
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using UGB.Application;
using UGB.Infrastructure;
using UGB.Services.Hubs;
using UGB.Services.Middleware;
namespace UGB.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        IConfiguration Configuration = builder.Configuration;
        
        //Token para encriptar JWT
        var TOKEN_KEY = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("TOKEN_KEY")!);

        //Se agregan las dependencias
        builder.Services.AddInfraestructure(builder.Configuration).AddApplication();

        //Directiva para omitir la validación de entidades anidadas
        builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)

        //directiva para ignorar los campos nulos y referencias cíclicas en los json
        .AddJsonOptions(options => {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

        //Directiva para habilitar cors
        builder.Services.AddCors(o => o.AddPolicy("AllowCors", builder =>
            {
                builder.SetIsOriginAllowedToAllowWildcardSubdomains()
                       .WithOrigins(Configuration.GetValue<string>("AllowedOrigin")!)
                       .AllowAnyMethod()
                       .AllowCredentials()
                       .AllowAnyHeader();
            }));

        //Directiva para habilitar autenticación JWT
        builder.Services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.RequireAuthenticatedSignIn = true;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(TOKEN_KEY),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        //Directiva para habilitar politicas de seguridad
        //Valida que el token exista en la cabecera en los métodos o controladores que se indique para permitir el acceso
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddAuthorization(options => 
            options.AddPolicy("HeaderToken", policy => policy.Requirements.Add(new TokenValidationMiddleware()))
        );
        builder.Services.AddTransient<IAuthorizationHandler, TokenValidationHandler>();

        //Para agregar openapi
        builder.Services.AddOpenApi();

        //Habilitamos signalr
        builder.Services.AddSignalR(o =>
        {
            o.EnableDetailedErrors = true;
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/openapi/v1.json", "UGB Api");
            });
        }       

        //Habilitar el middleware para errores
        app.UseMiddleware<ErrorHandlerMiddleware>();
        app.UseHttpsRedirection();

        //Para habilitar autenticación y autorización
        app.UseAuthentication();
        app.UseAuthorization();

        //Ruta para signalr
        app.MapHub<SignalRMessageHub>("/signalRMessageHub");

        //Habilitamos cors
        app.UseCors("AllowCors");

        app.MapControllers();
        
        app.Run();
    }
}

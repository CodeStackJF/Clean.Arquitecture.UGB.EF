using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UGB.Services.Middleware
{
    /// <summary>
    /// Middleware para validar que se ha enviado un token en la cabecera
    /// </summary>
    public class TokenValidationMiddleware:IAuthorizationRequirement
    {
        
    }

    public class TokenValidationHandler:AuthorizationHandler<TokenValidationMiddleware>
    {
        private readonly IConfiguration config;
        private readonly IHttpContextAccessor contextAccessor;
        public TokenValidationHandler(IConfiguration _config, IHttpContextAccessor _context)
        {
            config = _config;
            contextAccessor = _context;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TokenValidationMiddleware requirement)
        {
            string token = config.GetValue<string>("HEADER_TOKEN")!;
            string token_header = contextAccessor.HttpContext!.Request.Headers.Where(x=>x.Key == "X-Token").SingleOrDefault().Value!;
            if(string.IsNullOrWhiteSpace(token_header) || !token_header.Equals(token))
            {
                context.Fail(); 
                context.Succeed(requirement);               
            }
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
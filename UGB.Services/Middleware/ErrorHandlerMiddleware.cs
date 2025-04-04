using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using UGB.Application.Exceptions;
using UGB.Domain.Entities;
using UGB.Domain.Interfaces;
using UGB.Services.Helper;

namespace UGB.Services.Middleware
{
    public class ErrorHandlerMiddleware
    {   
        /// <summary>
        /// Middleware para la captura de errores personalizado
        /// </summary>
        private readonly RequestDelegate _next;
        private readonly IRaCarrerasRepository raCarrerasRepository;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                await HandleExceptionAsync(context, error);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var responseModel = new Wrapper.Response();
            switch (error)
            {
                case SqlException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.Message = e.Message;
                    responseModel.StatusCode = 500;
                    break;
                case CustomValidationException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.ValidationErrors = e.Errors;
                    responseModel.StatusCode = response.StatusCode;
                    break;
                case ValidationException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.Message = e.Message;
                    responseModel.StatusCode = response.StatusCode;
                    break;
                case KeyNotFoundException e:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    responseModel.Message = e.Message;
                    responseModel.StatusCode = response.StatusCode;
                    break;
                case AuthenticationException e:
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    responseModel.Message = e.Message;
                    responseModel.StatusCode = response.StatusCode;
                    break;
                case HttpRequestException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.Message = e.Message;
                    responseModel.StatusCode = response.StatusCode;
                    break;
                case NotFoundException e:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    responseModel.Message = e.Message;
                    responseModel.StatusCode = response.StatusCode;
                    break;
                case UnauthorizedAccessException e:
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    responseModel.Message = e.Message;
                    responseModel.StatusCode = response.StatusCode;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    responseModel.Message = error.Message + " | " + (error.InnerException != null ? error.InnerException.Message:"");
                    responseModel.StatusCode = response.StatusCode;
                    break;
            }

            JsonSerializerOptions jso = new JsonSerializerOptions();
            jso.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            var result = JsonSerializer.Serialize(responseModel,jso);

            if(context.User.Identity!.IsAuthenticated)
            {
                var logsRepository = context.RequestServices.GetService<IHttpLogsRepository>()!;
                context.Request.EnableBuffering();
                var bodyStream = new StreamReader(context.Request.Body);
                bodyStream.BaseStream.Seek(0, SeekOrigin.Begin);
                
                http_logs log = new http_logs()
                {
                    statusCode = response.StatusCode,
                    request = bodyStream.ReadToEnd(),
                    response = result,
                    url = context.Request.GetDisplayUrl(),
                    date = DateTime.Now,
                    username = context.User.GetProperty(ClaimTypes.NameIdentifier),
                    method = context.Request.Method
                };
                logsRepository.Create(log);
            }

            return response.WriteAsync(result);
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Store.API.Errors;
using Store.ApplicationService.Error;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
            IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationError er)
            {
                await SendValidationErrorResponse(context, (int)HttpStatusCode.BadRequest, er.GetMessages().ToArray());
            }
            catch (Exception ex)
            {
                if (ex is NotFoundError)
                {
                    await SendErrorResponse(context, (int)HttpStatusCode.NotFound, ex.Message);
                }
                else if (ex is NotAuthorizedError)
                {
                    await SendErrorResponse(context, (int)HttpStatusCode.Unauthorized, ex.Message);
                }
                else if (ex is UnKnownError)
                {
                    await SendErrorResponse(context, (int)HttpStatusCode.BadRequest, ex.Message);
                }
                else
                {
                    _logger.LogError(ex, ex.Message);
                    await SendExceptionResponse(context, ex);
                }
            }

        }

        private async Task SendErrorResponse(HttpContext context, int statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new ErrorResponse(statusCode, message);

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var jsonResponse = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(jsonResponse);
        }

        private async Task SendValidationErrorResponse(HttpContext context, int statusCode, string[] message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new ValidationResponse()
            {
                Errors = message
            };

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var jsonResponse = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(jsonResponse);
        }

        private async Task SendExceptionResponse(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = _env.IsDevelopment()
                ? new ExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                : new ExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString());

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var jsonResponse = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(jsonResponse);
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Store.API.Errors;
using Store.ApplicationService.Errors;
using Store.ApplicationService.Errors.BaseTypes;
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
            catch (MultipleErrors er)
            {
                if (er is ValidationErrors)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }

                await SendMultipleErrorResponse(context, er.GetErrors().ToArray());
            }
            catch (SingleError er)
            {
                if (er is NotFoundError)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                }
                else if (er is NotAuthorizedError)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                }
                else if (er is UnKnownError)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }

                await SendSingleErrorResponse(context, (int)HttpStatusCode.NotFound, er.GetError());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await SendExceptionResponse(context, ex);
            }

        }

        private async Task SendSingleErrorResponse(HttpContext context, int statusCode, string message)
        {
            context.Response.ContentType = "application/json";

            var response = new ErrorResponse(context.Response.StatusCode, message);
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var jsonResponse = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(jsonResponse);
        }

        private async Task SendMultipleErrorResponse(HttpContext context, string[] message)
        {
            context.Response.ContentType = "application/json";

            var response = new MultipleErrorResponse()
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

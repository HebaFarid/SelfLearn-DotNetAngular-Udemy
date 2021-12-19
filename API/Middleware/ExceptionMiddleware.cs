using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        //RequestDelegate: is a function that can process an http request
        //IHostEnvirnment: is used to check if we are in development modes
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); //if there is no exception the request moves on to its next stage    
            }
            catch (Exception ex)
            {                
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json"; //to write our own response in the context response so that we can send it back to the client
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment() ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                    :  new ApiException((int)HttpStatusCode.InternalServerError);

                var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
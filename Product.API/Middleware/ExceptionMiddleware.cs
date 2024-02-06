using Product.API.Errors;
using System.Net;
using System.Text.Json;

namespace Product.API.Middleware
{
    public class ExceptionMiddleware
    {
        //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _hostEnvironment;

        public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> logger, IHostEnvironment hostEnvironment)
        {
            _next = next;
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
                _logger.LogInformation("Success");
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, $"This Error come From exception Middleware {ex.Message} !");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = _hostEnvironment.IsDevelopment()
                    ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                    : new ApiException((int)HttpStatusCode.InternalServerError);

          var options =new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);

            }
        }
    }
}

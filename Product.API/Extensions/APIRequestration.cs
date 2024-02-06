using Microsoft.AspNetCore.Mvc;
using Product.API.Errors;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

namespace Product.API.Extensions
{
    public static class APIRequestration
    {
        public static IServiceCollection AddApiReguestration(this IServiceCollection services) 
        {
            //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

            // AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //FileProvide
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot"
                )));


            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.InvalidModelStateResponseFactory = context =>
                {
                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = context.ModelState
                                .Where(x => x.Value.Errors.Count > 0)
                                .SelectMany(x => x.Value.Errors)
                                .Select(x => x.ErrorMessage).ToArray()
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });

            //Enable CORS
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", pol =>
                {
                    pol.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://localhost:4200");
                });
            });
            return services;
        }
    }
}

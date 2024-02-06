//Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Core.Interface;
using Product.Infrastructure.Data;
using Product.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure
{
    public static class InfraStructureRequistration
    {
        public static IServiceCollection InfraStructureConfigration (this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //  services.AddScoped<ICategoryRepository, CategoryRepository>();
            // services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefualtConnection"))
            );

            return services;
        }
    }
}
//Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1


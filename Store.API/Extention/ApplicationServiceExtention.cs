using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Store.API.Errors;
using Store.ApplicationService.Contract;
using Store.ApplicationService.Factory;
using Store.ApplicationService.FactoryImplementation;
using Store.ApplicationService.ProductService;
using Store.Core.Products.DataContract;
using Store.Core.Products.ServiceContract;
using Store.Infrastructure.Data;
using Store.Infrastructure.Data.Products;
using System.Linq;

namespace Store.API.Extention
{
    public static class ApplicationServiceExtention
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, StoreUnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ErrorFactory, ErrorFactoryImplementation>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage)
                        .ToArray();

                    var errorResponse = new MultipleErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}

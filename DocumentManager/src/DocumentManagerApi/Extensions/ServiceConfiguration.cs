using Microsoft.AspNetCore.Mvc;
using MediatR;
using DocumentManagerApi.Features.Documents.Interfaces;
using DocumentManagerApi.Features.Documents;
using System.Reflection;
using DocumentManagerApi.Filters;

namespace UserManager.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddService(this IServiceCollection service, WebApplicationBuilder builder)
        {
            service.AddScoped<IDocumentRepository, DocumentRepository>();
            service.AddHttpContextAccessor();

            service.AddControllers(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            });
            
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();

            service.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            return service;
        }
    }
}

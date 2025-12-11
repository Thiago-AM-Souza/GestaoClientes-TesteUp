using GestaoClientes.WebApi.API.Middlewares;
using Microsoft.OpenApi;

namespace GestaoClientes.WebApi.API.Bootstrapper.Api
{
    public static class ApiBootstrapper
    {
        public static IServiceCollection AddApiModule(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gestão Clientes API", Version = "v1" });
                c.DocInclusionPredicate((_, api) => !string.IsNullOrEmpty(api.GroupName));

                c.TagActionsBy(api =>
                {
                    if (!string.IsNullOrEmpty(api.GroupName))
                    {
                        return [api.GroupName];
                    }

                    var endpointGroupName = api.ActionDescriptor.EndpointMetadata
                        .OfType<IEndpointGroupNameMetadata>()
                        .FirstOrDefault()?.EndpointGroupName;

                    return endpointGroupName != null ? [endpointGroupName] : new[] { "Outros" };
                });
            });

            services.AddTransient<ExceptionHandlingMiddleware>();

            return services;
        }
    }
}

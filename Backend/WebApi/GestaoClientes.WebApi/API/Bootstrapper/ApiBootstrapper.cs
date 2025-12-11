using GestaoClientes.WebApi.API.Bootstrapper.Api;
using GestaoClientes.WebApi.API.Bootstrapper.Application;
using GestaoClientes.WebApi.API.Bootstrapper.Infrastructure;

namespace GestaoClientes.WebApi.API.Bootstrapper
{
    public static class ApiBootstrapper
    {
        public static IServiceCollection AddApiBootstrapper(this IServiceCollection services,
                                                            IConfiguration configuration)
        {
            services.AddApplicationModule()
                    .AddInfrastructureModule(configuration)
                    .AddApiModule();

            return services;
        }
    }
}

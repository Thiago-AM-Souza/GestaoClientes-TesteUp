using GestaoClientes.Infrastructure.Configuration;

namespace GestaoClientes.WebApi.API.Bootstrapper.Infrastructure
{
    public static class InfrastructureBootstrapper
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services,
                                                                 IConfiguration configuration)
        {
            services.AddInfrastructure(configuration);
            return services;
        }
    }
}

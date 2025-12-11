using GestaoClientes.Application.Clientes;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoClientes.Application.Configuration
{
    public static class ApplicationBootstrapper
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddClienteModule();

            return services;
        }
    }
}

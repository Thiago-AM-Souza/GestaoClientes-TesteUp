using GestaoClientes.Application.Configuration;

namespace GestaoClientes.WebApi.API.Bootstrapper.Application
{
    public static class ApplicationBootstrapper
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddApplication();
            return services;
        }
    }
}

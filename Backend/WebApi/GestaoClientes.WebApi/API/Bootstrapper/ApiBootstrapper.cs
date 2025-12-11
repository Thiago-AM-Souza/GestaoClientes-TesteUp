using GestaoClientes.WebApi.API.Bootstrapper.Application;

namespace GestaoClientes.WebApi.API.Bootstrapper
{
    public static class ApiBootstrapper
    {
        public static IServiceCollection AddApiBootstrapper(this IServiceCollection services)
        {
            services.AddApplicationModule();

            return services;
        }
    }
}

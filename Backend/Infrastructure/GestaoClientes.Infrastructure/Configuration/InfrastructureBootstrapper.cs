using GestaoClientes.Domain.Interfaces;
using GestaoClientes.Infrastructure.Database;
using GestaoClientes.Infrastructure.Repositories.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoClientes.Infrastructure.Configuration
{
    public static class InfrastructureBootstrapper
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                           IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IClienteRepository, ClienteRepository>();

            return services;
        }
    }
}

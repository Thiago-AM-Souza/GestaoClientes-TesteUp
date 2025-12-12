using GestaoClientes.Application.Clientes.Commands.Create;
using GestaoClientes.Application.Clientes.Commands.Delete;
using GestaoClientes.Application.Clientes.Commands.Status;
using GestaoClientes.Application.Clientes.Commands.Update;
using GestaoClientes.Application.Clientes.Queries.GetAll;
using GestaoClientes.Application.Clientes.Queries.GetById;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoClientes.Application.Clientes
{
    public static class ClienteBootstrapper
    {
        public static IServiceCollection AddClienteModule(this IServiceCollection services)
        {
            // Commands
            services.AddScoped<CreateClienteHandler>();
            services.AddScoped<UpdateClienteHandler>();
            services.AddScoped<DeleteClienteHandler>();
            services.AddScoped<StatusClienteAtivarHandler>();
            services.AddScoped<StatusClienteDesativarHandler>();

            // Queries
            services.AddScoped<GetClienteByIdHandler>();
            services.AddScoped<GetClientesHandler>();

            return services;
        }
    }
}

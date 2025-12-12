using GestaoClientes.Application.ApplicationErrors;
using GestaoClientes.BuildingBlocks.Core.Errors;
using GestaoClientes.Domain.Interfaces;
using OneOf;

namespace GestaoClientes.Application.Clientes.Commands.Status
{
    public class StatusClienteDesativarHandler
    {
        private readonly IClienteRepository _clienteRepository;

        public StatusClienteDesativarHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<OneOf<bool, AppError>> Handler(StatusClienteCommand command)
        {
            var cliente = await _clienteRepository.GetClienteById(command.Id);

            if (cliente is null)
            {
                return new ClienteNotFound("Cliente não encontrado na base de dados.");
            }

            cliente.Desativar();

            await _clienteRepository.UpdateCliente(cliente);

            return true;
        }
    }
}

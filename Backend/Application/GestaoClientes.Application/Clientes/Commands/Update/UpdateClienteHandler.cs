using GestaoClientes.Application.ApplicationErrors;
using GestaoClientes.Application.Clientes.Commands.Create;
using GestaoClientes.BuildingBlocks.Core.Errors;
using GestaoClientes.BuildingBlocks.Extensions;
using GestaoClientes.Domain.Clientes;
using GestaoClientes.Domain.Interfaces;
using GestaoClientes.Domain.ValueObjects;
using OneOf;

namespace GestaoClientes.Application.Clientes.Commands.Update
{
    public class UpdateClienteHandler
    {
        private readonly IClienteRepository _clienteRepository;

        public UpdateClienteHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<OneOf<bool, AppError>> Handler(Guid id, UpdateClienteCommand command)
        {
            var cliente = await _clienteRepository.GetClienteById(id);

            if (cliente is null)
            {
                return new ClienteNotFound("Cliente não encontrado na base de dados.");
            }

            var cpfResult = Cpf.Criar(command.Cpf);

            if (cpfResult.IsError())
            {
                return cpfResult.GetErrorResult();
            }

            var emailResult = Email.Criar(command.Email);

            if (emailResult.IsError())
            {
                return emailResult.GetErrorResult();
            }

            cliente.Alterar(command.Nome,
                            cpfResult.GetSuccessResult(),
                            emailResult.GetSuccessResult());

            await _clienteRepository.UpdateCliente(cliente);

            return true;
        }
    }
}

using GestaoClientes.BuildingBlocks.Core.Errors;
using GestaoClientes.BuildingBlocks.Extensions;
using GestaoClientes.Domain.ValueObjects;
using GestaoClientes.Domain.Clientes;
using OneOf;
using GestaoClientes.Domain.Enums;
using GestaoClientes.Domain.Interfaces;
using GestaoClientes.Application.ApplicationErrors;

namespace GestaoClientes.Application.Clientes.Commands.Create
{
    public class CreateClienteHandler
    {
        private readonly IClienteRepository _clienteRepository;

        public CreateClienteHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<OneOf<Guid, AppError>> Handler(CreateClienteCommand command)
        {
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

            var clienteExistente = await _clienteRepository.GetClienteByEmail(emailResult.GetSuccessResult().Valor);

            if (clienteExistente is not null)
            {
                return new ClienteExists("Já existe um usuário cadastrado com este email.");
            }

            var cliente = new Cliente(command.Nome,
                                      cpfResult.GetSuccessResult(),
                                      emailResult.GetSuccessResult());

            if (command.Telefones is not null)
            {
                foreach(var tel in command.Telefones)
                {
                    var telefone = new Telefone((TipoTelefone)tel.TipoTelefone,
                                                tel.Numero);

                    cliente.AdicionarTelefone(telefone);
                }
            }

            await _clienteRepository.CreateCliente(cliente);            

            return cliente.Id;
        }
    }
}

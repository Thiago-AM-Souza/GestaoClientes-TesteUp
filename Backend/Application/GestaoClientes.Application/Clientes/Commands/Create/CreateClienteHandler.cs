using GestaoClientes.BuildingBlocks.Core.Errors;
using GestaoClientes.BuildingBlocks.Extensions;
using GestaoClientes.Domain.ValueObjects;
using GestaoClientes.Domain.Clientes;
using OneOf;
using GestaoClientes.Domain.Enums;

namespace GestaoClientes.Application.Clientes.Commands.Create
{
    public class CreateClienteHandler
    {
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

            return cliente.Id;
        }
    }
}

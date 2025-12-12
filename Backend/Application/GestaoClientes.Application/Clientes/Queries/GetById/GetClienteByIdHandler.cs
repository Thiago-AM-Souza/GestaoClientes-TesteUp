using GestaoClientes.Application.ApplicationErrors;
using GestaoClientes.BuildingBlocks.Core.Errors;
using GestaoClientes.Domain.Interfaces;
using OneOf;

namespace GestaoClientes.Application.Clientes.Queries.GetById
{
    public class GetClienteByIdHandler
    {
        private readonly IClienteRepository _clienteRepository;

        public GetClienteByIdHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<OneOf<ClienteDto, AppError>> Handler(GetClienteByIdQuery query)
        {
            var cliente = await _clienteRepository.GetClienteById(query.Id);

            if (cliente is null)
            {
                return new ClienteNotFound("Cliente não encontrado na base de dados.");
            }

            var dto = new ClienteDto(cliente.Id,
                                     cliente.Nome,
                                     cliente.Cpf.Valor,
                                     cliente.Email.Valor,
                                     cliente.Ativo,
                                     cliente.Telefones.Select(x => 
                                                new TelefoneDto((int)x.TipoTelefone,
                                                                x.Valor))
                                     .ToList());

            return dto;
        }
    }
}

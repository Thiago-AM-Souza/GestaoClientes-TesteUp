using GestaoClientes.Application.Clientes.Queries.GetById;
using GestaoClientes.BuildingBlocks.Core.Errors;
using GestaoClientes.Domain.Interfaces;
using OneOf;
using TelefoneDto = GestaoClientes.Application.Clientes.Queries.GetById.TelefoneDto;

namespace GestaoClientes.Application.Clientes.Queries.GetAll
{
    public class GetClientesHandler
    {
        private readonly IClienteRepository _clienteRepository;

        public GetClientesHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<OneOf<List<ClienteDto>, AppError>> Handler()
        {
            var clientes = await _clienteRepository.GetAll();

            var dto = clientes.Select(x => 
                            new ClienteDto(x.Id,
                                           x.Nome,
                                           x.Cpf.Valor,
                                           x.Email.Valor,
                                           x.Ativo,
                                           x.Telefones.Select(t => 
                                                new TelefoneDto((int)t.TipoTelefone,
                                                                t.Valor))
                                                .ToList()))
                .ToList();

            return dto;
        }
    }
}

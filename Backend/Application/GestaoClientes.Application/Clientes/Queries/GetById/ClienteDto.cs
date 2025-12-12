namespace GestaoClientes.Application.Clientes.Queries.GetById
{
    public record ClienteDto(Guid Id,
                             string Nome,
                             string Cpf,
                             string Email,
                             bool Ativo,
                             List<TelefoneDto> Telefones);

    public record TelefoneDto(int TipoTelefone,
                              string Numero);
}

namespace GestaoClientes.Application.Clientes.Commands.Create
{
    public record CreateClienteCommand(string Nome,
                                       string Email,
                                       string Cpf,
                                       List<TelefoneDto> Telefones);

    public record TelefoneDto(int TipoTelefone, string Numero);
}

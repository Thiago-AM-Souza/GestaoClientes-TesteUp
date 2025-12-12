namespace GestaoClientes.Application.Clientes.Commands.Update
{
    public record UpdateClienteCommand(string Nome,
                                       string Email,
                                       string Cpf);
}

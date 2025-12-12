using GestaoClientes.Domain.Clientes;

namespace GestaoClientes.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task CreateCliente(Cliente cliente);
        Task<Cliente?> GetClienteByEmail(string email);
        Task<Cliente?> GetClienteById(Guid id);
        Task UpdateCliente(Cliente cliente);
        Task<List<Cliente>> GetAll();
    }
}

using GestaoClientes.Domain.Clientes;
using GestaoClientes.Domain.Interfaces;
using GestaoClientes.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace GestaoClientes.Infrastructure.Repositories.Clientes
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateCliente(Cliente cliente)
        {
            try
            {
                await _context.Clientes.AddAsync(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
        }

        public async Task<Cliente?> GetClienteByEmail(string email)
        {
            var usuario = await _context.Clientes
                                        .Where(x => x.Email.Valor == email)
                                        .FirstOrDefaultAsync();

            return usuario;
        }
    }
}

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
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cliente>> GetAll()
        {
            var clientes = new List<Cliente>();

            clientes = await _context.Clientes
                                     .ToListAsync();

            return clientes;
        }

        public async Task<Cliente?> GetClienteByEmail(string email)
        {
            var usuario = await _context.Clientes
                                        .Where(x => x.Email.Valor == email)
                                        .FirstOrDefaultAsync();

            return usuario;
        }

        public async Task<Cliente?> GetClienteById(Guid id)
        {
            var usuario = await _context.Clientes
                                        .FindAsync(id);

            return usuario;
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}

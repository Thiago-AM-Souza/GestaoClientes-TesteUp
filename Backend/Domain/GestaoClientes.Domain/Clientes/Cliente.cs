using GestaoClientes.Domain.ValueObjects;

namespace GestaoClientes.Domain.Clientes
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; } = default!;
        public Cpf Cpf { get; private set; } = default!;
        public Email Email { get; private set; } = default!;

        private List<Telefone> _telefones = new();
        public IReadOnlyList<Telefone> Telefones => _telefones;

        protected Cliente() { }

        public Cliente(string nome, 
                       Cpf cpf, 
                       Email email)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
        }
    }
}

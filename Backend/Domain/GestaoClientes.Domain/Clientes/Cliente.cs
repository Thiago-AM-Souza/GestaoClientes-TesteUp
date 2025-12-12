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
        public bool Ativo { get; private set; }

        protected Cliente() { }

        public Cliente(string nome, 
                       Cpf cpf, 
                       Email email)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Ativo = true;
        }

        public void AdicionarTelefone(Telefone telefone)
        {
            if (!_telefones.Contains(telefone))
            {
                _telefones.Add(telefone);
            }
        }

        public void RemoverTelefone(Telefone telefone)
        {
            _telefones.Remove(telefone);
        }

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void Alterar(string nome,
                            Cpf cpf,
                            Email email)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
        }
    }
}

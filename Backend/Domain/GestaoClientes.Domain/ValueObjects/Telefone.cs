using GestaoClientes.Domain.Enums;

namespace GestaoClientes.Domain.ValueObjects
{
    public class Telefone
    {
        public TipoTelefone TipoTelefone { get; }
        public string Valor { get; } = default!;

        protected Telefone() { }

        public Telefone(TipoTelefone tipoTelefone, 
                        string telefone)
        {
            TipoTelefone = tipoTelefone;
            Valor = telefone;
        }
    }
}

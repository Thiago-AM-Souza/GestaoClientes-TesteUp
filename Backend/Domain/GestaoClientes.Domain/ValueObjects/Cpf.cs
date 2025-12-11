namespace GestaoClientes.Domain.ValueObjects
{
    public class Cpf
    {
        public string Valor { get; set; }

        private Cpf(string cpf) 
        { 
            Valor = cpf;
        }

        public static Cpf Criar(string cpf)
        {
            return new Cpf(cpf);
        }
    }
}

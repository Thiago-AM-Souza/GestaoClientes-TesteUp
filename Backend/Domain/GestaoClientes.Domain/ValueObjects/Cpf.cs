using GestaoClientes.Domain.DomainErrors;

namespace GestaoClientes.Domain.ValueObjects
{
    public class Cpf
    {
        public string Valor { get; set; } = default!;

        private Cpf(string cpf) 
        { 
            Valor = cpf;
        }

        protected Cpf() { }

        public static OneOf<Cpf, AppError> Criar(string cpf)
        {
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (!ValidarCpf(cpf))
            {
                return new CpfValidation("Cpf inválido.");
            }

            return new Cpf(cpf);
        }

        private static bool ValidarCpf(string cpf)
        {
            int[] multiplicador1 = [10, 9, 8, 7, 6, 5, 4, 3, 2 ];
            int[] multiplicador2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];
            string tempCpf;
            string digito;
            int soma;
            int resto;            

            if (cpf.Length != 11)
            {
                return false;
            }

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}

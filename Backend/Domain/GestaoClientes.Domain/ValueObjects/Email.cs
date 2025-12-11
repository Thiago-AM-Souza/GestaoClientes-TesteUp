using GestaoClientes.Domain.DomainErrors;
using System.Text.RegularExpressions;

namespace GestaoClientes.Domain.ValueObjects
{
    public class Email
    {
        public string Valor { get; } = default!;

        private Email(string email)
        {
            Valor = email;
        }

        protected Email() { }

        public static OneOf<Email, AppError> Criar(string email)
        {
            var regex = new Regex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$");

            var valido = regex.IsMatch(email);

            if (!valido)
            {
                return new EmailValidation("Email inválido.");
            }

            return new Email(email);
        }
    }
}

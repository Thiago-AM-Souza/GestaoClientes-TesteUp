

using GestaoClientes.BuildingBlocks.Core.Errors;
using System.Text.RegularExpressions;

namespace GestaoClientes.Domain.ValueObjects
{
    public class Email
    {
        public string Valor { get; }

        private Email(string email)
        {
            Valor = email;
        }

        public static OneOf<Email, AppError> Criar(string email)
        {
            var regex = new Regex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$");

            var valido = regex.IsMatch(email);

            if (!valido)
            {
                //return
            }

            return new Email(email);
        }
    }
}

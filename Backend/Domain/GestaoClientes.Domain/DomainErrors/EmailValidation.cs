namespace GestaoClientes.Domain.DomainErrors
{
    public record EmailValidation(string Details, ErrorType ErrorType = ErrorType.Validation) 
        : AppError(Details, ErrorType);
}

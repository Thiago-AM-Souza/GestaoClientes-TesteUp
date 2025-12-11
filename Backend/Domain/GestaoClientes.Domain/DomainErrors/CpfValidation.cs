namespace GestaoClientes.Domain.DomainErrors
{
    public record CpfValidation(string Details, ErrorType ErrorType = ErrorType.Validation)
        : AppError(Details, ErrorType);
}

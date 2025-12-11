namespace GestaoClientes.BuildingBlocks.Core.Errors
{
    public abstract record AppError(string Details, ErrorType ErrorType);

    public enum ErrorType
    {
        Validation,
        BusinessRule,
    }
}

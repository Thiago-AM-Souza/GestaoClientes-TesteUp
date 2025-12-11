using GestaoClientes.BuildingBlocks.Core.Errors;

namespace GestaoClientes.Application.ApplicationErrors
{
    public record ClienteExists(string Details, ErrorType ErrorType = ErrorType.BusinessRule) 
        : AppError(Details, ErrorType);
}

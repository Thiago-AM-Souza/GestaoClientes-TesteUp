using GestaoClientes.BuildingBlocks.Core.Errors;

namespace GestaoClientes.Application.ApplicationErrors
{
    public record ClienteNotFound(string Details, ErrorType ErrorType = ErrorType.NotFound)
        : AppError(Details, ErrorType);
}

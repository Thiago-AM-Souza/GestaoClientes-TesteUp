using GestaoClientes.BuildingBlocks.Core.Errors;

namespace GestaoClientes.WebApi.API.Responses
{
    public static class ResponseResult
    {
        public static IResult Response(this AppError appError)
        {
            return appError.ErrorType switch
            {
                ErrorType.Validation => Results.BadRequest(new { error = appError.ErrorType.ToString(), details = appError.Details }),
                ErrorType.BusinessRule => Results.Conflict(new { error = appError.ErrorType.ToString(), details = appError.Details }),
                _ => Results.InternalServerError("Erro interno no servidor")
            };
        }
    }
}

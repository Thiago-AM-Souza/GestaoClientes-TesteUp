using GestaoClientes.Application.Clientes.Commands.Create;
using GestaoClientes.BuildingBlocks.Extensions;
using GestaoClientes.WebApi.API.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GestaoClientes.WebApi.API.Controllers.Clientes
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        public async Task<IResult> CreateCliente([FromBody] CreateClienteCommand command,
                                                 [FromServices] CreateClienteHandler handler)
        {
            var result = await handler.Handler(command);

            if (result.IsError())
            {
                return result.GetErrorResult().Response();
            }

            return Results.Created("api/cliente", new
            {
                Id = result.GetSuccessResult()
            });
        }
    }
}

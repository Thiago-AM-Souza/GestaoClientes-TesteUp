using GestaoClientes.Application.Clientes.Commands.Create;
using GestaoClientes.Application.Clientes.Commands.Status;
using GestaoClientes.Application.Clientes.Commands.Update;
using GestaoClientes.Application.Clientes.Queries.GetAll;
using GestaoClientes.Application.Clientes.Queries.GetById;
using GestaoClientes.BuildingBlocks.Extensions;
using GestaoClientes.WebApi.API.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GestaoClientes.WebApi.API.Controllers.Clientes
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [EndpointGroupName("Clientes")]
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

        [HttpPut("{id:Guid}")]
        public async Task<IResult> UpdateCliente(Guid id,
                                                [FromBody] UpdateClienteCommand command,
                                                [FromServices] UpdateClienteHandler handler)
        {
            var result = await handler.Handler(id, command);

            if (result.IsError())
            {
                return result.GetErrorResult().Response();
            }

            return Results.Ok(result.GetSuccessResult());
        }

        [HttpGet("{id:Guid}")]
        public async Task<IResult> GetClienteById(Guid id,
                                                 [FromServices] GetClienteByIdHandler handler)
        {
            var result = await handler.Handler(new GetClienteByIdQuery(id));

            if (result.IsError())
            {
                return result.GetErrorResult().Response();
            }

            return Results.Ok(result.GetSuccessResult());
        }

        [HttpGet]
        public async Task<IResult> GetClientes(
            [FromServices] GetClientesHandler handler)
        {
            var result = await handler.Handler();

            if (result.IsError())
            {
                return result.GetErrorResult().Response();
            }

            return Results.Ok(result.GetSuccessResult());
        }

        [HttpPatch("{id:Guid}/ativar")]
        public async Task<IResult> AtivarCliente(Guid id,
                                                [FromServices] StatusClienteAtivarHandler handler)
        {
            var result = await handler.Handler(new StatusClienteCommand(id));

            if (result.IsError())
                return result.GetErrorResult().Response();

            return Results.NoContent();
        }

        [HttpPatch("{id:Guid}/desativar")]
        public async Task<IResult> DesativarCliente(Guid id,
                                                    [FromServices] StatusClienteDesativarHandler handler)
        {
            var result = await handler.Handler(new StatusClienteCommand(id));

            if (result.IsError())
                return result.GetErrorResult().Response();

            return Results.NoContent();
        }
    }
}

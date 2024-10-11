using Application.EmisionesCarbono.Create;
using Application.EmisionesCarbono.Delete;
using Application.EmisionesCarbono.GetAll;
using Application.EmisionesCarbono.GetById;
using Application.EmisionesCarbono.GetByIdEmpresa;
using Application.EmisionesCarbono.Update;
using MediatR;

namespace Api.PruebaTecnica.Controllers;


[Route("Emicion_Carbono")]
public class EmicionCarbono : ApiController
{
    private readonly ISender _mediator;
    public EmicionCarbono(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var permisosResult = await _mediator.Send(new GetAllEmisionesCarbonoQuery());

        return permisosResult.Match(
            permisos => Ok(permisos),
            errors => Problem(errors)
        );
    }
    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var customerResult = await _mediator.Send(new GetEmisionCarbonoByIdQuery(id));

        return customerResult.Match(
            customer => Ok(customer),
            errors => Problem(errors)
        );
    }

    [HttpGet("GetByIdEmpresa/{id}")]
    public async Task<IActionResult> GetByIdEmpresa(int id)
    {
        var customerResult = await _mediator.Send(new GetByIdEmpresaQuery(id));

        return customerResult.Match(
            customer => Ok(customer),
            errors => Problem(errors)
        );
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmisionCarbonoCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            customerId => Ok(customerId),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateEmisionCarbonoCommand command)
    {
        if (command.Id != id)
        {
            List<Error> errors = new()
            {
                Error.Validation("Permiso.UpdateInvalid", "El ID de la solicitud no coincide con el ID de la URL.")
            };
            return Problem(errors);
        }

        var updateResult = await _mediator.Send(command);

        return updateResult.Match(
            customerId => NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("Eliminar/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleteResult = await _mediator.Send(new DeleteEmisionCarbonoCommand(id));

        return deleteResult.Match(
            customerId => NoContent(),
            errors => Problem(errors)
        );
    }


}

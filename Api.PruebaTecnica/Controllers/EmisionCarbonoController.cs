using Application.EmisionesCarbono.GetAll;
using MediatR;

namespace Api.PruebaTecnica.Controllers;


[Route("Emicion de Carbono")]
public class EmicionCarbono : ApiController
{
    private readonly ISender _mediator;
    public EmicionCarbono(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var permisosResult = await _mediator.Send(new GetAllEmisionesCarbonoQuery());

        return permisosResult.Match(
            permisos => Ok(permisos),
            errors => Problem(errors)
        );
    }


}

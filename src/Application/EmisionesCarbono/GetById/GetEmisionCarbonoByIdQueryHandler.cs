using Application.EmisionesCarbono.Common;
using Domain.EmicionesCarbono;

namespace Application.EmisionesCarbono.GetById;

internal sealed class GetEmisionCarbonoByIdQueryHandler :
    IRequestHandler<GetEmisionCarbonoByIdQuery, ErrorOr<EmisionesCarbonoResponse>>
{
    private readonly IEmisionCarbonoRepository _repository;

    public GetEmisionCarbonoByIdQueryHandler(IEmisionCarbonoRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ErrorOr<EmisionesCarbonoResponse>> Handle(GetEmisionCarbonoByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _repository.GetByIdAsync((query.Id)) is not EmisionCarbono emisionCarbono)
        {
            return Error.NotFound("EmisionCarbono.NotFound", "");
        }

        return new EmisionesCarbonoResponse(
            emisionCarbono.Id,
            emisionCarbono.EmpresaId,
            emisionCarbono.Descripcion,
            emisionCarbono.Cantidad,
            emisionCarbono.FechaEmicion,
            emisionCarbono.TipoEmicion);
    }
}
using Application.EmisionesCarbono.Common;
using Domain.EmicionesCarbono;

namespace Application.EmisionesCarbono.GetAll;

internal class GetAllEmisionesCarbonoQueryHandler : IRequestHandler<GetAllEmisionesCarbonoQuery, ErrorOr<IReadOnlyList<EmisionesCarbonoResponse>>>
{
    private readonly IEmisionCarbonoRepository _repository;

    public GetAllEmisionesCarbonoQueryHandler(IEmisionCarbonoRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ErrorOr<IReadOnlyList<EmisionesCarbonoResponse>>> Handle(GetAllEmisionesCarbonoQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<EmisionCarbono> emisionCarbonos = await _repository.GetAll();

        return emisionCarbonos.Select(emision => new EmisionesCarbonoResponse(
               emision.Id,
               emision.EmpresaId,
               emision.Descripcion,
               emision.Cantidad,
               emision.FechaEmicion,
               emision.TipoEmicion
            )).ToList();
    }
}

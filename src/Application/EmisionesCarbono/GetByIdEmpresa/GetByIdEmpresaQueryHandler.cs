using Application.EmisionesCarbono.Common;
using Application.EmisionesCarbono.GetById;
using Domain.EmicionesCarbono;

namespace Application.EmisionesCarbono.GetByIdEmpresa;

internal class GetByIdEmpresaQueryHandler :
    IRequestHandler<GetByIdEmpresaQuery, ErrorOr<IReadOnlyList<EmisionesCarbonoResponse>>>
{
    private readonly IEmisionCarbonoRepository _repository;

    public GetByIdEmpresaQueryHandler(IEmisionCarbonoRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ErrorOr<IReadOnlyList<EmisionesCarbonoResponse>>> Handle(GetByIdEmpresaQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<EmisionCarbono> emisionCarbonos = await _repository.GetByIdEmpresaAsync(query.Id);

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
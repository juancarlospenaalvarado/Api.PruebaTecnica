using Application.EmisionesCarbono.Common;

namespace Application.EmisionesCarbono.GetByIdEmpresa;


public record GetByIdEmpresaQuery(int Id) : IRequest<ErrorOr<IReadOnlyList<EmisionesCarbonoResponse>>>;


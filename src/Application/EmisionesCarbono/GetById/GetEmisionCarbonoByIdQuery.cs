using Application.EmisionesCarbono.Common;

namespace Application.EmisionesCarbono.GetById;

public record GetEmisionCarbonoByIdQuery(int Id) : IRequest<ErrorOr<EmisionesCarbonoResponse>>;

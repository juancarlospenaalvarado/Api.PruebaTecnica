using Application.EmisionesCarbono.Common;

namespace Application.EmisionesCarbono.GetAll;

public record GetAllEmisionesCarbonoQuery() : 
    IRequest<ErrorOr<IReadOnlyList<EmisionesCarbonoResponse>>>;

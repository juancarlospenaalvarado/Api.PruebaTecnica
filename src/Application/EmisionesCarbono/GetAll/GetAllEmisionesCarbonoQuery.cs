using Application.EmisionesCarbono.Common;
using Domain.Security.Authorizations;
using Domain.Security.Policies;
using Domain.Security.Permissions;

namespace Application.EmisionesCarbono.GetAll;

//public record GetAllEmisionesCarbonoQuery() : 
//    IRequest<ErrorOr<IReadOnlyList<EmisionesCarbonoResponse>>>;


[Authorize(Permissions = Permission.EmisionCarbono.Get , Policies = Policy.SelfOrAdmin)]
public record GetAllEmisionesCarbonoQuery() :
    IAuthorizeableRequest<ErrorOr<IReadOnlyList<EmisionesCarbonoResponse>>>;

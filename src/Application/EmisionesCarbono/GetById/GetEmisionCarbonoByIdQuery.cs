using Application.EmisionesCarbono.Common;
using Domain.Security.Policies;
using Domain.Security.Authorizations;
using Domain.Security.Permissions;


namespace Application.EmisionesCarbono.GetById;

[Authorize(Permissions = Permission.EmisionCarbono.Get, Policies = Policy.SelfOrAdmin)]
public record GetEmisionCarbonoByIdQuery(int Id) : IAuthorizeableRequest<ErrorOr<EmisionesCarbonoResponse>>;

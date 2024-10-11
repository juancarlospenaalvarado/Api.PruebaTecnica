using Domain.Security.Policies;
using Domain.Security.Authorizations;
using Domain.Security.Permissions;

namespace Application.EmisionesCarbono.Delete;

[Authorize(Permissions = Permission.EmisionCarbono.Delete, Policies = Policy.SelfOrAdmin)]
public record DeleteEmisionCarbonoCommand (int Id) : IAuthorizeableRequest<ErrorOr<Unit>>;

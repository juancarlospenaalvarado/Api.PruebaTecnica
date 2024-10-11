using Application.EmisionesCarbono.Common;
using Domain.Security.Policies;
using Domain.Security.Authorizations;
using Domain.Security.Permissions;

namespace Application.EmisionesCarbono.GetByIdEmpresa;


[Authorize(Permissions = Permission.EmisionCarbono.Get, Policies = Policy.SelfOrAdmin)]
public record GetByIdEmpresaQuery(int Id) : IAuthorizeableRequest<ErrorOr<IReadOnlyList<EmisionesCarbonoResponse>>>;


namespace Application.EmisionesCarbono.Create;

using Domain.Security.Policies;
using Domain.Security.Authorizations;
using Domain.Security.Permissions;

[Authorize(Permissions = Permission.EmisionCarbono.Create, Policies = Policy.SelfOrAdmin)]
public record CreateEmisionCarbonoCommand(
    int EmpresaId,
    string Descripcion,
    Decimal Cantidad,
    string TipoEmision) : IAuthorizeableRequest<ErrorOr<int>>;

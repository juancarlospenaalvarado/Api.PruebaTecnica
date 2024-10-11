namespace Application.EmisionesCarbono.Update;
using Domain.Security.Policies;
using Domain.Security.Authorizations;
using Domain.Security.Permissions;

[Authorize(Permissions = Permission.EmisionCarbono.Update, Policies = Policy.SelfOrAdmin)]
public record UpdateEmisionCarbonoCommand(
    int Id,
    int EmpresaId,
    string Descripcion,
    Decimal Cantidad,
    string TipoEmision) : IAuthorizeableRequest<ErrorOr<Unit>>;

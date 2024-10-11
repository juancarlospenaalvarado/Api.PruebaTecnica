namespace Application.EmisionesCarbono.Update;

public record UpdateEmisionCarbonoCommand(
    int Id,
    int EmpresaId,
    string Descripcion,
    Decimal Cantidad,
    string TipoEmision) : IRequest<ErrorOr<Unit>>;

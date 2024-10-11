namespace Application.EmisionesCarbono.Create;


public record CreateEmisionCarbonoCommand(
    int EmpresaId,
    string Descripcion,
    Decimal Cantidad,
    string TipoEmision) : IRequest<ErrorOr<int>>;

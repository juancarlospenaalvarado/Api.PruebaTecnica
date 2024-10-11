namespace Application.EmisionesCarbono.Common;

public record EmisionesCarbonoResponse(
    int Id,
    int EmpresaId,
    string Descripcion,
    Decimal Cantidad,
    DateTime FechaEmision,
    string TipoEmision
    );

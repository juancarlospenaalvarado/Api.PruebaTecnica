using Domain.Primitives;

namespace Domain.EmicionesCarbono;

public sealed class EmisionCarbono : AggregateRoot
{
    public int Id {  get; set; }
    public int EmpresaId { get; set; }
    public string Descripcion { get; set; }
    public Decimal Cantidad { get; set; }
    public DateTime FechaEmicion {  get; set; }
    public string TipoEmicion {  set; get; }
    public bool Status {  get; set; }




    public EmisionCarbono(int id,
                          int empresaId,
                          string descripcion,
                          Decimal cantidad,
                          DateTime fechaEmicion,
                          string tipoEmicion)
    {
        Id = id;
        EmpresaId = empresaId;
        Descripcion = descripcion;
        Cantidad = cantidad;
        FechaEmicion = fechaEmicion;
        TipoEmicion = tipoEmicion;
        Status = Status;

    }

}

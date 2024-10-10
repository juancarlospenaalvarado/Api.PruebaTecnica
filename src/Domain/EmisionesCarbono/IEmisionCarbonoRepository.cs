namespace Domain.EmicionesCarbono;

public interface IEmisionCarbonoRepository
{

    Task<List<EmisionCarbono>> GetAll();
}

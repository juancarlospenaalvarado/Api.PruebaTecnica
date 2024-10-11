namespace Domain.EmicionesCarbono;

public interface IEmisionCarbonoRepository
{

    Task<List<EmisionCarbono>> GetAll();
    Task<EmisionCarbono> GetByIdAsync(int id);
    Task<List<EmisionCarbono>> GetByIdEmpresaAsync(int id);
    void Add(EmisionCarbono permiso);
    void Update(EmisionCarbono permiso);
    void Delete(EmisionCarbono permiso);
    Task<bool> ExistsAsync(int id);
}

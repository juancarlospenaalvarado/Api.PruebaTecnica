using Domain.EmicionesCarbono;
using System.Text.Json;

namespace Infrastructure.Persistence.Repositories;

public class EmisionCarbonoRepository : IEmisionCarbonoRepository
{
    private readonly ApplicationDbContext _context;

    public EmisionCarbonoRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }


    public async Task<List<EmisionCarbono>> GetAll() => await _context.EmisionCarbonos.Where(c => c.Status == true).ToListAsync();
    public async Task<EmisionCarbono?> GetByIdAsync(int id) => await _context.EmisionCarbonos.SingleOrDefaultAsync(c => (c.Id == id && c.Status == true));
    public async Task<List<EmisionCarbono>> GetByIdEmpresaAsync(int id) => await _context.EmisionCarbonos.Where(c => c.EmpresaId == id && c.Status == true).ToListAsync();
    public void Add(EmisionCarbono emisionCarbono) => _context.EmisionCarbonos.Add(emisionCarbono);
    public void Delete(EmisionCarbono emisionCarbono) => _context.EmisionCarbonos.Remove(emisionCarbono);
    public void Update(EmisionCarbono emisionCarbono) => _context.EmisionCarbonos.Update(emisionCarbono);
    public async Task<bool> ExistsAsync(int id) => await _context.EmisionCarbonos.AnyAsync(e => e.Id == id);
}

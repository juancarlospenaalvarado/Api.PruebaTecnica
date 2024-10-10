using Domain.EmicionesCarbono;

namespace Infrastructure.Persistence.Repositories;

public class EmisionCarbonoRepository : IEmisionCarbonoRepository
{
    private readonly ApplicationDbContext _context;

    public EmisionCarbonoRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }


     public async Task<List<EmisionCarbono>> GetAll() => await _context.EmisionCarbonos.ToListAsync();
    
}

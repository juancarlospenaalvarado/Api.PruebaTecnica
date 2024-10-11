using Domain.EmicionesCarbono;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<EmisionCarbono> EmisionCarbonos { get; set; }  
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
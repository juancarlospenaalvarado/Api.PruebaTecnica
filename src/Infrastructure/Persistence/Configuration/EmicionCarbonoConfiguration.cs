using Domain.EmicionesCarbono;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class  EmicionCarbonoConfiguration : IEntityTypeConfiguration<EmisionCarbono>
{
    public void Configure(EntityTypeBuilder<EmisionCarbono> builder)
    {
        builder.ToTable("EmisionCarbono");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.EmpresaId).HasMaxLength(50);

        builder.Property(c => c.Descripcion).HasMaxLength(50);

        builder.Property(c => c.Cantidad);

        builder.Property(c => c.FechaEmicion);


        builder.Property(c => c.TipoEmicion).HasMaxLength(255);




        builder.Property(c => c.Status);
    }
}

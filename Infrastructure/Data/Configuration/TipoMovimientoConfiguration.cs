using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TipoMovimientoConfiguration : IEntityTypeConfiguration<TipoMovimiento>
{
    public void Configure(EntityTypeBuilder<TipoMovimiento> builder)
    {
        builder.ToTable("tipomovimiento");
        builder.Property(p => p.Id)
                .IsRequired();

        builder.Property(p => p.Descripcion)
                .IsRequired()
                .HasMaxLength(100);     
    }
}
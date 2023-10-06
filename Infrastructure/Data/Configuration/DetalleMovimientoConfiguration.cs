using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class DetalleMovimientoConfiguration : IEntityTypeConfiguration<DetalleMovimiento>
{
    public void Configure(EntityTypeBuilder<DetalleMovimiento> builder)
    {
        builder.ToTable("detallemovimiento");
        builder.Property(p => p.Id)
                .IsRequired();
                
        builder.Property(p => p.Cantidad)
                .IsRequired()
                .HasColumnType("int");

        builder.Property(p => p.Precio)
                .IsRequired()
                .HasColumnType("int");

        builder.HasOne(y => y.Medicamento)
            .WithMany(l => l.DetalleMovimientos)
            .HasForeignKey(z => z.IdMedicamento)
            .IsRequired();

        builder.HasOne(y => y.MovimientoMedicamento)
            .WithMany(l => l.DetalleMovimientos)
            .HasForeignKey(z => z.IdMovMedicamento)
            .IsRequired();
        
    }
}
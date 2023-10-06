using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class MovimientoMedicamentoConfiguration : IEntityTypeConfiguration<MovimientoMedicamento>
{
    public void Configure(EntityTypeBuilder<MovimientoMedicamento> builder)
    {
        builder.ToTable("movimientomedicamento");
        builder.Property(p => p.Id)
                .IsRequired();

        builder.Property(p => p.Cantidad)
                .IsRequired()
                .HasColumnType("int");
                
        builder.Property(p => p.Fecha)
                .IsRequired()
                .HasColumnType("date");

        builder.HasOne(y => y.Medicamento)
            .WithMany(l => l.MovimientoMedicamentos)
            .HasForeignKey(z => z.IdMedicamento)
            .IsRequired();

        builder.HasOne(y => y.TipoMovimiento)
            .WithMany(l => l.MovimientoMedicamentos)
            .HasForeignKey(z => z.IdTipoMovimiento)
            .IsRequired();
        
    }
}
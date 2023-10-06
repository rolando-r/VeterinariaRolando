using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
{
    public void Configure(EntityTypeBuilder<Medicamento> builder)
    {
        builder.ToTable("medicamento");
        builder.Property(p => p.Id)
                .IsRequired();

        builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(200);

        builder.Property(p => p.CantidadDisponible)
                .IsRequired()
                .HasColumnType("int");
        
        builder.Property(p => p.Precio)
                .IsRequired()
                .HasColumnType("int");

        builder.HasOne(y => y.Laboratorio)
            .WithMany(l => l.Medicamentos)
            .HasForeignKey(z => z.IdLaboratorio)
            .IsRequired();

        builder
            .HasMany(p => p.Proveedores)
            .WithMany(p => p.Medicamentos)
            .UsingEntity<MedicamentoProveedores>(
                j => j
                    .HasOne(pt => pt.Proveedor)
                    .WithMany(t => t.MedicamentosProveedores)
                    .HasForeignKey(pt => pt.IdProveedor),
                j => j
                    .HasOne(pt => pt.Medicamento)
                    .WithMany(p => p.MedicamentosProveedores)
                    .HasForeignKey(pt => pt.IdMedicamento),
                j =>
                {
                    j.HasKey(t => new { t.IdMedicamento, t.IdProveedor });
                });
        
    }
}
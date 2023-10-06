using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class LaboratorioConfiguration : IEntityTypeConfiguration<Laboratorio>
{
    public void Configure(EntityTypeBuilder<Laboratorio> builder)
    {
        builder.ToTable("laboratorio");
        builder.Property(p => p.Id)
                .IsRequired();
                
        builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

        builder.Property(p => p.Direccion)
                .IsRequired()
                .HasMaxLength(200);

        builder.Property(p => p.Telefono)
                .IsRequired()
                .HasColumnType("int");
    }
}
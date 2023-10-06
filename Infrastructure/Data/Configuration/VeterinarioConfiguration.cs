using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class VeterinarioConfiguration : IEntityTypeConfiguration<Veterinario>
{
    public void Configure(EntityTypeBuilder<Veterinario> builder)
    {
        builder.ToTable("veterinario");
        builder.Property(p => p.Id)
                .IsRequired();

        builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);     

        builder.Property(p => p.CorreoElectronico)
                .IsRequired()
                .HasMaxLength(150); 

        builder.Property(p => p.Telefono)
                .IsRequired()
                .HasColumnType("int"); 

        builder.Property(p => p.Especialidad)
                .IsRequired()
                .HasMaxLength(150);
    }
}
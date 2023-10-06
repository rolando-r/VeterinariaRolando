using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>
{
    public void Configure(EntityTypeBuilder<Mascota> builder)
    {
        builder.ToTable("mascota");
        builder.Property(p => p.Id)
                .IsRequired();
                
        builder.Property(p => p.FechaNacimiento)
                .IsRequired()
                .HasColumnType("date");

        builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

        builder.HasOne(y => y.Propietario)
            .WithMany(l => l.Mascotas)
            .HasForeignKey(z => z.IdPropietario)
            .IsRequired();

        builder.HasOne(y => y.Especie)
            .WithMany(l => l.Mascotas)
            .HasForeignKey(z => z.IdEspecie)
            .IsRequired();

        builder.HasOne(y => y.Raza)
            .WithMany(l => l.Mascotas)
            .HasForeignKey(z => z.IdRaza)
            .IsRequired();
        
    }
}
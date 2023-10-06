using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class CitaConfiguration : IEntityTypeConfiguration<Cita>
{
    public void Configure(EntityTypeBuilder<Cita> builder)
    {
        builder.ToTable("cita");
        builder.Property(p => p.Id)
                .IsRequired();
                
        builder.Property(p => p.Fecha)
                .IsRequired()
                .HasColumnType("date");

        builder.Property(p => p.Motivo)
                .IsRequired()
                .HasMaxLength(200);

        builder.HasOne(y => y.Mascota)
            .WithMany(l => l.Citas)
            .HasForeignKey(z => z.IdMascota)
            .IsRequired();

        builder.HasOne(y => y.Veterinario)
            .WithMany(l => l.Citas)
            .HasForeignKey(z => z.IdVeterinario)
            .IsRequired();
        
    }
}
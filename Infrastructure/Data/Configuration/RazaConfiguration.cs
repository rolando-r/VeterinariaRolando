using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class RazaConfiguration : IEntityTypeConfiguration<Raza>
{
    public void Configure(EntityTypeBuilder<Raza> builder)
    {
        builder.ToTable("raza");
        builder.Property(p => p.Id)
                .IsRequired();

        builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);     

        builder.HasOne(y => y.Especie)
            .WithMany(l => l.Razas)
            .HasForeignKey(z => z.IdEspecie)
            .IsRequired();
    }
}
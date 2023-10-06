using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class EspecieConfiguration : IEntityTypeConfiguration<Especie>
{
    public void Configure(EntityTypeBuilder<Especie> builder)
    {
        builder.ToTable("especie");
        builder.Property(p => p.Id)
                .IsRequired();
                
        builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);
    }
}
using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("proveedor");
        builder.Property(p => p.Id)
                .IsRequired();

        builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);     

        builder.Property(p => p.Direccion)
                .IsRequired()
                .HasMaxLength(150); 

        builder.Property(p => p.Telefono)
                .IsRequired()
                .HasColumnType("int"); 
    }
}
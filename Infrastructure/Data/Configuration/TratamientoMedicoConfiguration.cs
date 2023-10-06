using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TratamientoMedicoConfiguration : IEntityTypeConfiguration<TratamientoMedico>
{
    public void Configure(EntityTypeBuilder<TratamientoMedico> builder)
    {
        builder.ToTable("tratamientomedico");
        builder.Property(p => p.Id)
                .IsRequired();

        builder.Property(p => p.Dosis)
                .IsRequired()
                .HasMaxLength(100);     

        builder.Property(p => p.FechaAdministracion)
                .IsRequired()
                .HasColumnType("date"); 

        builder.Property(p => p.Observacion)
                .IsRequired()
                .HasMaxLength(100);

        builder.HasOne(y => y.Cita)
            .WithMany(l => l.TratamientoMedicos)
            .HasForeignKey(z => z.IdCita)
            .IsRequired();

        builder.HasOne(y => y.Medicamento)
            .WithMany(l => l.TratamientoMedicos)
            .HasForeignKey(z => z.IdMedicamento)
            .IsRequired();
    }
}
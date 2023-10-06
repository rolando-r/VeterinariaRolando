using System.Reflection;
using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<DetalleMovimiento> DetalleMovimientos { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Proveedor> Proveedors { get; set; }
        public DbSet<Raza> Razas { get; set; }
        public DbSet<TipoMovimiento> TipoMovimientos { get; set; }
        public DbSet<TratamientoMedico> TratamientoMedicos { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

        
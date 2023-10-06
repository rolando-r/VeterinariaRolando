namespace Core.Interfaces;
public interface IUnitOfWork
{
    IRolRepository Roles { get; }
    ICitaRepository Citas { get; }
    IDetalleMovimientoRepository DetalleMovimientos { get; }
    IEspecieRepository Especies { get; }
    ILaboratorioRepository Laboratorios { get; }
    IMascotaRepository Mascotas { get; }
    IMedicamentoRepository Medicamentos { get; }
    IMovimientoMedicamentoRepository MovimientoMedicamentos { get; }
    IPropietarioRepository Propietarios { get; }
    IProveedorRepository Proveedors { get; }
    IRazaRepository Razas { get; }
    ITipoMovimientoRepository TipoMovimientos { get; }
    ITratamientoMedicoRepository TratamientoMedicos { get; }
    IVeterinarioRepository Veterinarios { get; }
    IUsuarioRepository Usuarios { get; }    
    Task<int> SaveAsync();
}
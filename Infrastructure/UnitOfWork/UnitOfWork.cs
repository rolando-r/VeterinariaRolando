using Core.Interfaces;
using Infrastructure.Repository;
namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BaseContext context;
        private IRolRepository _roles;
        private IUsuarioRepository _usuarios;
        private ICitaRepository _citas;
        private IDetalleMovimientoRepository _detallemovimientos;
        private IEspecieRepository _especies;
        private ILaboratorioRepository _laboratorios;
        private IMascotaRepository _mascotas;
        private IMedicamentoRepository _medicamentos;
        private IMovimientoMedicamentoRepository _movimientomedicamentos;
        private IPropietarioRepository _propietarios;
        private IProveedorRepository _proveedores;
        private IRazaRepository _razas;
        private ITipoMovimientoRepository _tipomovimientos;
        private ITratamientoMedicoRepository _tratamientomedicos;
        private IVeterinarioRepository _veterinarios;
        public UnitOfWork(BaseContext _context)
        {
            context = _context;
        }

        public IRolRepository Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RolRepository(context);
                }
                return _roles;
            }
        }
        public IUsuarioRepository Usuarios
        {
            get
            {
                if (_usuarios == null)
                {
                    _usuarios = new UsuarioRepository(context);
                }
                return _usuarios;
            }
        }
        public ICitaRepository Citas
        {
            get
            {
                if (_citas == null)
                {
                    _citas = new CitaRepository(context);
                }
                return _citas;
            }
        }
        public IDetalleMovimientoRepository DetalleMovimientos
        {
            get
            {
                if (_detallemovimientos == null)
                {
                    _detallemovimientos = new DetalleMovimientoRepository(context);
                }
                return _detallemovimientos;
            }
        }
        public IEspecieRepository Especies
        {
            get
            {
                if (_especies == null)
                {
                    _especies = new EspecieRepository(context);
                }
                return _especies;
            }
        }
        public ILaboratorioRepository Laboratorios
        {
            get
            {
                if (_laboratorios == null)
                {
                    _laboratorios = new LaboratorioRepository(context);
                }
                return _laboratorios;
            }
        }
        public IMascotaRepository Mascotas
        {
            get
            {
                if (_mascotas == null)
                {
                    _mascotas = new MascotaRepository(context);
                }
                return _mascotas;
            }
        }
        public IMedicamentoRepository Medicamentos
        {
            get
            {
                if (_medicamentos == null)
                {
                    _medicamentos = new MedicamentoRepository(context);
                }
                return _medicamentos;
            }
        }
        public IMovimientoMedicamentoRepository MovimientoMedicamentos
        {
            get
            {
                if (_movimientomedicamentos == null)
                {
                    _movimientomedicamentos = new MovimientoMedicamentoRepository(context);
                }
                return _movimientomedicamentos;
            }
        }
        public IPropietarioRepository Propietarios
        {
            get
            {
                if (_propietarios == null)
                {
                    _propietarios = new PropietarioRepository(context);
                }
                return _propietarios;
            }
        }
        public IProveedorRepository Proveedors
        {
            get
            {
                if (_proveedores == null)
                {
                    _proveedores = new ProveedorRepository(context);
                }
                return _proveedores;
            }
        }
        public IRazaRepository Razas
        {
            get
            {
                if (_razas == null)
                {
                    _razas = new RazaRepository(context);
                }
                return _razas;
            }
        }
        public ITipoMovimientoRepository TipoMovimientos
        {
            get
            {
                if (_tipomovimientos == null)
                {
                    _tipomovimientos = new TipoMovimientoRepository(context);
                }
                return _tipomovimientos;
            }
        }
        public ITratamientoMedicoRepository TratamientoMedicos
        {
            get
            {
                if (_tratamientomedicos == null)
                {
                    _tratamientomedicos = new TratamientoMedicoRepository(context);
                }
                return _tratamientomedicos;
            }
        }
        public IVeterinarioRepository Veterinarios
        {
            get
            {
                if (_veterinarios == null)
                {
                    _veterinarios = new VeterinarioRepository(context);
                }
                return _veterinarios;
            }
        }
        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
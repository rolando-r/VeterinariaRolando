using Core.Entities;

namespace Core.Interfaces;
public interface IPropietarioRepository : IGenericRepository<Propietario>
{
    Task<dynamic> GetPropietariosYMascotas();
}
using Core.Entities;

namespace Core.Interfaces;
public interface IVeterinarioRepository : IGenericRepository<Veterinario>
{
    Task<List<Veterinario>> GetVeterinariosCirujanosVascular();
}
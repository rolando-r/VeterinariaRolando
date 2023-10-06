using Core;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class VeterinarioRepository : GenericRepository<Veterinario>, IVeterinarioRepository
    {
        public VeterinarioRepository(BaseContext context) : base(context)
        {
        }

        public async Task<List<Veterinario>> GetVeterinariosCirujanosVascular()
        {
            string veterinarioEspecialidad = "Cirujano Vascular";

            return await _context.Veterinarios
                .Where(veterinario => veterinario.Especialidad == veterinarioEspecialidad)
                .ToListAsync();
        }

    }
}
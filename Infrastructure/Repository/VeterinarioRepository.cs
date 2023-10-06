using Core;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;

namespace Infrastructure.Repository
{
    public class VeterinarioRepository : GenericRepository<Veterinario>, IVeterinarioRepository
    {
        public VeterinarioRepository(BaseContext context) : base(context)
        {
        }

        public Task<dynamic> GetVeterinariosCirujanosVascular()
        {
            throw new NotImplementedException();
        }
    }
}
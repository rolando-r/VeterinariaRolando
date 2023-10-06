using Core;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;

namespace Infrastructure.Repository
{
    public class PropietarioRepository : GenericRepository<Propietario>, IPropietarioRepository
    {
        public PropietarioRepository(BaseContext context) : base(context)
        {
        }

        public Task<dynamic> GetPropietariosYMascotas()
        {
            throw new NotImplementedException();
        }
    }
}
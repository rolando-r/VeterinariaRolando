using Core;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;

namespace Infrastructure.Repository
{
    public class RazaRepository : GenericRepository<Raza>, IRazaRepository
    {
        public RazaRepository(BaseContext context) : base(context)
        {
        }
    }
}
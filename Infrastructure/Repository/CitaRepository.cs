using Core;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;

namespace Infrastructure.Repository
{
    public class CitaRepository : GenericRepository<Cita>, ICitaRepository
    {
        public CitaRepository(BaseContext context) : base(context)
        {
        }
    }
}
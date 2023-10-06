using Core;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;

namespace Infrastructure.Repository
{
    public class TipoMovimientoRepository : GenericRepository<TipoMovimiento>, ITipoMovimientoRepository
    {
        public TipoMovimientoRepository(BaseContext context) : base(context)
        {
        }
    }
}
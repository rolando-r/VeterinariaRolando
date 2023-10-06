using Core;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;

namespace Infrastructure.Repository
{
    public class DetalleMovimientoRepository : GenericRepository<DetalleMovimiento>, IDetalleMovimientoRepository
    {
        public DetalleMovimientoRepository(BaseContext context) : base(context)
        {
        }
    }
}
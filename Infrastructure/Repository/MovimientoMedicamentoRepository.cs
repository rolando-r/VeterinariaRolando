using Core;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;

namespace Infrastructure.Repository
{
    public class MovimientoMedicamentoRepository : GenericRepository<MovimientoMedicamento>, IMovimientoMedicamentoRepository
    {
        public MovimientoMedicamentoRepository(BaseContext context) : base(context)
        {
        }
    }
}
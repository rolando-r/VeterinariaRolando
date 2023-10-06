using Core;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;

namespace Infrastructure.Repository
{
    public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamentoRepository
    {
        public MedicamentoRepository(BaseContext context) : base(context)
        {
        }
    }
}
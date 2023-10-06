using Core;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;

namespace Infrastructure.Repository
{
    public class LaboratorioRepository : GenericRepository<Laboratorio>, ILaboratorioRepository
    {
        public LaboratorioRepository(BaseContext context) : base(context)
        {
        }
    }
}
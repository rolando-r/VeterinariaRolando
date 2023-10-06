using Core;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EspecieRepository : GenericRepository<Especie>, IEspecieRepository
    {
        public EspecieRepository(BaseContext context) : base(context)
        {
        }
    }
}
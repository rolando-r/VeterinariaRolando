using Core;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;

namespace Infrastructure.Repository
{
    public class TratamientoMedicoRepository : GenericRepository<TratamientoMedico>, ITratamientoMedicoRepository
    {
        public TratamientoMedicoRepository(BaseContext context) : base(context)
        {
        }
    }
}
using Core;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;

namespace Infrastructure.Repository
{
    public class MascotaRepository : GenericRepository<Mascota>, IMascotaRepository
    {
        public MascotaRepository(BaseContext context) : base(context)
        {
        }

        public Task<dynamic> GetMascotasFelinas()
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetMascotasVacunacionPrimerTrimestre2023()
        {
            throw new NotImplementedException();
        }
    }
}
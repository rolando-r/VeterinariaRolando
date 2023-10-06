using Core.Entities;

namespace Core.Interfaces;
public interface IMascotaRepository : IGenericRepository<Mascota>
{
    Task<dynamic> GetMascotasFelinas();
    Task<dynamic> GetMascotasVacunacionPrimerTrimestre2023();
}
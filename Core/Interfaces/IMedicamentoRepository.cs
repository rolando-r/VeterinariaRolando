using Core.Entities;

namespace Core.Interfaces;
public interface IMedicamentoRepository : IGenericRepository<Medicamento>
{
    Task<dynamic> GetMedicamentosLaboratorioGenfar();
    Task<dynamic> GetMedicamentos5000();
}
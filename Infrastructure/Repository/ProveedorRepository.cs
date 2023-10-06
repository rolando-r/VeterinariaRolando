using Core;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;

namespace Infrastructure.Repository
{
    public class ProveedorRepository : GenericRepository<Proveedor>, IProveedorRepository
    {
        public ProveedorRepository(BaseContext context) : base(context)
        {
        }
    }
}
using Dominio.Entidades;
using Infra.Interfaces.Repository;

namespace Infra.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>
    {
        public ClienteRepository(IUnitOfWork unit)
            : base(unit)
        {
          
        }
    }
}

using Dominio.Entidades;
using Infra.Interfaces.Repository;

namespace Infra.Repository
{
    public class PedidoRepository : BaseRepository<Pedido>
    {
        public PedidoRepository(IUnitOfWork unit)
            : base(unit)
        {
          
        }
    }
}

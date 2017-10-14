using Dominio.Entidades;
using Infra.Interfaces.Repository;

namespace Infra.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>
    {
        public ProdutoRepository(IUnitOfWork unit)
            : base(unit)
        {
          
        }
    }
}

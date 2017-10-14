using Dominio.Entidades;
using Infra.Interfaces.Repository;

namespace Infra.Repository
{
    public class EnderecoRepository : BaseRepository<Endereco>
    {
        public EnderecoRepository(IUnitOfWork unit)
            : base(unit)
        {
          
        }
    }
}

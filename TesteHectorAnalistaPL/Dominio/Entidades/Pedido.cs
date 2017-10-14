
namespace Dominio.Entidades
{
    public class Pedido
    {
        public int PedidoId { get; set; }

        public int Quantidade { get; set; }

        public decimal ValorTotal { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual int ProdutoId { get; set; }   

        public virtual Cliente Cliente { get; set; }

        public virtual int ClienteId { get; set; }        
    }
}

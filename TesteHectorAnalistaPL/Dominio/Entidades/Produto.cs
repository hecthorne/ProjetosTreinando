
using System.Collections.Generic;
namespace Dominio.Entidades
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

        //public virtual Pedido Pedido { get; set; }

        //public virtual int PedidoId { get; set; }  
    }
}

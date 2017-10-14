using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}

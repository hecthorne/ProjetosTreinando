using Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Infra.ConfiguracaoEF
{
    public class PedidoConfig : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfig()
        {
            HasKey(c => c.PedidoId);

            Property(c => c.ValorTotal)
                .IsRequired();

            Property(c => c.Quantidade)
                .IsRequired();

            HasRequired(p => p.Cliente)
                .WithMany(x => x.Pedidos)
                .HasForeignKey(p => p.ClienteId)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Produto)
                .WithMany(x => x.Pedidos)
                .HasForeignKey(p => p.ProdutoId)
                .WillCascadeOnDelete(false);
        }
    }
}

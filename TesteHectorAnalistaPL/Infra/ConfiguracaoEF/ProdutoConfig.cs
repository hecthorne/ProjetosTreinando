using Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Infra.ConfiguracaoEF
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            HasKey(c => c.ProdutoId);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Valor)
                .IsRequired();
        }
    }
}

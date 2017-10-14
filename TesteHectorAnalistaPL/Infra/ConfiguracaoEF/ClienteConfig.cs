using Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Infra.ConfiguracaoEF
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}

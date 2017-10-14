using System.Data.Entity.ModelConfiguration;
using Dominio.Entidades;

namespace Infra.ConfiguracaoEF
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(c => c.EnderecoId);

            Property(c => c.EnderecoCompleto)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Bairro)
                .IsRequired()
                .HasMaxLength(20);

            Property(c => c.Cep)
                .IsRequired()
                .HasMaxLength(20);

            HasRequired(p => p.Cliente)
                .WithMany(x => x.Enderecos)
                .HasForeignKey(p => p.ClienteId)
                .WillCascadeOnDelete(false);
        }
    }
}

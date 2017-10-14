using Dominio.Entidades;
using Infra.ConfiguracaoEF;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infra.Contexto
{
    public class MeuContext : DbContext
    {
        public MeuContext()
            : base("ProjetoTesteHector")
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Properties()
            //    .Where(p => p.Name == p.ReflectedType.Name + "Id")
            //    .Configure(p => p.IsKey());

            //modelBuilder.Properties<string>()
            //    .Configure(p => p.HasColumnType("varchar"));

            //modelBuilder.Properties<string>()
            //    .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new PedidoConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());
        }
    }
}

using Microsoft.EntityFrameworkCore;


namespace ArmariosPorMedidaAPI.Models
{
    public class ArmariosPorMedidaContext : DbContext
    {
        public ArmariosPorMedidaContext(DbContextOptions<ArmariosPorMedidaContext> options)
            : base(options)
        {
        }
        /*/protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLExpress;Database=ArmariosPorMedida;Trusted_Connection=true");
        }*/
        
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Restricao> Restricoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<Acabamento> Acabamentos { get; set; }
        public DbSet<Parte> Partes { get; set; }
        public DbSet<ProdutoParte> ProdutoPartes { get; set; }
        public DbSet<ProdutoRestricao> ProdutoRestricoes { get; set; }
        public DbSet<MaterialAcabamento> MaterialAcabamentos { get; set; }
        public DbSet<MaterialProduto> MaterialProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Produto * * Parte
            modelBuilder.Entity<ProdutoParte>()
                .HasKey(pp => new { pp.ProdutoID, pp.ParteID });

            modelBuilder.Entity<ProdutoParte>()
                .HasOne(pp => pp.Produto)
                .WithMany(pr => pr.ProdutoPartes)
                .HasForeignKey(bc => bc.ProdutoID);

            modelBuilder.Entity<ProdutoParte>()
                .HasOne(pp => pp.Parte)
                .WithMany(pa => pa.ProdutoPartes)
                .HasForeignKey(pp => pp.ParteID);


            //Produto * * Restricao
            modelBuilder.Entity<ProdutoRestricao>()
                .HasKey(pp => new { pp.ProdutoID, pp.RestricaoID });

            modelBuilder.Entity<ProdutoRestricao>()
                .HasOne(pp => pp.Produto)
                .WithMany(pr => pr.ProdutoRestricoes)
                .HasForeignKey(bc => bc.ProdutoID);

            modelBuilder.Entity<ProdutoRestricao>()
                .HasOne(pp => pp.Restricao)
                .WithMany(r => r.ProdutoRestricoes)
                .HasForeignKey(pp => pp.RestricaoID);

            //Produto * * Material
            modelBuilder.Entity<MaterialProduto>()
                .HasKey(pp => new { pp.MaterialID, pp.ProdutoID });

            modelBuilder.Entity<MaterialProduto>()
                .HasOne(pp => pp.Produto)
                .WithMany(pr => pr.MaterialProdutos)
                .HasForeignKey(bc => bc.ProdutoID);

            modelBuilder.Entity<MaterialProduto>()
                .HasOne(pp => pp.Material)
                .WithMany(pa => pa.MaterialProdutos)
                .HasForeignKey(pp => pp.MaterialID);

            //Material * * Acabamento
            modelBuilder.Entity<MaterialAcabamento>()
                .HasKey(pp => new { pp.MaterialID, pp.AcabamentoID });

            modelBuilder.Entity<MaterialAcabamento>()
                .HasOne(pp => pp.Material)
                .WithMany(pr => pr.MaterialAcabamentos)
                .HasForeignKey(bc => bc.MaterialID);

            modelBuilder.Entity<MaterialAcabamento>()
                .HasOne(pp => pp.Acabamento)
                .WithMany(pa => pa.MaterialAcabamentos)
                .HasForeignKey(pp => pp.AcabamentoID);
        }

    }



}
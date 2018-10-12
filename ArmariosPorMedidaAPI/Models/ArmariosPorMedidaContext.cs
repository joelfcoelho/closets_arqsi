using Microsoft.EntityFrameworkCore;


namespace ArmariosPorMedidaAPI.Models
{
    public class ArmariosPorMedidaContext : DbContext
    {
        public ArmariosPorMedidaContext(DbContextOptions<ArmariosPorMedidaContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Restricao> Restricoes {get;set;}
        public DbSet<Categoria> Categorias {get;set;}
        public DbSet<Material> Materiais {get;set;}
        public DbSet<Acabamento> Acabamentos {get;set;}
        public DbSet<Parte> Partes {get;set;}
        public DbSet<ProdutoParte> ProdutoPartes { get; set; }
        public DbSet<ProdutoRestricao> ProdutoRestricoes { get; set; }
 
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
        }
    
    }

    

}
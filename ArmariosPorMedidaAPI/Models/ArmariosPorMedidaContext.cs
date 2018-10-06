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
    }


}
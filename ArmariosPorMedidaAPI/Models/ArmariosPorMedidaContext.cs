using Microsoft.EntityFrameworkCore;

namespace ArmariosPorMedidaAPI.Models
{
    public class ArmariosPorMedidaContext : DbContext
    {
        public ArmariosPorMedidaContext(DbContextOptions<ArmariosPorMedidaContext> options)
            : base(options)
        {
        }

       // public DbSet<ArmariosPorMedidaItem> ArmariosPorMedidaItems { get; set; }
    }
}
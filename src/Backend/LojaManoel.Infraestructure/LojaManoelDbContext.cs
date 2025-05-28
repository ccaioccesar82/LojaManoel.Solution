using LojaManoel.Domain;
using Microsoft.EntityFrameworkCore;

namespace LojaManoel.Infraestructure
{
    public class LojaManoelDbContext : DbContext
    {
        public LojaManoelDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LojaManoelDbContext).Assembly);
        }
    }
}

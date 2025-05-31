using PackingServiceAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace PackingServiceAPI.Infrastructure
{
    public class PackingDbContext : DbContext
    {
        public PackingDbContext(DbContextOptions<PackingDbContext> options) : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Caixa> Caixas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pedido>(entity =>
    {
        entity.HasKey(p => p.PedidoId);
        entity.HasMany(p => p.Produtos)
              .WithOne()
              .HasForeignKey(prod => prod.ProdutoId)
              .OnDelete(DeleteBehavior.Cascade);
    });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(prod => prod.ProdutoId);
                entity.OwnsOne(prod => prod.Dimensoes);

                entity.HasOne<Caixa>()
                      .WithMany(c => c.Produtos)
                      .HasForeignKey(prod => prod.CaixaId)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Caixa>(entity =>
            {
                entity.HasKey(c => c.CaixaId);
                entity.OwnsOne(c => c.Dimensoes);
                entity.HasMany(c => c.Produtos)
                      .WithOne()
                      .HasForeignKey(p => p.CaixaId)
                      .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}

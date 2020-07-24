using Microsoft.EntityFrameworkCore;
using TSContaCorrente.Domain.Entidades;

namespace TSContaCorrente.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContaCorrente> Contas { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<TipoLancamento> TipoLancamento { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("AppBd");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContaCorrente>().HasMany(x => x.Lancamentos).WithOne(x => x.ContaCorrente);

            modelBuilder.Entity<Lancamento>().HasOne(x => x.ContaCorrente).WithMany(x => x.Lancamentos);

            modelBuilder.Entity<Lancamento>().HasOne(x => x.TipoLancamento);

            base.OnModelCreating(modelBuilder);
        }
    }
}

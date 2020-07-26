using App.Domain.Data.Configurations;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;

namespace App.Domain.Data.Contexts
{
    public class AppDataContext : DbContext
    {
        public DbSet<ContaCorrente> Contas { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ContaCorrente>().HasData(new ContaCorrente { Id = 1, NumAgencia = "1010", NumConta = "1010-1" });

            modelBuilder.Entity<ContaCorrente>().HasData(new ContaCorrente { Id = 2, NumAgencia = "2020", NumConta = "2020-2" });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=PC-WELLINGTON\SQLExpress; Initial Catalog=db; Integrated Security=true;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}

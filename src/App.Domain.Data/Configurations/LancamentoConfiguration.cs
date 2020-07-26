using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Data.Configurations
{
    public class LancamentoConfiguration : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ContaCorrente).WithMany(x => x.Lancamentos).IsRequired();

            builder.Property(x => x.DataLancamento).HasDefaultValueSql("getdate()");
        }
    }
}

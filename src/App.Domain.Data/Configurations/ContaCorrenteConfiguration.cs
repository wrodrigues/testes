using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Data.Configurations
{
    public class ContaCorrenteConfiguration : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Lancamentos).WithOne(x => x.ContaCorrente);
        }
    }
}

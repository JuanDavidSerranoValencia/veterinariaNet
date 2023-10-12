using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");

            builder.HasKey(cli => cli.Id);
            builder.Property(cli => cli.Id);

            builder.Property(cli =>cli.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(cli => cli.Apellidos)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(cli =>cli.Email)
            .HasMaxLength(50);

           

        }
    }
}
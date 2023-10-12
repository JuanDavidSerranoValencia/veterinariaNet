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
    public class ClienteDireccioConfiguration : IEntityTypeConfiguration<ClienteDireccion>
    {
        public void Configure(EntityTypeBuilder<ClienteDireccion> builder)
        {
            builder.ToTable("clienteDireccion");

            builder.HasKey(cliDir => cliDir.Id);
            builder.Property(cliDir => cliDir.Id);

            builder.Property(cliDir => cliDir.TipoDeVia)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.NumeroPri)
            .HasColumnType("int");

            builder.Property(p => p.Letra)
            .IsRequired()
            .HasMaxLength(1);

            builder.Property(p => p.Bis)
            .IsRequired()
            .HasMaxLength(3);

            builder.Property(p => p.LetraSec)
            .IsRequired()
            .HasMaxLength(2);

            builder.Property(p => p.Cardinal)
            .IsRequired()
            .HasMaxLength(10);

            builder.Property(p => p.NumeroSec)
            .HasColumnType("int");

            builder.Property(p => p.LetraTer)
            .IsRequired()
            .HasMaxLength(10);

            builder.Property(p => p.NumeroTer)
            .HasColumnType("int");

            builder.Property(p => p.CardinalSec)
            .IsRequired()
            .HasMaxLength(10);

            builder.Property(p => p.Complemento)
            .HasMaxLength(50);

            builder.Property(p => p.CodigoPostal)
            .HasMaxLength(10);

            builder.HasOne(cliDir =>cliDir.Ciudades)
            .WithMany(cliDir => cliDir.ClienteDireccion).
            HasForeignKey(cliDir => cliDir.IdCiudad);
        }
    }
}
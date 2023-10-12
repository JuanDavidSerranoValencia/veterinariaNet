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
    public class ClienteTelefonoConfiguration : IEntityTypeConfiguration<ClienteTelefono>
    {
        public void Configure(EntityTypeBuilder<ClienteTelefono> builder)
        {
            builder.ToTable("clienteTelefono");

            builder.HasKey(cliTel => cliTel.Id);
            builder.Property(cliTel => cliTel.Id);

            builder.Property(cliTel => cliTel.Numero)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(cliTel =>cliTel.Clientes)
            .WithMany(cliTel => cliTel.ClientesTelefonos)
            .HasForeignKey(cliTel => cliTel.IdCliente).IsRequired();

        }
        }
    }

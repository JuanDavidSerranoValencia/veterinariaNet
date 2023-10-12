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
    public class ServicioConfiguration : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> builder)
        {
            builder.ToTable("servicio");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id);

            builder.Property(s => s.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(s => s.Precio)
            .IsRequired()
            .HasMaxLength(50);

        }
    }
}
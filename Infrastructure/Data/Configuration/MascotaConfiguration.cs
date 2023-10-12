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
    public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> builder)
        {
            builder.ToTable("mascotas");

            builder.HasKey(m => m.Id);
            builder.Property(m =>m.Id);

            builder.Property(m =>m.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(m =>m.Especie)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(m => m.FechaNacimiento)
            .HasColumnType("datetime");
            
            builder.HasOne(m => m.Raza)
            .WithMany(m => m.Mascotas)
            .HasForeignKey(m =>m.IdRaza);

             builder.HasOne(m => m.Clientes)
            .WithMany(m => m.Mascotas)
            .HasForeignKey(m => m.IdCliente);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class CitaConfiguration : IEntityTypeConfiguration<Cita>
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            builder.ToTable("cita");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id);

            builder.Property(c => c.Fecha)
            .IsRequired()
            .HasColumnType("date");

            builder.Property(c => c.Hora)
            .IsRequired()
            .HasColumnType("time");

            builder.HasOne(c => c.Clientes)
            .WithMany(c => c.Citas)
            .HasForeignKey(c => c.IdCliente);

            builder.HasOne(c => c.Mascotas)
            .WithMany(c => c.Citas)
            .HasForeignKey(c => c.IdMascota);

            builder.HasOne(c => c.Servicios)
            .WithMany(c => c.Citas)
            .HasForeignKey(c => c.ServicioId);
        }
    }


}
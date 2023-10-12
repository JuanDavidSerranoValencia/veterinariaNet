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
    public class RazaConfiguration:IEntityTypeConfiguration<Raza>
    {
        public void Configure(EntityTypeBuilder<Raza> builder)
        {
            builder.ToTable("raza");

            builder.HasKey(r=> r.Id);
            builder.Property(r =>r.Id);

            builder.Property(r =>r.NombreRaza)
            .IsRequired()
            .HasMaxLength(50);

            
        }

        
    }
}
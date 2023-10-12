using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Core.Entitites;



namespace Infrastructure.Data;

public class VeterinariaNetContext : DbContext
{

    public VeterinariaNetContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Cliente> Clientes {get;set;}
    public DbSet<Cita> Citas {get;set;}
    public DbSet<Departamento> Departamentos {get;set;}
    public DbSet<Ciudad> Ciudades {get;set;}
    public DbSet<ClienteDireccion> ClientesDirecciones {get;set;}
    public DbSet<ClienteTelefono> ClientesTelefonos {get;set;}
    public DbSet<Mascota> Mascotas {get;set;}
    public DbSet<Pais> Paises {get;set;}
    public DbSet<Raza> Razas {get;set;}
    public DbSet<Servicio> Servicios {get;set;}


    public DbSet<Cliente> Clientes {get;set;}
    public DbSet<Cita> Citas {get;set;}
    public DbSet<Ciudad> Ciudades {get;set;}
    public DbSet<ClienteDireccion> ClientesDirecciones {get;set;}
    public DbSet<ClienteTelefono> ClientesTelefonos {get;set;}
    public DbSet<Departamento> Departamentos {get;set;}
    public DbSet<Mascota> Mascotas {get;set;}
    public DbSet<Pais> Paises {get;set;}
    public DbSet<Raza> Razas {get;set;}
    public DbSet<Servicio> Servicios {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Infrastructure.Data;

public class VeterinariaNetContext:DbContext {

    public VeterinariaNetContext(DbContextOptions options) : base(options){

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

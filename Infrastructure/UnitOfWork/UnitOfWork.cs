using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly VeterinariaNetContext _context;
    public UnitOfWork(VeterinariaNetContext context)
    {
        _context = context;
    }
   
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

     public void Dispose()
    {
        _context.Dispose();
    }
 
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly VeterinariaNetContext _context;
    private PaisRepository _paises;
    private CitaRepository _citas;

    private CiudadRepository _ciudades;

    public IPaisRepository Paises
    {
        get
        {
            if (_paises == null)
            {
                _paises = new PaisRepository(_context);
            }
            return _paises;
        }
    }

    public ICitaRepository Citas
    {
        get
        {
            if (_citas == null)
            {
                _citas = new CitaRepository(_context);
            }
            return _citas;
        }
    }

    public ICiudadRepository Ciudades
    {
        get
        {
            if (_ciudades == null)
            {
                _ciudades = new CiudadRepository(_context);
            }
            return _ciudades;
        }
    }
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

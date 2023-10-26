using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitites;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly VeterinariaNetContext _context;
    private ClienteRepository _clientes;
    private PaisRepository _paises;
    private CitaRepository _citas;
    private CiudadRepository _ciudades;
    private ClienteTelefonoRepository _clienteTelefonos;
    private ClienteDireccionRepository _clienteDirecciones;
    private DepartamentoRepository _departamentos;
    private MascotaRepository _mascotas;
    private RazaRepository _razas;
    private ServicioRepository _servicios;
    public IClienteRepository Clientes
    {
        get
        {
            if (_clientes == null)
            {
                _clientes = new ClienteRepository(_context);
            }
            return _clientes;
        }
    }

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

     public IClienteDireccionRepository ClienteDirecciones
    {
        get
        {
            if (_clienteDirecciones == null)
            {
                _clienteDirecciones = new ClienteDireccionRepository(_context);
            }
            return _clienteDirecciones;
        }
    }
        public IClienteTelefonoRepository ClienteTelefonos
    {
        get
        {
            if (_clienteTelefonos == null)
            {
                _clienteTelefonos = new ClienteTelefonoRepository(_context);
            }
            return _clienteTelefonos;
        }
    }

     public IDepartamentoRepository Departamentos
    {
        get
        {
            if (_departamentos == null)
            {
                _departamentos = new DepartamentoRepository(_context);
            }
            return _departamentos;
        }
    }
       public IMascotaRepository Mascotas
    {
        get
        {
            if (_mascotas == null)
            {
                _mascotas = new MascotaRepository(_context);
            }
            return _mascotas;
        }
    }
       public IRazaRepository Razas
    {
        get
        {
            if (_razas == null)
            {
                _razas = new RazaRepository(_context);
            }
            return _razas;
        }
    }
      public IServicioRepository Servicios
    {
        get
        {
            if (_servicios == null)
            {
                _servicios = new ServicioRepository(_context);
            }
            return _servicios;
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

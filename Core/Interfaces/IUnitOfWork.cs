using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IClienteRepository Clientes { get; }
        IPaisRepository Paises { get; }
        ICitaRepository Citas { get; }
        ICiudadRepository Ciudades { get; }
        IClienteDireccionRepository ClienteDirecciones { get; }
        IClienteTelefonoRepository ClienteTelefonos { get; }
        IDepartamentoRepository Departamentos { get; }
        IMascotaRepository Mascotas { get; }
        IRazaRepository Razas { get; }
        IServicioRepository Servicios { get; }
        Task<int> SaveAsync();
    }
}
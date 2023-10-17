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
        Task<int> SaveAsync();
    }
}
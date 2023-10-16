using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitites;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ServicioRepository : GenericRepository<Servicio>, IServicioRepository
    {
        private readonly VeterinariaNetContext _context;

        public ServicioRepository(VeterinariaNetContext context) : base(context)
        {
            _context = context;
        }
    }
}
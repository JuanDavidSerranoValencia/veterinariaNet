using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitites;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class RazaRepository : GenericRepository<Raza>, IRazaRepository
    {
      private readonly VeterinariaNetContext _context;

        public RazaRepository(VeterinariaNetContext context) : base(context)
        {
            _context = context;
        }
    }
}
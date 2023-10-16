using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitites;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class MascotaRepository : GenericRepository<Mascota>, IMascotaRepository
    {
       private readonly VeterinariaNetContext _context;

        public MascotaRepository(VeterinariaNetContext context) : base(context)
        {
            _context = context;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitites;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        private readonly VeterinariaNetContext _context;

        public ClienteRepository(VeterinariaNetContext context) : base(context)
        {
            _context = context;
        }

        public static implicit operator ClienteRepository(ClienteTelefonoRepository v)
        {
            throw new NotImplementedException();
        }
    }
}
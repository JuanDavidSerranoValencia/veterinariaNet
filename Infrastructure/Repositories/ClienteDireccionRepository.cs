using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitites;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ClienteDireccionRepository : GenericRepository<ClienteDireccion>, IClienteDireccionRepository
    {
        public ClienteDireccionRepository(VeterinariaNetContext context) : base(context)
        {
        }
    }
}
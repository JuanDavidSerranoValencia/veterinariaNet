using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces;

namespace ApiAnimals.Controllers
{
    public class ClienteDireccionController:BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClienteDireccionController(IUnitOfWork unitOfWork ,IMapper mapper)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork; 

        }
        

    }
}
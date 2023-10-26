using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAnimals.Dtos;
using AutoMapper;
using Core.Entitites;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace ApiAnimals.Controllers
{
    public class ClienteTelefonoController : BaseControllerApi
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClienteTelefonoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteTelefonoDto>>> Get()
        {
            var clienteTel = await _unitOfWork.ClienteTelefonos.GetAllAsync();

            //var clienteTel = await _unitOfWork.ClienteTelefonos.GetAllAsync();
            return _mapper.Map<List<ClienteTelefonoDto>>(clienteTel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteTelefono>> Post(ClienteTelefonoDto clienteTelefonoDto)
        {
            var clienteTel = _mapper.Map<ClienteTelefono>(clienteTelefonoDto);
            this._unitOfWork.ClienteTelefonos.Add(clienteTel);
            await _unitOfWork.SaveAsync();
            if (clienteTel == null)
            {
                return BadRequest();
            }
            clienteTelefonoDto.Id = clienteTel.Id;
            return CreatedAtAction(nameof(Post), new { id = clienteTelefonoDto.Id }, clienteTelefonoDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteTelefonoDto>> Get(int id)
        {
            var clienteTel = await _unitOfWork.ClienteTelefonos.GetByIdAsync(id);
            if (clienteTel == null)
            {
                return NotFound();
            }
            return _mapper.Map<ClienteTelefonoDto>(clienteTel);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteTelefonoDto>> Put(int id, [FromBody] ClienteTelefonoDto clienteTelefonoDto)
        {
            if (clienteTelefonoDto == null)
                return NotFound();
            var clienteTel = _mapper.Map<ClienteTelefono>(clienteTelefonoDto);
            _unitOfWork.ClienteTelefonos.Update(clienteTel);
            await _unitOfWork.SaveAsync();
            return clienteTelefonoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var clienteTel = await _unitOfWork.ClienteTelefonos.GetByIdAsync(id);
            if (clienteTel == null)
            {
                return NotFound();
            }
            _unitOfWork.ClienteTelefonos.Remove(clienteTel);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

    }
}
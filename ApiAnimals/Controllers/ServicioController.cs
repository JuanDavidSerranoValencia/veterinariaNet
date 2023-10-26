using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAnimals.Dtos;
using AutoMapper;
using Core.Entitites;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiAnimals.Controllers
{
    public class ServicioController:BaseControllerApi
    {
         private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServicioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ServicioDto>>> Get()
        {
            var servicio = await _unitOfWork.Servicios.GetAllAsync();

            //var servicio = await _unitOfWork.Servicios.GetAllAsync();
            return _mapper.Map<List<ServicioDto>>(servicio);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Servicio>> Post(ServicioDto servicioDto)
        {
            var pais = _mapper.Map<Servicio>(servicioDto);
            this._unitOfWork.Servicios.Add(pais);
            await _unitOfWork.SaveAsync();
            if (pais == null)
            {
                return BadRequest();
            }
            servicioDto.Id = pais.Id;
            return CreatedAtAction(nameof(Post), new { id = servicioDto.Id }, servicioDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServicioDto>> Get(int id)
        {
            var pais = await _unitOfWork.Servicios.GetByIdAsync(id);
            if (pais == null)
            {
                return NotFound();
            }
            return _mapper.Map<ServicioDto>(pais);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ServicioDto>> Put(int id, [FromBody] ServicioDto servicioDto)
        {
            if (servicioDto == null)
                return NotFound();
            var servicio = _mapper.Map<Servicio>(servicioDto);
            _unitOfWork.Servicios.Update(servicio);
            await _unitOfWork.SaveAsync();
            return servicioDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var pais = await _unitOfWork.Servicios.GetByIdAsync(id);
            if (pais == null)
            {
                return NotFound();
            }
            _unitOfWork.Servicios.Remove(pais);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
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
    public class RazaController : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RazaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RazaDto>>> Get()
        {
            var raza = await _unitOfWork.Razas.GetAllAsync();

            //var raza = await _unitOfWork.Razas.GetAllAsync();
            return _mapper.Map<List<RazaDto>>(raza);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Raza>> Post(RazaDto razaDto)
        {
            var pais = _mapper.Map<Raza>(razaDto);
            this._unitOfWork.Razas.Add(pais);
            await _unitOfWork.SaveAsync();
            if (pais == null)
            {
                return BadRequest();
            }
            razaDto.Id = pais.Id;
            return CreatedAtAction(nameof(Post), new { id = razaDto.Id }, razaDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RazaDto>> Get(int id)
        {
            var pais = await _unitOfWork.Razas.GetByIdAsync(id);
            if (pais == null)
            {
                return NotFound();
            }
            return _mapper.Map<RazaDto>(pais);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RazaDto>> Put(int id, [FromBody] RazaDto razaDto)
        {
            if (razaDto == null)
                return NotFound();
            var raza = _mapper.Map<Raza>(razaDto);
            _unitOfWork.Razas.Update(raza);
            await _unitOfWork.SaveAsync();
            return razaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var pais = await _unitOfWork.Razas.GetByIdAsync(id);
            if (pais == null)
            {
                return NotFound();
            }
            _unitOfWork.Razas.Remove(pais);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RuletaClean.Api.Responses;
using RuletaClean.Core.DTOs;
using RuletaClean.Core.Entities;
using RuletaClean.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuletaClean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApuestaController : ControllerBase
    {
        private readonly IApuestaRepository _apuestaRepository;
        private readonly IMapper _mapper;

        public ApuestaController(IApuestaRepository apuestaRepository, IMapper mapper)
        {
            _apuestaRepository = apuestaRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CerrarApuestaById(int id)
        {
            var apuesta = await _apuestaRepository.SelectApuestaByRuleta(id);
            var apuestaDto = _mapper.Map<IEnumerable<ApuestaDto>>(apuesta);
            var resp = new ApiResponses<IEnumerable<ApuestaDto>>(apuestaDto);
            return Ok(resp);
        }
        [HttpPost]
        public async Task<IActionResult> CrearApuesta(ApuestaDto apuestaDto, [FromHeader] int id_usuario)
        {
            var apuesta = _mapper.Map<Apuesta>(apuestaDto);
            apuesta.id_usuario = id_usuario;
            var respuesta = await _apuestaRepository.InsertApuestas(apuesta);
            var resp = new ApiResponses<string>(respuesta);
            return Ok(resp);
        }
    }
}

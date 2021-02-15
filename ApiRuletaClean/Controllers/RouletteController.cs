using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RuletaClean.Api.Responses;
using RuletaClean.Core.DTOs;
using RuletaClean.Core.Entities;
using RuletaClean.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RuletaClean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteService _ruletaService;
        private readonly IMapper _mapper;
        public RouletteController(IRouletteService ruletaService, IMapper mapper)
        {
            _ruletaService = ruletaService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetRuletas()
        {
            var ruletas = await _ruletaService.GetRoulettes();
            var ruletasDto = _mapper.Map<IEnumerable<RouletteDto>>(ruletas);
            var response = new ApiResponses<IEnumerable<RouletteDto>>(ruletasDto);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> AbrirRuleta(int id)
        {
            var respuesta = await _ruletaService.OpenRoulette(id);
            var response = new ApiResponses<bool>(respuesta);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertRuleta(RouletteDto ruletaDto)
        {
            var ruleta = _mapper.Map<Roulette>(ruletaDto);
            await _ruletaService.InsertRoulette(ruleta);
            ruletaDto = _mapper.Map<RouletteDto>(ruleta);
            var response = new ApiResponses<int>(ruletaDto.id_roulette);
            return Ok(response);
        }
        
    }
}

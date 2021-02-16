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
        private readonly IRouletteService _rouletteService;
        private readonly IMapper _mapper;
        public RouletteController(IRouletteService rouletteService, IMapper mapper)
        {
            _rouletteService = rouletteService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetRoulettes()
        {
            var roulettes = await _rouletteService.GetRoulettes();
            var rouletteDto = _mapper.Map<IEnumerable<RouletteDto>>(roulettes);
            var response = new ApiResponses<IEnumerable<RouletteDto>>(rouletteDto);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> OpenRoulette(int id)
        {
            var roulette = await _rouletteService.OpenRoulette(id);
            var response = new ApiResponses<bool>(roulette);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertRoulette(RouletteDto rouletteDto)
        {
            var roulette = _mapper.Map<Roulette>(rouletteDto);
            await _rouletteService.InsertRoulette(roulette);
            rouletteDto = _mapper.Map<RouletteDto>(roulette);
            var response = new ApiResponses<int>(rouletteDto.id_roulette);
            return Ok(response);
        }
        
    }
}

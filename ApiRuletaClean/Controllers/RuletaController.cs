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
    public class RuletaController : ControllerBase
    {
        private readonly IRuletaService _ruletaService;
        private readonly IMapper _mapper;
        public RuletaController(IRuletaService ruletaService, IMapper mapper)
        {
            _ruletaService = ruletaService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetRuletas()
        {
            var ruletas = await _ruletaService.GetRuletas();
            var ruletasDto = _mapper.Map<IEnumerable<RuletaDto>>(ruletas);
            var response = new ApiResponses<IEnumerable<RuletaDto>>(ruletasDto);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> AbrirRuleta(int id)
        {
            var respuesta = await _ruletaService.AbrirRuleta(id);
            var response = new ApiResponses<bool>(respuesta);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertRuleta(RuletaDto ruletaDto)
        {
            var ruleta = _mapper.Map<Ruleta>(ruletaDto);
            await _ruletaService.InsertRuleta(ruleta);
            ruletaDto = _mapper.Map<RuletaDto>(ruleta);
            var response = new ApiResponses<int>(ruletaDto.id_ruleta);
            return Ok(response);
        }
        
    }
}

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
    public class BetController : ControllerBase
    {
        private readonly IBetService _betService;
        private readonly IMapper _mapper;

        public BetController(IBetService betService, IMapper mapper)
        {
            _betService = betService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CloseBetById(int id)
        {
            var bet = await _betService.SelectBetByRoulette(id);
            var betDto = _mapper.Map<IEnumerable<BetDto>>(bet);
            var response = new ApiResponses<IEnumerable<BetDto>>(betDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertBet(BetDto betDto, [FromHeader] int id_user)
        {
            var bet = _mapper.Map<Bet>(betDto);
            bet.id_user = id_user;
            await _betService.InsertBet(bet);
            return Ok();
        }
    }
}

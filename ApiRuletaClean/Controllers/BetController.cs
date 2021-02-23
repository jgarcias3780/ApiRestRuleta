using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RuletaClean.Api.Responses;
using RuletaClean.Core.CustomEntities;
using RuletaClean.Core.DTOs;
using RuletaClean.Core.Entities;
using RuletaClean.Core.Interfaces;
using RuletaClean.Core.QueryFilters;
using RuletaClean.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RuletaClean.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly IBetService _betService;
        private readonly IMapper _mapper;
        private readonly IUrlService _urlService;

        public BetController(IBetService betService, IMapper mapper, IUrlService urlService)
        {
            _betService = betService;
            _mapper = mapper;
            _urlService = urlService;
        }

        /// <summary>
        /// Cerrar una ruleta y realizar sorteo
        /// </summary>
        /// <param name="id">id de la ruleta a cerrar</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> CloseBetById(int id)
        {
            var bet = await _betService.SelectBetByRoulette(id);
            var betDto = _mapper.Map<IEnumerable<BetDto>>(bet);
            var response = new ApiResponses<IEnumerable<BetDto>>(betDto);
            return Ok(response);
        }
        /// <summary>
        /// Obtener todas las apuestas con paginacion
        /// </summary>
        /// <param name="filters">Filtros de busqueda</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(SelectBets))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponses<IEnumerable<BetDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponses<IEnumerable<BetDto>>))]
        public async Task<IActionResult> SelectBets([FromQuery] BetQueryFilter filters)
        {
            var bets = await _betService.SelectBets(filters);
            var betDto = _mapper.Map<IEnumerable<BetDto>>(bets);

            var metaData = new MetaData {
                TotalCount = bets.TotalCount,
                PageSize = bets.PageSize,
                CurrentPage = bets.CurrentPage,
                TotalPages = bets.TotalPages,
                HasNextPage = bets.HasNextPage,
                HasPreviousPage = bets.HasPreviousPage,
                NextPageUrl = _urlService.getPostPaginationUrl(filters,Url.RouteUrl(nameof(SelectBets))).ToString(),
                PreviousPageUrl = _urlService.getPostPaginationUrl(filters, Url.RouteUrl(nameof(SelectBets))).ToString()
            };
            var response = new ApiResponses<IEnumerable<BetDto>>(betDto)
            {
                Meta = metaData
            };
            Response.Headers.Add("x-Pagination",JsonConvert.SerializeObject(metaData));
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

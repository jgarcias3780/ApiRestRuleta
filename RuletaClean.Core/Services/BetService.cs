using Microsoft.Extensions.Options;
using RuletaClean.Core.CustomEntities;
using RuletaClean.Core.Entities;
using RuletaClean.Core.Exceptions;
using RuletaClean.Core.Interfaces;
using RuletaClean.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuletaClean.Core.Services
{
    public class BetService : IBetService
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly PaginationOptions _paginationOptions;
        public BetService(IUnitOfWork unitOfwork, IOptions<PaginationOptions> options)
        {
            _unitOfwork = unitOfwork;
            _paginationOptions = options.Value;
        }

        public async Task InsertBet(Bet apuesta)
        {
            if (!await ValidateCreditUser(apuesta)) { throw new BusinessException("El usuario no existe o no tiene credito"); }
            if (!await ValidateRouletteOpen(apuesta)) { throw new BusinessException("La ruleta no se encuentra abierta"); }
            if (apuesta.color == null)
            {
                if (!ValidateNumber(apuesta)) { throw new BusinessException("El numero no esta en el rango definido"); }
                await _unitOfwork.BetRepository.InsertBet(apuesta);
            }
            else
            {
                await _unitOfwork.BetRepository.InsertBet(apuesta);
            }
        }
        public async Task<IEnumerable<Bet>> SelectBetByRoulette(int id_roulette)
        {
            await Lottery(id_roulette);
            return await _unitOfwork.BetRepository.SelectBetByRoulette(id_roulette);
        }

        public async Task<PagedList<Bet>> SelectBets(BetQueryFilter filters)
        {
            var bets = await _unitOfwork.BetRepository.SelectBets();
            filters.pageNumber = filters.pageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.pageNumber;
            filters.pageSize = filters.pageSize == 0 ? _paginationOptions.DefaultPageSize : filters.pageSize;
            if (filters.id_roulette != null)
            {
                bets = bets.Where(e => e.id_roulette == filters.id_roulette);
            }
            if (filters.id_user != null)
            {
                bets = bets.Where(e => e.id_user == filters.id_user);
            }

            var pagedBets = PagedList<Bet>.Create(bets, filters.pageNumber, filters.pageSize);
            return pagedBets;
        }

        public async Task<bool> ValidateCreditUser(Bet bet)
        {
            var user = await _unitOfwork.UserRepository.GetUserById(bet.id_user);
            if (user != null)
            {
                if (bet.money <= user.credit)
                {
                    return true;
                }

                return false;
            }

            return false;
        }
        public async Task<bool> ValidateRouletteOpen(Bet bet)
        {
            var roulette = await _unitOfwork.RouletteRepository.GetRouletteById(bet.id_roulette);
            if (roulette != null && roulette.state == "abierta")
            {
                return true;
            }
            return false;
        }
        public bool ValidateNumber(Bet bet)
        {
            if (bet.number == null)
                return false;

            if (Int32.Parse(bet.number) >= 0 && Int32.Parse(bet.number) <= 36)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task Lottery(int id_roulette)
        {
            await _unitOfwork.RouletteRepository.CloseRoulette(id_roulette);

            Random rnd = new Random();
            int winning_number = rnd.Next(37);
            string winning_color;
            if ((winning_number % 2) == 0)
                winning_color = "rojo";
            else
                winning_color = "negro";

            var ganador_numeros = await _unitOfwork.BetRepository.SelectWinningNumber(winning_number.ToString(), id_roulette);
            foreach (Bet element in ganador_numeros)
            {
                element.win = "Si";
                element.earned_value = element.money * 5;
                await _unitOfwork.BetRepository.UpdateWinner(element.id_bet, element);
            }
            var ganador_color = await _unitOfwork.BetRepository.SelectWinningColor(winning_color, id_roulette);
            foreach (Bet element in ganador_color)
            {
                element.win = "Si";
                element.earned_value = element.money * 1.8m;
                await _unitOfwork.BetRepository.UpdateWinner(element.id_bet, element);
            }

        }
    }
}

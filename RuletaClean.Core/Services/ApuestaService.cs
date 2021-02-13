using RuletaClean.Core.Entities;
using RuletaClean.Core.Exceptions;
using RuletaClean.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RuletaClean.Core.Services
{
    public class ApuestaService : IApuestaService
    {
        private readonly IUnitOfWork _unitOfwork;
        public ApuestaService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public async Task InsertApuestas(Apuesta apuesta)
        {
            if (!await ValidarUsuarioCredito(apuesta)) { throw new BusinessException("El usuario no existe o no tiene credito"); }
            if (!await ValidarRuletaAbierta(apuesta)) { throw new BusinessException("La ruleta no se encuentra abierta"); }
            if (apuesta.color == null)
            {
                if (!ValidarNumero(apuesta)) { throw new BusinessException("El numero no esta en el rango definido"); }
                await _unitOfwork.ApuestaRepository.InsertApuestas(apuesta);
            }
            else
            {
                await _unitOfwork.ApuestaRepository.InsertApuestas(apuesta);
            }
        }
        public async Task<IEnumerable<Apuesta>> SelectApuestaByRuleta(int id_ruleta)
        {
            await RealizarSorteo(id_ruleta);
            return await _unitOfwork.ApuestaRepository.SelectApuestaByRuleta(id_ruleta);
        }

        public async Task<bool> ValidarUsuarioCredito(Apuesta apuesta)
        {
            var usuario = await _unitOfwork.UsuarioRepository.GetUsuarioById(apuesta.id_usuario);
            if (usuario != null)
            {
                if (apuesta.dinero <= usuario.credito)
                {
                    return true;
                }

                return false;
            }

            return false;
        }
        public async Task<bool> ValidarRuletaAbierta(Apuesta apuesta)
        {
            var ruleta = await _unitOfwork.RuletaRepository.GetRuletaById(apuesta.id_ruleta);
            if (ruleta != null && ruleta.estado == "abierta")
            {
                return true;
            }
            return false;
        }
        public bool ValidarNumero(Apuesta apuesta)
        {
            if (apuesta.numero == null)
                return false;

            if (Int32.Parse(apuesta.numero) >= 0 && Int32.Parse(apuesta.numero) <= 36)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public async Task RealizarSorteo(int id_ruleta)
        {
            Random rnd = new Random();
            int numero_ganador = rnd.Next(37);
            string color_ganador = "";
            if ((numero_ganador % 2) == 0)
                color_ganador = "rojo";
            else
                color_ganador = "negro";

            var ganador_numeros = await _unitOfwork.ApuestaRepository.SelectGanadorNumero(numero_ganador.ToString(), id_ruleta);
            foreach (Apuesta element in ganador_numeros)
            {
                element.gano = "Si";
                element.valor_ganado = element.dinero * 5;
                await _unitOfwork.ApuestaRepository.UpdateGanador(element.id_apuesta, element);
            }
            var ganador_color = await _unitOfwork.ApuestaRepository.SelectGanadorColor(color_ganador, id_ruleta);
            foreach (Apuesta element in ganador_color)
            {
                element.gano = "Si";
                element.valor_ganado = element.dinero * 1.8m;
                await _unitOfwork.ApuestaRepository.UpdateGanador(element.id_apuesta, element);
            }
            await _unitOfwork.RuletaRepository.CerrarRuleta(id_ruleta);
        }
    }
}

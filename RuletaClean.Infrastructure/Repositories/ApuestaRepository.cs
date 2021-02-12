using Microsoft.EntityFrameworkCore;
using RuletaClean.Core.Entities;
using RuletaClean.Core.Interfaces;
using RuletaClean.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletaClean.Infrastructure.Repositories
{
    public class ApuestaRepository : IApuestaRepository
    {
        private readonly SqlContext _context;
        public ApuestaRepository(SqlContext context)
        {
            _context = context;
        }
        public async Task<string> InsertApuestas(Apuesta apuesta)
        {
            string mensaje = "";
            if (await ValidarUsuarioCredito(apuesta))
            {
                if(await ValidarRuletaAbierta(apuesta))
                {
                    if(apuesta.color == null)
                    {
                        if(ValidarNumero(apuesta))
                        {
                            _context.Apuesta.Add(apuesta);
                            await _context.SaveChangesAsync();
                            mensaje = "Ok";
                        }
                        else
                        {
                            mensaje = "El numero no esta entre 0 y 36";
                        }
                    }
                    else
                    {
                        _context.Apuesta.Add(apuesta);
                        await _context.SaveChangesAsync();
                        mensaje = "Ok";
                    }
                }
                else
                {
                    mensaje = "La ruleta no se encuentra abierta";
                }
            }
            else
            {
                mensaje = "El usuario no es valido o no tiene credito";
            }

            return mensaje;
        }

        
        public async Task<IEnumerable<Apuesta>> SelectApuestaByRuleta(int id_ruleta)
        {
            await RealizarSorteo(id_ruleta);
            var apuestas = await _context.Apuesta.Where(p => p.id_ruleta == id_ruleta).ToListAsync();
            return apuestas;
        }

        public async Task<bool> ValidarUsuarioCredito(Apuesta apuesta)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(a => a.id_usuario == apuesta.id_usuario);
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
            var ruleta = await _context.Ruleta.FirstOrDefaultAsync(a => a.id_ruleta == apuesta.id_ruleta);
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
        public async Task<IEnumerable<Apuesta>> SelectGanadorNumero(string numero_ganador, int id_ruleta)
        {
            var ganadores = await _context.Apuesta.Where(p => p.numero == numero_ganador && p.id_ruleta == id_ruleta && p.color == null).ToListAsync();
            return ganadores;
        }

        public async Task<IEnumerable<Apuesta>> SelectGanadorColor(string color_ganador, int id_ruleta)
        {
            var ganadores = await _context.Apuesta.Where(p => p.color == color_ganador && p.id_ruleta == id_ruleta && p.numero == null).ToListAsync();
            return ganadores;
        }
        public async Task UpdateGanador(int id, Apuesta apuesta)
        {
            if (apuesta.id_apuesta == id)
            {
                _context.Entry(apuesta).State = EntityState.Modified;
                await _context.SaveChangesAsync();
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

            var ganador_numeros = await SelectGanadorNumero(numero_ganador.ToString(), id_ruleta);
            foreach (Apuesta element in ganador_numeros)
            {
                element.gano = "Si";
                element.valor_ganado = element.dinero * 5;
                await UpdateGanador(element.id_apuesta, element);
            }
            var ganador_color = await SelectGanadorColor(color_ganador, id_ruleta);
            foreach (Apuesta element in ganador_color)
            {
                element.gano = "Si";
                element.valor_ganado = element.dinero * 1.8m;
                await UpdateGanador(element.id_apuesta, element);
            }
            await CerrarRuleta(id_ruleta);
        }
        public async Task CerrarRuleta(int id_ruleta)
        {
            var ruleta = await _context.Ruleta.FirstOrDefaultAsync(a => a.id_ruleta == id_ruleta);
            ruleta.estado = "cerrado";
            await _context.SaveChangesAsync();
            
        }


    }
}

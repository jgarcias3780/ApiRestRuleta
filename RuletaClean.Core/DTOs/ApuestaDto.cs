using System;
using System.Collections.Generic;
using System.Text;

namespace RuletaClean.Core.DTOs
{
    public class ApuestaDto
    {
        public int id_apuesta { get; set; }
        public int id_ruleta { get; set; }
        public int id_usuario { get; set; }
        public string numero { get; set; }
        public decimal dinero { get; set; }
        public string color { get; set; }
        public string gano { get; set; }
        public decimal valor_ganado{ get; set; }

    }
}

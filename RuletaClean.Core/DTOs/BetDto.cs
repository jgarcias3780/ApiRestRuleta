using System;
using System.Collections.Generic;
using System.Text;

namespace RuletaClean.Core.DTOs
{
    public class BetDto
    {
        public int id_bet { get; set; }
        public int id_roulette { get; set; }
        public int id_user { get; set; }
        public string number { get; set; }
        public decimal money { get; set; }
        public string color { get; set; }
        public string win { get; set; }
        public decimal earned_value{ get; set; }

    }
}

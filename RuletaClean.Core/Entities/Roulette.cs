using System.Collections.Generic;

namespace RuletaClean.Core.Entities
{
    public partial class Roulette
    {
        public Roulette()
        {
            Bet = new HashSet<Bet>();
        }
        public int id_roulette { get; set; }
        public string roulette_name { get; set; }
        public string state { get; set; }

        public virtual ICollection<Bet> Bet { get; set; }

    }
}

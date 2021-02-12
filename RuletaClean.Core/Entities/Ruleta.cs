using System.Collections.Generic;

namespace RuletaClean.Core.Entities
{
    public partial class Ruleta
    {
        public Ruleta()
        {
            Apuesta = new HashSet<Apuesta>();
        }
        public int id_ruleta { get; set; }
        public string nombre_ruleta { get; set; }
        public string estado { get; set; }

        public virtual ICollection<Apuesta> Apuesta { get; set; }

    }
}

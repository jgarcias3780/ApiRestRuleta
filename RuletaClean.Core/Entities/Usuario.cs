using System.Collections.Generic;

namespace RuletaClean.Core.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Apuesta = new HashSet<Apuesta>();
        }
        public int id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public decimal credito { get; set; }

        public virtual ICollection<Apuesta> Apuesta { get; set; }


    }
}

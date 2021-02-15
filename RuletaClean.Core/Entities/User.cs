using System.Collections.Generic;

namespace RuletaClean.Core.Entities
{
    public partial class User
    {
        public User()
        {
            Bet = new HashSet<Bet>();
        }
        public int id_user { get; set; }
        public string user_name { get; set; }
        public decimal credit { get; set; }
        public virtual ICollection<Bet> Bet { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RuletaClean.Core.QueryFilters
{
    public class BetQueryFilter
    {
        public int? id_roulette { get; set; }
        public int? id_user { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastMoneyBookmaker.Models
{
    class Match
    {
        public int Id { get; set; }
        public KindOfSport KindOfSport { get; set; }
        public List<Team> Teams { get; set; }
    }
}

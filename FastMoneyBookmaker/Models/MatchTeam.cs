using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastMoneyBookmaker.Models
{
    class MatchTeam
    {
        public int Id { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}

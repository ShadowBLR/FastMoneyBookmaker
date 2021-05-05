using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastMoneyBookmaker.Models
{
    class Bet
    {
        public int BetId { get; set; }
        public DateTime DateOfBet { get; set; }
        public decimal Cash { get; set; }
        public BetState State { get; set; }
        public Match Match { get; set; }

    }
}

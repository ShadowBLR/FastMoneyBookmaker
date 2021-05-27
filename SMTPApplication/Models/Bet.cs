using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPApplication.Models
{
    class Bet
    {
        public int Id { get; set; }
        public decimal Cash { get; set; }
        public BetState State { get; set; }
        public MatchResult BetOn { get; set; }
        public DateTime DateOfBet { get; set; }


        public int MatchId { get; set; }
        public Match Match { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}

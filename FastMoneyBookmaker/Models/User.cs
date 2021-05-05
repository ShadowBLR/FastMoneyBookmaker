using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastMoneyBookmaker.Models
{
    class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public decimal Balance { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsBlocked { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public string Avatar { get; set; }
        public virtual Passport Passport { get; set; }
        public virtual Contact Contact { get; set; }
        public List<Bet> Bets { get; set;}
    }
}

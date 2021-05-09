using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastMoneyBookmaker.Models
{
    
    class Match
    {
        public int Id { get; set; }
        public KindOfSport KindOfSport { get; set; }
        public ICollection<Bet> Bets { get; set; }
        public ICollection<Team> Teams { get; set; }
        public Match()
        {
            Bets = new ObservableCollection<Bet>();
            Teams = new ObservableCollection<Team>();
        }
    }
}

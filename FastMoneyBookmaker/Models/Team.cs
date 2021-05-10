using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace FastMoneyBookmaker.Models
{
    class Team
    {  
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
        public Team ()
        {
            Matches = new ObservableCollection<Match>();
            Name = "";
        }
    }
}

using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace SMTPApplication.Models
{
    class Team
    {  
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MatchTeam> MatchTeams { get; set; }
        public Team ()
        {
            Name = "";
            MatchTeams = new ObservableCollection<MatchTeam>();
        }
    }
}

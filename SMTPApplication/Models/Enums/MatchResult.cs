using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPApplication.Models
{
    public enum MatchResult 
    { 
        Undefined = 0, 
        FirstTeamWin = 1, 
        SecondTeamWin = 2 ,
        Draw = 3,
        Cancel = 4 
    }
}

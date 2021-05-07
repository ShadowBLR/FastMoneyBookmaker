using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Interfaces;
using FastMoneyBookmaker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastMoneyBookmaker.ViewModels
{
    class MatchesViewModel : ViewModel, IPageVIewModel
    {
        private User currentUser;
        public User CurrentUser
        {
            get => currentUser;
            set => Set(ref currentUser, value);
        }
        private BookmakerContext context;
        private ObservableCollection<Match> matches;
        public ObservableCollection<Match> Matches
        {
            get=>matches;
            set => Set(ref matches, value);
        }
        public MatchesViewModel(BookmakerContext context,User user)
        {
/*           CurrentUser =user ;
           this.context = context;
           Matches = this.context.Matches.Local;
            var mat = from m in context.Matches
                      join
t in context.Teams on m.Id equals t.MatchId
                      select new new
                      {
                          m.Id,
                          m.KindOfSport,
                          m.Teams
                      };*/

        }
    }
}

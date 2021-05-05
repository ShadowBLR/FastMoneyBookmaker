using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastMoneyBookmaker.ViewModels.For_models
{
    class MatchViewModel:ViewModel
    {
        private Match match;
        public Match Match
        {
            get => match;
            set => Set(ref match, value);
        }
        public int Id
        {
            get => match.Id;
            set
            {
                match.Id = value;
                OnPropertyChanged("Id");
            }
        }
        public KindOfSport KindOdSport
        {
            get => match.KindOfSport;
            set
            {
                match.KindOfSport = value;
                OnPropertyChanged("KindOfSport");
            }
        }
        private List<TeamViewModel> teams;
        public List<TeamViewModel> Teams
        {
            get => teams;
            set
            {
                teams = value;
                OnPropertyChanged("Teams");
            }
        }
        public MatchViewModel()
        {
            teams = new List<TeamViewModel>();
        }
    }
}

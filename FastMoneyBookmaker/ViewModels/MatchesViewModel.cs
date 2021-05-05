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
        private Match match;
        #region match's fields
        public int Id
        {
            get => match.Id;
            set
            {
                match.Id = value;
                OnPropertyChanged("Id");
            }
        }
        public KindOfSport KindOfSport
        {
            get => match.KindOfSport;
            set
            {
                match.KindOfSport = value;
                OnPropertyChanged("KindOfSport");
            }
        }
        public List<Team> Teams
        {
            get => match.Teams;
            set
            {
                match.Teams = value;
                OnPropertyChanged("Teams");
            }
        }

        #endregion
        private ObservableCollection<Match> matches;
        public ObservableCollection<Match> Matches
        {
            get=>matches;
            set => Set(ref matches, value);
        }
        public MatchesViewModel()
        {
            Matches = new ObservableCollection<Match>
            {
                new Match
                {
                     Id=1,
                     KindOfSport=KindOfSport.BasketBall,
                     Teams = new List<Team>
                     {
                         new Team
                         {
                              Name="Nemiga"
                         },new Team
                         {
                             Name="EG"
                         }
                     }
                }
            };
            //Matches[0];
        }
    }
}

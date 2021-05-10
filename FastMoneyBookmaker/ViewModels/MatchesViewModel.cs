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
        private ObservableCollection<Bet> bets;
        public ObservableCollection<Bet> Bets
        {
            get => bets;
            set => Set(ref bets, value);
        }
        public MatchesViewModel(BookmakerContext context,User user)
        {
           CurrentUser =user ;
           this.context = context;
            Matches = context.Matches.Local;
           
        }
    }
}

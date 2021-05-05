using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Models;
using FastMoneyBookmaker.ViewModels.For_models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastMoneyBookmaker.ViewModels.For_models
{
    class BetViewModel:ViewModel
    {
        private Bet bet;
        public Bet Bet
        {
            get => bet;
            set => Set(ref bet, value);
        }
        public int Id
        {
            get => bet.BetId;
            set
            {
                bet.BetId = value;
                OnPropertyChanged("Bet");
            }
        }
        public decimal Cash
        {
            get => bet.Cash;
            set
            {
                bet.Cash = value;
                OnPropertyChanged("Cash");
            }
        }
        public DateTime DateOfBet
        {
            get => bet.DateOfBet;
            set
            {
                bet.DateOfBet = value;
                OnPropertyChanged("DateOfBet");
            }
        }
        public BetState State
        {
            get => bet.State;
            set
            {
                bet.State = value;
                OnPropertyChanged("State");
            }
        }
        private MatchViewModel match;
        public MatchViewModel Match
        {
            get => match;
            set => Set(ref match, value);
        }


    }
}

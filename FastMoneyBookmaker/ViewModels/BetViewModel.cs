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
    class BetViewModel:ViewModel,IPageVIewModel
    {
        public User CurrentUser { get; set; }
        private BookmakerContext context;
        private ObservableCollection<Bet> bets;
        public ObservableCollection<Bet> Bets
        {
            get => bets;
            set => Set(ref bets, value);
        }
        public BetViewModel(BookmakerContext bookmakerContext,User current)
        {
            context = bookmakerContext;
            CurrentUser = current;
          //  Bets =new ObservableCollection<Bet>(context.Bets.Where(b => b.User.Id == current.Id).Select(t=>t));
           
                   
        }
        private static ObservableCollection<Bet> ToObservableCollection<Bet>(IEnumerable<Bet> enumerator)
        {
            return new ObservableCollection<Bet>(enumerator)??new ObservableCollection<Bet>();
        }
    }
}

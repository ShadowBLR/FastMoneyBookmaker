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
        private User currentUser;
        public User CurrentUser
        {
            get => currentUser;
            set => Set(ref currentUser, value);
        }
        private BookmakerContext context;
        public BookmakerContext Context
        {
            get => context;
            set => Set(ref context, value);
        }
        private ObservableCollection<Bet> bets;
        public ObservableCollection<Bet> Bets
        {
            get => bets;
            set => Set(ref bets, value);
        }
        public BetViewModel(BookmakerContext bookmakerContext,User current)
        {
            Context = bookmakerContext;
            CurrentUser = current;
            
            var result = from b in context.Bets
                   where b.UserId==CurrentUser.Id
                   join m in context.Matches
                   on b.MatchId equals m.Id
                   select new { Bets = b };
            Bets = new ObservableCollection<Bet>();
            foreach (var b in result)
            {
                Bets.Add(b.Bets);
            }
            System.Windows.MessageBox.Show(Bets.Count.ToString());
          //  Bets =new ObservableCollection<Bet>(context.Bets.Where(b => b.User.Id == current.Id).Select(t=>t));
           
                   
        }
        private static ObservableCollection<Bet> ToObservableCollection<Bet>(IEnumerable<Bet> enumerator)
        {
            return new ObservableCollection<Bet>(enumerator)??new ObservableCollection<Bet>();
        }
    }
}

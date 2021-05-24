using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Commands.Base;
using FastMoneyBookmaker.Helpers;
using FastMoneyBookmaker.Interfaces;
using FastMoneyBookmaker.Models;
using FastMoneyBookmaker.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
        public decimal Balance
        {
            get => CurrentUser.Balance;
            set
            {
                CurrentUser.Balance = value;
                OnPropertyChanged("Balance");
                CurrentUser?.BalanceChanged(value);
            }
        }
        private Bet selectedBet;
        public Bet SelectedBet
        {
            get => selectedBet;
            set => Set(ref selectedBet, value);
        }
        private BookmakerContext context;
        public BookmakerContext Context
        {
            get => context;
            set => Set(ref context, value);
        }
        public BetViewModel(BookmakerContext bookmakerContext,User current)
        {
            Context = bookmakerContext;
            CurrentUser = current;
            Balance = CurrentUser.Balance;
            
            var result = from b in context.Bets
                   where b.UserId==CurrentUser.Id
                   select b;
           
            CurrentUser.Bets = new BindingList<Bet>(context.Bets
                .Where(b => b.User.Id == current.Id)
                .Select(t => t)
                .ToList());
          //  Bets =new ObservableCollection<Bet>(context.Bets.Where(b => b.User.Id == current.Id).Select(t=>t));
        }
        private static ObservableCollection<Bet> ToObservableCollection<Bet>(IEnumerable<Bet> enumerator)
        {
            return new ObservableCollection<Bet>(enumerator)??new ObservableCollection<Bet>();
        }
        private RelayCommand cancelABetCommand;
        public ICommand CancelABetCommand
        {
            get
            {
                if (cancelABetCommand == null)
                {
                    cancelABetCommand = new RelayCommand(CancelABet, CanCancelABet);
                }
                return cancelABetCommand;
            }
        }
        private void CancelABet(object obj)
        {
            if (SelectedBet != null)
            {
                Balance += Math.Round(0.7M * SelectedBet.Cash, 2);
                context.Bets.Remove(SelectedBet);
                context.SaveChanges();
                context.Bets.Load();
                MessageBoxCaller.Call("Success", ActionResult.Succes);
            }
            else
            {
                MessageBoxCaller.Call("Error", ActionResult.Error);
            }
        }
        private bool CanCancelABet(object obj)
        {
            return SelectedBet != null;
        }
    }
}

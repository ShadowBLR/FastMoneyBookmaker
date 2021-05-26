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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastMoneyBookmaker.ViewModels
{
    class MatchesViewModel : ViewModel, IPageVIewModel
    {
        private User currentUser;
        public User CurrentUser
        {
            get => currentUser;
            set 
            { 
                Set(ref currentUser, value); 
            }
        }
        public decimal Balance
        {
            get => CurrentUser.Balance;
            set
            {
                CurrentUser.Balance = value;

                CurrentUser?.BalanceChanged(value); 
            }
        }
        private Match selectedMatch;
        public Match SelectedMatch
        {
            get => selectedMatch;
            set => Set(ref selectedMatch, value);
        }
        private BookmakerContext context;
        private string teamName;
        public string TeamName
        {
            get => teamName;
            set => Set(ref teamName, value);
        }
        private ObservableCollection<Match> matches;
        public ObservableCollection<Match> Matches
        {
            get=>matches;
            set => Set(ref matches, value);
        }
        public MatchesViewModel(BookmakerContext context,User user)
        {
           CurrentUser =user ;
            Balance = CurrentUser.Balance;
           this.context = context;

            var result = from m in context.Matches
                         join mt in context.MatchTeams
                         on m.Id equals mt.MatchId
                         join t in context.Teams
                         on mt.TeamId equals t.Id
                         select new { match = m,matchTeam=mt,team=t };
            Matches = new ObservableCollection<Match>();
           CurrentUser.Bets = new BindingList<Bet>();
            if (result != null)
            {
                Match mat = result.FirstOrDefault().match;
                if (mat != null)
                {
                    foreach (var r in result)
                    {
                        if (r.match.Id != mat.Id)
                        {
                            Matches.Add(mat);
                        }
                        mat = r.match;
                    }
                    Matches.Add(mat);
                }
            }
           //Matches = context.Matches.Local;
           
        }
        private RelayCommand makeABetCommand;
        public ICommand MakeABetCommand
        {
            get
            {
                if(makeABetCommand==null)
                {
                    makeABetCommand = new RelayCommand(MakeABet, CanMakeABet);
                }
                return makeABetCommand;
            }
        }
        private void MakeABet(object obj)
        {
            if (obj is TextBox textBox)
            {
                if (Decimal.TryParse(textBox.Text, out decimal sum))
                {
                    sum = Math.Round(sum, 2);
                    if (Balance < sum)
                    {
                        MessageBoxCaller.Call("NotFunds", ActionResult.Error);
                    }
                    else
                    {
                        Bet bet = new Bet
                        {
                            Cash = sum,
                            Match = SelectedMatch,
                            State = BetState.Wait,
                            DateOfBet = DateTime.Now,
                            User = CurrentUser
                        };
                        context.Bets.Add(bet);
                        context.SaveChanges();
                        context.Bets.Load();
                        Balance -= sum;
                        textBox.Text = "";
                        MessageBoxCaller.Call("Success", Models.Enums.ActionResult.Succes);
                    }
                }

            }
        }
        private bool CanMakeABet(object obj)
        {
            if (obj is TextBox textBox)
            {
                if (Decimal.TryParse(textBox.Text, out decimal sum))
                    return true;
            }
            return false;
         }
    }

}

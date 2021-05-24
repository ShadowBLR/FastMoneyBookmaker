using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Commands.Base;
using FastMoneyBookmaker.Helpers;
using FastMoneyBookmaker.Interfaces;
using FastMoneyBookmaker.Models;
using FastMoneyBookmaker.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastMoneyBookmaker.ViewModels
{
    class BalanceViewModel:ViewModel,IPageVIewModel
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
        private BookmakerContext bookmakerContext;
        public BookmakerContext BookmakerContext
        {
            get => bookmakerContext;
            set => Set(ref bookmakerContext, value);
        }
        #region Constructors
        public BalanceViewModel(BookmakerContext context,User user)
        {
            bookmakerContext = context;
            CurrentUser = user;
            Balance = CurrentUser.Balance;
        }
        #endregion
        #region Commands
        #region PutMoneyCommand
        private RelayCommand putMoneyCommand;
        public ICommand PutMoneyCommand
        {
            get
            {
                if (putMoneyCommand == null)
                    putMoneyCommand = new RelayCommand(PutMoney,CanPutMoney);
                return putMoneyCommand;
            }
        }
        public bool CanPutMoney(object obj)
        {
            if (obj is TextBox tb)
            {
                if (decimal.TryParse(tb.Text, out decimal money) && !(money < 0))
                    return true;
            }
            return false;
        }
        public void PutMoney(object obj)
        {
            if (obj is TextBox tb)
            {
                if (decimal.TryParse(tb.Text, out decimal money)&&!(money<0))
                {
                    money = Math.Round(money, 2);
                    if (!(Balance + money < money)&&(Balance+money <
                        decimal.MaxValue))
                    {
                        Balance += money;
                        BookmakerContext.Entry(CurrentUser).State = System.Data.Entity.EntityState.Modified;
                        BookmakerContext.SaveChanges();
                        MessageBoxCaller.Call("Success", ActionResult.Succes);
                    }
                    else
                    {
                        MessageBoxCaller.Call("BalanceExceeded",ActionResult.Error);
                    }
                }
                else
                {
                    MessageBoxCaller.Call("IncorrectedData", ActionResult.Error);
                }
                tb.Text = "";
            }
        }
        #endregion
        #region OutputMoneyCommand
        private RelayCommand outputMoneyCommand;
        public ICommand OutputMoneyCommand
        {
            get
            {
                if (outputMoneyCommand == null)
                    outputMoneyCommand = new RelayCommand(OutputMoney, CanOutputMoney);
                return outputMoneyCommand;
            }
        }
        public bool CanOutputMoney(object obj)
        {
            if (obj is TextBox tb)
                if (decimal.TryParse(tb.Text, out decimal money) && !(money < 0))
                    return true;
            return false;
        }
        public void OutputMoney(object obj)
        {
            if (obj is TextBox tb)
            {
                if (CurrentUser.IsConfirmed)
                {
                    if (decimal.TryParse(tb.Text, out decimal money))
                    {
                        money = Math.Round(money, 2);
                        if (Balance < money)
                        {
                            MessageBoxCaller.Call("NotFunds", ActionResult.Error);
                        }
                        else
                        {
                            Balance -=money;
                            BookmakerContext.SaveChanges();
                            MessageBoxCaller.Call("Success", ActionResult.Succes);
                        }
                    }
                    else
                    {
                        MessageBoxCaller.Call("IncorrectedData", ActionResult.Error);
                    }
                }
                else
                {
                    MessageBoxCaller.Call("IsNotConfirmed", ActionResult.Error);
                }
                tb.Text = "";
            }
        }
        #endregion

        #endregion

    }
}

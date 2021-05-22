using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Commands.Base;
using FastMoneyBookmaker.Interfaces;
using FastMoneyBookmaker.Models;
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
        public bool CanPutMoney(object obj) => true;
        public void PutMoney(object obj)
        {
            if (obj is TextBox tb)
            {
                if (decimal.TryParse(tb.Text, out decimal money))
                {
                    money = Math.Round(money, 2);
                    if (!(CurrentUser.Balance + money < money)&&(CurrentUser.Balance+money <
                        decimal.MaxValue))
                    {
                        CurrentUser.Balance += money;
                        BookmakerContext.Entry(CurrentUser).State = System.Data.Entity.EntityState.Modified;
                        BookmakerContext.SaveChanges();
                        System.Windows.MessageBox.Show("Succes");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Balance limit exceeded");
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Incorrected value");
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
        public bool CanOutputMoney(object obj) => true;
        public void OutputMoney(object obj)
        {
            if (obj is TextBox tb)
            {
                if (CurrentUser.IsConfirmed)
                {
                    if (decimal.TryParse(tb.Text, out decimal money))
                    {
                        money = Math.Round(money, 2);
                        if (CurrentUser.Balance < money)
                        {
                            System.Windows.MessageBox.Show("There are not enough funds in the account");
                        }
                        else
                        {
                            CurrentUser.Balance -=money;
                            BookmakerContext.SaveChanges();
                            System.Windows.MessageBox.Show("Succes");
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Incorrected value");
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Your account is'nt confirmed");
                }
                tb.Text = "";
            }
        }
        #endregion

        #endregion

    }
}

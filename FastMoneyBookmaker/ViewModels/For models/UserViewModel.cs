using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FastMoneyBookmaker.ViewModels.For_models
{
   // [Table("Users")]
    class UserViewModel : ViewModel
    {
        private User user;
        public User User
        {
            get => user;
            set => Set(ref user, value);
        }
        public int Id
        {
            get => user.Id;
            set
            {
                user.Id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Nickname
        {
            get => user.Nickname;
            set
            {
                user.Nickname = value;
                OnPropertyChanged("Nickname");
            }
            
        }
        public decimal Balance
        {
            get => user.Balance;
            set
            {
                user.Balance = value;
                OnPropertyChanged("Balance");
            }
        }
        public bool IsAdmonistratior
        {
            get => user.IsAdministrator;
            set
            {
                user.IsAdministrator = value;
                OnPropertyChanged("IsAdministrator");
            }
        }
        public bool IsBlocked
        {
            get => user.IsBlocked;
            set
            {
                user.IsBlocked = value;
                OnPropertyChanged("IsBlocked");
            }
        }
        public string Hash
        {
            get => user.Hash;
            set
            {
                user.Hash = value;
                OnPropertyChanged("Hash");
            }
        }
        public string Salt
        {
            get => user.Salt;
            set
            {
                user.Salt = value;
                OnPropertyChanged("Salt");
            }
        }
        public string Avatar
        {
            get => user.Avatar;
            set
            {
                user.Avatar = value;
                OnPropertyChanged("Avatar");
            }
        }
        public Passport Passport
        {
            get => user.Passport;
            set
            {
                user.Passport = value;
                OnPropertyChanged("Passport");
            }
        }
        public Contact Contact
        {
            get => user.Contact;
            set
            {
                user.Contact = value;
            }
        }
        private List<BetViewModel> bet;
        public List<BetViewModel> Bet
        {
            get => bet;
            set => Set(ref bet, value);
        }
        public UserViewModel()
        {
            user = new User();
            bet = new List<BetViewModel>();
        }
    }
}

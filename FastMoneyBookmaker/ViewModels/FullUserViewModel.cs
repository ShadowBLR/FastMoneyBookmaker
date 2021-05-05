using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastMoneyBookmaker.ViewModels.For_models;
namespace FastMoneyBookmaker.ViewModels
{
    class FullUserViewModel:ViewModel
    {
        private UserViewModel user;
        public UserViewModel User
        {
            get => user;
            set => Set(ref user, value);
        }
        
        private PassportViewModel passport;
        public PassportViewModel Passport
        {
            get => passport;
            set => Set(ref passport, value);
        }
        private ContactViewModel contact;
        public ContactViewModel Contact
        {
            get => contact;
            set => Set(ref contact, value);
        }
        private MatchesViewModel matches;
        public MatchesViewModel Matches
        {
            get => matches;
            set => Set(ref matches, value);
        }
        /* private MyBetsViewModel bets;
         private MyBetsViewModel Bets
         {
             get => bets;
             set => Set(ref bets, value);
         }*/
        public  FullUserViewModel()
        {
            User = new UserViewModel();
            Passport = new PassportViewModel();
            Contact = new ContactViewModel();
            //Bets = new MyBetsViewModel();
        }
    }
}

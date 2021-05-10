using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastMoneyBookmaker.ViewModels
{
    class AdministratorViewModel:ViewModel
    {
        private User admin;
        public User Admin
        {
            get => admin;
            set => Set(ref admin, value);
        }
        private User searchedUser;
        public User SearchedUser
        {
            get => searchedUser;
            set => Set(ref searchedUser, value);
        }
        private BookmakerContext context;
        public BookmakerContext Context
        {
            get => context;
            set => Set(ref context, value);
        }
        private Match newMatch;
        public Match NewMatch
        {
            get => newMatch;
            set => Set(ref newMatch,value);
        }
        public AdministratorViewModel(BookmakerContext bookmakerContext)
        {
            context = bookmakerContext;
        }
        public void AddMatch()
        {
            context.Matches.Add(NewMatch);
            context.SaveChanges();
        }
    }
   
}

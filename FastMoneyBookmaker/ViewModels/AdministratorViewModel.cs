using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Commands.Base;
using FastMoneyBookmaker.Interfaces;
using FastMoneyBookmaker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FastMoneyBookmaker.ViewModels
{
    class AdministratorViewModel:ViewModel,IPageVIewModel
    {
        #region admin
        private User admin;
        public User Admin
        {
            get => admin;
            set => Set(ref admin, value);
        }
        #endregion
        #region Users
        private User searchedUser;
        public User SearchedUser
        {
            get => searchedUser;
            set => Set(ref searchedUser, value);
        }
        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get => users;
            set => Set(ref users,value);
        }
        #endregion
        #region bookmakerContext
        private BookmakerContext context;
        public BookmakerContext Context
        {
            get => context;
            set => Set(ref context, value);
        }
        #endregion
        #region newMatch
        private Match newMatch;
        public Match NewMatch
        {
            get => newMatch;
            set => Set(ref newMatch,value);
        }
        #endregion
        #region teams
        private ObservableCollection<Team> teams;
        public ObservableCollection<Team> Teams
        {
            get => teams;
            set => Set(ref teams, value);
        }
        private Team teamOne;
        public Team TeamOne
        {
            get => teamOne;
            set => Set(ref teamOne, value);
        }
        private Team teamTwo;
        public Team TeamTwo
        {
            get => teamTwo;
            set => Set(ref teamTwo, value);
        }
        private double firstCoefficient;
        public double FirstCoefficient
        {
            get => firstCoefficient;
            set => Set(ref firstCoefficient, value);
        }
        private double secondCoefficient;
        public double SecondCoefficient
        {
            get => secondCoefficient;
            set => Set(ref secondCoefficient, value);
        }
        #endregion
        #region
        private ObservableCollection<Match> matches;
        public ObservableCollection<Match> Matches
        {
            get => matches;
            set => Set(ref matches, value);
        }
        #endregion
        private KindOfSport catrgory;
        public KindOfSport Category
        {
            get => catrgory;
            set => Set(ref catrgory, value);
        }
        #region Constructor
        public AdministratorViewModel(BookmakerContext bookmakerContext)
        {
            context = bookmakerContext;
            Teams = bookmakerContext.Teams.Local;
            Matches = bookmakerContext.Matches.Local;
            Users = bookmakerContext.Users.Local;
        }
        #endregion
        #region addMatchCommand
        private RelayCommand addMatchCommand;
        public ICommand AddMatchCommand
        {
            get
            {
                if(addMatchCommand==null)
                {
                    addMatchCommand = new RelayCommand(
                        (obj)=>AddMatch(obj),
                       (obj)=>CanAddMatch(obj));
                }
                return addMatchCommand;
            }
        }
        public void AddMatch(object obj)
        {
            context.Matches.Add(NewMatch);
            context.SaveChanges();
        }
        public bool CanAddMatch(object obj) => true;
        #endregion
        #region SaveChangesCommand
        private RelayCommand saveChangesCommand;
        public ICommand SaveChangesCommand
        {
            get
            {
                if (saveChangesCommand == null)
                    saveChangesCommand = new RelayCommand(Savechanges,CanSaveChanges);
                return saveChangesCommand;
            }
        }
        private void Savechanges(object obj)
        {
            context.SaveChanges();
        }
        private bool CanSaveChanges(object obj) => true;
        #endregion
    }

}

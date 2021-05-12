using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Commands.Base;
using FastMoneyBookmaker.Helpers;
using FastMoneyBookmaker.Interfaces;
using FastMoneyBookmaker.View;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System;
using FastMoneyBookmaker.ViewModels;
using FastMoneyBookmaker.Models;

namespace FastMoneyBookmaker.ViewModels
{
    class LoginViewModel : ViewModel, IPageVIewModel
    {
        private User currentUser;
        public User CurrentUser
        {
            get => currentUser;
            set => Set(ref currentUser, value);
        }
        private MainViewModel mainViewModel;
        public MainViewModel  MainViewModel
            {
            get
                {
                    return mainViewModel;
                }
            }
        public UserControl UserControl { get; set; }
        public BookmakerContext BookmakerContext { get; set; } 
        public LoginViewModel(MainViewModel parent,BookmakerContext bc)
        {
            mainViewModel = parent;
            UserControl = new LoginUI();
            BookmakerContext = bc;
            currentUser = parent.CurrentUser;
            
        }

        #region commands
        #region GoToRegisterViewCommand
        private RelayCommand goToRegisterViewCommand;
        public ICommand GoToRegisterViewCommand
        {
            get
            {
             
                if (goToRegisterViewCommand == null)
                {
                    goToRegisterViewCommand = new RelayCommand(
                        (obj) => mainViewModel.CurrentPage = mainViewModel.ListViewModel[1],
                        (obj) => true
                        );
                }
                return goToRegisterViewCommand;
            }
        }
        #endregion
        #region AuthorizationUserCommand
        private RelayCommand authorizationUserCommand;
        public ICommand AuthorizationUserCommand
        {
            get
            {
                if (authorizationUserCommand == null)
                {
                    authorizationUserCommand = new RelayCommand(
                        AuthorizationUser,
                        CanAuthorizationUser
                        );
                }
                return authorizationUserCommand;
            }
        }
        private void AuthorizationUser(object obj)
        {

            PasswordBox passBox = obj as PasswordBox;
           
            var User = from us in BookmakerContext.Users
                       join p in BookmakerContext.Passports on
                       us.Passport.Id equals p.Id join
                        c in BookmakerContext.Contacts on
                        us.Contact.Id equals c.Id
                       where us.Nickname==CurrentUser.Nickname
                       select new { User = us ,Passport = p,Contact = c};
        

            if (User.Count() != 0)
            {
                var activeUser = User.First();
                activeUser.User.Passport = activeUser.Passport;
                activeUser.User.Contact = activeUser.Contact;
                
                HashHelper helper = new HashHelper
                {
                    Salt = activeUser.User.Salt
                };
                helper.Hash = HashHelper.CalculeHashSHA256(passBox.Password, helper.Salt);
                if (helper.IsEqual(activeUser.User.Hash))
                {

                    System.Windows.MessageBox.Show("Hash equals");
                    CurrentUser =mainViewModel.CurrentUser= activeUser.User;
                    if (activeUser.User.IsBlocked)
                    {
                        System.Windows.MessageBox.Show("YOU ARE BLOKED");
                    }
                    else
                    {
                        if (activeUser.User.IsAdministrator)
                        {
                            AdministratorViewModel admin = new AdministratorViewModel(BookmakerContext);
                            mainViewModel.ListViewModel.Add(admin);
                            mainViewModel.CurrentPage = mainViewModel.ListViewModel[mainViewModel.ListViewModel.IndexOf(admin)];
                            
                        }
                        else
                        {
                            PersonalAccountViewModel personal = new PersonalAccountViewModel(MainViewModel, BookmakerContext);
                            mainViewModel.ListViewModel.Add(personal);
                            mainViewModel.CurrentPage = mainViewModel.ListViewModel[mainViewModel.ListViewModel.IndexOf(personal)];
                        }
                    }
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Login or password incorrected");
            }
              
        }
        private bool CanAuthorizationUser(object obj)
        {
            if (obj is PasswordBox passwordBox)
            {
                bool valid = true;
                Regex passwordPattern = new Regex(@"^[0-9a-zA-Z_*]{6,32}$");
                if (string.IsNullOrEmpty(passwordBox.Password) ||
                    !passwordPattern.IsMatch(passwordBox.Password))
                {
                    valid = false;
                }
                return valid;
            }
            return false;
        }
        #endregion
        #region GoToPersonalAccountView
        private RelayCommand goToPersonalAccountView;
        public ICommand GoToPersonalAccountView
        {
            get
            {
                goToPersonalAccountView = goToPersonalAccountView ?? new RelayCommand(
                    GoToPersonalAccount,
                    (obj)=>true
                    );
                return goToPersonalAccountView;
            }
        }

        private void GoToPersonalAccount(object obj)
        {
            mainViewModel.CurrentPage = mainViewModel.ListViewModel[2];
           
        }
        #endregion
        #endregion
        

}
}

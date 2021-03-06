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
using System.ComponentModel;
using FastMoneyBookmaker.Models.Enums;

namespace FastMoneyBookmaker.ViewModels
{
    class LoginViewModel : ViewModel, IPageVIewModel,IDataErrorInfo
    {
        private User currentUser;
        public User CurrentUser
        {
            get => currentUser;
            set => Set(ref currentUser, value);
        }
        private string login;
        public string Login
        {
            get => login;
            set => Set(ref login, value);
        }
        private bool hasErrorLogin;
        public bool HasErrorLogin
        {
            get => hasErrorLogin;
            set => Set(ref hasErrorLogin, value);
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

                    
                    CurrentUser =mainViewModel.CurrentUser= activeUser.User;
                    if (activeUser.User.IsBlocked)
                    {
                        MessageBoxCaller.Call("YouBlocked", ActionResult.Error);
                    }
                    else
                    {
                        if (activeUser.User.IsAdministrator)
                        {
                            AdministratorViewModel admin = new AdministratorViewModel(BookmakerContext,MainViewModel);
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
                MessageBoxCaller.Call(("IncorrectedData"), Models.Enums.ActionResult.Succes);
            }
              
        }
        private bool CanAuthorizationUser(object obj)
        {
            bool valid = false;
            if (obj is PasswordBox passwordBox)
            {
                CurrentUser.Nickname = Login;
                 
                Regex passwordPattern = new Regex(@"^[0-9a-zA-Z_*]{6,32}$");
                if (!string.IsNullOrEmpty(passwordBox.Password) &&
                    passwordPattern.IsMatch(passwordBox.Password))
                {
                    valid = true;
                }
            }
            return valid;
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
        #region IDataErrorInfo
        public string Error => throw new NotImplementedException();
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Login":
                        {
                            if (string.IsNullOrEmpty(Login))
                                error = "Empty login";
                            else
                            {
                                if (Login.Length > 16 || Login.Length < 4)
                                    error = "Unsuitable length";
                                else
                                {
                                    Regex regex = new Regex(@"^[A-Za-z0-9_]*$");
                                    if (!regex.IsMatch(Login))
                                        error = "Only latin, numbers and _";
                                }
                            }
                            break;
                        }
                }
                return error;
            }
        }
        #endregion

    }
}

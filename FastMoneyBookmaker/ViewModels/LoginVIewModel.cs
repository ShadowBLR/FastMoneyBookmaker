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

namespace FastMoneyBookmaker.ViewModels
{
    class LoginViewModel : ViewModel, IPageVIewModel
    {
        private FullUserViewModel userVM;
        public FullUserViewModel UserVM
        {
            get => userVM;
            set => Set(ref userVM, value);
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
            UserVM = new FullUserViewModel();
            
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
                       where us.Nickname==UserVM.User.Nickname
                       select new { User = us };

            if (User.Count() != 0)
            {
                var activeUser = User.First();
                HashHelper helper = new HashHelper
                {
                    Salt = activeUser.User.Salt
                };
                helper.Hash = HashHelper.CalculeHashSHA256(passBox.Password, helper.Salt);
                if (helper.IsEqual(activeUser.User.Hash))
                {
                    if (activeUser.User.IsBlocked)
                    {
                        System.Windows.MessageBox.Show("YOU ARE BLOKED");
                    }
                    else
                    {
                        if (activeUser.User.IsAdministrator)
                        {
                            System.Windows.MessageBox.Show("Show admin view");
                        }
                        else
                        {
                            mainViewModel.CurrentPage = new PersonalAccountViewModel(mainViewModel, BookmakerContext);
                        }
                    }
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Login or password incorrected");
            }
            UserVM = new FullUserViewModel();
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

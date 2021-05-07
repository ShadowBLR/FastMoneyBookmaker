using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Commands.Base;
using FastMoneyBookmaker.Helpers;
using FastMoneyBookmaker.Interfaces;
using FastMoneyBookmaker.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastMoneyBookmaker.ViewModels
{
    class RegisterViewModel: ViewModel,IPageVIewModel
    {
        private BookmakerContext bmContext { get; }
        public FullUserViewModel UserVM { get; set; }
        private MainViewModel mainViewModel;
        public MainViewModel MainViewModel
        {
            get 
            {
                return mainViewModel??throw new NullReferenceException("mainViewModel from RegisterViewModel is null");
            }
        }
        #region RegisterCommand
        private RelayCommand registerUserCommand;
        public ICommand RegisterUserCommand
        {
            get
            {
                registerUserCommand= registerUserCommand ?? new RelayCommand(
                    RegisterUser,
                    CanRegisterUser
                    );
                return registerUserCommand;
            }
        }
        private void RegisterUser(object obj)
        {
            if (obj is PasswordBox passBox)
            { 
                string nick = UserVM.User.Nickname;
                string email = UserVM.Contact.Email;
                if (IsValidPassword(passBox.Password))
                {
                    if (IsNotExistsEmailInDB(email))
                    {
                        if (IsNotExistsNicknameInDB(nick))
                        {

                            HashHelper hashHelper = new HashHelper
                            {
                                Salt = HashHelper.GenerateSalt32()
                            };
                            hashHelper.Hash = HashHelper.CalculeHashSHA256(passBox.Password, hashHelper.Salt);

                            User usr = new User
                            {
                                Nickname = nick,
                                Hash = hashHelper.Hash,
                                Salt = hashHelper.Salt,
                                Contact = new Contact { Email = email },
                                Passport = new Passport { DateOfBIrth=DateTime.Now}
                            };
                            bmContext.Users.Add(usr);
                            bmContext.SaveChanges();
                            GoToLoginViewCommand.Execute(null);
                            
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("this nickname already exists");
                        }

                    }
                    else
                    {
                        System.Windows.MessageBox.Show("this email already exists");
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Password is not valid");
                }
   
            }
        }
        private bool IsNotExistsNicknameInDB(string nickname)
        {
            var res = from u in bmContext.Users
                      where u.Nickname == nickname
                      select u;
            if (res.Count()!=1)
                return true;
            return false;
        }
        private bool IsValidPassword(string password)
        {
            string passwordPattern = @"^[a-zA-Z0-9_*]{6,32}$";
            Regex regexPassword = new Regex(passwordPattern);
            return regexPassword.IsMatch(password);
        }
        private bool IsNotExistsEmailInDB(string email)
        {
            var res = from cont in bmContext.Contacts
                          where cont.Email == email
                          select cont;
            if (res.Count()==0)
                return true;
            return false;
        }
        private bool IsAllFill(params string [] str)
        {
            bool rc = true;
            foreach(string s in str)
            {
                if (String.IsNullOrEmpty(s))
                    rc = false;
            }
            return rc; 
        }
        private  bool CanRegisterUser(object obj)
        {
            return obj is PasswordBox passwordBox &&
                !String.IsNullOrEmpty(passwordBox.Password);
        }
#endregion
        #region CONSTRUCTORS
        public RegisterViewModel(MainViewModel parent,BookmakerContext context)
        {
            mainViewModel = parent;
            bmContext = context;
            UserVM = new FullUserViewModel();
        }
        public RegisterViewModel( )
        {
           
        }
        #endregion
        #region GoToLoginViewCommand
        private RelayCommand goToLoginViewCommand;
        public ICommand GoToLoginViewCommand
        {
            get
            {
                if (goToLoginViewCommand == null)
                {
                    goToLoginViewCommand = new RelayCommand(
                        (obj) => mainViewModel.CurrentPage = mainViewModel.ListViewModel[0],
                        (obj) => true
                        );
                }
                return goToLoginViewCommand;
            }
        }
        #endregion
    }
}

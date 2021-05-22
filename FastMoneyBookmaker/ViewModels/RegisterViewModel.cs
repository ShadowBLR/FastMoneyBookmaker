using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Commands.Base;
using FastMoneyBookmaker.Helpers;
using FastMoneyBookmaker.Interfaces;
using FastMoneyBookmaker.Models;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastMoneyBookmaker.ViewModels
{
    class RegisterViewModel: ViewModel,IPageVIewModel,IDataErrorInfo
    {
        private BookmakerContext bmContext;
        public BookmakerContext BmContext
        {
            get => bmContext;
            set => Set(ref bmContext, value);
        }
        private User currentUser;
        public User CurrentUser
        {
            get => currentUser;
            set => Set(ref currentUser, value);
        }
        private string nickname;
        public string Nickname
        {
            get => nickname;
            set => Set(ref nickname, value);
        }
        private string email;
        public string Email
        {
            get => email;
            set => Set(ref email, value);
        }
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
                
                if (IsValidPassword(passBox.Password))
                {
                    if (IsNotExistsEmailInDB(Email))
                    {
                        if (IsNotExistsNicknameInDB(Nickname))
                        {

                            HashHelper hashHelper = new HashHelper
                            {
                                Salt = HashHelper.GenerateSalt32()
                            };
                            hashHelper.Hash = HashHelper.CalculeHashSHA256(passBox.Password, hashHelper.Salt);

                            User usr = new User
                            {
                                Nickname = Nickname,
                                Hash = hashHelper.Hash,
                                Salt = hashHelper.Salt,
                                Contact = new Contact { Email = Email },
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
            var res = from u in BmContext.Users
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
            var res = from cont in BmContext.Contacts
                          where cont.Email == email
                          select cont;
            if (res.Count()==0)
                return true;
            return false;
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
            BmContext = context;
            CurrentUser = new User();
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
        #region Validation
        public string Error
        {
            get 
            { 
                throw new NotImplementedException(); 
            }
        }

    public string this[string columnName]
        {
            get
            {
                string result=string.Empty;
                switch(columnName)
                {
                    case "Nickname":
                            result = ValidationNickname(result);
                            break;
                    case "Email":
                            result = ValidationEmail(result);
                            break;
                }
                return result;
            }
        }
        private string ValidationNickname(string err)
        {
            Regex rule = new Regex(@"^[a-zA-Z0-9]{4,16}$");
            if(string.IsNullOrEmpty(Nickname))
            {
                err = "string is empty";
            }
            else if(!rule.IsMatch(Nickname))
            {
                err = "Only latin and number";
            }
            return err;
        }
        private string ValidationEmail(string err)
        {
            Regex rule = new Regex(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
            if (string.IsNullOrEmpty(Email))
            {
                err = "this field is required";
            }
            else if(!rule.IsMatch(Email))
            {
                err = "Incorrected email";
            }
            return err;
        }
        #endregion
    }
}

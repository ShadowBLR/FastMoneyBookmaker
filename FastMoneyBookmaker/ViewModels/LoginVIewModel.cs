using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Commands.Base;
using FastMoneyBookmaker.Interfaces;
using FastMoneyBookmaker.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastMoneyBookmaker.ViewModels
{
    class LoginViewModel : ViewModel, IPageVIewModel
    {
        private MainViewModel mainViewModel;
        public MainViewModel  MainViewModel
            {
            get
                {
                    return mainViewModel;
                }
            }
        public UserControl UserControl { get; set; }
        public LoginViewModel(MainViewModel parent)
        {
            mainViewModel = parent;
            UserControl = new LoginUI();
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
                        (obj) => mainViewModel.CurrentPage = mainViewModel.listViewModel[1],
                        (obj) => true
                        );
                    MessageBox.Show("CREATE COMMAND");
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
                if(authorizationUserCommand == null)
                {
                    authorizationUserCommand = new RelayCommand(AuthorizationUser);
                }
                return authorizationUserCommand;
            }
        }
        #endregion
        #endregion
        private void AuthorizationUser(object obj)
        {
            PasswordBox passwordBox = obj as PasswordBox;



        }

    }
}

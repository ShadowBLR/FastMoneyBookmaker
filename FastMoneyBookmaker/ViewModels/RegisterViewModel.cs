using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Commands.Base;
using FastMoneyBookmaker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FastMoneyBookmaker.ViewModels
{
    class RegisterViewModel: ViewModel,IPageVIewModel
    {
        private MainViewModel mainViewModel;
        public MainViewModel MainViewModel
        {
            get 
            {
                return mainViewModel??throw new NullReferenceException("mainViewModel from RegisterViewModel is null");
            }
        }
        public RegisterViewModel(MainViewModel parent)
        {
            mainViewModel = parent;
        }
        public RegisterViewModel( )
        {
           
        }
        private RelayCommand goToLoginViewCommand;
        public ICommand GoToLoginViewCommand
        {
            get
            {
                if (goToLoginViewCommand == null)
                {
                    goToLoginViewCommand = new RelayCommand(
                        (obj) => mainViewModel.CurrentPage = mainViewModel.listViewModel[0],
                        (obj) => true
                        );
                    MessageBox.Show("CREATE COMMAND");
                }
                return goToLoginViewCommand;
            }
        }
    }
}

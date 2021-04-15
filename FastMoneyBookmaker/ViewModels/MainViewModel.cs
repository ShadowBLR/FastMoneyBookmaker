using CourseWork.Commands;
using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Commands;
using FastMoneyBookmaker.Commands.Base;
using FastMoneyBookmaker.Interfaces;
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
     class MainViewModel:ViewModel,IPageVIewModel
    {
        public List<IPageVIewModel> listViewModel { get;} 
        private IPageVIewModel _currentPage;
        public IPageVIewModel CurrentPage
        {
            get => _currentPage;
            set => Set(ref _currentPage, value);
        }
        public void ChangeViewModel(IPageVIewModel viewModel)
        {
            if(!listViewModel.Contains(viewModel))
            {
                listViewModel.Add(viewModel);
            }
            CurrentPage = listViewModel.FirstOrDefault(vm => vm == viewModel);
        }
        private RelayCommand goToRegisterViewCommand;
        public ICommand GoToRegisterViewCommand
        {
            get 
            {
                if(goToRegisterViewCommand == null)
                {
                    goToRegisterViewCommand = new RelayCommand(
                        (obj) => CurrentPage = listViewModel[1],
                        (obj)=>true
                        ) ;
                    MessageBox.Show("CREATE COMMAND");
                }
                return goToRegisterViewCommand;
            }
        }
        private RelayCommand goToLoginViewModel;
        public ICommand GoToLoginViewCommand
        {
            get
            {
                if (goToLoginViewModel == null)
                {
                    goToLoginViewModel = new RelayCommand(
                        (obj) => CurrentPage = listViewModel[0],
                        (obj) => true
                        );
                    MessageBox.Show("CREATE COMMAND");
                }
                return goToLoginViewModel;
            }
        }
        #region constructor
        public MainViewModel()
        {
            listViewModel = new List<IPageVIewModel>
            {
                new LoginViewModel(this),
                new RegisterViewModel(this)
            };
            CurrentPage = listViewModel[0];

        }
        #endregion

    }
}

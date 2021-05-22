using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Commands.Base;
using FastMoneyBookmaker.Interfaces;
using FastMoneyBookmaker.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows;

namespace FastMoneyBookmaker.ViewModels
{
    class MainViewModel:ViewModel,IPageVIewModel
    {
        public MainWindow mainWnd { get; set; }
        private User currentUser;
        public User CurrentUser
        {
            get => currentUser;
            set => Set(ref currentUser, value);
        }
        private BookmakerContext bookmakerContext;
        public BookmakerContext BookmakerContext
        {
            get => bookmakerContext;
            set => Set(ref bookmakerContext, value);
        }
        public List<IPageVIewModel> ListViewModel { get;} 
        private IPageVIewModel _currentPage;
        public IPageVIewModel CurrentPage
        {
            get => _currentPage;
            set => Set(ref _currentPage, value);
        }
        public void ChangeViewModel(IPageVIewModel viewModel)
        {
            if(!ListViewModel.Contains(viewModel))
            {
                ListViewModel.Add(viewModel);
            }
            CurrentPage = ListViewModel.FirstOrDefault(vm => vm == viewModel);
        }
        #region constructor
        public MainViewModel(BookmakerContext bk,MainWindow mainWindow)
        {
            mainWnd = mainWindow;
            BookmakerContext = bk;
            CurrentUser = new User();
            ListViewModel = new List<IPageVIewModel>
            {
                new LoginViewModel(this,BookmakerContext),
                new RegisterViewModel(this,BookmakerContext)
             };
            CurrentPage = ListViewModel[0];
            
            //CurrentPage = new PersonalAccountViewModel(this,BookmakerContext);
           

        }
        #endregion
        #region LogOutCommand
        private RelayCommand logOutCommand;
        public ICommand LogOutCommand
        {
            get
            {
                if (logOutCommand == null)
                    logOutCommand = new RelayCommand(LogOut,CanLogOut);
                return logOutCommand;
            }
        }
        private bool CanLogOut(object obj) => true;
        private void LogOut(object obj)
        {
            CurrentUser = new User();
            ListViewModel[0] = new LoginViewModel(this, BookmakerContext);
            CurrentPage = ListViewModel[0];
        }
        #endregion
        #region DoFullScreenCommand
        private RelayCommand doFullScreenCommand;
        public ICommand DoFullScreenCommand
        {
            get
            {
                if(doFullScreenCommand==null)
                {
                    doFullScreenCommand = new RelayCommand(DoFullScreen, CanDoFullScreen);
                }
                return doFullScreenCommand;
            }
        }
        private bool CanDoFullScreen(object obj) => true;
        private void DoFullScreen(object obj)
        {
            if(obj is Window main)
            {
                main.WindowStyle = WindowStyle.SingleBorderWindow;
                main.WindowState = WindowState.Normal;
            }
        }
        #endregion
        #region DoNormalScreenCommand
        private RelayCommand doNormalScreenCommand;
        public ICommand DoNormalScreenCommand
        {
            get
            {
                if(doNormalScreenCommand==null)
                {
                    doNormalScreenCommand = new RelayCommand(DoNormalScreen, CanDoNormalScreen);
                }
                return doNormalScreenCommand;
            }
        }
        private bool CanDoNormalScreen(object obj) => true;
        private void DoNormalScreen(object obj)
        {
            if(obj is Window main)
            {
                main.WindowStyle = WindowStyle.None;
                main.WindowState = WindowState.Maximized;
            }
        }
        #endregion
    }
}

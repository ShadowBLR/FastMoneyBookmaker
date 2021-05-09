using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Interfaces;
using FastMoneyBookmaker.Models;
using System.Collections.Generic;
using System.Linq;

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

    }
}

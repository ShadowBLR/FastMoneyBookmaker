using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FastMoneyBookmaker.ViewModels
{
    class MainViewModel:ViewModel,IPageVIewModel
    {
        public MainWindow mainWnd { get; set; }
        public BookmakerContext BookmakerContext { get; set; }
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
                ListViewModel = new List<IPageVIewModel>
            {
                new LoginViewModel(this,BookmakerContext),
                new RegisterViewModel(this,BookmakerContext),
                new PersonalAccountViewModel(this,BookmakerContext)
             };
            CurrentPage = ListViewModel[0];
            //CurrentPage = new PersonalAccountViewModel(this,BookmakerContext);
           

        }
        #endregion

    }
}

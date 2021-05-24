using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Commands.Base;
using FastMoneyBookmaker.Interfaces;
using FastMoneyBookmaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FastMoneyBookmaker.ViewModels
{
    class PersonalAccountViewModel : ViewModel, IPageVIewModel
    {
        private MainViewModel mainVM;
        public MainViewModel MainVM
        {
            get => mainVM;
            set => Set(ref mainVM, value);
        }
        private User currentUser;
        public User CurrentUser
        {
            get => currentUser;
            set => Set(ref currentUser, value);
        }
        
        public decimal Balance
        {
            get => CurrentUser.Balance;
            set
            {
                CurrentUser.Balance = value;
            }
        }
        public BookmakerContext BookmakerContext { get; set; }
        public List<IPageVIewModel> MenuList { get; set; }
        private IPageVIewModel selectedVM;
        public IPageVIewModel SelectedVM
        {
            get => selectedVM;
            set => Set(ref selectedVM, value);
        }
        public PersonalAccountViewModel(MainViewModel parent, BookmakerContext context)
        {
            mainVM = parent;
            BookmakerContext = context;
            CurrentUser = mainVM.CurrentUser;
            CurrentUser.RefeshBalance += CurrentUser_RefeshBalance;
            MenuList = new List<IPageVIewModel>()
            {
                new SettingsViewModel(mainVM.mainWnd),
                new MyProfileViewMode(BookmakerContext, mainVM.CurrentUser),
                new MatchesViewModel(BookmakerContext,mainVM.CurrentUser),
                new BetViewModel(context,mainVM.CurrentUser),
                new BalanceViewModel(context,mainVM.CurrentUser)
            };

        }

        private void CurrentUser_RefeshBalance(decimal value)
        {
            Balance = value;
        }
        #region Commands
        #region ShowSettingsUICommand
        private RelayCommand showSettingsUI;
        public ICommand ShowSettingsUI
        {
            get
            {
                if (showSettingsUI == null)
                {
                    showSettingsUI = new RelayCommand(
                        (obj) => SelectedVM = MenuList[0]
                        , (obj) => true
                        );
                }
                return showSettingsUI;
            }
        }
        #endregion]
        #region ShowMyProfileUI
        private RelayCommand showMyProfileUI;
        public ICommand ShowMyProfileUI
        {
            get
            {
                if (showMyProfileUI == null)
                {
                    showMyProfileUI = new RelayCommand(
                        ShowMyProfile,
                        (obj) => true
                        );
                }
                return showMyProfileUI;
            }
        }
        private void ShowMyProfile(object obj)
        {
            SelectedVM = MenuList[1];
        }
        #endregion
        #region ShowMatchesUI
        private RelayCommand showMatchesUI;
        public ICommand ShowMatchesUI
        {
            get
            {
                if (showMatchesUI == null)
                {
                    showMatchesUI = new RelayCommand(
                        (obj) => SelectedVM = MenuList[2]
                        , (obj) => true
                        );
                }
                return showMatchesUI;
            }
        }
        #endregion
        #region ShowMyBetsCommand
        private RelayCommand showMyBetsUI;
        public ICommand ShowMyBetsUI
        {
            get
            {
                if (showMyBetsUI == null)
                {
                    showMyBetsUI = new RelayCommand(
                        ShowMyBets,
                        (obj) => true
                        );
                }
                return showMyBetsUI;
            }
        }
        private void ShowMyBets(object obj)
        {
            SelectedVM = MenuList[3];
        }
        #endregion
        #region ShowBalanceUI
        private RelayCommand showBalanceUICommand;
        public ICommand ShowBalanceUICommand
        {
            get
            {
                if (showBalanceUICommand == null)
                    showBalanceUICommand = new RelayCommand(ShowBalanceUI,CanShowBalanceUI);
                return showBalanceUICommand;
            }
        }
        private bool CanShowBalanceUI(object obj) => true;
        private void ShowBalanceUI(object obj)
        {
            SelectedVM = MenuList[4];
        }
        #endregion
        #endregion
    }

}

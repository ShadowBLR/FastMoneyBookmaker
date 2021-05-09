﻿using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Commands.Base;
using FastMoneyBookmaker.Interfaces;
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
            MenuList = new List<IPageVIewModel>()
            {
                new SettingsViewModel(mainVM.mainWnd),
                new MyProfileViewMode(BookmakerContext, mainVM.CurrentUser),
                new MatchesViewModel(BookmakerContext,mainVM.CurrentUser),
                new BetViewModel(context,mainVM.CurrentUser)
            };

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
        public ICommand ShowMyBetsCommand
        {
            get
            {
                if (showMyProfileUI == null)
                {
                    showMyProfileUI = new RelayCommand(
                        ShowMyBets,
                        (obj) => true
                        );
                }
                return showMyProfileUI;
            }
        }
        private void ShowMyBets(object obj)
        {
            SelectedVM = MenuList[3];
        }
        #endregion
        #endregion
    }

}

using CourseWork.ViewModels.Base;
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
    class SettingsViewModel:ViewModel,IPageVIewModel
    {
        MainWindow MainWindow;
        public SettingsViewModel(MainWindow main)
        {
            MainWindow = main;
        }
       public bool IsFullScreen { get; set; }
        #region DoGullScreenCommand
        private RelayCommand doFullScreen;
        public ICommand DoFullScreen
        {
            get
            {
                if(doFullScreen==null)
                {
                    doFullScreen = new RelayCommand(
                        ResizeMainWindow,
                        (obj)=>true
                        );
                }
                return doFullScreen;
            }
        }
        private void ResizeMainWindow(object obj)
        {
            if(obj is CheckBox checkBox)
            {
                if(checkBox.IsEnabled)
                {
                    if (MainWindow.WindowState == WindowState.Maximized)
                    {
                        MainWindow.WindowStyle = WindowStyle.SingleBorderWindow;
                        MainWindow.WindowState = WindowState.Normal;

                    }
                    else
                    {
                        MainWindow.WindowStyle = WindowStyle.None;
                        MainWindow.WindowState = WindowState.Maximized;
                        
                    }
                }
                else
                {
                    MainWindow.WindowState = WindowState.Normal;
                }
            }
        }
        #endregion
    }
}

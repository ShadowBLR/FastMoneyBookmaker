using FastMoneyBookmaker.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FastMoneyBookmaker.Commands
{
    class CloseCommands
    {
        #region CloseWindowCommand
        private static RelayCommand closeWindowCommand;
        public static ICommand CloseWindowCommand
        {
            get
            {
                if (closeWindowCommand == null)
                {
                    closeWindowCommand = new RelayCommand(CloseWindow);
                }
                return closeWindowCommand;
            }
        }
        private static void CloseWindow(object obj)
        {
            if (obj is Window wnd) wnd.Close();
        }
        #endregion
    }
}

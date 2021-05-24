using FastMoneyBookmaker.Models.Enums;
using FastMoneyBookmaker.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MessageBox = FastMoneyBookmaker.View.MessageBox;

namespace FastMoneyBookmaker.Helpers
{
    public static  class  MessageBoxCaller
    {
        public static bool Call(string key,ActionResult res)
        {
             if(!String.IsNullOrEmpty(key))
            {
                MessageBox messageBox = new MessageBox
                {
                    Owner = Application.Current.MainWindow
                };
                MessageBoxContent messageBoxContent = new MessageBoxContent(key, res);
                messageBox.DataContext = messageBoxContent;
               
                messageBox.ShowDialog();
                return true;
            }
            return false;
        }
    }
}

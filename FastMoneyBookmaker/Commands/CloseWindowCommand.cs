using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastMoneyBookmaker.Commands
{
    class CloseWindowCommand : Base.RelayCommand
    {
        public CloseWindowCommand(Action<object> Execute, Func<object, bool> CanExecute = null) : base(Execute, CanExecute)
        {
        }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => Application.Current.Shutdown();
        public CloseWindowCommand() { }
    }
    
}

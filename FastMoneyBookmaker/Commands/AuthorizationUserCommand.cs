using CourseWork.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FastMoneyBookmaker.Commands
{
    class AuthorizationUserCommand : Command
    {
        public override bool CanExecute(object parameter)
        {

            //condition from do something
            PasswordBox passwordBox = parameter as PasswordBox;
            //TODO:Add isNullUser.UserName
            return IsValidPassword(passwordBox.Password, @"^[0-9a-zA-Z*]{6,32}$");
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
        private bool IsValidPassword(string password, string pattern)
        {
            Regex regex = new Regex(pattern);
            return !string.IsNullOrEmpty(password) && regex.IsMatch(password);
        }
    }
}

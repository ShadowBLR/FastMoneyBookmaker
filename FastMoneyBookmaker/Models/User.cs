using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastMoneyBookmaker.Models
{
    
    class User
    {
        public delegate void UserEvent(decimal a);

        public event UserEvent RefeshBalance;


        public int Id { get; set; }
        public string Nickname { get; set; }
        public decimal Balance { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsConfirmed { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public string Avatar { get; set; }
        public virtual Passport Passport { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual ICollection<Bet> Bets { get; set;}
        public User()
        {
            Nickname = "";
            Avatar = "";

        }
        public void BalanceChanged(decimal value)
        {
            RefeshBalance?.Invoke(value);
        }
    }
}

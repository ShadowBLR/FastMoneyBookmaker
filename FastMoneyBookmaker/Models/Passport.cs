using FastMoneyBookmaker.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastMoneyBookmaker.Models
{
    class Passport
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBIrth { get; set; }
       public Passport()
        {
            FirstName = "";
            SurName = "";
            LastName = "";
            DateOfBIrth = default;
        }
    }
}

using FastMoneyBookmaker.Models;
using FastMoneyBookmaker.ViewModels.For_models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastMoneyBookmaker
{
    class BookmakerContext:DbContext
    {
        public BookmakerContext() : base("DbConnection") { }
        /* public DbSet<UserViewModel> Users { get; set; }
         public DbSet<BetViewModel> Bets { get; set; }
         public DbSet<ContactViewModel> Contacts { get; set; }
         public DbSet<TeamViewModel> Teams { get; set; }
         public DbSet<PassportViewModel> Passports { get; set; }
         public DbSet<MatchViewModel> Matches { get; set; }*/
        public DbSet<User> Users { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Match> Matches { get; set; }
    }
}

using SMTPApplication.Models;
using System.Data.Entity;

namespace SMTPApplication
{
    class BookmakerContext:DbContext
    {
        public BookmakerContext() : base("DbConnection") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<MatchTeam> MatchTeams { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Match> Matches { get; set; }
    }
}

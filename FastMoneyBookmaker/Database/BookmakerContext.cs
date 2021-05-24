using FastMoneyBookmaker.Models;
using System.Data.Entity;

namespace FastMoneyBookmaker
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
        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasKey(t => t.Id);
            modelBuilder.Entity<Team>().Property(t => t.Name).IsOptional();

            modelBuilder.Entity<User>().Property(u => u.Nickname).IsOptional();
            modelBuilder.Entity<User>().Property(u=>u.Salt).IsOptional();
            modelBuilder.Entity<User>().Property(u=>u.Hash).IsOptional();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Bets)
                .WithRequired(b => b.User);

            modelBuilder.Entity<Match>()
                    .HasMany(m => m.Bets)
                    .WithRequired(b => b.Match);

            modelBuilder.Entity<Match>()
                .HasMany(m => m.Teams)
                .WithRequired(t=>t.)

            base.OnModelCreating(modelBuilder);
        }*/
    }
}

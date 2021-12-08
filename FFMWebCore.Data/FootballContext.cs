using FFMWebCore.Domain;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace FFMWebCore.Data
{
    public class FootballContext : DbContext
    {
        private readonly string _connectionString;
        private static Config Config { get; set; } = Config.GetConfig();

        #region DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
        public DbSet<UserTeamSquad> UserTeamSquads { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }
        #endregion

        public FootballContext(string connectionString) : base()
        {
            _connectionString = connectionString;
        }

        public FootballContext(DbContextOptions<FootballContext> options) : base(options)
        {
            
        }

        public FootballContext()
        {
            _connectionString = Config.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(_connectionString != null)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("Users");
                u.HasKey(u => u.Id);
                u.Property(u => u.Id).HasColumnName("Id").IsRequired();
                u.Property(u => u.Identifier).HasColumnName("Identifier").HasMaxLength(100).IsRequired();
                u.Property(u => u.EMail).HasColumnName("EMail").HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<UserTeam>(ut =>
            {
                ut.ToTable("UserTeams");
                ut.HasKey(ut => ut.Id);
                ut.Property(ut => ut.Id).HasColumnName("Id").IsRequired();
                ut.Property(ut => ut.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
                ut.HasOne(ut => ut.User).WithMany(u => u.UserTeams).OnDelete(DeleteBehavior.Cascade);
                ut.HasOne(ut => ut.Season).WithMany(s => s.UserTeams).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserTeamSquad>(uts =>
            {
                uts.ToTable("UserTeamSquads");
                uts.HasKey(uts => uts.Id);
                uts.Property(uts => uts.Id).HasColumnName("Id").IsRequired();
                uts.HasOne(uts => uts.UserTeam).WithMany(ut => ut.UserTeamSquads).OnDelete(DeleteBehavior.Cascade);
                uts.HasOne(uts => uts.Player).WithMany(p => p.UserTeamSquads).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Season>(s =>
            {
                s.ToTable("Seasons");
                s.HasKey(s => s.Id);
                s.Property(s => s.Id).HasColumnName("Id").IsRequired();
                s.Property(s => s.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Player>(p =>
            {
                p.ToTable("Players");
                p.HasKey(p => p.Id);
                p.Property(p => p.Id).HasColumnName("Id").IsRequired();
                p.Property(p => p.FirstName).HasColumnName("FirstName").HasMaxLength(50).IsRequired();
                p.Property(p => p.LastName).HasColumnName("LastName").HasMaxLength(50).IsRequired();
                p.Property(p => p.BirthDate).HasColumnName("BirthDate").HasMaxLength(20).IsRequired();
                p.Property(p => p.BirthCountry).HasColumnName("BirthCountry").HasMaxLength(50).IsRequired();
                p.Property(p => p.BirthPlace).HasColumnName("BirthPlace").HasMaxLength(50).IsRequired();
                p.Property(p => p.Nationality).HasColumnName("Nationality").HasMaxLength(50).IsRequired();
                p.Property(p => p.Height).HasColumnName("Height").HasMaxLength(10).IsRequired();
                p.Property(p => p.Weight).HasColumnName("Weight").HasMaxLength(10).IsRequired();
                p.Property(p => p.Position).HasColumnName("Position").HasMaxLength(50).IsRequired();
                p.Property(p => p.Photo).HasColumnName("Photo").HasMaxLength(100).IsRequired();
                //p.Property(p => p.Active).HasColumnName("Active").IsRequired();
                p.HasOne(p => p.Team).WithMany(t => t.Players).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Team>(t =>
            {
                t.ToTable("Teams");
                t.HasKey(t => t.Id);
                t.Property(t => t.Id).HasColumnName("Id").IsRequired();
                t.Property(t => t.Name).HasColumnName("Name").IsRequired();
                t.Property(t => t.Logo).HasColumnName("Logo").IsRequired();
                t.HasOne(t => t.League).WithMany(l => l.Teams).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<League>(l =>
            {
                l.ToTable("Leagues");
                l.HasKey(l => l.Id);
                l.Property(l => l.Id).HasColumnName("Id").IsRequired();
                l.Property(l => l.Name).HasColumnName("Name").IsRequired();
                l.Property(l => l.Country).HasColumnName("Country").IsRequired();
                l.Property(l => l.Logo).HasColumnName("Logo").IsRequired();
                l.Property(l => l.Flag).HasColumnName("Flag").IsRequired();
            });
        }
        #endregion
    }
}

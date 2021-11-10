using FFMWebCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace FFMWebCore.Data
{
    public class FootballContext : DbContext
    {
        private readonly string _connectionString;

        #region DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
        #endregion

        public FootballContext(string connectionString) : base()
        {
            _connectionString = connectionString;
        }

        public FootballContext(DbContextOptions<FootballContext> options) : base(options)
        {
            
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
                u.HasKey(x => x.Id);
                u.Property(x => x.Id).HasColumnName("ID").IsRequired();
                u.Property(x => x.Identifier).HasColumnName("Identifier").HasMaxLength(100).IsRequired();
                u.Property(x => x.EMail).HasColumnName("EMail").HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Season>(s =>
            {
                s.ToTable("Seasons");
                s.HasKey(x => x.Id);
                s.Property(x => x.Id).HasColumnName("ID").IsRequired();
                s.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<UserTeam>(ut =>
            {
                ut.ToTable("UserTeams");
                ut.HasKey(x => x.Id);
                ut.Property(x => x.Id).HasColumnName("ID").IsRequired();
                ut.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
                ut.HasOne(x => x.User).WithMany(x => x.Teams).OnDelete(DeleteBehavior.Cascade);
                ut.HasOne(x => x.Season).WithMany(x => x.Teams).OnDelete(DeleteBehavior.Cascade);
            });
        }
        #endregion
    }
}

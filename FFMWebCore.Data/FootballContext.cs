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
                u.Property(x => x.Id).HasColumnName("Id").IsRequired();
                u.Property(x => x.Identifier).HasColumnName("Identifier").HasMaxLength(100).IsRequired();
                u.Property(x => x.EMail).HasColumnName("EMail").HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Season>(s =>
            {
                s.ToTable("Seasons");
                s.HasKey(x => x.Id);
                s.Property(x => x.Id).HasColumnName("Id").IsRequired();
                s.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<UserTeam>(ut =>
            {
                ut.ToTable("UserTeams");
                ut.HasKey(x => x.Id);
                ut.Property(x => x.Id).HasColumnName("Id").IsRequired();
                ut.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
                ut.HasOne(x => x.User).WithMany(x => x.Teams).OnDelete(DeleteBehavior.Cascade);
                ut.HasOne(x => x.Season).WithMany(x => x.Teams).OnDelete(DeleteBehavior.Cascade);
            });

            //modelBuilder.Entity<League>(l =>
            //{
            //    l.ToTable("Leagues");
            //    l.HasKey(l => l.Id);
            //    l.Property(l => l.Id).HasColumnName("Id").IsRequired();
            //    l.Property(l => l.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            //    l.Property(l => l.Logo).HasColumnName("Logo").HasMaxLength(100).IsRequired();
            //    l.Property(l => l.Flag).HasColumnName("Flag").HasMaxLength(100).IsRequired();
            //});

            //modelBuilder.Entity<Player>(p =>
            //{
            //    p.ToTable("Players");
            //    p.HasKey(p => p.Id);
            //    p.Property(p => p.Id).HasColumnName("Id").IsRequired();
            //    p.Property(p => p.FirstName).HasColumnName("FirstName").HasMaxLength(50).IsRequired();
            //    p.Property(p => p.LastName).HasColumnName("LastName").HasMaxLength(50).IsRequired();
            //    p.Property(p => p.BirthDate).HasColumnName("BirthDate").HasMaxLength(20).IsRequired();
            //    p.Property(p => p.Nationality).HasColumnName("Nationality").HasMaxLength(50).IsRequired();
            //    p.Property(p => p.Height).HasColumnName("Height").HasMaxLength(10).IsRequired();
            //    p.Property(p => p.Photo).HasColumnName("Photo").HasMaxLength(100).IsRequired();
            //           -- Foreign Key --  ;
            //});

            //modelBuilder.Entity<Team>(t =>
            //{
            //    t.ToTable("Teams");
            //    t.HasKey(t => t.Id);
            //    t.Property(t => t.Id).HasColumnName("Id").IsRequired();
            //    t.Property(t => t.Name).HasMaxLength(50).HasColumnName("Name").IsRequired();
            //    t.Property(t => t.Logo).HasMaxLength(100).HasColumnName("Logo").IsRequired();
            //       -- Foreign Key --
            //});

            //modelBuilder.Entity<UserTeamSquad>(uts =>
            //{
            //    uts.ToTable("UserTeamSquads");
            //    uts.HasKey(uts => uts.Id);
            //    uts.Property(uts => uts.Id).HasColumnName("Id").IsRequired();
            //    uts.Property(uts => uts.GK1_Id).HasColumnName("GK1_Id").IsRequired();
            //    uts.Property(uts => uts.GK2_Id).HasColumnName("GK2_Id").IsRequired();
            //    uts.Property(uts => uts.DF1_Id).HasColumnName("DF1_Id").IsRequired();
            //    uts.Property(uts => uts.DF2_Id).HasColumnName("DF2_Id").IsRequired();
            //    uts.Property(uts => uts.DF3_Id).HasColumnName("DF3_Id").IsRequired();
            //    uts.Property(uts => uts.DF4_Id).HasColumnName("DF4_Id").IsRequired();
            //    uts.Property(uts => uts.DF5_Id).HasColumnName("DF5_Id").IsRequired();
            //    uts.Property(uts => uts.MF1_Id).HasColumnName("MF1_Id").IsRequired();
            //    uts.Property(uts => uts.MF2_Id).HasColumnName("MF2_Id").IsRequired();
            //    uts.Property(uts => uts.MF3_Id).HasColumnName("MF3_Id").IsRequired();
            //    uts.Property(uts => uts.MF4_Id).HasColumnName("MF4_Id").IsRequired();
            //    uts.Property(uts => uts.MF5_Id).HasColumnName("MF5_Id").IsRequired();
            //    uts.Property(uts => uts.AT1_Id).HasColumnName("AT1_Id").IsRequired();
            //    uts.Property(uts => uts.AT2_Id).HasColumnName("AT2_Id").IsRequired();
            //    uts.Property(uts => uts.AT3_Id).HasColumnName("AT3_Id").IsRequired();
            //    uts.Property(uts => uts.AT4_Id).HasColumnName("AT4_Id").IsRequired();
            //       -- Foreign Key --
            //});
        }
        #endregion
    }
}

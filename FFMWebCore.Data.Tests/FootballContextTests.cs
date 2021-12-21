using FFMWebCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FFMWebCore.Data.Tests
{
    public class FootballContextTests : FootballContextFixture
    {
        private readonly User _user;
        private readonly Season _season;

        public FootballContextTests()
        {
            _user = new() { Identifier = "Identifier", EMail = "test@email.com", UserTeams =  new List<UserTeam>()};
            _season = new() { Name = "TestSeason", UserTeams = new List<UserTeam>() };
        }

        [Fact]
        public async Task UserCreation()
        {
            await using (var context = DataTestUtils.CreateFootballContext())
            {
                context.Users.Add(_user);
                await context.SaveChangesAsync();
            }

            await using (var context = DataTestUtils.CreateFootballContext())
            {
                var fromDb = await context.Users.FindAsync(_user.Id);
                Assert.Equal(_user.Identifier, fromDb.Identifier);
                Assert.Equal(_user.EMail, fromDb.EMail);
            }
        }

        [Fact]
        public async Task SeasonCreation()
        {
            await using (var context = DataTestUtils.CreateFootballContext())
            {
                context.Seasons.Add(_season);
                await context.SaveChangesAsync();
            }

            await using (var context = DataTestUtils.CreateFootballContext())
            {
                var fromDb = await context.Seasons.FindAsync(_season.Id);
                Assert.Equal(_season.Id, fromDb.Id);
                Assert.Equal(_season.Name, fromDb.Name);
                Assert.Equal(_season.UserTeams, fromDb.UserTeams);
            }
        }

        [Fact]
        public async Task UserTeamCreation()
        {
            var userTeam = new UserTeam
            {
               Name = "TestName",
               UserId = 3,
               User = _user,
               SeasonId = 3,
               Season = _season,
            };

            await using (var context = DataTestUtils.CreateFootballContext())
            {
                context.UserTeams.Add(userTeam);
                await context.SaveChangesAsync();
            }

            await using (var context = DataTestUtils.CreateFootballContext())
            {
                var fromDb = await context.UserTeams.Include(u => u.User).Include(u => u.Season).FirstOrDefaultAsync(u => u.Id == userTeam.Id);
                Assert.Equal(userTeam.Name, fromDb.Name);
                Assert.Equal(userTeam.UserId, fromDb.UserId);
                Assert.Equal(userTeam.SeasonId, fromDb.SeasonId);
            }
        }
    }
}

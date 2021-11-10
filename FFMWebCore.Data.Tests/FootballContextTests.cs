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
        [Fact]
        public async Task TestUserCreation()
        {
            var user = new User
            {
                Identifier = "Identifier",
                EMail = "halts@maul.de"
            };

            await using (var context = DataTestUtils.CreateFootballContext())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }

            await using (var context = DataTestUtils.CreateFootballContext())
            {
                var fromDb = await context.Users.FindAsync(user.Id);
                Assert.Equal(user.Identifier, fromDb.Identifier);
                Assert.Equal(user.EMail, fromDb.EMail);
            }
        }

        [Fact]
        public async Task TestSeasonCreation()
        {
            var season = new Season
            {
                Name = "TestSeason",
                Teams = new List<UserTeam>()
            };

            await using (var context = DataTestUtils.CreateFootballContext())
            {
                context.Seasons.Add(season);
                await context.SaveChangesAsync();
            }

            await using (var context = DataTestUtils.CreateFootballContext())
            {
                var fromDb = await context.Seasons.FindAsync(season.Id);
                Assert.Equal(season.Id, fromDb.Id);
                Assert.Equal(season.Name, fromDb.Name);
                Assert.Equal(season.Teams, fromDb.Teams);
            }
        }

        [Fact]
        public async Task TestUserTeamCreation()
        {
            var userTeam = new UserTeam
            {
                Name = "TestTeam",
                UserId = 3,
                User = new User 
                {
                    Identifier = "Test123",
                    EMail = "fresse"
                },
                SeasonId = 1,
                Season = new Season
                {
                    Name = "TestSeason"
                }
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
                // Assert.Equal(userTeam.User, fromDb.User);
                Assert.Equal(userTeam.SeasonId, fromDb.SeasonId);
                // Assert.Equal(userTeam.Season, fromDb.Season);
            }
        }
    }
}

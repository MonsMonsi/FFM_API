using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FFMWebCore.Data.Tests
{
    public class FootballContextFixture : IAsyncLifetime
    {
        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task InitializeAsync()
        {
            await CleanDatabase();
        }

        static async Task CleanDatabase()
        {
            using var context = new FootballContext();
            context.Users.RemoveRange(context.Users);
            context.Seasons.RemoveRange(context.Seasons);
            await context.SaveChangesAsync();
        }
    }
}

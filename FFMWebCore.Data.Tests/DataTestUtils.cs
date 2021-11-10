using System;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace FFMWebCore.Data.Tests
{
    public static class DataTestUtils
    {
        public static FootballContext CreateFootballContext()
        {
            var connectionString = "Server=localhost\\sqlexpress;Database=FFM_WEB_TEST;Trusted_Connection=True;";

            return new FootballContext(connectionString);
        }
    }
}

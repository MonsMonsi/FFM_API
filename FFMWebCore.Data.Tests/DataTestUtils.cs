using System;
using System.IO;
using System.Text.Json;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace FFMWebCore.Data.Tests
{
    public static class DataTestUtils
    {
        public static FootballContext CreateFootballContext()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "TestConfig.json");
            var connectionString = JsonSerializer.Deserialize<TestConfig>(File.ReadAllText(path))
                .ConnectionString;

            return new FootballContext(connectionString);
        }
    }
}

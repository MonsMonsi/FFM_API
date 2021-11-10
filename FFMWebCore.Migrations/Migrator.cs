using FluentMigrator.Infrastructure;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace FFMWebCore.Migrations
{
    public class Migrator
    {
        private readonly string _connectionString;

        public Migrator(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Applies all migrations.
        /// </summary>
        public void Migrate()
        {
            var services = CreateServices();
            using (var scope = services.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        /// <summary>
        /// Removes a migration.
        /// </summary>
        /// <param name="migrationId">The ID of the migration to remove.</param>
        public void MigrateDown(long migrationId)
        {
            var services = CreateServices();
            using (var scope = services.CreateScope())
            {
                DowngradeDatabase(scope.ServiceProvider, migrationId);
            }
        }

        /// <summary>
        /// Loads applied migrations from the database.
        /// </summary>
        /// <returns>A list of migration infos.</returns>
        public SortedList<long, IMigrationInfo> LoadMigrations()
        {
            var services = CreateServices();
            using (var scope = services.CreateScope())
            {
                return LoadMigrations(scope.ServiceProvider);
            }
        }

        private IServiceProvider CreateServices()
        {
            return new ServiceCollection().AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(_connectionString)
                    .ScanIn(typeof(Migrator).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

        private static void DowngradeDatabase(IServiceProvider serviceProvider, long migrationId)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateDown(migrationId);
        }

        private static SortedList<long, IMigrationInfo> LoadMigrations(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            return runner.MigrationLoader.LoadMigrations();
        }
    }
}

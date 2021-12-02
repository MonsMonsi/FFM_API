using System;

namespace FFMWebCore.Migrator
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=localhost\\sqlexpress;Database=FFM_WEB;Trusted_Connection=True;";
            var migrator = new Migrations.Migrator(connectionString);

            migrator.Migrate();

            Console.WriteLine("Done!");
        }
    }
}

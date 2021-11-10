using FFMWebCore.Migrations.Properties;
using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFMWebCore.Migrations.Migrations
{
    [Migration(1)]
    public class InitialMigration : Migration
    {
        public override void Down()
        {
        }

        public override void Up()
        {
            Execute.Sql(Resources._001_up);
        }
    }
}

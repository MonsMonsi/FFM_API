using FFMWebCore.Migrations.Properties;
using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFMWebCore.Migrations.Migrations
{
    [Migration(3)]
    public class AddingTeamsLeagues: Migration
    {
        public override void Down()
        {
        }

        public override void Up()
        {
            Execute.Sql(Resources._003_up);
        }
    }
}

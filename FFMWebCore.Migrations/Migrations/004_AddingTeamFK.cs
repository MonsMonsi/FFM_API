using FFMWebCore.Migrations.Properties;
using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFMWebCore.Migrations.Migrations
{
    [Migration(4)]
    public class AddingTeamFK:Migration
    {
        public override void Down()
        {
        }

        public override void Up()
        {
            Execute.Sql(Resources._004_up);
        }
    }
}

using System;
using FluentMigrator;

namespace Geshotel.Migrations.GeshotelDB
{
    [Migration(20170123163900)]
    public class GeshotelDB_20170123_163900_Inital : Migration
    {
        public override void Up()
        {
            Create.Schema("Geshotel");
            IfDatabase("MySql")
               .Execute.EmbeddedScript("Geshotel.Modules.Common.Migrations.GeshotelDB.GeshotelDB_20170123_163900_Initial_Mysql.sql");
            IfDatabase("SqlServer", "SqlServer2000", "SqlServerCe")
                .Execute.EmbeddedScript("Geshotel.Modules.Common.Migrations.GeshotelDB.GeshotelDB_20170123_163900_Initial_SQL_Server.sql");
        }
        public override void Down()
        {
        }

    }
}
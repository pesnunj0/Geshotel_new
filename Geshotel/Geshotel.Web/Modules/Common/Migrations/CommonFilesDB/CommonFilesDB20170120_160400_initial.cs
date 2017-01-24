using FluentMigrator;

namespace Geshotel.Migrations.CommonFilesDB
{              
    [Migration(20170120160000)]
    public class CommonFilesDB20170120_160400_Initial : Migration
    {

        public override void Up()
        {
            Create.Schema("commonfiles");
            IfDatabase("MySql")
                .Execute.EmbeddedScript("Geshotel.Modules.Common.Migrations.CommonFilesDB.CommonFilesDB_Initial_Script_MySql.sql");
            IfDatabase("SqlServer", "SqlServer2000", "SqlServerCe")
                .Execute.EmbeddedScript("Geshotel.Modules.Common.Migrations.CommonFilesDB.CommonFilesDB_Initial_Script_SQL_Server.sql");
            IfDatabase("Postgres")
                .Execute.EmbeddedScript("Geshotel.Modules.Common.Migrations.CommonFilesDB.CommonFilesDB_Initial_Script_PostgreSQL.sql");
        }
        public override void Down()
        {
        }
    }
}



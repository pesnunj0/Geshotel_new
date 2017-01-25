using System;
using FluentMigrator;

namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170118182000)]
    public class DefaultDB_20170118_182000_Usercompany : Migration
    {
 
        public override void Up()
        {

            Alter.Table("users")
                .AddColumn("EmpresaId").AsInt16().Nullable()
                .AddColumn("HotelId").AsInt16().Nullable();
            // Creamos el indice
            Create.Index().OnTable("users").OnColumn("EmpresaId");
            Create.Index().OnTable("users").OnColumn("HotelId");
            // Creamos la Foreign Key
            //Create.ForeignKey().FromTable("users").ForeignColumn("EmpresaId")
            //    .ToTable("empresas").InSchema("commonfiles").PrimaryColumn("empresa_id");

            // Foreign Keys related to another schema must be done with script
            // I Tried it but Inschema seems not working in FluentMigrator
            // Javier January 2017
            Update.Table("Users").Set(new { EmpresaID = "1" }).AllRows();
            Update.Table("Users").Set(new { HotelID = "1" }).AllRows();
            //IfDatabase("MySql")
            //    .Execute.EmbeddedScript("Geshotel.Modules.Common.Migrations.DefaultDB.DefaultDB_20170118_182700_FK_Mysql.sql");
            //IfDatabase("SqlServer", "SqlServer2000", "SqlServerCe")
            //    .Execute.EmbeddedScript("Geshotel.Modules.Common.Migrations.DefaultDB.DefaultDB_20170118_182700_FK_SQL_Server.sql");

        }
        public override void Down()
        {
            
        }

    }
}
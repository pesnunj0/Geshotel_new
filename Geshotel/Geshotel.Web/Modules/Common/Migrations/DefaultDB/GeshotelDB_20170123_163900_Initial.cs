using System;
using FluentMigrator;

namespace Geshotel.Migrations.GeshotelDB
{
    [Migration(20170123163900)]
    public class GeshotelDB_20170123_163900_Inital : Migration
    {
        public override void Up()
        {

            IfDatabase("MySql")
               .Execute.EmbeddedScript("Geshotel.Modules.Common.Migrations.GeshotelDB.GeshotelDB_20170123_163900_Initial_Mysql.sql");
            IfDatabase("SqlServer", "SqlServer2000", "SqlServerCe")
                .Execute.EmbeddedScript("Geshotel.Modules.Common.Migrations.GeshotelDB.GeshotelDB_20170123_163900_Initial_SQL_Server.sql");

            Create.Table("tipos_habitacion_hotel")
                  .WithColumn("hotel_id").AsInt16().PrimaryKey().NotNullable()
                  .WithColumn("tipo_habitacion_id").AsInt16().PrimaryKey().NotNullable()
                  .WithColumn("servicio_id").AsInt16().NotNullable();
            Create.Table("cupos")
                .WithColumn("cupo_id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("cliente_id").AsInt32().NotNullable()
                .WithColumn("hotel_id").AsInt16().NotNullable()
                .WithColumn("fecha_desde").AsDate().NotNullable().WithDefaultValue("2000-01-01")
                .WithColumn("fecha_hasta").AsDate().NotNullable().WithDefaultValue("2100-01-01")
                .WithColumn("tipo_habitacion_id").AsInt16().NotNullable()
                .WithColumn("garantia").AsDecimal(5, 2).NotNullable().WithDefaultValue("0.00").WithDescription("Porcentaje de ocupación garantizado por el TTOO")
                .WithColumn("reserva_automatica").AsBinary().NotNullable().WithDefaultValue("0")
                .WithColumn("user_id").AsInt16()
                .WithColumn("fecha_modificacion").AsDateTime();

        }
        public override void Down()
        {
        }

    }
}
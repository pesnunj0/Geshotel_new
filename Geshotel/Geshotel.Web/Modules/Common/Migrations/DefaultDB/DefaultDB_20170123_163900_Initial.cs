using System;
using FluentMigrator;

namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170123163900)]
    public class DefaultDB_20170123_163900_Inital : Migration
    {
        public override void Up()
        {

            IfDatabase("MySql")
               .Execute.EmbeddedScript("Geshotel.Modules.Common.Migrations.GeshotelDB.GeshotelDB_20170123_163900_Initial_Mysql.sql");
            IfDatabase("SqlServer", "SqlServer2000", "SqlServerCe")
                .Execute.EmbeddedScript("Geshotel.Modules.Common.Migrations.GeshotelDB.GeshotelDB_20170123_163900_Initial_SQL_Server.sql");

            Create.Table("tipos_habitacion_hotel")
                .WithColumn("tipo_habitacion_hotel_id").AsInt32().Identity().PrimaryKey().NotNullable()
                   .WithColumn("hotel_id").AsInt16().NotNullable()
                   .ForeignKey("FK_tipos_habitacion_hotel_hotel_id", "hoteles", "hotel_id")
                   .WithColumn("tipo_habitacion_id").AsInt16().NotNullable()
                   .ForeignKey("FK_tipos_habitacion_tipo_habitacion_id", "tipos_habitacion", "tipo_habitacion_id")
                   .WithColumn("servicio_id").AsInt32().NotNullable()
                    .ForeignKey("FK_tipos_habitacion_servicio_id", "servicios", "servicio_id");
            Create.Index("IX_tipo_habitacion_hotel")
                    .OnTable("tipos_habitacion_hotel")
                    .OnColumn("tipo_habitacion_id").Ascending()
                    .OnColumn("hotel_id").Ascending()
                    .WithOptions().Unique();

            Create.Table("cupos")
                .WithColumn("cupo_id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("cliente_id").AsInt32().NotNullable()
                .ForeignKey("FK_cupos_cliente_id", "clientes", "cliente_id")
                .WithColumn("hotel_id").AsInt16().NotNullable()
                .ForeignKey("FK_cupos_hotel_id", "hoteles", "hotel_id")
                .WithColumn("fecha_desde").AsDate().NotNullable()
                .WithColumn("fecha_hasta").AsDate().NotNullable()
                .WithColumn("tipo_habitacion_id").AsInt16().NotNullable()
                .ForeignKey("FK_cupos_tipo_habitacion_id", "tipos_habitacion", "tipo_habitacion_id")
                .WithColumn("garantia").AsDecimal(5, 2).NotNullable().WithDefaultValue("0.00")
                .WithColumn("cupo").AsInt16().NotNullable()
                .WithColumn("reserva_automatica").AsBinary(1).NotNullable()
                .WithColumn("user_id").AsInt32().Nullable()
                .WithColumn("fecha_modificacion").AsDateTime().Nullable();                
        }
        public override void Down()
        {
        }

    }
}
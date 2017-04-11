using System;
using FluentMigrator;
// ************************************************************************************************
// Creacion de los ficheros siguientes:
// - cierres
// - Cambiamos estado_reserva_id a 1 en las reservas de la 10 a la 14
// ************************************************************************************************
namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170405224500)]
    public class DefaultDB_20170405_224500_Cierres : Migration
    { 
        public override void Up()
        {
            Create.Table("cierres")
                .WithColumn("cierre_id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("hotel_id").AsInt16().NotNullable()
                .WithColumn("fecha_cierre").AsDate().NotNullable()
                .WithColumn("fecha_cierre_tpv").AsDateTime().Nullable()
                .WithColumn("fecha_contabilizacion").AsDateTime().Nullable()
                .WithColumn("fichero_cierre").AsString(512).Nullable()
                .WithColumn("fichero_policia").AsString(512).Nullable()
                .WithColumn("postcierre").AsBoolean().Nullable().WithDefaultValue(0)
                .WithColumn("user_id").AsInt32().Nullable()
                .WithColumn("fecha_modificacion").AsDateTime().Nullable();



            Create.Index("IX_cierre_hotel_fecha")
                .OnTable("cierres")
                .OnColumn("hotel_id").Ascending()
                .OnColumn("fecha_cierre").Ascending()
                .WithOptions().Unique();

            Insert.IntoTable("cierres").Row(new
            {
                hotel_id = "1",
                fecha_cierre = new DateTime(2017, 3, 31),
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });

            Insert.IntoTable("cierres").Row(new
            {
                hotel_id = "2",
                fecha_cierre = new DateTime(2017, 3, 31),
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });
            Insert.IntoTable("cierres").Row(new
            {
                hotel_id = "3",
                fecha_cierre = new DateTime(2017, 4, 1),
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });
            Insert.IntoTable("cierres").Row(new
            {
                hotel_id = "4",
                fecha_cierre = new DateTime(2017, 4, 2),
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });

            for (int i = 10; i < 15; i++)
            {
                Update.Table("reservas").Set(new
                {
                    estado_reserva_id = 1
                }).Where(new { reserva_id = i });
            }

        }

        public override void Down()
        {
        }

    }
}
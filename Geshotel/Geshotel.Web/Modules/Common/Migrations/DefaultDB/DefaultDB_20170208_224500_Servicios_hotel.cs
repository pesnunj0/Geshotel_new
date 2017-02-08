using System;
using FluentMigrator;

namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170208224500)]
    public class DefaultDB_20170208_224500_Servicios_hotel : Migration
    {
        public override void Up()
        {
            Create.Table("servicios_hotel")
                .WithColumn("servicio_id").AsInt32().NotNullable()
                .ForeignKey("", "servicios", "servicio_id")
                .WithColumn("hotel_id").AsInt16().PrimaryKey().NotNullable()
                .ForeignKey("", "hoteles", "hotel_id")
                .WithColumn("impuesto_id").AsInt16()
                .ForeignKey("", "impuestos", "impuesto_id")
                .WithColumn("costo").AsFloat().Nullable()
                .WithColumn("cta_contable").AsString(16)
                .WithColumn("dpto_contable").AsString(10)
                .WithColumn("permite_credito").AsBoolean();
        }

        public override void Down()
        {
        }

    }
}
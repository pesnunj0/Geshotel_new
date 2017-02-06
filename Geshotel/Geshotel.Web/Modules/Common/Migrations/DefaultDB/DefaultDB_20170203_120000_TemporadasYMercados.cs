using System;
using FluentMigrator;

namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170203120000)]
    public class DefaultDB_20170203_120000_TemporadasYMercados : Migration
    {
        public override void Up()
        {

            Create.Table("temporadas")
                .WithColumn("temporada_id").AsInt16().NotNullable().PrimaryKey().Identity()
                .WithColumn("temporada").AsString(25).NotNullable()
                .WithColumn("hotel_id").AsInt16().NotNullable()
                .ForeignKey("FK_temporadas_hoteles_hotel_id", "hoteles", "hotel_id")
                .WithColumn("ano").AsInt16().Nullable()
                .WithColumn("fecha_desde").AsDate()
                .WithColumn("fecha_hasta").AsDate();

            Create.Index("IX_tempradas_hotel_id")
                .OnTable("temporadas")
                .OnColumn("hotel_id").Ascending();

            Create.Table("mercados")
                .WithColumn("mercado_id").AsInt16().NotNullable().PrimaryKey().Identity()
                .WithColumn("mercado").AsString(25)
                .WithColumn("hotel_id").AsInt16().NotNullable().PrimaryKey()
                .ForeignKey("FK_mercados_hoteles_hotel_id", "hoteles", "hotel_id");

            Create.Index("IX_mercados_hotel_id")
                .OnTable("mercados")
                .OnColumn("hotel_id").Ascending();
        }
        public override void Down()
        {
        }

    }
}
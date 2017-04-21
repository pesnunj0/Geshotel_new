using System;
using FluentMigrator;
// ************************************************************************************************
// Creacion de los ficheros siguientes:
// - PreviewServicios
// ************************************************************************************************
namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170420224500)]
    public class DefaultDB_20170420_224500_PreviewServicios : Migration
    { 
        public override void Up()
        {
            if (Schema.Table("preview_servicios").Exists())
                Delete.Table("preview_servicios");

            Create.Table("preview_servicios")
                .WithColumn("preview_servicios_id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("reserva_id").AsInt32().NotNullable()
                .WithColumn("fecha").AsDate().NotNullable()
                .WithColumn("servicio_id").AsInt32().NotNullable()
                .WithColumn("importe").AsDecimal(7, 2).Nullable()
                .WithColumn("descripcion").AsString(40).Nullable()
                .WithColumn("error").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("desc_oferta").AsString(20).Nullable()
                .WithColumn("desc_uc").AsString(20).Nullable()
                .WithColumn("desc_uc_reserva").AsString(20).Nullable()
                .WithColumn("cantidad").AsDecimal(5, 2).Nullable()
                .WithColumn("precio_producciom").AsDecimal(7, 2).Nullable();

            Create.Index("IX_preview_servicios")
                .OnTable("preview_servicios")
                .OnColumn("reserva_id").Ascending()
                .OnColumn("fecha").Ascending()
                .OnColumn("servicio_id").Ascending()
                .WithOptions().Unique();

            Create.Index("IX_reserva_id")
               .OnTable("preview_servicios")
               .OnColumn("reserva_id").Ascending();
            
        }

        public override void Down()
        {
        }

    }
}
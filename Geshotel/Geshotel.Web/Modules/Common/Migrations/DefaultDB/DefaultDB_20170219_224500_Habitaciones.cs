using System;
using FluentMigrator;

namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170219224500)]
    public class DefaultDB_20170219_224500_Habitaciones : Migration
    {
        public override void Up()
        {
            Create.Table("habitaciones_situacion")
                .WithColumn("situacion_id").AsInt16().Identity().PrimaryKey().NotNullable()
                .WithColumn("situacion").AsString().NotNullable();

            Insert.IntoTable("habitaciones_situacion").Row(new
            {
                Situacion = "Libre"
            });

            Insert.IntoTable("habitaciones_situacion").Row(new
            {
                Situacion = "Pendiente Salida"
            });

            Insert.IntoTable("habitaciones_situacion").Row(new
            {
                Situacion = "Pendiente Entrada"
            });

            Insert.IntoTable("habitaciones_situacion").Row(new
            {
                Situacion = "Ocupada"
            });

            Insert.IntoTable("habitaciones_situacion").Row(new
            {
                Situacion = "Bloqueada"
            });

            Create.Table("tipos_bloqueo")
                .WithColumn("tipo_bloqueo_id").AsInt16().Identity().PrimaryKey().NotNullable()
                .WithColumn("descriptivo").AsString(20).NotNullable()
                .WithColumn("editable").AsBoolean().WithDefaultValue(1);

            Insert.IntoTable("tipos_bloqueo").Row(new
            {
                descriptivo = "Reserva",
                editable = 0
            });

            Insert.IntoTable("tipos_bloqueo").Row(new
            {
                descriptivo = "Rotura",
                editable = 1
            });

            Insert.IntoTable("tipos_bloqueo").Row(new
            {
                descriptivo = "Limpieza",
                editable = 0
            });

            Insert.IntoTable("tipos_bloqueo").Row(new
            {
                descriptivo = "Obras",
                editable = 0
            });


            Create.Table("zonas_limpieza")
                .WithColumn("zona_limpieza_id").AsInt16().Identity().PrimaryKey().NotNullable()
                .WithColumn("hotel_id").AsInt16().NotNullable()
                .ForeignKey("FK_zonas_limpieza_hotel_id", "hoteles", "hotel_id")
                .WithColumn("nombre_zona").AsString(20);

            Create.Index("IX_zona_limpieza_hotel")
                .OnTable("zonas_limpieza")
                .OnColumn("hotel_id").Ascending();

            Create.Table("habitaciones")
                .WithColumn("habitacion_id").AsInt16().Identity().PrimaryKey().NotNullable()
                .WithColumn("hotel_id").AsInt16().NotNullable()
                .ForeignKey("FK_habitaciones_hotel_id", "hoteles", "hotel_id")
                .WithColumn("numero_habitacion").AsString(8).NotNullable()
                .WithColumn("tipo_habitacion_id").AsInt16().NotNullable()
                .ForeignKey("FK_habitaciones_tipo_habitacion_id", "tipos_habitacion", "tipo_habitacion_id")
                .WithColumn("extension").AsInt16()
                .WithColumn("observaciones").AsString(255)
                .WithColumn("situacion_id").AsInt16()
                .ForeignKey("FK_habitaciones_situacion", "habitaciones_situacion", "situacion_id")
                .WithColumn("fecha_inicio").AsDate()
                .WithColumn("estado_telefono").AsInt16()
                .WithColumn("estado_procesado").AsInt16()
                .WithColumn("habitacion_ista").AsString(20)
                .WithColumn("zona_limpieza_id").AsInt16()
                .ForeignKey("FK_zonas_limpieza", "zonas_limpieza", "zona_limpieza_id")
                .WithColumn("lat").AsDecimal(15,10)
                .WithColumn("lng").AsDecimal(15,10)
                .WithColumn("primary_image").AsString(100)
                .WithColumn("galleryimages").AsString(int.MaxValue)
                .WithColumn("planta").AsInt16()
                .WithColumn("user_id").AsInt32()
                .WithColumn("fecha_modificacion").AsDateTime();

            Create.Index("IX_hotel_id")
                .OnTable("habitaciones")
                .OnColumn("hotel_id").Ascending();

            Create.Index("IX_tipo_habitacion")
                .OnTable("habitaciones")
                .OnColumn("tipo_habitacion_id").Ascending();

            Create.Index("IX_situacion")
                .OnTable("habitaciones")
                .OnColumn("situacion_id").Ascending();

            Create.Index("IX_zona_limpieza")
                .OnTable("habitaciones")
                .OnColumn("zona_limpieza_id").Ascending();

            Create.Table("habitaciones_bloqueo")
                .WithColumn("habitacion_bloqueo_id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("habitacion_id").AsInt16().NotNullable()
                .ForeignKey("","habitaciones","habitacion_id").OnDeleteOrUpdate(System.Data.Rule.Cascade)
                .WithColumn("tipo_bloqueo_id").AsInt16().NotNullable()
                .WithColumn("fecha_desde").AsDate().NotNullable()
                .WithColumn("fecha_hasta").AsDate().NotNullable()
                .WithColumn("Observaciones").AsString(1000)
                .WithColumn("reserva_id").AsInt32()
                .WithColumn("user_id").AsInt32()
                .WithColumn("fecha_modificacion").AsDateTime();

            Create.Index("IX_habitacion_id")
                .OnTable("habitaciones_bloqueo")
                .OnColumn("habitacion_id").Ascending();
            Create.Index("IX_tipo_bloqueo")
                .OnTable("habitaciones_bloqueo")
                .OnColumn("tipo_bloqueo_id").Ascending();
        }

        public override void Down()
        {
        }

    }
}
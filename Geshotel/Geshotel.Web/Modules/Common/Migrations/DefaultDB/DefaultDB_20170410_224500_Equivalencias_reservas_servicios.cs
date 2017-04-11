using System;
using FluentMigrator;
// ************************************************************************************************
// Creacion de los ficheros siguientes:
// - cierres
// - Cambiamos estado_reserva_id a 1 en las reservas de la 10 a la 14
// ************************************************************************************************
namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170410224500)]
    public class DefaultDB_20170410_224500_Equivalencias_Reservas_Servicios : Migration
    { 
        public override void Up()
        {
            Create.Table("equivalencia_reservas_servicios")
                .WithColumn("reserva_servicio_id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("servicio_opcion_id").AsInt32().NotNullable()
                .WithColumn("servicio_id").AsInt32().NotNullable()
                .WithColumn("user_id").AsInt32().Nullable()
                .WithColumn("fecha_modificacion").AsDateTime().Nullable();

            Create.Index("IX_equivalencia_reservas_servicios")
                .OnTable("equivalencia_reservas_servicios")
                .OnColumn("servicio_opcion_id").Ascending()
                .OnColumn("servicio_id").Ascending()
                .WithOptions().Unique();

            Insert.IntoTable("equivalencia_reservas_servicios").Row(new
            {
                servicio_opcion_id = 10,
                servicio_id = 1,
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });
            Insert.IntoTable("equivalencia_reservas_servicios").Row(new
            {
                servicio_opcion_id = 11,
                servicio_id = 6,
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });
            Insert.IntoTable("equivalencia_reservas_servicios").Row(new
            {
                servicio_opcion_id = 55,
                servicio_id = 53,
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });
            Insert.IntoTable("equivalencia_reservas_servicios").Row(new
            {
                servicio_opcion_id = 56,
                servicio_id = 54,
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });
            Insert.IntoTable("equivalencia_reservas_servicios").Row(new
            {
                servicio_opcion_id = 96,
                servicio_id = 94,
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });
            Insert.IntoTable("equivalencia_reservas_servicios").Row(new
            {
                servicio_opcion_id = 97,
                servicio_id = 95,
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });
            Create.Table("unidades_calculo_agrupados")
                .WithColumn("unidad_calculo_padre_id").AsInt16().PrimaryKey().NotNullable()
                .WithColumn("unidad_calculo_hijo_id").AsInt16().PrimaryKey().NotNullable();

            Insert.IntoTable("unidades_calculo_agrupados").Row(new
            {                
                unidad_calculo_padre_id = 6,
                unidad_calculo_hijo_id = 2
            });
            Insert.IntoTable("unidades_calculo_agrupados").Row(new
            {        
                unidad_calculo_padre_id = 6,
                unidad_calculo_hijo_id = 3

            });
            Insert.IntoTable("unidades_calculo_agrupados").Row(new
            {             
                unidad_calculo_padre_id = 6,
                unidad_calculo_hijo_id = 4
            });
            Insert.IntoTable("unidades_calculo_agrupados").Row(new
            {               
                unidad_calculo_padre_id = 6,
                unidad_calculo_hijo_id = 5
            });
            Create.Table("condiciones_linea_contrato")
                .WithColumn("condiciones_linea_contrato_id").AsInt32().PrimaryKey().Identity()
                .WithColumn("linea_contrato_id").AsInt32().NotNullable()
                .WithColumn("unidad_calculo_id").AsInt16().NotNullable()
                .WithColumn("tipo_condicion_id").AsInt16().NotNullable()
                .WithColumn("cantidad").AsDecimal(5, 1).NotNullable();

            Create.Index("IX_condiciones_linea_contrato")
                .OnTable("condiciones_linea_contrato")
                .OnColumn("linea_contrato_id").Ascending()
                .OnColumn("unidad_calculo_id").Ascending()
                .OnColumn("tipo_condicion_id").Ascending()
                .WithOptions().Unique();

        }

        public override void Down()
        {
        }

    }
}
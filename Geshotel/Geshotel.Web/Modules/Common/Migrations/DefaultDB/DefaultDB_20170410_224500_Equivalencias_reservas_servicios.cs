using System;
using FluentMigrator;
// ************************************************************************************************
// Creacion de los ficheros siguientes:
// - equivalencias_reservas_servicios
// - unidades_calculo_agrupados. Importante para definir que A+N1+N2+B lo que tiene
// - ofertas_codigos
// - clientes_hotel
// ************************************************************************************************
namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170410224500)]
    public class DefaultDB_20170410_224500_Equivalencias_Reservas_Servicios : Migration
    { 
        public override void Up()
        {
            if (Schema.Table("equivalencia_reservas_servicios").Exists())
                Delete.Table("equivalencia_reservas_servicios");

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
            if (Schema.Table("unidades_calculo_agrupados").Exists())
                Delete.Table("unidades_calculo_agrupados");

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

            if (Schema.Table("condiciones_linea_contrato").Exists())
                Delete.Table("condiciones_linea_contrato");

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

            if (Schema.Table("ofertas_codigos").Exists())
                Delete.Table("ofertas_codigos");

            Create.Table("ofertas_codigos")
                .WithColumn("oferta_codigo_id").AsInt32().PrimaryKey().Identity()
                .WithColumn("oferta_id").AsInt32().NotNullable()
                .WithColumn("codigo_oferta").AsString(20).NotNullable();

            Create.Index("IX_ofertas_codigos_oferta_id")
                .OnTable("ofertas_codigos")
                .OnColumn("oferta_id").Ascending();

            Create.Index("IX_ofertas_codigos")
                .OnTable("ofertas_codigos")
                .OnColumn("oferta_id").Ascending()
                .OnColumn("codigo_oferta").Ascending()
                .WithOptions().Unique();

            if (Schema.Table("clientes_hotel").Exists())
                Delete.Table("clientes_hotel");

            Create.Table("clientes_hotel")
                .WithColumn("clientes_hotel_id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("cliente_id").AsInt32().NotNullable()
                .WithColumn("hotel_id").AsInt16().NotNullable()
                .WithColumn("cta_contable").AsString(15)
                .WithColumn("dpto_contable").AsString(5)
                .WithColumn("cta_anticipos").AsString(15)
                .WithColumn("dpto_anticipos").AsString(5)
                .WithColumn("cta_depositos").AsString(15)
                .WithColumn("cliente_bavel").AsString(20)
                .WithColumn("tipo_bavel").AsBoolean()
                .WithColumn("factura_anticipada").AsBoolean()
                .WithColumn("precio_dingus").AsBoolean()
                .WithColumn("impuestos_incluidos").AsBoolean().WithDefaultValue(1)
                .WithColumn("comision").AsDecimal(5, 2);

            Create.Index("IX_clientes_hotel")
                .OnTable("clientes_hotel")
                .OnColumn("cliente_id").Ascending()
                .OnColumn("hotel_id").Ascending()
                .WithOptions().Unique();

        }

        public override void Down()
        {
        }

    }
}
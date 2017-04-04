using System;
using FluentMigrator;
// ************************************************************************************************
// Creacion de los ficheros siguientes:
// - events : Guardaremos, entradas, salidas, habitaciones libres, habitaciones Ocupadas
// - contadores : contadores de numero de factura por empresa
// - cajas :
// - facturas :
// - lineas_factura :
// - tickets :
// - lineas_ticket :
// - movimientos_caja : 
// - anticipos :
// - lineas_anticipo :
// - tipos_movimiento_caja :
// - tipos_cobro
// - movimientos_caja :
// - cobros :
// - lineas_cobro :
// ************************************************************************************************
namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170405224500)]
    public class DefaultDB_20170404_224500_Events_movimientos_caja : Migration
    { 
        public override void Up()
        {
            Create.Table("events")
                .WithColumn("id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("name").AsString(25).NotNullable()
                .WithColumn("eventstart").AsDateTime().NotNullable()
                .WithColumn("eventend").AsDateTime().NotNullable();

            Create.Table("contadores")
                .WithColumn("contador_id").AsInt32().PrimaryKey().Identity()
                .WithColumn("empresa_id").AsInt16().NotNullable()
                .WithColumn("serie_id").AsInt16().NotNullable()
                .WithColumn("ano").AsInt16().NotNullable()
                .WithColumn("contador").AsInt32().NotNullable();

            Create.Index("IX_contadores_empresa")
                .OnTable("contadores")
                .OnColumn("empresa_id").Ascending()
                .OnColumn("serie_id").Ascending()
                .OnColumn("ano").Ascending()
                .WithOptions().Unique();

            Create.Table("cajas")
                .WithColumn("caja_id").AsInt32().PrimaryKey().Identity()
                .WithColumn("hotel_id").AsInt16().NotNullable()
                .WithColumn("nombre_caja").AsString(30).NotNullable()
                .WithColumn("desc_corta").AsString(6).NotNullable()
                .WithColumn("cierre_dia").AsBoolean().NotNullable()
                .WithColumn("cta_contable").AsString(16).Nullable()
                .WithColumn("dpto_contable").AsString(5).Nullable()
                .WithColumn("user_id").AsInt32().Nullable()
                .WithColumn("fecha_modificacion").AsDateTime();

            Create.Table("facturas")
                .WithColumn("factura_id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("numero_factura").AsInt32().NotNullable()
                .WithColumn("serie_id").AsInt16().NotNullable()
                .WithColumn("fecha_factura").AsDate().NotNullable()
                .WithColumn("hotel_id").AsInt16().NotNullable()
                .WithColumn("cliente_id").AsInt32().NotNullable()
                .WithColumn("forma_pago_id").AsInt16().Nullable()
                .WithColumn("direccion_factura").AsString(70).Nullable()
                .WithColumn("poblacion_factura").AsString(50).Nullable()
                .WithColumn("zip").AsString(10).Nullable()
                .WithColumn("provincia_id").AsInt16().Nullable()
                .WithColumn("fecha_vencimiento").AsDate().Nullable()
                .WithColumn("estado_factura_id").AsInt16().NotNullable()
                .WithColumn("ref_fra1").AsString(75).Nullable()
                .WithColumn("ref_fra2").AsString(75).Nullable()
                .WithColumn("id_factura_rectificada").AsInt32().Nullable()
                .WithColumn("motivo_rectificacion").AsString(75).Nullable()
                .WithColumn("user_id").AsInt32().Nullable()
                .WithColumn("fecha_modificacion").AsDateTime().Nullable();

            Create.Table("lineas_factura")
                .WithColumn("linea_factura_id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("hotel_id").AsInt16().NotNullable()
                .WithColumn("fecha").AsDate().NotNullable()
                .WithColumn("factura_id").AsInt32().Nullable()
                .WithColumn("reserva_id").AsInt32().Nullable()
                .WithColumn("contrato_id").AsInt32().Nullable()
                .WithColumn("descripcion").AsString(50).NotNullable()
                .WithColumn("cantidad").AsDecimal(5, 2).NotNullable()
                .WithColumn("precio").AsDecimal(15, 3).NotNullable()
                .WithColumn("impuesto_id").AsInt16().NotNullable()
                .WithColumn("porc_impuesto").AsDecimal(5, 2).NotNullable()
                .WithColumn("servicio_id").AsInt32().NotNullable()
                .WithColumn("unidad_calculo_id").AsInt16().NotNullable()
                .WithColumn("tipo_linea_factura").AsString(1).NotNullable()
                .WithColumn("precio_produccion").AsDecimal(15, 3).Nullable()
                .WithColumn("pag_factura").AsInt16().WithDefaultValue(1).NotNullable()
                .WithColumn("costo").AsDecimal(10, 2).Nullable()
                .WithColumn("user_id").AsInt32().Nullable()
                .WithColumn("fecha_modificacion").AsDateTime().Nullable()
                .WithColumn("sw_ajuste").AsBoolean().WithDefaultValue(0).NotNullable();

            Create.Table("tickets")
                .WithColumn("ticket_id").AsInt32().PrimaryKey().Identity()
                .WithColumn("serie_id").AsInt16().NotNullable()
                .WithColumn("cliente_id").AsInt32().NotNullable()
                .WithColumn("hotel_id").AsInt16().NotNullable()
                .WithColumn("fecha").AsDate().NotNullable()
                .WithColumn("cliente_id_contrato").AsInt32().Nullable()
                .WithColumn("reserva_id").AsInt32().Nullable()
                .WithColumn("fecha_contabilizacion").AsDateTime().Nullable()
                .WithColumn("caja_id").AsInt16().Nullable()
                .WithColumn("forma_pago_id").AsInt16().Nullable()
                .WithColumn("factura_id").AsInt32().Nullable()
                .WithColumn("estado_ticket_id").AsInt16().WithDefaultValue(0).NotNullable();

            Create.Table("lineas_ticket")
                .WithColumn("linea_ticket_id").AsInt32().PrimaryKey().Identity()
                .WithColumn("tikect_id").AsInt32().NotNullable()
                .WithColumn("servicio_id").AsInt16().NotNullable()
                .WithColumn("unidad_calculo_id").AsInt16().NotNullable()
                .WithColumn("cantidad").AsDecimal(6, 2).NotNullable()
                .WithColumn("contrato_id").AsInt32().Nullable()
                .WithColumn("descripcion").AsString(50).Nullable()
                .WithColumn("precio").AsDecimal(15, 2).Nullable()
                .WithColumn("impuesto_id").AsInt16().Nullable()
                .WithColumn("porc_impuesto").AsDecimal(5, 2).Nullable()
                .WithColumn("user_id").AsInt32().Nullable()
                .WithColumn("fecha_modificacion").AsDateTime().Nullable();

            Create.Table("tipos_movimiento_caja")
                .WithColumn("tipo_movimiento_id").AsInt16().PrimaryKey().Identity()
                .WithColumn("descripcion").AsString(50).NotNullable()
                .WithColumn("signo").AsInt16().NotNullable()
                .WithColumn("produccion").AsBoolean().WithDefaultValue(1).NotNullable();

            Insert.IntoTable("tipos_movimiento_caja").Row(new
            {
                descripcion = "Cobro",
                signo = 1,
                produccion =1
            });
            Insert.IntoTable("tipos_movimiento_caja").Row(new
            {
                descripcion = "Devolución",
                signo = -1,
                produccion = 1
            });
            Insert.IntoTable("tipos_movimiento_caja").Row(new
            {
                descripcion = "Dotación de Fondos",
                signo = 1,
                produccion = 1
            });
            Insert.IntoTable("tipos_movimiento_caja").Row(new
            {
                descripcion = "Retirada de Fondos",
                signo = -1,
                produccion = 1
            });
            Insert.IntoTable("tipos_movimiento_caja").Row(new
            {
                descripcion = "Anticipo",
                signo = 1,
                produccion = 1
            });
            Insert.IntoTable("tipos_movimiento_caja").Row(new
            {
                descripcion = "Faltante de Caja",
                signo = -1,
                produccion = 1
            });
            Insert.IntoTable("tipos_movimiento_caja").Row(new
            {
                descripcion = "Sobrante de Caja",
                signo = 1,
                produccion = 1
            });
            Insert.IntoTable("tipos_movimiento_caja").Row(new
            {
                descripcion = "Deposito",
                signo = 1,
                produccion = 1
            });
            Insert.IntoTable("tipos_movimiento_caja").Row(new
            {
                descripcion = "Devolucion Deposito",
                signo = -1,
                produccion = 1
            });
            Insert.IntoTable("tipos_movimiento_caja").Row(new
            {
                descripcion = "Gastos",
                signo = 1,
                produccion = 1
            });
            Insert.IntoTable("tipos_movimiento_caja").Row(new
            {
                descripcion = "Devolucion Anticipo",
                signo = 1,
                produccion = 1
            });

            Create.Table("movimientos_caja")
                .WithColumn("movimiento_id").AsInt32().PrimaryKey().Identity()
                .WithColumn("tipo_movimiento_id").AsInt16().NotNullable()
                .WithColumn("fecha").AsDateTime().NotNullable()
                .WithColumn("caja_id").AsInt16().NotNullable()
                .WithColumn("descripcion").AsString(30).Nullable()
                .WithColumn("importe").AsDecimal(12, 2).NotNullable()
                .WithColumn("item_id").AsInt32().Nullable()
                .WithColumn("forma_pago_id").AsInt16().Nullable()
                .WithColumn("user_id").AsInt32().Nullable()
                .WithColumn("fecha_modificacion").AsDateTime().Nullable();

            Create.Table("anticipos")
                .WithColumn("anticipo_id").AsInt32().Identity().PrimaryKey()
                .WithColumn("hotel_id").AsInt16().NotNullable()
                .WithColumn("fecha").AsDate().NotNullable()
                .WithColumn("tipo_anticipo_id").AsInt16().NotNullable()
                .WithColumn("reserva_id").AsInt32().Nullable()
                .WithColumn("cliente_id").AsInt32().NotNullable()
                .WithColumn("caja_id").AsInt16().NotNullable()
                .WithColumn("importe").AsDecimal(15, 2).NotNullable()
                .WithColumn("forma_pago_id").AsInt16().NotNullable()
                .WithColumn("user_id").AsInt32().Nullable()
                .WithColumn("fecha_modificacion").AsDateTime().Nullable();

            Create.Table("lineas_anticipo")
                .WithColumn("linea_anticipo_id").AsInt32().PrimaryKey().Identity()
                .WithColumn("anticipo_id").AsInt32().NotNullable()
                .WithColumn("factura_id").AsInt32().Nullable()
                .WithColumn("importe").AsDecimal(12, 2).NotNullable()
                .WithColumn("fecha_contabilizacion").AsDateTime().Nullable()
                .WithColumn("estado").AsInt16().WithDefaultValue(0).Nullable()
                .WithColumn("user_id").AsInt32().Nullable()
                .WithColumn("fecha_modificacion").AsDateTime().Nullable();

            Create.Table("cobros")
                .WithColumn("cobro_id").AsInt32().Identity().PrimaryKey()
                .WithColumn("tipo_cobro_id").AsInt16().NotNullable()
                .WithColumn("fecha").AsDate().NotNullable()
                .WithColumn("hotel_id").AsInt16().NotNullable()
                .WithColumn("caja_id").AsInt16().NotNullable()
                .WithColumn("forma_pago_id").AsInt16().NotNullable()
                .WithColumn("cta_bancaria_id").AsInt16().Nullable()
                .WithColumn("fecha_contabilizacion").AsDateTime().Nullable()
                .WithColumn("observaciones").AsString(400).Nullable()
                .WithColumn("estado_cobro_id").AsInt16().WithDefaultValue(0)
                .WithColumn("user_id").AsInt32().Nullable()
                .WithColumn("fecha_modificacion").AsDateTime().Nullable();

            // *****************************
            // Incompletos por aqui abajo
            // *****************************

            Create.Table("lineas_cobro")
                .WithColumn("linea_cobro_id").AsInt32().PrimaryKey().Identity()
                .WithColumn("cobro_id").AsInt32().NotNullable()
                .WithColumn("factura_id").AsInt32().Nullable()
                .WithColumn("importe").AsDecimal(12, 2).NotNullable();


            Create.Table("tipos_cobro")
                .WithColumn("tipo_cobro_id").AsInt16().PrimaryKey().Identity()
                .WithColumn("descripcion").AsString(20).NotNullable()
                .WithColumn("signo").AsInt16().NotNullable()
                .WithColumn("tipo_movimiento_id").AsInt16().NotNullable()
                .WithColumn("cobro").AsBoolean().WithDefaultValue(1);


            Insert.IntoTable("tipos_cobro").Row(new
            {
                descripcion = "Cobro",
                signo = 1,
                tipo_movimiento_id = 1,
                cobro = 1
            });

            Insert.IntoTable("tipos_cobro").Row(new
            {
                descripcion = "Devolucion",
                signo = -1,
                tipo_movimiento_id = 2,
                cobro = 1
            });
            Insert.IntoTable("tipos_cobro").Row(new
            {
                descripcion = "Depósito",
                signo = 1,
                tipo_movimiento_id = 8,
                cobro = 0
            });
            Insert.IntoTable("tipos_cobro").Row(new
            {
                descripcion = "Devol. Depósito",
                signo = -1,
                tipo_movimiento_id = 9,
                cobro = 0
            });
            Insert.IntoTable("tipos_cobro").Row(new
            {
                descripcion = "Anticipo",
                signo = 1,
                tipo_movimiento_id = 5,
                cobro = 1
            });

            Alter.Table("series")
                .AddColumn("empresa_id").AsInt16().Nullable()
                .AddColumn("user_id").AsInt32().Nullable()
                .AddColumn("fecha_modificacion").AsDateTime().Nullable();

        }

        public override void Down()
        {
        }

    }
}
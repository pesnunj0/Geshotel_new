using System;
using FluentMigrator;

namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170203224500)]
    public class DefaultDB_20170203_224500_ReservaAutomatica : Migration
    {
        public override void Up()
        {
            Alter.Table("cupos")
                .AlterColumn("reserva_automatica").AsBoolean().NotNullable();

            Insert.IntoTable("clientes").Row(new
            {
                razon = "Clientes Directos",
                desc_corta ="DIR",
                empresa_id = 1,
                grupo_cliente_id = 1,
                tipo_documento_id = "C",
                nif = "99999999",
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });

            Insert.IntoTable("clientes").Row(new
            {
                razon = "Clientes Extra Contado",
                desc_corta = "EXTRA",
                empresa_id = 1,
                grupo_cliente_id = 2,
                agencia_id = 1,
                tipo_documento_id = "C",
                nif = "99999999",
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });

            Insert.IntoTable("contratos").Row(new
            {
                hotel_id = 1,
                fecha_contrato = DateTime.Today,
                cliente_id = 2,
                fecha_desde = DateTime.Today,
                fecha_hasta = DateTime.Parse("2017-12-31"),
                impuesto_incluido = 1,
                numero_contrato_cliente = "123456-99",
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });

            Insert.IntoTable("cupos").Row(new
            {
                hotel_id = 1,
                cliente_id = 2,
                fecha_desde = DateTime.Today,
                fecha_hasta = DateTime.Parse("2017-12-31"),
                tipo_habitacion_id = 21,
                garantia = 0,
                cupo = 10,
                reserva_automatica = 0,
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });

            Insert.IntoTable("lineas_de_contrato").Row(new
            {
                contrato_id = 1,
                servicio_id = 1,
                desde = DateTime.Today,
                hasta = DateTime.Parse("2017-12-31"),
                unidad_calculo_id = 6,
                frecuencia_id = 2,
                tipo_imputacion_id = 4,
                importe = Convert.ToDecimal("24,75"),
                lunes = 1,
                martes = 1,
                miercoles = 1,
                jueves = 1,
                viernes = 1,
                sabado = 1,
                domingo = 1,
                pag_factura = 1,
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });

            Insert.IntoTable("lineas_de_contrato").Row(new
            {
                contrato_id = 1,
                servicio_id = 10,
                desde = DateTime.Today,
                hasta = DateTime.Parse("2017-12-31"),
                unidad_calculo_id = 1,
                frecuencia_id = 2,
                tipo_imputacion_id = 4,
                importe = 0,
                lunes = 1,
                martes = 1,
                miercoles = 1,
                jueves = 1,
                viernes = 1,
                sabado = 1,
                domingo = 1,
                pag_factura = 1,
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });
            Insert.IntoTable("lineas_de_contrato").Row(new
            {
                contrato_id = 2,
                servicio_id = 125,
                desde = DateTime.Today,
                hasta = DateTime.Parse("2017-12-31"),
                unidad_calculo_id = 6,
                frecuencia_id = 2,
                tipo_imputacion_id = 4,
                importe = Convert.ToDecimal("50"),
                lunes = 1,
                martes = 1,
                miercoles = 1,
                jueves = 1,
                viernes = 1,
                sabado = 1,
                domingo = 1,
                pag_factura = 1,
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });
            Insert.IntoTable("lineas_de_contrato").Row(new
            {
                contrato_id = 2,
                servicio_id = 1,
                desde = DateTime.Today,
                hasta = DateTime.Parse("2017-12-31"),
                unidad_calculo_id = 6,
                frecuencia_id = 2,
                tipo_imputacion_id = 4,
                importe = 25,
                lunes = 1,
                martes = 1,
                miercoles = 1,
                jueves = 1,
                viernes = 1,
                sabado = 1,
                domingo = 1,
                pag_factura = 1,
                user_id = 1,
                fecha_modificacion = DateTime.Now
            });
        }

        public override void Down()
        {
        }

    }
}
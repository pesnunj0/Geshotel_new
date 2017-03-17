using System;
using FluentMigrator;

namespace Geshotel.Migrations.DefaultDB
{
    [Migration(20170220224500)]
    public class DefaultDB_20170220_224500_Reservas : Migration
    {
        public override void Up()
        {
            Create.Table("canales_reserva")
                .WithColumn("canal_reserva_id").AsInt16().Identity().PrimaryKey().NotNullable()
                .WithColumn("empresa_id").AsInt16().NotNullable()
                .ForeignKey("FK_canales_reserva_empresa_id", "empresas","empresa_id")
                .WithColumn("nombre_canal").AsString(40).NotNullable();

            Create.Table("reservas")
                .WithColumn("reserva_id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("fecha_creacion").AsDateTime().WithDefault(SystemMethods.CurrentDateTime)
                .WithColumn("hotel_id").AsInt16().NotNullable()
                .ForeignKey("FK_reservas_hotel_id", "hoteles", "hotel_id")
                .WithColumn("estado_reserva_id").AsInt16().NotNullable()
                .ForeignKey("FK_reservas_estado_reserva_id", "reserva_estados", "estado_reserva_id")
                .WithColumn("cliente_id").AsInt32().NotNullable()
                .ForeignKey("FK_reservas_cliente_id", "clientes", "cliente_id")
                .WithColumn("canal_reserva_id").AsInt16().Nullable()
                .ForeignKey("FK_reservas_canal_reserva_id", "canales_reserva","canal_reserva_id")
                .WithColumn("cliente_id_factura").AsInt32().Nullable()
                .ForeignKey("FK_reservas_cliente_id_factura", "clientes", "cliente_id")
                .WithColumn("tipo_habitacion_id").AsInt16().NotNullable()
                .WithColumn("pension_id").AsInt16().NotNullable()
                .WithColumn("adultos").AsInt16().NotNullable()
                .WithColumn("child_50").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("child_free").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("bebes").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("fecha_reserva").AsDate().NotNullable()
                .WithColumn("nombre_reserva").AsString(100).NotNullable()
                .WithColumn("fecha_prevista_llegada").AsDateTime().NotNullable()
                .WithColumn("fecha_prevista_salida").AsDateTime().NotNullable()
                .WithColumn("observaciones_llegada").AsString(1000).Nullable()
                .WithColumn("observaciones_salida").AsString(1000).Nullable()
                .WithColumn("observaciones_cliente").AsString(1000).Nullable()
                .WithColumn("observaciones").AsString(1000).Nullable()
                .WithColumn("fecha_llegada").AsDate().Nullable()
                .WithColumn("fecha_salida").AsDate().Nullable()
                .WithColumn("bono_referencia").AsString(40).NotNullable()
                .WithColumn("bono_online").AsString(40).Nullable()
                .WithColumn("bloquear_tarifa").AsBoolean().NotNullable().WithDefaultValue(0)
                .WithColumn("permite_devolucion").AsBoolean().NotNullable().WithDefaultValue(0)
                .WithColumn("tipo_tarjeta_id").AsInt16().Nullable()
                .WithColumn("tarjeta_credito").AsString().Nullable()
                .WithColumn("caducidad").AsString(10).Nullable()
                .WithColumn("cod_seguridad").AsString(4).Nullable()
                .WithColumn("contrato_ttoo").AsString(30).Nullable()
                .WithColumn("codigo_oferta").AsString(30).Nullable()
                .WithColumn("valor").AsDecimal(10,2).Nullable()
                .WithColumn("valor_validado").AsDecimal(10,2).Nullable()
                .WithColumn("fecha_validacion").AsDateTime().Nullable()
                .WithColumn("usuario_validacion").AsInt32().Nullable()
                .WithColumn("paroventas_check").AsBoolean().Nullable()
                .WithColumn("cupos_check").AsBoolean().Nullable()
                .WithColumn("release_check").AsBoolean().Nullable()
                .WithColumn("reserva_dingus").AsString(Int32.MaxValue).Nullable()
                .WithColumn("dingus_impuestos_incluidos").AsBoolean().Nullable()
                .WithColumn("dingus_comision").AsInt16().Nullable()
                .WithColumn("reserva_dingus_tipo").AsInt16().Nullable()
                .WithColumn("fecha_anulacion").AsDateTime().Nullable()
                .WithColumn("user_id").AsInt32().Nullable()
                .ForeignKey("FK_reservas_user_id", "users", "UserId")
                .WithColumn("fecha_modificacion").AsDateTime().Nullable();


            Create.Table("reservas_servicios")
                .WithColumn("servicio_reserva_id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("reserva_id").AsInt32().NotNullable()
                .ForeignKey("FX_reservas_servicios_reserva_id", "reservas","reserva_id")
                .WithColumn("servicio_id").AsInt32().NotNullable()
                .ForeignKey("FX_reservas_servicios_servicio_id", "servicios","servicio_id")
                .WithColumn("unidad_calculo_id").AsInt16().NotNullable()
                .ForeignKey("FX_reservas_servicios_unidad_calculo_id", "unidades_calculo","unidad_calculo_id")
                .WithColumn("fecha_desde").AsDate().NotNullable()
                .WithColumn("fecha_hasta").AsDate().NotNullable()
                .WithColumn("cantidad").AsDecimal(5,2)
                .WithColumn("user_id").AsInt32().Nullable()
                .ForeignKey("FX_reservas_servicios_user_id", "users","UserId")
                .WithColumn("fecha_modificacion").AsDateTime().Nullable()
                .WithColumn("flag_contrato").AsBoolean().Nullable()
                .WithColumn("precio_servicio").AsDouble().Nullable()
                .WithColumn("servicio_extra").AsBoolean().Nullable();

            Create.Index("")
                .OnTable("reservas_servicios")
                .OnColumn("reserva_id").Ascending();

            Create.Index("")
                .OnTable("reservas_servicios")
                .OnColumn("servicio_id").Ascending();

            Create.Index("")
                .OnTable("reservas_servicios")
                .OnColumn("fecha_desde").Ascending();

            Create.Index("")
                .OnTable("reservas_servicios")
                .OnColumn("fecha_hasta").Ascending();

            Create.Table("reservas_contratos")
                .WithColumn("reserva_contrato_id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("reserva_id").AsInt32().NotNullable()
                .WithColumn("contrato_id").AsInt32().NotNullable()
                .WithColumn("directo").AsBoolean().Nullable();

            Create.Index("")
                .OnTable("reservas_contratos")
                .OnColumn("reserva_id").Ascending()
                .OnColumn("contrato_id").Ascending()
                .WithOptions().Unique();

            Create.Table("tipos_descuento")
                .WithColumn("tipo_descuento_id").AsInt16().PrimaryKey().Identity().NotNullable()
                .WithColumn("tipo_descuento").AsString(16).NotNullable();

            Insert.IntoTable("tipos_descuento").Row(new
            {
                tipo_descuento = "Porcentaje"
            });

            Insert.IntoTable("tipos_descuento").Row(new
            {
                tipo_descuento = "Cantidad"
            });

            Create.Table("modo_descuento")
                .WithColumn("tipo").AsString(1).PrimaryKey().NotNullable()
                .WithColumn("descripcion").AsString(15).NotNullable();

            Insert.IntoTable("modo_descuento").Row(new
            {
                tipo = "M",
                descripcion = "Manual"
                
            });

            Insert.IntoTable("modo_descuento").Row(new
            {
                tipo = "A",
                descripcion = "Automatico"

            });

            Create.Table("huespedes")
                .WithColumn("huesped_id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("empresa_id").AsInt16().NotNullable()
                .ForeignKey("FK_huespedes_empresa_id", "empresas", "empresa_id")
                .WithColumn("Nombre").AsString(30).NotNullable()
                .WithColumn("Apellidos").AsString(50).NotNullable()
                .WithColumn("tipo_documento_id").AsString(1).Nullable()
                .WithColumn("nif").AsString(20).Nullable()
                .WithColumn("fecha_documento").AsDate().Nullable()
                .WithColumn("sexo_id").AsString(1).Nullable()
                .WithColumn("direccion").AsString(70).Nullable()
                .WithColumn("poblacion").AsString(70).Nullable()
                .WithColumn("zip").AsString(10).Nullable()
                .WithColumn("nacion_id").AsInt16().Nullable()
                .ForeignKey("FK_huespedes_nacion", "naciones", "nacion_id")
                .WithColumn("provincia_id").AsInt16().Nullable()
                .ForeignKey("FK_huespedes_provincia", "provincias", "provincia_id")
                .WithColumn("telefono").AsString(16).Nullable()
                .WithColumn("email").AsString(70).Nullable()
                .WithColumn("foto1").AsString(100).Nullable()
                .WithColumn("foto2").AsString(100).Nullable()
                .WithColumn("tarjeta_fidelizacion").AsString(20).Nullable();

            Create.Index("IX_huespedes_empresa_id")
                .OnTable("huespedes")
                .OnColumn("empresa_id").Ascending();

            Create.Index("IX_huespedes_naciones")
                .OnTable("huespedes")
                .OnColumn("nacion_id").Ascending();

            Create.Table("reservas_descuentos")
                .WithColumn("reserva_descuento_id").AsInt32().PrimaryKey().Identity()
                .WithColumn("reserva_id").AsInt32().NotNullable()
                .ForeignKey("FK_reservas_descuentos_reserva_id", "reservas", "reserva_id")
                .WithColumn("servicio_id").AsInt32().NotNullable()
                .ForeignKey("FK_reservas_descuentos_servicio_id", "servicios","servicio_id")
                .WithColumn("tipo_descuento_id").AsInt16().NotNullable()
                .ForeignKey("FK_reservas_descuentos_tipo_descuento_id", "tipos_descuento","tipo_descuento_id")
                .WithColumn("tipo").AsString(1).NotNullable()
                .ForeignKey("","modo_descuento","tipo")
                .WithColumn("descuento").AsDecimal(7,2).NotNullable()
                .WithColumn("user_id").AsInt32().Nullable()
                .WithColumn("fecha_modificacion").AsDateTime().Nullable();

            Create.Table("reservas_huespedes")
                .WithColumn("reservas_huespedes_id").AsInt32().Identity().PrimaryKey()
                .WithColumn("reserva_id").AsInt32().NotNullable()
                .ForeignKey("FK_reservas_huespedes_reserva_id", "reservas", "reserva_id")
                .WithColumn("huesped_id").AsInt32().NotNullable()
                .ForeignKey("FK_reservas_huespedes_huesped_id","huespedes","huesped_id")
                .WithColumn("fecha_llegada").AsDate().Nullable()
                .WithColumn("fecha_salida").AsDate().Nullable()
                .WithColumn("habitacion_id").AsInt32().Nullable()
                .WithColumn("tipo_huesped_id").AsInt16().Nullable()
                .WithColumn("edad").AsInt16().Nullable();

            Create.Table("reservas_ofertas")
                .WithColumn("reserva_oferta_id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("reserva_id").AsInt32().NotNullable()
                .WithColumn("oferta_id").AsInt32().NotNullable()
                .WithColumn("tipo").AsString(1).Nullable()
                .WithColumn("activa").AsBoolean().Nullable()
                .WithColumn("oferta_usada").AsBoolean().Nullable();

            Create.Index("")
                .OnTable("reservas_ofertas")
                .OnColumn("reserva_id").Ascending();

            Create.Index("")
                .OnTable("reservas_ofertas")
                .OnColumn("reserva_id").Ascending()
                .OnColumn("oferta_id").Ascending()
                .WithOptions().Unique();

        }

        public override void Down()
        {
        }

    }
}
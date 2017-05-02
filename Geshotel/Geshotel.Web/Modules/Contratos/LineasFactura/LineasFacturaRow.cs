
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), TableName("lineas_factura"), DisplayName("Lineas Factura"), InstanceName("Lineas Factura"), TwoLevelCached]
    [ReadPermission("Recepcion:Hotel")]
    [ModifyPermission("Recepcion:Hotel")]
    public sealed class LineasFacturaRow : Row, IIdRow, INameRow
    {
        [DisplayName("Linea Factura Id"), Column("linea_factura_id"), Identity]
        public Int32? LineaFacturaId
        {
            get { return Fields.LineaFacturaId[this]; }
            set { Fields.LineaFacturaId[this] = value; }
        }

        [DisplayName("Hotel"), Column("hotel_id"), NotNull, ForeignKey("hoteles", "hotel_id"), LeftJoin("jHotel"), TextualField("HotelName"), LookupInclude]
        [LookupEditor("Portal.Hoteles")]
        public Int16? HotelId
        {
            get { return Fields.HotelId[this]; }
            set { Fields.HotelId[this] = value; }
        }
        [DisplayName("Hotel"), Expression("jHotel.[hotel]")]
        public String HotelName
        {
            get { return Fields.HotelName[this]; }
            set { Fields.HotelName[this] = value; }
        }
        //*********
        [DisplayName("Empresa"), Expression("jHotel.[empresa_id]"), ForeignKey("empresas", "empresa_id"), LeftJoin("jEmpresas")]
        [LookupEditor("Portal.Empresas")]
        public Int16? EmpresaId
        {
            get { return Fields.EmpresaId[this]; }
            set { Fields.EmpresaId[this] = value; }

        }

        [DisplayName("Empresa"), Expression("jEmpresas.empresa")]

        public String Empresa
        {
            get { return Fields.Empresa[this]; }
            set { Fields.Empresa[this] = value; }

        }
        //*******

        [DisplayName("Fecha"), Column("fecha"), NotNull]
        public DateTime? Fecha
        {
            get { return Fields.Fecha[this]; }
            set { Fields.Fecha[this] = value; }
        }

        [DisplayName("Factura Id"), Column("factura_id")]
        public Int32? FacturaId
        {
            get { return Fields.FacturaId[this]; }
            set { Fields.FacturaId[this] = value; }
        }

        [DisplayName("Reserva Id"), Column("reserva_id")]
        public Int32? ReservaId
        {
            get { return Fields.ReservaId[this]; }
            set { Fields.ReservaId[this] = value; }
        }

        [DisplayName("Contrato Id"), Column("contrato_id")]
        public Int32? ContratoId
        {
            get { return Fields.ContratoId[this]; }
            set { Fields.ContratoId[this] = value; }
        }

        [DisplayName("Descripcion"), Column("descripcion"), Size(50), NotNull, QuickSearch]
        public String Descripcion
        {
            get { return Fields.Descripcion[this]; }
            set { Fields.Descripcion[this] = value; }
        }

        [DisplayName("Cantidad"), Column("cantidad"), Size(5), Scale(2), NotNull]
        public Decimal? Cantidad
        {
            get { return Fields.Cantidad[this]; }
            set { Fields.Cantidad[this] = value; }
        }

        [DisplayName("Precio"), Column("precio"), Size(15), Scale(3), NotNull]
        public Decimal? Precio
        {
            get { return Fields.Precio[this]; }
            set { Fields.Precio[this] = value; }
        }

        [DisplayName("Importe"),Expression("T0.Cantidad*T0.precio")]
        public Decimal? Importe
        {
            get { return Fields.Importe[this]; }
            set { Fields.Importe[this] = value; }

        }

        [DisplayName("Impuesto Id"), Column("impuesto_id"), NotNull]
        public Int16? ImpuestoId
        {
            get { return Fields.ImpuestoId[this]; }
            set { Fields.ImpuestoId[this] = value; }
        }

        [DisplayName("Porc Impuesto"), Column("porc_impuesto"), Size(5), Scale(2), NotNull]
        public Decimal? PorcImpuesto
        {
            get { return Fields.PorcImpuesto[this]; }
            set { Fields.PorcImpuesto[this] = value; }
        }

        [DisplayName("Servicio"), Column("servicio_id"), NotNull, ForeignKey("servicios", "servicio_id"), LeftJoin("jServicio"), TextualField("ServicioNombreServicio")]
        [LookupEditor("Portal.Servicios")]
        public Int32? ServicioId
        {
            get { return Fields.ServicioId[this]; }
            set { Fields.ServicioId[this] = value; }
        }

        [DisplayName("Unidad Calculo"), Column("unidad_calculo_id"), NotNull, ForeignKey("unidades_calculo", "unidad_calculo_id"), LeftJoin("jUnidadCalculo"), TextualField("UnidadCalculo")]
        [LookupEditor(typeof(Portal.Entities.UnidadesCalculoRow))]
        public Int16? UnidadCalculoId
        {
            get { return Fields.UnidadCalculoId[this]; }
            set { Fields.UnidadCalculoId[this] = value; }
        }

        [DisplayName("Servicio"), Expression("jServicio.[nombre_servicio]")]
        public String NombreServicio
        {
            get { return Fields.NombreServicio[this]; }
            set { Fields.NombreServicio[this] = value; }
        }

        [DisplayName("Unidad Calculo"), Expression("jUnidadCalculo.[descripcion_unidad_calculo]")]
        public String UnidadCalculo
        {
            get { return Fields.UnidadCalculo[this]; }
            set { Fields.UnidadCalculo[this] = value; }
        }

        [DisplayName("Tipo Linea Factura"), Column("tipo_linea_factura"), Size(1), NotNull]
        public String TipoLineaFactura
        {
            get { return Fields.TipoLineaFactura[this]; }
            set { Fields.TipoLineaFactura[this] = value; }
        }

        [DisplayName("Precio Produccion"), Column("precio_produccion"), Size(15), Scale(3)]
        public Decimal? PrecioProduccion
        {
            get { return Fields.PrecioProduccion[this]; }
            set { Fields.PrecioProduccion[this] = value; }
        }

        [DisplayName("Pag Factura"), Column("pag_factura"), NotNull]
        public Int16? PagFactura
        {
            get { return Fields.PagFactura[this]; }
            set { Fields.PagFactura[this] = value; }
        }

        [DisplayName("Costo"), Column("costo"), Size(10), Scale(2)]
        public Decimal? Costo
        {
            get { return Fields.Costo[this]; }
            set { Fields.Costo[this] = value; }
        }

        [DisplayName("User"), Column("user_id"), ForeignKey("users", "UserId"), LeftJoin("jUser"), TextualField("Username")]
        [LookupEditor("Portal.Users")]
        public Int32? UserId
        {
            get { return Fields.UserId[this]; }
            set { Fields.UserId[this] = value; }
        }

        [DisplayName("Fecha Modificacion"), Column("fecha_modificacion")]
        public DateTime? FechaModificacion
        {
            get { return Fields.FechaModificacion[this]; }
            set { Fields.FechaModificacion[this] = value; }
        }

        [DisplayName("User Username"), Expression("jUser.[Username]")]
        public String Username
        {
            get { return Fields.Username[this]; }
            set { Fields.Username[this] = value; }
        }

        [DisplayName("Sw Ajuste"), Column("sw_ajuste"), NotNull]
        public Boolean? SwAjuste
        {
            get { return Fields.SwAjuste[this]; }
            set { Fields.SwAjuste[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.LineaFacturaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Descripcion; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public LineasFacturaRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field LineaFacturaId;
            public Int16Field HotelId;
            public DateTimeField Fecha;
            public Int32Field FacturaId;
            public Int32Field ReservaId;
            public Int32Field ContratoId;
            public StringField Descripcion;
            public DecimalField Cantidad;
            public DecimalField Precio;
            public Int16Field ImpuestoId;
            public DecimalField PorcImpuesto;
            public Int32Field ServicioId;
            public Int16Field UnidadCalculoId;
            public StringField TipoLineaFactura;
            public DecimalField PrecioProduccion;
            public Int16Field PagFactura;
            public DecimalField Costo;
            public Int32Field UserId;
            public DateTimeField FechaModificacion;
            public BooleanField SwAjuste;

            public StringField HotelName;
            public Int16Field EmpresaId;
            public StringField Empresa;
            public StringField Username;
            public DecimalField Importe;
            public StringField NombreServicio;

            public StringField UnidadCalculo;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Contratos.LineasFactura";
            }
        }
    }
}

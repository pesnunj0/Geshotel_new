
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), TableName("facturas"), DisplayName("Facturas"), InstanceName("Facturas"), TwoLevelCached]
    [ReadPermission("Contratos:Empresa")]
    [ModifyPermission("Contratos:Empresa")]
    public sealed class FacturasRow : Row, IIdRow, INameRow
    {
        [DisplayName("Factura Id"), Column("factura_id"), Identity]
        public Int32? FacturaId
        {
            get { return Fields.FacturaId[this]; }
            set { Fields.FacturaId[this] = value; }
        }

        [DisplayName("Numero Factura"), Column("numero_factura"), NotNull]
        public Int32? NumeroFactura
        {
            get { return Fields.NumeroFactura[this]; }
            set { Fields.NumeroFactura[this] = value; }
        }

        [DisplayName("Serie Id"), Column("serie_id"), NotNull]
        public Int16? SerieId
        {
            get { return Fields.SerieId[this]; }
            set { Fields.SerieId[this] = value; }
        }

        [DisplayName("Fecha Factura"), Column("fecha_factura"), NotNull]
        public DateTime? FechaFactura
        {
            get { return Fields.FechaFactura[this]; }
            set { Fields.FechaFactura[this] = value; }
        }

        [DisplayName("Hotel Id"), Column("hotel_id"), NotNull]
        public Int16? HotelId
        {
            get { return Fields.HotelId[this]; }
            set { Fields.HotelId[this] = value; }
        }

        [DisplayName("Cliente Id"), Column("cliente_id"), NotNull]
        public Int32? ClienteId
        {
            get { return Fields.ClienteId[this]; }
            set { Fields.ClienteId[this] = value; }
        }

        [DisplayName("Forma Pago Id"), Column("forma_pago_id")]
        public Int16? FormaPagoId
        {
            get { return Fields.FormaPagoId[this]; }
            set { Fields.FormaPagoId[this] = value; }
        }

        [DisplayName("Direccion Factura"), Column("direccion_factura"), Size(70), QuickSearch]
        public String DireccionFactura
        {
            get { return Fields.DireccionFactura[this]; }
            set { Fields.DireccionFactura[this] = value; }
        }

        [DisplayName("Poblacion Factura"), Column("poblacion_factura"), Size(50)]
        public String PoblacionFactura
        {
            get { return Fields.PoblacionFactura[this]; }
            set { Fields.PoblacionFactura[this] = value; }
        }

        [DisplayName("Zip"), Column("zip"), Size(10)]
        public String Zip
        {
            get { return Fields.Zip[this]; }
            set { Fields.Zip[this] = value; }
        }

        [DisplayName("Provincia Id"), Column("provincia_id")]
        public Int16? ProvinciaId
        {
            get { return Fields.ProvinciaId[this]; }
            set { Fields.ProvinciaId[this] = value; }
        }

        [DisplayName("Fecha Vencimiento"), Column("fecha_vencimiento")]
        public DateTime? FechaVencimiento
        {
            get { return Fields.FechaVencimiento[this]; }
            set { Fields.FechaVencimiento[this] = value; }
        }

        [DisplayName("Estado Factura Id"), Column("estado_factura_id"), NotNull]
        public Int16? EstadoFacturaId
        {
            get { return Fields.EstadoFacturaId[this]; }
            set { Fields.EstadoFacturaId[this] = value; }
        }

        [DisplayName("Ref Fra1"), Column("ref_fra1"), Size(75)]
        public String RefFra1
        {
            get { return Fields.RefFra1[this]; }
            set { Fields.RefFra1[this] = value; }
        }

        [DisplayName("Ref Fra2"), Column("ref_fra2"), Size(75)]
        public String RefFra2
        {
            get { return Fields.RefFra2[this]; }
            set { Fields.RefFra2[this] = value; }
        }

        [DisplayName("Id Factura Rectificada"), Column("id_factura_rectificada")]
        public Int32? IdFacturaRectificada
        {
            get { return Fields.IdFacturaRectificada[this]; }
            set { Fields.IdFacturaRectificada[this] = value; }
        }

        [DisplayName("Motivo Rectificacion"), Column("motivo_rectificacion"), Size(75)]
        public String MotivoRectificacion
        {
            get { return Fields.MotivoRectificacion[this]; }
            set { Fields.MotivoRectificacion[this] = value; }
        }

        [DisplayName("User Id"), Column("user_id")]
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

        IIdField IIdRow.IdField
        {
            get { return Fields.FacturaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.DireccionFactura; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public FacturasRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field FacturaId;
            public Int32Field NumeroFactura;
            public Int16Field SerieId;
            public DateTimeField FechaFactura;
            public Int16Field HotelId;
            public Int32Field ClienteId;
            public Int16Field FormaPagoId;
            public StringField DireccionFactura;
            public StringField PoblacionFactura;
            public StringField Zip;
            public Int16Field ProvinciaId;
            public DateTimeField FechaVencimiento;
            public Int16Field EstadoFacturaId;
            public StringField RefFra1;
            public StringField RefFra2;
            public Int32Field IdFacturaRectificada;
            public StringField MotivoRectificacion;
            public Int32Field UserId;
            public DateTimeField FechaModificacion;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Contratos.Facturas";
            }
        }
    }
}

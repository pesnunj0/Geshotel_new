
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("estados_facturas"), InstanceName("estados_facturas"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.EstadosFactura")]
    public sealed class EstadosFacturasRow : Row, IIdRow, INameRow
    {
        [DisplayName("Estado Factura Id"), Column("estado_factura_id"), PrimaryKey]
        public Int16? EstadoFacturaId
        {
            get { return Fields.EstadoFacturaId[this]; }
            set { Fields.EstadoFacturaId[this] = value; }
        }

        [DisplayName("Descripcion"), Column("descripcion"), Size(255), QuickSearch]
        public String Descripcion
        {
            get { return Fields.Descripcion[this]; }
            set { Fields.Descripcion[this] = value; }
        }

        [DisplayName("Es Error"), Column("es_error")]
        public Int16? EsError
        {
            get { return Fields.EsError[this]; }
            set { Fields.EsError[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.EstadoFacturaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Descripcion; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public EstadosFacturasRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field EstadoFacturaId;
            public StringField Descripcion;
            public Int16Field EsError;

            public RowFields()
                : base("estados_facturas")
            {
                LocalTextPrefix = "Portal.EstadosFacturas";
            }
        }
    }
}

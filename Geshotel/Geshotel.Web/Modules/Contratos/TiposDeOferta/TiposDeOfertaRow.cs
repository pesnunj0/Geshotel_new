
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("tipos_de_oferta"), InstanceName("tipos_de_oferta"), TwoLevelCached]
    [ReadPermission("Todos:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Contratos.TiposDeOferta")]
    public sealed class TiposDeOfertaRow : Row, IIdRow, INameRow
    {
        [DisplayName("Tipo Oferta Id"), Column("tipo_oferta_id"), PrimaryKey]
        public Int16? TipoOfertaId
        {
            get { return Fields.TipoOfertaId[this]; }
            set { Fields.TipoOfertaId[this] = value; }
        }

        [DisplayName("Oferta"), Size(25), NotNull, QuickSearch]
        public String Oferta
        {
            get { return Fields.Oferta[this]; }
            set { Fields.Oferta[this] = value; }
        }

        [DisplayName("Permitir M Mayor Que N"), Column("permitir_m_mayor_que_n"), NotNull]
        public Int16? PermitirMMayorQueN
        {
            get { return Fields.PermitirMMayorQueN[this]; }
            set { Fields.PermitirMMayorQueN[this] = value; }
        }

        [DisplayName("Rejilla"), Column("rejilla"), NotNull]
        public Int16? Rejilla
        {
            get { return Fields.Rejilla[this]; }
            set { Fields.Rejilla[this] = value; }
        }

        [DisplayName("Observaciones"), Size(100)]
        public String Observaciones
        {
            get { return Fields.Observaciones[this]; }
            set { Fields.Observaciones[this] = value; }
        }

        [DisplayName("Orden Aplicacion"), Column("orden_aplicacion")]
        public Int16? OrdenAplicacion
        {
            get { return Fields.OrdenAplicacion[this]; }
            set { Fields.OrdenAplicacion[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.TipoOfertaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Oferta; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TiposDeOfertaRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field TipoOfertaId;
            public StringField Oferta;
            public Int16Field PermitirMMayorQueN;
            public Int16Field Rejilla;
            public StringField Observaciones;
            public Int16Field OrdenAplicacion;

            public RowFields()
                : base("tipos_de_oferta")
            {
                LocalTextPrefix = "Contratos.TiposDeOferta";
            }
        }
    }
}


namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;
    using Geshotel.Portal.Entities;

    [ConnectionKey("Default"), DisplayName("Mercados"), InstanceName("Mercados"), TwoLevelCached]
    [ReadPermission("Contratos:General")]
    [ModifyPermission("Contratos:General")]
    [LookupScript("Contratos.Mercados")]
    public sealed class MercadosRow : Row, IIdRow, INameRow
    {
        [DisplayName("Mercado Id"), Column("mercado_id"), PrimaryKey]
        public Int16? MercadoId
        {
            get { return Fields.MercadoId[this]; }
            set { Fields.MercadoId[this] = value; }
        }

        [DisplayName("Mercado"), Column("mercado"), Size(25), NotNull, QuickSearch]
        public String Mercado
        {
            get { return Fields.Mercado[this]; }
            set { Fields.Mercado[this] = value; }
        }

        [DisplayName("Hotel"), Column("hotel_id"), PrimaryKey, ForeignKey("[hoteles]", "hotel_id"), LeftJoin("jHoteles"), TextualField("Hotel")]
        [LookupEditor(typeof(HotelesRow))]
        public Int16? HotelId
        {
            get { return Fields.HotelId[this]; }
            set { Fields.HotelId[this] = value; }
        }

        [DisplayName("Hotel"), Expression("jHoteles.[hotel]")]
        public String HotelName
        {
            get { return Fields.HotelName[this]; }
            set { Fields.HotelName[this] = value; }
        }

        [DisplayName("Empresa"), Expression("jHoteles.[empresa_id]"), ForeignKey("empresas", "empresa_id"), LeftJoin("jEmpresas")]
        [LookupEditor(typeof(EmpresasRow))]
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


        IIdField IIdRow.IdField
        {
            get { return Fields.MercadoId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Mercado; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public MercadosRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field MercadoId;
            public StringField Mercado;
            public Int16Field EmpresaId;
            public Int16Field HotelId;

            public StringField Empresa;
            public StringField HotelName;

            public RowFields()
                : base("[mercados]")
            {
                LocalTextPrefix = "Contratos.Mercados";
            }
        }
    }
}

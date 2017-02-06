
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

    [ConnectionKey("Default"), DisplayName("Temporadas"), InstanceName("Temporadas"), TwoLevelCached]
    [ReadPermission("Contratos:General")]
    [ModifyPermission("Contratos:General")]
    [LookupScript("Contratos.Temporadas")]
    public sealed class TemporadasRow : Row, IIdRow, INameRow
    {
        [DisplayName("Temporada Id"), Column("temporada_id"), PrimaryKey]
        public Int16? TemporadaId
        {
            get { return Fields.TemporadaId[this]; }
            set { Fields.TemporadaId[this] = value; }
        }

        [DisplayName("Temporada"), Column("temporada"), Size(25), NotNull, QuickSearch]
        public String Temporada
        {
            get { return Fields.Temporada[this]; }
            set { Fields.Temporada[this] = value; }
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

        [DisplayName("Ano"), Column("ano")]
        public Int16? Ano
        {
            get { return Fields.Ano[this]; }
            set { Fields.Ano[this] = value; }
        }

        [DisplayName("Fecha Desde"), Column("fecha_desde"), NotNull]
        public DateTime? FechaDesde
        {
            get { return Fields.FechaDesde[this]; }
            set { Fields.FechaDesde[this] = value; }
        }

        [DisplayName("Fecha Hasta"), Column("fecha_hasta"), NotNull]
        public DateTime? FechaHasta
        {
            get { return Fields.FechaHasta[this]; }
            set { Fields.FechaHasta[this] = value; }
        }

 

        IIdField IIdRow.IdField
        {
            get { return Fields.TemporadaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Temporada; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TemporadasRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field TemporadaId;
            public StringField Temporada;
            public Int16Field HotelId;
            public Int16Field EmpresaId;
            public Int16Field Ano;
            public DateTimeField FechaDesde;
            public DateTimeField FechaHasta;

            public StringField HotelName;
            public StringField Empresa;

            public RowFields()
                : base("[dbo].[temporadas]")
            {
                LocalTextPrefix = "Contratos.Temporadas";
            }
        }
    }
}

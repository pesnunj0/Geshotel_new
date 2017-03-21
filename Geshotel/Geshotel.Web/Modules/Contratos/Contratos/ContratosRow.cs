
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

    [ConnectionKey("Default"), DisplayName("Contratos"), InstanceName("Contratos"), TwoLevelCached]
    [ReadPermission("Todos:General")]
    [ModifyPermission("Contratos:Empresa")]
    [LookupScript("Contratos.Contratos]")]
    public sealed class ContratosRow : Row, IIdRow, INameRow, ITenantRow
    {
        public Int16Field HotelIdField
        {
            get { return Fields.HotelId; }
        }
        public Int16Field EmpresaIdField
        {
            get { return Fields.EmpresaId; }
        }

        [DisplayName("Contrato Id"), Column("contrato_id"), Identity]
        public Int32? ContratoId
        {
            get { return Fields.ContratoId[this]; }
            set { Fields.ContratoId[this] = value; }
        }

        [DisplayName("Hotel"), Column("hotel_id"), ForeignKey("hoteles", "hotel_id"), LeftJoin("jHoteles")]
        [LookupEditor("Portal.Hoteles"),LookupInclude]
        public Int16? HotelId
        {
            get { return Fields.HotelId[this]; }
            set { Fields.HotelId[this] = value; }

        }

        [DisplayName("Empresa"), Expression("jHoteles.[empresa_id]"), ForeignKey("empresas","empresa_id"), LeftJoin("jEmpresas")]
        [LookupEditor("Portal.Empresas"),LookupInclude]
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

        [DisplayName("Hotel"), Expression("jHoteles.hotel")]
        public String HotelName
        {
            get { return Fields.HotelName[this]; }
            set { Fields.HotelName[this] = value; }
        }

        [DisplayName("Touroperador"), Column("cliente_id"), NotNull, ForeignKey("clientes", "cliente_id"), LeftJoin("jCliente"), TextualField("Touroperador")]
        [LookupEditor("Contratos.Clientes")]
        public Int32? ClienteId
        {
            get { return Fields.ClienteId[this]; }
            set { Fields.ClienteId[this] = value; }
        }

        [DisplayName("Touroperador"),Expression("jCliente.razon")]
        public String Touroperador
        {
            get { return Fields.Touroperador[this]; }
            set { Fields.Touroperador[this] = value; }
        }

        [DisplayName("Fecha Contrato"), Column("fecha_contrato"), NotNull]
        public DateTime? FechaContrato
        {
            get { return Fields.FechaContrato[this]; }
            set { Fields.FechaContrato[this] = value; }
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

        [DisplayName("Numero Contrato TTOO"), Column("numero_contrato_cliente"), Size(40), QuickSearch]
        public String NumeroContratoCliente
        {
            get { return Fields.NumeroContratoCliente[this]; }
            set { Fields.NumeroContratoCliente[this] = value; }
        }

        [DisplayName("Usuario"), Column("user_id"), ForeignKey("users", "UserId"), LeftJoin("jUsers")]
        [LookupEditor(typeof(Geshotel.Administration.Entities.UserRow))]
        public Int32? UserId
        {
            get { return Fields.UserId[this]; }
            set { Fields.UserId[this] = value; }
        }
        [DisplayName("Usuario"), Expression("jUsers.Username")]
        public String UserName
        {
            get { return Fields.UserName[this]; }
            set { Fields.UserName[this] = value; }
        }

        [DisplayName("Fecha Modificacion"), Column("fecha_modificacion")]
        public DateTime? FechaModificacion
        {
            get { return Fields.FechaModificacion[this]; }
            set { Fields.FechaModificacion[this] = value; }
        }

        [DisplayName("Temporada"), Column("temporada_id"),ForeignKey("temporadas","temporada_id"),LeftJoin("jTemporadas")]
        [LookupEditor(typeof(TemporadasRow))]
        public Int16? TemporadaId
        {
            get { return Fields.TemporadaId[this]; }
            set { Fields.TemporadaId[this] = value; }
        }
        [DisplayName("Temporada"),Expression("jTemporadas.[temporada]")]
        public String Temporada
        {
            get { return Fields.Temporada[this]; }
            set { Fields.Temporada[this] = value; }
        }

        [DisplayName("Impuesto Incluido"), Column("impuesto_incluido")]
        public Boolean? ImpuestoIncluido
        {
            get { return Fields.ImpuestoIncluido[this]; }
            set { Fields.ImpuestoIncluido[this] = value; }
        }

        [DisplayName("Mercado"), Column("mercado_id"),ForeignKey("mercados","mercado_id"),LeftJoin("jMercados")]
        [LookupEditor(typeof(MercadosRow))]
        public Int16? MercadoId
        {
            get { return Fields.MercadoId[this]; }
            set { Fields.MercadoId[this] = value; }
        }
        [DisplayName("Mercado"), Expression("jMercados.[mercado]")]
        public String Mercado
        {
            get { return Fields.Mercado[this]; }
            set { Fields.Mercado[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ContratoId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Touroperador; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ContratosRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ContratoId;
            public Int16Field HotelId;
            public Int32Field ClienteId;
            public DateTimeField FechaContrato;
            public DateTimeField FechaDesde;
            public DateTimeField FechaHasta;
            public StringField NumeroContratoCliente;
            public Int32Field UserId;
            public DateTimeField FechaModificacion;
            public Int16Field TemporadaId;
            public BooleanField ImpuestoIncluido;
            public Int16Field MercadoId;

            public StringField HotelName;
            public StringField Touroperador;
            public Int16Field EmpresaId;
            public StringField Empresa;
            public StringField Mercado;
            public StringField Temporada;
            public StringField UserName;

            public RowFields()
                : base("[contratos]")
            {
                LocalTextPrefix = "Contratos.Contratos";
            }
        }
    }
}

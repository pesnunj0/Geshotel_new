
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

    [ConnectionKey("Default"), TableName("contratos_edades"), DisplayName("Edades"), InstanceName("Edades"), TwoLevelCached]
    [ReadPermission("Contratos:General")]
    [ModifyPermission("Contratos:General")]
    public sealed class EdadesRow : Row, IIdRow, INameRow
    {
        [DisplayName("Contratos Edades Id"), Column("contratos_edades_id"), Identity]
        public Int32? EdadesId
        {
            get { return Fields.EdadesId[this]; }
            set { Fields.EdadesId[this] = value; }
        }

        [DisplayName("Hotel"), Column("hotel_id"), ForeignKey("hoteles", "hotel_id"), LeftJoin("jHoteles")]
        [LookupEditor(typeof(HotelesRow))]
        public Int16? HotelId
        {
            get { return Fields.HotelId[this]; }
            set { Fields.HotelId[this] = value; }

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

        [DisplayName("Hotel"), Expression("jHoteles.hotel")]
        public String HotelName
        {
            get { return Fields.HotelName[this]; }
            set { Fields.HotelName[this] = value; }
        }

        [DisplayName("Touroperador"), Column("cliente_id"), NotNull, ForeignKey("clientes", "cliente_id"), LeftJoin("jCliente"), TextualField("Cliente")]
        [LookupEditor(typeof(ClientesRow))]
        public Int32? ClienteId
        {
            get { return Fields.ClienteId[this]; }
            set { Fields.ClienteId[this] = value; }
        }

        [DisplayName("Touroperador"), Expression("jCliente.razon")]
        public String Touroperador
        {
            get { return Fields.Touroperador[this]; }
            set { Fields.Touroperador[this] = value; }
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

        [DisplayName("Tipo Huesped Id"), Column("tipo_huesped_id"), ForeignKey("tipos_huesped", "tipo_huesped_id"), LeftJoin("JTiposHuesped"), NotNull]
        [LookupEditor(typeof(TiposHuespedRow))]
        public Int16? TipoHuespedId
        {
            get { return Fields.TipoHuespedId[this]; }
            set { Fields.TipoHuespedId[this] = value; }
        }

        [DisplayName("Tipo Huesped"), Expression("jTiposHuesped.descripcion")]
        public String TipoHuesped
        {
            get { return Fields.TipoHuesped[this]; }
            set { Fields.TipoHuesped[this] = value; }
        }

        [DisplayName("Edad Minima"), Column("edad_minima"), NotNull]
        public Int32? EdadMinima
        {
            get { return Fields.EdadMinima[this]; }
            set { Fields.EdadMinima[this] = value; }
        }

        [DisplayName("Edad Maxima"), Column("edad_maxima"), NotNull]
        public Int32? EdadMaxima
        {
            get { return Fields.EdadMaxima[this]; }
            set { Fields.EdadMaxima[this] = value; }
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

        IIdField IIdRow.IdField
        {
            get { return Fields.EdadesId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Touroperador; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public EdadesRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field EdadesId;
            public Int16Field HotelId;
            public Int32Field ClienteId;
            public DateTimeField FechaDesde;
            public DateTimeField FechaHasta;
            public Int16Field TipoHuespedId;
            public Int32Field EdadMinima;
            public Int32Field EdadMaxima;
            public Int32Field UserId;
            public DateTimeField FechaModificacion;

            public StringField HotelName;
            public StringField Touroperador;
            public Int16Field EmpresaId;
            public StringField Empresa;
            public StringField UserName;
            public StringField TipoHuesped;
            public RowFields()
                : base()
            {
                LocalTextPrefix = "Contratos.ContratosEdades";
            }
        }
    }
}

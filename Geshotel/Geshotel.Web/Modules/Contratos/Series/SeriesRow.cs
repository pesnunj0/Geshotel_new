
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

    [ConnectionKey("Default"), TableName("series"), DisplayName("Series"), InstanceName("Series"), TwoLevelCached]
    [ReadPermission("Todos:General")]
    [ModifyPermission("Contratos:Empresa")]
    public sealed class SeriesRow : Row, IIdRow, INameRow, ITenantRow
    {
        public Int16Field HotelIdField
        {
            get { return null; }
        }
        public Int16Field EmpresaIdField
        {
            get { return Fields.EmpresaId; }
        }
    
        [DisplayName("Serie Id"), Column("serie_id"), Identity]
        public Int16? SerieId
        {
            get { return Fields.SerieId[this]; }
            set { Fields.SerieId[this] = value; }
        }

        [DisplayName("Empresa"), Column("empresa_id"), NotNull, ForeignKey("empresas", "empresa_id"), LeftJoin("jEmpresa"), TextualField("Empresa"), LookupInclude]
        [LookupEditor("Portal.Empresas")]
        public Int16? EmpresaId
        {
            get { return Fields.EmpresaId[this]; }
            set { Fields.EmpresaId[this] = value; }
        }

        [DisplayName("Empresa"), Expression("jEmpresa.[empresa]")]
        public String Empresa
        {
            get { return Fields.Empresa[this]; }
            set { Fields.Empresa[this] = value; }
        }


        [DisplayName("Descripcion"), Column("descripcion"), Size(20), NotNull, QuickSearch]
        public String Descripcion
        {
            get { return Fields.Descripcion[this]; }
            set { Fields.Descripcion[this] = value; }
        }

        [DisplayName("Abreviatura"), Column("abreviatura"), Size(4), NotNull]
        public String Abreviatura
        {
            get { return Fields.Abreviatura[this]; }
            set { Fields.Abreviatura[this] = value; }
        }

        [DisplayName("Manocorriente"), Column("manocorriente")]
        public Boolean? Manocorriente
        {
            get { return Fields.Manocorriente[this]; }
            set { Fields.Manocorriente[this] = value; }
        }

        [DisplayName("Visible"), Column("visible")]
        public Boolean? Visible
        {
            get { return Fields.Visible[this]; }
            set { Fields.Visible[this] = value; }
        }

        [DisplayName("Factura"), Column("factura")]
        public Boolean? Factura
        {
            get { return Fields.Factura[this]; }
            set { Fields.Factura[this] = value; }
        }

        [DisplayName("Deposito"), Column("deposito")]
        public Boolean? Deposito
        {
            get { return Fields.Deposito[this]; }
            set { Fields.Deposito[this] = value; }
        }

        [DisplayName("Servicio Id"), Column("servicio_id")]
        public Int32? ServicioId
        {
            get { return Fields.ServicioId[this]; }
            set { Fields.ServicioId[this] = value; }
        }

        [DisplayName("Impuesto Id"), Column("impuesto_id")]
        public Int32? ImpuestoId
        {
            get { return Fields.ImpuestoId[this]; }
            set { Fields.ImpuestoId[this] = value; }
        }

        [DisplayName("Voxel"), Column("voxel")]
        public Int16? Voxel
        {
            get { return Fields.Voxel[this]; }
            set { Fields.Voxel[this] = value; }
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

        [DisplayName("Fecha Modificacion"), Column("fecha_modificacion"), NotNull]
        public DateTime? FechaModificacion
        {
            get { return Fields.FechaModificacion[this]; }
            set { Fields.FechaModificacion[this] = value; }
        }


        IIdField IIdRow.IdField
        {
            get { return Fields.SerieId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Descripcion; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public SeriesRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field SerieId;
            public Int16Field EmpresaId;
            public StringField Descripcion;
            public StringField Abreviatura;
            public BooleanField Manocorriente;
            public BooleanField Visible;
            public BooleanField Factura;
            public BooleanField Deposito;
            public Int32Field ServicioId;
            public Int32Field ImpuestoId;
            public Int16Field Voxel;
            public Int32Field UserId;
            public DateTimeField FechaModificacion;

            public StringField Empresa;
            public StringField UserName;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Contratos.Series";
            }
        }
    }
}

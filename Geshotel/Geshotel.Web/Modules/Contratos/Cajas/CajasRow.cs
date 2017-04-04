
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;
    using Portal.Entities;

    [ConnectionKey("Default"), TableName("cajas"), DisplayName("Cajas"), InstanceName("Cajas"), TwoLevelCached]
    [ReadPermission("Todos:General")]
    [ModifyPermission("Contratos:empresa")]
    public sealed class CajasRow : Row, IIdRow, INameRow, ITenantRow
    {
        public Int16Field HotelIdField
        {
            get { return Fields.HotelId; }
        }
        public Int16Field EmpresaIdField
        {
            get { return Fields.EmpresaId; }
        }
    
        [DisplayName("Caja Id"), Column("caja_id"), Identity]
        public Int32? CajaId
        {
            get { return Fields.CajaId[this]; }
            set { Fields.CajaId[this] = value; }
        }

        [DisplayName("Hotel"), Column("hotel_id"), NotNull, ForeignKey("[hoteles]", "hotel_id"), LeftJoin("jHotel"), TextualField("HotelName"), LookupInclude]
        [LookupEditor("Portal.Hoteles")]
        public Int16? HotelId
        {
            get { return Fields.HotelId[this]; }
            set { Fields.HotelId[this] = value; }
        }


        [DisplayName("Nombre Caja"), Column("nombre_caja"), Size(30), NotNull, QuickSearch]
        public String NombreCaja
        {
            get { return Fields.NombreCaja[this]; }
            set { Fields.NombreCaja[this] = value; }
        }

        [DisplayName("Desc Corta"), Column("desc_corta"), Size(6), NotNull]
        public String DescCorta
        {
            get { return Fields.DescCorta[this]; }
            set { Fields.DescCorta[this] = value; }
        }

        [DisplayName("Cierre Dia"), Column("cierre_dia"), NotNull]
        public Boolean? CierreDia
        {
            get { return Fields.CierreDia[this]; }
            set { Fields.CierreDia[this] = value; }
        }

        [DisplayName("Cta Contable"), Column("cta_contable"), Size(16)]
        public String CtaContable
        {
            get { return Fields.CtaContable[this]; }
            set { Fields.CtaContable[this] = value; }
        }

        [DisplayName("Dpto Contable"), Column("dpto_contable"), Size(5)]
        public String DptoContable
        {
            get { return Fields.DptoContable[this]; }
            set { Fields.DptoContable[this] = value; }
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

        [DisplayName("Hotel"), Expression("jHotel.[hotel]")]
        public String HotelName
        {
            get { return Fields.HotelName[this]; }
            set { Fields.HotelName[this] = value; }
        }

        [DisplayName("Empresa"), Expression("jHotel.[empresa_id]"), ForeignKey("empresas", "empresa_id"), LeftJoin("jEmpresas")]
        [LookupEditor("Portal.Empresas"), LookupInclude]
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
            get { return Fields.CajaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.NombreCaja; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public CajasRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field CajaId;
            public Int16Field HotelId;
            public StringField NombreCaja;
            public StringField DescCorta;
            public BooleanField CierreDia;
            public StringField CtaContable;
            public StringField DptoContable;
            public Int32Field UserId;
            public DateTimeField FechaModificacion;

            public StringField HotelName;
            public Int16Field EmpresaId;
            public StringField Empresa;
            public StringField UserName;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Contratos.Cajas";
            }
        }
    }
}

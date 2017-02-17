
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), TableName("impuestos"), DisplayName("Impuestos"), InstanceName("Impuestos"), TwoLevelCached]
    [ReadPermission("Contratos:General")]
    [ModifyPermission("Contratos:General")]
    [LookupScript("Portal.Impuestos")]
    public sealed class ImpuestosRow : Row, IIdRow, INameRow
    {
        [DisplayName("Impuesto Id"), Column("impuesto_id"), Identity]
        public Int16? ImpuestoId
        {
            get { return Fields.ImpuestoId[this]; }
            set { Fields.ImpuestoId[this] = value; }
        }

        [DisplayName("Empresa"), Column("empresa_id"), NotNull, ForeignKey("empresas", "empresa_id"), LeftJoin("jEmpresa"), TextualField("Empresa")]
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

        [DisplayName("Impuesto"), Column("impuesto"), Size(30), NotNull, QuickSearch]
        public String Impuesto
        {
            get { return Fields.Impuesto[this]; }
            set { Fields.Impuesto[this] = value; }
        }

        [DisplayName("Porcentaje"), Column("porcentaje"), NotNull]
        public Double? Porcentaje
        {
            get { return Fields.Porcentaje[this]; }
            set { Fields.Porcentaje[this] = value; }
        }

        [DisplayName("Cta Contable"), Column("cta_contable"), Size(15)]
        public String CtaContable
        {
            get { return Fields.CtaContable[this]; }
            set { Fields.CtaContable[this] = value; }
        }

        [DisplayName("Activo Geshotel"), Column("activo_geshotel")]
        public Boolean? ActivoGeshotel
        {
            get { return Fields.ActivoGeshotel[this]; }
            set { Fields.ActivoGeshotel[this] = value; }
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

        [DisplayName("Fecha Actualizacion"), Column("fecha_actualizacion")]
        public DateTime? FechaActualizacion
        {
            get { return Fields.FechaActualizacion[this]; }
            set { Fields.FechaActualizacion[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ImpuestoId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Impuesto; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ImpuestosRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field ImpuestoId;
            public Int16Field EmpresaId;
            public StringField Impuesto;
            public DoubleField Porcentaje;
            public StringField CtaContable;
            public BooleanField ActivoGeshotel;
            public Int32Field UserId;
            public DateTimeField FechaActualizacion;
            public StringField UserName;
            public StringField Empresa;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Portal.Impuestos";
            }
        }
    }
}

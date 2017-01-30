
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("tipos_de_imputacion"), InstanceName("tipos_de_imputacion"), TwoLevelCached]
    [ReadPermission("Todos:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Contratos.TiposDeImputacion")]
    public sealed class TiposDeImputacionRow : Row, IIdRow, INameRow
    {
        [DisplayName("Tipo Imputacion Id"), Column("tipo_imputacion_id"), Identity]
        public Int16? TipoImputacionId
        {
            get { return Fields.TipoImputacionId[this]; }
            set { Fields.TipoImputacionId[this] = value; }
        }

        [DisplayName("Imputacion"), Column("imputacion"), Size(20), NotNull, QuickSearch]
        public String Imputacion
        {
            get { return Fields.Imputacion[this]; }
            set { Fields.Imputacion[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.TipoImputacionId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Imputacion; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TiposDeImputacionRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field TipoImputacionId;
            public StringField Imputacion;

            public RowFields()
                : base("tipos_de_imputacion")
            {
                LocalTextPrefix = "Contratos.TiposDeImputacion";
            }
        }
    }
}

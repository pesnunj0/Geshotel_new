namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Geshotel"), DisplayName("categoria_hoteles"), InstanceName("conceptos_acelerador_reservas"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.ConceptosAceleradorReservas")]
    public sealed class ConceptosAceleradorReservasRow : Row, IIdRow, INameRow
    {
        [DisplayName("Concepto Id"), Column("concepto_acelerador_id"), Identity]
        public Int16? ConceptoAceleradorId
        {
            get { return Fields.ConceptoAceleradorId[this]; }
            set { Fields.ConceptoAceleradorId[this] = value; }
        }

        [DisplayName("Concepto"), Column("concepto"), Size(20), NotNull]
        public String Concepto
        {
            get { return Fields.Concepto[this]; }
            set { Fields.Concepto[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ConceptoAceleradorId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Concepto; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ConceptosAceleradorReservasRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field ConceptoAceleradorId;
            public StringField Concepto;

            public RowFields()
                : base("conceptos_acelerador_reservas")
            {
                LocalTextPrefix = "Portal.ConceptosAceleradorReservas";
            }
        }
    }
}

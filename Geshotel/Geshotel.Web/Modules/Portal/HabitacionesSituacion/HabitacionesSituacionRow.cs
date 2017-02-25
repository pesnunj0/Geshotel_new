
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), TableName("habitaciones_situacion"), DisplayName("Habitaciones Situacion"), InstanceName("Habitaciones Situacion"), TwoLevelCached]
    [ReadPermission("Todos:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.HabitacionesSituacion")]
    public sealed class HabitacionesSituacionRow : Row, IIdRow, INameRow
    {
        [DisplayName("Situacion Id"), Column("situacion_id"), Identity]
        public Int16? SituacionId
        {
            get { return Fields.SituacionId[this]; }
            set { Fields.SituacionId[this] = value; }
        }

        [DisplayName("Situacion"), Column("Situacion"), Size(20), NotNull, QuickSearch]
        public String Situacion
        {
            get { return Fields.Situacion[this]; }
            set { Fields.Situacion[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.SituacionId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Situacion; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public HabitacionesSituacionRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field SituacionId;
            public StringField Situacion;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Portal.HabitacionesSituacion";
            }
        }
    }
}

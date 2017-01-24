
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CommonFiles"), DisplayName("grupos_habitacion"), InstanceName("grupos_habitacion"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.GruposHabitacion")]
    public sealed class GruposHabitacionRow : Row, IIdRow, INameRow
    {
        [DisplayName("Habitacion Id"), Column("grupo_habitacion_id"), PrimaryKey]
        public Int16? HabitacionId
        {
            get { return Fields.HabitacionId[this]; }
            set { Fields.HabitacionId[this] = value; }
        }

        [DisplayName("Habitacion"), Column("grupo_habitacion"), Size(15), NotNull, QuickSearch]
        public String Habitacion
        {
            get { return Fields.Habitacion[this]; }
            set { Fields.Habitacion[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.HabitacionId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Habitacion; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public GruposHabitacionRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field HabitacionId;
            public StringField Habitacion;

            public RowFields()
                : base("grupos_habitacion", "grupo_")
            {
                LocalTextPrefix = "Portal.GruposHabitacion";
            }
        }
    }
}

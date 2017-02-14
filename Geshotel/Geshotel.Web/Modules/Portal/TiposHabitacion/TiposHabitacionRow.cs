
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("tipos_habitacion"), InstanceName("tipos_habitacion"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.TiposHabitacion")]
    public sealed class TiposHabitacionRow : Row, IIdRow, INameRow
    {
        [DisplayName("Tipo Habitacion Id"), Column("tipo_habitacion_id"), Identity]
        public Int16? TipoHabitacionId
        {
            get { return Fields.TipoHabitacionId[this]; }
            set { Fields.TipoHabitacionId[this] = value; }
        }

        [DisplayName("Desc Corta"), Column("desc_corta"), Size(6), NotNull, QuickSearch]
        public String DescCorta
        {
            get { return Fields.DescCorta[this]; }
            set { Fields.DescCorta[this] = value; }
        }

        [DisplayName("Descripcion"), Column("descripcion"), Size(50), NotNull]
        public String Descripcion
        {
            get { return Fields.Descripcion[this]; }
            set { Fields.Descripcion[this] = value; }
        }

        [DisplayName("Grupo Habitacion Id"), Column("grupo_habitacion_id"), ForeignKey("grupos_habitacion", "grupo_habitacion_id"), LeftJoin("jGrupoHabitacion"), TextualField("GrupoHabitacion")]
        [LookupEditor(typeof(GruposHabitacionRow), InplaceAdd = true)]
        public Int16? GrupoHabitacionId
        {
            get { return Fields.GrupoHabitacionId[this]; }
            set { Fields.GrupoHabitacionId[this] = value; }
        }

        [DisplayName("Tipo Hab"), Expression("jGrupoHabitacion.[grupo_habitacion]")]
        public String GrupoHabitacion
        {
            get { return Fields.GrupoHabitacion[this]; }
            set { Fields.GrupoHabitacion[this] = value; }
        }

        [DisplayName("Numero Personas"), Column("numero_personas"), NotNull]
        public Int16? NumeroPersonas
        {
            get { return Fields.NumeroPersonas[this]; }
            set { Fields.NumeroPersonas[this] = value; }
        }

        [DisplayName("Desvios"), Column("desvios")]
        public Int16? Desvios
        {
            get { return Fields.Desvios[this]; }
            set { Fields.Desvios[this] = value; }
        }

        [DisplayName("No Show"), Column("no_show")]
        public Int16? NoShow
        {
            get { return Fields.NoShow[this]; }
            set { Fields.NoShow[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.TipoHabitacionId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Descripcion; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TiposHabitacionRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field TipoHabitacionId;
            public StringField DescCorta;
            public StringField Descripcion;
            public Int16Field GrupoHabitacionId;
            public Int16Field NumeroPersonas;
            public Int16Field Desvios;
            public Int16Field NoShow;

            public StringField GrupoHabitacion;

            public RowFields()
                : base("tipos_habitacion")
            {
                LocalTextPrefix = "Portal.TiposHabitacion";
            }
        }
    }
}

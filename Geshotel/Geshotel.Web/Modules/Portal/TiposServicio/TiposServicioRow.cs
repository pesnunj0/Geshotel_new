
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("tipos_servicio"), InstanceName("tipos_servicio"), TwoLevelCached]
    [ReadPermission("Todos:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.TiposServicio")]
    public sealed class TiposServicioRow : Row, IIdRow, INameRow
    {
        [DisplayName("Tipo Servicio Id"), Column("tipo_servicio_id"), Identity]
        public Int16? TipoServicioId
        {
            get { return Fields.TipoServicioId[this]; }
            set { Fields.TipoServicioId[this] = value; }
        }

        [DisplayName("Nombre Tipo Servicio"), Column("nombre_tipo_servicio"), Size(30), NotNull, QuickSearch]
        public String NombreTipoServicio
        {
            get { return Fields.NombreTipoServicio[this]; }
            set { Fields.NombreTipoServicio[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.TipoServicioId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.NombreTipoServicio; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TiposServicioRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field TipoServicioId;
            public StringField NombreTipoServicio;

            public RowFields()
                : base("tipos_servicio")
            {
                LocalTextPrefix = "Portal.TiposServicio";
            }
        }
    }
}

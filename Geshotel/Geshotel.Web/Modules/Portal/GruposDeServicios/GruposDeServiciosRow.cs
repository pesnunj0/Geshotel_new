
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("grupos_de_servicios"), InstanceName("grupos_de_servicios"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.GruposDeServicio")]
    public sealed class GruposDeServiciosRow : Row, IIdRow, INameRow
    {
        [DisplayName("Grupo Servicio Id"), Column("grupo_servicio_id"), Identity]
        public Int32? GrupoServicioId
        {
            get { return Fields.GrupoServicioId[this]; }
            set { Fields.GrupoServicioId[this] = value; }
        }

        [DisplayName("Nombre Grupo"), Column("nombre_grupo"), Size(255), NotNull, QuickSearch]
        public String NombreGrupo
        {
            get { return Fields.NombreGrupo[this]; }
            set { Fields.NombreGrupo[this] = value; }
        }

        [DisplayName("Cta Contable"), Column("cta_contable"), Size(16), NotNull]
        public String CtaContable
        {
            get { return Fields.CtaContable[this]; }
            set { Fields.CtaContable[this] = value; }
        }


        IIdField IIdRow.IdField
        {
            get { return Fields.GrupoServicioId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.NombreGrupo; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public GruposDeServiciosRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field GrupoServicioId;
            public StringField NombreGrupo;
            public StringField CtaContable;

            public RowFields()
                : base("grupos_de_servicios")
            {
                LocalTextPrefix = "Portal.GruposDeServicios";
            }
        }
    }
}

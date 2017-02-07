
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("Edades"), InstanceName("Edades"), TwoLevelCached]
    [ReadPermission("Contratos:General")]
    [ModifyPermission("Contratos:General")]
    public sealed class EdadesRow : Row, IIdRow
    {
        [DisplayName("Contrato Id"), Column("contrato_id"), PrimaryKey]
        public Int32? ContratoId
        {
            get { return Fields.ContratoId[this]; }
            set { Fields.ContratoId[this] = value; }
        }

        [DisplayName("Tipo Huesped Id"), Column("tipo_huesped_id"), PrimaryKey]
        public Int16? TipoHuespedId
        {
            get { return Fields.TipoHuespedId[this]; }
            set { Fields.TipoHuespedId[this] = value; }
        }

        [DisplayName("Edad Minima"), Column("edad_minima"), NotNull]
        public Int32? EdadMinima
        {
            get { return Fields.EdadMinima[this]; }
            set { Fields.EdadMinima[this] = value; }
        }

        [DisplayName("Edad Maxima"), Column("edad_maxima"), NotNull]
        public Int32? EdadMaxima
        {
            get { return Fields.EdadMaxima[this]; }
            set { Fields.EdadMaxima[this] = value; }
        }

        [DisplayName("User Id"), Column("user_id")]
        public Int16? UserId
        {
            get { return Fields.UserId[this]; }
            set { Fields.UserId[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ContratoId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public EdadesRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ContratoId;
            public Int16Field TipoHuespedId;
            public Int32Field EdadMinima;
            public Int32Field EdadMaxima;
            public Int16Field UserId;

            public RowFields()
                : base("[contratos_edades]")
            {
                LocalTextPrefix = "Contratos.Edades";
            }
        }
    }
}

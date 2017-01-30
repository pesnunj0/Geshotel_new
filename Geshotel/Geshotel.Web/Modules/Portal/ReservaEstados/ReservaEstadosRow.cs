
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("reserva_estados"), InstanceName("reserva_estados"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.ReservasEstados")]
    public sealed class ReservaEstadosRow : Row, IIdRow, INameRow
    {
        [DisplayName("Estado Reserva Id"), Column("estado_reserva_id"), PrimaryKey]
        public Int16? EstadoReservaId
        {
            get { return Fields.EstadoReservaId[this]; }
            set { Fields.EstadoReservaId[this] = value; }
        }

        [DisplayName("Estado"), Column("estado"), Size(20), NotNull, QuickSearch]
        public String Estado
        {
            get { return Fields.Estado[this]; }
            set { Fields.Estado[this] = value; }
        }

        [DisplayName("Es Error Fechaini"), Column("es_error_fechaini"), NotNull]
        public Int16? EsErrorFechaini
        {
            get { return Fields.EsErrorFechaini[this]; }
            set { Fields.EsErrorFechaini[this] = value; }
        }

        [DisplayName("Es Error Fechafin"), Column("es_error_fechafin"), NotNull]
        public Int16? EsErrorFechafin
        {
            get { return Fields.EsErrorFechafin[this]; }
            set { Fields.EsErrorFechafin[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.EstadoReservaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Estado; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ReservaEstadosRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field EstadoReservaId;
            public StringField Estado;
            public Int16Field EsErrorFechaini;
            public Int16Field EsErrorFechafin;

            public RowFields()
                : base("reserva_estados")
            {
                LocalTextPrefix = "Portal.ReservaEstados";
            }
        }
    }
}

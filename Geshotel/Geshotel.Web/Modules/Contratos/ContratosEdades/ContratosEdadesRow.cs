
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), TableName("[dbo].[contratos_edades]"), DisplayName("Contratos Edades"), InstanceName("Contratos Edades"), TwoLevelCached]
    [ReadPermission("Contratos:General")]
    [ModifyPermission("Contratos:General")]
    public sealed class ContratosEdadesRow : Row, IIdRow
    {
        [DisplayName("Contratos Edades Id"), Column("contratos_edades_id"), Identity]
        public Int32? ContratosEdadesId
        {
            get { return Fields.ContratosEdadesId[this]; }
            set { Fields.ContratosEdadesId[this] = value; }
        }

        [DisplayName("Hotel Id"), Column("hotel_id"), NotNull]
        public Int16? HotelId
        {
            get { return Fields.HotelId[this]; }
            set { Fields.HotelId[this] = value; }
        }

        [DisplayName("Cliente Id"), Column("cliente_id"), NotNull]
        public Int32? ClienteId
        {
            get { return Fields.ClienteId[this]; }
            set { Fields.ClienteId[this] = value; }
        }

        [DisplayName("Fecha Desde"), Column("fecha_desde"), NotNull]
        public DateTime? FechaDesde
        {
            get { return Fields.FechaDesde[this]; }
            set { Fields.FechaDesde[this] = value; }
        }

        [DisplayName("Fecha Hasta"), Column("fecha_hasta"), NotNull]
        public DateTime? FechaHasta
        {
            get { return Fields.FechaHasta[this]; }
            set { Fields.FechaHasta[this] = value; }
        }

        [DisplayName("Tipo Huesped Id"), Column("tipo_huesped_id"), NotNull]
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
        public Int32? UserId
        {
            get { return Fields.UserId[this]; }
            set { Fields.UserId[this] = value; }
        }

        [DisplayName("Fecha Modificacion"), Column("fecha_modificacion")]
        public DateTime? FechaModificacion
        {
            get { return Fields.FechaModificacion[this]; }
            set { Fields.FechaModificacion[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ContratosEdadesId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ContratosEdadesRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ContratosEdadesId;
            public Int16Field HotelId;
            public Int32Field ClienteId;
            public DateTimeField FechaDesde;
            public DateTimeField FechaHasta;
            public Int16Field TipoHuespedId;
            public Int32Field EdadMinima;
            public Int32Field EdadMaxima;
            public Int32Field UserId;
            public DateTimeField FechaModificacion;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Contratos.ContratosEdades";
            }
        }
    }
}

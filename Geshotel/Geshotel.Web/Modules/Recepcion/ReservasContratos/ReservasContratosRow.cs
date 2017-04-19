
namespace Geshotel.Recepcion.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), TableName("reservas_contratos"), DisplayName("Reservas Contratos"), InstanceName("Reservas Contratos"), TwoLevelCached]
    [ReadPermission("Recepcion:Hotel")]
    [ModifyPermission("Recepcion:Hotel")]
    public sealed class ReservasContratosRow : Row, IIdRow
    {
        [DisplayName("Reserva Contrato Id"), Column("reserva_contrato_id"), Identity]
        public Int32? ReservaContratoId
        {
            get { return Fields.ReservaContratoId[this]; }
            set { Fields.ReservaContratoId[this] = value; }
        }

        [DisplayName("Reserva Id"), Column("reserva_id"), NotNull]
        public Int32? ReservaId
        {
            get { return Fields.ReservaId[this]; }
            set { Fields.ReservaId[this] = value; }
        }

        [DisplayName("Contrato Id"), Column("contrato_id"), ForeignKey("contratos","contrato_id"),LeftJoin("jContratos"), NotNull]
        public Int32? ContratoId
        {
            get { return Fields.ContratoId[this]; }
            set { Fields.ContratoId[this] = value; }
        }
        [DisplayName("Fecha Desde"),Expression("jContratos.fecha_desde")]
        public DateTime? FechaDesde
        {
            get { return Fields.FechaDesde[this]; }
            set { Fields.FechaDesde[this] = value; }
        }

        [DisplayName("Fecha Hasta"), Expression("jContratos.fecha_hasta")]
        public DateTime? FechaHasta
        {
            get { return Fields.FechaHasta[this]; }
            set { Fields.FechaHasta[this] = value; }
        }
        [DisplayName("ClienteId"), Expression("jContratos.cliente_id"), ForeignKey("clientes","cliente_id"),LeftJoin("jClientes")]
        public Int32? ClienteId
        {
            get { return Fields.ClienteId[this]; }
            set { Fields.ClienteId[this] = value; }
        }
        [DisplayName("Cliente"), Expression("jClientes.razon")]
        public String ClienteName
        {
            get { return Fields.ClienteName[this]; }
            set { Fields.ClienteName[this] = value; }
        }

        [DisplayName("Directo"), Column("directo")]
        public Boolean? Directo
        {
            get { return Fields.Directo[this]; }
            set { Fields.Directo[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ReservaContratoId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ReservasContratosRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ReservaContratoId;
            public Int32Field ReservaId;
            public Int32Field ContratoId;
            public BooleanField Directo;

            public DateTimeField FechaDesde;
            public DateTimeField FechaHasta;
            public Int32Field ClienteId;
            public StringField ClienteName;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Recepcion.ReservasContratos";
            }
        }
    }
}

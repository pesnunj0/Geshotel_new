
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

        [DisplayName("Contrato Id"), Column("contrato_id"), NotNull]
        public Int32? ContratoId
        {
            get { return Fields.ContratoId[this]; }
            set { Fields.ContratoId[this] = value; }
        }

        [DisplayName("Directo"), Column("directo")]
        public Int16? Directo
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
            public Int16Field Directo;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Recepcion.ReservasContratos";
            }
        }
    }
}


namespace Geshotel.Recepcion.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), TableName("reservas_ofertas"), DisplayName("Reservas Ofertas"), InstanceName("Reservas Ofertas"), TwoLevelCached]
    [ReadPermission("Recepcion:Hotel")]
    [ModifyPermission("Recepcion:Hotel")]
    public sealed class ReservasOfertasRow : Row, IIdRow, INameRow
    {
        [DisplayName("Reserva Oferta Id"), Column("reserva_oferta_id"), Identity]
        public Int32? ReservaOfertaId
        {
            get { return Fields.ReservaOfertaId[this]; }
            set { Fields.ReservaOfertaId[this] = value; }
        }

        [DisplayName("Reserva Id"), Column("reserva_id"), NotNull]
        public Int32? ReservaId
        {
            get { return Fields.ReservaId[this]; }
            set { Fields.ReservaId[this] = value; }
        }

        [DisplayName("Oferta Id"), Column("oferta_id"), NotNull]
        public Int32? OfertaId
        {
            get { return Fields.OfertaId[this]; }
            set { Fields.OfertaId[this] = value; }
        }

        [DisplayName("Tipo"), Column("tipo"), Size(1), QuickSearch]
        public String Tipo
        {
            get { return Fields.Tipo[this]; }
            set { Fields.Tipo[this] = value; }
        }

        [DisplayName("Activa"), Column("activa")]
        public Int16? Activa
        {
            get { return Fields.Activa[this]; }
            set { Fields.Activa[this] = value; }
        }

        [DisplayName("Oferta Usada"), Column("oferta_usada")]
        public Int16? OfertaUsada
        {
            get { return Fields.OfertaUsada[this]; }
            set { Fields.OfertaUsada[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ReservaOfertaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Tipo; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ReservasOfertasRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ReservaOfertaId;
            public Int32Field ReservaId;
            public Int32Field OfertaId;
            public StringField Tipo;
            public Int16Field Activa;
            public Int16Field OfertaUsada;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Recepcion.ReservasOfertas";
            }
        }
    }
}

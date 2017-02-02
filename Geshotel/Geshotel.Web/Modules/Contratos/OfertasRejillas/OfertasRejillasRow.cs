
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("Ofertas Rejillas"), InstanceName("Ofertas Rejillas"), TwoLevelCached]
    [ReadPermission("Contratos:General")]
    [ModifyPermission("Contratos:General")]
    public sealed class OfertasRejillasRow : Row, IIdRow
    {
        [DisplayName("Rejilla Id"), Column("rejilla_id"), Identity]
        public Int32? RejillaId
        {
            get { return Fields.RejillaId[this]; }
            set { Fields.RejillaId[this] = value; }
        }

        [DisplayName("Oferta Id"), Column("oferta_id"), NotNull]
        public Int32? OfertaId
        {
            get { return Fields.OfertaId[this]; }
            set { Fields.OfertaId[this] = value; }
        }

        [DisplayName("N"), Column("n"), NotNull]
        public Int16? N
        {
            get { return Fields.N[this]; }
            set { Fields.N[this] = value; }
        }

        [DisplayName("Tipo Condicion Id"), Column("tipo_condicion_id")]
        public Int16? TipoCondicionId
        {
            get { return Fields.TipoCondicionId[this]; }
            set { Fields.TipoCondicionId[this] = value; }
        }

        [DisplayName("Tipo Aplicacion"), Column("tipo_aplicacion")]
        public Int16? TipoAplicacion
        {
            get { return Fields.TipoAplicacion[this]; }
            set { Fields.TipoAplicacion[this] = value; }
        }

        [DisplayName("M"), Column("m"), NotNull]
        public Double? M
        {
            get { return Fields.M[this]; }
            set { Fields.M[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.RejillaId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public OfertasRejillasRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field RejillaId;
            public Int32Field OfertaId;
            public Int16Field N;
            public Int16Field TipoCondicionId;
            public Int16Field TipoAplicacion;
            public DoubleField M;

            public RowFields()
                : base("[dbo].[ofertas_rejillas]")
            {
                LocalTextPrefix = "Contratos.OfertasRejillas";
            }
        }
    }
}


namespace Geshotel.Recepcion.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;
    using Geshotel.Portal.Entities;

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

        [DisplayName("Oferta Id"), Column("oferta_id"), NotNull, ForeignKey("ofertas","oferta_id"), LeftJoin("jOfertas"),TextualField("Texto")]
        public Int32? OfertaId
        {
            get { return Fields.OfertaId[this]; }
            set { Fields.OfertaId[this] = value; }
        }
        [DisplayName("Texto"), Expression("jOfertas.[texto]"), Size(60), NotNull, QuickSearch]
        public String Texto
        {
            get { return Fields.Texto[this]; }
            set { Fields.Texto[this] = value; }
        }

        [DisplayName("Unidad Calculo Id"), Expression("jOfertas.[unidad_calculo_id]"), ForeignKey("unidades_calculo", "unidad_calculo_id"), LeftJoin("jUC")]
        [LookupEditor(typeof(UnidadesCalculoRow))]
        public Int16? UnidadCalculoId
        {
            get { return Fields.UnidadCalculoId[this]; }
            set { Fields.UnidadCalculoId[this] = value; }
        }

        [DisplayName("Unidad Calculo"), Expression("jUC.descripcion_unidad_calculo")]
        public String UnidadCalculoName
        {
            get { return Fields.UnidadCalculoName[this]; }
            set { Fields.UnidadCalculoName[this] = value; }
        }

        [DisplayName("N"), Expression("jOfertas.n"), Size(3)]
        public Int16? N
        {
            get { return Fields.N[this]; }
            set { Fields.N[this] = value; }
        }

        [DisplayName("Tipo Oferta Id"), Expression("jOfertas.tipo_oferta_id"), ForeignKey("tipos_de_oferta", "tipo_oferta_id"), LeftJoin("jTipoOferta")]
        [LookupEditor(typeof(TiposDeOfertaRow))]
        public Int16? TipoOfertaId
        {
            get { return Fields.TipoOfertaId[this]; }
            set { Fields.TipoOfertaId[this] = value; }
        }

        [DisplayName("Tipo"), Expression("jTipoOferta.Oferta")]
        public String TipoOfertaName
        {
            get { return Fields.TipoOfertaName[this]; }
            set { Fields.TipoOfertaName[this] = value; }
        }

        [DisplayName("M"), Expression("jOfertas.m"), Size(15), Scale(3)]
        public Decimal? M
        {
            get { return Fields.M[this]; }
            set { Fields.M[this] = value; }
        }


        [DisplayName("Tipo"), Column("tipo"), Size(1), QuickSearch]
        public String Tipo
        {
            get { return Fields.Tipo[this]; }
            set { Fields.Tipo[this] = value; }
        }

        [DisplayName("Activa"), Column("activa")]
        public Boolean? Activa
        {
            get { return Fields.Activa[this]; }
            set { Fields.Activa[this] = value; }
        }

        [DisplayName("Oferta Usada"), Column("oferta_usada")]
        public Boolean? OfertaUsada
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
            public BooleanField Activa;
            public BooleanField OfertaUsada;

            public Int16Field UnidadCalculoId;
            public StringField Texto;
            public Int16Field N;
            public Int16Field TipoOfertaId;
            public DecimalField M;
            public StringField TipoOfertaName;
            public StringField UnidadCalculoName;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Recepcion.ReservasOfertas";
            }
        }
    }
}

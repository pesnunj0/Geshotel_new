
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("Ofertas"), InstanceName("Ofertas"), TwoLevelCached]
    [ReadPermission("Contratos:General")]
    [ModifyPermission("Contratos:General")]
    public sealed class OfertasRow : Row, IIdRow, INameRow
    {
        [DisplayName("Oferta Id"), Column("oferta_id"), Identity]
        public Int32? OfertaId
        {
            get { return Fields.OfertaId[this]; }
            set { Fields.OfertaId[this] = value; }
        }

        [DisplayName("Texto"), Column("texto"), Size(60), NotNull, QuickSearch]
        public String Texto
        {
            get { return Fields.Texto[this]; }
            set { Fields.Texto[this] = value; }
        }

        [DisplayName("Contrato Id"), Column("contrato_id"), NotNull]
        public Int32? ContratoId
        {
            get { return Fields.ContratoId[this]; }
            set { Fields.ContratoId[this] = value; }
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

        [DisplayName("Tipo Aplicacion Oferta Id"), Column("tipo_aplicacion_oferta_id"), Size(1), NotNull]
        public String TipoAplicacionOfertaId
        {
            get { return Fields.TipoAplicacionOfertaId[this]; }
            set { Fields.TipoAplicacionOfertaId[this] = value; }
        }

        [DisplayName("Aplicable Auto"), Column("aplicable_auto"), NotNull]
        public Boolean? AplicableAuto
        {
            get { return Fields.AplicableAuto[this]; }
            set { Fields.AplicableAuto[this] = value; }
        }

        [DisplayName("Fecha Reserva Desde"), Column("fecha_reserva_desde")]
        public DateTime? FechaReservaDesde
        {
            get { return Fields.FechaReservaDesde[this]; }
            set { Fields.FechaReservaDesde[this] = value; }
        }

        [DisplayName("Fecha Reserva Hasta"), Column("fecha_reserva_hasta")]
        public DateTime? FechaReservaHasta
        {
            get { return Fields.FechaReservaHasta[this]; }
            set { Fields.FechaReservaHasta[this] = value; }
        }

        [DisplayName("Estancia Minima Dias"), Column("estancia_minima_dias")]
        public Int16? EstanciaMinimaDias
        {
            get { return Fields.EstanciaMinimaDias[this]; }
            set { Fields.EstanciaMinimaDias[this] = value; }
        }

        [DisplayName("Estancia Maxima Dias"), Column("estancia_maxima_dias")]
        public Int16? EstanciaMaximaDias
        {
            get { return Fields.EstanciaMaximaDias[this]; }
            set { Fields.EstanciaMaximaDias[this] = value; }
        }

        [DisplayName("Dias De Antelacion"), Column("dias_de_antelacion")]
        public Int16? DiasDeAntelacion
        {
            get { return Fields.DiasDeAntelacion[this]; }
            set { Fields.DiasDeAntelacion[this] = value; }
        }

        [DisplayName("Tipo Servicio Id"), Column("tipo_servicio_id")]
        public Int16? TipoServicioId
        {
            get { return Fields.TipoServicioId[this]; }
            set { Fields.TipoServicioId[this] = value; }
        }

        [DisplayName("Servicio Id"), Column("servicio_id")]
        public Int32? ServicioId
        {
            get { return Fields.ServicioId[this]; }
            set { Fields.ServicioId[this] = value; }
        }

        [DisplayName("Unidad Calculo Id"), Column("unidad_calculo_id")]
        public Int16? UnidadCalculoId
        {
            get { return Fields.UnidadCalculoId[this]; }
            set { Fields.UnidadCalculoId[this] = value; }
        }

        [DisplayName("Servicio Ligado Id"), Column("servicio_ligado_id")]
        public Int32? ServicioLigadoId
        {
            get { return Fields.ServicioLigadoId[this]; }
            set { Fields.ServicioLigadoId[this] = value; }
        }

        [DisplayName("Cupo Oferta"), Column("cupo_oferta")]
        public Int16? CupoOferta
        {
            get { return Fields.CupoOferta[this]; }
            set { Fields.CupoOferta[this] = value; }
        }

        [DisplayName("Precio"), Column("precio"), Size(15), Scale(3)]
        public Decimal? Precio
        {
            get { return Fields.Precio[this]; }
            set { Fields.Precio[this] = value; }
        }

        [DisplayName("N"), Column("n"), Size(7), Scale(2)]
        public Decimal? N
        {
            get { return Fields.N[this]; }
            set { Fields.N[this] = value; }
        }

        [DisplayName("Tipo Oferta Id"), Column("tipo_oferta_id")]
        public Int16? TipoOfertaId
        {
            get { return Fields.TipoOfertaId[this]; }
            set { Fields.TipoOfertaId[this] = value; }
        }

        [DisplayName("M"), Column("m"), Size(15), Scale(3)]
        public Decimal? M
        {
            get { return Fields.M[this]; }
            set { Fields.M[this] = value; }
        }

        [DisplayName("Ambito Oferta Id"), Column("ambito_oferta_id")]
        public Int16? AmbitoOfertaId
        {
            get { return Fields.AmbitoOfertaId[this]; }
            set { Fields.AmbitoOfertaId[this] = value; }
        }

        [DisplayName("User Id"), Column("user_id")]
        public Int16? UserId
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

        [DisplayName("Impuesto Incluido"), Column("impuesto_incluido")]
        public Boolean? ImpuestoIncluido
        {
            get { return Fields.ImpuestoIncluido[this]; }
            set { Fields.ImpuestoIncluido[this] = value; }
        }

        [DisplayName("Tipo Imputacion Id"), Column("tipo_imputacion_id"), NotNull]
        public Int16? TipoImputacionId
        {
            get { return Fields.TipoImputacionId[this]; }
            set { Fields.TipoImputacionId[this] = value; }
        }

        [DisplayName("Orden Aplicacion"), Column("orden_aplicacion")]
        public Int16? OrdenAplicacion
        {
            get { return Fields.OrdenAplicacion[this]; }
            set { Fields.OrdenAplicacion[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.OfertaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Texto; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public OfertasRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field OfertaId;
            public StringField Texto;
            public Int32Field ContratoId;
            public DateTimeField FechaDesde;
            public DateTimeField FechaHasta;
            public StringField TipoAplicacionOfertaId;
            public BooleanField AplicableAuto;
            public DateTimeField FechaReservaDesde;
            public DateTimeField FechaReservaHasta;
            public Int16Field EstanciaMinimaDias;
            public Int16Field EstanciaMaximaDias;
            public Int16Field DiasDeAntelacion;
            public Int16Field TipoServicioId;
            public Int32Field ServicioId;
            public Int16Field UnidadCalculoId;
            public Int32Field ServicioLigadoId;
            public Int16Field CupoOferta;
            public DecimalField Precio;
            public DecimalField N;
            public Int16Field TipoOfertaId;
            public DecimalField M;
            public Int16Field AmbitoOfertaId;
            public Int16Field UserId;
            public DateTimeField FechaModificacion;
            public BooleanField ImpuestoIncluido;
            public Int16Field TipoImputacionId;
            public Int16Field OrdenAplicacion;

            public RowFields()
                : base("[dbo].[ofertas]")
            {
                LocalTextPrefix = "Contratos.Ofertas";
            }
        }
    }
}

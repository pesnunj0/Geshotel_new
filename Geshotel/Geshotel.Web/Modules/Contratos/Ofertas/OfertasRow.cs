
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;
    using Geshotel.Portal.Entities;

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

        [DisplayName("Tipo Aplicacion"), Column("tipo_aplicacion_oferta_id"), ForeignKey("tipo_aplicacion_oferta", "tipo_aplicacion_oferta_id"),LeftJoin("jTipoAplicacionOferta"),Size(1), NotNull]
        [LookupEditor(typeof(TipoAplicacionOfertaRow))]
        public String TipoAplicacionOfertaId
        {
            get { return Fields.TipoAplicacionOfertaId[this]; }
            set { Fields.TipoAplicacionOfertaId[this] = value; }
        }

        [DisplayName("Tipo Aplicacion"), Expression("jTipoAplicacionOferta.aplicable_segun_fecha_de")]
        public String TipoAplicacionOfertaName
        {
            get { return Fields.TipoAplicacionOfertaName[this]; }
            set { Fields.TipoAplicacionOfertaName[this] = value; }
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

        [DisplayName("Tipo Servicio Id"), Column("tipo_servicio_id"), ForeignKey("tipos_servicio","tipo_servicio_id"), LeftJoin("jTiposServicio")]
        [LookupEditor(typeof(TiposServicioRow))]
        public Int16? TipoServicioId
        {
            get { return Fields.TipoServicioId[this]; }
            set { Fields.TipoServicioId[this] = value; }
        }

        [DisplayName("Tipo Servicio"), Expression("jTiposServicio.nombre_tipo_servicio")]
        public String TipoServicioName
        {
            get { return Fields.TipoServicioName[this]; }
            set { Fields.TipoServicioName[this] = value; }
        }

        [DisplayName("Servicio Id"), Column("servicio_id"), ForeignKey("servicios","servicio_id"),LeftJoin("jServicios")]
        [LookupEditor(typeof(ServiciosRow))]
        public Int32? ServicioId
        {
            get { return Fields.ServicioId[this]; }
            set { Fields.ServicioId[this] = value; }
        }

        [DisplayName("Servicio"), Expression("jServicios.nombre_servicio")]
        public String ServicioName
        {
            get { return Fields.ServicioName[this]; }
            set { Fields.ServicioName[this] = value; }
        }


        [DisplayName("Unidad Calculo Id"), Column("unidad_calculo_id"),ForeignKey("unidades_calculo","unidad_calculo_id"),LeftJoin("jUC")]
        [LookupEditor(typeof(UnidadesCalculoRow))]
        public Int16? UnidadCalculoId
        {
            get { return Fields.UnidadCalculoId[this]; }
            set { Fields.UnidadCalculoId[this] = value; }
        }

        [DisplayName("Unidad Calculo"), Expression("jUC.uc")]
        public String UnidadCalculoName
        {
            get { return Fields.UnidadCalculoName[this]; }
            set { Fields.UnidadCalculoName[this] = value; }
        }

        [DisplayName("Servicio Ligado"), Column("servicio_ligado_id"),ForeignKey("servicios","servicio_id"),LeftJoin("jServicioLigado")]
        [LookupEditor(typeof(ServiciosRow))]
        public Int32? ServicioLigadoId
        {
            get { return Fields.ServicioLigadoId[this]; }
            set { Fields.ServicioLigadoId[this] = value; }
        }

        [DisplayName("Servicio Ligado"), Expression("jServicioLigado.servicio")]
        public String ServicioLigadoName
        {
            get { return Fields.ServicioLigadoName[this]; }
            set { Fields.ServicioLigadoName[this] = value; }
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

        [DisplayName("Tipo Oferta Id"), Column("tipo_oferta_id"),ForeignKey("tipos_de_oferta","tipo_oferta_id"),LeftJoin("jTipoOferta")]
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

        [DisplayName("M"), Column("m"), Size(15), Scale(3)]
        public Decimal? M
        {
            get { return Fields.M[this]; }
            set { Fields.M[this] = value; }
        }

        [DisplayName("Ambito Oferta Id"), Column("ambito_oferta_id"),ForeignKey("ambito_oferta","ambito_oferta_id"),LeftJoin("jAmbito")]
        [LookupEditor(typeof(AmbitoOfertaRow))]
        public Int16? AmbitoOfertaId
        {
            get { return Fields.AmbitoOfertaId[this]; }
            set { Fields.AmbitoOfertaId[this] = value; }
        }

        [DisplayName("Ambito"), Expression("jAmbito.nombre")]
        public String AmbitoOfertaName
        {
            get { return Fields.AmbitoOfertaName[this]; }
            set { Fields.AmbitoOfertaName[this] = value; }
        }

        [DisplayName("User Id"), Column("user_id"),ForeignKey("Users","UserID"),LeftJoin("jUsers")]
        [LookupEditor(typeof(Geshotel.Administration.Entities.UserRow))]
        public Int32? UserId
        {
            get { return Fields.UserId[this]; }
            set { Fields.UserId[this] = value; }
        }

        [DisplayName("Usuario"), Expression("jUsers.Username")]
        public String UserName
        {
            get { return Fields.UserName[this]; }
            set { Fields.UserName[this] = value; }
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

        [DisplayName("Imputacion"), Column("tipo_imputacion_id"), ForeignKey("tipos_de_imputacion","tipo_imputacion_id"),LeftJoin("jTipoImputacion") NotNull]
        [LookupEditor(typeof(TiposDeImputacionRow))]
        public Int16? TipoImputacionId
        {
            get { return Fields.TipoImputacionId[this]; }
            set { Fields.TipoImputacionId[this] = value; }
        }

        [DisplayName("Imputacion"), Expression("jTipoImputacion.imputacion")]
        public String TipoImputacionName
        {
            get { return Fields.TipoImputacionName[this]; }
            set { Fields.TipoImputacionName[this] = value; }
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
            public Int32Field UserId;
            public DateTimeField FechaModificacion;
            public BooleanField ImpuestoIncluido;
            public Int16Field TipoImputacionId;
            public Int16Field OrdenAplicacion;

            public StringField AmbitoOfertaName;
            public StringField TipoOfertaName;
            public StringField TipoServicioName;
            public StringField ServicioName;
            public StringField ServicioLigadoName;
            public StringField UnidadCalculoName;
            public StringField UserName;
            public StringField TipoAplicacionOfertaName;
            public StringField TipoImputacionName;


            public RowFields()
                : base("[ofertas]")
            {
                LocalTextPrefix = "Contratos.Ofertas";
            }
        }
    }
}

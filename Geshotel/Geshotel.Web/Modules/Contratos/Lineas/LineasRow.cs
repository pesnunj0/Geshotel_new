
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

    [ConnectionKey("Default"), DisplayName("Lineas"), InstanceName("Lineas"), TwoLevelCached]
    [ReadPermission("Contratos:General")]
    [ModifyPermission("Contratos:Empresa")]
 //   [ForeignKey("servicios","servicio_id")]
    public sealed class LineasRow : Row, IIdRow
    {
        [DisplayName("Linea Contrato Id"), Column("linea_contrato_id"), Identity]
        public Int32? LineaContratoId
        {
            get { return Fields.LineaContratoId[this]; }
            set { Fields.LineaContratoId[this] = value; }
        }

        [DisplayName("Contrato Id"), Column("contrato_id"), NotNull]
        public Int32? ContratoId
        {
            get { return Fields.ContratoId[this]; }
            set { Fields.ContratoId[this] = value; }
        }

        [DisplayName("Oferta"), Column("oferta")]
        public Boolean? Oferta
        {
            get { return Fields.Oferta[this]; }
            set { Fields.Oferta[this] = value; }
        }

        [DisplayName("Desde"), Column("desde"), NotNull]
        public DateTime? Desde
        {
            get { return Fields.Desde[this]; }
            set { Fields.Desde[this] = value; }
        }

        [DisplayName("Hasta"), Column("hasta"), NotNull]
        public DateTime? Hasta
        {
            get { return Fields.Hasta[this]; }
            set { Fields.Hasta[this] = value; }
        }

        [DisplayName("Servicio"), Column("servicio_id"), NotNull, ForeignKey("servicios","servicio_id"), LeftJoin("jServicios"), TextualField("Servicio")]
        [LookupEditor(typeof(ServiciosRow))]
        public Int32? ServicioId
        {
            get { return Fields.ServicioId[this]; }
            set { Fields.ServicioId[this] = value; }
        }

        [DisplayName("Servicio"),Expression("jServicios.[nombre_servicio]")]
        public String Servicio
        {
            get { return Fields.Servicio[this]; }
            set { Fields.Servicio[this] = value; }
        }
        [DisplayName("Tipo Servicio"), Expression("jservicios.[tipo_servicio_id]"), ForeignKey("tipos_servicio","tipo_servicio_id"), LeftJoin("jTiposServicio")]
        [LookupEditor(typeof(TiposServicioRow))]
        public Int16? TipoServicioId
        {
            get { return Fields.TipoServicioId[this]; }
            set { Fields.TipoServicioId[this] = value; }
        }

        [DisplayName("Tipo Servicio"), Expression("jTiposServicio.[nombre_tipo_servicio]")]
        public String TipoServicio
        {
            get { return Fields.TipoServicio[this]; }
            set { Fields.TipoServicio[this] = value; }
        }

        [DisplayName("U. Calculo"), Column("unidad_calculo_id"), NotNull, ForeignKey("unidades_calculo", "unidad_calculo_id"), LeftJoin("jUc"), TextualField("DescripcionUnidadCalculo")]
        [LookupEditor(typeof(Geshotel.Portal.Entities.UnidadesCalculoRow))]
        public Int16? UnidadCalculoId
        {
            get { return Fields.UnidadCalculoId[this]; }
            set { Fields.UnidadCalculoId[this] = value; }
        }

        [DisplayName("U. Calculo"), Expression("jUc.descripcion_unidad_calculo")]
        public String DescripcionUnidadCalculo
        {
            get { return Fields.DescripcionUnidadCalculo[this]; }
            set { Fields.DescripcionUnidadCalculo[this] = value; }
        }

        [DisplayName("Frecuencia"), Column("frecuencia_id"), NotNull, DefaultValue(2),ForeignKey("frecuencia_facturacion", "frecuencia_id"), LeftJoin("jFrecuencia"), TextualField("Frecuencia")]
        [LookupEditor(typeof(FrecuenciaFacturacionRow))]
        public Int16? FrecuenciaId
        {
            get { return Fields.FrecuenciaId[this]; }
            set { Fields.FrecuenciaId[this] = value; }
        }

        [DisplayName("Frecuencia"), Expression("jFrecuencia.[descripcion]")]
        public String Frecuencia
        {
            get { return Fields.Frecuencia[this]; }
            set { Fields.Frecuencia[this] = value; }
        }


        [DisplayName("Imputacion"), Column("tipo_imputacion_id"),NotNull,DefaultValue(0), ForeignKey("tipos_de_imputacion", "tipo_imputacion_id"), LeftJoin("jImputacion"), TextualField("Imputacion")]
        [LookupEditor(typeof(TiposDeImputacionRow))]
        public Int16? TipoImputacionId
        {
            get { return Fields.TipoImputacionId[this]; }
            set { Fields.TipoImputacionId[this] = value; }
        }

        [DisplayName("Imputacion"), Expression("jImputacion.[imputacion]")]
        public String Imputacion
        {
            get { return Fields.Imputacion[this]; }
            set { Fields.Imputacion[this] = value; }
        }


        [DisplayName("Importe"), Column("importe"), NotNull]
        public Double? Importe
        {
            get { return Fields.Importe[this]; }
            set { Fields.Importe[this] = value; }
        }

        //[DisplayName("N"), Column("n")]
        //public Int16? N
        //{
        //    get { return Fields.N[this]; }
        //    set { Fields.N[this] = value; }
        //}

        //[DisplayName("Tipo Oferta Id"), Column("tipo_oferta_id"), ForeignKey("tipos_oferta", "tipo_oferta_id"), LeftJoin("jTipoOferta"), TextualField("Frecuencia")]
        //[LookupEditor(typeof(FrecuenciaFacturacionRow))]
        //public Int16? TipoOfertaId
        //{
        //    get { return Fields.TipoOfertaId[this]; }
        //    set { Fields.TipoOfertaId[this] = value; }
        //}

        //[DisplayName("M"), Column("m")]
        //public Double? M
        //{
        //    get { return Fields.M[this]; }
        //    set { Fields.M[this] = value; }
        //}

        //[DisplayName("Ambito Oferta Id"), Column("ambito_oferta_id")]
        //public Int16? AmbitoOfertaId
        //{
        //    get { return Fields.AmbitoOfertaId[this]; }
        //    set { Fields.AmbitoOfertaId[this] = value; }
        //}

        [DisplayName("Lunes"), Column("lunes"), NotNull]
        public Boolean? Lunes
        {
            get { return Fields.Lunes[this]; }
            set { Fields.Lunes[this] = value; }
        }

        [DisplayName("Martes"), Column("martes"), NotNull]
        public Boolean? Martes
        {
            get { return Fields.Martes[this]; }
            set { Fields.Martes[this] = value; }
        }

        [DisplayName("Miercoles"), Column("miercoles"), NotNull]
        public Boolean? Miercoles
        {
            get { return Fields.Miercoles[this]; }
            set { Fields.Miercoles[this] = value; }
        }

        [DisplayName("Jueves"), Column("jueves"), NotNull]
        public Boolean? Jueves
        {
            get { return Fields.Jueves[this]; }
            set { Fields.Jueves[this] = value; }
        }

        [DisplayName("Viernes"), Column("viernes"), NotNull]
        public Boolean? Viernes
        {
            get { return Fields.Viernes[this]; }
            set { Fields.Viernes[this] = value; }
        }

        [DisplayName("Sabado"), Column("sabado"), NotNull]
        public Boolean? Sabado
        {
            get { return Fields.Sabado[this]; }
            set { Fields.Sabado[this] = value; }
        }

        [DisplayName("Domingo"), Column("domingo"), NotNull]
        public Boolean? Domingo
        {
            get { return Fields.Domingo[this]; }
            set { Fields.Domingo[this] = value; }
        }

        [DisplayName("Pag Factura"), Column("pag_factura"),Size(1)]
        public Int16? PagFactura
        {
            get { return Fields.PagFactura[this]; }
            set { Fields.PagFactura[this] = value; }
        }

        [DisplayName("Usuario"), Column("user_id"), ForeignKey("users", "UserId"), LeftJoin("jUser"), TextualField("Usuario")]
        [LookupEditor(typeof(Geshotel.Administration.Entities.UserRow))]

        public Int32? UserId
        {
            get { return Fields.UserId[this]; }
            set { Fields.UserId[this] = value; }
        }

        [DisplayName("Usuario"), Expression("jUser.[Username]")]
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

        IIdField IIdRow.IdField
        {
            get { return Fields.LineaContratoId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public LineasRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field LineaContratoId;
            public Int32Field ContratoId;
            public BooleanField Oferta;
            public DateTimeField Desde;
            public DateTimeField Hasta;
            public Int32Field ServicioId;
            public Int16Field UnidadCalculoId;
            public Int16Field FrecuenciaId;
            public Int16Field TipoImputacionId;
            public DoubleField Importe;
            public Int16Field TipoServicioId;
            //public Int16Field N;
            //public Int16Field TipoOfertaId;
            //public DoubleField M;
            //public Int16Field AmbitoOfertaId;
            public BooleanField Lunes;
            public BooleanField Martes;
            public BooleanField Miercoles;
            public BooleanField Jueves;
            public BooleanField Viernes;
            public BooleanField Sabado;
            public BooleanField Domingo;
            public Int16Field PagFactura;
            public Int32Field UserId;
            public DateTimeField FechaModificacion;

            public StringField Servicio;
            public StringField DescripcionUnidadCalculo;
            public StringField Frecuencia;
            public StringField Imputacion;
            public StringField UserName;
            public StringField TipoServicio;

            public RowFields()
                : base("[lineas_de_contrato]")
            {
                LocalTextPrefix = "Contratos.Lineas";
            }
        }
    }
}

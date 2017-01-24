
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CommonFiles"), DisplayName("servicios"), InstanceName("servicios"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.Servicios")]
    public sealed class ServiciosRow : Row, IIdRow, INameRow
    {
        [DisplayName("Servicio Id"), Column("servicio_id"), Identity]
        public Int32? ServicioId
        {
            get { return Fields.ServicioId[this]; }
            set { Fields.ServicioId[this] = value; }
        }

        [DisplayName("Nombre Servicio"), Column("nombre_servicio"), Size(50), NotNull, QuickSearch]
        public String NombreServicio
        {
            get { return Fields.NombreServicio[this]; }
            set { Fields.NombreServicio[this] = value; }
        }

        [DisplayName("Abreviatura"), Column("abreviatura"), Size(6), NotNull]
        public String Abreviatura
        {
            get { return Fields.Abreviatura[this]; }
            set { Fields.Abreviatura[this] = value; }
        }

        [DisplayName("Tipo Servicio"), Column("tipo_servicio_id"), NotNull, ForeignKey("tipos_servicio", "tipo_servicio_id"), LeftJoin("jTipoServicio"), TextualField("TipoServicioNombreTipoServicio")]
        [LookupEditor(typeof(TiposServicioRow), InplaceAdd = true)]
        public Int16? TipoServicioId
        {
            get { return Fields.TipoServicioId[this]; }
            set { Fields.TipoServicioId[this] = value; }
        }

        [DisplayName("Tipo Unidad Calculo"), Column("tipo_unidad_calculo_id"), NotNull, ForeignKey("tipos_unidad_calculo", "tipo_unidad_calculo_id"), LeftJoin("jTipoUC"), TextualField("Tipo_UC")]
        [LookupEditor(typeof(TiposUnidadCalculoRow), InplaceAdd = true)]
        public Int16? TipoUnidadCalculoId
        {
            get { return Fields.TipoUnidadCalculoId[this]; }
            set { Fields.TipoUnidadCalculoId[this] = value; }
        }
        [DisplayName("Suma Servicio Id"), Column("suma_servicio_id"), ForeignKey("servicios", "servicio_id"), LeftJoin("jSuma"), TextualField("SumaServicio")]
        [LookupEditor(typeof(ServiciosRow))]
        public Int32? SumaServicioId
        {
            get { return Fields.SumaServicioId[this]; }
            set { Fields.SumaServicioId[this] = value; }
        }

        [DisplayName("Suma"), Expression("jSuma.[nombre_servicio]")]
        public String Suma
        {
            get { return Fields.Suma[this]; }
            set { Fields.Suma[this] = value; }
        }

        [DisplayName("Resta Servicio Id"), Column("resta_servicio_id"), ForeignKey("servicios", "servicio_id"), LeftJoin("jResta"), TextualField("RestaServicio")]
        [LookupEditor(typeof(ServiciosRow))]
        public Int32? RestaServicioId
        {
            get { return Fields.RestaServicioId[this]; }
            set { Fields.RestaServicioId[this] = value; }
        }

        [DisplayName("Resta"), Expression("jResta.[nombre_servicio]")]
        public String Resta
        {
            get { return Fields.Resta[this]; }
            set { Fields.Resta[this] = value; }
        }

        [DisplayName("Tipo Hab"), Column("tipo_hab"),ForeignKey("grupos_habitacion", "grupo_habitacion_id"), LeftJoin("jHab"), TextualField("TipoHabitacion")]
        [LookupEditor(typeof(GruposHabitacionRow), InplaceAdd = true)]
        public Int16? TipoHab
        {
            get { return Fields.TipoHab[this]; }
            set { Fields.TipoHab[this] = value; }
        }

        [DisplayName("Tipo Hab"), Expression("jHab.[grupo_habitacion]")]
        public String NombreTipoHab
        {
            get { return Fields.NombreTipoHab[this]; }
            set { Fields.NombreTipoHab[this] = value; }
        }

        [DisplayName("Tipo Pension"), Column("tipo_pension"), ForeignKey("tipos_pension", "tipo_pension_id"), LeftJoin("jPension"), TextualField("TipoPension")]
        [LookupEditor(typeof(TiposPensionRow), InplaceAdd = true)]
        public Int16? TipoPension
        {
            get { return Fields.TipoPension[this]; }
            set { Fields.TipoPension[this] = value; }
        }

        [DisplayName("Tipo Pension"), Expression("jPension.[Tipo_pension]")]
        public String NombreTipoPension
        {
            get { return Fields.NombreTipoPension[this]; }
            set { Fields.NombreTipoPension[this] = value; }
        }

        [DisplayName("Concepto Acelerador Reservas Id"), Column("concepto_acelerador_reservas_id"),ForeignKey("conceptos_acelerador_reservas", "concepto_acelerador_id"), LeftJoin("jacel"), TextualField("concepto_acelerador")]
        [LookupEditor(typeof(ConceptosAceleradorReservasRow))]
        public Int16? ConceptoAceleradorReservasId
        {
            get { return Fields.ConceptoAceleradorReservasId[this]; }
            set { Fields.ConceptoAceleradorReservasId[this] = value; }
        }
        [DisplayName("Concepto Acel."),Expression("jacel.[concepto]")]
        public String Concepto
        {
            get { return Fields.Concepto[this]; }
            set { Fields.Concepto[this] = value; }
        }

        [DisplayName("Tipo Servicio Nombre Tipo Servicio"), Expression("jTipoServicio.[nombre_tipo_servicio]")]
        public String TipoServicioNombreTipoServicio
        {
            get { return Fields.TipoServicioNombreTipoServicio[this]; }
            set { Fields.TipoServicioNombreTipoServicio[this] = value; }
        }

        [DisplayName("Tipo Unidad Calculo"), Expression("jTipoUC.[tipo_uc]")]
        public string Tipo_UC
        {
            get { return Fields.Tipo_UC[this]; }
            set { Fields.Tipo_UC[this] = value; }
        }

        [DisplayName("Sw Produccion"), Column("sw_produccion"), Size(4), NotNull]
        public Boolean? SwProduccion
        {
            get { return Fields.SwProduccion[this]; }
            set { Fields.SwProduccion[this] = value; }
        }

        [DisplayName("Sw Descuento"), Column("sw_descuento"), Size(4)]
        public Boolean? SwDescuento
        {
            get { return Fields.SwDescuento[this]; }
            set { Fields.SwDescuento[this] = value; }
        }

        [DisplayName("Sw Ajustes"), Column("sw_ajustes"), Size(4)]
        public Boolean? SwAjustes
        {
            get { return Fields.SwAjustes[this]; }
            set { Fields.SwAjustes[this] = value; }
        }

        [DisplayName("Sw Gastos"), Column("sw_gastos"), Size(4)]
        public Boolean? SwGastos
        {
            get { return Fields.SwGastos[this]; }
            set { Fields.SwGastos[this] = value; }
        }

        [DisplayName("Sw Pension"), Column("sw_pension"), Size(4), NotNull]
        public Boolean? SwPension
        {
            get { return Fields.SwPension[this]; }
            set { Fields.SwPension[this] = value; }
        }

        [DisplayName("Sw Rectificativa"), Column("sw_rectificativa"), Size(4)]
        public Boolean? SwRectificativa
        {
            get { return Fields.SwRectificativa[this]; }
            set { Fields.SwRectificativa[this] = value; }
        }

        [DisplayName("Costo"), Column("costo")]
        public Double? Costo
        {
            get { return Fields.Costo[this]; }
            set { Fields.Costo[this] = value; }
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

        IIdField IIdRow.IdField
        {
            get { return Fields.ServicioId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.NombreServicio; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ServiciosRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ServicioId;
            public StringField NombreServicio;
            public StringField Abreviatura;
            public Int16Field TipoServicioId;
            public BooleanField SwProduccion;
            public BooleanField SwDescuento;
            public BooleanField SwAjustes;
            public BooleanField SwGastos;
            public BooleanField SwPension;
            public BooleanField SwRectificativa;
            public Int16Field TipoUnidadCalculoId;
            public Int16Field ConceptoAceleradorReservasId;
            public DoubleField Costo;
            public Int32Field SumaServicioId;
            public Int32Field RestaServicioId;
            public Int16Field UserId;
            public DateTimeField FechaModificacion;
            public Int16Field TipoHab;
            public Int16Field TipoPension;
            public StringField TipoServicioNombreTipoServicio;
            public StringField Tipo_UC;
            public StringField Concepto;
            public StringField Suma;
            public StringField Resta;
            public StringField NombreTipoHab;
            public StringField NombreTipoPension;

            public RowFields()
                : base("servicios")
            {
                LocalTextPrefix = "Portal.Servicios";
            }
        }
    }
}

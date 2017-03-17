
namespace Geshotel.Contratos.Entities
{
    using Portal.Entities;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), TableName("[dbo].[habitaciones]"), DisplayName("Habitaciones"), InstanceName("Habitaciones"), TwoLevelCached]
    [ReadPermission("Todos:General")]
    [ModifyPermission("Contratos:Empresa")]
    public sealed class HabitacionesRow : Row, IIdRow, INameRow,  ITenantRow
    {
        public Int16Field HotelIdField
        {
            get { return null; }
        }
        public Int16Field EmpresaIdField
        {
            get { return Fields.EmpresaId; }
        }

        [DisplayName("Habitacion Id"), Column("habitacion_id"), Identity]
        public Int16? HabitacionId
        {
            get { return Fields.HabitacionId[this]; }
            set { Fields.HabitacionId[this] = value; }
        }

        [DisplayName("Hotel"), Column("hotel_id"), NotNull, ForeignKey("[hoteles]", "hotel_id"), LeftJoin("jHotel"), TextualField("Hotel")]
        [LookupEditor("Portal.Hoteles")]
        public Int16? HotelId
        {
            get { return Fields.HotelId[this]; }
            set { Fields.HotelId[this] = value; }
        }

        [DisplayName("Numero Habitacion"), Column("numero_habitacion"), Size(8), NotNull, QuickSearch]
        public String NumeroHabitacion
        {
            get { return Fields.NumeroHabitacion[this]; }
            set { Fields.NumeroHabitacion[this] = value; }
        }

        [DisplayName("Tipo Habitacion"), Column("tipo_habitacion_id"), NotNull, ForeignKey("[tipos_habitacion]", "tipo_habitacion_id"), LeftJoin("jTipoHabitacion"), TextualField("TipoHabitacionDescCorta")]
        [LookupEditor("Contratos.TiposHabitacionHotel")]
        public Int16? TipoHabitacionId
        {
            get { return Fields.TipoHabitacionId[this]; }
            set { Fields.TipoHabitacionId[this] = value; }
        }

        [DisplayName("Extension"), Column("extension")]
        public Int16? Extension
        {
            get { return Fields.Extension[this]; }
            set { Fields.Extension[this] = value; }
        }

        [DisplayName("Observaciones"), Column("observaciones"), Size(255)]
        public String Observaciones
        {
            get { return Fields.Observaciones[this]; }
            set { Fields.Observaciones[this] = value; }
        }

        [DisplayName("Situacion"), Column("situacion_id"), ForeignKey("[habitaciones_situacion]", "situacion_id"), LeftJoin("jSituacion"), TextualField("Situacion")]
        [LookupEditor(typeof(HabitacionesSituacionRow))]
        public Int16? SituacionId
        {
            get { return Fields.SituacionId[this]; }
            set { Fields.SituacionId[this] = value; }
        }

        [DisplayName("Fecha Inicio"), Column("fecha_inicio")]
        public DateTime? FechaInicio
        {
            get { return Fields.FechaInicio[this]; }
            set { Fields.FechaInicio[this] = value; }
        }

        [DisplayName("Estado Telefono"), Column("estado_telefono")]
        public Int16? EstadoTelefono
        {
            get { return Fields.EstadoTelefono[this]; }
            set { Fields.EstadoTelefono[this] = value; }
        }

        [DisplayName("Estado Procesado"), Column("estado_procesado")]
        public Int16? EstadoProcesado
        {
            get { return Fields.EstadoProcesado[this]; }
            set { Fields.EstadoProcesado[this] = value; }
        }

        [DisplayName("Habitacion Ista"), Column("habitacion_ista"), Size(20)]
        public String HabitacionIsta
        {
            get { return Fields.HabitacionIsta[this]; }
            set { Fields.HabitacionIsta[this] = value; }
        }

        [DisplayName("Zona Limpieza"), Column("zona_limpieza_id"), ForeignKey("[zonas_limpieza]", "zona_limpieza_id"), LeftJoin("jZonaLimpieza"), TextualField("ZonaLimpiezaNombreZona")]
        public Int16? ZonaLimpiezaId
        {
            get { return Fields.ZonaLimpiezaId[this]; }
            set { Fields.ZonaLimpiezaId[this] = value; }
        }

        [DisplayName("Lat"), Column("lat"), Size(15), Scale(10)]
        public Decimal? Lat
        {
            get { return Fields.Lat[this]; }
            set { Fields.Lat[this] = value; }
        }

        [DisplayName("Lng"), Column("lng"), Size(15), Scale(10)]
        public Decimal? Lng
        {
            get { return Fields.Lng[this]; }
            set { Fields.Lng[this] = value; }
        }

        [DisplayName("Primary Image"), Column("primary_image"), Size(100)]
        public String PrimaryImage
        {
            get { return Fields.PrimaryImage[this]; }
            set { Fields.PrimaryImage[this] = value; }
        }

        [DisplayName("Galleryimages"), Column("galleryimages"), Size(-1)]
        public String Galleryimages
        {
            get { return Fields.Galleryimages[this]; }
            set { Fields.Galleryimages[this] = value; }
        }

        [DisplayName("Planta"), Column("planta")]
        public Int16? Planta
        {
            get { return Fields.Planta[this]; }
            set { Fields.Planta[this] = value; }
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

        [DisplayName("Hotel"), Expression("jHotel.[hotel]")]
        public String Hotel
        {
            get { return Fields.Hotel[this]; }
            set { Fields.Hotel[this] = value; }
        }

        [DisplayName("Hotel Empresa Id"), Expression("jHotel.[empresa_id]")]
        public Int16? EmpresaId
        {
            get { return Fields.EmpresaId[this]; }
            set { Fields.EmpresaId[this] = value; }
        }

  

        [DisplayName("Tipo Habitacion Desc Corta"), Expression("jTipoHabitacion.[desc_corta]")]
        public String TipoHabitacionDescCorta
        {
            get { return Fields.TipoHabitacionDescCorta[this]; }
            set { Fields.TipoHabitacionDescCorta[this] = value; }
        }

        [DisplayName("Tipo Habitacion Descripcion"), Expression("jTipoHabitacion.[descripcion]")]
        public String TipoHabitacionDescripcion
        {
            get { return Fields.TipoHabitacionDescripcion[this]; }
            set { Fields.TipoHabitacionDescripcion[this] = value; }
        }

 
        [DisplayName("Situacion"), Expression("jSituacion.[situacion]")]
        public String Situacion
        {
            get { return Fields.Situacion[this]; }
            set { Fields.Situacion[this] = value; }
        }

 
        [DisplayName("Zona Limpieza Nombre Zona"), Expression("jZonaLimpieza.[nombre_zona]")]
        public String ZonaLimpiezaNombreZona
        {
            get { return Fields.ZonaLimpiezaNombreZona[this]; }
            set { Fields.ZonaLimpiezaNombreZona[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.HabitacionId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.NumeroHabitacion; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public HabitacionesRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field HabitacionId;
            public Int16Field HotelId;
            public StringField NumeroHabitacion;
            public Int16Field TipoHabitacionId;
            public Int16Field Extension;
            public StringField Observaciones;
            public Int16Field SituacionId;
            public DateTimeField FechaInicio;
            public Int16Field EstadoTelefono;
            public Int16Field EstadoProcesado;
            public StringField HabitacionIsta;
            public Int16Field ZonaLimpiezaId;
            public DecimalField Lat;
            public DecimalField Lng;
            public StringField PrimaryImage;
            public StringField Galleryimages;
            public Int16Field Planta;
            public Int32Field UserId;
            public DateTimeField FechaModificacion;

            public StringField Hotel;
            public Int16Field EmpresaId;
 
            public StringField TipoHabitacionDescCorta;
            public StringField TipoHabitacionDescripcion;

            public StringField Situacion;

            public StringField ZonaLimpiezaNombreZona;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Contratos.Habitaciones";
            }
        }
    }
}

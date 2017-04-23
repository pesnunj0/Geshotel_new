
namespace Geshotel.Recepcion.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), TableName("reservas_huespedes"), DisplayName("Reservas Huespedes"), InstanceName("Reservas Huespedes"), TwoLevelCached]
    [ReadPermission("Recepcion:Hotel")]
    [ModifyPermission("Recepcion:Hotel")]
    public sealed class ReservasHuespedesRow : Row, IIdRow
    {
        [DisplayName("Reservas Huespedes Id"), Column("reservas_huespedes_id"), Identity]
        public Int32? ReservasHuespedesId
        {
            get { return Fields.ReservasHuespedesId[this]; }
            set { Fields.ReservasHuespedesId[this] = value; }
        }

        [DisplayName("Reserva"), Column("reserva_id"), NotNull, ForeignKey("reservas", "reserva_id"), LeftJoin("jReserva"), TextualField("ReservaNombreReserva")]
        public Int32? ReservaId
        {
            get { return Fields.ReservaId[this]; }
            set { Fields.ReservaId[this] = value; }
        }

        [DisplayName("Huesped Id"), Column("huesped_id"), NotNull, ForeignKey("huespedes", "huesped_id") ,LeftJoin("jHuesped"), TextualField("NombreCompleto")]
        public Int32? HuespedId
        {
            get { return Fields.HuespedId[this]; }
            set { Fields.HuespedId[this] = value; }
        }

        [DisplayName("Hotel"), Expression("jReserva.[hotel_id]"), ForeignKey("hoteles", "hotel_id"), LeftJoin("jHotel"), TextualField("HotelName"), LookupInclude]
        [LookupEditor("Portal.Hoteles")]
        public Int16? HotelId
        {
            get { return Fields.HotelId[this]; }
            set { Fields.HotelId[this] = value; }
        }

        [DisplayName("Empresa"), Expression("jHotel.[empresa_id]"), ForeignKey("empresas", "empresa_id"), LeftJoin("jEmpresas")]
        [LookupEditor("Portal.Empresas")]
        public Int16? EmpresaId
        {
            get { return Fields.EmpresaId[this]; }
            set { Fields.EmpresaId[this] = value; }

        }

        [DisplayName("Nombre"), Expression("jHuesped.[nombre]")]
        public String Nombre
        {
            get { return Fields.Nombre[this]; }
            set { Fields.Apellidos[this] = value; }
        }

        [DisplayName("Apellidos"), Expression("jHuesped.[apellidos]")]
        public String Apellidos
        {
            get { return Fields.Apellidos[this]; }
            set { Fields.Apellidos[this] = value; }
        }

        [DisplayName("Nombre Completo"), Expression("CONCAT(jHuesped.[nombre], CONCAT(' ', jHuesped.[apellidos]))"), QuickSearch]

        public String NombreCompleto
        {
            get { return Fields.NombreCompleto[this]; }
            set { Fields.NombreCompleto[this] = value; }
        }
        [DisplayName("F. Nacimiento"), Expression("jHuesped.[fecha_nacimiento]")]
        public DateTime? FechaNacimiento
        {
            get { return Fields.FechaNacimiento[this]; }
            set { Fields.FechaNacimiento[this] = value; }
        }
        [DisplayName("Dirección"), Expression("jHuesped.[direccion]")]
        public String Direccion
        {
            get { return Fields.Direccion[this]; }
            set { Fields.Direccion[this] = value; }
        }

        [DisplayName("Poblacion"), Expression("jHuesped.[poblacion]")]
        public String Poblacion
        {
            get { return Fields.Poblacion[this]; }
            set { Fields.Poblacion[this] = value; }
        }

        [DisplayName("Sexo"), Expression("jHuesped.[sexo_id]"), Size(1), ForeignKey("sexos", "sexo_id"), LeftJoin("jSexo")]
        [LookupEditor(typeof(Portal.Entities.SexosRow))]
        public String SexoId
        {
            get { return Fields.SexoId[this]; }
            set { Fields.SexoId[this] = value; }
        }

        [DisplayName("Nación"), Expression("jHuesped.[nacion_id]"), ForeignKey("naciones","nacion_id"),LeftJoin("jNaciones"),TextualField("Nacion")]
        [LookupEditor(typeof(Portal.Entities.NacionesRow))]
        public Int16? NacionId
        {
            get { return Fields.NacionId[this]; }
            set { Fields.NacionId[this] = value; }
        }

        [DisplayName("Nación"), Expression("jNaciones.[desc_corta]")]
        public String Nacion
        {
            get { return Fields.Nacion[this]; }
            set { Fields.Nacion[this] = value; }
        }

        [DisplayName("Provincia"), Expression("jHuesped.[provincia_id]"), ForeignKey("provincias", "provincia_id"), LeftJoin("jProvincias"), TextualField("Provincia")]
        [LookupEditor(typeof(Portal.Entities.ProvinciasRow))]
        public Int16? ProvinciaId
        {
            get { return Fields.ProvinciaId[this]; }
            set { Fields.ProvinciaId[this] = value; }
        }

        [DisplayName("Provincia"), Expression("jProvincias.[provincia]")]
        public String Provincia
        {
            get { return Fields.Provincia[this]; }
            set { Fields.Provincia[this] = value; }
        }


        [DisplayName("Tipo Doc"), Expression("jHuesped.[tipo_documento_id]"),ForeignKey("tipos_documento","tipo_documento_id"),LeftJoin("jTiposDocumento")]
        [LookupEditor(typeof(Portal.Entities.TiposDocumentoRow))]
        public String TipoDocumentoId
        {
            get { return Fields.TipoDocumentoId[this]; }
            set { Fields.TipoDocumentoId[this] = value; }
        }
        [DisplayName("Tipo Doc"), Expression("jTiposDocumento.[tipo_documento]")]
        
        public String TipoDocumento
        {
            get { return Fields.TipoDocumento[this]; }
            set { Fields.TipoDocumento[this] = value; }
        }
        [DisplayName("Nº Doc."), Expression("jHuesped.[nif]")]

        public String Nif
        {
            get { return Fields.Nif[this]; }
            set { Fields.Nif[this] = value; }
        }

        [DisplayName("Fecha Exp."), Expression("jHuesped.[fecha_documento]")]
        public DateTime? FechaDocumento
        {
            get { return Fields.FechaDocumento[this]; }
            set { Fields.FechaDocumento[this] = value; }
        }

        [DisplayName("Tel."), Expression("jHuesped.[telefono]")]

        public String Telefono
        {
            get { return Fields.Telefono[this]; }
            set { Fields.Telefono[this] = value; }
        }

        [DisplayName("Email"), Expression("jHuesped.[email]")]

        public String Email
        {
            get { return Fields.Email[this]; }
            set { Fields.Email[this] = value; }
        }

        [DisplayName("Loyalty Card"), Expression("jHuesped.[tarjeta_fidelizacion]")]

        public String TarjetaFidelizacion
        {
            get { return Fields.TarjetaFidelizacion[this]; }
            set { Fields.TarjetaFidelizacion[this] = value; }
        }

        [DisplayName("Fecha Llegada"), Column("fecha_llegada")]
        public DateTime? FechaLlegada
        {
            get { return Fields.FechaLlegada[this]; }
            set { Fields.FechaLlegada[this] = value; }
        }

        [DisplayName("Fecha Salida"), Column("fecha_salida")]
        public DateTime? FechaSalida
        {
            get { return Fields.FechaSalida[this]; }
            set { Fields.FechaSalida[this] = value; }
        }

        [DisplayName("Habitacion"), Column("habitacion_id"),ForeignKey("habitaciones","habitacion_id"),LeftJoin("jHabitaciones")]
        [LookupEditor("Contratos.Habitaciones")]
        public Int32? HabitacionId
        {
            get { return Fields.HabitacionId[this]; }
            set { Fields.HabitacionId[this] = value; }
        }
        [DisplayName("Habitacion"),Expression("jHabitaciones.[numero_habitacion]")]
        public String NumeroHabitacion
        {
            get { return Fields.NumeroHabitacion[this]; }
            set { Fields.NumeroHabitacion[this] = value; }
        }

        [DisplayName("Edad"), Column("edad")]
        public Int16? Edad
        {
            get { return Fields.Edad[this]; }
            set { Fields.Edad[this] = value; }
        }


        [DisplayName("Hotel"), Expression("jReserva.[hotel_id]")]
        public Int16? ReservaHotelId
        {
            get { return Fields.ReservaHotelId[this]; }
            set { Fields.ReservaHotelId[this] = value; }
        }

        [DisplayName("Estado Reserva"), Expression("jReserva.[estado_reserva_id]")]
        public Int16? ReservaEstadoReservaId
        {
            get { return Fields.ReservaEstadoReservaId[this]; }
            set { Fields.ReservaEstadoReservaId[this] = value; }
        }
  
        [DisplayName("FechaLlegada"), Expression("jReserva.[fecha_prevista_llegada]")]
        public DateTime? ReservaFechaPrevistaLlegada
        {
            get { return Fields.ReservaFechaPrevistaLlegada[this]; }
            set { Fields.ReservaFechaPrevistaLlegada[this] = value; }
        }

        [DisplayName("Fecha Salida"), Expression("jReserva.[fecha_prevista_salida]")]
        public DateTime? ReservaFechaPrevistaSalida
        {
            get { return Fields.ReservaFechaPrevistaSalida[this]; }
            set { Fields.ReservaFechaPrevistaSalida[this] = value; }
        }
 
        IIdField IIdRow.IdField
        {
            get { return Fields.ReservasHuespedesId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ReservasHuespedesRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ReservasHuespedesId;
            public Int32Field ReservaId;
            public Int32Field HuespedId;
            public DateTimeField FechaLlegada;
            public DateTimeField FechaSalida;
            public Int32Field HabitacionId;
            public Int16Field Edad;
    
            public Int16Field ReservaHotelId;
            public Int16Field ReservaEstadoReservaId;
            
            public DateTimeField ReservaFechaPrevistaLlegada;
            public DateTimeField ReservaFechaPrevistaSalida;

            public StringField Nombre;
            public StringField Apellidos;
            public StringField NombreCompleto;
            public StringField TipoDocumentoId;
            public StringField TipoDocumento;
            public DateTimeField FechaDocumento;
      
            public StringField Nif;
            public DateTimeField FechaNacimiento;
            public StringField Direccion;
            public StringField Poblacion;
            public Int16Field ProvinciaId;
            public StringField Provincia;
            public Int16Field NacionId;
            public StringField Nacion;
            public StringField Telefono;
            public StringField Email;
            public StringField TarjetaFidelizacion;
            public StringField NumeroHabitacion;
            public StringField SexoId;
            public Int16Field HotelId;
            public Int16Field EmpresaId;


            public RowFields()
                : base()
            {
                LocalTextPrefix = "Recepcion.ReservasHuespedes";
            }
        }
    }
}

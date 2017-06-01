
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

        [DisplayName("Hotel"), Expression("jHotel.[hotel]")]
        public String HotelName
        {
            get { return Fields.HotelName[this]; }
            set { Fields.HotelName[this] = value; }
        }

        [DisplayName("Empresa"), Expression("jHotel.[empresa_id]"), ForeignKey("empresas", "empresa_id"), LeftJoin("jEmpresas")]
        [LookupEditor("Portal.Empresas")]
        public Int16? EmpresaId
        {
            get { return Fields.EmpresaId[this]; }
            set { Fields.EmpresaId[this] = value; }

        }

        [DisplayName("Empresa"), Expression("jEmpresas.empresa")]

        public String Empresa
        {
            get { return Fields.Empresa[this]; }
            set { Fields.Empresa[this] = value; }

        }
        //*******

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

        [DisplayName("Nombre Completo"), Expression("CONCAT(jHuesped.[nombre], CONCAT(' ', jHuesped.[apellidos]))"), QuickSearch,LookupInclude]

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

        [DisplayName("Sexo"), Expression("jHuesped.[sexo_id]"), Size(1), ForeignKey("sexos", "sexo_id"), LeftJoin("jSexo"),TextualField("Sexo")]
        [LookupEditor(typeof(Portal.Entities.SexosRow))]
        public String SexoId
        {
            get { return Fields.SexoId[this]; }
            set { Fields.SexoId[this] = value; }
        }
        [DisplayName("Sexo"),Expression("jSexo.[sexo]")]
        public String Sexo
        {
            get { return Fields.Sexo[this]; }
            set { Fields.Sexo[this] = value; }
        }

        [DisplayName("Nación"), Expression("jHuesped.[nacion_id]"), ForeignKey("naciones","nacion_id"),LeftJoin("jNaciones"),TextualField("Nacion")]
        [LookupEditor(typeof(Portal.Entities.NacionesRow))]
        public Int16? NacionId
        {
            get { return Fields.NacionId[this]; }
            set { Fields.NacionId[this] = value; }
        }

        [DisplayName("Nación"), Expression("jNaciones.[nacion]")]
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

        [DisplayName("Zip"), Expression("jHuesped.[zip]")]

        public String Zip
        {
            get { return Fields.Zip[this]; }
            set { Fields.Zip[this] = value; }
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
        [DisplayName("Habitacion"),Expression("(SELECT MAX(COALESCE(reservas_huespedes.habitacion_id,habitaciones_bloqueos.habitacion_id)) As habitacion_id FROM reservas_huespedes LEFT JOIN habitaciones_bloqueos ON reservas_huespedes.reserva_id = habitaciones_bloqueos.reserva_id WHERE reservas_huespedes_id = t0.reservas_huespedes_id)")]
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
        [DisplayName("Fotos"), Expression("jHuesped.[ficheros]"),MultipleFileUploadEditor(FilenameFormat = "Huespedes/Ficheros/~")]
        public string Ficheros
        {
            get { return Fields.Ficheros[this]; }
            set { Fields.Ficheros[this] = value; }
        }

        [DisplayName("Estado Reserva"), Expression("jReserva.[estado_reserva_id]"),ForeignKey("reserva_estados","estado_reserva_id"),LeftJoin("jEstadoReserva"), TextualField("EstadoReserva")]
        [LookupEditor("Portal.ReservaEstados")]
        public Int16? ReservaEstadoReservaId
        {
            get { return Fields.ReservaEstadoReservaId[this]; }
            set { Fields.ReservaEstadoReservaId[this] = value; }
        }
        [DisplayName("Estado Reserva"), Expression("jEstadoReserva.[estado]")]
        public String EstadoReserva
        {
            get { return Fields.EstadoReserva[this]; }
            set { Fields.EstadoReserva[this] = value; }
        }

        [DisplayName("Llegada"), Expression("jReserva.[fecha_llegada]")]
        public DateTime? ReservaFechaLlegada
        {
            get { return Fields.ReservaFechaLlegada[this]; }
            set { Fields.ReservaFechaLlegada[this] = value; }
        }

        [DisplayName("Salida"), Expression("jReserva.[fecha_salida]")]
        public DateTime? ReservaFechaSalida
        {
            get { return Fields.ReservaFechaSalida[this]; }
            set { Fields.ReservaFechaSalida[this] = value; }
        }

        [DisplayName("Desde")]
        [Expression("(SELECT COALESCE(reservas_huespedes.fecha_llegada, reservas.fecha_llegada) FROM reservas_huespedes INNER JOIN reservas ON reservas_huespedes.reserva_id = reservas.reserva_id WHERE reservas_huespedes.reservas_huespedes_id = t0.reservas_huespedes_id )")]
        public DateTime? Desde
        {
            get { return Fields.Desde[this]; }
            set { Fields.Desde[this] = value; }
        }

        [DisplayName("Hasta")]
        [Expression("(SELECT COALESCE(reservas_huespedes.fecha_salida, reservas.fecha_salida) FROM reservas_huespedes INNER JOIN reservas ON reservas_huespedes.reserva_id = reservas.reserva_id WHERE reservas_huespedes.reservas_huespedes_id = t0.reservas_huespedes_id )")]

        public DateTime? Hasta
        {
            get { return Fields.Hasta[this]; }
            set { Fields.Hasta[this] = value; }
        }

        [DisplayName("Tipo Habitacion"), Expression("jReserva.tipo_habitacion_id"), ForeignKey("servicios", "servicio_id"), LeftJoin("jTipoHabitacion"), TextualField("TipoHabitacion")]
        [LookupEditor(("Contratos.ServiciosHotel"), CascadeFrom = "HotelId", CascadeField = "HotelId", FilterField = "ConceptoAceleradorReservasId", FilterValue = 1)]
        public Int16? TipoHabitacionId
        {
            get { return Fields.TipoHabitacionId[this]; }
            set { Fields.TipoHabitacionId[this] = value; }
        }

        [DisplayName("TipoHabitacion"), Expression("jTipoHabitacion.abreviatura")]
        public String TipoHabitacion
        {
            get { return Fields.TipoHabitacion[this]; }
            set { Fields.TipoHabitacion[this] = value; }
        }

        [DisplayName("Pension"), Expression("jReserva.pension_id"), ForeignKey("servicios", "servicio_id"), LeftJoin("jPension"), TextualField("Pension")]
        [LookupEditor(("Contratos.ServiciosHotel"), CascadeFrom = "HotelId", CascadeField = "HotelId", FilterField = "ConceptoAceleradorReservasId", FilterValue = 2)]
        public Int16? PensionId
        {
            get { return Fields.PensionId[this]; }
            set { Fields.PensionId[this] = value; }
        }

        [DisplayName("Pension"), Expression("jPension.abreviatura")]
        public String Pension
        {
            get { return Fields.Pension[this]; }
            set { Fields.Pension[this] = value; }
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
            
            public DateTimeField ReservaFechaLlegada;
            public DateTimeField ReservaFechaSalida;
            

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
            public StringField Zip;
            public StringField Email;
            public StringField TarjetaFidelizacion;
            public StringField NumeroHabitacion;
            public StringField SexoId;
            public StringField Sexo;
            public Int16Field HotelId;
            public Int16Field EmpresaId;

            public DateTimeField Desde;
            public DateTimeField Hasta;

            public StringField HotelName;
            public StringField Empresa;

            public Int16Field TipoHabitacionId;
            public Int16Field PensionId;
            public StringField TipoHabitacion;
            public StringField Pension;
            public readonly StringField Ficheros;
            public StringField EstadoReserva;
            public RowFields()
                : base()
            {
                LocalTextPrefix = "Recepcion.ReservasHuespedes";
            }
        }
    }
}

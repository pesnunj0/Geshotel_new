﻿
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

        [DisplayName("First Name"), Expression("jHuesped.[nombre]")]
        public String Nombre
        {
            get { return Fields.Nombre[this]; }
            set { Fields.Apellidos[this] = value; }
        }

        [DisplayName("Last Name"), Expression("jHuesped.[apellidos]")]
        public String Apellidos
        {
            get { return Fields.Apellidos[this]; }
            set { Fields.Apellidos[this] = value; }
        }

        [DisplayName("Full Name"), Expression("CONCAT(jHuesped.[nombre], CONCAT(' ', jHuesped.[apellidos]))"), QuickSearch]

        public String NombreCompleto
        {
            get { return Fields.NombreCompleto[this]; }
            set { Fields.NombreCompleto[this] = value; }
        }
        [DisplayName("Birthday"), Expression("jHuesped.[fecha_nacimiento]")]
        public DateTime? FechaNacimiento
        {
            get { return Fields.FechaNacimiento[this]; }
            set { Fields.FechaNacimiento[this] = value; }
        }
        [DisplayName("Address"), Expression("jHuesped.[direccion]")]
        public String Direccion
        {
            get { return Fields.Direccion[this]; }
            set { Fields.Direccion[this] = value; }
        }

        [DisplayName("Location"), Expression("jHuesped.[poblacion]")]
        public String Poblacion
        {
            get { return Fields.Poblacion[this]; }
            set { Fields.Poblacion[this] = value; }
        }

        [DisplayName("Country Id"), Expression("jHuesped.[nacion_id]"), ForeignKey("naciones","nacion_id"),LeftJoin("jNaciones"),TextualField("Nacion")]
        [LookupEditor(typeof(Portal.Entities.NacionesRow))]
        public Int16? NacionId
        {
            get { return Fields.NacionId[this]; }
            set { Fields.NacionId[this] = value; }
        }

        [DisplayName("Country"), Expression("jNaciones.[desc_corta]")]
        public String Nacion
        {
            get { return Fields.Nacion[this]; }
            set { Fields.Nacion[this] = value; }
        }

        [DisplayName("State Id"), Expression("jHuesped.[provincia_id]"), ForeignKey("provincias", "provincia_id"), LeftJoin("jProvincias"), TextualField("Provincia")]
        [LookupEditor(typeof(Portal.Entities.NacionesRow))]
        public Int16? ProvinciaId
        {
            get { return Fields.ProvinciaId[this]; }
            set { Fields.ProvinciaId[this] = value; }
        }

        [DisplayName("State"), Expression("jProvincias.[provincia]")]
        public String Provincia
        {
            get { return Fields.Provincia[this]; }
            set { Fields.Provincia[this] = value; }
        }


        [DisplayName("Doc Type Id"), Expression("jHuesped.[tipo_documento_id]"),ForeignKey("tipos_documento","tipo_documento_id"),LeftJoin("jTiposDocumento")]
        [LookupEditor(typeof(Portal.Entities.TiposDocumentoRow))]
        public String TipoDocumentoId
        {
            get { return Fields.TipoDocumentoId[this]; }
            set { Fields.TipoDocumentoId[this] = value; }
        }
        [DisplayName("Doc Type"), Expression("jTiposDocumento.[tipo_documento]")]
        
        public String TipoDocumento
        {
            get { return Fields.TipoDocumento[this]; }
            set { Fields.TipoDocumento[this] = value; }
        }
        [DisplayName("IDCard"), Expression("jHuesped.[nif]")]

        public String Nif
        {
            get { return Fields.Nif[this]; }
            set { Fields.Nif[this] = value; }
        }

        [DisplayName("Phone"), Expression("jHuesped.[telefono]")]

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

        [DisplayName("Habitacion Id"), Column("habitacion_id"),ForeignKey("habitaciones","habitacion_id"),LeftJoin("jHabitaciones")]
        [LookupEditor("Contratos.Habitaciones")]
        public Int32? HabitacionId
        {
            get { return Fields.HabitacionId[this]; }
            set { Fields.HabitacionId[this] = value; }
        }


        [DisplayName("Edad"), Column("edad")]
        public Int16? Edad
        {
            get { return Fields.Edad[this]; }
            set { Fields.Edad[this] = value; }
        }


        [DisplayName("Reserva Hotel Id"), Expression("jReserva.[hotel_id]")]
        public Int16? ReservaHotelId
        {
            get { return Fields.ReservaHotelId[this]; }
            set { Fields.ReservaHotelId[this] = value; }
        }

        [DisplayName("Reserva Estado Reserva Id"), Expression("jReserva.[estado_reserva_id]")]
        public Int16? ReservaEstadoReservaId
        {
            get { return Fields.ReservaEstadoReservaId[this]; }
            set { Fields.ReservaEstadoReservaId[this] = value; }
        }

 

  
        [DisplayName("Reserva Fecha Prevista Llegada"), Expression("jReserva.[fecha_prevista_llegada]")]
        public DateTime? ReservaFechaPrevistaLlegada
        {
            get { return Fields.ReservaFechaPrevistaLlegada[this]; }
            set { Fields.ReservaFechaPrevistaLlegada[this] = value; }
        }

        [DisplayName("Reserva Fecha Prevista Salida"), Expression("jReserva.[fecha_prevista_salida]")]
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
                
            public RowFields()
                : base()
            {
                LocalTextPrefix = "Recepcion.ReservasHuespedes";
            }
        }
    }
}


namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;
    using Portal.Entities;

    [ConnectionKey("Default"), TableName("tipos_habitacion_hotel"), DisplayName("Tipos Habitacion Hotel"), InstanceName("Tipos Habitacion Hotel"), TwoLevelCached]
    [ReadPermission("Contratos:General")]
    [ModifyPermission("Contratos:General")]

    public sealed class TiposHabitacionHotelRow : Row, IIdRow
    {
       

        [DisplayName("Tipo Habitacion Hotel Id"), Column("tipo_habitacion_hotel_id"), Identity]
        public Int32? TipoHabitacionHotelId
        {
            get { return Fields.TipoHabitacionHotelId[this]; }
            set { Fields.TipoHabitacionHotelId[this] = value; }
        }

        [DisplayName("Hotel"), Column("hotel_id"), ForeignKey("hoteles", "hotel_id"), LeftJoin("jHoteles")]
        [LookupEditor("Portal.Hoteles", CascadeFrom = "EmpresaId", CascadeField = "EmpresaId")]
        public Int16? HotelId
        {
            get { return Fields.HotelId[this]; }
            set { Fields.HotelId[this] = value; }

        }

        [DisplayName("Empresa"), Expression("jHoteles.[empresa_id]"), ForeignKey("empresas", "empresa_id"), LeftJoin("jEmpresas")]
        [LookupEditor("Portal.Empresas"), ReadPermission(Administration.PermissionKeys.Security)]
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

        [DisplayName("Hotel"), Expression("jHoteles.hotel")]
        public String HotelName
        {
            get { return Fields.HotelName[this]; }
            set { Fields.HotelName[this] = value; }
        }


        [DisplayName("Tipo Habitacion"), Column("tipo_habitacion_id"), PrimaryKey, ForeignKey("tipos_habitacion", "tipo_habitacion_id"), LeftJoin("jTipoHabitacion"), TextualField("TipoHabitacionName"),NotNull]
        [LookupEditor(typeof(TiposHabitacionRow))]
        public Int16? TipoHabitacionId
        {
            get { return Fields.TipoHabitacionId[this]; }
            set { Fields.TipoHabitacionId[this] = value; }
        }

        [DisplayName("Servicio"), Column("servicio_id"), NotNull, ForeignKey("servicios", "servicio_id"), LeftJoin("jServicio"), TextualField("ServicioName")]
        [LookupEditor(typeof(ServiciosRow),FilterField = "TipoServicioId", FilterValue = 1)]
        public Int32? ServicioId
        {
            get { return Fields.ServicioId[this]; }
            set { Fields.ServicioId[this] = value; }
        }

        [DisplayName("Tipo Habitacion"), Expression("jTipoHabitacion.[descripcion]")]
        public String TipoHabitacionName
        {
            get { return Fields.TipoHabitacionName[this]; }
            set { Fields.TipoHabitacionName[this] = value; }
        }

        [DisplayName("Servicio"), Expression("jServicio.[nombre_servicio]")]

        public String ServicioName
        {
            get { return Fields.ServicioName[this]; }
            set { Fields.ServicioName[this] = value; }
        }


        IIdField IIdRow.IdField
        {
            get { return Fields.TipoHabitacionHotelId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TiposHabitacionHotelRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field TipoHabitacionHotelId;
            public Int16Field HotelId;
            public Int16Field TipoHabitacionId;
            public Int32Field ServicioId;

            public StringField HotelName;
            public Int16Field EmpresaId;
            public StringField Empresa;

            public StringField TipoHabitacionName;

            public StringField ServicioName;
           

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Contratos.TiposHabitacionHotel";
            }
        }
    }
}

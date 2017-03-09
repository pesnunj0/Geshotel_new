
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

    [ConnectionKey("Default"), TableName("servicios_hotel"), DisplayName("Servicios Hotel"), InstanceName("Servicios Hotel"), TwoLevelCached]
    [ReadPermission("Todos:General")]
    [ModifyPermission("Contratos:Empresa")]
    [LookupScript("Contratos.ServiciosHotel")]
    public sealed class ServiciosHotelRow : Row, IIdRow, INameRow, ITenantRow
    {
        public Int16Field HotelIdField
        {
            get { return null; }
        }
        public Int16Field EmpresaIdField
        {
            get { return Fields.EmpresaId; }
        }

        [DisplayName("Servicio Hotel Id"), Column("servicio_hotel_id"), Identity]
        public Int32? ServicioHotelId
        {
            get { return Fields.ServicioHotelId[this]; }
            set { Fields.ServicioHotelId[this] = value; }
        }

        [DisplayName("Hotel"), Column("hotel_id"), ForeignKey("hoteles", "hotel_id"), LeftJoin("jHoteles"), LookupInclude]
        [LookupEditor("Portal.Hoteles")]
        public Int16? HotelId
        {
            get { return Fields.HotelId[this]; }
            set { Fields.HotelId[this] = value; }

        }

        [DisplayName("Empresa"), Expression("jHoteles.[empresa_id]"), ForeignKey("empresas", "empresa_id"), LeftJoin("jEmpresas")]
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

        [DisplayName("Hotel"), Expression("jHoteles.hotel")]
        public String HotelName
        {
            get { return Fields.HotelName[this]; }
            set { Fields.HotelName[this] = value; }
        }


        [DisplayName("Servicio"), Column("servicio_id"), NotNull, ForeignKey("servicios", "servicio_id"), LeftJoin("jServicio"), TextualField("NombreServicio")]
        [LookupEditor(typeof(ServiciosRow))]
        public Int32? ServicioId
        {
            get { return Fields.ServicioId[this]; }
            set { Fields.ServicioId[this] = value; }
        }



        [DisplayName("Impuesto"), Column("impuesto_id"), NotNull, ForeignKey("impuestos", "impuesto_id"), LeftJoin("jImpuesto"), TextualField("Impuesto")]
        [LookupEditor(typeof(ImpuestosRow))]
        public Int16? ImpuestoId
        {
            get { return Fields.ImpuestoId[this]; }
            set { Fields.ImpuestoId[this] = value; }
        }

        [DisplayName("Costo"), Column("costo")]
        public Double? Costo
        {
            get { return Fields.Costo[this]; }
            set { Fields.Costo[this] = value; }
        }

        [DisplayName("Cta Contable"), Column("cta_contable"), Size(16), NotNull, QuickSearch]
        public String CtaContable
        {
            get { return Fields.CtaContable[this]; }
            set { Fields.CtaContable[this] = value; }
        }

        [DisplayName("Dpto Contable"), Column("dpto_contable"), Size(10), NotNull]
        public String DptoContable
        {
            get { return Fields.DptoContable[this]; }
            set { Fields.DptoContable[this] = value; }
        }

        [DisplayName("Permite Credito"), Column("permite_credito"), NotNull]
        public Boolean? PermiteCredito
        {
            get { return Fields.PermiteCredito[this]; }
            set { Fields.PermiteCredito[this] = value; }
        }

        [DisplayName("Servicio Nombre Servicio"), Expression("jServicio.[nombre_servicio]")]
        public String NombreServicio
        {
            get { return Fields.NombreServicio[this]; }
            set { Fields.NombreServicio[this] = value; }
        }



        [DisplayName("Servicio Tipo Servicio Id"), Expression("jServicio.[tipo_servicio_id]")]
        public Int16? ServicioTipoServicioId
        {
            get { return Fields.ServicioTipoServicioId[this]; }
            set { Fields.ServicioTipoServicioId[this] = value; }
        }

        [DisplayName("Concepto Acelerador Reservas Id"), Expression("jServicio.[concepto_acelerador_reservas_id]"), LookupInclude]
        public Int16? ConceptoAceleradorReservasId
        {
            get { return Fields.ConceptoAceleradorReservasId[this]; }
            set { Fields.ConceptoAceleradorReservasId[this] = value; }
        }

        [DisplayName("SwPension"), Expression("jServicio.[sw_pension]")]
        public Boolean? SwPension
        {
            get { return Fields.SwPension[this]; }
            set { Fields.SwPension[this] = value; }
        }

        [DisplayName("Impuesto"), Expression("jImpuesto.[impuesto]")]
        public String Impuesto
        {
            get { return Fields.Impuesto[this]; }
            set { Fields.Impuesto[this] = value; }
        }


        IIdField IIdRow.IdField
        {
            get { return Fields.ServicioHotelId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.CtaContable; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ServiciosHotelRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ServicioHotelId;
            public Int32Field ServicioId;
            public Int16Field HotelId;
            public Int16Field ImpuestoId;
            public DoubleField Costo;
            public StringField CtaContable;
            public StringField DptoContable;
            public BooleanField PermiteCredito;

            public StringField HotelName;
            public Int16Field EmpresaId;
            public StringField Empresa;


            public StringField NombreServicio;
            public Int16Field ServicioTipoServicioId;
            public Int16Field ConceptoAceleradorReservasId;
            public BooleanField SwPension;


            public StringField Impuesto;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Contratos.ServiciosHotel";
            }
        }
    }
}

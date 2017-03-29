
namespace Geshotel.Recepcion.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;
    using Portal.Entities;

    [ConnectionKey("Default"), TableName("[dbo].[huespedes]"), DisplayName("Huespedes"), InstanceName("Huespedes"), TwoLevelCached]
    [ReadPermission("Recepcion:Hotel")]
    [ModifyPermission("Recepcion:Hotel")]
    public sealed class HuespedesRow : Row, IIdRow, INameRow
    {
        [DisplayName("Guest Id"), Column("huesped_id"), Identity]
        public Int32? HuespedId
        {
            get { return Fields.HuespedId[this]; }
            set { Fields.HuespedId[this] = value; }
        }

        [DisplayName("Company"), Column("empresa_id"), NotNull, ForeignKey("[dbo].[empresas]", "empresa_id"), LeftJoin("jEmpresa"), TextualField("Empresa")]
        [LookupEditor("Portal.Empresas")]
        public Int16? EmpresaId
        {
            get { return Fields.EmpresaId[this]; }
            set { Fields.EmpresaId[this] = value; }
        }

        [DisplayName("First Name"), Size(30), NotNull, QuickSearch]
        public String Nombre
        {
            get { return Fields.Nombre[this]; }
            set { Fields.Nombre[this] = value; }
        }

        [DisplayName("Last Name"), Size(50), NotNull]
        public String Apellidos
        {
            get { return Fields.Apellidos[this]; }
            set { Fields.Apellidos[this] = value; }
        }

        [DisplayName("Full Name"), Expression("CONCAT(T0.nombre,' ',T0.apellidos)")]
        public String NombreCompleto
        {
            get { return Fields.NombreCompleto[this]; }
            set { Fields.NombreCompleto[this] = value; }
        }

        [DisplayName("Document Type"), Column("tipo_documento_id"), Size(1), ForeignKey("[tipos_documento]", "tipo_documento_id"), LeftJoin("jTipoDocumento"), TextualField("TipoDocumentoDocumento")]
        [LookupEditor(typeof(TiposDocumentoRow))]
        public String TipoDocumentoId
        {
            get { return Fields.TipoDocumentoId[this]; }
            set { Fields.TipoDocumentoId[this] = value; }
        }

        [DisplayName("Document Type"),Expression("jTipoDocumento.[tipo_documento]")]
        public String TipoDocumento
        {
            get { return Fields.TipoDocumento[this]; }
            set { Fields.TipoDocumento[this] = value; }
        }

        [DisplayName("ID Card"), Column("nif"), Size(20)]
        public String Nif
        {
            get { return Fields.Nif[this]; }
            set { Fields.Nif[this] = value; }
        }

        [DisplayName("Birthday"), Column("fecha_nacimiento")]
        public DateTime? FechaNacimiento
        {
            get { return Fields.FechaNacimiento[this]; }
            set { Fields.FechaNacimiento[this] = value; }
        }

        [DisplayName("Document Date"), Column("fecha_documento")]
        public DateTime? FechaDocumento
        {
            get { return Fields.FechaDocumento[this]; }
            set { Fields.FechaDocumento[this] = value; }
        }

        [DisplayName("SexId"), Column("sexo_id"), Size(1),ForeignKey("sexos","sexo_id"),LeftJoin("jSexo"),TextualField("Sexo")]
        [LookupEditor(typeof(SexosRow))]
        public String SexoId
        {
            get { return Fields.SexoId[this]; }
            set { Fields.SexoId[this] = value; }
        }

        [DisplayName("Address"), Column("direccion"), Size(70)]
        public String Direccion
        {
            get { return Fields.Direccion[this]; }
            set { Fields.Direccion[this] = value; }
        }

        [DisplayName("Location"), Column("poblacion"), Size(70)]
        public String Poblacion
        {
            get { return Fields.Poblacion[this]; }
            set { Fields.Poblacion[this] = value; }
        }

        [DisplayName("Zip"), Column("zip"), Size(10)]
        public String Zip
        {
            get { return Fields.Zip[this]; }
            set { Fields.Zip[this] = value; }
        }

        [DisplayName("Country"), Column("nacion_id"), ForeignKey("[naciones]", "nacion_id"), LeftJoin("jNacion"), TextualField("Nacion")]
        [LookupEditor(typeof(NacionesRow))]
        public Int16? NacionId
        {
            get { return Fields.NacionId[this]; }
            set { Fields.NacionId[this] = value; }
        }

        [DisplayName("State"), Column("provincia_id"), ForeignKey("[provincias]", "provincia_id"), LeftJoin("jProvincia"), TextualField("Provincia")]
        [LookupEditor(typeof(ProvinciasRow))]
        public Int16? ProvinciaId
        {
            get { return Fields.ProvinciaId[this]; }
            set { Fields.ProvinciaId[this] = value; }
        }

        [DisplayName("Phone"), Column("telefono"), Size(16)]
        public String Telefono
        {
            get { return Fields.Telefono[this]; }
            set { Fields.Telefono[this] = value; }
        }

        [DisplayName("Email"), Column("email"), Size(70)]
        public String Email
        {
            get { return Fields.Email[this]; }
            set { Fields.Email[this] = value; }
        }

        [DisplayName("Photo1"), Column("foto1"), Size(100)]
        public String Foto1
        {
            get { return Fields.Foto1[this]; }
            set { Fields.Foto1[this] = value; }
        }

        [DisplayName("Photo2"), Column("foto2"), Size(100)]
        public String Foto2
        {
            get { return Fields.Foto2[this]; }
            set { Fields.Foto2[this] = value; }
        }

        [DisplayName("Loyalty Card"), Column("tarjeta_fidelizacion"), Size(20)]
        public String TarjetaFidelizacion
        {
            get { return Fields.TarjetaFidelizacion[this]; }
            set { Fields.TarjetaFidelizacion[this] = value; }
        }

        [DisplayName("Company"), Expression("jEmpresa.[empresa]")]
        public String Empresa
        {
            get { return Fields.Empresa[this]; }
            set { Fields.Empresa[this] = value; }
        }

  

        [DisplayName("Country"), Expression("jNacion.[nacion]")]
        public String Nacion
        {
            get { return Fields.Nacion[this]; }
            set { Fields.Nacion[this] = value; }
        }

        [DisplayName("Country"), Expression("jNacion.[desc_corta]")]
        public String NacionDescCorta
        {
            get { return Fields.NacionDescCorta[this]; }
            set { Fields.NacionDescCorta[this] = value; }
        }

        [DisplayName("State"), Expression("jProvincia.[provincia]")]
        public String Provincia
        {
            get { return Fields.Provincia[this]; }
            set { Fields.Provincia[this] = value; }
        }


        IIdField IIdRow.IdField
        {
            get { return Fields.HuespedId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Nombre; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public HuespedesRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field HuespedId;
            public Int16Field EmpresaId;
            public StringField Nombre;
            public StringField Apellidos;
            public StringField NombreCompleto;
            public StringField TipoDocumentoId;
            public StringField Nif;
            public DateTimeField FechaDocumento;
            public DateTimeField FechaNacimiento;
            public StringField SexoId;
            public StringField Direccion;
            public StringField Poblacion;
            public StringField Zip;
            public Int16Field NacionId;
            public Int16Field ProvinciaId;
            public StringField Telefono;
            public StringField Email;
            public StringField Foto1;
            public StringField Foto2;
            public StringField TarjetaFidelizacion;

            public StringField Empresa;

            public StringField TipoDocumento;

            public StringField Nacion;
            public StringField NacionDescCorta;

            public StringField Provincia;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Recepcion.Huespedes";
            }
        }
    }
}


namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("unidades_calculo"), InstanceName("unidades_calculo"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.UnidadesCalculo")]
    public sealed class UnidadesCalculoRow : Row, IIdRow, INameRow
    {
        [DisplayName("Unidad Calculo Id"), Column("unidad_calculo_id"), Identity]
        public Int16? UnidadCalculoId
        {
            get { return Fields.UnidadCalculoId[this]; }
            set { Fields.UnidadCalculoId[this] = value; }
        }

        [DisplayName("Uc"), Column("UC"), Size(4), NotNull, QuickSearch]
        public String Uc
        {
            get { return Fields.Uc[this]; }
            set { Fields.Uc[this] = value; }
        }

        [DisplayName("Descripcion Unidad Calculo"), Column("descripcion_unidad_calculo"), Size(30), NotNull]
        public String DescripcionUnidadCalculo
        {
            get { return Fields.DescripcionUnidadCalculo[this]; }
            set { Fields.DescripcionUnidadCalculo[this] = value; }
        }

        [DisplayName("Tipo Unidad Calculo"), Column("tipo_unidad_calculo_id"), ForeignKey("tipos_unidad_calculo", "tipo_unidad_calculo_id"), LeftJoin("jTipoUnidadCalculo"), TextualField("TipoUnidadCalculoUc")]
        [LookupEditor(typeof(TiposUnidadCalculoRow))]
        public Int16? TipoUnidadCalculoId
        {
            get { return Fields.TipoUnidadCalculoId[this]; }
            set { Fields.TipoUnidadCalculoId[this] = value; }
        }

        [DisplayName("Pax"), Column("pax")]
        public Boolean? Pax
        {
            get { return Fields.Pax[this]; }
            set { Fields.Pax[this] = value; }
        }

        [DisplayName("Servicio"), Column("servicio_id"), ForeignKey("servicios", "servicio_id"), LeftJoin("jServicio"), TextualField("ServicioNombreServicio")]
        [LookupEditor(typeof(ServiciosRow))]
        public Int32? ServicioId
        {
            get { return Fields.ServicioId[this]; }
            set { Fields.ServicioId[this] = value; }
        }


        [DisplayName("Tipo Uc"), Expression("jTipoUnidadCalculo.[tipo_uc]")]
        public String TipoUc
        {
            get { return Fields.TipoUc[this]; }
            set { Fields.TipoUc[this] = value; }
        }

        [DisplayName("Servicio"), Expression("jServicio.[nombre_servicio]")]
        public String ServicioNombreServicio
        {
            get { return Fields.ServicioNombreServicio[this]; }
            set { Fields.ServicioNombreServicio[this] = value; }
        }
 

        IIdField IIdRow.IdField
        {
            get { return Fields.UnidadCalculoId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Uc; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public UnidadesCalculoRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field UnidadCalculoId;
            public StringField Uc;
            public StringField DescripcionUnidadCalculo;
            public Int16Field TipoUnidadCalculoId;
            public BooleanField Pax;
            public Int32Field ServicioId;
 
            public StringField TipoUc;

            public StringField ServicioNombreServicio;

            public RowFields()
                : base("unidades_calculo")
            {
                LocalTextPrefix = "Portal.UnidadesCalculo";
            }
        }
    }
}

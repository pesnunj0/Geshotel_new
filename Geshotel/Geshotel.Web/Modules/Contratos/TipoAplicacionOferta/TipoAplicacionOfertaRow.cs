﻿
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("tipo_aplicacion_oferta"), InstanceName("tipo_aplicacion_oferta"), TwoLevelCached]
    [ReadPermission("Todos:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Contratos.TipoAplicacionOferta")]
    public sealed class TipoAplicacionOfertaRow : Row, IIdRow, INameRow
    {
        [DisplayName("Tipo Aplicacion Oferta Id"), Column("tipo_aplicacion_oferta_id"), Size(1), PrimaryKey, QuickSearch]
        public String TipoAplicacionOfertaId
        {
            get { return Fields.TipoAplicacionOfertaId[this]; }
            set { Fields.TipoAplicacionOfertaId[this] = value; }
        }

        [DisplayName("Aplicable Segun Fecha De"), Column("aplicable_segun_fecha_de"), Size(15), NotNull]
        public String AplicableSegunFechaDe
        {
            get { return Fields.AplicableSegunFechaDe[this]; }
            set { Fields.AplicableSegunFechaDe[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.TipoAplicacionOfertaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.AplicableSegunFechaDe; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TipoAplicacionOfertaRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public StringField TipoAplicacionOfertaId;
            public StringField AplicableSegunFechaDe;

            public RowFields()
                : base("tipo_aplicacion_oferta")
            {
                LocalTextPrefix = "Contratos.TipoAplicacionOferta";
            }
        }
    }
}

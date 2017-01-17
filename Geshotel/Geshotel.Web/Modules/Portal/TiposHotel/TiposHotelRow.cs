
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Geshotel"), DisplayName("tipos_hotel"), InstanceName("tipos_hotel"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.TiposHotel")]
    public sealed class TiposHotelRow : Row, IIdRow, INameRow
    {
        [DisplayName("Tipo Hotel Id"), Column("tipo_hotel_id"), Identity]
        public Int16? TipoHotelId
        {
            get { return Fields.TipoHotelId[this]; }
            set { Fields.TipoHotelId[this] = value; }
        }

        [DisplayName("Tipo Hotel"), Column("tipo_hotel"), Size(30), QuickSearch]
        public String TipoHotel
        {
            get { return Fields.TipoHotel[this]; }
            set { Fields.TipoHotel[this] = value; }
        }

        [DisplayName("Abreviatura"), Column("abreviatura"), Size(6)]
        public String Abreviatura
        {
            get { return Fields.Abreviatura[this]; }
            set { Fields.Abreviatura[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.TipoHotelId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TipoHotel; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TiposHotelRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field TipoHotelId;
            public StringField TipoHotel;
            public StringField Abreviatura;

            public RowFields()
                : base("tipos_hotel")
            {
                LocalTextPrefix = "Portal.TiposHotel";
            }
        }
    }
}

namespace Geshotel.Contratos.Scripts
{
    using Entities;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Web;

    [LookupScript("Contratos.ServiciosHotel")]
    public class ServiciosHotelLookup : RowLookupScript<ServiciosHotelRow>
    {
        public ServiciosHotelLookup()
        {
            IdField = ServiciosHotelRow.Fields.ServicioId.PropertyName;
            TextField = ServiciosHotelRow.Fields.NombreServicio.PropertyName;
        }
    }
}
namespace Geshotel.Contratos.Scripts
{
    using Entities;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Web;
    using Portal.Scripts;

    [LookupScript("Contratos.ServiciosHotel")]
    public class ServiciosHotelLookup : MultiTenantRowLookupScript<ServiciosHotelRow>
    {
        public ServiciosHotelLookup()
        {
            IdField     = ServiciosHotelRow.Fields.ServicioId.PropertyName;
            TextField   = ServiciosHotelRow.Fields.NombreServicio.PropertyName;
        }
    }
}
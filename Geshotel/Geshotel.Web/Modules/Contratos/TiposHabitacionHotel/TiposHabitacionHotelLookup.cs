namespace Geshotel.Contratos.Scripts
{
    using Entities;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Web;
    using Portal.Scripts;

    [LookupScript("Contratos.TiposHabitacionHotel")]
    public class TiposHabitacionHotelLookup : MultiTenantRowLookupScript<TiposHabitacionHotelRow>
    {
        public TiposHabitacionHotelLookup()
        {
            IdField     = TiposHabitacionHotelRow.Fields.TipoHabitacionId.PropertyName;
            TextField   = TiposHabitacionHotelRow.Fields.TipoHabitacionName.PropertyName;
        }
    }
}
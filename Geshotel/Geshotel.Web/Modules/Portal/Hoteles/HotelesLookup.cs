

namespace Geshotel.Portal.Scripts
{
    using Entities;
    using Serenity.ComponentModel;
    using Serenity.Web;
    using System;

    [LookupScript("Portal.Hoteles")]
    public class HotelesLookup : MultiTenantRowLookupScript<HotelesRow>
    {
        public HotelesLookup()
        {
            this.Expiration = TimeSpan.FromMinutes(5);
        }
    }
}
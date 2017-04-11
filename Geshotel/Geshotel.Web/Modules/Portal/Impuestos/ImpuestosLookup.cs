

namespace Geshotel.Portal.Scripts
{
    using Entities;
    using Serenity.ComponentModel;
    using Serenity.Web;
    using System;

    [LookupScript("Portal.Impuestos")]
    public class ImpuestosLookup : MultiTenantRowLookupScript<ImpuestosRow>
    {
        public ImpuestosLookup()
        {
            this.Expiration = TimeSpan.FromMinutes(5);
        }
    }
}
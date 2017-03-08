namespace Geshotel.Contratos.Scripts
{
    using Entities;
    using Serenity.ComponentModel;
    using Serenity.Web;
    using Portal.Scripts;
    [LookupScript("Contratos.Agencias")]
    public class AgenciasLookup : MultiTenantRowLookupScript<AgenciasRow>
    {

    }
}
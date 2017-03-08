namespace Geshotel.Contratos.Scripts
{
    using Entities;
    using Serenity.ComponentModel;
    using Serenity.Web;
    using Portal.Scripts;
    [LookupScript("Contratos.Clientes")]
    public class ClientesLookup : MultiTenantRowLookupScript<ClientesRow>
    {

    }
}
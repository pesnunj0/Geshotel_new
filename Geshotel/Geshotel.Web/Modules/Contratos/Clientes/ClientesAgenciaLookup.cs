
namespace Geshotel.Contratos.Scripts
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Web;
    using Entities;

    [LookupScript("Contratos.ClientesAgencia")]
    public class ClientesAgenciaLookup : RowLookupScript<ClientesRow>
    {
        public ClientesAgenciaLookup()
        {
            IdField = ClientesRow.Fields.ClienteId.PropertyName;
            TextField = ClientesRow.Fields.Razon.PropertyName;
        }

        protected override void PrepareQuery(SqlQuery query)
        {
            var fld = ClientesRow.Fields;
            query.Distinct(true)
                .Select(fld.Razon)
                .Where(
                    new Criteria(fld.GrupoClienteId) == "1") ;
       }

        protected override void ApplyOrder(SqlQuery query)
        {
        }
    }
}

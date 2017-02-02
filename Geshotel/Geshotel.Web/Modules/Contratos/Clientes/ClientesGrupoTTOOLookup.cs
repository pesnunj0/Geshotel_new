
namespace Geshotel.Contratos.Scripts
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Web;
    using Entities;
    using Portal.Entities;

    [LookupScript("Contratos.ClientesGrupoTTOOLookup")]
    public class ClientesGrupoTTOOLookup : RowLookupScript<GruposDeClienteRow>
    {
        public ClientesGrupoTTOOLookup()
        {
            IdField = GruposDeClienteRow.Fields.GrupoClienteId.PropertyName;
            TextField = GruposDeClienteRow.Fields.NombreGrupo.PropertyName;
        }

        protected override void PrepareQuery(SqlQuery query)
        {
            var fld = GruposDeClienteRow.Fields;
            query.Distinct(true)
                .Select(fld.NombreGrupo)
                .Where(
                    new Criteria(fld.GrupoClienteId) == "2") ;
       }

        protected override void ApplyOrder(SqlQuery query)
        {
        }
    }
}

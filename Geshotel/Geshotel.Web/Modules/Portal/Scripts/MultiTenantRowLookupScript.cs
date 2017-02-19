
using Serenity;
using Serenity.Data;
using Serenity.Web;
using System;
using Geshotel.Portal.Entities;
using Geshotel.Administration;

// ********************************************************************************************************************
// Script for filtering LookupEditors
// Based on Volkans Example Chapter Multi Tenancy --> Handling Lookup Scripts
// With Behavior we filtered Rows but not LookupScrpts / Editors
// Very important: Remove  [LookupScript("Portal.Hoteles")] as example at HotelesRow or whatever
// And add it to a new class Foe example HotelesLookup that call to this script
// Also important at LookupEditor not using typeof, use [LookupEditor("Portal.Hoteles"]
// If it is administrator no filter is applied
// If it has permissionKeys.Empresa then filter all hotels belonged to the company 
// Otherwise only one hotel can be choosen
// Javier on February 2017
// *********************************************************************************************************************

namespace Geshotel.Portal.Scripts
{
    public abstract class MultiTenantRowLookupScript<TRow> :
           RowLookupScript<TRow>
           where TRow : Row, ITenantRow, new()
    {
        public MultiTenantRowLookupScript()
        {
            Expiration = TimeSpan.FromDays(-1);
        }

        protected override void PrepareQuery(SqlQuery query)
        {

            base.PrepareQuery(query);
            if (!Authorization.HasPermission(PermissionKeys.Security))
                AddTenantFilter(query);
        }

        protected void AddTenantFilter(SqlQuery query)
        {
            var r = new TRow();

                if (Authorization.HasPermission(PermissionKeys.Empresa))
                {
                    query.Where(r.EmpresaIdField == (((UserDefinition)Authorization.UserDefinition).EmpresaId ?? -1));
                }
                else
                {
                    query.Where(r.HotelIdField == (((UserDefinition)Authorization.UserDefinition).HotelId ?? -1));
                }
        }

        public override string GetScript()
        {
            if (Authorization.HasPermission(PermissionKeys.Security))
                return base.GetScript();
            if (Authorization.HasPermission(PermissionKeys.Empresa))
                return TwoLevelCache.GetLocalStoreOnly("MultiTenantLookup:" +
                    this.ScriptName + ":" +
                    ((UserDefinition)Authorization.UserDefinition).EmpresaId,
                    TimeSpan.FromHours(1),
                new TRow().GetFields().GenerationKey, () =>
                {
                    return base.GetScript();
                });

            return TwoLevelCache.GetLocalStoreOnly("MultiTenantLookup:" +
                    this.ScriptName + ":" +
                    ((UserDefinition)Authorization.UserDefinition).HotelId,
                    TimeSpan.FromHours(1),
                new TRow().GetFields().GenerationKey, () =>
                {
                    return base.GetScript();
                });
        }

    }
}
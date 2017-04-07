// --------------------------------------------------------------------------------
// Tenant Behavior
// Based on Serenity Developer Guide By Volkan Ceylan
// Have a look at Multi Tenancy Chapter
// The scope is to filter Rows by hotel_id or empresa_id that match
// with corresponding fields stored in Users table
// Created by Javier on February 2017
// --------------------------------------------------------------------------------
using Geshotel.Administration;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;

namespace Geshotel.Behaviors
{
    public class TenantBehavior :  IImplicitBehavior,
        ISaveBehavior, IDeleteBehavior,
        IListBehavior, IRetrieveBehavior
    {
        private Int16Field fldHotelId;
        private Int16Field fldEmpresaId;
        //private Boolean isSpecialRow;

        public bool ActivateFor(Row row)
        {
            // **************************************************************************************************************************
            // I'm gonna change my first scope so  Authorization.HasPermission(PermissionKeys.Security) won´t have any restriction 
            // so nothing to do
            // If they have  Authorization.HasPermission(PermissionKeys.Empresa) then query will be filtered only by EmpresaID 
            // otherwise query will be filtered by hotelId
            // 
            // 
            //  will check if fields hotel_id or empresa_id exists in Row
            // If exists then return true else return false
            //
            // Note: We do not look for iTenant row at all
            // Javier on February 2017
            // ***************************************************************************************************************************

            //isSpecialRow = false;
            //var mt =row as Portal.Entities.ITenantRow;
            //if (mt != null)
            //{
            //    isSpecialRow = true;
            //}

            // If administrator nothing to do doesn´t matter fields
            if (Authorization.HasPermission(PermissionKeys.Security))
                return false;

            fldHotelId = (row.FindFieldByPropertyName("HotelId") ??
               row.FindField("hotel_id")) as Int16Field;

            fldEmpresaId = (row.FindFieldByPropertyName("EmpresaId") ??
               row.FindField("empresa_id")) as Int16Field;

            return !ReferenceEquals(null, fldHotelId) ||
                !ReferenceEquals(null, fldEmpresaId);
        }

        public void OnPrepareQuery(IRetrieveRequestHandler handler,
            SqlQuery query)
        {
            var user = (UserDefinition)Authorization.UserDefinition;
            // -----------------------------------------------------------------------------------------------------
            // If is Administrator then can see all records
            // otherwise filter by hotel if hotel_id field is in row or filter by empresa_if empresa_id is in row
            // Javier Feb 2017
            // -----------------------------------------------------------------------------------------------------

            if (Authorization.HasPermission(PermissionKeys.Security))
                return;
            // ******************************************************************************************
            // We always filter by empresa_id becouse all rows with field hotel_id has also empresa_id
            // But not all rows that have empresa_id have also hotel_id
            // ******************************************************************************************
            query.Where(fldEmpresaId == (user.EmpresaId ?? -1));
            // if has no empresa permission and exist HotelId field we filter by HotelId
            if (!Authorization.HasPermission(PermissionKeys.Empresa) & !ReferenceEquals(null, fldHotelId))
                query.Where(fldHotelId == (user.HotelId ?? -1));

        }

        public void OnPrepareQuery(IListRequestHandler handler,
            SqlQuery query)
        {
            var user = (UserDefinition)Authorization.UserDefinition;
            // -----------------------------------------------------------------------------------------------------
            // If is Administrator then can see all records
            // otherwise filter by hotel if hotel_id field is in row or filter by empresa_if empresa_id is in row
            // Javier Feb 2017
            // -----------------------------------------------------------------------------------------------------

            if (Authorization.HasPermission(PermissionKeys.Security))
                return;
            // ******************************************************************************************
            // We always filter by empresa_id becouse all rows with field hotel_id has also empresa_id
            // ******************************************************************************************
            query.Where(fldEmpresaId == (user.EmpresaId ?? -1));
            // if has no empresa permission and exist HotelId field we filter by HotelId
            if (!Authorization.HasPermission(PermissionKeys.Empresa) & !ReferenceEquals(null, fldHotelId))
                query.Where(fldHotelId == (user.HotelId ?? -1));

        }

        public void OnSetInternalFields(ISaveRequestHandler handler)
        {
            if (handler.IsCreate)
            {
                if (!ReferenceEquals(null, fldEmpresaId))
                    fldEmpresaId[handler.Row] = ((UserDefinition)Authorization.UserDefinition).EmpresaId;

                if (!Authorization.HasPermission(PermissionKeys.Empresa) & !ReferenceEquals(null, fldHotelId))
                    fldHotelId[handler.Row] = ((UserDefinition)Authorization.UserDefinition).HotelId;
            }
        }

        public void OnValidateRequest(IDeleteRequestHandler handler)
        {
            var user = (UserDefinition)Authorization.UserDefinition;
            if (fldEmpresaId[handler.Row] != user.EmpresaId)
                Authorization.ValidatePermission(
                    PermissionKeys.Security);
            if (fldHotelId[handler.Row] != user.HotelId)
                Authorization.ValidatePermission(
                    PermissionKeys.Empresa);
        }

        public void OnAfterDelete(IDeleteRequestHandler handler) { }
        public void OnAfterExecuteQuery(IRetrieveRequestHandler handler) { }
        public void OnAfterExecuteQuery(IListRequestHandler handler) { }
        public void OnAfterSave(ISaveRequestHandler handler) {}
        public void OnApplyFilters(IListRequestHandler handler, SqlQuery query) { }
        public void OnAudit(IDeleteRequestHandler handler) { }
        public void OnAudit(ISaveRequestHandler handler) { }
        public void OnBeforeDelete(IDeleteRequestHandler handler) { }
        public void OnBeforeExecuteQuery(IRetrieveRequestHandler handler) { }
        public void OnBeforeExecuteQuery(IListRequestHandler handler) { }
        public void OnBeforeSave(ISaveRequestHandler handler) { }
        public void OnPrepareQuery(IDeleteRequestHandler handler, SqlQuery query) { }
        public void OnPrepareQuery(ISaveRequestHandler handler, SqlQuery query) { }
        public void OnReturn(IDeleteRequestHandler handler) { }
        public void OnReturn(IRetrieveRequestHandler handler) { }
        public void OnReturn(IListRequestHandler handler) { }
        public void OnReturn(ISaveRequestHandler handler) { }
        public void OnValidateRequest(IRetrieveRequestHandler handler) { }
        public void OnValidateRequest(IListRequestHandler handler) { }
        public void OnValidateRequest(ISaveRequestHandler handler) { }
    }
}
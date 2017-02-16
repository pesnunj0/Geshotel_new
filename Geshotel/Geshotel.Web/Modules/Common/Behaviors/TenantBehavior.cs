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
    public class TenantBehavior : IImplicitBehavior,
        ISaveBehavior, IDeleteBehavior,
        IListBehavior, IRetrieveBehavior
    {
        private Int16Field fldHotelId;
        private Int16Field fldEmpresaId;
        private Boolean isSpecialRow;

        public bool ActivateFor(Row row)
        {
            // ********************************************************************************************************
            // Only special Rows like UsersRow, EmpresasRow or HotelesRow will have defined ITenantRow interface
            // these rows are special and only administrators can insert, or update. 
            // I don´t know yet if others can read o no, so I prefer to leave this door open.
            // 
            // Rest of 
            // Then I will check if fields hotel_id or empresa_id exists in Row
            // If exists then return true else return false
            // Javier on February 2017
            // *********************************************************************************************************

            isSpecialRow = false;
            var mt =row as Portal.Entities.ITenantRow;
            if (mt != null)
            {
                isSpecialRow = true;
            }
                
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
            // If isSpecialRow and is Administrator then can see all records
            // otherwise filter by hotel if hotel_id field is in row or filter by empresa_if empresa_id is in row
            // Javier Feb 2017
            // -----------------------------------------------------------------------------------------------------

            if (isSpecialRow & Authorization.HasPermission(PermissionKeys.Security))
                return;

            if (!ReferenceEquals(null, fldHotelId))        
                query.Where(fldHotelId == user.HotelId);           
            else
                if (!ReferenceEquals(null, fldEmpresaId))
                    query.Where(fldEmpresaId == user.EmpresaId);
        }

        public void OnPrepareQuery(IListRequestHandler handler,
            SqlQuery query)
        {
            var user = (UserDefinition)Authorization.UserDefinition;
            // -----------------------------------------------------------------------------------------------------
            // If isSpecialRow and is Administrator then can see all records
            // otherwise filter by hotel if hotel_id field is in row or filter by empresa_if empresa_id is in row
            // Javier Feb 2017
            // -----------------------------------------------------------------------------------------------------

            if (isSpecialRow & Authorization.HasPermission(PermissionKeys.Security))
                return;

            if (!ReferenceEquals(null, fldHotelId))
                query.Where(fldHotelId == user.HotelId);
            if (!ReferenceEquals(null, fldEmpresaId))
                query.Where(fldEmpresaId == user.EmpresaId);
        }

        public void OnSetInternalFields(ISaveRequestHandler handler)
        {
            if (handler.IsCreate & !isSpecialRow)
            {
                if (!ReferenceEquals(null, fldHotelId))
                    fldHotelId[handler.Row] = ((UserDefinition)Authorization.UserDefinition).HotelId;
                else
                     if (!ReferenceEquals(null, fldEmpresaId))       
                        fldEmpresaId[handler.Row] = ((UserDefinition)Authorization.UserDefinition).EmpresaId;
            }
        }

        public void OnValidateRequest(IDeleteRequestHandler handler)
        {
            var user = (UserDefinition)Authorization.UserDefinition;
            if (fldEmpresaId[handler.Row] != user.EmpresaId)
                Authorization.ValidatePermission(
                    PermissionKeys.Empresa);
            if (fldHotelId[handler.Row] != user.HotelId)
                Authorization.ValidatePermission(
                    PermissionKeys.Hotel);
        }

        public void OnAfterDelete(IDeleteRequestHandler handler) { }
        public void OnAfterExecuteQuery(IRetrieveRequestHandler handler) { }
        public void OnAfterExecuteQuery(IListRequestHandler handler) { }
        public void OnAfterSave(ISaveRequestHandler handler) { }
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
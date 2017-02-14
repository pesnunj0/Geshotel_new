

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

        public bool ActivateFor(Row row)
        {
            // ********************************************************************************************************
            // As Almost all tables except UsersRow, EmpresasRow or HotelesRow  must be filtered even for Administrartors
            // We check if TenantRow is implemented in Row Then Return false
            // becouse these tables are special and only administrators can insert, or update fields.
            // 
            // Otherwise I will check if fields hotel_id or empresa_id exists in Row
            // If exists then return true else return false
            // WARNING I'm not sure about the correct functionality. Let's see
            // Javier on February 2017
            // *********************************************************************************************************
            var mt = row as Geshotel.Portal.Entities.ITenantRow;
            if (mt != null)
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

            if (!ReferenceEquals(null, fldHotelId))
                query.Where(fldHotelId == user.HotelId);
            if (!ReferenceEquals(null, fldEmpresaId))
                query.Where(fldEmpresaId == user.EmpresaId);
        }

        public void OnPrepareQuery(IListRequestHandler handler,
            SqlQuery query)
        {
            var user = (UserDefinition)Authorization.UserDefinition;
            if (!ReferenceEquals(null, fldHotelId))
                query.Where(fldHotelId == user.HotelId);
            if (!ReferenceEquals(null, fldEmpresaId))
                query.Where(fldEmpresaId == user.EmpresaId);
        }

        public void OnSetInternalFields(ISaveRequestHandler handler)
        {
            if (handler.IsCreate)
            {
                fldHotelId[handler.Row] = ((UserDefinition)Authorization.UserDefinition).HotelId;
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
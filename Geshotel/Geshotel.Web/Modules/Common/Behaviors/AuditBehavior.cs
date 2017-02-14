
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Globalization;

namespace Geshotel.Behaviors
{
    public class AuditBehavior : BaseSaveBehavior, IImplicitBehavior
    {
        private Field UserId;
        private DateTimeField LastModification;

        public bool ActivateFor(Row row)
        {
            
            LastModification = (row.FindFieldByPropertyName("FechaModificacion") ??
                row.FindField("fecha_modificacion")) as DateTimeField;

            UserId = row.FindFieldByPropertyName("UserId") ??
                row.FindField("user_id");

            return !ReferenceEquals(null, LastModification) &&
                !ReferenceEquals(null, UserId);
        }

        public override void OnSetInternalFields(ISaveRequestHandler handler)
        {
            LastModification[handler.Row] = DateTime.Now;
            UserId.AsObject(handler.Row, Authorization.UserId == null ? null : 
                UserId.ConvertValue(Authorization.UserId, CultureInfo.InvariantCulture));
        }
    }
}
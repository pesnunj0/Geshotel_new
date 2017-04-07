
using Serenity.ComponentModel;
using Serenity.Services;

namespace Geshotel.Recepcion
{
    [ScriptInclude]
    public enum ReservationStatus
    {
        ArrivalPending = 1,
        Cancelled = 2,
        CheckedIn = 3,
        CheckedOut = 4,
        Finished = 5
    }

    public class CheckInRequest : ServiceRequest
    {
        public int? ReservaId { get; set; }
    }

    public class CheckInResponse : ServiceResponse
    {
    }
}

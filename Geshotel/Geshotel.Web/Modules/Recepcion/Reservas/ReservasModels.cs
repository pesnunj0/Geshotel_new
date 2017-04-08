
using Serenity.ComponentModel;
using Serenity.Services;

namespace Geshotel.Recepcion
{
    [ScriptInclude]
    public enum ReservationStatus
    {
        WithErrors = 0,
        ArrivalPending = 1,
        Cancelled = 2,
        CheckedIn = 3,
        PreCheckedOut = 4,
        CheckedOut = 5,
        NoShow = 6
    }

    public class ChangeReservationStatusRequest : ServiceRequest
    {
        public int? ReservaId { get; set; }
        public int? NewStatusId { get; set; }
    }

    public class ChangeReservationStatusResponse : ServiceResponse
    {

    }

    public class CheckInRequest : ServiceRequest
    {
        public int? ReservaId { get; set; }
    }

    public class CheckInResponse : ServiceResponse
    {
    }
}

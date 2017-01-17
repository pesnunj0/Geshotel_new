
using Serenity.ComponentModel;
using System.ComponentModel;

namespace Geshotel.Meeting
{
    [EnumKey("Meeting.MeetingAttendeeType")]
    public enum MeetingAttendeeType
    {
        [Description("Attendee")]
        Attendee = 1,
        [Description("Guest")]
        Guest = 2
    }
}
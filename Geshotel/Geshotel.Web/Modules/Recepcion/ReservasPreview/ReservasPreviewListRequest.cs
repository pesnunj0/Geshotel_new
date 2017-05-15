using Serenity.Services;

namespace Geshotel.Recepcion
{
    public class ReservasPreviewListRequest : ListRequest
    {
        public int? ReservaId { get; set; }
    }
} 

namespace Geshotel.Recepcion.Endpoints
{
    using Serenity.Services;
    using System.Web.Mvc;
    using MyRepository = Repositories.ReservasPreviewRepository;
    using MyRow = Entities.ReservasHuespedesRow;

    [RoutePrefix("Services/Recepcion/ReservasPreview"), Route("{action}")]
    [ServiceAuthorize(typeof(MyRow))]
    // Same ServiceAuthorize than ReservasHuespedesRow
    public class ReservasPreviewController : ServiceEndpoint
    {
        public ListResponse<ReservasPreviewItem> List(ReservasPreviewListRequest request)
        {
            return new MyRepository().List(request);
        }
    }
}

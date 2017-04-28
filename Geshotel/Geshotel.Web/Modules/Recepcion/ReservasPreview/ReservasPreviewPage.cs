namespace Geshotel.Recepcion.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Recepcion/ReservasPreview"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ReservasRow))]
    public class RservasPreviewController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Recepcion/RservasPreview/RservaspreviewIndex.cshtml");
        }
    }
}
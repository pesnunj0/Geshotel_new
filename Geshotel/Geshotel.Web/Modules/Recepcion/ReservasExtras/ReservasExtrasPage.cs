
namespace Geshotel.Recepcion.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Recepcion/ReservasExtras"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ReservasServiciosRow))]
    public class ReservasExtrasController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Recepcion/ReservasExtras/ReservasExtrasIndex.cshtml");
        }
    }
}
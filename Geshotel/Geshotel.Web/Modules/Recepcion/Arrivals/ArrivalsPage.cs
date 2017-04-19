


namespace Geshotel.Recepcion.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Recepcion/Arrivals"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ReservasRow))]
    public class ArrivalsController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Recepcion/Arrivals/ArrivalsIndex.cshtml");
        }
    }
}
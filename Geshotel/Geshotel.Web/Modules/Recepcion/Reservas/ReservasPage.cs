


namespace Geshotel.Recepcion.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Recepcion/Reservas"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ReservasRow))]
    public class ReservasController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Recepcion/Reservas/ReservasIndex.cshtml");
        }
    }
}
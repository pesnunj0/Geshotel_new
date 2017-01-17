


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/ComunidadesAutonomas"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ComunidadesAutonomasRow))]
    public class ComunidadesAutonomasController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/ComunidadesAutonomas/ComunidadesAutonomasIndex.cshtml");
        }
    }
}
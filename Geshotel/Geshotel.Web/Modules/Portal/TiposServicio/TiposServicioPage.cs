


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/TiposServicio"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TiposServicioRow))]
    public class TiposServicioController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/TiposServicio/TiposServicioIndex.cshtml");
        }
    }
}
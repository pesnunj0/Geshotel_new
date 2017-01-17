


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/Hoteles"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.HotelesRow))]
    public class HotelesController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/Hoteles/HotelesIndex.cshtml");
        }
    }
}
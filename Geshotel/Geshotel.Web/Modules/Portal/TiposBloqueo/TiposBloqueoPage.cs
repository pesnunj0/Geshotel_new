


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/TiposBloqueo"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TiposBloqueoRow))]
    public class TiposBloqueoController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/TiposBloqueo/TiposBloqueoIndex.cshtml");
        }
    }
}
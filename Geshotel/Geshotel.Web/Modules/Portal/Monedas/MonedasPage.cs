


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/Monedas"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.MonedasRow))]
    public class MonedasController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/Monedas/MonedasIndex.cshtml");
        }
    }
}
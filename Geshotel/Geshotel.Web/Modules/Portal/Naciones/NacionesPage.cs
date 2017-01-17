


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/Naciones"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.NacionesRow))]
    public class NacionesController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/Naciones/NacionesIndex.cshtml");
        }
    }
}
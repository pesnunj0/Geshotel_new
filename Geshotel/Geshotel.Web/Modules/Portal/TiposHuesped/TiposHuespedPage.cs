

namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/TiposHuesped"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TiposHuespedRow))]
    public class TiposHuespedController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/TiposHuesped/TiposHuespedIndex.cshtml");
        }
    }
}
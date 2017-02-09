


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/TiposCondicion"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TiposCondicionRow))]
    public class TiposCondicionController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/TiposCondicion/TiposCondicionIndex.cshtml");
        }
    }
}



namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/TiposDeImputacion"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TiposDeImputacionRow))]
    public class TiposDeImputacionController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/TiposDeImputacion/TiposDeImputacionIndex.cshtml");
        }
    }
}
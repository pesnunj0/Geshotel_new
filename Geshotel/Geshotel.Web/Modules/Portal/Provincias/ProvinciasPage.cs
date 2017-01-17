


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/Provincias"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ProvinciasRow))]
    public class ProvinciasController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/Provincias/ProvinciasIndex.cshtml");
        }
    }
}
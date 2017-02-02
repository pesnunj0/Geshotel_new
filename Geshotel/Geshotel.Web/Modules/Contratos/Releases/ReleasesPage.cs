

namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/Releases"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ReleasesRow))]
    public class ReleasesController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/Releases/ReleasesIndex.cshtml");
        }
    }
}
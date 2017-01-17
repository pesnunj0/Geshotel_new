


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/TiposUnidadCalculo"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TiposUnidadCalculoRow))]
    public class TiposUnidadCalculoController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/TiposUnidadCalculo/TiposUnidadCalculoIndex.cshtml");
        }
    }
}
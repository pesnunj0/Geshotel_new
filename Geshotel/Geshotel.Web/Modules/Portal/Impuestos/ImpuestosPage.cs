

namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/Impuestos"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ImpuestosRow))]
    public class ImpuestosController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/Impuestos/ImpuestosIndex.cshtml");
        }
    }
}
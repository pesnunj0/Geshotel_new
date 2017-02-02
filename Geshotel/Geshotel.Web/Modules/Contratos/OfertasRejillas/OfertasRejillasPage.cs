

namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/OfertasRejillas"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.OfertasRejillasRow))]
    public class OfertasRejillasController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/OfertasRejillas/OfertasRejillasIndex.cshtml");
        }
    }
}
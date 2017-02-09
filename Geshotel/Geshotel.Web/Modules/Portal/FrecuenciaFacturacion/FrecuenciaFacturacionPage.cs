


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/FrecuenciaFacturacion"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.FrecuenciaFacturacionRow))]
    public class FrecuenciaFacturacionController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/FrecuenciaFacturacion/FrecuenciaFacturacionIndex.cshtml");
        }
    }
}
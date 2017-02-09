


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/TipoAplicacionOferta"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TipoAplicacionOfertaRow))]
    public class TipoAplicacionOfertaController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/TipoAplicacionOferta/TipoAplicacionOfertaIndex.cshtml");
        }
    }
}
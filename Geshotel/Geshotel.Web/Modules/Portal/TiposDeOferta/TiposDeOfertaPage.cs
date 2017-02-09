


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/TiposDeOferta"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TiposDeOfertaRow))]
    public class TiposDeOfertaController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/TiposDeOferta/TiposDeOfertaIndex.cshtml");
        }
    }
}
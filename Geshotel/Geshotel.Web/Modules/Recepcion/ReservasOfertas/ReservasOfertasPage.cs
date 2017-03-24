


namespace Geshotel.Recepcion.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Recepcion/ReservasOfertas"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ReservasOfertasRow))]
    public class ReservasOfertasController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Recepcion/ReservasOfertas/ReservasOfertasIndex.cshtml");
        }
    }
}
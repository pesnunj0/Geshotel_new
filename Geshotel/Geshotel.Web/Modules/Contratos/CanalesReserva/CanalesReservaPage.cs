


namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/CanalesReserva"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.CanalesReservaRow))]
    public class CanalesReservaController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/CanalesReserva/CanalesReservaIndex.cshtml");
        }
    }
}
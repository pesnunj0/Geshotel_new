


namespace Geshotel.Recepcion.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Recepcion/ReservasContratos"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ReservasContratosRow))]
    public class ReservasContratosController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Recepcion/ReservasContratos/ReservasContratosIndex.cshtml");
        }
    }
}
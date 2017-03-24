


namespace Geshotel.Recepcion.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Recepcion/ReservasDescuentos"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ReservasDescuentosRow))]
    public class ReservasDescuentosController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Recepcion/ReservasDescuentos/ReservasDescuentosIndex.cshtml");
        }
    }
}
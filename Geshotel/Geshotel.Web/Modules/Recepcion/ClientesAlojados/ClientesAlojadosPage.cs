


namespace Geshotel.Recepcion.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Recepcion/ClientesAlojados"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ReservasHuespedesRow))]
    public class ClientesAlojadosController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Recepcion/ClientesAlojados/ClientesAlojadosIndex.cshtml");
        }
    }
}
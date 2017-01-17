


namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/Clientes"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ClientesRow))]
    public class ClientesController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/Clientes/ClientesIndex.cshtml");
        }
    }
}
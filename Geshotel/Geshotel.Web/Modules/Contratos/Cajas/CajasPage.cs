

namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/Cajas"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.CajasRow))]
    public class CajasController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/Cajas/CajasIndex.cshtml");
        }
    }
}
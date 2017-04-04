


namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/Contadores"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ContadoresRow))]
    public class ContadoresController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/Contadores/ContadoresIndex.cshtml");
        }
    }
}
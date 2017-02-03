


namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/Mercados"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.MercadosRow))]
    public class MercadosController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/Mercados/MercadosIndex.cshtml");
        }
    }
}
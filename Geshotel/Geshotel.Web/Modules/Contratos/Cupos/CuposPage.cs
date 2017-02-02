


namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/Cupos"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.CuposRow))]
    public class CuposController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/Cupos/CuposIndex.cshtml");
        }
    }
}



namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/Empresas"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.EmpresasRow))]
    public class EmpresasController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/Empresas/EmpresasIndex.cshtml");
        }
    }
}
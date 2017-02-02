


namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/Lineas"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.LineasRow))]
    public class LineasController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/Lineas/LineasIndex.cshtml");
        }
    }
}
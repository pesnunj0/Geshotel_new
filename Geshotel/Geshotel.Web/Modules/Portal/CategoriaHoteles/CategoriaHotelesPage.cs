

namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/CategoriaHoteles"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.CategoriaHotelesRow))]
    public class CategoriaHotelesController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/CategoriaHoteles/CategoriaHotelesIndex.cshtml");
        }
    }
}
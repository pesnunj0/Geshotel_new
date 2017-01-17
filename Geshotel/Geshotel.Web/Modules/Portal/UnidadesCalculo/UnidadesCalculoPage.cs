


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/UnidadesCalculo"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.UnidadesCalculoRow))]
    public class UnidadesCalculoController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/UnidadesCalculo/UnidadesCalculoIndex.cshtml");
        }
    }
}



namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/Servicios"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ServiciosRow))]
    public class ServiciosController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/Servicios/ServiciosIndex.cshtml");
        }
    }
}
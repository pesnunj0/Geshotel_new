


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/GruposDeServicios"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.GruposDeServiciosRow))]
    public class GruposDeServiciosController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/GruposDeServicios/GruposDeServiciosIndex.cshtml");
        }
    }
}
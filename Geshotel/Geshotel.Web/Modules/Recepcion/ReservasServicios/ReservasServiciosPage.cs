

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Recepcion/ReservasServicios", typeof(Geshotel.Recepcion.Pages.ReservasServiciosController))]

namespace Geshotel.Recepcion.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Recepcion/ReservasServicios"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ReservasServiciosRow))]
    public class ReservasServiciosController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Recepcion/ReservasServicios/ReservasServiciosIndex.cshtml");
        }
    }
}
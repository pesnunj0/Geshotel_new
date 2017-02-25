

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Recepcion/ReservasHuespedes", typeof(Geshotel.Recepcion.Pages.ReservasHuespedesController))]

namespace Geshotel.Recepcion.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Recepcion/ReservasHuespedes"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ReservasHuespedesRow))]
    public class ReservasHuespedesController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Recepcion/ReservasHuespedes/ReservasHuespedesIndex.cshtml");
        }
    }
}
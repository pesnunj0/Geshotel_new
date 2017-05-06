

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Recepcion/ReservasExtras", typeof(Geshotel.Recepcion.Pages.ReservasExtrasController))]

namespace Geshotel.Recepcion.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Recepcion/ReservasExtras"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ReservasExtrasRow))]
    public class ReservasExtrasController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Recepcion/ReservasExtras/ReservasExtrasIndex.cshtml");
        }
    }
}
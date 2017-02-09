
[assembly: Serenity.Navigation.NavigationLink(int.MaxValue, "Contratos/Ofertas", typeof(Geshotel.Contratos.Pages.OfertasController))]

namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/Ofertas"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.OfertasRow))]
    public class OfertasController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/Ofertas/OfertasIndex.cshtml");
        }
    }
}
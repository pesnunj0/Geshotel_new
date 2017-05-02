

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Contratos/Facturas", typeof(Geshotel.Contratos.Pages.FacturasController))]

namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/Facturas"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.FacturasRow))]
    public class FacturasController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/Facturas/FacturasIndex.cshtml");
        }
    }
}


[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Contratos/LineasFactura", typeof(Geshotel.Contratos.Pages.LineasFacturaController))]

namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/LineasFactura"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.LineasFacturaRow))]
    public class LineasFacturaController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/LineasFactura/LineasFacturaIndex.cshtml");
        }
    }
}
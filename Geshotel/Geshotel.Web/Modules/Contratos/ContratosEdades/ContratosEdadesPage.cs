

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Contratos/ContratosEdades", typeof(Geshotel.Contratos.Pages.ContratosEdadesController))]

namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/ContratosEdades"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ContratosEdadesRow))]
    public class ContratosEdadesController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/ContratosEdades/ContratosEdadesIndex.cshtml");
        }
    }
}
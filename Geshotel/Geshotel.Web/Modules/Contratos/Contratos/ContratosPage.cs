

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Contratos/Contratos", typeof(Geshotel.Contratos.Pages.ContratosController))]

namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/Contratos"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ContratosRow))]
    public class ContratosController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/Contratos/ContratosIndex.cshtml");
        }
    }
}
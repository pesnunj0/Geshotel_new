

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Contratos/Agencias", typeof(Geshotel.Contratos.Pages.AgenciasController))]

namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/Agencias"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AgenciasRow))]
    public class AgenciasController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/Agencias/AgenciasIndex.cshtml");
        }
    }
}
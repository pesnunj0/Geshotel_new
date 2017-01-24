

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Contratos/LineasDeContrato", typeof(Geshotel.Contratos.Pages.LineasDeContratoController))]

namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/LineasDeContrato"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.LineasDeContratoRow))]
    public class LineasDeContratoController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/LineasDeContrato/LineasDeContratoIndex.cshtml");
        }
    }
}
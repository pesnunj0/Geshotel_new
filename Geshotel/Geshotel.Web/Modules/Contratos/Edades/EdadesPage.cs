


namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/Edades"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.EdadesRow))]
    public class EdadesController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/Edades/EdadesIndex.cshtml");
        }
    }
}
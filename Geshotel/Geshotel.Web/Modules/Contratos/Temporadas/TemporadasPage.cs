


namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/Temporadas"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TemporadasRow))]
    public class TemporadasController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/Temporadas/TemporadasIndex.cshtml");
        }
    }
}
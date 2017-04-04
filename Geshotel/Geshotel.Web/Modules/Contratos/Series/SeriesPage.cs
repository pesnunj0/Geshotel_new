

namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/Series"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.SeriesRow))]
    public class SeriesController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/Series/SeriesIndex.cshtml");
        }
    }
}



namespace Geshotel.Recepcion.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Recepcion/Departures"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ReservasRow))]
    public class DeparturesController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Recepcion/Departures/DeparturesIndex.cshtml");
        }
    }
}
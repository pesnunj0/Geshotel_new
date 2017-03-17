

namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/Habitaciones"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.HabitacionesRow))]
    public class HabitacionesController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/Habitaciones/HabitacionesIndex.cshtml");
        }
    }
}
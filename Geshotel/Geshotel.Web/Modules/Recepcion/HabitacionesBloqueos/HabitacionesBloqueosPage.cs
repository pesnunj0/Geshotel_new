

namespace Geshotel.Recepcion.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Recepcion/HabitacionesBloqueos"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.HabitacionesBloqueosRow))]
    public class HabitacionesBloqueosController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Recepcion/HabitacionesBloqueos/HabitacionesBloqueosIndex.cshtml");
        }
    }
}
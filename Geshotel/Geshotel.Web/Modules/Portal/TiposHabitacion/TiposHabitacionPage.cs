


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/TiposHabitacion"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TiposHabitacionRow))]
    public class TiposHabitacionController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/TiposHabitacion/TiposHabitacionIndex.cshtml");
        }
    }
}
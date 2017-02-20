


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/HabitacionesSituacion"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.HabitacionesSituacionRow))]
    public class HabitacionesSituacionController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/HabitacionesSituacion/HabitacionesSituacionIndex.cshtml");
        }
    }
}
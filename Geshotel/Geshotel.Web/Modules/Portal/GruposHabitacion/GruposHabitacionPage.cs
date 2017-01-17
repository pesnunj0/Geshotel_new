


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/GruposHabitacion"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.GruposHabitacionRow))]
    public class GruposHabitacionController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/GruposHabitacion/GruposHabitacionIndex.cshtml");
        }
    }
}
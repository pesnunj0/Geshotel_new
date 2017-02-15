

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Portal/TiposHabitacionHotel", typeof(Geshotel.Portal.Pages.TiposHabitacionHotelController))]

namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/TiposHabitacionHotel"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TiposHabitacionHotelRow))]
    public class TiposHabitacionHotelController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/TiposHabitacionHotel/TiposHabitacionHotelIndex.cshtml");
        }
    }
}
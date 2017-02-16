

namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/TiposHabitacionHotel"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TiposHabitacionHotelRow))]
    public class TiposHabitacionHotelController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/TiposHabitacionHotel/TiposHabitacionHotelIndex.cshtml");
        }
    }
}
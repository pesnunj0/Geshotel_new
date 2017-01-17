

namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/TiposHotel"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TiposHotelRow))]
    public class TiposHotelController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/TiposHotel/TiposHotelIndex.cshtml");
        }
    }
}
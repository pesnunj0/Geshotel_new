

namespace Geshotel.Contratos.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Contratos/ServiciosHotel"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ServiciosHotelRow))]
    public class ServiciosHotelController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Contratos/ServiciosHotel/ServiciosHotelIndex.cshtml");
        }
    }
}



namespace Geshotel.Recepcion.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Recepcion/Huespedes"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.HuespedesRow))]
    public class HuespedesController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Recepcion/Huespedes/HuespedesIndex.cshtml");
        }
    }
}
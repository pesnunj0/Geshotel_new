


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/FormasDePago"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.FormasDePagoRow))]
    public class FormasDePagoController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/FormasDePago/FormasDePagoIndex.cshtml");
        }
    }
}
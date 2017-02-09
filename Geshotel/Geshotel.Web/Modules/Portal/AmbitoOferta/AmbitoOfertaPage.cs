


namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/AmbitoOferta"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.AmbitoOfertaRow))]
    public class AmbitoOfertaController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/AmbitoOferta/AmbitoOfertaIndex.cshtml");
        }
    }
}
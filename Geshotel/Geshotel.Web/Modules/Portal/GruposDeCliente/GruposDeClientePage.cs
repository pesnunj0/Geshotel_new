

namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/GruposDeCliente"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.GruposDeClienteRow))]
    public class GruposDeClienteController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/GruposDeCliente/GruposDeClienteIndex.cshtml");
        }
    }
}
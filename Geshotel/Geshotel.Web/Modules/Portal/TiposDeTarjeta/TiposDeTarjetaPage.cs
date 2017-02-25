
namespace Geshotel.Portal.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Portal/TiposDeTarjeta"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TiposDeTarjetaRow))]
    public class TiposDeTarjetaController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Portal/TiposDeTarjeta/TiposDeTarjetaIndex.cshtml");
        }
    }
}
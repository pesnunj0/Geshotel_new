
namespace Geshotel.Recepcion.Pages
{
    using Serenity;
    using Serenity.Web;
    using Serenity.Data;
    using System.Web.Mvc;

    [RoutePrefix("Recepcion/Scheduler"), Route("{action=index}")]
    //[ReadPermission("Recepcion:Hotel")]
    //[ModifyPermission("Recepcion:Hotel")]
    [PageAuthorize(typeof(Entities.ReservasRow))]
    public class SchedulerController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Recepcion/Scheduler/SchedulerIndex.cshtml");
        }
    }
}
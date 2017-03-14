using System;
using System.Data;
using System.Drawing;
using System.Web.Mvc;
using Data;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Data;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Events.Scheduler;

namespace Geshotel.Recepcion.Pages
{
    using Serenity;
    using Serenity.Web;
    using Serenity.Data;
    using System.Web.Mvc;

    [RoutePrefix("Recepcion/Scheduler/Backend"), Route("{action=Backend}")]
    //[ReadPermission("Recepcion:Hotel")]
    //[ModifyPermission("Recepcion:Hotel")]
    [PageAuthorize(typeof(Entities.ReservasRow))]
    public class SchedulerController : Controller
    {
        

        public ActionResult Index()
        {
            
            return View("~/Modules/Recepcion/Scheduler/SchedulerIndex.cshtml");
        }

        public ActionResult Backend()
        {
            return new Scheduler().CallBack(this);
        }

        class Scheduler : DayPilotScheduler
        {
            private string LoadHotelId()
            {
                var user = (UserDefinition)Authorization.UserDefinition;
                string HotelId = Convert.ToString(user.HotelId);
                if (ClientState["filter"] != null)
                {
                    HotelId = (string)ClientState["filter"]["hotel_id"];
                }
                return HotelId;
            }
            protected override void OnInit(InitArgs e)
            {
                // *********************************
                // JN 2017
                // *********************************
                string hotelId = LoadHotelId();
                // *********************************
                DateTime fini = DateTime.Today.AddDays(-90);
                DateTime ffin = DateTime.Today.AddDays(180);

                DateTime start = new DateTime(fini.Year, fini.Month, 1, 12, 0, 0);
                DateTime end = new DateTime(ffin.Year, ffin.Month, 1, 12, 0, 0);

                //DateTime start = new DateTime(2017, 1, 1, 12, 0, 0);
                //DateTime end = new DateTime(2018, 1, 1, 12, 0, 0);

                Timeline = new TimeCellCollection();
                for (DateTime cell = start; cell < end; cell = cell.AddDays(1))
                {
                    Timeline.Add(cell, cell.AddDays(1));
                }

                LoadRoomsAndReservations(hotelId);
                ScrollTo(DateTime.Today.AddDays(-1));
                Separators.Add(DateTime.Now, Color.Red);
                UpdateWithMessage("Welcome!", CallBackUpdateType.Full);
            }

            private void LoadRoomsAndReservations(string hotelId)
            {
                LoadRooms(hotelId);
                LoadReservations(hotelId);
            }

            private void LoadReservations(string hotelId)
            {
                
                Events = Db.GetReservations(hotelId).Rows;
                
                DataStartField = "llegada";
                DataEndField = "salida";
                DataIdField = "reserva_id";
                DataTextField = "nombre_reserva";
                DataResourceField = "Roomid";

                DataTagFields = "estado_reserva_id";

            }

            private void LoadRooms(string hotelId)
            {
                Resources.Clear();

                string roomFilter = "0";
                if (ClientState["filter"] != null)
                {
                    roomFilter = (string)ClientState["filter"]["room"];
                }
                
                DataTable dt = Db.GetRoomsFiltered(roomFilter,hotelId);

                foreach (DataRow r in dt.Rows)
                {
                    string tipo = (string)r["RoomType"];
                    string name = (string)r["RoomName"];
                    string id = Convert.ToString(r["RoomId"]);
                    string status = (string)r["RoomStatus"];
                    int beds = Convert.ToInt32(r["RoomSize"]);
                    string bedsFormatted = (beds == 1) ? "1 bed" : String.Format("{0} beds", beds);
                    if (status=="")
                    {
                        bedsFormatted = "";

                    }

                    Resource res = new Resource(name, id);
                    res.DataItem = r;
                    res.Columns.Add(new ResourceColumn(tipo));
                    res.Columns.Add(new ResourceColumn(bedsFormatted));
                    res.Columns.Add(new ResourceColumn(status));

                    Resources.Add(res);
                }
            }

            protected override void OnEventMove(EventMoveArgs e)
            {

                string id = e.Id;
                DateTime start = e.NewStart;
                DateTime end = e.NewEnd;
                string resource = e.NewResource;

                // *********************************
                // JN 2017
                // *********************************
                string hotelId = Db.DimeHotel(id);
                // *********************************

                string message = null;
                if (!Db.IsFree(id, start, end, resource))
                {
                    message = "The reservation cannot overlap with an existing reservation.";
                }
                else if (e.OldEnd <= DateTime.Today)
                {
                    message = "This reservation cannot be changed anymore.";
                }
                else if (e.NewStart < DateTime.Today)
                {
                    message = "The reservation cannot be moved to the past.";
                }
                else
                {
                    // Primero intentamos borrar el anterior habitaciones_bloqueo
                    if (!e.OldResource.EndsWith("000")) // Si tenía habitacion asignada entonces la borro 
                        Db.DeleteHabitacionesBloqueo(e.Id, e.OldStart, e.OldEnd, e.OldResource);
                    if (!e.NewResource.EndsWith("000")) // Si asigno una habitacion válida, entonces
                        Db.MoveReservation(e.Id, e.NewStart, e.NewEnd, e.NewResource);
                }

                LoadReservations(hotelId);
                UpdateWithMessage(message);
            }

            protected override void OnEventResize(EventResizeArgs e)
            {
                // *********************************
                // JN 2017
                // *********************************
                string hotelId = Db.DimeHotel(e.Id);
                // *********************************
                Db.MoveReservation(e.Id, e.NewStart, e.NewEnd, e.Resource);
                LoadReservations(hotelId);
                Update();
            }

            protected override void OnBeforeEventRender(BeforeEventRenderArgs e)
            {
                e.Html = String.Format("{0} ({1:d} - {2:d})", e.Text, e.Start, e.End);
                int status = Convert.ToInt32(e.Tag["estado_reserva_id"]);
                string ttoo = (String)e.DataItem["ttoo"];
                e.ToolTip = String.Format("Id={0}-{1}-{2}pax", e.Id, e.DataItem["ttoo"], e.DataItem["pax"]);
//                e.ToolTip = "ID=" + (String)e.Id + "-" + ttoo + " " + (String)e.DataItem["pax"]+"pax";
                switch (status)
                {
                    case 0: // Pendiente de Finalizar. Reserva con errores
                        if (e.Start < DateTime.Today.AddDays(2)) // must be confirmed two day in advance
                        {
                            e.DurationBarColor = "red";
                            e.ToolTip += "Expired (not confirmed in time)";
                        }
                        else
                        {
                            e.DurationBarColor = "orange";
                            e.ToolTip += " Errors";
                        }
                        break;
                    case 1:  // confirmed
                        if (e.Start < DateTime.Today || (e.Start == DateTime.Today && DateTime.Now.TimeOfDay.Hours > 18))  // must arrive before 6 pm
                        {
                            e.DurationBarColor = "#f41616";  // red
                            e.ToolTip += "Late arrival";
                        }
                        else
                        {
                            e.DurationBarColor = "green";
                            e.ToolTip += "Confirmed";
                        }
                        break;
                    case 2: // arrived
                        if (e.End < DateTime.Today || (e.End == DateTime.Today && DateTime.Now.TimeOfDay.Hours > 13))  // must checkout before 12 am
                        {
                            e.DurationBarColor = "#f41616"; // red
                            e.ToolTip += "Late checkout";
                        }
                        else
                        {
                            e.DurationBarColor = "#1691f4";  // blue
                            e.ToolTip += "Arrived";
                        }
                        break;
                    case 3: // checked out
                        e.DurationBarColor = "gray";
                        e.ToolTip += "Checked out";
                        break;
                    default:
                        throw new ArgumentException("Unexpected status.");
                }

                e.Html = e.Html + String.Format("<br /><span style='color:gray'>{0}</span>", e.ToolTip);


                int paid = Convert.ToInt32(e.DataItem["ReservationPaid"]);
                string paidColor = "#aaaaaa";

                e.Areas.Add(new Area().Bottom(10).Right(4).Html("<div style='color:" + paidColor + "; font-size: 8pt;'>Paid: " + paid + "%</div>").Visible());
                e.Areas.Add(new Area().Left(4).Bottom(8).Right(4).Height(2).Html("<div style='background-color:" + paidColor + "; height: 100%; width:" + paid + "%'></div>").Visible());
            }

            protected override void OnBeforeResHeaderRender(BeforeResHeaderRenderArgs e)
            {
                string status = (string)e.DataItem["RoomStatus"];
                switch (status)
                {
                    case "Dirty":
                        e.CssClass = "status_dirty";
                        break;
                    case "Cleanup":
                        e.CssClass = "status_cleanup";
                        break;
                    case "":
                        e.CssClass = "status_none";
                        break;
                }
            }


            protected override void OnCommand(CommandArgs e)
            {
                // *********************************
                // JN 2017
                // *********************************
                string hotelId = LoadHotelId();
                // *********************************
                switch (e.Command)
                {
                    case "refresh":
                        LoadReservations(hotelId);
                        UpdateWithMessage("Refreshed");
                        break;
                    case "filter":
                        LoadRoomsAndReservations(hotelId);
                        UpdateWithMessage("Updated", CallBackUpdateType.Full);
                        break;
                }
            }


        }
    }
}
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
    using System.Web;
    
    using System.Configuration;

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
                    string aux = (string)ClientState["filter"]["hotel_id"];
                    if (!string.IsNullOrEmpty(aux))
                        HotelId = aux;
                }
                return HotelId;
            }
            protected override void OnInit(InitArgs e)
            {
                string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                var user = (UserDefinition)Authorization.UserDefinition;
                //var x = ClasesGeshotel.geshotelk.GesHotelClase.CrearClase(user.UserId, conexion);
                //DateTime HotelDate = x.FechaHotel(hotel_id);
                //var ErrorCode = x.CambiarEstadoReserva(24, 3,true);
              //  ClasesGeshotel.geshotelk.GesHotelClase.CrearClase(1, conexion).regenerarLineasFacturasReserva(24);
                // *********************************
                // JN 2017
                // *********************************
                string hotelId = LoadHotelId();
                // *********************************
                DateTime fini = DateTime.Today.AddDays(-30);
                DateTime ffin = DateTime.Today.AddDays(90);

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
                UpdateWithMessage("Bienvenidos a Geshotel Scheduler!", CallBackUpdateType.Full);
            }

            private void LoadRoomsAndReservations(string hotelId)
            {
                if (String.IsNullOrEmpty(hotelId))
                    hotelId = LoadHotelId();
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

                DataTagFields = "ReservationStatus";

            }

            private void LoadRooms(string hotelId)
            {
                Resources.Clear();

                string roomFilter = "0";
                if (ClientState["filter"] != null)
                {
                    roomFilter = (string)ClientState["filter"]["room"];
                }

                if (String.IsNullOrEmpty(hotelId))
                    hotelId = LoadHotelId();

                    DataTable dt = Db.GetRoomsFiltered(roomFilter,hotelId);

                foreach (DataRow r in dt.Rows)
                {
                    string tipo = (string)r["RoomType"];
                    string name = (string)r["RoomName"];
                    string id = Convert.ToString(r["RoomId"]);
                    string status = (string)r["RoomStatus"];
                    string aux = Convert.ToString(r["RoomSize"]);
                    int test;
                    if (!int.TryParse(aux, out test)) // Por si acaso roomSize viene vacío
                        aux = "0";
                    int beds = Convert.ToInt32(aux);
                    string bedsFormatted = (beds == 1) ? "1 pax" : String.Format("{0} paxs", beds);
                    if (status=="")
                    {
                        bedsFormatted = "Reservas";

                        name = "";
                        status = "Sin Asignar";
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
 
                if (e.OldResource == e.NewResource & (e.OldEnd != e.NewEnd | e.OldStart != e.NewStart))   // No permito cambio de fechas. Debe hacerse por editor
                {
                    message = "No se pueden cambiar las fechas directamente. Por favor, edite la reserva.";
                }
                else
                {
                    // Primero intentamos borrar el anterior habitaciones_bloqueo
                    if (!e.OldResource.EndsWith("000")) // Si tenía habitacion asignada entonces la borro 
                        Db.DeleteHabitacionesBloqueo(e.Id, e.OldStart, e.OldEnd, e.OldResource);
                    if (!e.NewResource.EndsWith("000")) // Si asigno una habitacion válida, entonces OJO Que pongo OldStart y OldEnd porque no permito mover fechas
                        Db.MoveReservation(e.Id, e.OldStart, e.OldEnd, e.NewResource);
                    Boolean match = Db.TipoHabitacionMatch(e.Id, e.NewResource);
                    if (!match)
                        message = "Reserva Asignada a una habitacion de tipo distinto a la Reserva.";
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
                //Db.MoveReservation(e.Id, e.NewStart, e.NewEnd, e.Resource);
                
                LoadReservations(hotelId);
                string message = "No se permite modificar las fechas directamente. Por favor, edite la reserva.";
                UpdateWithMessage(message);
            }

            protected override void OnBeforeEventRender(BeforeEventRenderArgs e)
            {
                e.Html = String.Format("{0} ({1:d} - {2:d})", e.Text, e.Start, e.End);
                int status = Convert.ToInt32(e.Tag["ReservationStatus"]);
                string ttoo = (String)e.DataItem["ttoo"];
                e.ToolTip = String.Format("Id={0}-{1}-{2}pax-{3}-", e.Id, e.DataItem["ttoo"], e.DataItem["pax"], e.DataItem["desc_corta"]);
                Boolean match = Db.TipoHabitacionMatch(e.Id, e.Resource);
                if (!match)
                    e.ToolTip += "Tipo de Habitación no corresponde-";
                switch (status)
                {
                    case 0: // Pendiente de Finalizar. Reserva con errores
                        e.DurationBarColor = "red";
                        e.ToolTip += "Reserva con Errores";
                        break;
                    case 1:  // confirmed
                        if (e.Start.Date == DateTime.Today.Date)    // En espera de entrada
                        {
                            e.DurationBarColor = "Orange";
                            e.ToolTip += "Entrada";
                        }
                        else
                        {
                            e.DurationBarColor = "lightskyblue"; ; // Azul celeste
                            e.ToolTip += "Pendiente";
                        }
                        break;
                    case 2:
                        e.DurationBarColor = "black";
                        e.ToolTip += "Cancelada";
                        break;
                    case 3: // Check-in
                        if (e.End <= DateTime.Today ) { // Tenía que haber salido. Caso totalmente anómalo
                            e.DurationBarColor = "blueviolet";
                            e.ToolTip += "Late checkout";
                        }
                        else
                        {
                            e.DurationBarColor = "limegreen";  // blue
                            e.ToolTip += "Check-In";
                        }
                        break;
                    case 4: // Check-Out
                        if (e.End < DateTime.Today || (e.End == DateTime.Today && DateTime.Now.TimeOfDay.Hours > 13))  // must checkout before 12 am
                        {
                            e.DurationBarColor = "blueviolet"; 
                            e.ToolTip += "Late Checkout";
                        }
                        else
                        {
                            e.DurationBarColor = "blue";  // azul oscuro
                            e.ToolTip += "Salida";
                        }
                        break;
                    case 5: // Finalizada gris
                        e.DurationBarColor = "gray";
                        e.ToolTip += "Checked Out";
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
                if (e.DataItem["RoomStatus"] != System.DBNull.Value)
                {
                    string status = Convert.ToString(e.DataItem["RoomStatus"]);
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
                    case "navigate":
                        StartDate = (DateTime)e.Data["start"];
                        Update(CallBackUpdateType.Full);
                        break;
                    case "refresh":
                        LoadReservations(hotelId);
                        UpdateWithMessage("Refrescado");
                        break;
                    case "filter":
                        LoadRoomsAndReservations(hotelId);
                        UpdateWithMessage("Refrescado", CallBackUpdateType.Full);
                        break;
                }
            }


        }
    }
}
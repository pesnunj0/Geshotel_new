
namespace Geshotel.Common.Pages
{
    using Northwind;
    using Northwind.Entities;
    using Serenity;
    using Serenity.Data;
    using System;
    using System.Web.Mvc;
    using Recepcion.Entities;
    using Contratos.Entities;
    using System.Collections.Generic;
    using System.Configuration;
    using Portal.Entities;

    [RoutePrefix("Dashboard"), Route("{action=index}")]
    public class DashboardController : Controller
    {
        [Authorize, HttpGet, Route("~/")]
        public ActionResult Index()
        {
            var user = (UserDefinition)Authorization.UserDefinition;
            Int16? hotelId = user.HotelId;
            var cachedModel = TwoLevelCache.GetLocalStoreOnly("DashboardPageModel", TimeSpan.FromMinutes(1),
                OrderRow.Fields.GenerationKey, () =>
                {
                    var model = new DashboardPageModel();
                    var rRow = ReservasRow.Fields;
                    var hRow = HabitacionesRow.Fields;
                    var hbRow = HabitacionesBloqueosRow.Fields;
                    var o = HotelesRow.Fields;
                    string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                    var x = ClasesGeshotel.geshotelk.GesHotelClase.CrearClase(user.UserId,conexion);

                    model.FechaHotel = o.FechaHotel.ToString();
                    DateTime FechaHotel = DateTime.Now;
                    //DateTime FechaHotel = x.FechaHotel((int)user.HotelId);
                    
                    using (var connection = SqlConnections.NewFor<HotelesRow>())
                    {
                        string sqlQuery = "SELECT Max(cierres.fecha_cierre) FROM cierres WHERE cierres.hotel_id =" + hotelId.ToString();
                        var result = connection.Query<DateTime>(sqlQuery);
                        
                        foreach (DateTime id in result)
                        {
                            FechaHotel = Convert.ToDateTime(id);
                            FechaHotel = FechaHotel.AddDays(1);
                        }
                        
                        var rowHotel = connection.TrySingle<HotelesRow>(o.HotelId == (int)hotelId);
                        model.HotelName = rowHotel.Hotel;
 
                        model.FechaHotel = FechaHotel.ToString("dd/MM/yyyy");

                        model.Llegadas = connection.Count<ReservasRow>(rRow.FechaLlegada == FechaHotel & rRow.HotelId == (int)hotelId & (rRow.EstadoReservaId == 3 | rRow.EstadoReservaId == 1));
                        model.Salidas = connection.Count<ReservasRow>(rRow.FechaSalida == FechaHotel & rRow.HotelId == (int)hotelId & (rRow.EstadoReservaId == 3 | rRow.EstadoReservaId == 4 | rRow.EstadoReservaId == 5));
                        var totalhabitaciones = connection.Count<HabitacionesRow>(hRow.HotelId == (int)hotelId);
                        var habitacionesOcupadas = connection.Count<ReservasRow>(rRow.HotelId == (int)hotelId & (rRow.EstadoReservaId == 3 | rRow.EstadoReservaId == 4));
                        model.PorcentajeOcupacion = (int)Math.Round(totalhabitaciones == 0 ? 100 :
                            ((double)habitacionesOcupadas / (double)totalhabitaciones * 100));

                        List<ReservasRow> reservas = connection.List<ReservasRow>(rRow.HotelId == (int)hotelId & (rRow.EstadoReservaId==3 | rRow.EstadoReservaId == 4));
                        model.PaxAlojados = 0;
                        foreach (var c in reservas)
                        {
                            model.PaxAlojados += (int)c.Adultos + (int)c.Child50 + (int)c.ChildFree;
                        }
                        
                        
                    }
                    return model;
                });
            return View(MVC.Views.Common.Dashboard.DashboardIndex, cachedModel);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentMigrator.Builders;
using Serenity;
using Serenity.Web;
using Serenity.Data;
using Geshotel;
using Geshotel.Administration;

namespace Data
{
    /// <summary>
    /// Summary description for Db
    /// </summary>
    public static class Db
    {

        //todo
        //funcion que devuelva los hoteles para un usuario
        //se necesita el usuario_id del serenty
        //
        public static DataTable SelectHoteles()
        {
            // ******************************************************************
            // Javier Nuñez 2017
            // Carga del usuario, empresaId y hotelId
            // hotelId se usará para llamar LoadRooms y LoadReservations
            // El ideal sería hacer un Listbox que seleccionara los hoteles a los
            // que tiene permiso. Ver TenantBhavior
            // ******************************************************************
            var user = (UserDefinition)Authorization.UserDefinition;
            Int32 userId = user.UserId;
            Int16? hotelId = user.HotelId;
            Int16? empresa_id = user.EmpresaId;
            string sql = "SELECT * from hoteles WHERE hoteles.empresa_id = @empresa_id";
            if (!Authorization.HasPermission(PermissionKeys.Empresa))
            {
                sql += " AND hotel_id = @hotelId";
            };
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter(sql, conexion);
            da.SelectCommand.Parameters.AddWithValue("empresa_id", empresa_id);
            da.SelectCommand.Parameters.AddWithValue("hotelId", hotelId);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            // ******************************************************************
        }
        public static DataTable GetRooms()
        {
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            String sql = "SELECT * FROM [Room] order by [RoomName]";
            SqlDataAdapter da = new SqlDataAdapter(sql, conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static IEnumerable<SelectListItem> GetRoomSelectList()
        {
            return
                GetRooms().AsEnumerable().Select(u => new SelectListItem
                {
                    Value = Convert.ToString(u.Field<int>("RoomId")),
                    Text = u.Field<string>("RoomName")
                });
        }

        public static DataRow GetReservation(string id)
        {
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string sql = "SELECT * FROM [Reservation] WHERE [ReservationId] = @id";
            SqlDataAdapter da = new SqlDataAdapter(sql, conexion);
            da.SelectCommand.Parameters.AddWithValue("id", id);

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            return null;
        }

        public static DataTable GetReservations(string hotelId)
        {
            DateTime fini = DateTime.Today.AddDays(-30);
            DateTime ffin = DateTime.Today.AddDays(45);
            string sql = "SELECT reservas.reserva_id," +
            "CONCAT(FORMAT(COALESCE(habitaciones_bloqueos.fecha_desde,reservas.fecha_prevista_llegada),'yyyy-MM-dd'),' 12:00:00.000') As llegada, " +
            "COALESCE(FORMAT(habitaciones_bloqueos.fecha_hasta, 'yyyy-MM-dd'),FORMAT(reservas.fecha_prevista_salida, 'yyyy-MM-dd')) As Salida," +
            "reservas.Nombre_reserva," +
            "COALESCE (cliente_fac.desc_corta,clientes.desc_corta) AS ttoo," +
            "reservas.adultos + reservas.child_50 + reservas.child_free AS pax," +
            "COALESCE(habitaciones_bloqueos.habitacion_id, CONCAT(tipos_habitacion_hotel.tipo_habitacion_id, '000')) AS RoomId," +
            "tipos_habitacion.desc_corta," +
            "reservas.hotel_id," +
            "tipos_habitacion_hotel.tipo_habitacion_id As tipo_habitacion_id," + 
            "reservas.estado_reserva_id AS ReservationStatus," +
            "0 As ReservationPaid " +
            "FROM reservas " +
            "INNER JOIN clientes ON reservas.cliente_id = clientes.cliente_id " +
            "LEFT JOIN habitaciones_bloqueos ON reservas.reserva_id = habitaciones_bloqueos.reserva_id " +
            "LEFT JOIN tipos_habitacion_hotel ON tipos_habitacion_hotel.servicio_id = reservas.tipo_habitacion_id " +
            "INNER JOIN tipos_habitacion ON tipos_habitacion_hotel.tipo_habitacion_id = tipos_habitacion.tipo_habitacion_id " +
            "LEFT JOIN clientes AS cliente_fac ON reservas.cliente_id_factura = cliente_fac.cliente_id " +
            "WHERE reservas.hotel_id = @hotelId AND reservas.fecha_prevista_salida > @fini AND reservas.fecha_prevista_llegada < @ffin";

            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter(sql,conexion);
            da.SelectCommand.Parameters.AddWithValue("hotelId", hotelId);
            da.SelectCommand.Parameters.AddWithValue("fini", fini);
            da.SelectCommand.Parameters.AddWithValue("ffin", ffin);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }




        public static void MoveReservation(string id, DateTime start, DateTime end, string resource)
        {
            var user = (UserDefinition)Authorization.UserDefinition;
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string sql = "INSERT INTO habitaciones_bloqueos (reserva_id,fecha_desde,fecha_hasta,habitacion_id,user_id,tipo_bloqueo_id,fecha_modificacion) " +
            "VALUES(@id,'@start','@end',@resource,@user,1,@now)";
            sql = sql.Replace("@start", start.ToString("yyyy-MM-dd"));
            sql = sql.Replace("@end", end.ToString("yyyy-MM-dd"));
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("resource", resource);
                cmd.Parameters.AddWithValue("user", user.UserId);
                cmd.Parameters.AddWithValue("now", DateTime.Now);
                var result = cmd.ExecuteNonQuery();
            }
        }

        internal static void DeleteHabitacionesBloqueo(string id, DateTime oldStart, DateTime oldEnd, string oldResource)
        {
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string sql = "DELETE FROM habitaciones_bloqueos WHERE reserva_id = @id AND fecha_desde = '@start' AND fecha_hasta = '@end' AND habitacion_id =@resource";
            sql = sql.Replace("@start", oldStart.ToString("yyyy-MM-dd"));
            sql = sql.Replace("@end", oldEnd.ToString("yyyy-MM-dd"));
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("resource", oldResource);              
                var result = cmd.ExecuteNonQuery();
            }
        }

        internal static string DimeHotel(string id)
        {
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string sql = "SELECT hotel_id FROM reservas WHERE reserva_id = @id";
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("id", id);


                string hotelId = Convert.ToString(cmd.ExecuteScalar());
                return hotelId;
            }
        }

        public static void CreateReservation(DateTime start, DateTime end, string resource, string name)
        {
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Reservation] ([ReservationStart], [ReservationEnd], [RoomId], [ReservationName], [ReservationStatus]) VALUES (@start, @end, @resource, @name, 0)", con);
                cmd.Parameters.AddWithValue("start", start);
                cmd.Parameters.AddWithValue("end", end);
                cmd.Parameters.AddWithValue("resource", resource);
                cmd.Parameters.AddWithValue("name", name);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateReservation(string id, string name, DateTime start, DateTime end, string resource, int status, int paid)
        {
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [Reservation] SET [ReservationStart] = @start, [ReservationEnd] = @end, [RoomId] = @resource, [ReservationName] = @name, [ReservationStatus] = @status, [ReservationPaid] = @paid WHERE [ReservationId] = @id", con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("start", start);
                cmd.Parameters.AddWithValue("end", end);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("resource", resource);
                cmd.Parameters.AddWithValue("status", status);
                cmd.Parameters.AddWithValue("paid", paid);
                cmd.ExecuteNonQuery();
            }

        }

        public static DataTable GetRoomsFiltered(string roomFilter, string hotelId)
        {
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string provider = ConfigurationManager.ConnectionStrings["Default"].ProviderName;
            string sql = "";
            if (roomFilter=="4")
                sql = "(SELECT " +
                "habitaciones.habitacion_id AS RoomId," +
                "tipos_habitacion.desc_corta AS RoomType, " +
                "habitaciones.numero_habitacion AS RoomName, " +
                "COALESCE(habitaciones_situacion.situacion, 'Libre') AS RoomStatus, " +
                "tipos_habitacion.numero_personas AS RoomSize, " +
                "habitaciones.tipo_habitacion_id AS RoomTypeID " +         
                "FROM habitaciones " +
                "LEFT JOIN habitaciones_situacion ON habitaciones.situacion_id = habitaciones_situacion.situacion_id " +
                "INNER JOIN tipos_habitacion ON habitaciones.tipo_habitacion_id = tipos_habitacion.tipo_habitacion_id " +
                "WHERE habitaciones.hotel_id =@hotel AND tipos_habitacion.numero_personas >= @beds) " +
                "UNION (SELECT CONCAT(habitaciones.tipo_habitacion_id,'000') As RoomId," +
                "tipos_habitacion.desc_corta AS RoomType, " +
                "'' As RoomName, '' As RoomStatus, " +
                "'' As RoomSize,habitaciones.tipo_habitacion_id AS RoomTypeID " +
                "FROM habitaciones " +
                "INNER JOIN tipos_habitacion ON habitaciones.tipo_habitacion_id = tipos_habitacion.tipo_habitacion_id " +
                "WHERE habitaciones.hotel_id = @hotel AND tipos_habitacion.desvios=0 AND tipos_habitacion.no_show=0 " +
                "AND tipos_habitacion.numero_personas >= @beds " +
                "GROUP BY habitaciones.tipo_habitacion_id, tipos_habitacion.desc_corta) " +
                "ORDER BY RoomType, RoomName" ;
            else
                sql = "(SELECT " +
                "habitaciones.habitacion_id AS RoomId," +
                "tipos_habitacion.desc_corta AS RoomType, " +
                "habitaciones.numero_habitacion AS RoomName, " +
                "COALESCE(habitaciones_situacion.situacion, 'Libre') AS RoomStatus, " +
                "tipos_habitacion.numero_personas AS RoomSize, " +
                "habitaciones.tipo_habitacion_id AS RoomTypeID " +
                "FROM habitaciones " +
                "LEFT JOIN habitaciones_situacion ON habitaciones.situacion_id = habitaciones_situacion.situacion_id " +
                "INNER JOIN tipos_habitacion ON habitaciones.tipo_habitacion_id = tipos_habitacion.tipo_habitacion_id " +
                "WHERE habitaciones.hotel_id =@hotel AND (tipos_habitacion.numero_personas = @beds or @beds = '0')) " +
                "UNION (SELECT CONCAT(habitaciones.tipo_habitacion_id,'000') As RoomId," +
                "tipos_habitacion.desc_corta AS RoomType, " +
                "'' As RoomName, '' As RoomStatus, " +
                "'' As RoomSize,habitaciones.tipo_habitacion_id AS RoomTypeID " +
                "FROM habitaciones " +
                "INNER JOIN tipos_habitacion ON habitaciones.tipo_habitacion_id = tipos_habitacion.tipo_habitacion_id " +
                "WHERE habitaciones.hotel_id = @hotel AND tipos_habitacion.desvios=0 AND tipos_habitacion.no_show=0 " +
                "AND (tipos_habitacion.numero_personas = @beds or @beds = '0')" +
                "GROUP BY habitaciones.tipo_habitacion_id, tipos_habitacion.desc_corta) " +
                "ORDER BY RoomType, RoomName";

            if (provider == "Mysql.Data.MySqlClient")  // En Mysql sustituyo ISNULL por IFNULL. Deprecado porque uso COALESCE en ambos casos            
                sql.Replace("ISNULL","IFNULL");

            int test;
            if (!int.TryParse(roomFilter, out test)) // Por si acaso roomFilter viene vacío
                roomFilter = "0";
            
            SqlDataAdapter da = new SqlDataAdapter(sql, conexion);
            da.SelectCommand.Parameters.AddWithValue("beds", roomFilter);
            da.SelectCommand.Parameters.AddWithValue("hotel", hotelId);
            
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static bool IsFree(string id, DateTime start, DateTime end, string resource)
        {
            
            // event with the specified id will be ignored
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string provider = ConfigurationManager.ConnectionStrings["Default"].ProviderName;
            string sql = "SELECT count(ReservationId) as count FROM [Reservation] " + 
            "WHERE NOT (([ReservationEnd] <= @start) OR ([ReservationStart] >= @end)) AND RoomId = @resource AND ReservationId <> @id";
            SqlDataAdapter da = new SqlDataAdapter(sql, conexion);
            da.SelectCommand.Parameters.AddWithValue("id", id);
            da.SelectCommand.Parameters.AddWithValue("start", start);
            da.SelectCommand.Parameters.AddWithValue("end", end);
            da.SelectCommand.Parameters.AddWithValue("resource", resource);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int count = Convert.ToInt32(dt.Rows[0]["count"]);
            return count == 0;
        }
        public static bool TipoHabitacionMatch(string id, string resource)
        {
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string provider = ConfigurationManager.ConnectionStrings["Default"].ProviderName;
            string tipoHabitacionId = "";
            string tipoHabitacionReserva = "";
            string sql = "";
            if(resource.EndsWith("000"))            
                 tipoHabitacionId= resource.Substring(0, resource.Length - 3);
            else
            {
                sql = "SELECT tipo_habitacion_id FROM habitaciones WHERE habitacion_id =@resource";
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("resource", resource);
                    tipoHabitacionId = Convert.ToString(cmd.ExecuteScalar());
                }
            }
            sql = "SELECT " +
            "tipos_habitacion_hotel.tipo_habitacion_id " +
            "FROM reservas " +
            "LEFT JOIN tipos_habitacion_hotel ON tipos_habitacion_hotel.servicio_id = reservas.tipo_habitacion_id " +
            "WHERE reservas.reserva_id=@id";
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("id", id);
                tipoHabitacionReserva = Convert.ToString(cmd.ExecuteScalar());                
            }
            
            return tipoHabitacionId==tipoHabitacionReserva;
        }
    }

}

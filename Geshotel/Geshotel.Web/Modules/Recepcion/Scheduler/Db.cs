using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentMigrator.Builders;

namespace Data
{
    /// <summary>
    /// Summary description for Db
    /// </summary>
    public static class Db
    {
        

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

        public static DataTable GetReservations()
        {
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter("SELECT *,1 as ReservationStatus,1 as ReservationPaid, 11 As RoomId FROM [reservas]",conexion);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }




        public static void MoveReservation(string id, DateTime start, DateTime end, string resource)
        {
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [Reservation] SET [ReservationStart] = @start, [ReservationEnd] = @end, [RoomId] = @resource WHERE [ReservationId] = @id", con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("start", start);
                cmd.Parameters.AddWithValue("end", end);
                cmd.Parameters.AddWithValue("resource", resource);
                cmd.ExecuteNonQuery();
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

        public static DataTable GetRoomsFiltered(string roomFilter)
        {
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string provider = ConfigurationManager.ConnectionStrings["Default"].ProviderName;
            string sql = "SELECT " +
            "habitaciones.habitacion_id AS RoomId," +
            "habitaciones.numero_habitacion AS RoomName, " +
            "COALESCE(habitaciones_situacion.situacion, 'Libre') AS RoomStatus, " +
            "tipos_habitacion.numero_personas AS RoomSize, " +
            "tipos_habitacion.desc_corta AS RoomType " +
            "FROM habitaciones " +
            "LEFT JOIN habitaciones_situacion ON habitaciones.situacion_id = habitaciones_situacion.situacion_id " +
            "INNER JOIN tipos_habitacion ON habitaciones.tipo_habitacion_id = tipos_habitacion.tipo_habitacion_id ";

            if (provider == "Mysql.Data.MySqlClient")  // En Mysql sustituyo ISNULL por IFNULL. Deprecado porque uso COALESCE en ambos casos            
                sql.Replace("ISNULL","IFNULL");
            

            SqlDataAdapter da = new SqlDataAdapter(sql, conexion);
           // da.SelectCommand.Parameters.AddWithValue("beds", roomFilter);
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
    }

}

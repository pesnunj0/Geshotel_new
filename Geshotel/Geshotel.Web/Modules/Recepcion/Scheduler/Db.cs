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
using MySql.Data;
using MySql.Data.MySqlClient;

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
            string provider = ConfigurationManager.ConnectionStrings["Default"].ProviderName;

            //SqlDataAdapter da = new SqlDataAdapter(sql, conexion);
            MySqlDataAdapter da = new MySqlDataAdapter(sql,conexion);

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
            //SqlDataAdapter da = new SqlDataAdapter(sql, conexion);
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conexion);
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
            //SqlDataAdapter da = new SqlDataAdapter(sql, conexion);
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conexion);
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
            string sql = "";
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string provider = ConfigurationManager.ConnectionStrings["Default"].ProviderName;
            DataTable dt = new DataTable();
            if (provider == "Mysql.Data.MySqlClient")
            {
                sql = "SELECT reservas.reserva_id," +
                "CONCAT(DATE_FORMAT(COALESCE(habitaciones_bloqueos.fecha_desde,reservas.fecha_prevista_llegada),'%Y-%m-%d'),' 14:00:00.000') As llegada, " +
                "DATE_FORMAT(COALESCE(habitaciones_bloqueos.fecha_hasta,reservas.fecha_prevista_salida),'%Y-%m-%d') As salida," +
                "reservas.Nombre_reserva," +
                "COALESCE (cliente_fac.desc_corta,clientes.desc_corta) AS ttoo," +
                "reservas.adultos + reservas.child_50 + reservas.child_free AS pax," +
                "COALESCE(habitaciones_bloqueos.habitacion_id, CONCAT(tipos_habitacion_hotel.tipo_habitacion_id, '000')) AS RoomId," +
                "tipos_habitacion.desc_corta," +
                "reservas.hotel_id," +
                "tipos_habitacion_hotel.tipo_habitacion_id As tipo_habitacion_id," +
                "reservas.estado_reserva_id AS ReservationStatus," +
                "fecha_prevista_llegada, fecha_prevista_salida," +
                "0 As ReservationPaid " +
                "FROM reservas " +
                "INNER JOIN clientes ON reservas.cliente_id = clientes.cliente_id " +
                "LEFT JOIN habitaciones_bloqueos ON reservas.reserva_id = habitaciones_bloqueos.reserva_id " +
                "LEFT JOIN tipos_habitacion_hotel ON tipos_habitacion_hotel.servicio_id = reservas.tipo_habitacion_id " +
                "INNER JOIN tipos_habitacion ON tipos_habitacion_hotel.tipo_habitacion_id = tipos_habitacion.tipo_habitacion_id " +
                "LEFT JOIN clientes AS cliente_fac ON reservas.cliente_id_factura = cliente_fac.cliente_id " +
                "WHERE reservas.hotel_id = @hotelId AND reservas.fecha_prevista_salida > '@fini' AND reservas.fecha_prevista_llegada < '@ffin' " +
                "ORDER BY reserva_id,COALESCE(habitaciones_bloqueos.fecha_desde,reservas.fecha_prevista_llegada)";
                sql = sql.Replace("@fini", fini.ToString("yyyy-MM-dd"));
                sql = sql.Replace("@ffin", ffin.ToString("yyyy-MM-dd"));
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conexion);
                da.SelectCommand.Parameters.AddWithValue("hotelId", hotelId);                
                da.Fill(dt);
                
            }
            else
            {
                sql = "SELECT reservas.reserva_id," +
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
                "fecha_prevista_llegada, fecha_prevista_salida," +
                "0 As ReservationPaid " +
                "FROM reservas " +
                "INNER JOIN clientes ON reservas.cliente_id = clientes.cliente_id " +
                "LEFT JOIN habitaciones_bloqueos ON reservas.reserva_id = habitaciones_bloqueos.reserva_id " +
                "LEFT JOIN tipos_habitacion_hotel ON tipos_habitacion_hotel.servicio_id = reservas.tipo_habitacion_id " +
                "INNER JOIN tipos_habitacion ON tipos_habitacion_hotel.tipo_habitacion_id = tipos_habitacion.tipo_habitacion_id " +
                "LEFT JOIN clientes AS cliente_fac ON reservas.cliente_id_factura = cliente_fac.cliente_id " +
                "WHERE reservas.hotel_id = @hotelId AND reservas.fecha_prevista_salida > @fini AND reservas.fecha_prevista_llegada < @ffin " +
                "ORDER BY reserva_id,COALESCE(habitaciones_bloqueos.fecha_desde, reservas.fecha_prevista_llegada)";


                SqlDataAdapter da = new SqlDataAdapter(sql,conexion);
                //MySqlDataAdapter da = new MySqlDataAdapter(sql, conexion);
                da.SelectCommand.Parameters.AddWithValue("hotelId", hotelId);
                da.SelectCommand.Parameters.AddWithValue("fini", fini);
                da.SelectCommand.Parameters.AddWithValue("ffin", ffin);
                
                da.Fill(dt);
                
            }
            // ****************************************************************************************************************************************************************
            // Nos queda recorrer el datatable y añadir las filas que correspondieran en caso de que haya cambios de habitación y no estuviera contemplada anteriormente
            // Complicadilla la jodida cuestion, pero hay que hacerla por cojones
            // ****************************************************************************************************************************************************************
            DataTable copydt = new DataTable();
            copydt = dt.Copy();
            Int32 reserva_id = 0;
            foreach (DataRow fila in copydt.Rows)
            {
                DateTime llegada = Convert.ToDateTime(fila["llegada"]).Date;
                DateTime salida = Convert.ToDateTime(fila["salida"]).Date;
                if (reserva_id!= Convert.ToInt32(fila["reserva_id"]))
                {
                    reserva_id = Convert.ToInt32(fila["reserva_id"]);
                    DateTime llegadaReserva = Convert.ToDateTime(fila["fecha_prevista_llegada"]).Date;
                    DateTime SalidaReserva = Convert.ToDateTime(fila["fecha_prevista_salida"]).Date;
                    // Como dt está ordenado por llegadas, si la llegada que tenemos es mayor que la llegada de la reserva, hay que crear una fila 
                    // con llegada = Llegadareserva y Salida=llegada y ponerla en la habitación tipo+"000"
                    if (llegada != llegadaReserva)
                    {
                        DataRow dr = dt.NewRow();

                        for (int i = 0; i < fila.ItemArray.Count(); i++)  // Igualamos todos los campos de la fila
                        {
                            dr[i] = fila[i];
                        }
                        dr["llegada"] = fila["fecha_prevista_llegada"];
                        dr["salida"] = Convert.ToDateTime(fila["llegada"]).Date; // La salida no lleva hora
                        dr["RoomId"] = fila["tipo_habitacion_id"] + "000"; // Habitacion no asignada
                        dt.Rows.Add(dr);
                    }
                    if (salida != SalidaReserva)
                    {
                        DateTime NuevaLlegada = salida;  // Supongo que sea esta, pero en caso de que ya existiera, vendría a continuacion
                        DateTime NuevaSalida = SalidaReserva; // Esto sería lo esperado
                                                              // Aquí está claro quela reserva se partirá en cachos
                                                              // Es posible que haya otra y llegaremos a ella y por eso, buscamos a ver si hay alguna otra
                        DataView dv = new DataView(dt);
                        dv.Sort = "reserva_id,llegada";
                        dv.RowFilter = "reserva_id=" + reserva_id;

                        foreach (DataRowView drv in dv)
                        {
                            if (NuevaLlegada < Convert.ToDateTime(drv["llegada"]).Date)   // Caso muy cabron
                            {
                                // Añadir fila desde Nueva_llegada hasta drv["llegada"]

                                DataRow dr = dt.NewRow();

                                for (int i = 0; i < fila.ItemArray.Count(); i++)
                                {
                                    dr[i] = fila[i];
                                }
                                dr["llegada"] = NuevaLlegada.AddHours(14); ;
                                dr["salida"] = Convert.ToDateTime(drv["llegada"]).Date; // La salida no lleva hora
                                dr["RoomId"] = fila["tipo_habitacion_id"] + "000"; // Habitacion no asignada
                                dt.Rows.Add(dr);
                            }
                            NuevaLlegada = Convert.ToDateTime(drv["salida"]).Date;
                        }
                        // Una vez que salimos del bucle....
                        // Si NuevaLLegada sigue siendo menor que SalidaReserva  
                        // Añadimos otra fila con Llegada=NuevaLLegada y Salida=Salidareserva
                        if (NuevaLlegada < SalidaReserva)
                        {
                            DataRow dr = dt.NewRow();
                            for (int i = 0; i < fila.ItemArray.Count(); i++)
                            {
                                dr[i] = fila[i];
                            }


                            dr["reserva_id"] = fila["reserva_id"];
                            dr["llegada"] = NuevaLlegada.AddHours(14);

                            dr["salida"] = SalidaReserva; // La salida no lleva hora
                            dr["RoomId"] = fila["tipo_habitacion_id"] + "000"; // Habitacion no asignada
                            dt.Rows.Add(dr);
                        }
                    }

                }

            }
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
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
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
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("resource", oldResource);              
                var result = cmd.ExecuteNonQuery();
            }
        }
        internal static IDataAdapter DameDataAdapter(string sql)
        {
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string provider = ConfigurationManager.ConnectionStrings["Default"].ProviderName;
            if (provider == "Mysql.Data.MySqlClient")
            {
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conexion);
                return da;
            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conexion);
                return da;
            }
                
        }


        internal static string DimeHotel(string id)
        {
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string provider = ConfigurationManager.ConnectionStrings["Default"].ProviderName;
            string sql = "SELECT hotel_id FROM reservas WHERE reserva_id = @id";
            if (provider == "Mysql.Data.MySqlClient")
            {
                using (MySqlConnection con = new MySqlConnection(conexion))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("id", id);


                    string hotelId = Convert.ToString(cmd.ExecuteScalar());
                    return hotelId;
                }
            }
            else
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("id", id);


                    string hotelId = Convert.ToString(cmd.ExecuteScalar());
                    return hotelId;
                }

            }


        }

        public static void CreateReservation(DateTime start, DateTime end, string resource, string name)
        {
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO [Reservation] ([ReservationStart], [ReservationEnd], [RoomId], [ReservationName], [ReservationStatus]) VALUES (@start, @end, @resource, @name, 0)", con);
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
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE [Reservation] SET [ReservationStart] = @start, [ReservationEnd] = @end, [RoomId] = @resource, [ReservationName] = @name, [ReservationStatus] = @status, [ReservationPaid] = @paid WHERE [ReservationId] = @id", con);
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
                "0 As RoomSize,habitaciones.tipo_habitacion_id AS RoomTypeID " +
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

            int test;
            if (!int.TryParse(roomFilter, out test)) // Por si acaso roomFilter viene vacío
                roomFilter = "0";

            DataTable dt = new DataTable();
            if (provider == "Mysql.Data.MySqlClient")  // En Mysql sustituyo ISNULL por IFNULL. Deprecado porque uso COALESCE en ambos casos            
            {
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conexion);
                da.SelectCommand.Parameters.AddWithValue("beds", roomFilter);
                da.SelectCommand.Parameters.AddWithValue("hotel", hotelId);
                da.Fill(dt);
            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conexion);
                da.SelectCommand.Parameters.AddWithValue("beds", roomFilter);
                da.SelectCommand.Parameters.AddWithValue("hotel", hotelId);
                da.Fill(dt);
            }
            return dt;
        }

        public static bool IsFree(string id, DateTime start, DateTime end, string resource)
        {
            
            // event with the specified id will be ignored
            string conexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string provider = ConfigurationManager.ConnectionStrings["Default"].ProviderName;
            string sql = "SELECT count(ReservationId) as count FROM [Reservation] " + 
            "WHERE NOT (([ReservationEnd] <= @start) OR ([ReservationStart] >= @end)) AND RoomId = @resource AND ReservationId <> @id";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conexion);
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
                using (MySqlConnection con = new MySqlConnection(conexion))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("resource", resource);
                    tipoHabitacionId = Convert.ToString(cmd.ExecuteScalar());
                }
            }
            sql = "SELECT " +
            "tipos_habitacion_hotel.tipo_habitacion_id " +
            "FROM reservas " +
            "LEFT JOIN tipos_habitacion_hotel ON tipos_habitacion_hotel.servicio_id = reservas.tipo_habitacion_id " +
            "WHERE reservas.reserva_id=@id";
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("id", id);
                tipoHabitacionReserva = Convert.ToString(cmd.ExecuteScalar());                
            }
            
            return tipoHabitacionId==tipoHabitacionReserva;
        }
    }

}

Imports System.Xml.Serialization
Imports System.Security
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data
Imports System.Collections.Generic
Imports System.Threading
Imports GestionUsuarios.GESTCAC
Imports MySql.Data.MySqlClient


Imports System.Text
Imports System.Security.Cryptography
'este es el codigo ke devuelve el xml de todos los hoteles
Namespace geshotelk
    Partial Public Class GesHotelClase
        Public Function ObtieneHabitacion_Id(ByVal hotel_id As Integer, ByVal habitacion As Object) As Integer
            'Dim retVal As Integer
            Dim errorCode As Integer = 0
            Dim tmp As Integer = -1
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try
                tmp = ObtieneHabitacion_Id(cmd, hotel_id, habitacion)
            Catch ex As Exception
                errorCode = 1
            End Try
            flushConection(cmd, errorCode)
            Return tmp
        End Function
        Public Function URLDecode(ByVal Source As String) As String
            Dim x As Integer = 0
            Dim CharVal As Byte = 0
            Dim sb As New System.Text.StringBuilder()

            For x = 0 To (Source.Length - 1)
                Dim c As Char = Source(x)
                'Check for space
                If (c = "+") Then
                    sb.Append(" ")
                ElseIf c <> "%" Then
                    'Not hex value so add the chars to string builder.
                    sb.Append(c)
                Else
                    'Convert hex value to char value.
                    CharVal = Int("&H" & Source(x + 1) & Source(x + 2))
                    'Add the chars to string builder.
                    sb.Append(Chr(CharVal))
                    'INC by 2
                    x += 2
                End If
            Next

            'Return the string.
            Return sb.ToString()

        End Function
        Public Function EscapeXML(ByVal s As String) As String
            If (String.IsNullOrEmpty(s)) Then
                Return s
            End If
            If Not SecurityElement.IsValidText(s) Then
                Return SecurityElement.Escape(s)
            Else
                Return s
            End If
        End Function
        Public Function UnescapeXML(ByVal s As String) As String

            If (String.IsNullOrEmpty(s)) Then
                Return s
            End If


            Dim returnString As String = s

            returnString = returnString.Replace("&apos;", "'")

            returnString = returnString.Replace("&quot;", "" & Chr(34))

            returnString = returnString.Replace("&gt;", ">")

            returnString = returnString.Replace("&lt;", "<")

            returnString = returnString.Replace("&amp;", "&")



            Return returnString

        End Function

        Function procesaAccionHDHOTELS(ByVal actstr As String, Optional edition As Boolean = False) As String
            'Return actstr
            'convertir act a xml
            Try
                My.Computer.FileSystem.WriteAllText("C://TEMP//checkactions.TXT", "ACTION-" & actstr & vbNewLine, True, New System.Text.ASCIIEncoding)
            Catch ex2 As Exception

            End Try
            Try
                Dim acciones As New DataSet
                Dim reader As System.IO.StringReader = New System.IO.StringReader(actstr)
                acciones.ReadXml(reader)
                'obtener la accion y ejecutar la funcion
                'devolver un xml
                If Not IsNothing(acciones.Tables("action")) Then
                    Dim act As DataRowCollection = acciones.Tables("action").Rows
                    Dim x As Integer
                    For x = 0 To act.Count - 1
                        Dim reserva_id As String = "0"
                        If act(x).Table.Columns.Contains("RESERVA_ID") Then
                            reserva_id = act(x).Item("RESERVA_ID")
                        End If
                        Dim browser As String = ""
                        If act(x).Table.Columns.Contains("BROWSER") Then
                            browser = act(x).Item("BROWSER")
                        End If

                        If act(x).Item("ACTION") = "updateHDreserva" Then
                            Dim ret As String = updateHDreserva(act(x).Item("BONO"), act(x).Item("FECHA_LLEGADA"), URLDecode(act(x).Item("DATA")), act(x).Item("LANGUAGE"), reserva_id, browser)
                            If ret <> "" Then
                                Return ret
                            Else
                                Return generaHDreservasXML(act(x).Item("BONO"), act(x).Item("FECHA_LLEGADA"), Nothing, Nothing, Nothing, reserva_id)
                            End If

                        End If
                        Dim ip As String = "80.59.112.27"
                        If act(x).Table.Columns.Contains("ip") Then
                            ip = act(x).Item("ip")
                        End If
                        Dim register As String = Nothing
                        If act(x).Table.Columns.Contains("REGISTER") Then
                            register = URLDecode(act(x).Item("REGISTER"))
                        End If

                        Dim tiporegister As String = Nothing
                        If act(x).Table.Columns.Contains("TIPOREGISTER") Then
                            tiporegister = act(x).Item("TIPOREGISTER")
                        End If

                        Dim language As String = Nothing
                        If act(x).Table.Columns.Contains("LANGUAGE") Then
                            language = act(x).Item("LANGUAGE")
                        End If
                        Dim repasada As Integer = -1
                        If act(x).Table.Columns.Contains("repasada") Then
                            repasada = act(x).Item("repasada")
                        End If
                        Dim habitacion As String = Nothing
                        If act(x).Table.Columns.Contains("habitacion") Then
                            habitacion = act(x).Item("habitacion")
                        End If

                        Dim razon As String = Nothing
                        If act(x).Table.Columns.Contains("razon") Then
                            razon = act(x).Item("razon")
                        End If

                        Dim hotel_id As String = Nothing
                        If act(x).Table.Columns.Contains("hotel_id") Then
                            hotel_id = act(x).Item("hotel_id")
                        End If
                        Dim bono As String = Nothing
                        If act(x).Table.Columns.Contains("BONO") Then
                            bono = act(x).Item("BONO")
                        End If
                        Dim apellido As String = Nothing
                        If act(x).Table.Columns.Contains("apellido") Then
                            apellido = act(x).Item("apellido")
                        End If
                        Dim fecha_llegada As String = Nothing

                        If act(x).Item("ACTION") = "getNotificaciones" And Not IsNothing(register) And Not IsNothing(tiporegister) Then
                            Return getNotificaciones(register, tiporegister, language)
                        End If
                        If act(x).Item("ACTION") = "generaHDreservasXML" Then
                            'si no tiene bono pero tiene apellido+hab+fecha_llegada
                            If IsNothing(bono) Then
                                Dim datos() As Object = getBono(apellido, habitacion, act(x).Item("FECHA_LLEGADA"))
                                If Not IsNothing(datos) Then
                                    bono = datos(0)
                                    reserva_id = datos(1)
                                End If
                            End If
                            'obtener bono+reserva_id

                            Return generaHDreservasXML(bono, act(x).Item("FECHA_LLEGADA"), register, tiporegister, language, reserva_id)
                        End If
                        If act(x).Item("ACTION") = "getLimpiezas" Then
                            Return getLimpiezas(act(x).Item("usuario"), act(x).Item("password"), ip, register, tiporegister, language)
                        End If
                        If act(x).Item("ACTION") = "setLimpiezas" Then
                            Return setLimpiezas(act(x).Item("usuario"), act(x).Item("password"), ip, register, tiporegister, language, repasada, habitacion)
                        End If

                        If act(x).Item("ACTION") = "getHDRooms" Then
                            Return getHDRooms(act(x).Item("BONO"), act(x).Item("FECHA_LLEGADA"), act(x).Item("HOTEL_ID"), reserva_id)
                        End If
                        If act(x).Item("ACTION") = "getGaleria" Then
                            Return getGaleria(act(x).Item("HOTEL_ID"))
                        End If
                        If act(x).Item("ACTION") = "getLanguage" Then
                            Return getLanguage(act(x).Item("DATA"))
                        End If
                        If act(x).Item("ACTION") = "getEncuesta" Then
                            Return getEncuesta(hotel_id, habitacion, razon)
                        End If
                        If act(x).Item("ACTION") = "setEncuesta" Then
                            Return setEncuesta(hotel_id, habitacion, razon, act(x).Item("DATA"))
                        End If
                        If edition Then

                            If act(x).Item("ACTION") = "setCheckin" Then 'solo se puede llamar desde geshotel
                                Return setCheckin(act(x).Item("RESERVA_ID"))
                            End If
                            If act(x).Item("ACTION") = "getDatosReservaById" Then 'solo se puede llamar desde geshotel
                                Return getDatosReservaById(act(x).Item("RESERVA_ID"))
                            End If
                            If act(x).Item("ACTION") = "setHDRooms" Then
                                Return setHDRooms(act(x).Item("BONO"), act(x).Item("FECHA_LLEGADA"), URLDecode(act(x).Item("DATA")), reserva_id)
                            End If
                            'todo update galeria
                            If act(x).Item("ACTION") = "setGaleria" Then    'solo se puede llamar desde geshotel
                                Return setGaleria(URLDecode(act(x).Item("DATA")))
                            End If

                            If act(x).Item("ACTION") = "setLanguage" Then 'solo se puede llamar desde geshotel
                                Return setLanguage(URLDecode(act(x).Item("DATA")))
                            End If

                        End If
                    Next
                End If
            Catch ex As Exception
                Try
                    My.Computer.FileSystem.WriteAllText("C://TEMP//checking.TXT", "EXCEPTION-" & ex.Message & vbNewLine & actstr & vbNewLine, True, New System.Text.ASCIIEncoding)
                Catch ex2 As Exception

                End Try



                Return ex.Message
                'recordar quitar
            End Try
        End Function
        Shared sqlHdHotelBonoFecha = "select ifnull(bono_online,bono_referencia) as bono_referencia,fecha_prevista_llegada from reservas where reserva_id=?"
        Shared sqlEmailReserva = "select reservas.*" _
        & ", (select (select clientes.razon from clientes where clientes.cliente_id=min(reservas_huespedes.cliente_id)) as cliente_id from reservas_huespedes where reservas_huespedes.reserva_id=reservas.reserva_id) as razon" _
        & ",(select (select habitaciones.lat from habitaciones_bloqueos h inner join habitaciones on habitaciones.habitacion_id=h.habitacion_id where h.habitacion_bloqueo_id=max(habitaciones_bloqueos.habitacion_bloqueo_id)) from habitaciones_bloqueos where habitaciones_bloqueos.reserva_id=reservas.reserva_id) as lat" _
        & ",(select (select habitaciones.lng from habitaciones_bloqueos h inner join habitaciones on habitaciones.habitacion_id=h.habitacion_id where h.habitacion_bloqueo_id=max(habitaciones_bloqueos.habitacion_bloqueo_id)) from habitaciones_bloqueos where habitaciones_bloqueos.reserva_id=reservas.reserva_id) as lng" _
        & ",(select (select RIGHT(CONCAT('000',habitaciones.numero_habitacion),4)from habitaciones_bloqueos h inner join habitaciones on habitaciones.habitacion_id=h.habitacion_id where h.habitacion_bloqueo_id=max(habitaciones_bloqueos.habitacion_bloqueo_id)) from habitaciones_bloqueos where habitaciones_bloqueos.reserva_id=reservas.reserva_id) as numero_habitacion" _
        & ",(select (select desvios from tipos_habitacion h inner join habitaciones on habitaciones.tipo_habitacion_id=h.tipo_habitacion_id where habitaciones.habitacion_id=max(habitaciones_bloqueos.habitacion_id)) from habitaciones_bloqueos where habitaciones_bloqueos.reserva_id=reservas.reserva_id) as desvio " _
        & ",hoteles.email_smtp,hoteles.email_reservas,hoteles.zoom_mapa,hoteles.lat as hotel_lat,hoteles.lng as hotel_lng,hoteles.ancho,hoteles.alto " _
        & " from reservas left join hoteles on reservas.hotel_id=hoteles.hotel_id where reserva_id=?"
        Shared sqlHDreservas = "SELECT" _
        & " min(reservas.reserva_id) as reserva_id,group_concat(reservas.reserva_id) as reservas_id," _
        & " reservas.clave_wifi,reservas.ssid," _
        & " MIN(reservas.hotel_id) AS hotel_id,(select checkin_on_line from hoteles where hoteles.hotel_id=reservas.hotel_id) as checkin_on_line," _
        & " min(reservas.estado_reserva_id) as estado_reserva_id,0 as puedo_checkin,reservas.idioma_id as idioma_id," _
        & " min(reservas.fecha_reserva) as fecha_reserva," _
        & " reservas.fecha_prevista_llegada,DATE_FORMAT(reservas.hora_prevista_llegada, '%H:%i') as hora_prevista_llegada," _
        & " min(reservas.fecha_prevista_salida) as fecha_prevista_salida," _
        & " (SELECT Max(cierres.fecha_cierre) FROM cierres WHERE cierres.hotel_id=reservas.hotel_id) as fecha_hotel," _
        & " ifnull(reservas.bono_online,reservas.bono_referencia) as bono_referencia,reservas.email,reservas.observaciones_cliente AS observaciones_llegada" _
        & " ,(select (select RIGHT(CONCAT('000',habitaciones.numero_habitacion),4)from habitaciones_bloqueos h inner join habitaciones on habitaciones.habitacion_id=h.habitacion_id where h.habitacion_bloqueo_id=max(habitaciones_bloqueos.habitacion_bloqueo_id)) from habitaciones_bloqueos where habitaciones_bloqueos.reserva_id=reservas.reserva_id) as numero_habitacion" _
        & ",(select abreviatura from reservas_tipo_habitacion where reservas_tipo_habitacion.reserva_id=reservas.reserva_id limit 0,1) abreviatura" _
        & ",(select minimo_dias_checkin_online from hoteles where hoteles.hotel_id=reservas.hotel_id) as minimo_dias_checkin_online" _
        & ",(select sum(`r`.`cantidad`) AS `pax` from (`reservas_servicios` `r` join `servicios` on(((`servicios`.`servicio_id` = `r`.`servicio_id`) and (`servicios`.`concepto_acelerador_reservas_id` = 99)))) where ((`r`.`reserva_id` =reservas.reserva_id) and (`r`.`unidad_calculo_id` <> 5)))  as pax" _
        & ",(select sum(`r`.`cantidad`) AS `b` from (`reservas_servicios` `r` join `servicios` on(((`servicios`.`servicio_id` = `r`.`servicio_id`) and (`servicios`.`concepto_acelerador_reservas_id` = 99)))) where ((`r`.`reserva_id` =reservas.reserva_id) and (`r`.`unidad_calculo_id` = 5)))  as b" _
        & ",(select sum(`r`.`cantidad`) AS `n1` from (`reservas_servicios` `r` join `servicios` on(((`servicios`.`servicio_id` = `r`.`servicio_id`) and (`servicios`.`concepto_acelerador_reservas_id` = 99)))) where ((`r`.`reserva_id` =reservas.reserva_id) and (`r`.`unidad_calculo_id` = 3)))  as n1" _
        & ",(select sum(`r`.`cantidad`) AS `n2` from (`reservas_servicios` `r` join `servicios` on(((`servicios`.`servicio_id` = `r`.`servicio_id`) and (`servicios`.`concepto_acelerador_reservas_id` = 99)))) where ((`r`.`reserva_id` =reservas.reserva_id) and (`r`.`unidad_calculo_id` = 4)))  as n2" _
        & " FROM reservas WHERE reservas.estado_reserva_id IN (1,3) and reservas.fecha_prevista_llegada=? and SUBSTRING_INDEX(ifnull(reservas.bono_online,reservas.bono_referencia),'//',1)=?" _
        & " and (reservas.reserva_id=? or 0=?)" _
        & " GROUP BY SUBSTRING_INDEX(ifnull(reservas.bono_online,reservas.bono_referencia),'//',1) HAVING COUNT(distinct reservas.cliente_id)=1 and COUNT(DISTINCT reservas.reserva_id)<=4"

        Shared sqlHDhuespedes = "" _
        & " SELECT reservas_huespedes.cliente_id, reservas_huespedes.tipo_huesped_id, clientes.razon,clientes.contacto, clientes.tipo_documento_id," _
        & " clientes.nif,clientes.nacion_id,clientes.fecha_documento,clientes.fecha_nacimiento,clientes.sexo_id,clientes.nacion_id,clientes.email" _
        & " FROM reservas_huespedes Inner Join clientes ON reservas_huespedes.cliente_id = clientes.cliente_id" _
        & " WHERE reservas_huespedes.reserva_id = ?"
        Shared sqlHDquitarHuesped = "DELETE FROM reservas_huespedes WHERE  reserva_id = ? And cliente_id = ?"
        Shared sqlObtieneEmpresa_id = "select empresa_id from hoteles where hotel_id=?"
        Shared sqlObtieneNaciones = "select nacion_id,nombre_real as nacion,desc_corta,pais_ista from naciones order by nombre_real"
        Shared sqlHDBloqueoMin = "SELECT * FROM bloqueos_online WHERE bloqueos_online.bloqueo_online_id" _
        & " IN" _
        & " ( SELECT Max(bloqueos_online.bloqueo_online_id)" _
        & " FROM bloqueos_online WHERE bloqueos_online.hotel_id = ? AND  ? BETWEEN bloqueos_online.desde AND  bloqueos_online.hasta" _
        & " )"
        Shared sqlHDOcupacionAsignada = "" _
        & " SELECT IFNULL(COUNT(DISTINCT habitaciones_bloqueos.habitacion_id)/Count(DISTINCT habitaciones.habitacion_id)*100,0) AS PORC_OCUPACION_ASIGNADO " _
        & " FROM habitaciones LEFT JOIN " _
        & " (SELECT habitaciones_bloqueos.* FROM habitaciones_bloqueos JOIN reservas ON habitaciones_bloqueos.reserva_id=reservas.reserva_id AND reservas.estado_reserva_id NOT IN (0,2)" _
        & " WHERE  ? BETWEEN habitaciones_bloqueos.fecha_desde AND habitaciones_bloqueos.fecha_hasta" _
        & " ) AS habitaciones_bloqueos" _
        & " ON habitaciones.habitacion_id = habitaciones_bloqueos.habitacion_id " _
        & " INNER JOIN tipos_habitacion on habitaciones.tipo_habitacion_id=tipos_habitacion.tipo_habitacion_id" _
        & " WHERE habitaciones.hotel_id =? AND tipos_habitacion.desc_corta = ?"
        Private Function CheckinOnlineObitneReserva(cmd As Odbc.OdbcCommand, bono As String, fecha As Date, Optional reserva_id As Integer = 0)
            Dim reserva As DataSet = Nothing
            Try
                cmd.Parameters.Clear()
                Dim fecha_llegadaParam As New Odbc.OdbcParameter("@fecha_llegada", fecha)
                Dim bonoParam As New Odbc.OdbcParameter("@bono", bono)
                Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
                Dim reserva_id1Param As New Odbc.OdbcParameter("@reserva_id1", reserva_id)
                cmd.Parameters.Add(fecha_llegadaParam)
                cmd.Parameters.Add(bonoParam)
                cmd.Parameters.Add(reserva_idParam)
                cmd.Parameters.Add(reserva_id1Param)
                reserva = Me.getDataSet(cmd, sqlHDreservas)
            Catch ex As Exception

            End Try
            Return reserva
        End Function
        Function generaHDreservasXML(ByVal bono As String, ByVal fecha_llegada As Date, Optional register As String = Nothing, Optional tiporegister As String = Nothing, Optional language As String = Nothing, Optional reserva_id_filtro As Integer = 0) As String
            'devolver un xml vacio o con una reserva.

            Dim errorCode As Integer = 0
            Dim resultado As String = "no" 'un valor por defecto con error
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim reserva As DataSet = CheckinOnlineObitneReserva(cmd, bono, fecha_llegada, reserva_id_filtro)

            If Not IsNothing(reserva) Then


                Try

                    reserva.DataSetName = "Reserva"
                    reserva.Tables(0).TableName = "Cabecera"
                    If reserva.Tables(0).Rows.Count > 0 Then
                        registraDispositivoHDHotels(cmd, register, tiporegister, reserva.Tables(0).Rows(0).Item("hotel_id"), reserva.Tables(0).Rows(0).Item("reserva_id"), language)
                        If reserva.Tables(0).Rows(0).Item("checkin_on_line") = 1 Then

                            If CambiarEstadoReserva(reserva.Tables(0).Rows(0).Item("reserva_id"), 3, True) Then
                                reserva.Tables(0).Rows(0).Item("puedo_checkin") = 1
                            End If
                            'compruba si puedo hacer checkin a esa reserva (algo mal introducido)
                            cmd.Parameters.Clear()
                            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva.Tables(0).Rows(0).Item("reserva_id"))
                            cmd.Parameters.Add(reserva_idParam)
                            getDataSet(cmd, sqlHDhuespedes, reserva, "Huesped")

                            'arregla tipo doc
                            Dim dt As DataTable = reserva.Tables("Huesped")
                            Dim x As Integer
                            For x = 0 To dt.Rows.Count - 1
                                If dt.Rows(x).IsNull("tipo_documento_id") OrElse Asc((dt.Rows(x)("tipo_documento_id")).Chars(0)) = 0 Then
                                    dt.Rows(x).Item("tipo_documento_id") = "D"
                                End If
                                If dt.Rows(x).IsNull("sexo_id") OrElse Asc((dt.Rows(x)("sexo_id")).Chars(0)) = 0 Then
                                    dt.Rows(x).Item("sexo_id") = "M"
                                End If

                            Next
                            cmd.Parameters.Clear()
                            getDataSet(cmd, sqlObtieneNaciones, reserva, "Naciones")
                            cmd.Parameters.Clear()
                            Dim hotel_id As Integer
                            hotel_id = reserva.Tables(0).Rows(0).Item("hotel_id")
                            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
                            Dim fecha_llegadaParam As New Odbc.OdbcParameter("@fecha_llegada", fecha_llegada)
                            cmd.Parameters.Add(hotel_idParam)
                            cmd.Parameters.Add(fecha_llegadaParam)
                            getDataSet(cmd, sqlHDBloqueoMin, reserva, "bloqueos_online")
                            cmd.Parameters.Clear()

                            Dim desc_corta As String
                            desc_corta = reserva.Tables(0).Rows(0).Item("abreviatura")
                            Dim desc_cortaParam As New Odbc.OdbcParameter("@desc_corta", desc_corta)
                            cmd.Parameters.Add(fecha_llegadaParam)
                            cmd.Parameters.Add(hotel_idParam)
                            cmd.Parameters.Add(desc_cortaParam)
                            getDataSet(cmd, sqlHDOcupacionAsignada, reserva, "ocupacion")

                        Else
                            'NO TIENE ACTIVO EL CHECKIN ONLINE
                            resultado = generaXMLError("generaHDreservasXML", 1)
                            errorCode = -2
                        End If

                    End If
                    If errorCode = 0 Then
                        resultado = reserva.GetXml()
                    End If
                    'Dim writer As System.IO.StringWriter = New System.IO.StringWriter()
                    'reserva.WriteXml(writer, XmlWriteMode.IgnoreSchema)
                    'resultado = "<?xml version='1.0' encoding='UTF-8'?>" & writer.ToString()
                Catch ex As Exception
                    errorCode = -1
                End Try
            Else
                errorCode = -2 'no pude encontrar la reserva
            End If

            If Not flushConection(cmd, errorCode) Then

            End If
            'resultado = "aki_" & bono & "_" & fecha_llegada
            Return resultado
        End Function
        Function ObtieneEmpresaHotel(ByVal hotel_id As Integer)
            Dim errorCode As Integer = 0
            Dim resultado As Integer = 0 'un valor por defecto con error
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            cmd.Parameters.Add(hotel_idParam)
            Try
                resultado = ExecuteScalar(cmd, sqlObtieneEmpresa_id, True)
            Catch ex As Exception
                errorCode = -1
            End Try

            If Not flushConection(cmd, errorCode) Then
                resultado = 0
            End If
            Return resultado
        End Function
        Shared sqlUpdateEmailReserva As String = "update reservas set email=?,observaciones_cliente=?,idioma_id=ifnull(?,idioma_id),hora_prevista_llegada=? WHERE reserva_id = ?"
        Private Function actualizaEmailReserva(reserva_id As Integer, email As Object, olleg As Object, languaje As Object, hora_llegada As Object) As Integer
            Dim errorCode As Integer = 0
            Dim resultado As Integer = 0 'un valor por defecto con error
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            If IsNothing(languaje) Then
                languaje = DBNull.Value
            End If
            If IsNothing(email) Then
                email = DBNull.Value
            End If
            If IsNothing(olleg) Then
                olleg = DBNull.Value
            End If
            If IsNothing(hora_llegada) Then
                hora_llegada = DBNull.Value
            End If
            Dim hora As DateTime = Nothing
            Try
                hora = DateTime.ParseExact(hora_llegada, "HH:mm", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None)
                hora_llegada = hora.ToShortTimeString()

            Catch ex As Exception

            End Try
            Dim emailParam As New Odbc.OdbcParameter("@email", email)
            Dim ollegParam As New Odbc.OdbcParameter("@olleg", olleg)
            Dim idioma_idParam As New Odbc.OdbcParameter("@idioma_id", languaje)
            Dim hora_llegadaaram As New Odbc.OdbcParameter("@hora_llegada", hora_llegada)
            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
            cmd.Parameters.Add(emailParam)
            cmd.Parameters.Add(ollegParam)
            cmd.Parameters.Add(idioma_idParam)
            cmd.Parameters.Add(hora_llegadaaram)
            cmd.Parameters.Add(reserva_idParam)
            Try
                resultado = ExecuteNonQuery(cmd, sqlUpdateEmailReserva)
                If resultado > 1 Then
                    errorCode = -2
                    'no pudo actualizar el email o actualizo demasiados.
                End If
            Catch ex As Exception
                errorCode = -1
            End Try

            If Not flushConection(cmd, errorCode) Then
                resultado = 0
            End If
            Return resultado

        End Function
        Function updateHDreserva(ByVal bono As String, ByVal fecha_llegada As Date, ByVal datos As String, Optional language As String = "es", Optional reserva_id_filtro As Integer = 0, Optional browser As String = "") As String
            Dim retval As String = ""
            Dim reserva As New DataSet
            Dim reader As System.IO.StringReader = New System.IO.StringReader(datos)
            reserva.ReadXml(reader)
            'COMPROBAR KE ESOS DATOS CORRESPONDEN A ESA RESERVA.

            If Not IsNothing(reserva.Tables("cabecera")) Then
                Dim cab As DataRow = reserva.Tables("cabecera").Rows(0)
                Dim olddatos = generaHDreservasXML(bono, fecha_llegada, Nothing, Nothing, Nothing, reserva_id_filtro)
                Dim reservaold As New DataSet
                Dim readerold As System.IO.StringReader = New System.IO.StringReader(olddatos)
                reservaold.ReadXml(readerold)
                If Not IsNothing(reservaold.Tables("cabecera")) Then
                    Dim cabold As DataRow = reservaold.Tables("cabecera").Rows(0)
                    Dim numincompleto As Integer = 0
                    Dim numcambios As Integer = 0
                    If cab("reserva_id") = cabold("reserva_id") Then


                        Dim empresa_id As Integer = ObtieneEmpresaHotel(cab("hotel_id"))

                        If Not IsNothing(reserva.Tables("Huesped")) Then
                            'tiene huespedes asi ke actualizar/editar/borrar?
                            Dim x = 0
                            Dim huespedes As DataTable = reserva.Tables("Huesped")
                            Dim hues(huespedes.Rows.Count - 1) As GesHotelClase.MetaHuesped
                            Dim totalhus As Integer = 0
                            If cabold.Table.Columns.Contains("pax") Then


                                If Not cabold.IsNull("pax") Then
                                    Try
                                        totalhus += cabold("pax")
                                    Catch ex As Exception

                                    End Try

                                End If
                            End If
                            If cabold.Table.Columns.Contains("b") Then
                                If Not cabold.IsNull("b") Then
                                    Try
                                        totalhus += cabold("b")
                                    Catch ex As Exception

                                    End Try

                                End If
                            End If

                            If huespedes.Rows.Count <> totalhus Then
                                numincompleto = numincompleto + 1
                            End If
                            For x = 0 To huespedes.Rows.Count - 1
                                'si cliente_id es negativo...
                                'sacar valor absolute..y borrar?

                                Dim item As DataRow = huespedes.Rows(x)
                                Dim itemOld As DataRow = huespedes.Rows(x)
                                Dim hus As New GesHotelClase.MetaHuesped
                                If Not IsNothing(item("cliente_id")) Then
                                    hus.cliente_id = item("cliente_id")
                                    If hus.cliente_id > 0 Then
                                        'obtener datos del cliente
                                        If Not IsNothing(reservaold.Tables("Huesped")) Then
                                            Dim drt() As DataRow = reservaold.Tables("Huesped").Select("cliente_id='" & hus.cliente_id & "'", "")
                                            If drt.Length > 0 Then
                                                itemOld = drt(0)
                                            End If
                                        End If
                                    End If
                                End If
                                If item.Equals(itemOld) Then
                                    numcambios = numcambios + 1
                                End If
                                If x = 0 Then
                                    Try
                                        hus.email = Trim(cab("email"))
                                        hus.acepta_lopd = True
                                        If IsNothing(hus.email) OrElse hus.email = "" Then
                                            numincompleto += 1
                                        End If
                                        If Not cabold.Table.Columns.Contains("email") And cab.Table.Columns.Contains("email") Then
                                            numcambios = numcambios + 1
                                        Else
                                            If Not cabold.Item("email") = (cab("email")) Then
                                                numcambios = numcambios + 1
                                            End If
                                        End If


                                    Catch ex As Exception
                                        numincompleto += 1
                                    End Try

                                End If

                                hus.empresa_id = empresa_id ' a sacar de la reserva
                                'todo sacar la edad
                                Dim edad As Integer = 18

                                Try
                                    hus.fecha_nacimiento = item("fecha_nacimiento")
                                    If Not IsDate(hus.fecha_nacimiento) Then
                                        hus.fecha_nacimiento = Nothing
                                    End If
                                    If IsNothing(hus.fecha_nacimiento) OrElse hus.fecha_nacimiento = "" Then
                                        numincompleto += 1
                                    End If
                                    Dim dat = Nothing
                                    If itemOld.Table.Columns.Contains("fecha_nacimiento") Then
                                        dat = parseTimedDate(itemOld("fecha_nacimiento"))
                                    End If

                                    Dim dat1 = parseTimedDate(item("fecha_nacimiento"))
                                    If Not dat = dat1 Then
                                        numcambios = numcambios + 1
                                    End If
                                    Try
                                        Dim datnac As Date = Date.Parse(dat1)
                                        edad = Today.Year - datnac.Year
                                        If (datnac > Today.AddYears(-edad)) Then edad -= 1
                                    Catch ex As Exception

                                    End Try


                                Catch ex As Exception
                                    numincompleto += 1
                                End Try

                                Dim requiredbyage As Boolean = True
                                If edad < 16 Then
                                    requiredbyage = False
                                End If
                                Try
                                    hus.fecha_documento = item("fecha_documento")
                                    If Not IsDate(hus.fecha_documento) Then
                                        hus.fecha_documento = Nothing
                                    End If

                                    If IsNothing(hus.fecha_documento) OrElse hus.fecha_documento = "" Then
                                        If requiredbyage Then
                                            numincompleto += 1
                                        End If

                                    End If
                                    Dim dat = Nothing
                                    If itemOld.Table.Columns.Contains("fecha_documento") Then
                                        dat = parseTimedDate(itemOld("fecha_documento"))
                                    End If
                                    Dim dat1 = parseTimedDate(item("fecha_documento"))
                                    If Not dat = dat1 Then
                                        numcambios = numcambios + 1
                                    End If
                                Catch ex As Exception
                                    If requiredbyage Then
                                        numincompleto += 1
                                    End If
                                End Try


                                Try
                                    hus.nacion_id = item("nacion_id")
                                    If IsNothing(hus.nacion_id) OrElse hus.nacion_id = 0 Then
                                        numincompleto += 1
                                    End If
                                    If itemOld.Table.Columns.Contains("nacion_id") Then
                                        If (Not item.IsNull("nacion_id") And itemOld.IsNull("nacion_id")) OrElse Not item("nacion_id") = (itemOld("nacion_id")) Then
                                            numcambios = numcambios + 1
                                        End If
                                    Else
                                        If Not item.IsNull("nacion_id") Then
                                            numcambios = numcambios + 1
                                        End If
                                    End If
                                Catch ex As Exception
                                    numincompleto += 1
                                End Try
                                Try
                                    hus.tipo_documento_id = Trim(item("tipo_documento_id"))
                                    If IsNothing(hus.tipo_documento_id) OrElse hus.tipo_documento_id = "" Then
                                        If requiredbyage Then
                                            numincompleto += 1
                                        End If
                                    End If

                                    If itemOld.Table.Columns.Contains("tipo_documento_id") Then
                                        If Not item("tipo_documento_id") = (itemOld("tipo_documento_id")) Then
                                            numcambios = numcambios + 1
                                        End If
                                    Else
                                        If Not item.IsNull("tipo_documento_id") Then
                                            numcambios = numcambios + 1
                                        End If
                                    End If

                                Catch ex As Exception
                                    If requiredbyage Then
                                        numincompleto += 1
                                    End If
                                End Try
                                Try
                                    hus.nif = Trim(item("nif"))
                                    If Not IsNothing(hus.nif) Then
                                        If hus.nif.Length > 19 Then
                                            hus.nif = hus.nif.Substring(0, 19)
                                        End If
                                    End If
                                    If IsNothing(hus.nif) OrElse hus.nif = "" Then
                                        If requiredbyage Then
                                            numincompleto += 1
                                        End If
                                    End If
                                    If itemOld.Table.Columns.Contains("nif") Then
                                        If Not item("nif") = (itemOld("nif")) Then
                                            numcambios = numcambios + 1
                                        End If
                                    Else
                                        If Not item.IsNull("nif") Then
                                            numcambios = numcambios + 1
                                        End If
                                    End If
                                Catch ex As Exception
                                    If requiredbyage Then
                                        numincompleto += 1
                                    End If
                                End Try
                                Try
                                    hus.razon = Trim(item("razon"))
                                    If IsNothing(hus.razon) OrElse hus.razon = "" Then
                                        numincompleto += 1
                                    End If
                                    If itemOld.Table.Columns.Contains("razon") Then
                                        If Not item("razon") = (itemOld("razon")) Then
                                            numcambios = numcambios + 1
                                        End If
                                    Else
                                        If Not item.IsNull("razon") Then
                                            numcambios = numcambios + 1
                                        End If
                                    End If
                                Catch ex As Exception
                                    numincompleto += 1
                                End Try

                                'CONTACTO
                                Try
                                    hus.contacto = Trim(item("contacto"))
                                Catch ex As Exception

                                End Try
                                '
                                Try
                                    hus.sexo_id = Trim(item("sexo_id"))
                                    If IsNothing(hus.sexo_id) OrElse hus.sexo_id = "" Then
                                        numincompleto += 1
                                    End If
                                    If itemOld.Table.Columns.Contains("sexo_id") Then
                                        If Not item("sexo_id") = (itemOld("sexo_id")) Then
                                            numcambios = numcambios + 1
                                        End If
                                    Else
                                        If Not item.IsNull("sexo_id") Then
                                            numcambios = numcambios + 1
                                        End If
                                    End If

                                Catch ex As Exception
                                    numincompleto += 1
                                End Try
                                Try
                                    hus.tipo_huesped_id = item("tipo_huesped_id")
                                    If IsNothing(hus.tipo_huesped_id) OrElse hus.tipo_huesped_id = 0 Then
                                        numincompleto += 1
                                    End If
                                    If itemOld.Table.Columns.Contains("tipo_huesped_id") Then
                                        If Not item("tipo_huesped_id") = (itemOld("tipo_huesped_id")) Then
                                            numcambios = numcambios + 1
                                        End If
                                    Else
                                        If Not item.IsNull("tipo_huesped_id") Then
                                            numcambios = numcambios + 1
                                        End If
                                    End If

                                Catch ex As Exception
                                    'numincompleto += 1
                                End Try

                                hues(x) = hus
                            Next
                            If Not actualizaHuespedesReserva(reserva.Tables("cabecera").Rows(0).Item("reserva_id"), hues) Then
                                'escribir a un fichero log
                                Try
                                    My.Computer.FileSystem.WriteAllText("C://TEMP//checking.TXT", "UN ERROR-" & datos & vbNewLine, True, New System.Text.ASCIIEncoding)
                                Catch ex As Exception

                                End Try

                                numincompleto += 1
                            End If
                        Else
                            numincompleto += 1
                        End If

                        'actualizar email de la reserva
                        'If Not cab.IsNull("email") Then
                        Dim email As String = Nothing
                        Dim olleg As String = Nothing
                        Dim hora_llegada As String = Nothing
                        Try
                            email = cab("email")

                        Catch ex As Exception
                            numincompleto += 1
                        End Try
                        Try
                            olleg = cab("observaciones_llegada")
                        Catch ex As Exception

                        End Try
                        Try
                            hora_llegada = cab("hora_prevista_llegada")
                        Catch ex As Exception

                        End Try
                        If IsNothing(email) Then
                            email = ""
                            numincompleto += 1
                        End If
                        If IsNothing(olleg) Then
                            olleg = ""
                        End If
                        If numincompleto = 0 Then
                        Else
                            'no grabar el lenguaje si hay errores o esta incompleto
                            'problema..si hay un menor...NO ACTUALIZA?
                            language = Nothing
                        End If
                        actualizaEmailReserva(reserva.Tables("cabecera").Rows(0).Item("reserva_id"), email, olleg, language, hora_llegada)

                        'End If

                        'controlar ke este dentro de minimo_dias_checkin_online
                        If cab.Table.Columns.Contains("numero_habitacion") Then
                            If Not cab.IsNull("numero_habitacion") Then
                                'TODO SI ES CERO...SE CANCELA LA ASIGNACION
                                'detectar cambio de hab

                                If Not cabold.Table.Columns.Contains("numero_habitacion") OrElse cabold.Item("numero_habitacion") <> cab.Item("numero_habitacion") Then
                                    Dim habitacion_id As Integer = ObtieneHabitacion_Id(cab("hotel_id"), cab("numero_habitacion"))
                                    Dim tsTimeSpan = FechaHotel(cabold("hotel_id")).Subtract(cabold("fecha_prevista_llegada"))
                                    Dim iNumberOfDays = -tsTimeSpan.Days
                                    If iNumberOfDays >= cabold("minimo_dias_checkin_online") Then
                                        'todo comprobar estancia minima
                                        Dim bloqueos_online As DataRowCollection = Nothing
                                        If Not IsNothing(reservaold.Tables("bloqueos_online")) Then
                                            bloqueos_online = reservaold.Tables("bloqueos_online").Rows
                                            If bloqueos_online.Count > 0 Then
                                                Dim fechasal As Date = cabold("fecha_prevista_salida")
                                                Dim fechaent As Date = cabold("fecha_prevista_llegada")
                                                Dim estancia As Integer = fechasal.Subtract(fechaent).Days
                                                If estancia < bloqueos_online(0).Item("min_noches") Then
                                                    habitacion_id = -1
                                                    retval = generaXMLError("updateHDreserva", 1)
                                                End If
                                            End If
                                        End If
                                        If habitacion_id <> -1 Then
                                            If Not IsNothing(reservaold.Tables("ocupacion")) Then
                                                If reservaold.Tables("ocupacion").Rows.Count = 0 Then
                                                    'no existe tipo hab
                                                    habitacion_id = -1
                                                    retval = generaXMLError("updateHDreserva", 1)
                                                End If
                                            End If
                                        End If
                                        If habitacion_id <> -1 Then
                                            'todo supera el % de ocupacion
                                            If Not IsNothing(reservaold.Tables("ocupacion")) And Not IsNothing(bloqueos_online) Then
                                                If reservaold.Tables("ocupacion").Rows.Count > 0 And bloqueos_online.Count > 0 Then
                                                    Dim ocupacion As DataRow = reservaold.Tables("ocupacion").Rows(0)

                                                    Dim val As String = ocupacion.Item("PORC_OCUPACION_ASIGNADO")
                                                    val = val.Replace(".", ",")
                                                    Dim vald As Double = Double.Parse(val)
                                                    If bloqueos_online(0).Item("porc_ocupacion") < vald Then
                                                        habitacion_id = -1
                                                        retval = generaXMLError("updateHDreserva", 1)
                                                    End If
                                                End If
                                            End If

                                        End If
                                        If habitacion_id <> -1 Then
                                            AsignaHabitacionReserva(cab("reserva_id"), habitacion_id, True)
                                            EmailTraducido(reserva.Tables("cabecera").Rows(0).Item("reserva_id"), "EMAIL_CHANGE_ROOM", True)
                                            'todo fallo de asignancion de hab.
                                        End If
                                    Else
                                        'error..no puede por los dias
                                        retval = generaXMLError("updateHDreserva", 1)
                                    End If
                                End If
                            End If
                        End If
                        'todo detectar cambios en los demas campos?
                        Dim notiene As Boolean = False
                        If Not reservaold.Tables("cabecera").Columns.Contains("idioma_id") Then
                            notiene = True
                        End If
                        If numincompleto = 0 And numcambios > 0 And notiene Then
                            browser = ""
                            If browser = "totem" Or browser = "totem-wifi" Then
                                If browser = "totem" Then
                                    EmailTraducido(reserva.Tables("cabecera").Rows(0).Item("reserva_id"), "EMAIL_HOTEL_WIFI", True)
                                End If
                            Else
                                EmailTraducido(reserva.Tables("cabecera").Rows(0).Item("reserva_id"), "EMAIL_CONFIRMATION", True)
                                'EmailTraducido(reserva.Tables("cabecera").Rows(0).Item("reserva_id"), "EMAIL_HOTEL_WIFI", True)
                            End If

                        End If




                    Else
                        'no coinciden las cabeceras..
                    End If
                Else
                    'no existe la reserva en el segundo paso
                End If
            End If
            Return retval
        End Function
        Shared sqlHotelesHD As String = "select * from hoteles"

        Function actualizarHDHotelsXml()
            Return True
        End Function
        Dim sqlHDLimpiezasHotel = "" _
& "SELECT max(hora_validacion) as hora_validacion,max(hora_limpieza) as hora_limpieza,group_concat(item_limpieza_id) as items,limpiezas.fecha,limpiezas.habitacion_id AS habitacion_id, fecha_prevista_llegada, fecha_prevista_salida, hora_prevista_llegada, hora_prevista_salida," _
& " (select RIGHT(CONCAT('000',habitaciones.numero_habitacion),4)) AS numero," _
& " limpiezas.reserva_id AS limpiezas_reserva_id " _
& " FROM ((limpiezas INNER JOIN habitaciones ON " _
& " limpiezas.habitacion_id = habitaciones.habitacion_id) LEFT JOIN reservas ON" _
& " limpiezas.reserva_id = reservas.reserva_id) LEFT JOIN clientes ON " _
& " reservas.cliente_id = clientes.cliente_id" _
& " WHERE habitaciones.hotel_id = ?" _
& " AND limpiezas.fecha = ?" _
& " GROUP BY limpiezas.habitacion_id " _
& " ORDER BY numero"
        Shared sqlHDNotificaciones = "SELECT dispositivos_notificaciones.notificacion_id," _
& " dispositivos_notificaciones.estado_id," _
& " dispositivos_notificaciones.fecha_creacion," _
& " dispositivos_notificaciones.fecha_envio," _
& " dispositivos_notificaciones.fecha_cambio_estado," _
& " dispositivos_notificaciones.mensaje" _
& " FROM" _
& " dispositivos_notificaciones" _
& " INNER JOIN dispositivos ON dispositivos_notificaciones.dispositivo_id = dispositivos.dispositivo_id" _
& " WHERE" _
& " dispositivos.destino = ? AND" _
& " dispositivos.tipo_dispositivo_id = ? order by fecha_creacion desc limit 20"

        Shared sqlHDnotiusuario = "SELECT dispositivos_notificaciones.notificacion_id," _
& " dispositivos_notificaciones.mensaje," _
& " dispositivos_notificaciones.fecha_creacion" _
& " FROM" _
& " dispositivos_notificaciones" _
& " INNER JOIN dispositivos ON dispositivos_notificaciones.dispositivo_id = dispositivos.dispositivo_id" _
& " where dispositivos.usuario_id=? and dispositivos_notificaciones.fecha_creacion >=?" _
& " order by fecha_creacion desc"

        Dim SQLHDObtieneHotelDelUsuario = "" _
& "         SELECT min(usuarios_hoteles.hotel_id) as hotel_id" _
& " FROM" _
& " usuarios_hoteles" _
& " WHERE" _
& " usuarios_hoteles.usuario_id = ?"
        Shared sqlItemsLimpiezas = "SELECT" _
& " items_limpieza.item_limpieza_id," _
& " items_limpieza.item_limpieza " _
& " FROM" _
& " items_limpieza"
        Shared sqlHD_graba_fecha_limpieza As String = "UPDATE limpiezas SET hora_limpieza=NOW() WHERE habitacion_id = ? AND fecha = ?"
        Shared sqlHD_graba_fecha_validacion As String = "UPDATE limpiezas SET hora_validacion=NOW() WHERE habitacion_id = ? AND fecha = ?"
        Private Class login
            Public userId As Integer

            Friend Function Login(usuario As String, password As String, ip As String) As Object
                Throw New NotImplementedException()
            End Function
        End Class
        Public Function setLimpiezas(usuario As String, password As String, Optional ip As String = "80.59.112.27", Optional register As String = Nothing, Optional tiporegister As String = Nothing, Optional language As String = Nothing, Optional repasada As Integer = -1, Optional habitacion As String = Nothing) As String
            Dim resultado As String = "no"
            Dim logged As Object = Nothing
            Dim login As New login



            'Dim login As New GestionUsuarios.GESTCAC.Login
            '            Try
            'logged = login.Login(usuario, password, ip)
            'Catch ex As Exception


            'End Try

            If Not IsNothing(logged) Then

                'obtener el user id

                If Not IsDBNull(login.userId) Then
                    Dim usuario_id As Integer = login.userId





                    Dim errorCode As Integer = 0
                    Dim cmd As Odbc.OdbcCommand = prepareConection()
                    cmd.Parameters.Clear()
                    Dim usuario_idParam As New Odbc.OdbcParameter("@usuario_id", usuario_id)
                    cmd.Parameters.Add(usuario_idParam)

                    Try


                        Dim hotel_id As Object = Me.ExecuteScalar(cmd, SQLHDObtieneHotelDelUsuario)
                        If Not IsDBNull(hotel_id) Then


                            registraDispositivoHDHotels(cmd, register, tiporegister, hotel_id, Nothing, language, usuario_id)

                            'sacar el hotel del user_id
                            'Dim hotel_id As Integer = 2
                            'obtener las limpiezas del hotel

                            'obtener fecha del hotel
                            Dim fecha As Date = FechaHotel(cmd, hotel_id)
                            Try
                                'OBTENER LA HABITACION_ID
                                Dim habitacion_id As Integer = ObtieneHabitacion_Id(cmd, hotel_id, habitacion)
                                If habitacion_id > 0 Then

                                    cmd.Parameters.Clear()
                                    Dim habitacion_idParam As New Odbc.OdbcParameter("@hotel_id", habitacion_id)
                                    Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
                                    cmd.Parameters.Add(habitacion_idParam)
                                    cmd.Parameters.Add(fechaParam)

                                    'hacer las act ups
                                    If repasada = 0 Then
                                        'marcar todas como limpias
                                        If ExecuteNonQuery(cmd, sqlHD_graba_fecha_limpieza) > 0 Then
                                        Else
                                            errorCode = -4 'no actualizo nada
                                        End If
                                    End If
                                    If repasada = 1 Then
                                        'MARCAR TODAS COMO REPASADAS
                                        If ExecuteNonQuery(cmd, sqlHD_graba_fecha_validacion) > 0 Then
                                        Else
                                            errorCode = -4 'no actualizo nada
                                        End If
                                    End If
                                Else
                                    errorCode = -3 'no encuentro la hab
                                End If
                            Catch ex As Exception
                                errorCode = -1
                            End Try
                        Else
                            errorCode = -2 'sin hotel
                        End If

                    Catch ex As Exception
                        errorCode = -5 'excepcion
                    End Try
                    If Not flushConection(cmd, errorCode) Then

                    End If
                    If errorCode = 0 Then
                        resultado = getLimpiezas(usuario, password, ip, register, tiporegister, language)
                    End If

                Else
                    resultado = "no"
                End If
            End If
            Return resultado
        End Function
        Public Function getNotificaciones(register As String, tiporegister As String, languaje As String)
            'convertir tiporegister a un int
            'construir la query
            'sacar datos de la query
            'devolver xml si procede
            Dim resultado As String = "no"
            Dim errorCode As Integer = 0
            Dim tipo As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try
                tipo = obtieneTipoRegister(tiporegister)
                registraDispositivoHDHotels(cmd, register, tiporegister, 0, 0, languaje, 0)
                cmd.Parameters.Clear()
                Dim registerParam As New Odbc.OdbcParameter("@register", register)
                cmd.Parameters.Add(registerParam)
                Dim tipoParam As New Odbc.OdbcParameter("@tipo", tipo)
                cmd.Parameters.Add(tipoParam)
                Dim reserva As DataSet = Me.getDataSet(cmd, sqlHDNotificaciones)
                reserva.Tables(0).TableName = "notificacion"
                Dim writer As System.IO.StringWriter = New System.IO.StringWriter()
                reserva.WriteXml(writer, XmlWriteMode.IgnoreSchema)
                resultado = "<?xml version='1.0' encoding='UTF-16'?>" & writer.ToString()
            Catch ex As Exception
                errorCode = -1
            End Try
            If Not flushConection(cmd, errorCode) Then

            End If

            Return resultado
        End Function
        Public Function getNodi(incidencia_id As Integer, usuario As String, password As String, Optional ip As String = "80.59.112.27", Optional register As String = Nothing, Optional tiporegister As String = Nothing)
            Dim resultado As String = "no"
            Dim Ds As DataSet
            Dim sql_get_pendientes As String = "SELECT cms.incidencias.*,cms.departamentos.departamento " _
            & "FROM cms.incidencias " _
            & "INNER JOIN cms.usuarios_departamentos ON cms.incidencias.para_departamento_id = cms.usuarios_departamentos.departamento_id " _
            & "LEFT JOIN cms.usuarios ON cms.incidencias.usuario_id = cms.usuarios.user_id " _
            & "INNER JOIN cms.departamentos ON cms.incidencias.de_departamento_id = cms.departamentos.departamento_id " _
            & "WHERE cms.incidencias.estado_id=1 And cms.incidencias.para_departamento_id = ? {where} ORDER BY ASC fecha_creacion LIMIT 20"
            Dim sql_get_departamento As String = "SELECT MAX(cms.usuarios_departamentos.departamento_id) FROM cms.usuarios_departamentos Where usuario_id = ? "
            Dim sql_get_centros As String = "SELECT * FROM cms.centros" _
            & " INNER JOIN cms.usuarios_centros ON cms.centros.centro_id = cms.usuarios_centros.centro_id " _
            & "where cms.usuarios_centros.usuario_id = ?"
            Dim sql_get_departamentos As String = "SELECT cms.departamentos.* " _
            & "FROM cms.centros " _
            & "INNER JOIN cms.usuarios_centros ON cms.centros.centro_id = cms.usuarios_centros.centro_id" _
            & "INNER JOIN cms.departamentos ON cms.departamentos.centro_id = cms.centros.centro_id " _
            & "WHERE cms.usuarios_centros.usuario_id = ? "

            Dim errorcode As Integer = 0
            Dim login As New login 'GestionUsuarios.GESTCAC.Login
            Dim logged As Object = Nothing
            Try
                logged = login.Login(usuario, password, ip)
            Catch ex As Exception
                'login.userId = 2
                'logged = New Object
            End Try
            Dim where As String = ""
            If incidencia_id <> 0 Then
                where = "AND cms.incidencias.incidencia_id=" & incidencia_id
            End If
            sql_get_pendientes = sql_get_pendientes.Replace("{where}", where)
            If Not IsNothing(logged) Then

                'obtener el user id

                If Not IsDBNull(login.userId) Then
                    Dim cmd As Odbc.OdbcCommand = prepareConection()
                    Try
                        login.userId = 10 'a quitar
                        Dim user_idParam As New Odbc.OdbcParameter("@user_id", login.userId)
                        ' Obtengo el departamento_id del usuario para ver las novedades de su departamento.
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(user_idParam)
                        Dim departamento_id As Object = Me.ExecuteScalar(cmd, sql_get_departamento)
                        If Not IsDBNull(departamento_id) Then

                            Dim departamento_idParam As New Odbc.OdbcParameter("@departamento_id", departamento_id)
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add(departamento_idParam)
                            'obtener Novedades Pendientes y convertir a xml
                            Me.getDataSet(cmd, sql_get_pendientes, Ds, "Nodi")
                            If Not IsNothing(Ds) Then
                                Me.getDataSet(cmd, sql_get_centros, Ds, "centros")
                                Me.getDataSet(cmd, sql_get_departamentos, Ds, "departamentos")
                                Ds.Tables(0).TableName = "Nodi"
                                Dim writer As System.IO.StringWriter = New System.IO.StringWriter()
                                'Ds.Tables("Nodi").WriteXml(writer, XmlWriteMode.IgnoreSchema)
                                'Ds.Tables("centros").WriteXml(writer, XmlWriteMode.IgnoreSchema)
                                Ds.WriteXml(writer, XmlWriteMode.IgnoreSchema)
                                resultado = "<?xml version='1.0' encoding='UTF-16'?>" & writer.ToString()
                            End If
                        End If
                    Catch ex As Exception
                        errorcode = 1
                    End Try
                    flushConection(cmd, errorcode)
                End If
            End If
            Return resultado
        End Function

        Public Function getLimpiezas(usuario As String, password As String, Optional ip As String = "80.59.112.27", Optional register As String = Nothing, Optional tiporegister As String = Nothing, Optional language As String = Nothing) As String
            Dim resultado As String = "no"
            Dim login As New login ' GestionUsuarios.GESTCAC.Login
            Dim logged As Object = Nothing
            Try
                logged = login.Login(usuario, password, ip)
            Catch ex As Exception
                'login.userId = 2
                'logged = New Object
            End Try

            If Not IsNothing(logged) Then

                'obtener el user id

                If Not IsDBNull(login.userId) Then
                    Dim usuario_id As Integer = login.userId
                    Dim errorCode As Integer = 0
                    Dim cmd As Odbc.OdbcCommand = prepareConection()
                    cmd.Parameters.Clear()
                    Dim usuario_idParam As New Odbc.OdbcParameter("@usuario_id", usuario_id)
                    cmd.Parameters.Add(usuario_idParam)
                    Dim hotel_id As Object = Me.ExecuteScalar(cmd, SQLHDObtieneHotelDelUsuario)
                    If Not IsDBNull(hotel_id) Then


                        registraDispositivoHDHotels(cmd, register, tiporegister, hotel_id, Nothing, language, usuario_id)

                        'sacar el hotel del user_id
                        'Dim hotel_id As Integer = 2
                        'obtener las limpiezas del hotel

                        'obtener fecha del hotel
                        Dim fecha As Date = FechaHotel(cmd, hotel_id)
                        cmd.Parameters.Clear()
                        Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
                        Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
                        cmd.Parameters.Add(hotel_idParam)
                        cmd.Parameters.Add(fechaParam)
                        Try
                            Dim reserva As DataSet = Me.getDataSet(cmd, sqlHDLimpiezasHotel)
                            If Not IsNothing(reserva) Then
                                'resultado = habitaciones.GetXml()
                                reserva.Tables(0).TableName = "limpieza"
                                getDataSet(cmd, sqlItemsLimpiezas, reserva, "items_limpieza")
                                Dim fechaParamn As New Odbc.OdbcParameter("@fecha", convertFecha(Today))
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add(usuario_idParam)
                                cmd.Parameters.Add(fechaParamn)
                                getDataSet(cmd, sqlHDnotiusuario, reserva, "notificacion")


                                Dim writer As System.IO.StringWriter = New System.IO.StringWriter()
                                reserva.WriteXml(writer, XmlWriteMode.IgnoreSchema)
                                resultado = "<?xml version='1.0' encoding='UTF-16'?>" & writer.ToString()
                            End If


                        Catch ex As Exception
                            errorCode = -1
                        End Try
                    Else
                        errorCode = -2 'sin hotel
                    End If

                    If Not flushConection(cmd, errorCode) Then

                    End If
                Else
                    resultado = "no"
                End If
            End If
            Return resultado
        End Function
        Shared sqlHdGaleria As String = "select * from Galeria where hotel_id=? OR ?=0"
        Public Function getGaleria(hotel_id As Integer) As String
            'obtiene todas las galerias
            Dim resultado As String = "no"
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            cmd.Parameters.Clear()
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            Dim hotel_id1Param As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            cmd.Parameters.Add(hotel_idParam)
            cmd.Parameters.Add(hotel_id1Param)
            Try
                Dim reserva As DataSet = Me.getDataSet(cmd, sqlHdGaleria)
                If Not IsNothing(reserva) Then
                    'resultado = habitaciones.GetXml()
                    reserva.Tables(0).TableName = "galeria"
                    Dim writer As System.IO.StringWriter = New System.IO.StringWriter()
                    reserva.Tables(0).WriteXml(writer, XmlWriteMode.IgnoreSchema)
                    resultado = "<?xml version='1.0' encoding='UTF-16'?>" & writer.ToString()
                End If


            Catch ex As Exception
                errorCode = -1
            End Try

            If Not flushConection(cmd, errorCode) Then

            End If
            Return resultado
        End Function
        Public Function setGaleria(datos As String) As String
            Dim resultado As String = "no"
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            cmd.Parameters.Clear()
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", 0)
            Dim hotel_id1Param As New Odbc.OdbcParameter("@hotel_id", 0)
            cmd.Parameters.Add(hotel_idParam)
            cmd.Parameters.Add(hotel_id1Param)
            Try
                Dim galeriagrabada As DataSet = Me.getDataSet(cmd, sqlHdGaleria)
                Dim galeriaentrada As New DataSet
                Dim reader As System.IO.StringReader = New System.IO.StringReader(datos)
                galeriaentrada.ReadXml(reader)
                Dim fotos As DataTable = galeriaentrada.Tables("galeria")

                Dim x As Integer
                For x = 0 To fotos.Rows.Count - 1
                    Dim esalta As Boolean = False
                    Dim esbaja As Boolean = False
                    Dim galeria_id As Integer = fotos.Rows(x).Item("galeria_id")
                    If galeria_id < 0 Then
                        'es una baja
                        galeria_id = -galeria_id
                        esbaja = True
                        Dim rows() As DataRow = galeriagrabada.Tables(0).Select("galeria_id=" & galeria_id, "")
                        If (rows.Length > 0) Then
                            rows(0).Delete()

                        End If
                    Else
                        Dim row As DataRow = Nothing
                        If galeria_id = 0 Then
                            'es un alta
                            esalta = True
                            row = galeriagrabada.Tables(0).NewRow()
                            galeriagrabada.Tables(0).Rows.Add(row)
                            Try
                                row.Item("hotel_id") = fotos.Rows(x).Item("hotel_id")
                            Catch ex As Exception

                            End Try
                            Try
                                row.Item("tipo_habitacion_id") = fotos.Rows(x).Item("tipo_habitacion_id")
                            Catch ex As Exception

                            End Try
                            Try
                                row.Item("habitacion_id") = fotos.Rows(x).Item("habitacion_id")
                            Catch ex As Exception

                            End Try


                        End If
                        If Not IsNothing(row) OrElse galeria_id <> 0 Then
                            'es una modificacion


                            If IsNothing(row) Then
                                Dim rows() As DataRow = galeriagrabada.Tables(0).Select("galeria_id=" & galeria_id, "")
                                If rows.Length > 0 Then
                                    row = rows(0)
                                Else
                                    esalta = True
                                End If
                            End If

                            If Not IsNothing(row) Then
                                Try
                                    row.Item("orden") = fotos.Rows(x).Item("orden")
                                Catch ex As Exception

                                End Try



                                Try
                                    row.Item("lat") = fotos.Rows(x).Item("lat")
                                Catch ex As Exception

                                End Try
                                Try
                                    row.Item("lng") = fotos.Rows(x).Item("lng")
                                Catch ex As Exception

                                End Try
                                Try
                                    row.Item("foto_url") = fotos.Rows(x).Item("foto_url")
                                Catch ex As Exception

                                End Try

                                Try
                                    row.Item("icono_url") = fotos.Rows(x).Item("icono_url")
                                Catch ex As Exception

                                End Try

                                Try
                                    row.Item("Nombre") = fotos.Rows(x).Item("Nombre")
                                Catch ex As Exception

                                End Try
                                Try
                                    row.Item("Descripcion") = fotos.Rows(x).Item("Descripcion")
                                Catch ex As Exception

                                End Try
                                Try
                                    row.Item("planta") = fotos.Rows(x).Item("planta")
                                Catch ex As Exception

                                End Try
                            End If

                        End If





                    End If

                    Dim writer As Odbc.OdbcDataAdapter
                    writer = getDataAdapter(cmd, sqlHdGaleria)
                    writer.Fill(galeriagrabada.Tables(0))
                    writer.Update(galeriagrabada.Tables(0))
                    If Not esbaja And esalta Then
                        'sacar la ultima id insertada
                        galeria_id = ExecuteScalar(cmd, "SELECT LAST_INSERT_ID()")
                    End If
                    'falta los idiomas
                    If Not esbaja Then
                        'crear dataset ke necesita la actualizacion de fotos
                        Dim lenguajes As DataTable = galeriaentrada.Tables("language")
                        If Not IsNothing(lenguajes) Then
                            cmd.Parameters.Clear()
                            Dim lan_codeParam As New Odbc.OdbcParameter("@lan_code", -1)
                            cmd.Parameters.Add(lan_codeParam)
                            Dim lan_upd As DataSet = Me.getDataSet(cmd, sqlHdhotel_lan)
                            Dim lan_tble As DataTable = lan_upd.Tables(0)
                            Dim xx As Integer

                            For xx = 0 To lenguajes.Rows.Count - 1
                                Dim dr As DataRow = lan_tble.Rows.Add
                                dr.Item("lan_code") = lenguajes.Rows(xx).Item("lan_code")
                                dr.Item("lan_key") = "GALERIA_NOMBRE_" & galeria_id
                                dr.Item("value") = lenguajes.Rows(xx).Item("nombre")
                                dr = lan_tble.Rows.Add
                                dr.Item("lan_code") = lenguajes.Rows(xx).Item("lan_code")
                                dr.Item("lan_key") = "GALERIA_DESC_" & galeria_id
                                dr.Item("value") = lenguajes.Rows(xx).Item("descripcion")
                            Next
                            errorCode = setLanguage(cmd, lan_upd)
                            If errorCode <> 0 Then
                                Throw New System.Exception("No Pudo grabar los lenguajes.")
                            End If
                        End If
                    Else
                        'borrar traduccion de fotos
                        'clave GALERIA_1
                        cmd.Parameters.Clear()
                        Dim galeria_idNombreParam As New Odbc.OdbcParameter("@galeria_id", "GALERIA_NOMBRE_" & galeria_id)
                        Dim galeria_idDescripcionParam As New Odbc.OdbcParameter("@galeria_id", "GALERIA_DESC_" & galeria_id)
                        cmd.Parameters.Add(galeria_idNombreParam)
                        cmd.Parameters.Add(galeria_idDescripcionParam)
                        ExecuteNonQuery(cmd, "delete from hdhotels_lan where lan_key =? or lan_key =?")
                    End If
                Next

            Catch ex As Exception
                errorCode = -1
            End Try
            If Not flushConection(cmd, errorCode) Then

            End If
            Return resultado
            'detectar si es un alta o baja
            'una baja tiene galeria_id pero todos los demas campos vacios.

            'si es un alta...y ya existia...actualizar
            'si es una baja...borrar de la bd
            'permitir multiples acciones
            'cada alta/modif...trae una tabla auxiliar con los idiomas...ke acabara en la traduccion

        End Function
        Shared sqlHdhotel_lan As String = "select * from hdhotels_lan where lan_code=?"
        Shared sqlHdhotel_lan_key As String = "select * from hdhotels_lan where (lan_code=? or ?='' ) and lan_key=? "
        Shared sqlHdhotel_lanStore As String = "select * from hdhotels_lan"
        Public Function setLanguage(datos As String) As String
            Dim resultado As String = "no:" ' + lanurl 'un valor por defecto con error
            Dim errorCode As Integer = 0
            Dim languages As New DataSet
            Try
                Dim reader As System.IO.StringReader = New System.IO.StringReader(datos)
                languages.ReadXml(reader)
            Catch ex As Exception

            End Try
            If Not IsNothing(languages) Then
                Dim cmd As Odbc.OdbcCommand = prepareConection()
                errorCode = setLanguage(cmd, languages)
                If Not flushConection(cmd, errorCode) Then
                End If
            End If
            Return resultado
        End Function

        Public Function setLanguage(cmd As Odbc.OdbcCommand, languages As DataSet) As Integer
            Dim resultado As String = "no:" ' + lanurl 'un valor por defecto con error
            Dim errorCode As Integer = 0
            Try

                cmd.Parameters.Clear()
                Dim lan_old As DataSet = Me.getDataSet(cmd, sqlHdhotel_lanStore)
                'todo actualizar valores si existe
                'añadir nuevos si no existe
                'borrar si estan en blanco
                Dim dt As DataTable = languages.Tables(0)
                Dim x As Integer
                For x = 0 To dt.Rows.Count - 1
                    Dim rows() As DataRow = lan_old.Tables(0).Select("lan_code='" & dt.Rows(x).Item("lan_code") & "' and lan_key='" & dt.Rows(x).Item("lan_key") & "'", "")
                    If rows.Length > 0 Then
                        'la encontro
                        If IsNothing(dt.Rows(x).Item("value")) Then
                            'lo borro
                            rows(0).Delete()
                        Else
                            If IsNothing(rows(0).Item("value")) Then
                                'lo cambio
                                rows(0).Item("value") = dt.Rows(x).Item("value")
                            Else
                                If rows(0).Item("value") <> dt.Rows(x).Item("value") Then
                                    rows(0).Item("value") = dt.Rows(x).Item("value")
                                Else
                                    'es el mismo..no tokar..
                                End If
                            End If

                        End If

                    Else
                        'no existe..crear
                        If Not IsDBNull(dt.Rows(x).Item("value")) Then
                            Dim nr As DataRow = lan_old.Tables(0).NewRow()
                            nr.Item("lan_code") = dt.Rows(x).Item("lan_code")
                            nr.Item("lan_key") = dt.Rows(x).Item("lan_key")
                            nr.Item("value") = dt.Rows(x).Item("value")

                            lan_old.Tables(0).Rows.Add(nr)

                        End If

                    End If
                Next

                Dim writer As Odbc.OdbcDataAdapter
                writer = getDataAdapter(cmd, sqlHdhotel_lanStore)
                writer.Fill(lan_old.Tables(0))
                writer.Update(lan_old.Tables(0))
            Catch ex As Exception
                errorCode = 1 'falla algo
                resultado = "no:" + ex.ToString

            End Try

            Return errorCode
        End Function


        Public Function getLanguage(lanurl As String) As String
            'devolver un xml vacio o con una reserva.

            lanurl = lanurl.Replace("-", ".").Split(".")(1)
            Dim resultado As String = "no:" + lanurl 'un valor por defecto con error
            If lanurl.Length = 2 Then
                Dim errorCode As Integer = 0
                Dim cmd As Odbc.OdbcCommand = prepareConection()
                Try
                    cmd.Parameters.Clear()
                    Dim lan_codeParam As New Odbc.OdbcParameter("@lan_code", lanurl)
                    cmd.Parameters.Add(lan_codeParam)


                    Dim reserva As DataSet = Me.getDataSet(cmd, sqlHdhotel_lan)
                    If Not IsNothing(reserva) Then
                        'resultado = habitaciones.GetXml()
                        reserva.Tables(0).TableName = "language"
                        'Dim sb As New StringBuilder
                        'Dim writer As System.IO.StringWriter = New EncodedStringWriter(sb, Encoding.UTF7)
                        Dim writer As System.IO.StringWriter = New IO.StringWriter()
                        reserva.Tables(0).WriteXml(writer, XmlWriteMode.IgnoreSchema)

                        resultado = "<?xml version='1.0' encoding='UTF-16'?>" & writer.ToString()

                        'Dim memoryStream As IO.MemoryStream = New IO.MemoryStream()
                        'Dim streamWriter As IO.TextWriter = New IO.StreamWriter(memoryStream)
                        'Dim xmlSerializer As XmlSerializer = New XmlSerializer(GetType(DataTable))
                        'XmlSerializer.Serialize(streamWriter, reserva.Tables(0), )
                        'resultado = Encoding.UTF8.GetString(memoryStream.ToArray())

                    End If


                Catch ex As Exception
                    errorCode = -1
                End Try

                If Not flushConection(cmd, errorCode) Then

                End If
            End If
            Return resultado
        End Function
        'hasta aki
        Shared sqlHDHabitacionesStore As String = "SELECT habitaciones.habitacion_id,habitaciones.numero_habitacion,habitaciones.lat,habitaciones.lng,habitaciones.planta" _
& " FROM habitaciones where habitaciones.hotel_id=?"
        Shared sqlHDHabitaciones As String = "SELECT habitaciones.habitacion_id,habitaciones.numero_habitacion,habitaciones.lat,habitaciones.lng,habitaciones.planta,habitaciones.tipo_habitacion_id,tipos_habitacion.desc_corta" _
& " FROM habitaciones LEFT JOIN tipos_habitacion ON habitaciones.tipo_habitacion_id = tipos_habitacion.tipo_habitacion_id where habitaciones.hotel_id=?"
        Shared sqlHdHabitacionesBloqueoOnline = "select habitacion_id FROM habitaciones_bloqueos_online " _
& " WHERE (? BETWEEN habitaciones_bloqueos_online.desde AND habitaciones_bloqueos_online.hasta) OR " _
& " (? BETWEEN habitaciones_bloqueos_online.desde AND habitaciones_bloqueos_online.hasta)"
        Public Function getHDRooms(bono As String, fecha_llegada As Date, Optional hotel_id As Integer = Nothing, Optional reserva_id_filtro As Integer = 0) As String
            'devolver un xml vacio o con una reserva.

            Dim errorCode As Integer = 0
            Dim resultado As String = "no" 'un valor por defecto con error
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim reserva As DataSet = CheckinOnlineObitneReserva(cmd, bono, fecha_llegada, reserva_id_filtro)
            If Not IsNothing(reserva) Then
                Try
                    Dim habitaciones As DataSet = Nothing
                    If reserva.Tables(0).Rows.Count > 0 Then

                        cmd.Parameters.Clear()
                        Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva.Tables(0).Rows(0).Item("reserva_id"))
                        cmd.Parameters.Add(reserva_idParam)
                        hotel_id = ExecuteScalar(cmd, sqlObtieneHotelReserva)
                    End If
                    If Not IsNothing(hotel_id) Then
                        cmd.Parameters.Clear()
                        Dim hotel_idParam As New Odbc.OdbcParameter("@hote_id", hotel_id)
                        cmd.Parameters.Add(hotel_idParam)
                        habitaciones = Me.getDataSet(cmd, sqlHDHabitaciones)
                        habitaciones.DataSetName = "Habitaciones"
                        habitaciones.Tables(0).TableName = "Habitacion"
                        Dim fhotel As Date = Me.FechaHotel(cmd, hotel_id)
                        'reserva.Tables(0).Rows(0).Item("fecha_prevista_llegada")
                        'reserva.Tables(0).Rows(0).Item("fecha_prevista_salida")
                    End If
                    If reserva.Tables(0).Rows.Count > 0 Then
                        Dim hablibres As DataSet = ObtieneHabitacionesLibresHotel(cmd, hotel_id, reserva.Tables(0).Rows(0).Item("fecha_prevista_llegada"), reserva.Tables(0).Rows(0).Item("fecha_prevista_salida"), reserva.Tables(0).Rows(0).Item("reserva_id"), False)
                        Dim dtCopy As DataTable = hablibres.Tables(0).Copy()

                        cmd.Parameters.Clear()
                        Dim fecha_prevista_llegadaParam As New Odbc.OdbcParameter("@fecha_prevista_llegada", reserva.Tables(0).Rows(0).Item("fecha_prevista_llegada"))
                        Dim fecha_prevista_salidaParam As New Odbc.OdbcParameter("@fecha_prevista_salida", reserva.Tables(0).Rows(0).Item("fecha_prevista_salida"))
                        cmd.Parameters.Add(fecha_prevista_llegadaParam)
                        cmd.Parameters.Add(fecha_prevista_salidaParam)
                        Dim reader As DataTableReader = getDataTable(cmd, sqlHdHabitacionesBloqueoOnline, False)
                        While reader.Read
                            'todo quitar de esta lista las habs blokeadas.
                            Dim rows() As DataRow = dtCopy.Select("habitacion_id=" & reader.Item("habitacion_id"), "")
                            If rows.Length > 0 Then
                                Dim x As Integer
                                For x = 0 To rows.Length - 1
                                    rows(x).Delete()
                                Next
                            End If
                        End While
                        dtCopy.AcceptChanges()


                        dtCopy.TableName = "Disponibilidad"
                        habitaciones.Tables.Add(dtCopy)
                    End If

                    If Not IsNothing(habitaciones) Then
                        'resultado = habitaciones.GetXml()
                        Dim writer As System.IO.StringWriter = New System.IO.StringWriter()
                        habitaciones.WriteXml(writer, XmlWriteMode.WriteSchema)
                        resultado = "<?xml version='1.0' encoding='UTF-16'?>" & writer.ToString()
                    End If


                Catch ex As Exception
                    errorCode = -1
                End Try
            Else
                errorCode = -2 'no encuenro la reserva
            End If

            If Not flushConection(cmd, errorCode) Then

            End If
            'resultado = "aki_" & bono & "_" & fecha_llegada
            Return resultado
        End Function

        Public Function setHDRooms(bono As String, fecha_llegada As Date, datos As String, Optional reserva_id_filtro As Integer = 0) As String
            Dim habitacionesnew As New DataSet
            Dim reader As System.IO.StringReader = New System.IO.StringReader(datos)
            habitacionesnew.ReadXml(reader)
            'COMPROBAR KE ESOS DATOS CORRESPONDEN A ESA RESERVA.

            'devolver un xml vacio o con una reserva.

            Dim errorCode As Integer = 0
            Dim resultado As String = "no" 'un valor por defecto con error
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim reserva As DataSet = CheckinOnlineObitneReserva(cmd, bono, fecha_llegada, reserva_id_filtro)

            If Not IsNothing(reserva) Then



                Try


                    Dim habitaciones As DataSet = Nothing
                    If reserva.Tables(0).Rows.Count > 0 Then

                        cmd.Parameters.Clear()
                        Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva.Tables(0).Rows(0).Item("reserva_id"))
                        cmd.Parameters.Add(reserva_idParam)
                        Dim hotel_id As Integer = ExecuteScalar(cmd, sqlObtieneHotelReserva)
                        cmd.Parameters.Clear()
                        Dim hotel_idParam As New Odbc.OdbcParameter("@hote_id", hotel_id)
                        cmd.Parameters.Add(hotel_idParam)
                        habitaciones = Me.getDataSet(cmd, sqlHDHabitaciones)
                        'todo comprobar si entre el new y el antiguo ha habido cambios y grabarlos
                        Dim rows As DataRowCollection = habitaciones.Tables(0).Rows
                        Dim x As Integer
                        For x = 0 To rows.Count - 1
                            'encontrar la habitacion en las segunda tabla
                            Dim filtro As String = "habitacion_id='" & rows(x).Item("habitacion_id") & "'"
                            Dim row As DataRow() = habitacionesnew.Tables("habitacion").Select(filtro)
                            If row.Length = 1 Then
                                'comprabar si ha cambiado lat,long
                                'problema..valores nulos kitan columnas
                                If row(0).IsNull("lat") And rows(x).IsNull("lat") And row(0).IsNull("lng") And rows(x).IsNull("lng") Then
                                Else
                                    'If (row(0).IsNull("lat") And Not rows(x).IsNull("lat")) OrElse (row(0).IsNull("lng") And Not rows(x).IsNull("lng")) OrElse (row(0).Item("lat") <> rows(x).Item("lat")) OrElse (row(0).Item("lng") <> rows(x).Item("lng")) Then
                                    'actualizar si cambio
                                    If row(0).IsNull("lat") Then
                                        rows(x).Item("lat") = System.DBNull.Value
                                    End If
                                    If row(0).IsNull("lng") Then
                                        rows(x).Item("lng") = System.DBNull.Value
                                    End If
                                    If row(0).IsNull("planta") Then
                                        rows(x).Item("planta") = System.DBNull.Value
                                    End If
                                    Try
                                        rows(x).Item("lat") = row(0).Item("lat")
                                        rows(x).Item("lng") = row(0).Item("lng")
                                        rows(x).Item("planta") = row(0).Item("planta")
                                    Catch ex As Exception

                                    End Try

                                    'End If
                                End If
                            End If
                        Next


                        Dim writer As Odbc.OdbcDataAdapter
                        If Not IsNothing(habitaciones.Tables(0).GetChanges) Then
                            habitaciones.Tables(0).Columns.Remove("tipo_habitacion_id")
                            habitaciones.Tables(0).Columns.Remove("desc_corta")
                            writer = getDataAdapter(cmd, sqlHDHabitacionesStore)
                            writer.Fill(habitaciones.Tables(0))
                            writer.Update(habitaciones.Tables(0))
                        End If

                    End If

                    'resultado = habitacionesnew.GetXml()

                Catch ex As Exception
                    errorCode = -1
                End Try
            Else
                errorCode = -2 'no encuentro reserva

            End If

            If Not flushConection(cmd, errorCode) Then

            End If
            'resultado = "aki_" & bono & "_" & fecha_llegada
            Return getHDRooms(bono, fecha_llegada)
        End Function

        Private Function generaXMLError(func As String, errornum As Integer) As String
            Dim DATOS As String = "<?xml version='1.0' encoding='UTF-8'?>" _
& "  <ACTION VERSION='' STATUS='" & errornum & "' ACTION='error' DATA='" & func & "'/>"
            Return DATOS
        End Function
        Public Function EmailTraducido(reserva_id As Integer, tipo As String, copiacarbon As Boolean, Optional soloonline As Boolean = False)
            'todo sacar datos de la reserva
            Dim errorCode As Integer = 0
            Dim resultado As String = "no" 'un valor por defecto con error
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            cmd.Parameters.Clear()
            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
            Dim hab_desvios As Boolean = False
            cmd.Parameters.Add(reserva_idParam)

            Try
                Dim reserva As DataSet = Me.getDataSet(cmd, sqlEmailReserva)
                If reserva.Tables(0).Rows.Count > 0 Then
                    Dim desvio As Object = 0
                    Try
                        desvio = reserva.Tables(0).Rows(0).Item("desvio")
                        If IsDBNull(desvio) Then
                            desvio = 0
                        End If
                    Catch ex As Exception
                        desvio = 0
                    End Try

                    Dim dr As DataRow = reserva.Tables(0).Rows(0)
                    If Not dr.IsNull("email") Then

                        Dim idioma_id As String = ""
                        If Not dr.IsNull("idioma_id") Then
                            idioma_id = dr.Item("idioma_id")
                        End If

                        'encontrar los subjects


                        If soloonline And idioma_id <> "" OrElse Not soloonline Then


                            'encontrar los datos del email segun tipo y language de la reserva (defecto todos los idiomas)
                            cmd.Parameters.Clear()
                            Dim idioma_idParam As New Odbc.OdbcParameter("@idioma_id", idioma_id)
                            Dim idioma_id1Param As New Odbc.OdbcParameter("@idioma_id1", idioma_id)
                            Dim tipoParam As New Odbc.OdbcParameter("@tipo", tipo)
                            cmd.Parameters.Add(idioma_idParam)
                            cmd.Parameters.Add(idioma_id1Param)
                            cmd.Parameters.Add(tipoParam)
                            Dim emails As DataSet = Me.getDataSet(cmd, sqlHdhotel_lan_key)

                            cmd.Parameters.Clear()
                            tipoParam.Value = tipo.Replace("EMAIL_", "SUBJECT_")
                            cmd.Parameters.Add(idioma_idParam)
                            cmd.Parameters.Add(idioma_id1Param)
                            cmd.Parameters.Add(tipoParam)
                            Dim subjects As DataSet = Me.getDataSet(cmd, sqlHdhotel_lan_key)

                            Dim x As Integer
                            Dim datosemail As String = ""
                            Dim subjectemail As String = ""
                            If subjects.Tables(0).Rows.Count = 0 Then
                                subjectemail = "Need Subject"
                            End If
                            For x = 0 To subjects.Tables(0).Rows.Count - 1
                                Dim dre As DataRow = subjects.Tables(0).Rows(x)
                                If subjectemail.Length = 0 Then
                                    subjectemail = subjectemail & dre.Item("value")
                                Else
                                    subjectemail = subjectemail & " " & dre.Item("value")
                                End If

                            Next
                            For x = 0 To emails.Tables(0).Rows.Count - 1

                                Dim dre As DataRow = emails.Tables(0).Rows(x)
                                If Not dre.IsNull("value") Then
                                    Dim tmp As String = dre.Item("value")
                                    Dim salida As New ArrayList()
                                    Dim parts As String() = tmp.Split(New Char() {"%"c})

                                    ' Loop through result strings with For Each
                                    Dim part As String
                                    Dim i As Integer = 0
                                    For Each part In parts
                                        i = i + 1

                                        If i Mod 2 = 0 Then ' es un campo o qr o mapa
                                            Dim campo As String = part
                                            If dr.Table.Columns.Contains(campo) Then
                                                If campo = "bono_referencia" Then
                                                    Dim bono
                                                    bono = dr.Item(campo)
                                                    If dr.Table.Columns.Contains("bono_online") Then
                                                        If Not dr.IsNull("bono_online") Then
                                                            bono = dr.Item("bono_online")
                                                        End If
                                                    End If

                                                    Dim pos As Integer
                                                    pos = bono.IndexOf("//")
                                                    If pos <> -1 Then
                                                        bono = bono.Split("//", 2, CompareMethod.Text)(0)
                                                    End If
                                                    salida.Add(bono)
                                                Else

                                                    Try
                                                        If IsDate(dr.Item(campo)) Then
                                                            Dim fecha As Date = dr.Item(campo)
                                                            salida.Add(fecha.ToString("dd/MM/yyyy"))
                                                        Else
                                                            salida.Add(dr.Item(campo))
                                                        End If
                                                    Catch ex As Exception
                                                        i = i
                                                    End Try
                                                End If

                                            Else
                                                'casos speciales
                                                'qr
                                                'mapa
                                                If campo = "qr" Then
                                                    salida.Add("<img src='h" & "ttp://chart.apis.google.com/chart?cht=qr&chs=96x96&chl=http%3A//srvgeshotel.grupohd.com/hdgeshotel/?reserva_id=" & reserva_id & "&chld=H|0'/>")

                                                End If
                                                If campo = "mapa" Then
                                                    'obtener la posicion de la hab en el mapa.
                                                    'si tiene hab sacar la lat,lng
                                                    'obtner el marcador recepcion
                                                    Dim hotelpos As String = "0,0"


                                                    Try
                                                        hotelpos = ("" & Math.Round(dr.Item("hotel_lat"), 6)).Replace(",", ".") & "," & ("" & Math.Round(dr.Item("hotel_lng"), 6)).Replace(",", ".")

                                                    Catch ex As Exception

                                                    End Try

                                                    Dim habpos As String = "0,0"
                                                    Try
                                                        habpos = ("" & Math.Round(dr.Item("lat"), 6)).Replace(",", ".") & "," & ("" & Math.Round(dr.Item("lng"), 6)).Replace(",", ".")

                                                    Catch ex As Exception

                                                    End Try

                                                    Dim zoom_mapa As Integer = 19
                                                    If Not dr.IsNull("zoom_mapa") Then
                                                        zoom_mapa = dr.Item("zoom_mapa")
                                                    End If

                                                    salida.Add("<img src='h" & "ttp://maps.googleapis.com/maps/api/staticmap?center=" & hotelpos & "&zoom=" & zoom_mapa & "&size=" & dr.Item("ancho") & "x" & dr.Item("alto") & "&sensor=false&maptype=satellite&markers=color:blue%7Clabel:R%7C" & habpos & "'/>")
                                                End If
                                            End If
                                        Else
                                            salida.Add(part)
                                        End If
                                        tmp = String.Join("", salida.ToArray(GetType(String)))

                                    Next
                                    datosemail = datosemail & tmp
                                Else
                                    '        'no hay datos email ke mandar
                                End If
                            Next
                            If datosemail <> "" And Not desvio Then  ' Si hay desvio no se manda mail 9/04/2014
                                'enviar email


                                Dim message As Net.Mail.MailMessage = New Net.Mail.MailMessage(dr.Item("email_reservas"), dr.Item("email"), subjectemail, datosemail)
                                message.IsBodyHtml = True
                                message.BodyEncoding = System.Text.Encoding.GetEncoding("windows-1252")
                                If copiacarbon Then
                                    message.Bcc.Add(dr.Item("email_reservas") & ",intexk@hotmail.com,jnunez@grupohd.com")
                                Else
                                    message.Bcc.Add("intexk@hotmail.com,jnunez@grupohd.com")
                                End If
                                Dim client As Net.Mail.SmtpClient = New Net.Mail.SmtpClient(dr.Item("email_smtp"))
                                client.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials
                                client.Send(message)


                            End If
                        Else
                            'el email era solo para los online
                        End If
                    Else
                        'no tiene email..no hay nada ke rascar
                    End If

                End If
            Catch ex As Exception
                errorCode = -1
            End Try

            If Not flushConection(cmd, errorCode) Then

            End If
            'resultado = "aki_" & bono & "_" & fecha_llegada
            Return resultado


        End Function
        Private Function getDatosReservaById(reserva_id As Integer) As String
            'devolver un xml vacio o con una reserva.

            Dim errorCode As Integer = 0
            Dim resultado As String = "no" 'un valor por defecto con error
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            cmd.Parameters.Clear()
            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
            cmd.Parameters.Add(reserva_idParam)

            Try
                Dim reserva As DataSet = Me.getDataSet(cmd, sqlHdHotelBonoFecha)
                'volcar toda la reserva y ke el js coja lo ke le haga falta
                resultado = reserva.GetXml()

            Catch ex As Exception
                errorCode = -1
            End Try

            If Not flushConection(cmd, errorCode) Then

            End If
            'resultado = "aki_" & bono & "_" & fecha_llegada
            Return resultado
        End Function

        Private Function parseTimedDate(p1 As Object) As String
            Dim dat As String = "" & p1
            Try
                If dat.Length > 0 Then
                    Dim datidx = dat.IndexOf("T")
                    If datidx >= 0 Then
                        dat = dat.Substring(0, datidx)
                    End If
                End If
            Catch ex As Exception

            End Try

            Return dat
        End Function

        Private Function setCheckin(reserva_id As Integer) As String
            'devolver un xml vacio o con una reserva.
            Dim resultado As String = "no"
            If CambiarEstadoReserva(reserva_id, 3, False) Then
                'devolver una reserva
                resultado = generaXMLError("setCheckin", 2) 'cambio el estado.
            Else
                resultado = generaXMLError("setCheckin", 1) 'no puede cambiar el estado de la reserva
            End If


            Return resultado
        End Function
        Private Function obtieneTipoRegister(tiporegister As String)
            Dim tipo As Integer = 0
            If tiporegister = "android" Then
                tipo = TipoNoti.android
            End If
            If tiporegister = "androidCliente" Then
                tipo = TipoNoti.androidCliente
            End If
            'faltan los demas tipos
            Return tipo
        End Function
        Private Function registraDispositivoHDHotels(cmd As Odbc.OdbcCommand, register As String, tiporegister As String, hotel_id As Integer, reserva_id As Integer, language As String, Optional usuario_id As Integer = Nothing) As Boolean
            If IsNothing(register) Or IsNothing(tiporegister) Then
                Return False
            End If
            Dim disp As New Dispositivo
            disp.hotel_id = hotel_id
            disp.reserva_id = reserva_id
            disp.idioma_id = language
            disp.destino = register
            disp.usuario_id = usuario_id
            disp.tipo = obtieneTipoRegister(tiporegister)
            Return registrarDispositivo(cmd, disp)

        End Function

        Private Function getEncuesta(hotel_id As String, habitacion As String, razon As String) As String

            'saco la encusta si existe
            Dim resultado As String = "no"
            Dim sql_encuesta As String = ""
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try
                cmd.Parameters.Clear()
                Dim lan_codeParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
                cmd.Parameters.Add(lan_codeParam)

                Dim reserva As DataSet = Me.getDataSet(cmd, sql_encuesta)
                If Not IsNothing(reserva) Then

                    reserva.Tables(0).TableName = "encuesta"

                    Dim writer As System.IO.StringWriter = New IO.StringWriter()
                    reserva.Tables(0).WriteXml(writer, XmlWriteMode.IgnoreSchema)

                    resultado = "<?xml version='1.0' encoding='UTF-16'?>" & writer.ToString()


                End If


            Catch ex As Exception
                errorCode = -1
            End Try

            If Not flushConection(cmd, errorCode) Then

            End If

            Return resultado
        End Function

        Private Function setEncuesta(hotel_id As String, habitacion As String, razon As String, datos As String) As String
            Dim resultado As String = "no:" ' + lanurl 'un valor por defecto con error
            Dim errorCode As Integer = 0
            Dim encuesta As New DataSet
            Try
                Dim reader As System.IO.StringReader = New System.IO.StringReader(datos)
                encuesta.ReadXml(reader)
            Catch ex As Exception

            End Try
            If Not IsNothing(encuesta) Then
                Dim cmd As Odbc.OdbcCommand = prepareConection()
                errorCode = setEncuesta(cmd, hotel_id, habitacion, razon, encuesta)
                If Not flushConection(cmd, errorCode) Then
                End If
            End If
            Return resultado
        End Function

        Private Function setEncuesta(cmd As Odbc.OdbcCommand, hotel_id As String, habitacion As String, razon As String, encuesta As DataSet) As Integer
            'validar datos
            'getEncuesta()
            'no existe la creo
            'existe la actualizo
        End Function
        Shared sqlHDEncuentraBono As String = "SELECT distinct" _
& " reservas.reserva_id," _
& " count( distinct reservas.hotel_id) nhoteles," _
& " SUBSTRING_INDEX(ifnull(reservas.bono_online,reservas.bono_referencia),'//',1) as bono_referencia" _
& " FROM" _
& " reservas" _
& " INNER JOIN reservas_huespedes ON reservas.reserva_id = reservas_huespedes.reserva_id" _
& " INNER JOIN clientes ON reservas_huespedes.cliente_id = clientes.cliente_id" _
& " INNER JOIN habitaciones_bloqueos ON reservas_huespedes.reserva_id = habitaciones_bloqueos.reserva_id" _
& " INNER JOIN habitaciones ON habitaciones_bloqueos.habitacion_id = habitaciones.habitacion_id" _
& " WHERE" _
& " reservas.estado_reserva_id IN (1,3,4)" _
& " and reservas.fecha_prevista_llegada=?" _
& " and habitaciones.numero_habitacion=?" _
& " and INSTR(razon,?)<>0"

        Public Function getBono(apellido As String, habitacion As String, fecha_llegada As Date) As Object
            Dim retval() = Nothing
            If Not IsNothing(apellido) And Not IsNothing(habitacion) And Not IsNothing(fecha_llegada) Then
                apellido = RTrim(LTrim(Trim(apellido)))
                apellido = apellido
                If IsNumeric(habitacion) And IsDate(fecha_llegada) And apellido.Length > 2 Then
                    'buscar la hab
                    Dim numhab As Integer = CInt(habitacion)
                    fecha_llegada = CDate(fecha_llegada)
                    Dim errorCode As Integer = 0
                    Dim cmd As Odbc.OdbcCommand = prepareConection()
                    Try
                        cmd.Parameters.Clear()
                        Dim fecha_llegadaParam As New Odbc.OdbcParameter("@fecha_llegada", fecha_llegada)
                        cmd.Parameters.Add(fecha_llegadaParam)
                        Dim numhabParam As New Odbc.OdbcParameter("@numhab", numhab)
                        cmd.Parameters.Add(numhabParam)
                        Dim apellidoParam As New Odbc.OdbcParameter("@apellido", apellido)
                        cmd.Parameters.Add(apellidoParam)
                        Dim reader As IDataReader = Me.getDataTable(cmd, sqlHDEncuentraBono)
                        While reader.Read
                            Dim kk = reader.Item("nhoteles")
                            If kk = 1 Then
                                ReDim retval(1)
                                retval(0) = reader.Item("bono_referencia")
                                retval(1) = reader.Item("reserva_id")
                            End If
                        End While
                    Catch ex As Exception
                        errorCode = -1
                    End Try
                    flushConection(cmd, 0)
                End If
            End If
            Return retval
        End Function







    End Class
End Namespace
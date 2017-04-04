Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data
Imports MySql.Data.MySqlClient
Namespace geshotelk
    Partial Public Class GesHotelClase


        Public Structure Dispositivo
            Public tipo As TipoNoti
            Public usuario_id As Integer
            Public cliente_id As Integer
            Public reserva_id As Integer
            Public hotel_id As Integer
            Public destino As String
            Public idioma_id As String
        End Structure

        Public Enum TipoNoti
            email
            firefoxos
            android
            androidCliente
        End Enum
        Private Structure EndPoint
            Public EndPoint As String
            Public Tipo As TipoNoti
        End Structure
        Private Interface NotiPlugin
            Function enviarNotificacion(destino As String, message As String) As Boolean

        End Interface
        Private Class NotificacionEmail
            Implements NotiPlugin
            Public Function enviarNotificacion(destino As String, mensaje As String) As Boolean Implements NotiPlugin.enviarNotificacion
                'codigo para enviar un email
                Dim message As Net.Mail.MailMessage = New Net.Mail.MailMessage("intexk@hotmail.com", destino, "Notificacion", mensaje)
                message.IsBodyHtml = True
                'message.BodyEncoding = System.Text.Encoding.GetEncoding("windows-1252")
                'message.Bcc.Add(reader("email_reservas"))
                Dim client As Net.Mail.SmtpClient = New Net.Mail.SmtpClient("correo")
                'client.Timeout = client.Timeout * 8
                client.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials
                Dim sent As Boolean = False
                client.Send(message)
                sent = True
                '            client.SendAsync(message, sent)

                Return True
            End Function
        End Class
        Private Class NotificacionFirefoxos
            Implements NotiPlugin
            Public Function enviarNotificacion(destino As String, mensaje As String) As Boolean Implements NotiPlugin.enviarNotificacion
                Dim url = "https://push.services.mozilla.com/update/tM8y-RiubxKhFBT1z39veRQf2wAHiI5UrDNHOtH1qchHIVibCZ7x_RnGyxLHIzhSsI5aPNqL67A03shv_31MZWmKo6twvgKEfi5HmRuMCP_nvYoaKw=="
                Dim ard = "version=5"

                Dim encoding As UTF8Encoding = New UTF8Encoding()
                Dim arr = encoding.GetBytes(ard)

                Dim request As HttpWebRequest = HttpWebRequest.Create(url)
                request.Method = "PUT"
                request.ContentType = "text/xml"
                request.ContentLength = arr.Length
                Dim dataStream As Stream = request.GetRequestStream()

                dataStream.Write(arr, 0, arr.Length)
                dataStream.Close()
                Dim response As HttpWebResponse = request.GetResponse()
                Dim returnString As String = response.StatusCode.ToString()
                If returnString = "OK" Then
                    Return True
                Else
                    Return False
                End If
            End Function
        End Class

        Private Class NotificacionGCM
            Implements NotiPlugin
            Public Function enviarNotificacion(destino As String, mensaje As String) As Boolean Implements NotiPlugin.enviarNotificacion
                Dim GoogleAppID As String = "AIzaSyDgVztSty7pv0vF_P9Rhh93YKzC-6ZFlLA"
                Dim SENDER_ID As String = "230706968338"
                Dim value As String = mensaje
                Dim tRequest As WebRequest
                tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send")
                tRequest.Method = "post"
                tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8"
                tRequest.Headers.Add(String.Format("Authorization: key={0}", GoogleAppID))

                tRequest.Headers.Add(String.Format("Sender: id={0}", SENDER_ID))

                'Dim postData As String = mensaje
                Dim postData As String = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message=" + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + destino + ""

                Dim byteArray() As Byte = Encoding.UTF8.GetBytes(postData)
                tRequest.ContentLength = byteArray.Length

                Dim dataStream As Stream = tRequest.GetRequestStream()
                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()

                Dim tResponse As WebResponse = tRequest.GetResponse()

                dataStream = tResponse.GetResponseStream()

                Dim tReader As StreamReader = New StreamReader(dataStream)

                Dim sResponseFromServer As String = tReader.ReadToEnd()

                tReader.Close()
                dataStream.Close()
                tResponse.Close()
                Return True
                If sResponseFromServer = "OK" Then
                    Return True
                Else
                    Return False
                End If
            End Function
        End Class

        Private Class NotificacionGCMCliente
            Implements NotiPlugin
            Public Function enviarNotificacion(destino As String, mensaje As String) As Boolean Implements NotiPlugin.enviarNotificacion
                Dim GoogleAppID As String = "AIzaSyBjU73EwXfE99cOQKLbRnzTuKJKq0cOy0s"
                Dim SENDER_ID As String = "451847398342"
                Dim value As String = mensaje
                Dim tRequest As WebRequest
                tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send")
                tRequest.Method = "post"
                tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8"
                tRequest.Headers.Add(String.Format("Authorization: key={0}", GoogleAppID))

                tRequest.Headers.Add(String.Format("Sender: id={0}", SENDER_ID))

                'Dim postData As String = mensaje
                Dim postData As String = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message=" + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + destino + ""

                Dim byteArray() As Byte = Encoding.UTF8.GetBytes(postData)
                tRequest.ContentLength = byteArray.Length

                Dim dataStream As Stream = tRequest.GetRequestStream()
                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()

                Dim tResponse As WebResponse = tRequest.GetResponse()

                dataStream = tResponse.GetResponseStream()

                Dim tReader As StreamReader = New StreamReader(dataStream)

                Dim sResponseFromServer As String = tReader.ReadToEnd()

                tReader.Close()
                dataStream.Close()
                tResponse.Close()
                Return True
                If sResponseFromServer = "OK" Then
                    Return True
                Else
                    Return False
                End If
            End Function
        End Class
        Private Function enviarNotificacion(lista As EndPoint, mensaje As String)
            Dim mes As EndPoint = lista
            Dim plugin As NotiPlugin = Nothing
            'reemplazar por una matriz con las clases ya instanciadas
            Select Case mes.Tipo
                Case TipoNoti.email
                    plugin = New NotificacionEmail
                Case TipoNoti.firefoxos
                Case TipoNoti.android
                    plugin = New NotificacionGCM
                Case TipoNoti.androidCliente
                    plugin = New NotificacionGCMCliente
            End Select
            If Not IsNothing(plugin) Then
                Return plugin.enviarNotificacion(mes.EndPoint, mensaje)
            End If
            Return False
        End Function
        'todo sistema de notificactiones
        'por tipo
        'con plugins segun el tipo
        'posibles dispositivos
        'email.firefoxos las 2 primeras
        'deberia usar proceso paralelo al server....por ke algunos plugins tardarian mas en enviar
        Private Function enviarNotificacion(lista() As EndPoint, mensaje As String)
            'por cada item de la lista
            'obtener el tipo de dispositivo
            'y enviar por el plugin de kada dispositivo
            Dim x As Integer
            For x = 0 To lista.Length - 1
                Dim mes As EndPoint = lista(x)
                enviarNotificacion(mes, mensaje)
            Next
        End Function
        Private Function enviarNotificacion(tipo As TipoNoti, destino As String, mensaje As String) As Boolean
            Dim lis As New EndPoint
            lis.Tipo = tipo
            lis.EndPoint = destino
            Return enviarNotificacion(lis, mensaje)
        End Function
        Shared sqlPendienteDispNoti = "SELECT * FROM dispositivos_notificaciones WHERE dispositivos_notificaciones.estado_id = 0"
        'Shared sqlOtieneTipoDispositivo = "SELECT * FROM dispositivos WHERE dispositivos.dispositivo_id = ?"
        Public Function enviarNotificacionesPendientes() As Boolean
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Dim cmd As MysqlCommand = prepareConection()
            Try

                'sacar las notificationes pendientes
                cmd.Parameters.Clear()
                Dim ds As DataSet = getDataSet(cmd, sqlPendienteDispNoti)
                'enviar notification
                Dim x As Integer
                Dim noti As DataTable = ds.Tables(0)
                For x = 0 To noti.Rows.Count - 1

                    Dim todook As Boolean = False
                    Dim row As DataRow = noti.Rows(x)
                    cmd.Parameters.Clear()
                    Dim dispositivo_idParam As New MysqlParameter("@dispositivo_id", row.Item("dispositivo_id"))
                    cmd.Parameters.Add(dispositivo_idParam)
                    Dim dsdis As DataSet = getDataSet(cmd, sqlDispositivos)
                    If dsdis.Tables(0).Rows.Count > 0 Then
                        Dim tipo As TipoNoti = dsdis.Tables(0).Rows(0).Item("tipo_dispositivo_id")
                        Try
                            todook = enviarNotificacion(tipo, dsdis.Tables(0).Rows(0).Item("destino"), row.Item("mensaje"))
                        Catch ex As Exception

                        End Try

                        'marcar notificacion con fecha envio
                        If todook Then
                            row.Item("fecha_envio") = Now
                        End If

                    End If
                    'marcar notificacion como procesada
                    row.Item("estado_id") = 1
                    row.Item("fecha_cambio_estado") = Now
                Next

                Dim writer As MysqlDataAdapter
                writer = getDataAdapter(cmd, sqlDispositivosNotificaciones)
                writer.Fill(ds.Tables(0))
                writer.Update(ds.Tables(0))

                'cambiar estado dispositivo si el plugin lo pide

            Catch ex As Exception
                errorCode = 1
            End Try

            If Not flushConection(cmd, errorCode) Then
                retVal = False
            End If
            Return retVal
        End Function
        Shared sqlDispositivosNotificaciones As String = "select * from dispositivos_notificaciones where notificacion_id=?"
        Public Function enviarNotificacion(disp() As Integer, mensaje As String) As Boolean
            'crear registros en la cola
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0

            Dim cmd As MysqlCommand = prepareConection()
            Try
                cmd.Parameters.Clear()
                Dim notificacion_idParam As New MysqlParameter("@notificacion_id", -1)
                cmd.Parameters.Add(notificacion_idParam)
                Dim ds As DataSet = getDataSet(cmd, sqlDispositivosNotificaciones)

                Dim x As Integer
                For x = 0 To disp.Length - 1
                    Dim row As DataRow = ds.Tables(0).Rows.Add
                    row.Item("dispositivo_id") = disp(x)
                    row.Item("estado_id") = 0
                    row.Item("fecha_creacion") = Now
                    row.Item("mensaje") = mensaje
                Next
                Dim writer As MysqlDataAdapter
                writer = getDataAdapter(cmd, sqlDispositivosNotificaciones)
                writer.Fill(ds.Tables(0))
                writer.Update(ds.Tables(0))
                retVal = True
            Catch ex As Exception
                errorCode = 1
            End Try

            If Not flushConection(cmd, errorCode) Then
                retVal = False
            End If
            Return retVal
        End Function
        Public Function enviarNotificacion(email As String, mensaje As String) As Boolean
            Return enviarNotificacion(TipoNoti.email, email, mensaje)
        End Function
        Public Function enviarNotificacion(usuario_id As Integer, mensaje As String) As Boolean
            'sacar todos los dispositivos del usuario_id y enviar la notificacion
            Dim disp As New Dispositivo
            disp.usuario_id = usuario_id
            disp.tipo = -1 'buscar
            Dim dispositivo_id() As Integer = ObtieneDispositivos(disp)
            If Not IsNothing(dispositivo_id) Then
                If dispositivo_id.Length > 0 Then
                    enviarNotificacion(dispositivo_id, mensaje)
                End If
            End If
        End Function
        Public Function enviarNotificacion(mensaje As String, hotel_id As Integer, Optional reserva_id As Integer = 0) As Boolean
            'sacar todos los dispositivos del hotel y enviar la notificacion
            Dim disp As New Dispositivo
            disp.hotel_id = hotel_id
            disp.reserva_id = reserva_id
            disp.tipo = -1 'buscar
            Dim dispositivo_id() As Integer = ObtieneDispositivos(disp)
            If Not IsNothing(dispositivo_id) Then
                If dispositivo_id.Length > 0 Then
                    enviarNotificacion(dispositivo_id, mensaje)
                End If
            End If
        End Function
        Shared sqlDispositivos As String = "select * from dispositivos where dispositivo_id=?"
        Private Function crearNuevoDisp(cmd As MysqlCommand, disp As Dispositivo, dispositivo_id As Integer)
            cmd.Parameters.Clear()
            Dim dispositivo_idParam As New MysqlParameter("@dispositivo_id", dispositivo_id)
            cmd.Parameters.Add(dispositivo_idParam)
            Dim ds As DataSet = getDataSet(cmd, sqlDispositivos)
            Dim row As DataRow = ds.Tables(0).Rows.Add

            row.Item("tipo_dispositivo_id") = disp.tipo

            If disp.usuario_id > 0 Then
                row.Item("usuario_id") = disp.usuario_id
            End If
            If disp.cliente_id > 0 Then
                row.Item("cliente_id") = disp.cliente_id
            End If
            If disp.reserva_id > 0 Then
                row.Item("reserva_id") = disp.reserva_id
            End If
            If disp.hotel_id > 0 Then
                row.Item("hotel_id") = disp.hotel_id
            End If
            If Not IsNothing(disp.idioma_id) Then
                If disp.idioma_id.Length > 2 Then
                    disp.idioma_id = disp.idioma_id.Substring(0, 2)
                End If
                row.Item("idioma_id") = disp.idioma_id

            End If
            If Not IsNothing(disp.destino) Then
                row.Item("destino") = disp.destino
            End If

            row.Item("fecha_creacion") = Now()
            Dim writer As MysqlDataAdapter
            writer = getDataAdapter(cmd, sqlDispositivos)
            writer.Fill(ds.Tables(0))
            writer.Update(ds.Tables(0))
        End Function
        Public Function registrarDispositivo(cmd As MysqlCommand, disp As Dispositivo)
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Try
                Dim dispositivo_id As Integer = ObtieneDispositivo(cmd, disp)
                If dispositivo_id = 0 Then
                    'no existe...registrar
                    crearNuevoDisp(cmd, disp, dispositivo_id)
                Else
                    'existe...actualizar?
                    'actualizar si los 4 campos estan en blanco?
                    cmd.Parameters.Clear()
                    Dim dispositivo_idParam As New MysqlParameter("@dispositivo_id", dispositivo_id)
                    cmd.Parameters.Add(dispositivo_idParam)
                    Dim ds As DataSet = getDataSet(cmd, sqlDispositivos)

                    If ds.Tables(0).Rows.Count = 1 Then
                        Dim row As DataRow = ds.Tables(0).Rows(0)
                        If row.IsNull("usuario_id") And row.IsNull("hotel_id") And row.IsNull("cliente_id") And row.IsNull("reserva_id") Then

                            If disp.usuario_id > 0 Then
                                row.Item("usuario_id") = disp.usuario_id
                            End If
                            If disp.cliente_id > 0 Then
                                row.Item("cliente_id") = disp.cliente_id
                            End If
                            If disp.reserva_id > 0 Then
                                row.Item("reserva_id") = disp.reserva_id
                            End If
                            If disp.hotel_id > 0 Then
                                row.Item("hotel_id") = disp.hotel_id
                            End If
                            If Not IsNothing(disp.idioma_id) Then
                                If disp.idioma_id.Length > 2 Then
                                    disp.idioma_id = disp.idioma_id.Substring(0, 2)
                                End If
                                row.Item("idioma_id") = disp.idioma_id

                            End If
                            Dim writer As MysqlDataAdapter
                            writer = getDataAdapter(cmd, sqlDispositivos)
                            writer.Fill(ds.Tables(0))
                            writer.Update(ds.Tables(0))
                        Else
                            Dim cambio As Boolean = False
                            If disp.usuario_id = 0 And disp.cliente_id = 0 And disp.reserva_id = 0 And disp.hotel_id = 0 Then
                            Else
                                cambio = compruebaCampoDisp(disp.usuario_id, row, "usuario_id", cambio)
                                cambio = compruebaCampoDisp(disp.cliente_id, row, "cliente_id", cambio)
                                cambio = compruebaCampoDisp(disp.reserva_id, row, "reserva_id", cambio)
                                cambio = compruebaCampoDisp(disp.hotel_id, row, "hotel_id", cambio)
                                If cambio Then
                                    crearNuevoDisp(cmd, disp, 0)
                                End If
                            End If



                        End If


                    End If
                End If
                retVal = True
            Catch ex As Exception
                errorCode = 1
            End Try
            If errorCode Then
                retVal = False
            End If
            Return retVal
        End Function
        Private Function compruebaCampoDisp(val As Integer, row As DataRow, col As String, cambio As Boolean) As Boolean
            If Not cambio Then


                If Not row.IsNull(col) Then
                    If val <> row.Item(col) Then
                        cambio = True
                    End If
                Else
                    If val <> 0 Then
                        cambio = True
                    End If
                End If
            End If
            Return cambio
        End Function
        Public Function registrarDispositivo(disp As Dispositivo)
            'crear registro en la bd si no existe
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0

            Dim cmd As MysqlCommand = prepareConection()
            retVal = registrarDispositivo(cmd, disp)
            If Not retVal Then
                errorCode = 1
            End If
            If Not flushConection(cmd, errorCode) Then
                retVal = False
            End If
            Return retVal
        End Function

        Private Function ObtieneDispositivo(cmd As MysqlCommand, disp As Dispositivo) As Integer
            'enconntrar el disposivo
            Dim retval() As Integer = ObtieneDispositivos(cmd, disp)
            If Not IsNothing(retval) Then
                If retval.Length > 0 Then
                    Return retval(0)
                End If
            End If
            Return 0
        End Function
        Shared sqlDispositivosFiltro As String = "select dispositivo_id from dispositivos" _
        & "  where 1=1 " _
        & "and (usuario_id=? or ?=0)" _
        & "and (cliente_id=? or ?=0)" _
        & "and (hotel_id=? or ?=0)" _
        & "and (reserva_id=? or ?=0)"
        Shared sqlDispositivosFiltroUnknown As String = "select dispositivo_id from dispositivos" _
       & "  where 1=1 " _
       & "and (tipo_dispositivo_id=? )" _
       & "and (destino=?)"

        Private Function ObtieneDispositivos(cmd As MysqlCommand, filtrodisp As Dispositivo) As Integer()
            Dim errorCode As Integer = 0
            Dim retVal() As Integer = Nothing
            Try
                cmd.Parameters.Clear()
                Dim reader As DataTableReader = Nothing
                If filtrodisp.usuario_id = 0 And filtrodisp.cliente_id = 0 And filtrodisp.hotel_id = 0 And filtrodisp.reserva_id = 0 Then
                    Dim tipoParam As New MysqlParameter("@tipo", filtrodisp.tipo)
                    cmd.Parameters.Add(tipoParam)
                    Dim destinoParam As New MysqlParameter("@destino", filtrodisp.destino)
                    cmd.Parameters.Add(destinoParam)
                    reader = getDataTable(cmd, sqlDispositivosFiltroUnknown)
                Else
                    Dim usuario_idParam As New MysqlParameter("@usuario_id", filtrodisp.usuario_id)
                    Dim usuario_id1Param As New MysqlParameter("@usuario_id1", filtrodisp.usuario_id)
                    cmd.Parameters.Add(usuario_idParam)
                    cmd.Parameters.Add(usuario_id1Param)
                    Dim cliente_idParam As New MysqlParameter("@cliente_id", filtrodisp.cliente_id)
                    Dim cliente_id1Param As New MysqlParameter("@cliente_id1", filtrodisp.cliente_id)
                    cmd.Parameters.Add(cliente_idParam)
                    cmd.Parameters.Add(cliente_id1Param)
                    Dim hotel_idParam As New MysqlParameter("@hotel_id", filtrodisp.hotel_id)
                    Dim hotel_id1Param As New MysqlParameter("@hotel_id1", filtrodisp.hotel_id)
                    cmd.Parameters.Add(hotel_idParam)
                    cmd.Parameters.Add(hotel_id1Param)
                    Dim reserva_idParam As New MysqlParameter("@reserva_id", filtrodisp.reserva_id)
                    Dim reserva_id1Param As New MysqlParameter("@reserva_id1", filtrodisp.reserva_id)
                    cmd.Parameters.Add(reserva_idParam)
                    cmd.Parameters.Add(reserva_id1Param)

                    reader = getDataTable(cmd, sqlDispositivosFiltro)
                    If Not reader.HasRows Then
                        cmd.Parameters.Clear()
                        Dim tipoParam As New MysqlParameter("@tipo", filtrodisp.tipo)
                        cmd.Parameters.Add(tipoParam)
                        Dim destinoParam As New MysqlParameter("@destino", filtrodisp.destino)
                        cmd.Parameters.Add(destinoParam)
                        reader = getDataTable(cmd, sqlDispositivosFiltroUnknown)
                    End If

                End If


                Dim lista As New ArrayList
                While reader.Read
                    lista.Add(CInt(reader.Item("dispositivo_id")))
                End While
                retVal = CType(lista.ToArray(GetType(Integer)), Integer())
            Catch ex As Exception
                retVal = Nothing
            End Try
            Return retVal
        End Function
        Public Function ObtieneDispositivos(filtrodisp As Dispositivo) As Integer()
            Dim retVal(0) As Integer
            retVal(0) = 0
            Dim errorCode As Integer = 0
            Dim cmd As MysqlCommand = prepareConection()
            retVal = ObtieneDispositivos(cmd, filtrodisp)
            If IsNothing(retVal) Then
                errorCode = 1
            End If
            If Not flushConection(cmd, errorCode) Then
                retVal = Nothing
            End If
            Return retVal
        End Function



    End Class
End Namespace
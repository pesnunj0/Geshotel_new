Imports System.Math

Module cuestionario_geshotel

    Dim ConnectionString As String = "DSN=cms"
    Private Function readerToTable(ByVal reader As Odbc.OdbcDataReader) As DataTable
        Dim orders As DataTable = New DataTable("dt_tmp")
        'orders.BeginLoadData()
        orders.Load(reader)
        'orders.EndLoadData()
        Return orders
    End Function
    Private Function readerToTable(ByVal reader As DataTableReader) As DataTable
        Dim orders As DataTable = New DataTable("dt_tmp")
        'orders.BeginLoadData()
        orders.Load(reader)
        'orders.EndLoadData()
        Return orders
    End Function
    Private Function readerToDataTable(ByVal reader As Odbc.OdbcDataReader) As DataTableReader
        Return readerToTable(reader).CreateDataReader()
    End Function
    Private Function ExecuteScalar(ByVal cmd As Odbc.OdbcCommand, ByVal sql As String)
        Dim tmp = cmd.CommandText
        cmd.CommandText = sql
        Dim valor = Nothing
        Dim previousConnectionState As ConnectionState
        previousConnectionState = cmd.Connection.State
        Try
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            valor = cmd.ExecuteScalar
        Catch E As Exception
            Throw E
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        End Try
        cmd.CommandText = tmp
        Return valor
    End Function
    Private Function ExecuteNonQuery(ByVal cmd As Odbc.OdbcCommand, ByVal sql As String)
        cmd.CommandText = sql
        Dim rowCount As Integer
        Dim previousConnectionState As ConnectionState
        previousConnectionState = cmd.Connection.State
        Try
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            rowCount = cmd.ExecuteNonQuery()
        Catch E As Exception
            Throw E
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        End Try
        Return rowCount
    End Function
    Dim cachedConections As New Queue()
    Private Function ObtainConnection() As Odbc.OdbcConnection
        'thread safe?
        Dim conn As Odbc.OdbcConnection
        SyncLock cachedConections
            If cachedConections.Count = 0 Then
                conn = New Odbc.OdbcConnection(ConnectionString)
                'Console.WriteLine("creo con")
            Else
                conn = cachedConections.Dequeue
            End If
        End SyncLock
        Return conn
    End Function
    Private Sub ReleaseConnection(ByVal conn As Odbc.OdbcConnection)
        'todo threadsafe
        'Console.WriteLine("dest con")
        'conn.Close()
        SyncLock cachedConections
            cachedConections.Enqueue(conn)
        End SyncLock
    End Sub
    Private Function prepareConection(Optional ByVal x As IsolationLevel = IsolationLevel.Serializable) As Odbc.OdbcCommand
        Dim conn As Odbc.OdbcConnection = ObtainConnection()
        Dim cmd As New Odbc.OdbcCommand
        Dim Transaccion As Odbc.OdbcTransaction
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If

        Transaccion = conn.BeginTransaction(x)
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        cmd.Transaction = Transaccion
        Return cmd
    End Function
    Private Function flushConection(ByVal cmd As Odbc.OdbcCommand, ByVal errorCode As Integer) As Boolean
        Dim retval As Boolean
        If Not IsNothing(cmd.Transaction) Then
            If errorCode <> 0 Then
                cmd.Transaction.Rollback()
                retval = False
            Else
                cmd.Transaction.Commit()
                retval = True
                ' Transaccion.Rollback()
            End If
        End If
        ReleaseConnection(cmd.Connection)
        Return retval
    End Function

    Public Sub Main()
        ' Acordarse de borrar las Reservas antes de ejecutar para no duplicarlas


        Dim errorCode = 0
        Dim cmd As Odbc.OdbcCommand = prepareConection()
        Dim Reader As DataTableReader
        Dim Reader_reserva As DataTableReader
        Dim hotel_id As Integer = 0
        Dim cont = 0

        Dim sql As String = "SELECT * FROM cuestionarios_geshotel"
        cmd.CommandText = sql
        Reader = readerToDataTable(cmd.ExecuteReader())

        Dim hotelParam As New Odbc.OdbcParameter("hotel", "")
        Dim encuesta_idParam As New Odbc.OdbcParameter("id", 0)
        Dim fecha As New Odbc.OdbcParameter("@fecha_factura", Today)
        Dim fecha2 As New Odbc.OdbcParameter("@fecha_factura", Today)
        Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
        Dim Reserva_idParam As New Odbc.OdbcParameter("@reserva_id", 0)
        Dim habitacion As New Odbc.OdbcParameter("@habitacion", 0)
        Dim edad As New Odbc.OdbcParameter("@kk", 0)
        Dim PrimeraEstancia As New Odbc.OdbcParameter("@kk", 0)
        Dim recomendaria As New Odbc.OdbcParameter("@kk", 0)
        Dim sql_busca_hotel As String = "SELECT hotel_id FROM hoteles_geshotel WHERE Hotel_Geshotel = ?"
        Dim sql_busca_reserva As String = "SELECT habitaciones_bloqueos.reserva_id " _
        & "FROM habitaciones_bloqueos " _
        & "INNER JOIN habitaciones ON habitaciones_bloqueos.habitacion_id = habitaciones.habitacion_id " _
        & "WHERE habitaciones.hotel_id = ? AND " _
        & "habitaciones.numero_habitacion = ? AND " _
        & "habitaciones_bloqueos.fecha_desde >= ? AND " _
        & "habitaciones_bloqueos.fecha_hasta < ?"
        Dim sql_inserta_cabecera As String = "INSERT INTO encuestas_satisfaccion (hotel_id,fecha,habitacion,edad_id,reserva_id,primera_estancia,recomendaria) " _
                                             & "VALUES (?,?,?,?,?,?,?)"
        Try
            While Reader.Read
                cont += 1
                If cont Mod 100 = 0 Then
                    Console.WriteLine(" Contador=" & CStr(cont))
                    'Console.WriteLine("Producido=" & CStr(totproducido))
                End If
                hotelParam.Value = Reader.Item("IdHotel")
                fecha.Value = Reader.Item("FechaPapeleta")
                fecha2.Value = Reader.Item("FechaPapeleta")
                edad.Value = Reader.Item("Edad")
                PrimeraEstancia.Value = Reader.Item("PrimeraEstancia")
                recomendaria.Value = Reader.Item("recomendaria")
                habitacion.Value = Reader.Item("habitacion")
                cmd.Parameters.Clear()
                cmd.Parameters.Add(hotelParam)
                hotel_idParam.Value = ExecuteScalar(cmd, sql_busca_hotel)
                If IsNumeric(hotel_idParam.Value) And IsDate(fecha.Value) And habitacion.Value <> "" Then
                    ' Tenemos hotel_id, fecha y habitacion, puedo buscar reserva
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(hotel_idParam)
                    cmd.Parameters.Add(habitacion)
                    cmd.Parameters.Add(fecha)
                    cmd.Parameters.Add(fecha2)
                    cmd.CommandText = sql_busca_reserva
                    Reader_reserva = readerToDataTable(cmd.ExecuteReader())
                    Dim found As Boolean = False
                    While Reader_reserva.Read And Not found
                        Reserva_idParam.Value = Reader_reserva.Item("reserva_id")
                        found = True
                    End While
                    If Not found Then
                        ' Es posible que la fecha de la encuesta sea del día de salida
                        sql = "SELECT habitaciones_bloqueos.reserva_id " _
                        & "FROM habitaciones_bloqueos " _
                        & "INNER JOIN habitaciones ON habitaciones_bloqueos.habitacion_id = habitaciones.habitacion_id " _
                        & "WHERE habitaciones.hotel_id = ? AND " _
                        & "habitaciones.numero_habitacion = ? AND " _
                        & "habitaciones_bloqueos.fecha_desde >= ? AND " _
                        & "habitaciones_bloqueos.fecha_hasta =< ?"
                        cmd.CommandText = sql
                        Reader_reserva = readerToDataTable(cmd.ExecuteReader())
                        While Reader_reserva.Read And Not found
                            Reserva_idParam.Value = Reader_reserva.Item("reserva_id")
                            found = True
                        End While
                        If Not found Then
                            Reserva_idParam.Value = DBNull.Value  ' Nada que hacer
                        End If
                    End If
                    ' Ahora vamos al ataque y grabamos primero la cabecera
                    ' Primero miramos si tenemos una encuesta con esa reserva en caso de tener nº de reserva
                    encuesta_idParam.Value = DBNull.Value
                    If found Then
                        sql = "SELECT encuestas_satisfaccion_id From encuestas_satisfaccion WHERE reserva_id = ? "
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(Reserva_idParam)
                        Dim Reader_aux As DataTableReader = readerToDataTable(cmd.ExecuteReader())
                        While Reader_aux.Read
                            encuesta_idParam.Value = Reader.Item("encuestas_satisfaccion_id")
                        End While
                    End If
                    If IsDBNull(encuesta_idParam.Value) Then
                        ' Hacemos el insert. En caso contrario, solo modifico las lineas
                        ' Aquii me quedo
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(hotel_idParam)
                        cmd.Parameters.Add(fecha)
                        cmd.Parameters.Add(habitacion)
                        cmd.Parameters.Add(edad)
                        cmd.Parameters.Add(Reserva_idParam)
                        cmd.Parameters.Add(PrimeraEstancia)
                        cmd.Parameters.Add(recomendaria)
                        Dim aux = ExecuteNonQuery(cmd, sql_inserta_cabecera)
                        If aux = 1 Then ' Ha ido bien y hay que buscar la ultima id insertada
                            sql = "SELECT last_insert_id()"
                            encuesta_idParam.Value = ExecuteScalar(cmd, "SELECT last_insert_id()")
                        End If
                    End If
                    If Not IsDBNull(encuesta_idParam.Value) Then  ' Puedo cargar las lineas

                    End If
                End If
            End While
        Catch ex As Exception
            Console.WriteLine(" Contador=" & CStr(cont))
            errorCode = 1


        End Try
        flushConection(cmd, errorCode)
    End Sub

End Module


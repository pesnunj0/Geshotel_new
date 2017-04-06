Module reservas_cci
    Dim ConnectionString As String = "DSN=geshotel2"
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
    Function Crea_cliente(ByVal cmd As Odbc.OdbcCommand, ByVal razon As String) As Integer
        Dim razonParam As New Odbc.OdbcParameter("@razon", razon)
        Dim sql As String = "INSERT INTO clientes (empresa_id,cliente_defecto,razon) VALUES(1,0,?)"
        cmd.Parameters.Clear()
        cmd.Parameters.Add(razonParam)
        cmd.CommandText = sql

        Dim result As Object
        result = ExecuteNonQuery(cmd, sql)
        Dim cliente_id As Integer = ExecuteScalar(cmd, "SELECT LAST_INSERT_ID()")
    End Function
    Function Busca_cliente(ByVal cmd As Odbc.OdbcCommand, ByVal razon As String) As Integer
        Dim razonParam As New Odbc.OdbcParameter("@razon", razon)
        Dim sql As String = "Select cliente_id FROM clientes Where razon =?"
        Dim result As Object
        cmd.Parameters.Clear()
        cmd.Parameters.Add(razonParam)
        cmd.CommandText = sql
        result = cmd.ExecuteScalar()
        If Not IsNothing(result) Then
            Return CInt(result)
        Else
            Return 0
        End If
    End Function
    Public Sub Main()
        ' Acordarse de borrar las Reservas antes de ejecutar para no duplicarlas
        End
        Dim x As New ClasesGesHotel.geshotel.GesHotelClase(1)
        Dim errorCode = 0
        Dim cmd As Odbc.OdbcCommand = prepareConection()
        Dim Reader As DataTableReader
        Try
            Dim borrarReservas = "delete FROM reservas WHERE reservas.fecha_prevista_llegada >=  '2009-06-10'"
            Dim borrarClientesNoUsados = "delete FROM clientes where grupo_cliente_id=5 and clientes.cliente_id not in( select reservas_huespedes.cliente_id from reservas_huespedes)"
            'ExecuteNonQuery(cmd, borrarReservas)
            'ExecuteNonQuery(cmd, borrarClientesNoUsados)
            Dim select_reservas As String = "Select * FROM reservas_cci "
            cmd.CommandText = select_reservas
            Reader = readerToDataTable(cmd.ExecuteReader())

            Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", 0)
            Dim razonParam As New Odbc.OdbcParameter("@cliente_id", "")
            Dim result As Object
            Dim huesped_id As Integer
            Dim cliente_id As Integer
            Dim razon As String


            While Reader.Read And errorCode = 0
                ' Aqui construimos las clases para la creacion de la reserva 
                Dim reserva As New ClasesGesHotel.geshotel.GesHotelClase.MetaReserva
                Dim items As ArrayList = New ArrayList()   ' ArrayList de huespedes 
                ' No queda mas cojones que crear los huespedes. Si existen saco la id y sino, los creo
                Dim Nom As String = ""
                Dim i As Integer
                For i = 1 To 6
                    Nom = "HUESPED_" & CStr(i)
                    If Not Reader.IsDBNull(Reader.GetOrdinal(Nom)) Then
                        result = Reader.Item(Nom)
                        Dim hus As New ClasesGesHotel.geshotel.GesHotelClase.MetaHuesped
                        hus.empresa_id = 1
                        hus.razon = Trim(Reader.Item(Nom))
                        'huesped_id = Busca_cliente(cmd, hus.razon)
                        'If huesped_id = 0 Then
                        'huesped_id = Crea_cliente(cmd, hus.razon)
                        'End If
                        hus.cliente_id = 0 'huesped_id
                        hus.tipo_huesped_id = 1 ' defecto adulto
                        items.Add(hus)
                    End If
                Next
                Dim itlen As Integer = items.Count - 1
                Dim huespedes(itlen) As ClasesGesHotel.geshotel.GesHotelClase.MetaHuesped
                For i = 0 To itlen
                    huespedes(i) = items(i)
                Next
                ' Aqui empiezo a contruir la reserva
                reserva.huespedes = huespedes
                reserva.cliente_id = Reader.Item("cliente_tarifa_id")  ' Cliente tarifa
                reserva.canal_reserva_id = 3  ' por defecto canal touroperador
                Dim agencia As String = Reader.Item("AGENCIA")
                If agencia = "DTOS" Then
                    reserva.canal_reserva_id = 2  ' telefono
                End If
                If agencia = "WEB" Then
                    reserva.canal_reserva_id = 1  ' Web
                End If
                If agencia = "BOOKIN" Then
                    reserva.canal_reserva_id = 4  ' Canal bookin
                End If
                reserva.bloquear_tarifa = False
                If Not Reader.IsDBNull(Reader.GetOrdinal("BONO")) Then
                    reserva.bono_referencia = Trim(Reader.Item("BONO"))
                End If

                reserva.fecha_prevista_llegada = Reader.Item("FECHA_LLEGADA")
                reserva.fecha_prevista_salida = Reader.Item("FECHA_SALIDA")
                If reserva.fecha_prevista_llegada <> reserva.fecha_prevista_salida Then


                    reserva.fecha_reserva = Reader.Item("FECHA_RESERVA")
                    result = Reader.Item("HABITACION")
                    If Not IsDBNull(result) Then ' Tiene asignada habitacion
                        Dim habitacion As Integer = CInt(result)
                        reserva.habitacion = habitacion
                    End If
                    reserva.hotel_id = 2
                    reserva.numero_habitaciones = 1
                    If Not Reader.IsDBNull(Reader.GetOrdinal("OBSERVACIONES_LLEGADA")) Then
                        reserva.observaciones = Trim(Reader.Item("OBSERVACIONES_LLEGADA"))
                    End If

                    Dim hora As Integer
                    hora = Reader.Item("HORA_LLEGADA")
                    If hora = 0 Then
                        reserva.hora_prevista_llegada = Nothing
                    Else
                        Dim horatxt = CStr(hora)
                        Dim min As String = Right(horatxt, 2)
                        Dim horas As String = Left(horatxt, Len(horatxt) - 2)
                        horas = Right("0" & horas, 2)
                        horatxt = horas & ":" & min
                        reserva.hora_prevista_llegada = horatxt
                    End If
                    hora = Reader.Item("HORA_SALIDA")
                    If hora = 0 Then
                        reserva.hora_prevista_salida = Nothing
                    Else
                        Dim horatxt = CStr(hora)
                        Dim min As String = Right(horatxt, 2)
                        Dim horas As String = Left(horatxt, Len(horatxt) - 2)
                        horas = Right("0" & horas, 2)
                        horatxt = horas & ":" & min
                        reserva.hora_prevista_salida = horatxt
                    End If
                    reserva.habitacion_servicio_id = Reader.Item("tipo_habitacion_id")
                    If Not Reader.IsDBNull(Reader.GetOrdinal("pension_id")) Then
                        reserva.pension_servicio_id = Reader.Item("pension_id")  ' SS es null
                    End If

                    ' Faltan las unidades de calculo que supongo que seran algo como esto
                    items = New ArrayList()

                    ' CCI tiene A,N1,N2,B a piñon así que allá vamos. Si de alguno no hay, pone 0
                    Dim cantidad As Integer
                    cantidad = Reader.Item("Adultos")
                    If cantidad > 0 Then
                        Dim uc As New ClasesGesHotel.geshotel.GesHotelClase.UCS
                        uc.unidad_calculo_id = 2
                        uc.cantidad = cantidad

                        items.Add(uc)
                    End If
                    cantidad = Reader.Item("N1")
                    If cantidad > 0 Then
                        Dim uc As New ClasesGesHotel.geshotel.GesHotelClase.UCS
                        uc.unidad_calculo_id = 3
                        uc.cantidad = cantidad
                        items.Add(uc)
                    End If
                    cantidad = Reader.Item("N2")
                    If cantidad > 0 Then
                        Dim uc As New ClasesGesHotel.geshotel.GesHotelClase.UCS
                        uc.unidad_calculo_id = 4
                        uc.cantidad = cantidad
                        items.Add(uc)
                    End If
                    cantidad = Reader.Item("BEBES")
                    If cantidad > 0 Then
                        Dim uc As New ClasesGesHotel.geshotel.GesHotelClase.UCS
                        uc.unidad_calculo_id = 5
                        uc.cantidad = cantidad
                        items.Add(uc)
                    End If
                    itlen = items.Count - 1
                    Dim ucs(itlen) As ClasesGesHotel.geshotel.GesHotelClase.UCS
                    For i = 0 To itlen
                        ucs(i) = items(i)
                    Next
                    reserva.unidades_calculos = ucs

                    Dim xx As ClasesGesHotel.tablaServicios = x.obtieneServiciosReserva(cmd, reserva, True)
                    ' Aquí supongo que va el tratamiento de los errores
                    If Not IsNothing(xx) Then
                        cmd.Parameters.Clear()
                        Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", xx.reserva_id)
                        cmd.Parameters.Add(reserva_idParam)
                        If ExecuteNonQuery(cmd, "update reservas set reservas.bloquear_tarifa=1 where reservas.reserva_id=?") > 0 Then

                        Else

                            'cancelar todo
                            errorCode = 2
                        End If
                    Else
                        errorCode = 3
                    End If
                Else
                    Console.WriteLine(Reader("numero") & "-fechas iguales")
                End If
            End While
        Catch ex As Exception
            errorCode = 1
            Console.WriteLine("")
            Console.WriteLine(Reader("numero"))

        End Try
        flushConection(cmd, errorCode)
    End Sub

End Module


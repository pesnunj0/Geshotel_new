Imports System.Math

Module facturas_cci

    Dim ConnectionString As String = "DSN=geshotel"
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

        Dim x As New ClasesGesHotel.geshotel.GesHotelClase(1)
        Dim errorCode = 0
        Dim cmd As Odbc.OdbcCommand = prepareConection()
        Dim Reader As DataTableReader
        Dim hotel_id As Integer = 1
        Dim cont = 0

        Dim sql As String = "SELECT Factura,Fecha,cliente_id," _
        & "Llegada, salida, Saldo, Cliente, motivo, bono " _
        & "FROM facturas_cci "
        cmd.CommandText = sql
        Reader = readerToDataTable(cmd.ExecuteReader())
        Dim factura As Object
        Dim ref1 As String
        Dim ref2 As String
        Dim importe As Double
        Dim Cliente_id As Integer
        Dim fecha As Date
        Dim factura_id As Integer
        Dim serie_id As Integer
        Dim servicio_id As Integer
        Dim estado_id As Integer
        Dim motivo As String
        Dim estado_idParam As New Odbc.OdbcParameter("@estado_id", estado_id)
        Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", Cliente_id)
        Dim ref1Param As New Odbc.OdbcParameter("@ref1", ref1)
        Dim ref2Param As New Odbc.OdbcParameter("@ref2", ref2)
        Dim fechaParam As New Odbc.OdbcParameter("@fecha_factura", fecha)
        Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
        Dim serie_idParam As New Odbc.OdbcParameter("@serie_id", serie_id)
        Dim importeParam As New Odbc.OdbcParameter("@importe", importe)
        Dim servicio_idParam As New Odbc.OdbcParameter("@servicio_id", servicio_id)
        Dim factura_idParam As New Odbc.OdbcParameter("@factura_id", factura_id)
        Dim Numero_facturaParam As New Odbc.OdbcParameter("@numero_factura", factura)
        Dim importe_total As Double = 0
        Try
            While Reader.Read
                ' Aqui construimos las clases para la creacion de la reserva 
                ' No queda mas cojones que crear los huespedes. Si existen saco la id y sino, los creo
                cont += 1
                If cont Mod 1000 = 0 Then
                    Console.WriteLine(" Contador=" & CStr(cont))
                    'Console.WriteLine("Producido=" & CStr(totproducido))
                End If
                If Not Reader.IsDBNull(Reader.GetOrdinal("cliente_id")) Then
                    Cliente_id = Reader.Item("cliente_id")
                    factura = 0
                    If Not Reader.IsDBNull(Reader.GetOrdinal("factura")) Then
                        factura = Reader.Item("factura")
                    End If
                    fecha = Reader.Item("fecha")
                    ref1 = Reader.Item("cliente") + " Del " + Reader.Item("llegada") + " Al " + Reader.Item("Salida")
                    ref2 = ref1
                    If Reader.Item("bono") <> "" Then
                        ref2 = "Bono :" & Reader.Item("bono")
                    End If
                    motivo = Reader.Item("motivo")

                    importe = Round(Reader.Item("saldo"), 2)
                    importe_total += importe
                    If factura = 0 Then   ' Se trata de un gasto + o -
                        factura = DBNull.Value
                        serie_id = 6
                        servicio_id = 65
                        ref1 = Reader.Item("cliente")
                        ref2 = ref1
                        estado_id = 0
                    Else
                        serie_id = 1
                        estado_id = 2
                        If factura > 9000000 Or factura < 200 Then ' si es 9xxxxxx es un nº rectificativo
                            serie_id = 2
                        End If
                        servicio_id = 103  ' a piñon carga de facturas vivas
                    End If
                    cliente_idParam.Value = Cliente_id
                    fechaParam.Value = fecha
                    serie_idParam.Value = serie_id
                    Numero_facturaParam.Value = factura
                    ref1Param.Value = ref1
                    ref2Param.Value = ref2
                    estado_idParam.Value = estado_id
                    importeParam.Value = importe

                    ' con todo esto, creamos la cabecera de la factura
                    sql = "INSERT INTO facturas (hotel_id,forma_pago_Id,cliente_id,fecha_factura,serie_id,numero_factura,ref_fra1,ref_fra2,estado_factura_id,importe_total,cuota,user_id,fecha_modificacion) " _
                    & " VALUES (?,1,?,?,?,?,?,?,?,?,0,2,now())"
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(hotel_idParam)
                    cmd.Parameters.Add(cliente_idParam)
                    cmd.Parameters.Add(fechaParam)
                    cmd.Parameters.Add(serie_idParam)
                    cmd.Parameters.Add(Numero_facturaParam)
                    cmd.Parameters.Add(ref1Param)
                    cmd.Parameters.Add(ref2Param)
                    cmd.Parameters.Add(estado_idParam)
                    cmd.Parameters.Add(importeParam)

                    cmd.CommandText = sql

                    Dim result As Object
                    result = ExecuteNonQuery(cmd, sql)
                    If result <> 1 Then  'Numero de filas afectadas ha de ser 1
                        errorCode = 2
                        flushConection(cmd, errorCode)
                        Throw New Exception("Error Cabecera Factura" + errorCode)
                    End If
                    factura_id = ExecuteScalar(cmd, "SELECT LAST_INSERT_ID()")  ' Obtengo la id de la factura para las lineas
                    ' Ahora vamos a por la linea de la factura......
                    factura_idParam.Value = factura_id
                    importeParam.Value = importe
                    servicio_idParam.Value = servicio_id
                    sql = "INSERT INTO lineas_factura (factura_id,hotel_id,fecha,descripcion,cantidad,precio,impuesto_id,porc_impuesto,servicio_id,unidad_calculo_id,tipo_linea_factura) " _
                    & " Values(?,?,?,'Carga Facturas Vivas CCI',1,?,1,0,?,1,'A')"
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(factura_idParam)
                    cmd.Parameters.Add(hotel_idParam)
                    cmd.Parameters.Add(fechaParam)
                    cmd.Parameters.Add(importeParam)
                    cmd.Parameters.Add(servicio_idParam)

                    result = ExecuteNonQuery(cmd, sql)
                    If result <> 1 Then  'Numero de filas afectadas ha de ser 1
                        errorCode = 2
                        flushConection(cmd, errorCode)
                        Throw New Exception("Error Linea Factura" + errorCode)
                    End If
                    If estado_id = 0 Then
                        If x.CambiarEstadoFactura(cmd, factura_id, 2, False) Then
                            errorCode = 4
                            flushConection(cmd, errorCode)
                            Throw New Exception("Error cambiando estado de Factura 2" + CStr(factura_id))
                        End If
                    End If
                Else
                    Console.WriteLine(" Contador=" & CStr(cont))
                End If
            End While
        Catch ex As Exception
            Console.WriteLine(" Contador=" & CStr(cont))
            errorCode = 1


        End Try
        Console.WriteLine(" Contador=" & CStr(cont) & " Importe=" & CStr(importe_total))
        flushConection(cmd, errorCode)
    End Sub

End Module


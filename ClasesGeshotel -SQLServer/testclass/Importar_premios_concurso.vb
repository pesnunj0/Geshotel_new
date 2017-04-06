Module importa_concurso
    Dim ConnectionString As String = "DSN=concurso"
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
    Private Function ObtainConnection(ByVal conString As String) As Odbc.OdbcConnection
        'thread safe?
        Dim conn As Odbc.OdbcConnection
        SyncLock cachedConections
            If cachedConections.Count = 0 Then
                conn = New Odbc.OdbcConnection(conString)
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
    Private Function prepareConection(Optional ByVal conString As String = "", Optional ByVal x As IsolationLevel = IsolationLevel.Serializable) As Odbc.OdbcCommand
        If conString = "" Then
            conString = ConnectionString
        End If
        Dim conn As Odbc.OdbcConnection = ObtainConnection(conString)
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
        Dim errorCode = 0
        Dim cmd As Odbc.OdbcCommand = prepareConection()
        Dim Reader As DataTableReader
        Dim articulo_idParam As New Odbc.OdbcParameter("id_articulo", 0)
        Dim sesion_idParam As New Odbc.OdbcParameter("id_sesion", 0)
        Dim cantidad_Param As New Odbc.OdbcParameter("cantidad", 0)
        Dim cont = 0
        Dim sesion_ini As Integer = 305
        Dim sesion_fin As Integer = 338
        Dim num_sesiones As Integer = sesion_fin - sesion_ini + 1
        Dim sql As String = "SELECT * FROM importacion"
        Dim sql_update As String = "UPDATE lasarenas_sesion_articulos SET cantidad =? WHERE id_sesion=? AND id_articulo=?"
        cmd.CommandText = sql
        Reader = readerToDataTable(cmd.ExecuteReader())
        Do While Reader.Read
            Dim articulo_id As Integer = Reader.Item(0)
            Dim cantidad As Integer = 0
            articulo_idParam.Value = articulo_id
            Dim i As Integer

            For i = 1 To num_sesiones

                If Not IsDBNull(Reader.Item(i)) Then
                    cantidad = Reader.Item(i)
                Else
                    cantidad = 0
                End If
                cantidad_Param.Value = cantidad
                sesion_idParam.Value = sesion_ini + i - 1
                cantidad_Param.Value = cantidad
                cmd.Parameters.Clear()
                cmd.Parameters.Add(cantidad_Param)
                cmd.Parameters.Add(sesion_idParam)
                cmd.Parameters.Add(articulo_idParam)

                Try
                    errorCode = ExecuteNonQuery(cmd, sql_update)
                Catch ex As Exception

                End Try


            Next i
        Loop
        flushConection(cmd, 0)
    End Sub
End Module

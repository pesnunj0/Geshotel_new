Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data
Imports System.Collections.Generic
Imports System.Threading
Imports System.Xml.Serialization
Public Class LocalesFacturacion
    Private Shared ConnectionString As String = "Driver={SQL Server};Server=10.0.0.4;Database=Facturacion;Trusted_Connection=Yes;"
    Private Sub LogTime(ByVal funcion, ByVal datos)
        cachedHitsMisses += 1
        'AgregaInfo(funcion, datos, 0)
        'Console.WriteLine(funcion & ":" & datos)
        'Console.WriteLine(" ")
    End Sub
    Shared ListaErrores As New ArrayList
    Private Class ErrroClass
        Public funcion As String
        Public mensaje As String
        Public nivel As Integer
        Public fecha As Date
    End Class
    Public Shared Sub AgregaInfo(ByVal funcion As String, ByVal mensaje As String, ByVal nivel As Integer)
        Dim x As New ErrroClass
        x.funcion = funcion
        x.mensaje = mensaje
        x.nivel = nivel
        x.fecha = Now
        ListaErrores.Add(x)
    End Sub
    Public Shared typeCachedConnections As New Hashtable()
    'Shared cachedConections As New Queue()
    Private Function ObtainConnection(ByVal x As IsolationLevel, Optional ByVal fichero As String = Nothing) As Odbc.OdbcConnection
        'thread safe?
        Dim conn As Odbc.OdbcConnection
        Dim xx = IsolationLevel.Serializable
        ' SyncLock typeCachedConnections
        'If Not typeCachedConnections.ContainsKey(xx) Then
        'typeCachedConnections(xx) = New Queue
        ' End If
        'If typeCachedConnections(xx).Count = 0 Then

        If IsNothing(fichero) Then
            conn = New Odbc.OdbcConnection(ConnectionString)
        Else
            'fichero = "Driver={Microsoft Access Driver (*.mdb)};Dbq=" & fichero & ";Uid=Admin;Pwd=;"
            fichero = "Driver={Microsoft Access Driver (*.mdb)};DBQ=" & fichero
            'fichero = Chr(34) & "DBQ=" & fichero & ";DriverId=25;FIL=MS Access;MaxBufferSize=2048;PageTimeout=5;UID=admin;" & Chr(34)
            'fichero = "Provider=MSDASQL.1;Persist Security Info=False;Extended Properties=" & fichero
            conn = New Odbc.OdbcConnection(fichero)

        End If

        'Console.WriteLine("creo con")
        '    Else
        'conn = typeCachedConnections(xx).Dequeue
        '    End If
        'End SyncLock
        Return conn
    End Function
    Private Sub ReleaseConnection(ByVal conn As Odbc.OdbcConnection)
        'todo threadsafe
        'Console.WriteLine("dest con")
        conn.Close()
        'SyncLock typeCachedConnections
        'typeCachedConnections(IsolationLevel.Serializable).Enqueue(conn)
        'End SyncLock
    End Sub
    Private Function prepareConectionOnlyRead() As Odbc.OdbcCommand
        Return prepareConection(IsolationLevel.RepeatableRead)
    End Function
    Private Function prepareConection(Optional ByVal x As IsolationLevel = IsolationLevel.RepeatableRead, Optional ByVal fichero As String = Nothing) As Odbc.OdbcCommand
        Dim conn As Odbc.OdbcConnection = ObtainConnection(x, fichero)
        Dim cmd As New Odbc.OdbcCommand

        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        'Dim Transaccion As Odbc.OdbcTransaction
        'Transaccion = conn.BeginTransaction(x)
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        Try
            cmd.Transaction = conn.BeginTransaction(x)
        Catch ex As Exception

        End Try


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

    ''' <summary>
    ''' Ejecuta el command executeNonQuery con control de errores
    ''' </summary>
    ''' <param name="cmd">Control de transacciones</param>
    ''' <param name="sql">Sentencia sql a ejecutar</param>
    ''' <returns>Numero de filas afectadas por la sentencia o 0 si no la pudo hacer</returns>
    ''' <remarks></remarks>
    '''     
    Private Function ExecuteNonQuery(ByVal cmd As Odbc.OdbcCommand, ByVal sql As String)

        LogTime("ExecuteNonQuery", sql)
        cmd.CommandText = sql
        Dim rowCount As Integer
        Dim previousConnectionState As ConnectionState
        previousConnectionState = cmd.Connection.State
        Try
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            Dim dt As Date = Now
            rowCount = cmd.ExecuteNonQuery()
            queryMicrosecs += (Now - dt).Ticks
        Catch
            AgregaInfo("ExecuteNonQuery", "Error Query:" & sql, -1)
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        End Try
        Return rowCount
    End Function
    ''' <summary>
    ''' Ejecuta el command execute Escalar con control de errores
    ''' </summary>
    ''' <param name="cmd">Control de transacciones</param>
    ''' <param name="sql">Sentencia sql a ejecutar</param>
    ''' <returns>Deveuelve la primera columna de la primera fila. Objeto Nothing en caso de error</returns>
    ''' <remarks></remarks>
    Private Function ExecuteScalar(ByVal cmd As Odbc.OdbcCommand, ByVal sql As String)

        LogTime("ExecuteScalar", sql)
        Dim tmp = cmd.CommandText
        cmd.CommandText = sql
        Dim valor = Nothing
        Dim previousConnectionState As ConnectionState
        previousConnectionState = cmd.Connection.State
        Try
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            Dim dt As Date = Now
            valor = cmd.ExecuteScalar
            queryMicrosecs += (Now - dt).Ticks
        Catch
            AgregaInfo("ExecuteScalar", "Error Query:" & sql, -1)
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        End Try
        cmd.CommandText = tmp
        Return valor
    End Function
    Public Shared cachedValues As New Hashtable
    Public Shared cachedHits As Integer = 0
    Public Shared cachedHitsMisses As Integer = 0
    Public Shared borrarHits As Integer = 0
    Public Shared queryMicrosecs As Long = 0
    Shared Sub flushCache()
        'olddatosReservaActual = Nothing
        'cachedClase = Nothing
        SyncLock cachedValues.SyncRoot
            'End SyncLock
            cachedValues.Clear()
        End SyncLock
        cachedHits = 0
        cachedHitsMisses = 0
        borrarHits = 0
    End Sub
    Private Function findInCache(ByVal cmd As Odbc.OdbcCommand, ByVal sql As String, Optional ByVal sufix As String = "")
        'Dim newarray(3) As System.Data.Odbc.OdbcParameter
        'cmd.Parameters.CopyTo(newarray, 0)
        Dim x As Integer = cmd.Parameters.Count - 1
        Dim y As Integer
        Dim key As New Text.StringBuilder(sql)
        For y = 0 To x
            key.Append(";" & cmd.Parameters(y).ParameterName & "=" & cmd.Parameters(y).Value)
        Next
        key.Append(";" & sufix)
        Dim datos(2) As Object
        datos(0) = key.ToString
        SyncLock cachedValues.SyncRoot
            datos(1) = cachedValues(datos(0))
        End SyncLock
        If Not datos(1) Is Nothing Then
            cachedHits += 1
        End If
        'crear clonaciones si es tipo tables
        Return datos
    End Function
    Private Function ExecuteScalar(ByVal cmd As Odbc.OdbcCommand, ByVal sql As String, ByVal cached As Boolean)
        Dim valor As Object
        valor = findInCache(cmd, sql, "XS")
        If cached And (Not valor(1) Is Nothing) Then
            'cachedHits += 1
            Return valor(1)
        Else
            Dim obj As Object = ExecuteScalar(cmd, sql)
            SyncLock cachedValues.SyncRoot
                cachedValues(valor(0)) = obj
            End SyncLock
            Return obj
        End If
    End Function
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
    Private Function getDataSet(ByVal cmd As Odbc.OdbcCommand, ByVal sql As String, ByVal ds As DataSet, ByVal name As String)
        LogTime("getDataSet", sql)
        cmd.CommandText = sql
        Dim da As Odbc.OdbcDataAdapter = New Odbc.OdbcDataAdapter(cmd)
        Dim myDataRowsCommandBuilder = New Odbc.OdbcCommandBuilder(da) 'esto pa ke sirve
        Dim dt As Date = Now
        da.Fill(ds, name)
        queryMicrosecs += (Now - dt).Ticks
        Return ds
    End Function
    Private Function getDataView(ByVal cmd As Odbc.OdbcCommand, ByVal sql As String, ByVal cached As Boolean)
        Dim valor As Object = findInCache(cmd, sql, "DV")
        Dim dtv As DataView
        If cached And (Not valor(1) Is Nothing) Then
            dtv = valor(1)
        Else
            dtv = New DataView(getDataSet(cmd, sql).Tables(0))
            SyncLock cachedValues.SyncRoot
                cachedValues(valor(0)) = dtv
            End SyncLock
        End If
        Return dtv
    End Function
    Private Function getDataSet(ByVal cmd As Odbc.OdbcCommand, ByVal sql As String, ByVal cached As Boolean)
        Dim valor As Object = findInCache(cmd, sql, "DS")
        Dim dtr As DataSet
        If cached And (Not valor(1) Is Nothing) Then
            dtr = valor(1)
        Else
            dtr = getDataSet(cmd, sql)
            SyncLock cachedValues.SyncRoot
                cachedValues(valor(0)) = dtr
            End SyncLock
        End If
        Return dtr.Copy
    End Function
    Private Function getDataSet(ByVal cmd As Odbc.OdbcCommand, ByVal sql As String) As DataSet
        'Return getDataSet(cmd, sql, New DataSet(), "tmp")
        LogTime("getDataSet", sql)
        cmd.CommandText = sql
        Dim ds As New DataSet()
        Dim da As Odbc.OdbcDataAdapter = New Odbc.OdbcDataAdapter(cmd)
        Dim myDataRowsCommandBuilder = New Odbc.OdbcCommandBuilder(da)
        Dim dt As Date = Now
        da.Fill(ds)
        queryMicrosecs += (Now - dt).Ticks
        Return ds
    End Function
    Private Function getDataAdapter(ByVal cmd As Odbc.OdbcCommand, ByVal sql As String) As Odbc.OdbcDataAdapter
        LogTime("getDataAdapter", sql)
        cmd.CommandText = sql
        Dim ds As New DataSet()
        Dim da As Odbc.OdbcDataAdapter = New Odbc.OdbcDataAdapter(cmd)
        Dim myDataRowsCommandBuilder As Odbc.OdbcCommandBuilder = New Odbc.OdbcCommandBuilder(da)
        myDataRowsCommandBuilder.ConflictOption = ConflictOption.OverwriteChanges
        'da.Fill(ds, "tmp")
        Return da
    End Function
    Private Function getTable(ByVal cmd As Odbc.OdbcCommand, ByVal sql As String) As DataTable
        LogTime("getTable", sql)
        Dim reader As DataTable = Nothing
        cmd.CommandText = sql
        Dim previousConnectionState As ConnectionState = cmd.Connection.State
        Try
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            Dim dt As Date = Now
            reader = readerToTable(cmd.ExecuteReader())
            queryMicrosecs += (Now - dt).Ticks
        Catch
            AgregaInfo("getTable", "Error Query:" & sql, -1)
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        End Try
        Return reader
    End Function
    Private Function getTable(ByVal cmd As Odbc.OdbcCommand, ByVal sql As String, ByVal cached As Boolean) As DataTable
        Dim valor As Object = findInCache(cmd, sql, "TA")
        Dim dtr As DataTable
        If cached And (Not valor(1) Is Nothing) Then
            'Console.WriteLine("hit-" & cachedHits)
            dtr = valor(1)
            Return dtr.Copy() 'error grave del copon..deberia ser copy
        Else
            dtr = getTable(cmd, sql)
            SyncLock cachedValues.SyncRoot
                cachedValues(valor(0)) = dtr
            End SyncLock
            Return dtr.Copy()
        End If
    End Function
    Private Function getDataTable(ByVal cmd As Odbc.OdbcCommand, ByVal sql As String) As DataTableReader
        'Console.WriteLine(sql)
        LogTime("getDataTable", sql)
        Dim reader As DataTableReader = Nothing
        cmd.CommandText = sql
        Dim previousConnectionState As ConnectionState = cmd.Connection.State
        Try
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            Dim dt As Date = Now
            reader = readerToDataTable(cmd.ExecuteReader())
            queryMicrosecs += (Now - dt).Ticks
        Catch
            AgregaInfo("getDataTable", "Error Query:" & sql, -1)
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        End Try
        Return reader
    End Function
    Private Function getDataTable(ByVal cmd As Odbc.OdbcCommand, ByVal sql As String, ByVal cached As Boolean) As DataTableReader
        Dim valor As Object = findInCache(cmd, sql, "DT")
        Dim dtr As DataTable
        If cached And (Not valor(1) Is Nothing) Then
            dtr = valor(1)
        Else
            dtr = getTable(cmd, sql)
            SyncLock cachedValues.SyncRoot
                cachedValues(valor(0)) = dtr
            End SyncLock
        End If
        Return dtr.CreateDataReader
    End Function

    Sub importarFicheroMDB(ByVal p1 As String)
        Dim resultado As Boolean
        'If 1 = 0 Then



        Dim cmdServer As Odbc.OdbcCommand = prepareConection(IsolationLevel.RepeatableRead)
        Dim loc As DataSet = getDataSet(cmdServer, "select * from locales where empresa_id=5")
        If Not flushConection(cmdServer, 0) Then
            resultado = False
        End If
        'End If
        Dim cmd As Odbc.OdbcCommand = prepareConection(IsolationLevel.RepeatableRead, p1)
        Dim reader As DataTableReader = getDataTable(cmd, "select * from locales")
        Dim err As Integer = 0
        Dim cont As Integer = 0
        Dim warr As Integer = 0
        While reader.Read
            cont += 1
            If reader.IsDBNull(reader.GetOrdinal("UBICACION LOCAL")) Then
                err += 1
            Else


                Dim local_id As String = reader("UBICACION LOCAL")
                If local_id.IndexOf("(") >= 0 Then
                    local_id = local_id.Split("(")(0).Trim
                End If

                Dim local_id_alt As String = local_id
                If local_id_alt.IndexOf("-") >= 0 Then
                    Dim mat() As String = local_id_alt.Split("-")
                    'Dim mat2() As String = local_id_alt.Split("-")
                    Dim num() As String = mat(1).Split(",")
                    'Dim num2() As String = mat(1).Split(",")
                    Dim zz As Integer
                    mat(1) = ""
                    'mat2(1) = ""
                    For zz = 0 To num.Length - 1
                        num(zz) = "0" & num(zz) '& "%"
                        'num2(zz) = num2(zz) & "%"
                    Next
                    mat(1) = Join(num, ",")
                    'mat2(1) = Join(num2, ",")
                    'mat(1) = "0" & mat(1)
                    local_id_alt = mat(0) & "-" & mat(1)
                    'local_id = mat2(0) & "-" & mat2(1)
                End If
                Dim rows() As DataRow = loc.Tables(0).Select("numero like '" & local_id & "%'" & " or numero like '" & local_id_alt & "%'")
                If rows.Length = 0 Then
                    Console.WriteLine(local_id + "-" + local_id_alt)
                    err += 1
                Else
                    If rows.Length = 1 Then
                    Else
                        rows = loc.Tables(0).Select("numero ='" & local_id & "'")
                        If rows.Length = 1 Then
                        Else
                            rows = loc.Tables(0).Select("numero ='" & local_id_alt & "'")
                            If rows.Length = 1 Then
                            Else
                                Console.WriteLine("war:" & local_id + "-" + local_id_alt)
                                warr += 1
                            End If
                        End If

                    End If
                End If
                If 1 = 0 Then
                    Dim y As Integer = reader.VisibleFieldCount
                    Dim x As Integer
                    For x = 0 To y
                        'Console.WriteLine(reader.GetName(x) & "= " & reader(x))
                    Next
                End If
            End If
        End While
        Console.WriteLine(cont & "_" & warr & "_" & err)
        If Not flushConection(cmd, 0) Then
            resultado = False
        End If

    End Sub

End Class

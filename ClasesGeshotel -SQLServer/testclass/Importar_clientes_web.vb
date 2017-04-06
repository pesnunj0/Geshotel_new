Imports System.Math
Module Importar_clientes_web


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
    Private Function crea_cliente_marketing(ByVal cmd As Odbc.OdbcCommand, ByVal reader As DataTableReader, cliente_id As Integer)

    End Function
    Public Sub Main()
        Dim x As New ClasesGesHotel.geshotel.GesHotelClase(1)
        Dim errorCode = 0
        Dim cmd As Odbc.OdbcCommand = prepareConection()
        Dim sql As String = "Select * FROM usuarios_t"
        Dim mailParam As New Odbc.OdbcParameter("@mail", "")
        Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", 1)
        Dim nombreParam As New Odbc.OdbcParameter("@nombre", "")
        cmd.CommandText = sql
        Dim Reader As DataTableReader = readerToDataTable(cmd.ExecuteReader())
        Dim sql_insert As String = "INSERT INTO clientes_marketing (cliente_id,id,nombre,apellido1,apellido2,nif,grupo_id,logion,passwd,idioma_preferido, " _
        & "habla espanol,habla_ingles,habla_aleman,habla_otros,viaja_familia,viaja_padre,viaja_madre,viaja_pareja,viaja_hijo1,viaja_hijo2,viaja_amigos,viaja_en_grupo,viaja_solo," _
        & "viaja_otros,cantidad_compania,busca_naturaleza,busca_deporte,busca_disco,busca_sol,busca_spa,busca_vulcanologia,busca_nautica,busca_submarinismo, " _
        & "busca_etnologia,busca_golf,busca_trekking,busca_artes_populares,busca_cultura,busca_hipica,busca_excursiones,busca_gastronomia,busca_casino,busca_pesca,suscriptor_boletin " _
        & "VALUES ("
        Dim i As Integer
        For i = 1 To 43
            sql_insert &= "?,"
        Next
        sql_insert &= "?)"
        Dim encontrado = False
        While Reader.Read And Not encontrado
            mailParam.Value = Reader.Item("email")
            If Trim(Reader.Item("email")) <> "" Then ' Si tiene mail....
                nombreParam.Value = Reader.Item("nombre")
                ' Busco el primero en Geshotel con ese mail. Supongo que será el que me interesa
                cmd.Parameters.Clear()
                cmd.Parameters.Add(mailParam)
                cmd.Parameters.Add(nombreParam)
                sql = "SELECT cliente_id FROM clientes WHERE email = ? And clientes.razon LIKE '%?%' AND clientes.grupo_cliente_id = 5 Limit 0,1"
                Dim Cliente_id As Object = ExecuteScalar(cmd, sql)
                If Not IsDBNull(Cliente_id) AndAlso Cliente_id <> 0 Then ' Encontrado guapo
                    encontrado = True
                    ' A cargar los campos en la tabla clientes_marketing


                End If
            End If

        End While
    End Sub
End Module

Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data
Imports System.Collections.Generic
Imports System.Threading
Imports System.Xml.Serialization

Namespace geshotel
    Public Class GesHotelClase
        Inherits GesHotelClaseUtils
        'Public Shared ultimaMetaReserva As MetaReserva = Nothing
        Private Shared ConnectionString As String = "DSN=geshotel"

        Private userId As Integer = 0
        Public metaresid As Integer = -1
        Public metaresidhash As Hashtable
        Private Function convertFecha(ByVal fec As Date) As String
            Return fec.ToString("yyyy-MM-dd")
        End Function
        Private Function convertTime(ByVal fec As Date) As String
            Return fec.ToString("HH:mm:ss")
        End Function
        Private Function startMeasure() As Object
            Dim x As Date = Now
            Return x
        End Function
        Private Sub stopMeasure(ByVal y As Date)
            Console.WriteLine(Now - y)
        End Sub
        Shared calctimeTable As New Hashtable
        Shared calctimeResult As New Hashtable
        Shared calctimeCount As New Hashtable
        Private Sub calcTime(ByVal p1 As String, ByVal p2 As Boolean)
            If p2 Then
                calctimeTable(p1) = Now.Ticks
            Else
                If Not calctimeResult.ContainsKey(p1) Then
                    calctimeResult(p1) = 0
                    calctimeCount(p1) = 0
                End If
                calctimeResult(p1) += (Now.Ticks - calctimeTable(p1))
                calctimeCount(p1) += 1
            End If
        End Sub
        Public Function dumpCalcTime()
            Dim ienu As IEnumerator = calctimeResult.Keys.GetEnumerator
            While ienu.MoveNext
                Dim y = calctimeResult(ienu.Current)

                Console.WriteLine(ienu.Current & ":" & (y / TimeSpan.TicksPerSecond) & "(" & calctimeCount(ienu.Current) & ")")
            End While

        End Function

        Shared cachedClase As GesHotelClase
        Public Shared Function CrearClase(ByVal userid As Integer) As GesHotelClase
            If IsNothing(cachedClase) Then
                cachedClase = New GesHotelClase(userid)
            End If
            Return cachedClase
        End Function
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
        Shared sqlVolcadoErrores = "select '' as funcion,'' as mensaje,1 as nivel,now() as fecha from(select 1) drv where 1=0"
        Shared Function volcarErrores(ByVal limpiar As Boolean, ByVal formato As Integer) As Object
            'Dim resultadoTabla As DataSet
            Dim retVal As Single = 0
            Dim errorCode As Integer = 0
            Dim conn As New Odbc.OdbcConnection("DSN=geshotel")
            Dim cmd As New Odbc.OdbcCommand
            Dim Transaccion As Odbc.OdbcTransaction
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            Transaccion = conn.BeginTransaction(IsolationLevel.Serializable)
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn
            cmd.Transaction = Transaccion
            Dim resultado As New Text.StringBuilder
            Dim resultadoTabla As New DataSet()
            Try

            

                cmd.CommandText = sqlVolcadoErrores

                Dim da As Odbc.OdbcDataAdapter = New Odbc.OdbcDataAdapter(cmd)
                Dim myDataRowsCommandBuilder = New Odbc.OdbcCommandBuilder(da)
                da.Fill(resultadoTabla)

                'resultadoTabla = getDataSet(cmd, sqlVolcadoErrores)

                Dim x As Integer
                Dim y As Integer = ListaErrores.Count - 1
                Dim z As ErrroClass
                resultado.Append("Fecha:" & Now)
                For x = 0 To y
                    z = ListaErrores(x)
                    If Not IsNothing(z) Then
                        '                If z.nivel < 0 Then
                        resultado.Append(z.fecha & ":" & z.funcion & "-" & z.mensaje)
                        resultado.AppendLine()
                        Dim row As DataRow = resultadoTabla.Tables(0).Rows.Add
                        row.Item("funcion") = z.funcion
                        row.Item("mensaje") = z.mensaje
                        row.Item("nivel") = z.nivel
                        row.Item("fecha") = z.fecha
                        'End If
                    End If
                Next
                If limpiar Then
                    ListaErrores.Clear()
                End If
            Catch ex As Exception

            End Try
            If Not IsNothing(Transaccion) Then
                If errorCode <> 0 Then
                    Transaccion.Rollback()
                Else
                    Transaccion.Commit()
                    ' Transaccion.Rollback()
                End If
                conn.Close()
            End If

            If formato = 1 Then
                Return resultadoTabla
            Else
                Return resultado.ToString
            End If

        End Function
        Private Sub LogTime(ByVal funcion, ByVal datos)
            cachedHitsMisses += 1
            'AgregaInfo(funcion, datos, 0)
            'Console.WriteLine(funcion & ":" & datos)
            'Console.WriteLine(" ")
        End Sub
        Public Shared typeCachedConnections As New Hashtable()
        'Shared cachedConections As New Queue()
        Private Function ObtainConnection(ByVal x As IsolationLevel) As Odbc.OdbcConnection
            'thread safe?
            Dim conn As Odbc.OdbcConnection
            Dim xx = IsolationLevel.Serializable
            SyncLock typeCachedConnections
                If Not typeCachedConnections.ContainsKey(xx) Then
                    typeCachedConnections(xx) = New Queue
                End If
                If typeCachedConnections(xx).Count = 0 Then
                    conn = New Odbc.OdbcConnection(ConnectionString)
                    'Console.WriteLine("creo con")
                Else
                    conn = typeCachedConnections(xx).Dequeue
                End If
            End SyncLock
            Return conn
        End Function
        Private Sub ReleaseConnection(ByVal conn As Odbc.OdbcConnection)
            'todo threadsafe
            'Console.WriteLine("dest con")
            'conn.Close()
            SyncLock typeCachedConnections
                typeCachedConnections(IsolationLevel.Serializable).Enqueue(conn)
            End SyncLock
        End Sub
        Private Function prepareConectionOnlyRead() As Odbc.OdbcCommand
            Return prepareConection(IsolationLevel.RepeatableRead)
        End Function
        Private Function prepareConection(Optional ByVal x As IsolationLevel = IsolationLevel.RepeatableRead) As Odbc.OdbcCommand
            Dim conn As Odbc.OdbcConnection = ObtainConnection(x)
            Dim cmd As New Odbc.OdbcCommand

            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            'Dim Transaccion As Odbc.OdbcTransaction
            'Transaccion = conn.BeginTransaction(x)
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn
            cmd.Transaction = conn.BeginTransaction(x)

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
            cmd.CommandText = Sql
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
                AgregaInfo("ExecuteNonQuery", "Error Query:" & Sql, -1)
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
            olddatosReservaActual = Nothing
            cachedClase = Nothing
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
        Public Class UCS
            Public unidad_calculo_id As Integer
            Public cantidad As Single
        End Class
        Public Class MetaHuesped
            'Public reserva_id As Integer
            Public empresa_id As Integer
            Public cliente_id As Integer
            Public razon As String
            Public sexo_id As Char
            Public tipo_documento_id As Char
            Public nif As String
            Public fecha_documento As Object = Nothing
            Public fecha_nacimiento As Object = Nothing
            Public nacion_id As Integer
            Public tipo_huesped_id As Integer
            Public habitacion_id As Object
            Public fecha_llegada As Date
            Public fecha_salida As Object = Nothing
            Public agregado As Boolean = False
            Public habitacion As Object
        End Class
        Public Class MetaReserva
            Public errores As String
            Public habitacion As Object
            Public habitacion_id As Object
            Public hotel_id As Integer
            Public cliente_id As Integer
            Public cliente_id_factura As Integer
            Public fecha_reserva As Date
            Public canal_reserva_id As Integer
            Public bloquear_tarifa As Boolean
            Public vip As Boolean
            Public fecha_prevista_llegada As Date
            Public hora_prevista_llegada As String
            Public fecha_prevista_salida As Date
            Public hora_prevista_salida As String
            Public bono_referencia As String
            Public permite_devolucion As Boolean
            Public habitacion_servicio_id As Integer
            Public numero_habitaciones As Integer
            Public pension_servicio_id As Integer
            Public unidades_calculos() As UCS
            Public observaciones As String
            Public codigo_oferta As String
            Public huespedes() As MetaHuesped
            'datos tarjeta
            Public tipo_tarjeta_id As Integer
            Public tarjeta_credito As String
            Public caducidad As String
            Public cod_seguridad As String
            Public email As String
        End Class

        Shared sqlBaseDatasetMetaHuesped = "" _
& " SELECT 0 as reserva_id, 0 as cliente_id, 0 as  tipo_huesped_id," _
& " '' as razon, 0 AS clientes_cliente_id, 0 AS habitacion_id_defecto," _
& " '' as nif, now() as fecha_documento,now() AS fecha_llegada, '' as sexo_id, 0 as nacion_id, now() as fecha_nacimiento"
        Public Function ObtieneDataSetMetaHuespedes(ByVal huespedes() As MetaHuesped) As DataSet
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim datos As DataSet = Me.getDataSet(cmd, sqlBaseDatasetMetaHuesped)
            datos.Tables(0).Rows(0).Delete()
            datos.Tables(0).AcceptChanges()
            Try
                Dim x
                For x = 0 To huespedes.Length '- 1
                    Dim row As DataRow = datos.Tables(0).Rows.Add()
                    row.Item("reserva_id") = 0
                    row.Item("razon") = huespedes(x).razon
                    row.Item("cliente_id") = huespedes(x).cliente_id
                    row.Item("tipo_huesped_id") = huespedes(x).tipo_huesped_id
                    row.Item("clientes_cliente_id") = huespedes(x).cliente_id
                    row.Item("habitacion_id_defecto") = 0
                    If Not IsNothing(huespedes(x).habitacion_id) Then
                        If IsNumeric(huespedes(x).habitacion_id) Then
                            row.Item("habitacion_id_defecto") = huespedes(x).habitacion_id
                        End If
                    End If

                    row.Item("nif") = huespedes(x).nif
                    If IsDate(huespedes(x).fecha_documento) Then
                        row.Item("fecha_documento") = CDate(huespedes(x).fecha_documento)
                    End If
                    row.Item("sexo_id") = huespedes(x).sexo_id
                    row.Item("nacion_id") = huespedes(x).nacion_id
                    If IsDate(huespedes(x).fecha_nacimiento) Then
                        row.Item("fecha_nacimiento") = CDate(huespedes(x).fecha_nacimiento)
                    End If
                    If IsDate(huespedes(x).fecha_llegada) Then
                        row.Item("fecha_llegada") = CDate(huespedes(x).fecha_llegada)
                    End If
                Next
            Catch ex As Exception

            End Try
            flushConection(cmd, errorCode)
            'AgregaInfo("actualizaHuespedesReserva", "sali", -1)
            Return datos

        End Function
        Shared sqlObtieneGrupoHuespedPorEmpresa = "" _
& " SELECT grupos_de_cliente.empresa_Id," _
& " grupos_de_cliente.grupo_cliente_id " _
& " FROM " _
& " grupos_de_cliente " _
& " WHERE " _
& " grupos_de_cliente.huesped =  1 "
        Shared sqlCabHuespedes = "SELECT * FROM reservas_huespedes WHERE reserva_id=?"
        Private Function volcarHuesped(ByVal huesped As MetaHuesped) As String
            Dim tmp As New ArrayList
            tmp.Add("cliente_id:" & huesped.cliente_id)
            tmp.Add("empresa_id:" & huesped.empresa_id)
            tmp.Add("fecha_documento:" & huesped.fecha_documento)
            tmp.Add("fecha_llegada:" & huesped.fecha_llegada)
            tmp.Add("fecha_nacimiento:" & huesped.fecha_nacimiento)
            tmp.Add("fecha_salida:" & huesped.fecha_salida)
            tmp.Add("habitacion_id:" & huesped.habitacion_id)
            tmp.Add("nacion_id:" & huesped.nacion_id)
            tmp.Add("nif:" & huesped.nif)
            tmp.Add("razon:" & huesped.razon)
            tmp.Add("sexo_id:" & huesped.sexo_id)
            tmp.Add("tipo_huesped_id:" & huesped.tipo_huesped_id)

            Dim tmp1 As String = ""
            Dim x As Integer
            For x = 0 To tmp.Count - 1
                tmp1 += tmp(x) & "<br>"
            Next
            Return tmp1
        End Function
        Public Function actualizaHuespedesReserva(ByVal reserva_id As Integer, ByVal huespedes() As MetaHuesped)
            Dim errorCode As Integer = 0
            Dim retVal As Boolean = False
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = actualizaHuespedesReserva(cmd, reserva_id, huespedes)
            If retVal = False Then
                errorCode = 1
            End If
            flushConection(cmd, errorCode)
            Return retVal
        End Function

        Private Function actualizaHuespedesReserva(ByVal cmd As Odbc.OdbcCommand, ByVal reserva_id As Integer, ByVal huespedes() As MetaHuesped) As Boolean
            'AgregaInfo("actualizaHuespedesReserva", "entre", -1)

            Dim retVal As Boolean = True
            Dim errorCode As Integer = 0

            Dim grupos_clientes As DataSet = Me.getDataSet(cmd, sqlObtieneGrupoHuespedPorEmpresa)

            Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", 0)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(cliente_idParam)
            Dim clientes As DataSet = getDataSet(cmd, sqlCabCliente)
            getDataSet(cmd, sqlCabCliente, clientes, "clientesold")
            Try
                Dim x As Integer
                Dim writer As Odbc.OdbcDataAdapter
                For x = 0 To huespedes.Length - 1
                    Dim row As DataRow
                    If errorCode = 0 And Not IsNothing(huespedes(x).razon) Then
                        'And Not (huespedes(x).cliente_id = 0 And huespedes(x).razon = "") Then
                        row = Nothing
                        'AgregaInfo("actualizaHuespedesReserva", "Reserva:" & reserva_id & "<br>" & volcarHuesped(huespedes(x)), -1)
                        If huespedes(x).cliente_id = 0 And huespedes(x).razon <> "" Then
                            'no hay id de cliente asi que crea el registro en la tabla de clientes
                            row = clientes.Tables(0).Rows.Add
                            huespedes(x).agregado = True
                        Else
                            cliente_idParam.Value = huespedes(x).cliente_id
                            Dim tmp As DataSet = getDataSet(cmd, sqlCabCliente, clientes, "clientesold")
                            Dim clitmp() As DataRow = tmp.Tables("clientesold").Select("cliente_id=" & huespedes(x).cliente_id)
                            If clitmp.Length > 0 Then
                                row = clitmp(0)
                            Else
                                errorCode = 3
                                AgregaInfo("actualizaHuespedesReserva", "No encuentro el cliente:" & huespedes(x).cliente_id, -errorCode)
                            End If
                            'row = tmp.Tables("clientesold").Rows(tmp.Tables("clientesold").Rows.Count)
                        End If
                        'actualiza campos cliente
                        If Not IsNothing(row) Then
                            Dim grupos() As DataRow = grupos_clientes.Tables(0).Select("empresa_id=" & huespedes(x).empresa_id)
                            If grupos.Length > 0 Then
                                row.Item("grupo_cliente_id") = grupos(0).Item("grupo_cliente_id")
                                row.Item("empresa_id") = huespedes(x).empresa_id
                                row.Item("razon") = huespedes(x).razon
                                If Not IsNothing(huespedes(x).sexo_id) Then
                                    If huespedes(x).sexo_id <> "" Then
                                        row.Item("sexo_id") = huespedes(x).sexo_id
                                    End If
                                End If
                                If Not IsNothing(huespedes(x).tipo_documento_id) Then
                                    If huespedes(x).tipo_documento_id <> "" Then
                                        row.Item("tipo_documento_id") = huespedes(x).tipo_documento_id
                                    End If

                                End If

                                row.Item("nif") = huespedes(x).nif
                                row.Item("fecha_documento") = DBNull.Value
                                row.Item("fecha_nacimiento") = DBNull.Value
                                If Not IsNothing(huespedes(x).fecha_documento) Then
                                    row.Item("fecha_documento") = huespedes(x).fecha_documento
                                End If
                                If Not IsNothing(huespedes(x).fecha_nacimiento) Then
                                    row.Item("fecha_nacimiento") = huespedes(x).fecha_nacimiento
                                End If
                                If huespedes(x).nacion_id <> 0 Then
                                    row.Item("nacion_id") = huespedes(x).nacion_id
                                End If

                                row.Item("user_id") = userId
                                row.Item("fecha_modificacion") = Now
                                If row.RowState = DataRowState.Added Then
                                    'crear el registro y obtener el id

                                    writer = getDataAdapter(cmd, sqlCabCliente)
                                    writer.Fill(clientes.Tables(0))
                                    writer.Update(clientes.Tables(0))
                                    row.AcceptChanges()
                                    'obtener el ultimo registro insertado
                                    Dim cliente_id As Integer = ExecuteScalar(cmd, "SELECT LAST_INSERT_ID()")
                                    If cliente_id <> 0 Then
                                        row.Item("cliente_id") = cliente_id
                                        huespedes(x).cliente_id = cliente_id
                                        'row.SetModified()
                                        'cambiar el estado a updated
                                    Else
                                        errorCode = 4
                                        AgregaInfo("actualizaHuespedesReserva", "No puedo crear cliente:", -errorCode)

                                    End If

                                End If
                            Else
                                errorCode = 2
                                AgregaInfo("actualizaHuespedesReserva", "Empresa no tiene al menos un grupo de cliente Huesped:" & huespedes(x).empresa_id, -errorCode)
                            End If
                        End If
                    End If
                Next
                'actualizar campos clientes ya existentes
                If errorCode = 0 Then


                    writer = getDataAdapter(cmd, sqlCabCliente)
                    writer.Fill(clientes.Tables("clientesold"))
                    writer.Update(clientes.Tables("clientesold"))

                    'actualiza campos reservas_huespedes
                    'crea lineas nuevas de clientes creados
                    Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(reserva_idParam)
                    'obtiene hotel de la reserva
                    Dim hotel_id As Integer = 0
                    Try
                        Dim DSreserva As DataSet = getDataSet(cmd, sqlCabReserva)
                        hotel_id = DSreserva.Tables(0).Rows(0)("hotel_id")
                    Catch ex As Exception

                    End Try

                    Dim DShuespedes As DataSet = getDataSet(cmd, sqlCabHuespedes)
                    'Dim clitmp() As DataRow = clientes.Tables(0).Select("")
                    Dim y As Integer
                    For y = 0 To huespedes.Length - 1
                        Dim row As DataRow = Nothing
                        If huespedes(y).agregado Then
                            row = DShuespedes.Tables(0).Rows.Add()
                        Else
                            'encuentra la posile fila...cliente_id,fecha_llegada
                            Dim rows() As DataRow = DShuespedes.Tables(0).Select("cliente_id=" & huespedes(y).cliente_id)
                            If rows.Length = 1 Then
                                'solo hay uno..asi ke es ese
                                row = rows(0)
                            Else
                                If rows.Length = 0 Then
                                    'no hay nada que agregar
                                    row = DShuespedes.Tables(0).Rows.Add()
                                Else
                                    'hay mas de uno...buscar por fecha llegad y quedarse con el ultimo
                                    Dim z As Integer
                                    For z = 0 To rows.Length - 1
                                        If rows(z).Item("fecha_llegada") = huespedes(y).fecha_llegada Then
                                            row = rows(z)
                                        End If
                                    Next
                                End If
                            End If
                        End If
                        If Not IsNothing(row) And huespedes(y).tipo_huesped_id > 0 Then
                            row("reserva_id") = reserva_id
                            row("cliente_id") = huespedes(y).cliente_id
                            row("fecha_llegada") = huespedes(y).fecha_llegada
                            row("fecha_salida") = DBNull.Value
                            If Not IsNothing(huespedes(y).fecha_salida) Then
                                row("fecha_salida") = huespedes(y).fecha_salida
                            End If
                            row("habitacion_id") = DBNull.Value
                            If Not IsNothing(huespedes(y).habitacion) Then
                                huespedes(y).habitacion_id = ObtieneHabitacion_Id(cmd, hotel_id, huespedes(y).habitacion)
                            End If

                            If Not IsNothing(huespedes(y).habitacion_id) Then
                                If huespedes(y).habitacion_id > 0 Then
                                    row("habitacion_id") = huespedes(y).habitacion_id
                                End If
                            End If
                            row("tipo_huesped_id") = huespedes(y).tipo_huesped_id
                        Else
                            errorCode = 5
                            AgregaInfo("actualizaHuespedesReserva", "Fallo al asignar huespedes:", -errorCode)
                        End If
                    Next
                    If errorCode = 0 Then
                        'que pasa con un huespede ke se cambia de orden?
                        writer = getDataAdapter(cmd, sqlCabHuespedes)
                        writer.Fill(DShuespedes.Tables(0))
                        writer.Update(DShuespedes.Tables(0))
                    End If
                End If
                'actualiza los clientes que ya existian
            Catch ex As Exception
                errorCode = 1
                'ex.Message
                AgregaInfo("actualizaHuespedesReserva", "Error al actualizar huespedes en reservas:" + ex.Message, -errorCode)
            End Try
            If errorCode <> 0 Then
                retVal = False
            End If
            Return retVal

        End Function
        Shared sqlObtieneClienteFacturaReserva = "" _
& " SELECT" _
& " ifnull(reservas.cliente_id_factura,case clientes.permite_credito when 1 then reservas.cliente_id else ifnull(reservas_primer_huesped.cliente_id,reservas.cliente_id) end   ) as cliente_id" _
& " FROM " _
& " reservas " _
& " Left Join reservas_primer_huesped ON reservas.reserva_id = reservas_primer_huesped.reserva_id " _
& " Left Join clientes ON reservas.cliente_id = clientes.cliente_id " _
& " WHERE " _
& " reservas.reserva_id =  ?"

        Function ObtieneClienteFacturaReserva(ByVal reserva_id As Integer) As Integer
            Dim retVal As Integer = 0
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try
                Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
                cmd.Parameters.Clear()
                cmd.Parameters.Add(reserva_idParam)
                retVal = ExecuteScalar(cmd, sqlObtieneClienteFacturaReserva)
            Catch ex As Exception
                errorCode = 1
                AgregaInfo("ObtienePendienteAnticipoReserva", "Error al obtener el pendiente de la reserva:" & reserva_id, -errorCode)
            End Try
            flushConection(cmd, errorCode)
            Return retVal
        End Function
        Shared sqlObtienePendienteAnticiposReserva = "" _
& " select sum(tot)" _
& "  from (" _
& " select anticipos.importe " _
& " -(select ifnull(sum(importe),0) from lineas_anticipo l where l.anticipo_id=anticipos.anticipo_id) " _
& " -(select ifnull(sum(importe),0) from anticipos a where a.anticipo_padre_id=anticipos.anticipo_id)  " _
& " as tot  " _
& " from anticipos  " _
& " where anticipos.reserva_id=?  " _
& " group by anticipos.anticipo_id)  " _
& " drvanti "
        Public Function ObtienePendienteAnticipoReserva(ByVal reserva_id As String) As Single
            Dim retVal As Single = 0
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try
                retVal = ObtienePendienteAnticipoReserva(cmd, reserva_id)
            Catch ex As Exception
                errorCode = 1
                AgregaInfo("ObtienePendienteAnticipoReserva", "Error al obtener el pendiente de la reserva:" & reserva_id, -errorCode)
            End Try
            flushConection(cmd, errorCode)
            Return retVal
        End Function
        Private Function ObtienePendienteAnticipoReserva(ByVal cmd As Odbc.OdbcCommand, ByVal reserva_id As String) As Single
            Dim retVal As Single = 0
            Dim res As Integer = reserva_id
            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", res)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(reserva_idParam)
            Try
                retVal = Me.ExecuteScalar(cmd, sqlObtienePendienteAnticiposReserva)
            Catch ex As Exception
                AgregaInfo("ObtienePendienteAnticipoReserva", "Error al obtener el pendiente de la reserva:" & reserva_id, -2)
            End Try

            Return retVal
        End Function
        Shared sqlObtieneMovAnticipos = "" _
& " SELECT tipos_anticipo.serie_id," _
& " tipos_anticipo.tipo_movimiento_id,anticipos.reserva_id, " _
& " anticipos.hotel_id,anticipos.cliente_id,anticipos.fecha, anticipos.descripcion,anticipos.tipo_anticipo_id," _
& " anticipos.caja_id, " _
& " anticipos.importe, " _
& " anticipos.anticipo_id, " _
& " anticipos.forma_pago_id " _
& " FROM " _
& " anticipos " _
& " Inner Join tipos_anticipo ON anticipos.tipo_anticipo_id = tipos_anticipo.tipo_anticipo_id " _
& " WHERE " _
& " anticipos.anticipo_id =  ? AND " _
& " anticipos.estado_id is null "
        Shared sqlActualizaAnticipoEstadoNulo = "update anticipos set estado_id=0 where anticipo_id=? and estado_id is null"
        Public Function ActualizarAnticipo(ByVal anticipo_id As Integer)
            Dim retVal As Integer = -1
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            errorCode = ActualizarAnticipo(cmd, anticipo_id)
            flushConection(cmd, errorCode)
            Return retVal
        End Function
        Shared sqlDatosLineasSeries = "" _
& " SELECT " _
& " series.servicio_id," _
& " series.impuesto_id, " _
& " servicios.nombre_servicio, " _
& " impuestos.porcentaje " _
& " FROM " _
& " series " _
& " Inner Join servicios ON series.servicio_id = servicios.servicio_id " _
& " Inner Join impuestos ON series.impuesto_id = impuestos.impuesto_id " _
& " WHERE " _
& " series.serie_id =  ? "
        Public Function CrearFacturaSencilla(ByVal hotel_id As Integer, ByVal cliente_id As Integer, ByVal serie_id As Integer, ByVal referencia2 As String, ByVal cantidad As Integer, ByVal precio As Single, Optional ByVal fecha As Object = Nothing) As Factura
            Dim retVal As Integer = -1
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim fac As Factura = CrearFacturaSencilla(cmd, hotel_id, cliente_id, serie_id, referencia2, cantidad, precio, fecha)
            If IsNothing(fac) Then
                errorCode = 1
            End If
            flushConection(cmd, errorCode)
            Return fac
        End Function
        Private Function CrearFacturaSencilla(ByVal cmd As Odbc.OdbcCommand, ByVal hotel_id As Integer, ByVal cliente_id As Integer, ByVal serie_id As Integer, ByVal reserva_id As Object, ByVal referencia2 As Object, ByVal cantidad As Integer, ByVal precio As Single, Optional ByVal fecha As Object = Nothing) As Factura
            cmd.Parameters.Clear()
            Dim serie_idParam As New Odbc.OdbcParameter("@serie_id", serie_id)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(serie_idParam)
            Dim reader As DataTableReader = getDataTable(cmd, sqlDatosLineasSeries)
            Dim fac As Factura = Nothing
            Try
                While reader.Read
                    If IsNothing(fecha) Then
                        fecha = FechaHotel(cmd, hotel_id)
                    End If
                    'todo obtiene datos serie
                    fac = preparaFactura(cmd, -1, cliente_id, 1, fecha, hotel_id, serie_id, referencia2)
                    Dim dtcab As DataTable = fac.ds.Tables(0)
                    'dtcab.Rows(0)("ref_fra2") = referencia2
                    'TODO crear lineas de facturas
                    Dim row As DataRow = agregaLineaFactura(fac)
                    row.Item("fecha") = fecha
                    If IsNothing(reserva_id) Then
                        row.Item("reserva_id") = System.DBNull.Value
                    Else
                        row.Item("reserva_id") = reserva_id
                    End If

                    If fac.factura_id = 0 Then
                        row.Item("factura_id") = System.DBNull.Value
                    Else
                        row.Item("factura_id") = fac.factura_id
                    End If
                    row.Item("contrato_id") = System.DBNull.Value
                    row.Item("descripcion") = reader("nombre_servicio")
                    row.Item("cantidad") = cantidad
                    row.Item("hotel_id") = hotel_id
                    row.Item("precio") = precio
                    row.Item("precio_produccion") = 0
                    row.Item("impuesto_id") = reader("impuesto_id")
                    row.Item("porc_impuesto") = reader("porcentaje")
                    row.Item("servicio_id") = reader("servicio_id")
                    row.Item("unidad_calculo_id") = 1
                    row.Item("tipo_linea_factura") = "M"

                    actualizarLineas(fac)
                End While
            Catch ex As Exception
                fac = Nothing
            End Try
            Return fac
        End Function
        Private Function ActualizarAnticipo(ByVal cmd As Odbc.OdbcCommand, ByVal anticipo_id As Integer)
            Dim retVal As Integer = -1
            Dim errorCode As Integer = 0

            Dim anticipo_idParam As New Odbc.OdbcParameter("@anticipo_id", anticipo_id)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(anticipo_idParam)

            Dim ref2 As Object
            Dim reader As DataTableReader = getDataTable(cmd, sqlObtieneMovAnticipos)
            While reader.Read And errorCode = 0
                If CrearMovimientoCaja(cmd, reader("tipo_movimiento_id"), reader("fecha"), reader("caja_id"), reader("importe"), reader("anticipo_id"), reader("forma_pago_id")) Then
                    'todo crear factura con los datos de ese anticipo                   
                    ref2 = reader("descripcion")
                    Dim fac As Factura = CrearFacturaSencilla(cmd, reader("hotel_id"), reader("cliente_id"), reader("serie_id"), reader("reserva_id"), reader("descripcion"), 1, reader("importe"))
                    If Not IsNothing(fac) Then
                        

                        'cobrar esa factura con lo ke krea movimiento de caja
                        If CambiarEstadoFactura(cmd, fac.factura_id, 1, False) Then
                            'actualiza el anticipo de nulo a cero
                            'que pasa si no era de reserva?
                            'If reader("serie_id") = 5 And Not reader.IsDBNull(reader.GetOrdinal("reserva_id")) Then
                            ' Garra de Javier.....Cambio ref2 a los anticipos y depositos de las reservas
                            If Not reader.IsDBNull(reader.GetOrdinal("reserva_id")) Then
                                Dim dr As DatosReserva = obtieneReservaDatosListados(cmd, reader("reserva_id"))
                                Dim fact As Factura = abreFactura(cmd, fac.factura_id, reader("reserva_id"))
                                ref2 = fact.ds.Tables(0).Rows(0)("numero_factura") & " " & reader("reserva_id")
                                If Not IsNothing(dr) Then
                                    ref2 &= " " & dr.fecha_desde.ToShortDateString & " " & dr.primer_huesped
                                End If
                                fact.ds.Tables(0).Rows(0)("ref_fra2") = ref2

                                If Not (reader.IsDBNull(reader.GetOrdinal("descripcion"))) Then
                                    fact.ds.Tables(0).Rows(0)("ref_fra1") = reader("descripcion")
                                End If

                                Dim writer As Odbc.OdbcDataAdapter
                                writer = getDataAdapter(fact.cmd, sqlCabAbreFactura)
                                writer.Fill(fact.ds.Tables(0))
                                writer.Update(fact.ds.Tables(0))
                            End If

                            Dim tmpret As Boolean = True
                            ' Garra de Javier. En vez de mirar si el tipo de anticipo es = 3 miro si es anticipo o depósito y entonces no va acontabilidad
                            If reader("serie_id") = 4 Then
                                tmpret = CambiarEstadoFactura(cmd, fac.factura_id, 2, False)
                            End If
                            If tmpret Then
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add(anticipo_idParam)
                                If ExecuteNonQuery(cmd, sqlActualizaAnticipoEstadoNulo) = 1 Then
                                    If AsignarFacturaAnticipo(cmd, anticipo_id, fac.factura_id, reader("importe")) Then
                                        If ActualizarLineasAnticipo(cmd, anticipo_id) > 0 Then
                                            'crear factura negativa del anticipo...y dejarla en un estado contabilizado
                                            Dim fac2 As Factura = CrearFacturaSencilla(cmd, reader("hotel_id"), reader("cliente_id"), reader("serie_id"), reader("reserva_id"), ref2, -1, reader("importe"))
                                            If Not IsNothing(fac2) Then
                                                If CambiarEstadoFactura(cmd, fac2.factura_id, 1, False) Then
                                                    If CambiarEstadoFactura(cmd, fac2.factura_id, 2, False) Then
                                                        'todo oks
                                                    Else
                                                        errorCode = 1
                                                        AgregaInfo("ActualizarAnticipo", "No puedo contabilizar segunda factura del anticipo:" & anticipo_id, -errorCode)

                                                    End If
                                                Else
                                                    errorCode = 2
                                                    AgregaInfo("ActualizarAnticipo", "No puedo actualizar segunda factura del anticipo:" & anticipo_id, -errorCode)

                                                End If
                                            Else
                                                errorCode = 3
                                                AgregaInfo("ActualizarAnticipo", "No puedo crear segunda factura del anticipo:" & anticipo_id, -errorCode)
                                            End If
                                        Else
                                            errorCode = 4
                                            AgregaInfo("ActualizarAnticipo", "No puedo asignar factura al anticipo:" & anticipo_id, -errorCode)
                                        End If
                                    Else
                                        errorCode = 5
                                        AgregaInfo("ActualizarAnticipo", "No puedo asignar factura al anticipo:" & anticipo_id, -errorCode)
                                    End If
                                Else
                                    'no pude cambiar el estado del anticipo
                                    errorCode = 6
                                    AgregaInfo("ActualizarAnticipo", "No puedo cambiar el estado del anticipo:" & anticipo_id, -errorCode)
                                End If
                            Else
                                errorCode = 7
                                AgregaInfo("ActualizarAnticipo", "No puedo contabilizar factura del anticipo:" & anticipo_id, -errorCode)
                            End If
                        Else
                            errorCode = 8
                            AgregaInfo("ActualizarAnticipo", "No puedo actualizar factura del anticipo:" & anticipo_id, -errorCode)
                        End If
                    Else
                        'no pude cambiar el estado del anticipo
                        errorCode = 9
                        AgregaInfo("ActualizarAnticipo", "No puedo crear factura del anticipo:" & anticipo_id, -errorCode)

                    End If


                Else
                    'no puedo crear movimiento de caja
                    'caja ya cerrada para esa fecha
                    errorCode = 9
                    AgregaInfo("ActualizarAnticipo", "No puedo crear movimiento de caja:" & anticipo_id, -errorCode)
                End If
            End While


            Return errorCode
        End Function
        Private Function ActualizarAnticipoOld(ByVal cmd As Odbc.OdbcCommand, ByVal anticipo_id As Integer)
            Dim retVal As Integer = -1
            Dim errorCode As Integer = 0

            Dim anticipo_idParam As New Odbc.OdbcParameter("@anticipo_id", anticipo_id)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(anticipo_idParam)


            Dim reader As DataTableReader = getDataTable(cmd, sqlObtieneMovAnticipos)
            While reader.Read And errorCode = 0
                If CrearMovimientoCaja(cmd, reader("tipo_movimiento_id"), reader("fecha"), reader("caja_id"), reader("importe"), reader("anticipo_id"), reader("forma_pago_id")) Then
                    'actualiza el anticipo de nulo a cero
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(anticipo_idParam)
                    If ExecuteNonQuery(cmd, sqlActualizaAnticipoEstadoNulo) = 1 Then
                    Else
                        'no pude cambiar el estado del anticipo
                        errorCode = 2
                        AgregaInfo("ActualizarAnticipo", "No puedo cambiar el estado del anticipo:" & anticipo_id, -errorCode)
                    End If
                Else
                    'no puedo crear movimiento de caja
                    'caja ya cerrada para esa fecha
                    errorCode = 1
                    AgregaInfo("ActualizarAnticipo", "No puedo crear movimiento de caja:" & anticipo_id, -errorCode)
                End If
            End While


            Return errorCode
        End Function
        Public Function ActualizarLineasAnticipo(ByVal anticipo_id As Integer)
            Dim retVal As Integer = -1
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = ActualizarLineasAnticipo(cmd, anticipo_id)
            flushConection(cmd, errorCode)
            Return retVal
        End Function
        Private Function ActualizarLineasAnticipo(ByVal cmd As Odbc.OdbcCommand, ByVal anticipo_id As Integer) As Integer
            Dim retVal As Integer = -1
            Dim errorCode As Integer = 0
            Dim cobro_id As Integer = CrearCobro(cmd, anticipo_id)
            If cobro_id > 0 Then
                Dim pudoactualizarcobro As Boolean = CambiarEstadoCobro(cmd, cobro_id, 1, False)
                If pudoactualizarcobro Then
                    'todo correcto
                    retVal = cobro_id
                Else
                    'no se pudo actualizar el cobro
                    errorCode = 1
                    AgregaInfo("ActualizarLineasAnticipo", "No se pudo actualizar el cobro:" & anticipo_id, -errorCode)
                End If
            Else
                'no se pudo crear cobro
                errorCode = 2
                AgregaInfo("ActualizarLineasAnticipo", "No se pudo crear cobro:" & anticipo_id, -errorCode)
            End If


            Return retVal
        End Function
        Shared sqlObtieneFacturasReserva = "" _
& " SELECT DISTINCT" _
& " lineas_factura.factura_id, " _
& " facturas.Cliente_Id, " _
& " formas_de_pago.credito " _
& " FROM " _
& " lineas_factura " _
& " Inner Join facturas ON lineas_factura.factura_id = facturas.Factura_Id " _
& " Inner Join formas_de_pago ON facturas.Forma_Pago_Id = formas_de_pago.forma_pago_id " _
& " WHERE " _
& " lineas_factura.reserva_id = ? AND " _
& " facturas.Estado_Factura_Id >=  1 " _
& " group by  lineas_factura.factura_id,  facturas.Cliente_Id,  formas_de_pago.credito" _
& " order by  sum(lineas_factura.cantidad*lineas_factura.precio) asc "

        Shared sqlObtieneAnticiposReserva = "" _
& " SELECT " _
& " anticipos.anticipo_id,anticipos.hotel_id,anticipos.caja_id,anticipos.forma_pago_id, " _
& " anticipos.cliente_id, " _
& " ifnull((anticipos.importe*(anticipos.tipo_anticipo_id=1))-ifnull((select sum(l.Importe) from lineas_anticipo l where l.anticipo_id=anticipos.anticipo_id ),0)-ifnull((select sum(a.importe) from anticipos a where a.anticipo_padre_id=anticipos.anticipo_id),0),0) as pendiente " _
& " FROM " _
& " anticipos " _
& " WHERE " _
& " anticipos.reserva_id =  ? "
        Shared sqlLineaAnticipos = "select * from lineas_anticipo where anticipo_id=?"
        Shared sqlAnticipos = "select * from anticipos where 1=0"
        Function DevolverAnticiposReserva(ByVal reserva_id As Integer)
            Dim retVal As Single = 0
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            'retVal = ObtienePendienteAnticipoReserva(cmd, reserva_id)
            'If retVal > 0 Then
            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(reserva_idParam)
            Dim readerAnticipos As DataTableReader = getDataTable(cmd, sqlObtieneAnticiposReserva)
            Dim ds As DataSet = getDataSet(cmd, sqlAnticipos)
            Dim fecha As Date
            Dim fechaset As Boolean = False
            While readerAnticipos.Read And errorCode = 0
                Dim pend As Single = readerAnticipos("pendiente")
                If pend > 0 Then
                    'crear anticipo
                    Dim row As DataRow = ds.Tables(0).Rows.Add
                    If fechaset = False Then
                        'carga la fecha del hotel una sola vez
                        fecha = FechaHotel(cmd, readerAnticipos("hotel_id"))
                        fechaset = True
                    End If
                    row("hotel_id") = readerAnticipos("hotel_id")
                    row("tipo_anticipo_id") = 2
                    row("reserva_id") = reserva_id
                    row("cliente_id") = readerAnticipos("cliente_id")
                    row("caja_id") = readerAnticipos("caja_id")
                    row("importe") = pend

                    row("forma_pago_id") = readerAnticipos("forma_pago_id")
                    'row("estado_id") = 1
                    row("anticipo_padre_id") = readerAnticipos("anticipo_id")
                    row("user_id") = Me.userId
                    row("fecha_modificacion") = Now
                    'acelerar
                    row("fecha") = fecha

                    Dim writer As Odbc.OdbcDataAdapter
                    writer = getDataAdapter(cmd, sqlAnticipos)
                    writer.Fill(ds.Tables(0))
                    writer.Update(ds.Tables(0))
                    Dim anticipo_id As Integer = ExecuteScalar(cmd, "SELECT LAST_INSERT_ID()")
                    If anticipo_id <> 0 Then
                        'actualizar anticipo
                        errorCode = ActualizarAnticipo(cmd, anticipo_id)
                        AgregaInfo("DevolverAnticiposReserva", "Actualizando Anticipo:" & anticipo_id, -errorCode)
                    Else
                        errorCode = 10 'no inserto el registro
                        AgregaInfo("DevolverAnticiposReserva", "No pudo crear la devolucion:" & anticipo_id, -errorCode)
                    End If

                End If
            End While
            'End If
            flushConection(cmd, errorCode)
            Return retVal

        End Function
        Private Function AsignarFacturaAnticipo(ByVal cmd As Odbc.OdbcCommand, ByVal anticipo_id As Integer, ByVal factura_id As Integer, ByVal importe As Single) As Boolean
            Dim retval As Boolean = False
            Try
                Dim anticipo_idParam As New Odbc.OdbcParameter("@anticipo_id", anticipo_id)
                cmd.Parameters.Clear()
                cmd.Parameters.Add(anticipo_idParam)
                Dim ds As DataSet = getDataSet(cmd, sqlLineaAnticipos)
                Dim row As DataRow = ds.Tables(0).Rows.Add
                row.Item("Anticipo_Id") = anticipo_idParam.Value
                row.Item("Factura_Id") = factura_id
                row.Item("Importe") = importe 'obtieneImportePendienteFactura(cmd, factura_id)
                row.Item("estado") = 0
                row.Item("user_id") = userId
                row.Item("fecha_actualizacion") = Now
                Dim writer As Odbc.OdbcDataAdapter
                writer = getDataAdapter(cmd, sqlLineaAnticipos)
                writer.Fill(ds.Tables(0))
                writer.Update(ds.Tables(0))
                retval = True
            Catch ex As Exception

            End Try
            Return retval
        End Function
        Private Function ObtieneFacturasPendientesReserva(ByVal cmd As Odbc.OdbcCommand, ByVal reserva_id As Integer, Optional ByVal contado As Boolean = False) As String
            Dim retVal As String = ""
            Dim errorCode As Integer = 0

            Try
                Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
                cmd.Parameters.Clear()
                cmd.Parameters.Add(reserva_idParam)
                Dim reader As DataTableReader = getDataTable(cmd, sqlObtieneFacturasReserva)
                Dim puedo As Boolean = True
                While reader.Read
                    If reader.Item("credito") And contado Then
                        puedo = False
                    Else
                        puedo = True
                    End If
                    If puedo And obtieneImportePendienteFactura(cmd, CInt(reader.Item("factura_id"))) <> 0 Then
                        If retVal = "" Then
                            retVal = (reader.Item("factura_id"))
                        Else
                            retVal &= "," & (reader.Item("factura_id"))
                        End If
                    End If
                End While

            Catch ex As Exception
                retVal = Nothing
                errorCode = 1
            End Try

            Return retVal
        End Function
        Public Function ObtieneFacturasPendientesReserva(ByVal reserva_id As Integer, Optional ByVal contado As Boolean = False) As String
            Dim retVal As String = ""
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = ObtieneFacturasPendientesReserva(cmd, reserva_id, contado)
            If IsNothing(retVal) Then
                errorCode = 1
                retVal = ""
            End If
            flushConection(cmd, errorCode)
            Return retVal
        End Function

        Public Sub AsignarAnticiposReserva(ByVal reserva_id As Integer)
            Dim retVal As Integer = -1
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()


            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(reserva_idParam)
            Dim readerAnticipos As DataTableReader = getDataTable(cmd, sqlObtieneAnticiposReserva)
            Dim dsreader As DataSet = getDataSet(cmd, sqlObtieneFacturasReserva)

            Dim anticipo_idParam As New Odbc.OdbcParameter("@anticipo_id", 0)
            Dim totalasignado As Single = 0
            While readerAnticipos.Read
                Dim pend As Single = readerAnticipos.Item("pendiente")
                If pend > 0 Then
                    anticipo_idParam.Value = readerAnticipos.Item("anticipo_id")
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(anticipo_idParam)
                    Dim ds As DataSet = getDataSet(cmd, sqlLineaAnticipos)
                    Dim reader As DataTableReader = dsreader.Tables(0).CreateDataReader
                    While pend > 0 And reader.Read
                        If reader.Item("cliente_id") = readerAnticipos.Item("cliente_id") Then
                            Dim importe As Single = obtieneImportePendienteFactura(cmd, CInt(reader.Item("factura_id")))
                            If importe > 0 Then
                                If importe > pend Then
                                    importe = pend
                                End If
                                'meter una linea al anticipo
                                Dim row As DataRow = ds.Tables(0).Rows.Add
                                row.Item("Anticipo_Id") = anticipo_idParam.Value
                                row.Item("Factura_Id") = reader.Item("factura_id")
                                row.Item("Importe") = importe
                                row.Item("estado") = 0
                                row.Item("user_id") = userId
                                row.Item("fecha_actualizacion") = Now
                                pend -= importe
                                totalasignado += importe
                            End If
                        End If
                    End While
                    Dim writer As Odbc.OdbcDataAdapter
                    writer = getDataAdapter(cmd, sqlLineaAnticipos)
                    writer.Fill(ds.Tables(0))
                    writer.Update(ds.Tables(0))

                    If ActualizarLineasAnticipo(cmd, readerAnticipos.Item("anticipo_id")) > 0 Then
                    Else
                        errorCode = 1
                    End If
                End If
            End While
            If totalasignado = 0 Then
                AgregaInfo("AsignarAnticiposReserva", "No asigno los anticipos a reserva(falta de facturas=" & reserva_id, -errorCode)
            End If
            If errorCode <> 0 Then
                AgregaInfo("AsignarAnticiposReserva", "Fallo al asignar los anticipos de la reserva:" & reserva_id, -errorCode)
            End If
            flushConection(cmd, errorCode)
        End Sub
        Shared sqlLimpiezas = "select * from limpiezas where 1=0"
        Public Function crearLimpiezas(ByVal hotel_id As Integer, ByVal fecha As Date) As Boolean
            Dim retval As Boolean = True
            Dim dssource As DataSet = obtienenLimpiezas(hotel_id, fecha, 1)
            If Not IsNothing(dssource) Then
                Dim errorCode As Integer = 0
                Dim cmd As Odbc.OdbcCommand = prepareConection()
                Try
                    Dim ds As DataSet = getDataSet(cmd, sqlLimpiezas)
                    Dim tabla As DataTable = ds.Tables(0)
                    Dim stabla As DataTable = dssource.Tables(0)
                    Dim xc As Integer = stabla.Rows.Count - 1
                    Dim x As Integer
                    Dim row As DataRow
                    For x = 0 To x < xc
                        If stabla.Rows(x)("item_limpieza_id") <> 0 Then
                            row = tabla.Rows.Add
                            row("habitacion_id") = stabla.Rows(x)("habitacion_id")
                            row("reserva_id") = stabla.Rows(x)("reserva_id")
                            row("item_limpieza_id") = stabla.Rows(x)("item_limpieza_id")
                            row("fecha") = fecha
                            row("user_id") = Me.userId
                        End If
                    Next
                    Dim writer As Odbc.OdbcDataAdapter
                    writer = getDataAdapter(cmd, sqlLimpiezas)
                    writer.Fill(tabla)
                    writer.Update(tabla)
                Catch ex As Exception
                    errorCode = 1
                    retval = False
                End Try
                flushConection(cmd, errorCode)
            End If
            Return retval
        End Function
        Shared sqlObtieneLimpiezasPorHabitacionVacias = "" _
& " SELECT ifnull(reservas.fecha_llegada,reservas.fecha_prevista_llegada) as llegada,ifnull(reservas.fecha_salida,reservas.fecha_prevista_salida) as salida,ifnull(reservas.hora_prevista_llegada,cast(STR_TO_DATE('0','%s') as time)) as hora_llegada,ifnull(reservas.hora_prevista_salida,cast(STR_TO_DATE('0','%s') as time)) as hora_salida,'razon' as razon,0 as pax,0 as bebes,0 AS estado,1 as cliente_id,reservas.cliente_id as cliente_id_limpieza," _
& "   habitaciones.habitacion_id,  " _
& "   -1 as reserva_id,  " _
& "   0 as item_limpieza_id,   " _
& "         'VACIA' as item_limpieza, " _
& "   habitaciones.numero_habitacion, ifnull(convert(habitaciones.numero_habitacion , unsigned),0) as nhab, " _
& "  7 as cambios_semana,   " _
& "   0 as primer_dia,   " _
& "   0 as sucesivos_cambios,   " _
& "   1 as lunes,  " _
& "   1 as martes,   " _
& "   1 as miercoles,   " _
& "  1 as  jueves,   " _
& "   1 as viernes,   " _
& "   1 as sabado,   " _
& "   1 as domingo,   " _
& "   reservas.fecha_prevista_llegada   " _
& "   FROM   " _
& " 	habitaciones left join habitaciones_bloqueos ON habitaciones_bloqueos.tipo_bloqueo_id = 1 and habitaciones_bloqueos.habitacion_id = habitaciones.habitacion_id and ? between habitaciones_bloqueos.fecha_desde and (habitaciones_bloqueos.fecha_hasta- interval 1 day) " _
& "     	left Join reservas ON habitaciones_bloqueos.reserva_id = reservas.reserva_id  and  reservas.estado_reserva_id=3 " _
& "   WHERE   " _
& "   habitaciones.hotel_id=? " _
& "    and reservas.reserva_id is null " _
& "   order by nhab  "

        Shared sqlObtieneLimpiezasPorHabitacionDiaLlegadasSalidas = "" _
& "SELECT ifnull(reservas.fecha_llegada,reservas.fecha_prevista_llegada) as llegada,ifnull(reservas.fecha_salida,reservas.fecha_prevista_salida) as salida,ifnull(reservas.hora_prevista_llegada,cast(STR_TO_DATE('0','%s') as time)) as hora_llegada,ifnull(reservas.hora_prevista_salida,cast(STR_TO_DATE('0','%s') as time)) as hora_salida,'razon' as razon,0 as pax,0 as bebes,0 AS estado,1 as cliente_id,reservas.cliente_id as cliente_id_limpieza," _
& "  habitaciones_bloqueos.habitacion_id, " _
& "  habitaciones_bloqueos.reserva_id, " _
& "  items_limpieza.item_limpieza_id,  " _
& "  items_limpieza.item_limpieza,  " _
& "  habitaciones.numero_habitacion, ifnull(convert(habitaciones.numero_habitacion , unsigned),0) as nhab,  " _
& " 7 as cambios_semana,  " _
& "  0 as primer_dia,  " _
& "  0 as sucesivos_cambios, " _
& "  1 as lunes, " _
& "  1 as martes,  " _
& "  1 as miercoles,  " _
& " 1 as  jueves,  " _
& "  1 as viernes,  " _
& "  1 as sabado,  " _
& "  1 as domingo,  " _
& "  reservas.fecha_prevista_llegada  " _
& "  FROM  " _
& "  habitaciones_bloqueos  " _
& "  Inner Join reservas ON habitaciones_bloqueos.reserva_id = reservas.reserva_id  " _
& "  Inner Join items_limpieza ON items_limpieza.sw_llegada=1 or items_limpieza.sw_salida=1 " _
& "  Inner Join habitaciones ON habitaciones_bloqueos.habitacion_id = habitaciones.habitacion_id " _
& "  WHERE  " _
& " reservas.estado_reserva_id<>2 and  " _
& "  habitaciones_bloqueos.tipo_bloqueo_id = 1 AND  " _
& "  (       ? =  habitaciones_bloqueos.fecha_desde and items_limpieza.sw_llegada=1 " _
& " or " _
& "         ? =  habitaciones_bloqueos.fecha_hasta and items_limpieza.sw_salida=1 )" _
& "  and habitaciones.hotel_id=? " _
& "  and ? in (0,items_limpieza.item_limpieza_id)" _
& "  and ? in (0,habitaciones_bloqueos.habitacion_id) order by nhab "

        Shared sqlObtieneLimpiezasPorHabitacionDia = "" _
& " SELECT ifnull(reservas.fecha_llegada,reservas.fecha_prevista_llegada) as llegada,ifnull(reservas.fecha_salida,reservas.fecha_prevista_salida) as salida,ifnull(reservas.hora_prevista_llegada,cast(STR_TO_DATE('0','%s') as time)) as hora_llegada,ifnull(reservas.hora_prevista_salida,cast(STR_TO_DATE('0','%s') as time)) as hora_salida,'razon' as razon,0 as pax,0 as bebes,0 AS estado,1 as cliente_id,clientes_limpieza.cliente_id as cliente_id_limpieza," _
& " habitaciones_bloqueos.habitacion_id," _
& " habitaciones_bloqueos.reserva_id," _
& " items_limpieza.item_limpieza_id, " _
& " items_limpieza.item_limpieza, " _
& " habitaciones.numero_habitacion, ifnull(convert(habitaciones.numero_habitacion , unsigned),0) as nhab, " _
& " clientes_limpieza.cambios_semana, " _
& " clientes_limpieza.primer_dia, " _
& " clientes_limpieza.sucesivos_cambios," _
& " clientes_limpieza.lunes," _
& " clientes_limpieza.martes, " _
& " clientes_limpieza.miercoles, " _
& " clientes_limpieza.jueves, " _
& " clientes_limpieza.viernes, " _
& " clientes_limpieza.sabado, " _
& " clientes_limpieza.domingo, " _
& " reservas.fecha_prevista_llegada " _
& " FROM " _
& " habitaciones_bloqueos " _
& " Inner Join reservas ON habitaciones_bloqueos.reserva_id = reservas.reserva_id " _
& " Inner Join clientes_limpieza ON reservas.hotel_id = clientes_limpieza.hotel_id AND (reservas.cliente_id = clientes_limpieza.cliente_id or clientes_limpieza.cliente_id=? )  " _
& " Inner Join items_limpieza ON items_limpieza.item_limpieza_id = clientes_limpieza.item_limpieza_id " _
& " Inner Join habitaciones ON habitaciones_bloqueos.habitacion_id = habitaciones.habitacion_id AND habitaciones.tipo_habitacion_id = clientes_limpieza.tipo_habitacion_id " _
& " WHERE " _
& " habitaciones_bloqueos.tipo_bloqueo_id = 1 AND " _
& "         ? BETWEEN  habitaciones_bloqueos.fecha_desde AND  habitaciones_bloqueos.fecha_hasta " _
& " and habitaciones.hotel_id=? " _
& " and ? in (0,items_limpieza.item_limpieza_id)" _
& " and ? in (0,habitaciones_bloqueos.habitacion_id) order by nhab"
        Shared sqlObtieneLimpiezasHechas = "" _
& " SELECT " _
& " limpiezas.fecha" _
& " FROM " _
& " limpiezas " _
        & " WHERE " _
        & " yearweek(limpiezas.fecha)=yearweek(?) and " _
        & " limpiezas.habitacion_id =  ? AND " _
        & " limpiezas.reserva_id =  ? AND  " _
        & " limpiezas.item_limpieza_id =  ?"
        Shared sqlObtieneLimpiezasHechasReservas = "" _
& " SELECT " _
& " limpiezas.*" _
& " FROM " _
& " limpiezas " _
& " WHERE " _
& " yearweek(limpiezas.fecha)=yearweek(?) "


        Public Function obtienenLimpiezas(ByVal hotel_id As Integer, ByVal fecha As Date, ByVal estado As Integer, Optional ByVal item_limpieza_id As Integer = 0, Optional ByVal habitacion_id As Integer = 0, Optional ByVal habitacion_desde As Integer = 0, Optional ByVal habitacion_hasta As Integer = 0) As DataSet
            'Dim retVal As Integer
            
            Dim cacheDR As New Hashtable
            Dim errorCode As Integer = 0
            Dim ds As DataSet
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try

            
                Dim cliente_defecto_id As Integer = 16 'obtener el cliente extra contado?
                Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
                Dim fecha1Param As New Odbc.OdbcParameter("@fecha1", fecha)
                Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
                Dim habitacion_idParam As New Odbc.OdbcParameter("@habitacion_id", habitacion_id)
                Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", 1)
                Dim item_limpieza_idParam As New Odbc.OdbcParameter("@item_limpieza_id", item_limpieza_id)
                Dim cliente_defecto_idParam As New Odbc.OdbcParameter("@cliente_defecto_id", cliente_defecto_id)
                'Dim item_limpieza_idParam1 As New Odbc.OdbcParameter("@item_limpieza_id1", item_limpieza_id)

                


                cmd.Parameters.Clear()
                'cmd.Parameters.Add(fecha1Param)
                cmd.Parameters.Add(cliente_defecto_idParam)
                cmd.Parameters.Add(fechaParam)
                cmd.Parameters.Add(hotel_idParam)
                cmd.Parameters.Add(item_limpieza_idParam)
                cmd.Parameters.Add(habitacion_idParam)
                'cmd.Parameters.Add(item_limpieza_idParam1)
                ds = getDataSet(cmd, sqlObtieneLimpiezasPorHabitacionDia)
                cmd.Parameters.Clear()
                'cmd.Parameters.Add(fecha1Param)
                'cmd.Parameters.Add(cliente_defecto_idParam)
                cmd.Parameters.Add(fechaParam)
                cmd.Parameters.Add(fecha1Param)
                cmd.Parameters.Add(hotel_idParam)
                cmd.Parameters.Add(item_limpieza_idParam)
                cmd.Parameters.Add(habitacion_idParam)
                'cmd.Parameters.Add(item_limpieza_idParam1)
                Dim dsls As DataSet = getDataSet(cmd, sqlObtieneLimpiezasPorHabitacionDiaLlegadasSalidas)

                cmd.Parameters.Clear()
                cmd.Parameters.Add(fechaParam)
                cmd.Parameters.Add(hotel_idParam)
                Dim dsvac As DataSet = getDataSet(cmd, sqlObtieneLimpiezasPorHabitacionVacias)

                Dim x As Integer = 0
                Dim hab As Integer

                Dim filas As DataRowCollection
                Dim xc As Integer
                'todo en vez de borrar..mezclar y usar la id mas grande
                Dim ultstr As String = ""

                filas = dsvac.Tables(0).Rows
                xc = filas.Count - 1

                For x = 0 To xc
                    hab = filas(x).Item("habitacion_id")
                    filas(x)("item_limpieza") = concatenarColumna(ds.Tables(0), "reserva_id<>0 and habitacion_id=" & hab, "item_limpieza", "item_limpieza_id desc", filas(x)("item_limpieza"), filas(x)("item_limpieza_id"))
                    borrarDeTabla(ds.Tables(0), "reserva_id<>0 and habitacion_id=" & hab, True)

                    ds.Tables(0).Rows.Add(filas(x).ItemArray)
                Next

                filas = dsls.Tables(0).Rows
                xc = filas.Count - 1
                For x = 0 To xc
                    hab = filas(x).Item("habitacion_id")
                    filas(x)("item_limpieza") = concatenarColumna(ds.Tables(0), "reserva_id<>0 and habitacion_id=" & hab, "item_limpieza", "item_limpieza_id desc", filas(x)("item_limpieza"), filas(x)("item_limpieza_id"))
                    borrarDeTabla(ds.Tables(0), "reserva_id<>0 and habitacion_id=" & hab, True)

                    ds.Tables(0).Rows.Add(filas(x).ItemArray)
                Next


                Dim camposDias() As String = {"Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo"}


                If habitacion_desde <> 0 Or habitacion_hasta <> 0 Then
                    'todo habitacion desde-habitacion hasta
                    If habitacion_desde > habitacion_hasta Then
                        Dim tmp = habitacion_hasta
                        habitacion_hasta = habitacion_desde
                        habitacion_desde = tmp
                    End If
                    borrarDeTabla(ds.Tables(0), "not (nhab>=" & habitacion_desde & " and nhab<=" & habitacion_hasta & ")", False)
                    ds.Tables(0).AcceptChanges()
                End If
                ds.Tables(0).AcceptChanges()
                'quitar del resultado cuando existan 2 lineas iguales la que tiene el cliente por defecto

                'procesa linea a linea si se puede usar
                filas = ds.Tables(0).Rows

                Dim tipof As Integer = 0
                Dim tablahabs As New Hashtable
                Dim tablahabsele As New Hashtable
                'todo si cliente no tiene limpieza...usar el cliente por defecto
                xc = filas.Count - 1


                For x = 0 To xc
                    If filas(x)("reserva_id") <> 0 Then
                        Dim eliminar As Integer = 0
                        hab = filas(x).Item("habitacion_id")
                        If tablahabs.ContainsKey(hab) Then
                            If tablahabs(hab) = cliente_defecto_id Then

                                'si cliente es distinto de cliente defecto
                                'me cepillo todos los clientes distintos 
                                If (tablahabs(hab) <> filas(x).Item("cliente_id_limpieza")) Then
                                    eliminar = cliente_defecto_id
                                End If
                                tablahabs(hab) = filas(x).Item("cliente_id_limpieza")
                            Else
                                If (tablahabs(hab) <> filas(x).Item("cliente_id_limpieza")) Then
                                    eliminar = filas(x).Item("cliente_id_limpieza")
                                End If
                            End If
                            If eliminar <> 0 Then
                                borrarDeTabla(ds.Tables(0), "reserva_id<>0 and habitacion_id=" & hab & " and cliente_id_limpieza=" & eliminar, False, "reserva_id", 0)
                            End If
                        Else
                            tablahabs(hab) = filas(x).Item("cliente_id_limpieza")
                        End If
                    End If
                Next
                borrarDeTabla(ds.Tables(0), "reserva_id=0", False)
                ds.Tables(0).AcceptChanges()
                If 1 = 0 Then


                    Dim enu As IEnumerator = tablahabs.Keys.GetEnumerator()
                    Dim borrarkeys As String = ""
                    While enu.MoveNext
                        If borrarkeys <> "" Then
                            borrarkeys &= " or "
                        End If
                        borrarkeys &= "(habitacion_id=" & enu.Current & " and cliente_id_limpieza=" & tablahabs(enu.Current) & ")"
                    End While
                    If Not borrarkeys = "" Then
                        Console.WriteLine(borrarkeys.Length)
                        borrarDeTabla(ds.Tables(0), "not (" & borrarkeys & ")", False)
                        ds.Tables(0).AcceptChanges()
                        'Console.WriteLine(borrarkeys)
                    End If
                End If

                cmd.Parameters.Clear()
                cmd.Parameters.Add(fechaParam)
                Dim datoslimp As DataSet = getDataSet(cmd, sqlObtieneLimpiezasHechasReservas)
                'cmd.Parameters.Add(habitacion_idParam)
                'cmd.Parameters.Add(reserva_idParam)
                'cmd.Parameters.Add(item_limpieza_idParam)


                Dim dv As New DataView(datoslimp.Tables(0), "", "", DataViewRowState.CurrentRows)
                xc = filas.Count - 1
                For x = 0 To xc
                    
                    
                    'leer esa semana completa para la primera fila
                    'Console.WriteLine(cmd.Parameters.Count)
                    Dim borrar As Boolean = False
                    Dim nreg As Integer = 0
                    If 0 = 0 Then
                        dv.RowFilter = "habitacion_id=" & filas(x).Item("habitacion_id") & " and reserva_id=" & filas(x).Item("reserva_id") & " and item_limpieza_id=" & filas(x).Item("item_limpieza_id")
                        Dim datos As New DataTableReader(dv.ToTable)
                        'habitacion_idParam.Value = CInt(filas(x).Item("habitacion_id"))
                        'reserva_idParam.Value = filas(x).Item("reserva_id")
                        'item_limpieza_idParam.Value = filas(x).Item("item_limpieza_id")
                        'Dim datos As DataTableReader = getDataTable(cmd, sqlObtieneLimpiezasHechas)

                        'Dim matDias(7) As Boolean
                        'Dim fd As Date
                        While datos.Read
                            'fd = 
                            If datos("fecha") = fecha Then
                                filas(x).Item("estado") = 1
                                borrar = True
                            End If
                            'todo solo de la semana en curso
                            'matDias(Weekday(fd, FirstDayOfWeek.Monday)) = True
                            'todo solo de la semana en curso
                            nreg += 1
                        End While
                        datos.Close()
                        datos = Nothing
                        'dv.Dispose()
                        'dv = Nothing
                    End If
                    'si para el dia de hoy ya existe registro borrarlo
                    'comprobar tipo de fechas
                    If Not borrar Then
                        If filas(x).IsNull("cambios_semana") OrElse filas(x)("cambios_semana") = 0 Then
                            If filas(x).IsNull("primer_dia") OrElse filas(x)("primer_dia") = 0 Then
                                tipof = 2   'lun-dom
                            Else
                                tipof = 1   'prim-suce
                            End If
                        Else
                            tipof = 0   'semana
                        End If
                        Select Case tipof
                            Case 0
                                If nreg >= filas(x)("cambios_semana") Then
                                    borrar = True
                                Else
                                    borrar = False
                                End If
                            Case 1
                                Dim dlleg As Date = filas(x)("fecha_prevista_llegada")
                                If dlleg.AddDays(filas(x)("primer_dia")) = fecha Then
                                    borrar = False
                                Else
                                    borrar = True
                                    'cambiar while por modulo
                                    While dlleg < fecha And filas(x)("sucesivos_cambios") > 0
                                        dlleg = dlleg.AddDays(filas(x)("sucesivos_cambios"))
                                        If dlleg = fecha Then
                                            borrar = False
                                        End If
                                    End While
                                End If
                            Case 2
                                If filas(x)(camposDias(Weekday(fecha, Microsoft.VisualBasic.FirstDayOfWeek.Monday) - 1)) = 0 Then
                                    borrar = True
                                End If
                        End Select
                        If filas(x)(camposDias(Weekday(fecha, Microsoft.VisualBasic.FirstDayOfWeek.Monday) - 1)) = 0 Then
                            borrar = True
                        End If
                    End If
                    'si es la ultima linea ke existe de esa habitacion
                    'en vez de borrarla poner "NADA" y dejarla para ke la gobernanta lo vea...
                    If borrar And Not (filas(x).Item("estado") = 1 And estado = 0) Then
                        Dim num = ds.Tables(0).Compute("count(habitacion_id)", "habitacion_id=" & filas(x)("habitacion_id") & " and reserva_id<>0")
                        If num <> 1 Then
                            filas(x)("reserva_id") = 0
                        Else
                            filas(x)("item_limpieza") = " "
                            filas(x)("item_limpieza_id") = "0"
                        End If

                    Else
                    End If
                    If filas(x)("reserva_id") <> 0 Then
                        'todo cachear o usar funcion de cacheo
                        filas(x)("razon") = " "
                        filas(x)("pax") = 0
                        filas(x)("bebes") = 0
                        If 0 = 0 Then
                            Dim dr As DatosReserva
                            If cacheDR.ContainsKey(filas(x).Item("reserva_id")) Then
                                dr = cacheDR(filas(x).Item("reserva_id"))
                            Else
                                dr = obtieneReservaDatosListados(cmd, filas(x).Item("reserva_id"), fecha)
                                cacheDR(filas(x).Item("reserva_id")) = dr
                            End If

                            filas(x)("razon") = dr.primer_huesped
                            filas(x)("pax") = dr.pax
                            filas(x)("bebes") = dr.b
                        End If
                    End If
                    'ds.Tables(0).AcceptChanges()
                Next
                borrarDeTabla(ds.Tables(0), "reserva_id=0", False)
                ds.Tables(0).AcceptChanges()

                Dim dvk As New DataView(ds.Tables(0), "", "nhab", DataViewRowState.CurrentRows)
                ds = New DataSet()

                ds.Tables.Add(dvk.ToTable())

                Dim campos As New ArrayList()
                campos.Add("nhab")
                campos.Add("item_limpieza")
                dumpDataTable(ds.Tables(0).Select(""), campos)
            Catch ex As Exception
                errorCode = 1
                ds = Nothing
            End Try
            flushConection(cmd, errorCode)
            'todo eliminar las filas borradas?
            'ds = Nothing
            Return ds

        End Function
        Shared sqlObtienetHabitacionesDisponibles = "" _
& " SELECT count(habitaciones.habitacion_id) as habitaciones_disponibles,sum(tipos_habitacion.numero_personas) as CapacidadHotel " _
& " FROM  " _
& " habitaciones inner join tipos_habitacion on habitaciones.tipo_habitacion_id=tipos_habitacion.tipo_habitacion_id " _
& " Left Join habitaciones_bloqueos ON habitaciones.habitacion_id = habitaciones_bloqueos.habitacion_id  " _
& " and (? between habitaciones_bloqueos.fecha_desde and habitaciones_bloqueos.fecha_hasta and habitaciones_bloqueos.reserva_id is null) " _
& " WHERE " _
& " habitaciones.hotel_id =  ? AND " _
& " ( " _
& " habitaciones.fecha_inicio <=  ? " _
& " or habitaciones.fecha_inicio is null) and (habitaciones.tipo_habitacion_id=? or ?=0) and (tipos_habitacion.desvios=0 or 1=?)"
        Private Function ObtieneHabitacionesDisponiblesHotelDia(ByVal cmd As Odbc.OdbcCommand, ByVal hotel_id As Integer, ByVal fechaini As Date, Optional ByVal tipo_habitacion_id As Integer = 0, Optional ByVal sindesvios As Boolean = False) As Integer()
            Dim errorCode As Integer = 0
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            Dim fechainiParam As New Odbc.OdbcParameter("@fechaini", convertFecha(fechaini))
            Dim fechaini1Param As New Odbc.OdbcParameter("@fechaini1", convertFecha(fechaini))
            Dim tipo_habitacion_idParam As New Odbc.OdbcParameter("@tipo_habitacion_id", tipo_habitacion_id)
            Dim tipo_habitacion_id1Param As New Odbc.OdbcParameter("@tipo_habitacion_id1", tipo_habitacion_id)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(fechainiParam)
            cmd.Parameters.Add(hotel_idParam)
            cmd.Parameters.Add(fechaini1Param)
            cmd.Parameters.Add(tipo_habitacion_idParam)
            cmd.Parameters.Add(tipo_habitacion_id1Param)
            Dim todosParam As New Odbc.OdbcParameter("@todos", 0)
            If sindesvios Then
                todosParam.Value = 0
            Else
                todosParam.Value = 1
            End If
            cmd.Parameters.Add(todosParam)
            Dim datos As DataTableReader = Me.getDataTable(cmd, sqlObtienetHabitacionesDisponibles)
            Dim dev(1) As Integer
            dev(0) = 0
            dev(1) = 0
            While datos.Read
                'Return Me.ExecuteScalar(cmd, sqlObtienetHabitacionesDisponibles)
                dev(0) = datos.Item("habitaciones_disponibles")
                Try
                    dev(1) = datos.Item("CapacidadHotel")
                Catch ex As Exception

                End Try

            End While
            Return dev

        End Function
        Private Function ObtieneHabitacionesLibresHotel(ByVal cmd As Odbc.OdbcCommand, ByVal hotel_id As Integer, ByVal fechaini As Date, Optional ByVal fechafin As Date = Nothing, Optional ByVal reserva_id As Integer = 0, Optional ByVal todas As Boolean = False) As DataSet
            Dim errorCode As Integer = 0

            'todo falta reserva

            If fechafin = #12:00:00 AM# Then
                fechafin = fechaini
            End If
            If fechaini > fechafin Then
                Dim ft As Date = fechaini
                fechaini = fechafin
                fechafin = ft
            End If
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            Dim fechainiParam As New Odbc.OdbcParameter("@fechaini", convertFecha(fechaini))
            Dim fechafinParam As New Odbc.OdbcParameter("@fechafin", convertFecha(fechafin))
            Dim fechaini1Param As New Odbc.OdbcParameter("@fechaini1", convertFecha(fechaini))
            Dim fechafin1Param As New Odbc.OdbcParameter("@fechafin1", convertFecha(fechafin))
            Dim fechaini2Param As New Odbc.OdbcParameter("@fechaini2", convertFecha(fechaini))
            Dim fechafin2Param As New Odbc.OdbcParameter("@fechafin2", convertFecha(fechafin))
            Dim todasParam As New Odbc.OdbcParameter("@todas", todas)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(fechainiParam)
            cmd.Parameters.Add(fechafinParam)
            cmd.Parameters.Add(fechaini1Param)
            cmd.Parameters.Add(fechafin1Param)
            cmd.Parameters.Add(fechaini2Param)
            cmd.Parameters.Add(fechafin2Param)
            cmd.Parameters.Add(todasParam)
            cmd.Parameters.Add(hotel_idParam)
            Dim lectorDisp As DataTable = getDataSet(cmd, sqlObtieneHabitacionesDispHotelEntreFechas).Tables(0)
            If Not todas Then
                lectorDisp = getDataSet(cmd, sqlObtieneHabitacionesDispHotelEntreFechas).Tables(0)
                Dim filtroBorrado As String = "fecha_inicio>'" & fechaini & "' or "
                Dim fil1 As String = "  not fecha_desde is null "
                If (reserva_id > 0) Then
                    fil1 = " (( reserva_id is null or reserva_id<>" & reserva_id & ") and " & fil1 & ")"
                End If
                filtroBorrado = filtroBorrado & fil1
                borrarDeTabla(lectorDisp, filtroBorrado)
                lectorDisp.AcceptChanges()
            Else
                cmd.Parameters.Clear()
                cmd.Parameters.Add(hotel_idParam)
                lectorDisp = getDataSet(cmd, sqlObtieneHabitacionesHotel).Tables(0)
            End If
            Return lectorDisp.DataSet
        End Function
        Public Function ObtieneHabitacionesLibresHotel(ByVal reserva_id As Integer, Optional ByVal todas As Boolean = False) As DataSet
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim ds As DataSet = Nothing
            Try
                'todo falta reserva
                'busca hotel de una reserva
                'obtiene fecha inicial,final de una reserva
                Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
                cmd.Parameters.Clear()
                cmd.Parameters.Add(reserva_idParam)
                Dim row As DataRow = getDataSet(cmd, sqlCabReserva).Tables(0).Rows(0)
                ds = ObtieneHabitacionesLibresHotel(cmd, row.Item("hotel_id"), row.Item("fecha_prevista_llegada"), row.Item("fecha_prevista_salida"), reserva_id, todas)
            Catch ex As Exception
                errorCode = -1
            End Try
            flushConection(cmd, errorCode)
            Return ds
        End Function
        Public Function ObtieneHabitacionesLibresHotel(ByVal hotel_id As Integer, ByVal fechaini As Date, Optional ByVal fechafin As Date = Nothing, Optional ByVal reserva_id As Integer = Nothing) As DataSet
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            'todo falta reserva
            Dim ds As DataSet = ObtieneHabitacionesLibresHotel(cmd, hotel_id, fechaini, fechafin, reserva_id)
            flushConection(cmd, errorCode)
            Return ds
        End Function
        '        concatenarColumna(ds.Tables(0), "reserva_id<>0 and habitacion_id=" & hab, "item_limpieza")
        Private Function concatenarColumna(ByVal servicios As DataTable, ByVal filtro As String, ByVal columna As String, ByVal order As String, ByVal extra As String, ByVal idstr As Object) As String
            Dim trows() As DataRow = servicios.Select(filtro, order)
            Dim row As DataRow
            Dim retValue As String = ""
            With servicios.Rows
                For Each row In trows
                    If retValue = "" Then
                        retValue = row(columna)
                    Else
                        If retValue.IndexOf(row(columna)) < 0 Then
                            If idstr = 0 Then
                                retValue = row(columna)
                            Else
                                retValue = retValue & "," & row(columna)
                            End If

                        End If

                    End If
                Next
            End With
            If extra <> "" Then
                If retValue = "" Then
                    retValue = extra
                Else
                    If retValue.IndexOf(extra) < 0 Then
                        If idstr = 0 Then
                            retValue = extra
                        Else
                            retValue = retValue & "," & extra
                        End If

                    End If
                End If
            End If
            Return retValue
        End Function
        Private Sub borrarDeTabla(ByVal servicios As DataTable, ByVal filtro As String, Optional ByVal borrar As Boolean = False, Optional ByVal columna As String = "", Optional ByVal valor As Object = Nothing)
            Dim trows() As DataRow = servicios.Select(filtro)
            Dim row As DataRow
            With servicios.Rows
                If columna <> "" And Not IsNothing(valor) Then
                    For Each row In trows
                        row(columna) = valor
                    Next
                Else
                    If borrar Then
                        For Each row In trows
                            row.Delete()
                        Next
                    Else
                        For Each row In trows
                            .Remove(row)
                        Next
                    End If
                End If
            End With
        End Sub
        Shared sqlHabitacionEstaBlokeada = "" _
        & " SELECT" _
& " habitaciones_bloqueos.*,reservas.estado_reserva_id as estado_reserva_id " _
& " FROM " _
& " habitaciones_bloqueos left join reservas on habitaciones_bloqueos.reserva_id=reservas.reserva_id" _
& " WHERE " _
& " (habitaciones_bloqueos.habitacion_id =? or 0=? ) AND " _
& " (? BETWEEN  habitaciones_bloqueos.fecha_desde AND  habitaciones_bloqueos.fecha_hasta " _
& " or ? BETWEEN  habitaciones_bloqueos.fecha_desde AND  habitaciones_bloqueos.fecha_hasta " _
& " or habitaciones_bloqueos.fecha_desde between ? and ? " _
& " or habitaciones_bloqueos.fecha_hasta  between ? and ?) "

        Shared sqlObtieneHabitacionBloqueada = "select * from habitaciones_bloqueos where habitacion_bloqueo_id=?"
        Shared sqlObietneHotelPorHabitacion = "SELECT hotel_id FROM habitaciones WHERE habitaciones.habitacion_id =  ?"
        Shared sqlObtineDatosHabitacion = "SELECT * FROM habitaciones WHERE habitaciones.habitacion_id =  ?"
        Shared sqlObtieneDatosReseAsignaHabREserva = "" _
& "         SELECT " _
& " reservas.fecha_prevista_llegada as fecha_desde, " _
& " reservas.fecha_prevista_salida as fecha_hasta" _
& " FROM" _
& " reservas " _
& " Inner Join habitaciones ON reservas.hotel_id = habitaciones.hotel_id " _
& " WHERE " _
& " reservas.reserva_id =  ? AND " _
& " habitaciones.habitacion_id =  ? "
        Shared sqlBorrarHabitacionesBloqueadasReserva = "delete from habitaciones_bloqueos where reserva_id=?"

        Public Function AsignaHabitacionReserva(ByVal reserva_id As Integer, ByVal habitacion_id As Integer) As Boolean
            'todo comprobar habitacion y reserva_id es del mismo hotel

            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try


                Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
                Dim habitacion_idParam As New Odbc.OdbcParameter("@habitacion_id", habitacion_id)
                cmd.Parameters.Clear()
                cmd.Parameters.Add(reserva_idParam)
                cmd.Parameters.Add(habitacion_idParam)
                Dim reader As DataTableReader = Me.getDataTable(cmd, sqlObtieneDatosReseAsignaHabREserva)
                While reader.Read And errorCode = 0
                    'crear registro en habitaciones_bloqueos
                    'borrar habitacion cero?
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(reserva_idParam)
                    Me.ExecuteNonQuery(cmd, sqlBorrarHabitacionesBloqueadasReserva)
                    Dim retVal1 As Integer = bloqueaHabitacion(cmd, habitacion_id, reader.Item("fecha_desde"), reader.Item("fecha_hasta"), False, reserva_id, -1, Nothing, True)
                    If retVal1 = 0 Then
                        errorCode = -1
                        AgregaInfo("AsignaHabitacionReserva", "Fallo al intentar bloquer la habitacion " & habitacion_id & " para la reserva " & reserva_id, -errorCode)
                    Else
                        'asignar la habitacion bloqueada a los huespedes
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(reserva_idParam)
                        Dim DShuespedes As DataSet = getDataSet(cmd, sqlCabHuespedes)
                        Dim x As Integer
                        If DShuespedes.Tables(0).Rows.Count > 0 Then
                            For x = 0 To DShuespedes.Tables(0).Rows.Count - 1
                                DShuespedes.Tables(0).Rows(x)("habitacion_id") = habitacion_id
                            Next
                            Dim writer As Odbc.OdbcDataAdapter
                            writer = getDataAdapter(cmd, sqlCabHuespedes)
                            writer.Fill(DShuespedes.Tables(0))
                            writer.Update(DShuespedes.Tables(0))
                        End If
                        retVal = True
                    End If
                End While
            Catch ex As Exception
                retVal = False
                errorCode = 2
                AgregaInfo("AsignaHabitacionReserva", ex.Message, -errorCode)
            End Try
            flushConection(cmd, errorCode)
            Return retVal
        End Function
        Public Function bloqueaHabitacion(ByVal habitacion_id As Integer, ByVal fecha_desde As Date, ByVal fecha_hasta As Date, ByVal validar As Boolean, Optional ByVal reserva_id As Integer = -1, Optional ByVal habitacion_bloqueo_id As Integer = -1, Optional ByVal observaciones As String = Nothing, Optional ByVal forzar As Boolean = False) As Integer
            Dim retVal As Integer
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try
                retVal = bloqueaHabitacion(cmd, habitacion_id, fecha_desde, fecha_hasta, validar, reserva_id, habitacion_bloqueo_id, observaciones, forzar)
                If retVal = 0 Then
                    errorCode = -1
                End If
            Catch ex As Exception
                errorCode = -2
                retVal = 0
            End Try
            flushConection(cmd, errorCode)
            Return retVal
        End Function
        Private Function bloqueaHabitacion(ByVal cmd As Odbc.OdbcCommand, ByVal habitacion_id As Integer, ByVal fecha_desde As Date, ByVal fecha_hasta As Date, ByVal validar As Boolean, Optional ByVal reserva_id As Integer = -1, Optional ByVal habitacion_bloqueo_id As Integer = -1, Optional ByVal observaciones As String = Nothing, Optional ByVal forzar As Boolean = False) As Integer
            Dim retVal As Integer
            Dim errorCode As Integer = 0

            Try


                Dim habitacion_idParam As New Odbc.OdbcParameter("@habitacion_id", habitacion_id)
                Dim habitacion_bloqueo_idParam As New Odbc.OdbcParameter("@habitacion_bloqueo_id", habitacion_bloqueo_id)
                Dim fecha_desdeParam As New Odbc.OdbcParameter("@fecha_desde", fecha_desde)
                Dim fecha_hastaParam As New Odbc.OdbcParameter("@fecha_hasta", fecha_hasta)
                Dim fecha_desde1Param As New Odbc.OdbcParameter("@fecha_desde1", fecha_desde)
                Dim fecha_hasta1Param As New Odbc.OdbcParameter("@fecha_hasta1", fecha_hasta)
                Dim fecha_desde2Param As New Odbc.OdbcParameter("@fecha_desde2", fecha_desde)
                Dim fecha_hasta2Param As New Odbc.OdbcParameter("@fecha_hasta2", fecha_hasta)
                Dim habitacion_id_old As Integer
                cmd.Parameters.Clear()
                cmd.Parameters.Add(habitacion_bloqueo_idParam)
                Dim datosold As DataSet = getDataSet(cmd, sqlObtieneHabitacionBloqueada)
                If datosold.Tables(0).Rows.Count > 0 Then
                    habitacion_id_old = datosold.Tables(0).Rows(0).Item("habitacion_id")
                End If
                Dim habitacion_id_oldParam As New Odbc.OdbcParameter("@habitacion_id_old", habitacion_id_old)
                cmd.Parameters.Clear()
                cmd.Parameters.Add(habitacion_idParam)
                Dim hotel_id As Integer = ExecuteScalar(cmd, sqlObietneHotelPorHabitacion)
                Dim fechacierrehotel As Date = FechaHotel(cmd, hotel_id)

                cmd.Parameters.Clear()
                cmd.Parameters.Add(habitacion_idParam)
                cmd.Parameters.Add(habitacion_id_oldParam)
                cmd.Parameters.Add(fecha_desdeParam)
                cmd.Parameters.Add(fecha_hastaParam)
                cmd.Parameters.Add(fecha_desde1Param)
                cmd.Parameters.Add(fecha_hasta1Param)
                cmd.Parameters.Add(fecha_desde2Param)
                cmd.Parameters.Add(fecha_hasta2Param)
                Dim datos As DataSet = getDataSet(cmd, sqlHabitacionEstaBlokeada)
                'añadir la fila
                Dim row As DataRow
                Dim tmpCol(0) As DataColumn
                tmpCol(0) = datos.Tables(0).Columns("habitacion_bloqueo_id")

                Dim tmpcol1 = datos.Tables(0).PrimaryKey
                datos.Tables(0).PrimaryKey = tmpCol
                row = datos.Tables(0).Rows.Find(habitacion_bloqueo_id)
                datos.Tables(0).PrimaryKey = tmpcol1
                datos.Tables(0).Columns("habitacion_bloqueo_id").AllowDBNull = True
                'si habitacion es distinta...y la fecha de hotel ya ha pasado..crear 2
                If habitacion_bloqueo_id <> -1 Then
                    retVal = habitacion_bloqueo_id
                End If
                If IsNothing(row) Then
                    row = datos.Tables(0).Rows.Add()
                Else
                    If row.Item("habitacion_id") = habitacion_id Then
                        If fechacierrehotel >= row.Item("fecha_desde") And fechacierrehotel <= row.Item("fecha_hasta") Then
                            If row.Item("fecha_hasta") >= fechacierrehotel And fecha_hasta <= fechacierrehotel Then
                                row.Item("fecha_hasta") = fechacierrehotel
                                fecha_desde = row.Item("fecha_desde")
                                fecha_hasta = row.Item("fecha_hasta")
                            End If
                            If row.Item("fecha_desde") <= fechacierrehotel Then
                                fecha_desde = row.Item("fecha_desde")
                            End If
                        End If
                    Else
                        If fechacierrehotel >= row.Item("fecha_desde") And fechacierrehotel <= row.Item("fecha_hasta") Then
                            'If row.Item("fecha_hasta") >= fechacierrehotel And fecha_hasta <= fechacierrehotel Then
                            row.Item("fecha_hasta") = fechacierrehotel
                            fecha_desde = fechacierrehotel
                            'End If
                            row = datos.Tables(0).Rows.Add()
                        End If
                    End If
                End If

                row.Item("habitacion_id") = habitacion_id
                row.Item("tipo_bloqueo_id") = 1 'si existe reserva
                If reserva_id > 0 Then
                    row.Item("reserva_id") = reserva_id
                End If
                row.Item("observaciones") = observaciones
                row.Item("fecha_desde") = fecha_desde
                row.Item("fecha_hasta") = fecha_hasta
                row.Item("user_id") = userId
                row.Item("fecha_modificacion") = Now

                'comprobar integridad estructural
                Dim x As Integer
                Dim y As Integer
                If Not forzar Or fecha_desde = fecha_hasta Then
                    Dim rows As DataRowCollection = datos.Tables(0).Rows
                    Dim repetir As Boolean = True
                    While repetir
                        repetir = False
                        For x = 0 To (rows.Count - 1) And repetir = False
                            If (repetir = True OrElse rows(x).RowState = DataRowState.Deleted) Then
                            Else
                                If rows(x).Item("fecha_desde") = rows(x).Item("fecha_hasta") Then
                                    rows(x).Delete()
                                    repetir = True
                                    retVal = 0
                                Else
                                    For y = x + 1 To (rows.Count - 1) And repetir = False
                                        If (rows(y).RowState = DataRowState.Deleted) Then
                                        Else
                                            If rows(x).Item("habitacion_id") = rows(y).Item("habitacion_id") Then
                                                If rows(x).Item("reserva_id") = rows(y).Item("reserva_id") And rows(x).Item("fecha_desde") = rows(y).Item("fecha_desde") And rows(x).Item("fecha_hasta") = rows(y).Item("fecha_hasta") Then
                                                    'si fechas,reserva igual...eliminar primer registro
                                                    rows(x).Delete()
                                                    repetir = True
                                                    retVal = 0
                                                Else
                                                    If rows(y).Item("fecha_desde") >= rows(x).Item("fecha_desde") And rows(y).Item("fecha_desde") < rows(x).Item("fecha_hasta") Or rows(x).Item("fecha_desde") >= rows(y).Item("fecha_desde") And rows(x).Item("fecha_desde") < rows(y).Item("fecha_hasta") Then
                                                        rows(y).Delete()
                                                        repetir = True
                                                        retVal = 0
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                            End If
                        Next
                    End While
                End If
                'actualiza/inserta datos
                Dim writer As Odbc.OdbcDataAdapter
                writer = getDataAdapter(cmd, sqlObtieneHabitacionBloqueada)
                writer.Fill(datos.Tables(0))
                writer.Update(datos.Tables(0))
                Dim tmpretVal = ExecuteScalar(cmd, "SELECT LAST_INSERT_ID();")
                If tmpretVal <> 0 Then
                    retVal = tmpretVal
                End If

            Catch ex As Exception
                retVal = 0
                errorCode = 1
                AgregaInfo("bloquaHabitacion", "Fallo al intentar bloquer la habitacion " & habitacion_id & " para la reserva " & reserva_id, -errorCode)
            End Try

            'si existe bloqueid modificar sus fechas hasta permitido
            'si fechas colisionan cancelar


            Return retVal
        End Function
        Public Function CompruebaEstadoHabitacion(ByVal habitacion_bloqueo_id As Integer)
            'Dim retVal As Integer
            Dim errorCode As Integer = 0
            Dim tmp As String = ""
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try


                cmd.Parameters.Clear()
                Dim habitacion_bloqueo_idParam As New Odbc.OdbcParameter("@habitacion_bloqueo_id", habitacion_bloqueo_id)
                cmd.Parameters.Add(habitacion_bloqueo_idParam)
                Dim reader As DataTableReader = getDataTable(cmd, sqlObtieneHabitacionBloqueada)

                While reader.Read
                    tmp = CompruebaEstadoHabitacion(cmd, reader("habitacion_id"), reader("reserva_id"), reader("fecha_desde"), reader("fecha_hasta"))
                End While
            Catch ex As Exception

            End Try
            'If retVal = 0 Then
            ' errorCode = -1
            'End If
            flushConection(cmd, errorCode)
            Return tmp

        End Function
        Public Function CompruebaEstadoHabitacion(ByVal habitacion_id As Integer, ByVal reserva_id As Integer, ByVal fecha_desde As Date, ByVal fecha_hasta As Date) As String
            Dim tmp As String = ""
            If habitacion_id <> 0 Then
                Dim errorCode As Integer = 0
                Dim cmd As Odbc.OdbcCommand = prepareConection()
                Try
                    tmp = CompruebaEstadoHabitacion(cmd, habitacion_id, reserva_id, fecha_desde, fecha_hasta)
                Catch ex As Exception

                End Try

                flushConection(cmd, errorCode)
            End If
            Return tmp
        End Function
        Shared sqlTipoHabitacionesReserva = "" _
& " SELECT" _
& " habitaciones.habitacion_id, " _
& " tipos_habitacion.desc_corta, " _
& " reservas_tipo_habitacion.abreviatura " _
& " FROM " _
& " habitaciones " _
& " Inner Join tipos_habitacion ON habitaciones.tipo_habitacion_id = tipos_habitacion.tipo_habitacion_id , " _
& " reservas_tipo_habitacion " _
& " WHERE " _
& " reservas_tipo_habitacion.reserva_id =  ? AND " _
& " habitaciones.habitacion_id =  ? "

        Private Function CompruebaEstadoHabitacion(ByVal cmd As Odbc.OdbcCommand, ByVal habitacion_id As Integer, ByVal reserva_id As Integer, ByVal fecha_desde As Date, ByVal fecha_hasta As Date) As String
            Dim tmp As String = ""
            If habitacion_id <> 0 Then

                Try
                    Dim habitacion_idParam As New Odbc.OdbcParameter("@habitacion_id", habitacion_id)
                    Dim habitacion_id1Param As New Odbc.OdbcParameter("@habitacion_id1", habitacion_id)
                    Dim fecha_desdeParam As New Odbc.OdbcParameter("@fecha_desde", fecha_desde)
                    Dim fecha_hastaParam As New Odbc.OdbcParameter("@fecha_hasta", fecha_hasta)
                    Dim fecha_desde1Param As New Odbc.OdbcParameter("@fecha_desde1", fecha_desde)
                    Dim fecha_hasta1Param As New Odbc.OdbcParameter("@fecha_hasta1", fecha_hasta)
                    Dim fecha_desde2Param As New Odbc.OdbcParameter("@fecha_desde2", fecha_desde)
                    Dim fecha_hasta2Param As New Odbc.OdbcParameter("@fecha_hasta2", fecha_hasta)
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(habitacion_idParam)
                    cmd.Parameters.Add(habitacion_id1Param)
                    cmd.Parameters.Add(fecha_desdeParam)
                    cmd.Parameters.Add(fecha_hastaParam)
                    cmd.Parameters.Add(fecha_desde1Param)
                    cmd.Parameters.Add(fecha_hasta1Param)
                    cmd.Parameters.Add(fecha_desde2Param)
                    cmd.Parameters.Add(fecha_hasta2Param)
                    Dim datos As DataSet = Me.getDataSet(cmd, sqlHabitacionEstaBlokeada)
                    'Dim cont() As DataRow = datos.Tables(0).Select("reserva_id<>" & reserva_id & " and fecha_hasta<>'" + fecha_desde + "'")
                    Dim cont() As DataRow = datos.Tables(0).Select("reserva_id<>" & reserva_id & " and fecha_hasta<>'" + fecha_desde + "' and fecha_desde<>'" + fecha_hasta + "'")

                    If cont.Length > 0 Then
                        Dim x
                        tmp = "Bloqueada:"
                        For x = 0 To cont.Length - 1
                            tmp &= (" res:" & cont(x).Item("reserva_id"))
                        Next
                    End If
                    'todo comprobar que la reserva pide un tipo de hab y se le asigna el mismo tipo hab sino warnin
                    cmd.Parameters.Clear()
                    Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
                    cmd.Parameters.Add(reserva_idParam)
                    cmd.Parameters.Add(habitacion_idParam)
                    datos = getDataSet(cmd, sqlTipoHabitacionesReserva)
                    cont = datos.Tables(0).Select("desc_corta=abreviatura")
                    If cont.Length = 0 Then
                        Dim x As Integer
                        cont = datos.Tables(0).Select("desc_corta<>abreviatura")
                        For x = 0 To cont.Length - 1
                            tmp &= (" tipo " & cont(x).Item("desc_corta") & "<>" & cont(x).Item("abreviatura"))
                        Next
                    End If

                Catch ex As Exception

                End Try
            Else
                tmp = "Sin Habitacion asignada"
            End If
            Return tmp
            'CompruebaEstadoHabitacion(habitacion_id, reserva_id, fecha_desde, fecha_hasta)
        End Function
        Private Function ObtieneReservasHabitacion(ByVal cmd As Odbc.OdbcCommand, ByVal habitacion_id As Integer, ByVal fecha_desde As Date, ByVal fecha_hasta As Date, Optional ByVal reserva_id As Integer = 0) As ArrayList
            Dim tmp As New ArrayList
            'If habitacion_id <> 0 Then
            Try
                Dim habitacion_idParam As New Odbc.OdbcParameter("@habitacion_id", habitacion_id)
                Dim habitacion_id1Param As New Odbc.OdbcParameter("@habitacion_id1", habitacion_id)
                Dim fecha_desdeParam As New Odbc.OdbcParameter("@fecha_desde", (fecha_desde))
                Dim fecha_hastaParam As New Odbc.OdbcParameter("@fecha_hasta", (fecha_hasta))
                Dim fecha_desde1Param As New Odbc.OdbcParameter("@fecha_desde1", (fecha_desde))
                Dim fecha_hasta1Param As New Odbc.OdbcParameter("@fecha_hasta1", (fecha_hasta))
                Dim fecha_desde2Param As New Odbc.OdbcParameter("@fecha_desde2", (fecha_desde))
                Dim fecha_hasta2Param As New Odbc.OdbcParameter("@fecha_hasta2", (fecha_hasta))
                cmd.Parameters.Clear()
                cmd.Parameters.Add(habitacion_idParam)
                cmd.Parameters.Add(habitacion_id1Param)
                cmd.Parameters.Add(fecha_desdeParam)
                cmd.Parameters.Add(fecha_hastaParam)
                cmd.Parameters.Add(fecha_desde1Param)
                cmd.Parameters.Add(fecha_hasta1Param)
                cmd.Parameters.Add(fecha_desde2Param)
                cmd.Parameters.Add(fecha_hasta2Param)
                Dim datos As DataSet = Me.getDataSet(cmd, sqlHabitacionEstaBlokeada, True)
                Dim cont() As DataRow = datos.Tables(0).Select(" estado_reserva_id<>0 and estado_reserva_id<>2 and fecha_hasta<>'" + fecha_desde + "'")
                'Dim cont() As DataRow = datos.Tables(0).Select(" estado_reserva_id<>0 and estado_reserva_id<>2")
                If cont.Length > 0 Then
                    Dim x
                    For x = 0 To cont.Length - 1
                        If habitacion_id = 0 Then
                            If Not cont(x).IsNull("habitacion_id") And Not cont(x).IsNull("reserva_id") Then
                                If cont(x).Item("reserva_id") = reserva_id Then
                                    tmp.Add(cont(x).Item("habitacion_id"))
                                End If
                            End If
                        Else
                            If Not cont(x).IsNull("reserva_id") Then
                                tmp.Add(cont(x).Item("reserva_id"))
                            End If
                        End If


                    Next
                End If
            Catch ex As Exception

            End Try
            'Else
            'tmp = New ArraList()
            'End If
            Return tmp
            'CompruebaEstadoHabitacion(habitacion_id, reserva_id, fecha_desde, fecha_hasta)
        End Function
        Shared sqlUlitmaFechaHotel = "" _
    & "     SELECT" _
    & " Max(cierres.fecha_cierre) " _
    & " FROM " _
    & " cierres " _
    & " WHERE " _
    & " cierres.hotel_id =  ?"
        Private Function ComparaFechaHotel(ByVal cmd, ByVal reserva_id) As Boolean
            Dim retVal As Boolean = False
            Try
                cmd.Parameters.Clear()
                Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
                cmd.Parameters.Add(reserva_idParam)
                Dim reserva As DataSet = getDataSet(cmd, sqlCabReserva)
                If reserva.Tables(0).Rows.Count > 0 Then
                    Dim row As DataRow = reserva.Tables(0).Rows(0)
                    Dim fecha_hotel As Date = FechaHotel(cmd, row("hotel_id"))
                    If fecha_hotel = row("fecha_prevista_llegada") Then
                        retVal = True
                    End If
                End If
            Catch ex As Exception
                retVal = False
            End Try
            Return retVal
        End Function
        Private Function FechaHotel(ByVal cmd As Odbc.OdbcCommand, ByVal hotel_id As Integer) As Date
            Dim retVal As Date
            cmd.Parameters.Clear()
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            cmd.Parameters.Add(hotel_idParam)
            Try
                retVal = ExecuteScalar(cmd, sqlUlitmaFechaHotel, True)
                retVal = retVal.AddDays(1)
            Catch ex As Exception
                retVal = Now.Date
            End Try
            Return retVal
        End Function
        Function FechaHotel(ByVal hotel_id As Integer) As Date
            Dim retVal As Date
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = FechaHotel(cmd, hotel_id)
            flushConection(cmd, errorCode)
            Return retVal
        End Function
        Shared sqlEstadoCaja = "" _
    & "    SELECT" _
    & " arqueos_caja.arqueo_id " _
    & " FROM " _
    & " arqueos_caja" _
    & " WHERE " _
    & " arqueos_caja.tipo_arqueo_id =  2 AND " _
    & " arqueos_caja.caja_id =  ? AND " _
    & " arqueos_caja.fecha =  ? "
        Function EstaCajaAbierta(ByVal cmd As Odbc.OdbcCommand, ByVal caja_id As Integer, ByVal fecha As Date) As Boolean
            'todo cache...
            Dim retVal As Boolean = False
            If caja_id <> 0 Then
                cmd.Parameters.Clear()
                Dim caja_idParam As New Odbc.OdbcParameter("@caja_id", caja_id)
                Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
                cmd.Parameters.Add(caja_idParam)
                cmd.Parameters.Add(fechaParam)

                Dim existe = ExecuteScalar(cmd, sqlEstadoCaja)
                If IsNothing(existe) Then
                    retVal = True
                Else
                    retVal = False
                End If
            End If
            Return retVal
        End Function
        Function EstaCajaAbierta(ByVal caja_id As Integer, ByVal fecha As Date) As Boolean
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = EstaCajaAbierta(cmd, caja_id, fecha)
            flushConection(cmd, errorCode)
            Return retVal
        End Function
        Shared sqlImporteTeoricoNuevo = "" _
    & " SELECT " _
    & " sum(movimientos_caja.importe*tipos_movimiento_caja.signo) as importe " _
    & " FROM " _
    & " movimientos_caja " _
    & " Inner Join tipos_movimiento_caja ON movimientos_caja.tipo_movimiento_id = tipos_movimiento_caja.tpo_movimiento_id " _
    & " WHERE " _
    & " movimientos_caja.caja_id = ? AND " _
    & " movimientos_caja.fecha =  ? "
        Shared sqlImporteRealAnterior = "" _
    & " SELECT " _
    & " arqueos_caja.importe_real " _
    & " FROM " _
    & " arqueos_caja " _
    & " WHERE " _
    & " arqueos_caja.caja_id =  ? and arqueos_caja.fecha<? " _
    & " order by fecha desc " _
    & " limit 0,1 "
        Private Function ObtieneImporteTeoricoCaja(ByVal cmd As Odbc.OdbcCommand, ByVal caja_id As Integer, ByVal fecha As Date) As Single
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            cmd.Parameters.Clear()
            Dim caja_idParam As New Odbc.OdbcParameter("@caja_id", caja_id)
            Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
            cmd.Parameters.Add(caja_idParam)
            cmd.Parameters.Add(fechaParam)

            Dim imp As Single = 0
            Dim impant As Single = 0
            Dim ret As Object = ExecuteScalar(cmd, sqlImporteTeoricoNuevo)
            If Not IsDBNull(ret) Then
                imp = ret
            End If
            ret = ExecuteScalar(cmd, sqlImporteRealAnterior)
            If Not IsDBNull(ret) Then
                impant = ret
            End If
            imp = imp + impant
            Return imp
        End Function
        Function ObtieneImporteTeoricoCaja(ByVal caja_id As Integer, ByVal fecha As Date) As Single
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim imp As Single = ObtieneImporteTeoricoCaja(cmd, caja_id, fecha)
            flushConection(cmd, errorCode)
            Return imp
        End Function
        Class Factura
            Public ds As DataSet
            Public cmd As Odbc.OdbcCommand
            Public errorCode = 0
            Public factura_id As Integer
            Public excuteTrans As Boolean = True
        End Class

        Shared sqlCabCliente = "select * from clientes where cliente_id=?"
        Function preparaFactura(ByVal cmd As Odbc.OdbcCommand, ByVal reserva_id As Integer, ByVal cliente_id As Integer, ByVal forma_pago_id As Integer, ByVal fecha As Date, ByVal hotel_id As Integer, ByVal serie_id As Integer, Optional ByVal referencia2 As Object = Nothing)
            Dim fac As Factura = abreFactura(cmd, -1, reserva_id)
            fac.errorCode = 0
            Dim ds As DataSet = fac.ds
            Dim dtcab As DataTable = ds.Tables(0)
            fac.cmd.Parameters(0).Value = cliente_id
            Dim clires As DataTableReader = getDataTable(fac.cmd, sqlCabCliente)
            fac.cmd.Parameters(0).Value = reserva_id
            While clires.Read

                Dim row As DataRow = dtcab.Rows.Add
                row.Item("cliente_id") = cliente_id
                'relleno los demas campos
                row.Item("Fecha_Factura") = fecha 'todo cambiar fecha hotel+1
                Dim addven = clires.Item("vencimiento_facturas_id")
                If IsDBNull(addven) Then
                    addven = 0
                End If
                row.Item("Fecha_Vencimiento") = fecha.AddDays(addven)
                row.Item("hotel_id") = hotel_id
                row.Item("Estado_Factura_Id") = 0 'generada
                row.Item("user_id") = userId
                row.Item("Fecha_modificacion") = Now
                row.Item("Serie_id") = serie_id 'normal
                'row.Item("Forma_Pago_Id") = 1 'contado
                'obtiene datos de la reserva

                row.Item("Ref_Fra1") = ""
                row.Item("Ref_Fra2") = ""
                If Not IsNothing(referencia2) And Not IsDBNull(referencia2) Then
                    row.Item("Ref_Fra2") = referencia2
                Else
                    Dim dr As DatosReserva = obtieneReservaDatosListados(cmd, reserva_id)
                    If Not IsNothing(dr) Then
                        'Ref Fra para todos : Nombre del 1er Huesped  Del dd/mm/aaaa Al dd/mm/aaaa (si es rectificativa, poner los datos de la que rectifica por defecto)
                        row.Item("Ref_Fra1") = dr.primer_huesped & " del " & dr.fecha_desde.ToShortDateString & " al " & dr.fecha_hasta.ToShortDateString
                        'Ref Fra2               : Bono : xxxxxxxxxxx Habit.: xxx  PAX : xxx  Pension : xx   (si es rectificativa, poner los datos de la que rectifica por defecto)
                        row.Item("Ref_Fra2") = "Bono:" & dr.bono & " Habit.:" & dr.habitacion & " Pax:" & dr.pax & " Pension:" & dr.regimen
                    End If
                End If


                
                'datos cliente
                row.Item("Forma_Pago_Id") = forma_pago_id ' que hacer?
                row.Item("Direccion_Fra") = clires.Item("Direccion_Fra")
                row.Item("Poblacion_Fra") = clires.Item("Poblacion_Fra")
                row.Item("ZIP") = clires.Item("ZIP")
                row.Item("Provincia_Id") = clires.Item("Provincia_Id")

                Dim writer As Odbc.OdbcDataAdapter
                writer = getDataAdapter(fac.cmd, sqlCabAbreFactura)
                writer.Fill(fac.ds.Tables(0))
                writer.Update(fac.ds.Tables(0))
                fac.factura_id = ExecuteScalar(fac.cmd, "SELECT LAST_INSERT_ID();")
                row.Item("factura_id") = fac.factura_id
                row.AcceptChanges()

            End While
            Return fac
        End Function
        Shared sqlCabReserva = "select * from reservas where reserva_id=?"
        Shared sqlPrimerHuesped = "SELECT cliente_id FROM reservas_huespedes WHERE reserva_id = ? LIMIT 0, 1"
        Private Function preparaFactura(ByVal cmd As Odbc.OdbcCommand, ByVal forma_pago_id As Integer, ByVal reserva_id As Integer, Optional ByVal primerHuesped As Boolean = False, Optional ByVal extCliente_id As Integer = 0)
            Dim fac As Factura = abreFactura(cmd, -1, -1)
            fac.cmd.Parameters(0).Value = reserva_id
            Dim cabres As DataTableReader = getDataTable(fac.cmd, sqlCabReserva)
            If cabres.Read Then
                'fac.cmd.Transaction.Commit()
                'TODO cambiar fecha salida por fecha hotel
                Dim fecha As Date = FechaHotel(fac.cmd, cabres.Item("hotel_id"))
                fac.cmd.Parameters(0).Value = reserva_id
                Dim cliente_id As Integer = 0
                Dim primer_huesped_id = ExecuteScalar(fac.cmd, sqlPrimerHuesped)
                If IsDBNull(primer_huesped_id) Or IsNothing(primer_huesped_id) Then
                    primer_huesped_id = cabres.Item("cliente_id")
                End If

                If primerHuesped Then

                    If cabres.IsDBNull(cabres.GetOrdinal("cliente_id_factura")) Then
                        cliente_id = primer_huesped_id 'Me.ExecuteScalar(fac.cmd, sqlPrimerHuesped)
                    Else
                        cliente_id = cabres.Item("cliente_id_factura")
                    End If
                End If
                If cliente_id = 0 Then
                    If extCliente_id = 0 Then
                        If cabres.IsDBNull(cabres.GetOrdinal("cliente_id_factura")) Then
                            Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", cabres.Item("cliente_id"))
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add(cliente_idParam)
                            Dim clientes As DataSet = getDataSet(cmd, sqlCabCliente)
                            If clientes.Tables(0).Rows(0)("permite_credito") = 1 Then
                                cliente_id = cabres.Item("cliente_id")
                            Else
                                forma_pago_id = 1   'tiene ke ser contado
                                cliente_id = primer_huesped_id
                            End If
                        Else
                            Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", cabres.Item("cliente_id_factura"))
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add(cliente_idParam)
                            Dim clientes As DataSet = getDataSet(cmd, sqlCabCliente)
                            If clientes.Tables(0).Rows(0)("permite_credito") = 0 Then
                                forma_pago_id = 1   'tiene ke ser contado
                            End If
                            cliente_id = cabres.Item("cliente_id_factura")
                        End If
                    Else
                        Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", extCliente_id)
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(cliente_idParam)
                        Dim clientes As DataSet = getDataSet(cmd, sqlCabCliente)
                        If clientes.Tables(0).Rows(0)("permite_credito") = 0 Then
                            forma_pago_id = 1   'tiene ke ser contado
                        End If
                        cliente_id = extCliente_id
                    End If
                End If
                fac = preparaFactura(fac.cmd, reserva_id, cliente_id, forma_pago_id, fecha, cabres.Item("hotel_id"), 1)
            Else
                fac = Nothing
            End If
            Return fac
        End Function

        Function preparaFactura(ByVal cliente_id As Integer, ByVal forma_pago_id As Integer, ByVal reserva_id As Integer)
            Dim fac As Factura = abreFactura(-1, -1)
            fac.cmd.Parameters(0).Value = reserva_id
            Dim cabres As DataTableReader = getDataTable(fac.cmd, sqlCabReserva)
            If cabres.Read Then
                'fac.cmd.Transaction.Commit()
                'TODO cambiar fecha salida por fecha hotel
                'Dim fecha As Date = FechaHotel(fac.cmd, cabres.Item("hotel_id"))
                'fac = preparaFactura(fac.cmd, reserva_id, cliente_id, forma_pago_id, fecha, cabres.Item("hotel_id"), 1)
                fac = preparaFactura(fac.cmd, forma_pago_id, reserva_id, False, cliente_id)
            Else
                fac.cmd.Transaction.Rollback()
                fac = Nothing
            End If
            Return fac
        End Function
        Shared sqlCabAbreFactura = "select * from facturas where factura_id=?"
        Shared sqlCabLineasFactura = "select * from lineas_factura where reserva_id=?"

        Private Function abreFactura(ByVal cmd As Odbc.OdbcCommand, ByVal factura_id As Integer, ByVal reserva_id As Integer) As Factura
            Dim errorCode As Integer = 0

            cmd.Parameters.Clear()
            Dim factura_idParam As New Odbc.OdbcParameter("@factura_id", factura_id)
            cmd.Parameters.Add(factura_idParam)
            Dim ds As DataSet = getDataSet(cmd, sqlCabAbreFactura)
            cmd.Parameters.Clear()
            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
            cmd.Parameters.Add(reserva_idParam)
            ds = getDataSet(cmd, sqlCabLineasFactura, ds, "lineas_factura")


            'ds.Relations.Add("rel", ds.Tables(0).Columns("factura_id"), ds.Tables(1).Columns("factura_id"))

            Dim fac As Factura = New Factura
            fac.factura_id = factura_id
            fac.ds = ds
            fac.cmd = cmd
            Return fac
        End Function

        Function abreFactura(ByVal factura_id As Integer, ByVal reserva_id As Integer) As Factura
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Return abreFactura(cmd, factura_id, reserva_id)
        End Function
        Function agregaLineaFactura(ByVal fac As Factura) As DataRow
            Dim dsfac As DataTable = fac.ds.Tables(1)
            Dim row As DataRow = dsfac.Rows.Add
            Return row
        End Function
        Function asignaLineasAFactura(ByVal fac As Factura, ByVal filtro As String, Optional ByVal pag_factura As Object = Nothing) As Integer
            Dim extrafiltro = ""
            Dim reset As Integer = 0
            If Not IsNothing(pag_factura) Then
                If IsDBNull(pag_factura) Then
                    extrafiltro = " and pag_factura is null"
                    reset = 1
                Else

                    If pag_factura = 0 Then
                        'todas las paginas
                    Else
                        extrafiltro = " and pag_factura=" & pag_factura
                    End If
                End If
            End If
            Dim rows As DataRow() = fac.ds.Tables(1).Select(filtro & extrafiltro)
            Dim x As Integer
            Dim contador As Integer = 0
            For x = 0 To rows.Length - 1
                If rows(x).IsNull("factura_id") Then
                    rows(x).Item("factura_id") = fac.factura_id
                    If reset = 1 Then
                        rows(x).Item("pag_factura") = 1
                    End If
                    contador += 1
                End If
            Next
            Return contador
        End Function
        Private Function obtienePag_Factura(ByVal fac As Factura, ByVal tipo As String) As Queue
            Dim rows As DataRow() = fac.ds.Tables(1).Select()
            Dim x As Integer
            Dim nh As New Hashtable
            Dim contador As Integer = 0
            For x = 0 To rows.Length - 1
                If rows(x).IsNull("factura_id") And rows(x).Item("tipo_linea_factura") = tipo Then
                    If Not nh.ContainsKey(rows(x).Item("pag_factura")) Then
                        nh.Add(rows(x).Item("pag_factura"), rows(x).Item("pag_factura"))
                    End If

                End If
            Next

            Return New Queue(nh.Keys)
        End Function
        Function cambiaLineaFactura(ByVal linea_factura_id As Integer, ByVal cantidad As Single, ByVal fac As Factura, Optional ByVal completa As Boolean = False) As Boolean
            Dim row As DataRow
            Dim filtro As String = "linea_factura_id=" & linea_factura_id
            Dim rows As DataRow() = fac.ds.Tables(1).Select(filtro)

            If rows.Length = 0 Then
                Return False
            Else
                row = rows(0)
                If completa Then
                    cantidad = row.Item("cantidad")
                End If
                If row.Item("cantidad") <> cantidad Then
                    If cantidad = 0 Then
                        'hay ke desasignarla de la factura
                        row.Item("factura_id") = System.DBNull.Value
                    Else
                        If cantidad < row.Item("cantidad") Then
                            'ha cambiado cantidad...crear duplicado
                            Dim TempRow As DataRow = fac.ds.Tables(1).Rows.Add(row.ItemArray)
                            TempRow.Item("cantidad") = cantidad
                            TempRow.Item("factura_id") = fac.factura_id
                            row.Item("cantidad") = row.Item("cantidad") - cantidad
                            If Not row.IsNull("factura_id") Then
                                row.Item("factura_id") = System.DBNull.Value
                            End If
                        End If
                    End If
                Else
                    'la linea completa
                    If row.IsNull("factura_id") Then
                        row.Item("factura_id") = fac.factura_id
                    Else
                        If row.Item("factura_id") <> fac.factura_id Then
                            row.Item("factura_id") = fac.factura_id
                        End If
                    End If
                End If
                Return True
            End If
            'Return True
        End Function
        Public Sub OnRowUpdating(ByVal sender As Object, ByVal e As System.Data.Odbc.OdbcRowUpdatingEventArgs)
            Dim tmp() As String = e.Command.CommandText.Split("?")
            Dim res As String = ""
            Dim x As Integer
            For x = 0 To e.Command.Parameters.Count - 1
                res = res & tmp(x) & e.Command.Parameters(x).Value
            Next
            Console.WriteLine(res)

        End Sub
        Private Function actualizarLineas(ByVal fac As Factura)
            Dim writer As Odbc.OdbcDataAdapter
            Try
                'Console.WriteLine(fac.cmd.Parameters(0).Value)
                'dumpDataTable(fac.ds.Tables(1))
                'fac.cmd.Parameters.Clear()
                writer = getDataAdapter(fac.cmd, sqlCabLineasFactura) 'sqlCabLineasFactura
                'Console.WriteLine(fac.ds.Tables(1).GetChanges().Rows.Count)
                'fac.ds.Tables(1).Rows(0)("precio") = 66.3
                'fac.ds.Tables(1).Rows(0)("precio_produccion") = 49.98
                writer.Fill(fac.ds.Tables(1))
                'writer.
                'writer.ContinueUpdateOnError = True
                'writer.AcceptChangesDuringUpdate = True
                'AddHandler writer.RowUpdating, AddressOf OnRowUpdating

                writer.Update(fac.ds.Tables(1))
            Catch ex As DBConcurrencyException
                Console.WriteLine(fac.cmd.CommandText)
                Console.WriteLine(ex.Row.RowError)
                Return False
            Catch ex As Exception
                AgregaInfo("actualizarLineas", ex.Message, -1)
                Return False
            End Try
            Return True
        End Function
        Function actualizaFactura(ByVal fac As Factura)

            If fac.ds.Tables(1).Select("factura_id=" & fac.factura_id).Length = 0 Then
                'hay ke destruir la factura
                Dim rows As DataRow() = fac.ds.Tables(0).Select("factura_id=" & fac.factura_id)
                fac.factura_id = -1
                If rows.Length > 0 Then
                    Dim row As DataRow = rows(0)
                    row.Delete()
                    Dim writer As Odbc.OdbcDataAdapter
                    writer = getDataAdapter(fac.cmd, sqlCabAbreFactura)
                    writer.Fill(fac.ds.Tables(0))
                    writer.Update(fac.ds.Tables(0))
                End If
            End If
            If Not actualizarLineas(fac) Then
                fac.errorCode = 1
                AgregaInfo("actualizaFactura", "No puedo asignar lineas de factura a la cabecera:" & fac.factura_id, -fac.errorCode)
            End If
            If fac.excuteTrans Then
                flushConection(fac.cmd, fac.errorCode)
            End If
            Return True
        End Function
        Shared sqlObtieneDatosContFacturas = "" _
    & " SELECT " _
    & " facturas.Serie_id, " _
    & " hoteles.empresa_id, " _
    & " year(facturas.Fecha_Factura) AS ano " _
    & " FROM " _
    & " facturas " _
    & " Inner Join hoteles ON facturas.hotel_id = hoteles.hotel_id" _
    & " WHERE " _
    & " facturas.Factura_Id =  ?"
        Shared sqlContadores = " select * from contadores"
        Shared sqlActualizaContadorFactura = "update facturas set numero_factura=?,estado_factura_id=1 where factura_id=? and estado_factura_id=0"

        Private Function ObtieneNumeroFactura(ByVal cmd As Odbc.OdbcCommand, ByVal factura_id As Integer) As Integer
            Dim contador As Integer = -1
            cmd.Parameters.Clear()
            Dim factura_idParam As New Odbc.OdbcParameter("@factura_id", factura_id)
            cmd.Parameters.Add(factura_idParam)

            Dim dtr As DataTableReader = getDataTable(cmd, sqlObtieneDatosContFacturas)
            While dtr.Read
                Dim cont As DataSet = Me.getDataSet(cmd, sqlContadores)
                Dim filtro As String = "empresa_id=" & dtr.Item("empresa_id") & " and ano=" & dtr.Item("ano") & " and serie_id=" & dtr.Item("serie_id")
                Dim rows As DataRow() = cont.Tables(0).Select(filtro)
                Dim row As DataRow
                If rows.Length = 1 Then
                    row = rows(0)
                    contador = row.Item("contador")
                    row.Item("contador") = row.Item("contador") + 1
                Else
                    row = cont.Tables(0).Rows.Add()
                    row.Item("contador") = 2
                    row.Item("empresa_id") = dtr.Item("empresa_id")
                    row.Item("ano") = dtr.Item("ano")
                    row.Item("serie_id") = dtr.Item("serie_id")
                    contador = 1
                End If

                cmd.Parameters.Clear()
                Dim numero_facturaParam As New Odbc.OdbcParameter("@numero_factura", contador)
                cmd.Parameters.Add(numero_facturaParam)
                cmd.Parameters.Add(factura_idParam)
                If (ExecuteNonQuery(cmd, sqlActualizaContadorFactura) = 1) Then

                    Dim writer As Odbc.OdbcDataAdapter
                    writer = getDataAdapter(cmd, sqlContadores)
                    writer.Fill(cont.Tables(0))
                    writer.Update(cont.Tables(0))

                Else
                    contador = -1 'hubo un error
                    AgregaInfo("ObtieneNumeroFactura", "No puedo actualiza contador factura:" & factura_id, -contador)

                End If
            End While
            Return contador
        End Function
        Shared sqlCrearMovimientoCaja = "select * from movimientos_caja where movimiento_id=-1"
        Private Function CrearMovimientoCaja(ByVal cmd As Odbc.OdbcCommand, ByVal tipo_mov As Integer, ByVal fecha As Date, ByVal caja_id As Integer, ByVal importe As Double, ByVal item As Integer, ByVal forma_pago_id As Integer)
            Return CrearMovimientoCaja(cmd, tipo_mov, fecha, caja_id, importe, item, forma_pago_id, False)
        End Function
        Private Function CrearMovimientoCaja(ByVal cmd As Odbc.OdbcCommand, ByVal tipo_mov As Integer, ByVal fecha As Date, ByVal caja_id As Integer, ByVal importe As Double, ByVal item As Integer, ByVal forma_pago_id As Integer, ByVal saltaCierre As Boolean)
            'cache estado cajas 
            Dim retVal = False
            If saltaCierre OrElse EstaCajaAbierta(cmd, caja_id, fecha) Then
                Dim datos As DataSet = getDataSet(cmd, sqlCrearMovimientoCaja)
                Dim Row As DataRow = datos.Tables(0).Rows.Add()
                Row.Item("tipo_movimiento_id") = tipo_mov
                Row.Item("fecha") = fecha
                Row.Item("caja_id") = caja_id
                Row.Item("importe") = importe
                Row.Item("item_id") = item
                Row.Item("user_id") = userId
                Row.Item("fecha_modificacion") = Now
                Row.Item("forma_pago_id") = forma_pago_id
                Dim writer As Odbc.OdbcDataAdapter
                writer = getDataAdapter(cmd, sqlCrearMovimientoCaja)
                writer.Fill(datos.Tables(0))
                writer.Update(datos.Tables(0))
                retVal = True
            End If
            Return retVal
        End Function
        Shared sqlEstadoGasto = "select forma_pago_id,10 as tipo_movimiento_id,fecha,estado_id,caja_id,importe as total from gastos where gasto_id=?"
        Shared sqlCambiaEstadoGasto = "update gastos set estado_id=? where gasto_id=? and estado_id=?"
        Private Function CambiarEstadoGasto(ByVal cmd As Odbc.OdbcCommand, ByVal gasto_id As Integer, ByVal estado As Integer, ByVal validar As Boolean)
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            cmd.Parameters.Clear()
            Dim gasto_idParam As New Odbc.OdbcParameter("@gasto_id", gasto_id)
            cmd.Parameters.Add(gasto_idParam)
            Dim estado_anterior As Integer = Nothing
            Dim datos As DataTableReader = getDataTable(cmd, sqlEstadoGasto)
            Dim fecha As Date
            Dim caja_id As Integer
            Dim total As Single
            'Dim tipo_cobro_id As Integer
            Dim forma_pago_id As Integer
            Dim tipo_movimiento_id As Integer
            While datos.Read
                estado_anterior = datos.Item("estado_id")
                fecha = datos.Item("fecha")
                caja_id = datos.Item("caja_id")
                total = datos.Item("total")
                'tipo_cobro_id = datos.Item("tipo_cobro_id")
                forma_pago_id = datos.Item("forma_pago_id")
                tipo_movimiento_id = datos.Item("tipo_movimiento_id")
            End While


            Select Case estado_anterior
                Case 0
                    If estado = 1 Then
                        retVal = True
                        If Not validar Then
                            'todo cambiar estado
                            cmd.Parameters.Clear()
                            Dim estadoParam As New Odbc.OdbcParameter("@estado", estado)
                            Dim estado_anteriorParam As New Odbc.OdbcParameter("@estado_anterior", estado_anterior)
                            cmd.Parameters.Add(estadoParam)
                            cmd.Parameters.Add(gasto_idParam)
                            cmd.Parameters.Add(estado_anteriorParam)
                            If ExecuteNonQuery(cmd, sqlCambiaEstadoGasto) <> 1 Then
                                'no puedo cambiar estado

                                retVal = False
                            Else
                                'creo movmientos de cobro en caja asignada si la caja esta abierta
                                '10 gasto
                                If CrearMovimientoCaja(cmd, tipo_movimiento_id, fecha, caja_id, total, gasto_id, forma_pago_id) Then
                                Else
                                    'no puedo crear movimiento de caja
                                    'caja ya cerrada para esa fecha
                                    retVal = False
                                End If

                            End If
                        End If
                    End If
                Case 1
                    retVal = False
                    If estado = 2 Then
                        If validar Then
                            retVal = True
                        Else
                            cmd.Parameters.Clear()
                            Dim estadoParam As New Odbc.OdbcParameter("@estado", estado)
                            Dim estado_anteriorParam As New Odbc.OdbcParameter("@estado_anterior", estado_anterior)
                            cmd.Parameters.Add(estadoParam)
                            cmd.Parameters.Add(gasto_idParam)
                            cmd.Parameters.Add(estado_anteriorParam)
                            If ExecuteNonQuery(cmd, sqlCambiaEstadoGasto) <> 1 Then
                                'no puedo cambiar estado
                                retVal = False
                            Else
                                retVal = True
                            End If
                        End If
                    End If
            End Select

            If retVal = False Then
                errorCode = 1   'no se podria hacer el cambio
                AgregaInfo("CambiarEstadoGasto", "No puedo cambiar el estado del gasto:" & gasto_id, -errorCode)
            End If


            Return retVal
        End Function
        Shared sqlEstadoArqueo = "select estado_id from arqueos_caja where arqueo_id=?"
        Shared sqlCambiaEstadoArqueo = "update arqueos_caja set estado_id=? where arqueo_id=? and estado_id=?"
        Private Function CambiarEstadoArqueo(ByVal cmd As Odbc.OdbcCommand, ByVal arqueo_id As Integer, ByVal estado As Integer, ByVal validar As Boolean)
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            cmd.Parameters.Clear()
            Dim arqueo_idParam As New Odbc.OdbcParameter("@arqueo_id", arqueo_id)
            cmd.Parameters.Add(arqueo_idParam)
            Dim estado_anterior As Integer = Nothing
            Dim datos As DataTableReader = getDataTable(cmd, sqlEstadoArqueo)
            While datos.Read
                estado_anterior = datos.Item("estado_id")
            End While
            Select Case estado_anterior
                Case 0
                    If estado = 1 Then
                        retVal = True
                    End If
                Case 1
                    If estado = 2 Then
                        retVal = True
                    End If
            End Select

            If retVal And Not validar Then
                'todo cambiar estado
                cmd.Parameters.Clear()
                Dim estadoParam As New Odbc.OdbcParameter("@estado", estado)
                Dim estado_anteriorParam As New Odbc.OdbcParameter("@estado_anterior", estado_anterior)
                cmd.Parameters.Add(estadoParam)
                cmd.Parameters.Add(arqueo_idParam)
                cmd.Parameters.Add(estado_anteriorParam)
                If ExecuteNonQuery(cmd, sqlCambiaEstadoArqueo) <> 1 Then
                    'no puedo cambiar estado
                    retVal = False
                Else
                    retVal = True
                End If
            End If

            If retVal = False Then
                errorCode = 1   'no se podria hacer el cambio
                AgregaInfo("CambiarEstadoArqueo", "No puedo cambiar el estado del arqueo:" & arqueo_id, -errorCode)
            End If


            Return retVal
        End Function
        Shared sqlEstadoAnticipo = "select estado_id from anticipos where anticipo_id=?"
        Shared sqlCambiaEstadoAnticipo = "update anticipos set estado_id=? where anticipo_id=? and estado_id=?"
        Private Function CambiarEstadoAnticipo(ByVal cmd As Odbc.OdbcCommand, ByVal anticipo_id As Integer, ByVal estado As Integer, ByVal validar As Boolean)
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            cmd.Parameters.Clear()
            Dim anticipo_idParam As New Odbc.OdbcParameter("@anticipo_id", anticipo_id)
            cmd.Parameters.Add(anticipo_idParam)
            Dim estado_anterior As Integer = Nothing
            Dim datos As DataTableReader = getDataTable(cmd, sqlEstadoAnticipo)
            While datos.Read
                estado_anterior = datos.Item("estado_id")
            End While
            Select Case estado_anterior
                Case 0
                    If estado = 1 Then
                        retVal = True
                    End If
                Case 1
                    If estado = 2 Then
                        retVal = True
                    End If
            End Select

            If retVal And Not validar Then
                'todo cambiar estado
                cmd.Parameters.Clear()
                Dim estadoParam As New Odbc.OdbcParameter("@estado", estado)
                Dim estado_anteriorParam As New Odbc.OdbcParameter("@estado_anterior", estado_anterior)
                cmd.Parameters.Add(estadoParam)
                cmd.Parameters.Add(anticipo_idParam)
                cmd.Parameters.Add(estado_anteriorParam)
                If ExecuteNonQuery(cmd, sqlCambiaEstadoAnticipo) <> 1 Then
                    'no puedo cambiar estado
                    retVal = False
                Else
                    retVal = True
                End If
            End If

            If retVal = False Then
                errorCode = 1   'no se podria hacer el cambio
                AgregaInfo("CambiarEstadoAnticipo", "No puedo cambiar el estado del anticipo:" & anticipo_id, -errorCode)
            End If


            Return retVal
        End Function
        Shared sqlEstadoDotacion = "SELECT dotaciones.fecha,dotaciones.estado_id,dotaciones.caja_id,dotaciones.importe AS total,tipos_dotacion.tipo_moviemiento_id as tipo_movimiento_id FROM dotaciones Inner Join tipos_dotacion ON dotaciones.tipo_dotacion_id = tipos_dotacion.tipo_dotacion_id where dotaciones.dotacion_id=?"
        Shared sqlCambiaEstadoDotacion = "update dotaciones set estado_id=? where dotacion_id=? and estado_id=?"

        Private Function CambiarEstadoDotacion(ByVal cmd As Odbc.OdbcCommand, ByVal dotacion_id As Integer, ByVal estado As Integer, ByVal validar As Boolean)
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            cmd.Parameters.Clear()
            Dim dotacion_idParam As New Odbc.OdbcParameter("@dotacion_id", dotacion_id)
            cmd.Parameters.Add(dotacion_idParam)
            Dim estado_anterior As Integer = Nothing
            Dim datos As DataTableReader = getDataTable(cmd, sqlEstadoDotacion)
            Dim fecha As Date
            Dim caja_id As Integer
            Dim total As Single
            'Dim tipo_cobro_id As Integer
            'Dim forma_pago_id As Integer
            Dim tipo_movimiento_id As Integer
            While datos.Read
                estado_anterior = datos.Item("estado_id")
                fecha = datos.Item("fecha")
                caja_id = datos.Item("caja_id")
                total = datos.Item("total")
                'tipo_cobro_id = datos.Item("tipo_cobro_id")
                'forma_pago_id = datos.Item("forma_pago_id")
                tipo_movimiento_id = datos.Item("tipo_movimiento_id")
            End While


            Select Case estado_anterior
                Case 0
                    If estado = 1 Then
                        retVal = True
                        If Not validar Then
                            'todo cambiar estado
                            cmd.Parameters.Clear()
                            Dim estadoParam As New Odbc.OdbcParameter("@estado", estado)
                            Dim estado_anteriorParam As New Odbc.OdbcParameter("@estado_anterior", estado_anterior)
                            cmd.Parameters.Add(estadoParam)
                            cmd.Parameters.Add(dotacion_idParam)
                            cmd.Parameters.Add(estado_anteriorParam)
                            If ExecuteNonQuery(cmd, sqlCambiaEstadoDotacion) <> 1 Then
                                'no puedo cambiar estado
                                retVal = False
                            Else
                                'creo movmientos de cobro en caja asignada si la caja esta abierta
                                If CrearMovimientoCaja(cmd, tipo_movimiento_id, fecha, caja_id, total, dotacion_id, 1) Then
                                Else
                                    'no puedo crear movimiento de caja
                                    'caja ya cerrada para esa fecha
                                    retVal = False
                                End If

                            End If
                        End If
                    End If
                Case 1
                    retVal = False
                    If estado = 2 Then
                        If validar Then
                            retVal = True
                        Else
                            cmd.Parameters.Clear()
                            Dim estadoParam As New Odbc.OdbcParameter("@estado", estado)
                            Dim estado_anteriorParam As New Odbc.OdbcParameter("@estado_anterior", estado_anterior)
                            cmd.Parameters.Add(estadoParam)
                            cmd.Parameters.Add(dotacion_idParam)
                            cmd.Parameters.Add(estado_anteriorParam)
                            If ExecuteNonQuery(cmd, sqlCambiaEstadoDotacion) <> 1 Then
                                'no puedo cambiar estado
                                retVal = False
                            Else
                                retVal = True
                            End If
                        End If


                    End If
            End Select

            If retVal = False Then
                errorCode = 1   'no se podria hacer el cambio
                AgregaInfo("CambiarEstadoDotacion", "No puedo cambiar el estado de la dotacion:" & dotacion_id, -errorCode)
            End If


            Return retVal
        End Function
        Function CambiarEstadoDotacion(ByVal dotacion_id, ByVal estado, ByVal validar)
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = CambiarEstadoDotacion(cmd, dotacion_id, estado, validar)
            If retVal = False Then
                errorCode = 1   'no se podria hacer el cambio
            End If
            If Not flushConection(cmd, errorCode) Then
                retVal = False
            End If
            Return retVal
        End Function

        Function CambiarEstadoGasto(ByVal gasto_id, ByVal estado, ByVal validar)
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = CambiarEstadoGasto(cmd, gasto_id, estado, validar)
            If retVal = False Then
                errorCode = 1   'no se podria hacer el cambio
            End If
            If Not flushConection(cmd, errorCode) Then
                retVal = False
            End If
            Return retVal
        End Function
        Shared sqlEstadoCobro = "select cobros.hotel_id as hotel_id,ifnull(fecha,CURDATE()) as fecha,forma_pago_id,cobros.tipo_cobro_id as tipo_cobro_id ,tipos_cobro.tipo_movimiento_id as tipo_movimiento_id,estado_cobro_id,caja_id,(select sum(importe) from lineas_cobro l where l.cobro_id=cobros.cobro_id)*signo as total from cobros inner join tipos_cobro on tipos_cobro.tipo_cobro_id=cobros.tipo_cobro_id where cobro_id=?"
        'Dim sqlEstadoCobroOld = "select forma_pago_id,tipo_cobro_id,(select tipo_movimiento_id from tipos_cobro l where l.tipo_cobro_id=cobros.tipo_cobro_id) as tipo_movimiento_id,fecha,estado_cobro_id,caja_id,(select sum(importe) from lineas_cobro l where l.cobro_id=cobros.cobro_id) as total from cobros where cobro_id=?"
        Shared sqlCambiaEstadoCobro = "update cobros set estado_cobro_id=?,fecha=? where cobro_id=? and estado_cobro_id=?"
        Shared sqlCuentaLineasCobro = "select count(*) from lineas_cobro where cobro_id=?"

        Shared sqlFacturasCambiarEstado = "SELECT distinct lineas_cobro.factura_id FROM lineas_cobro Inner Join facturas ON lineas_cobro.factura_id = facturas.factura_id" _
        & " WHERE lineas_cobro.cobro_id =  ? AND facturas.serie_id =  '5'"
        Shared sqlCambiarFechaEstadoFactura = "update facturas set fecha_factura=?,estado_factura_id=1 where factura_id =?"
        Private Function CambiarEstadoCobro(ByVal cmd As Odbc.OdbcCommand, ByVal cobro_id As Integer, ByVal estado As Integer, ByVal validar As Boolean, Optional ByVal fecha As Object = Nothing)
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0

            cmd.Parameters.Clear()
            Dim cobro_idParam As New Odbc.OdbcParameter("@cobro_id", cobro_id)
            cmd.Parameters.Add(cobro_idParam)
            Dim estado_anterior As Integer = Nothing
            Dim datos As DataTableReader = getDataTable(cmd, sqlEstadoCobro)
            Dim caja_id As Integer
            Dim total As Single
            Dim tipo_cobro_id As Integer
            Dim forma_pago_id As Integer
            Dim tipo_movimiento_id As Integer
            While datos.Read
                If IsNothing(fecha) Then
                    fecha = datos.Item("fecha")
                End If
                estado_anterior = datos.Item("estado_cobro_id")
                caja_id = datos.Item("caja_id")
                If Not datos.IsDBNull(datos.GetOrdinal("total")) Then
                    total = datos.Item("total")
                End If
                tipo_cobro_id = datos.Item("tipo_cobro_id")
                forma_pago_id = datos.Item("forma_pago_id")
                tipo_movimiento_id = datos.Item("tipo_movimiento_id")
            End While
            Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)


            Select Case estado_anterior
                Case 0
                    If estado = 1 And ExecuteScalar(cmd, sqlCuentaLineasCobro) > 0 Then
                        'todo comprobar que tiene al menos 1 linea
                        'todo comprobar que todas las facturas esten al menos actualizadas.
                        retVal = True
                        If Not validar Then
                            'todo cambiar estado
                            cmd.Parameters.Clear()
                            Dim estadoParam As New Odbc.OdbcParameter("@estado", estado)
                            Dim estado_anteriorParam As New Odbc.OdbcParameter("@estado_anterior", estado_anterior)
                            cmd.Parameters.Add(estadoParam)
                            cmd.Parameters.Add(fechaParam)
                            cmd.Parameters.Add(cobro_idParam)
                            cmd.Parameters.Add(estado_anteriorParam)
                            If ExecuteNonQuery(cmd, sqlCambiaEstadoCobro) <> 1 Then
                                'no puedo cambiar estado
                                retVal = False
                            Else
                                'creo movmientos de cobro en caja asignada si la caja esta abierta
                                '1 cobro-2 devolucion,3=8,9
                                'If tipo_cobro_id = 3 Then
                                'tipo_cobro_id = 8 'y 9
                                'End If

                                'todo si tipo mov es 0(anticipos) no hay moviemiento de cajas
                                If tipo_movimiento_id <> 0 Then
                                    If CrearMovimientoCaja(cmd, tipo_movimiento_id, fecha, caja_id, total, cobro_id, forma_pago_id) Then
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.Add(cobro_idParam)
                                        Dim factura_idParam As New Odbc.OdbcParameter("@fecha", 0)
                                        'pasar a estado 1 cualquier factura de serie 6 que estuviese en estado 2
                                        Dim reader As DataTableReader = getDataTable(cmd, sqlFacturasCambiarEstado)
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.Add(fechaParam)
                                        cmd.Parameters.Add(factura_idParam)
                                        While reader.Read And retVal
                                            factura_idParam.Value = reader("factura_id")
                                            Console.WriteLine(factura_idParam.Value)
                                            'esas facturas se tienen ke cobrar en su totalidad..

                                            If ExecuteNonQuery(cmd, sqlCambiarFechaEstadoFactura) = 1 Then
                                            Else
                                                'retVal = False
                                            End If
                                        End While


                                    Else
                                        'no puedo crear movimiento de caja
                                        'caja ya cerrada para esa fecha
                                        retVal = False
                                    End If
                                End If
                            End If
                        End If
                    End If
                    If estado = 2 Then
                        If validar Then
                            retVal = False
                        Else
                            cmd.Parameters.Clear()
                            Dim estadoParam As New Odbc.OdbcParameter("@estado", estado)
                            Dim estado_anteriorParam As New Odbc.OdbcParameter("@estado_anterior", estado_anterior)
                            cmd.Parameters.Add(estadoParam)
                            cmd.Parameters.Add(fechaParam)
                            cmd.Parameters.Add(cobro_idParam)
                            cmd.Parameters.Add(estado_anteriorParam)
                            If ExecuteNonQuery(cmd, sqlCambiaEstadoCobro) = 1 Then
                                retVal = True
                            Else
                                'no puedo cambiar estado
                                retVal = False
                            End If

                        End If
                    End If
                Case 1
                    If estado = 2 Then
                        If validar = True Then
                            retVal = True
                        Else
                            cmd.Parameters.Clear()
                            Dim estadoParam As New Odbc.OdbcParameter("@estado", estado)
                            Dim estado_anteriorParam As New Odbc.OdbcParameter("@estado_anterior", estado_anterior)
                            cmd.Parameters.Add(estadoParam)
                            cmd.Parameters.Add(fechaParam)
                            cmd.Parameters.Add(cobro_idParam)
                            cmd.Parameters.Add(estado_anteriorParam)
                            If ExecuteNonQuery(cmd, sqlCambiaEstadoCobro) = 1 Then
                                retVal = True
                            Else
                                'no puedo cambiar estado
                                retVal = False
                            End If

                        End If
                    Else
                        retVal = False
                    End If

            End Select

            If retVal = False Then
                errorCode = 1   'no se podria hacer el cambio
                AgregaInfo("CambiarEstadoCobro", "No puedo cambiar el estado del cobro:" & cobro_id, -errorCode)
            End If


            Return retVal
        End Function

        Function CambiarEstadoCobro(ByVal cobro_id As Integer, ByVal estado As Integer, ByVal validar As Boolean, Optional ByVal fecha As Object = Nothing)
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = CambiarEstadoCobro(cmd, cobro_id, estado, validar, fecha)
            If retVal = False Then
                errorCode = 1   'no se podria hacer el cambio
            End If
            If Not flushConection(cmd, errorCode) Then
                retVal = False
            End If
            Return retVal
        End Function
        Shared sqlBorrarMovimientoCaja As String = "delete from movimientos_caja where item_id=? and tipo_movimiento_id=? and caja_id=? and fecha=?"
        Shared sqlBorrarLineasCobro As String = "delete from lineas_cobro where cobro_id=?"
        Shared sqlBorrarCobro As String = "delete from cobros where cobro_id=?"
        Function AnularCobro(ByVal cobro_id As Integer)
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try


                cmd.Parameters.Clear()
                Dim cobro_idParam As New Odbc.OdbcParameter("@cobro_id", cobro_id)
                cmd.Parameters.Add(cobro_idParam)
                Dim datos As DataTableReader = getDataTable(cmd, sqlEstadoCobro)
                While datos.Read
                    'comprobar ke la fecha del cobro sea igual que la fecha del hotel actual
                    Dim fecha_hotel As Date = FechaHotel(cmd, datos("hotel_id"))
                    If fecha_hotel = datos("fecha") Then
                        'comprobar ke la caja no este cerrada
                        If EstaCajaAbierta(cmd, datos("caja_id"), fecha_hotel) Then
                            'borrar el movimiento de caja
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add(cobro_idParam)
                            Dim tipo_movimiento_idParam As New Odbc.OdbcParameter("@tipo_movimiento_id", datos("tipo_movimiento_id"))
                            cmd.Parameters.Add(tipo_movimiento_idParam)
                            Dim caja_idParam As New Odbc.OdbcParameter("@caja_id", datos("caja_id"))
                            cmd.Parameters.Add(caja_idParam)
                            Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha_hotel)
                            cmd.Parameters.Add(fechaParam)
                            If ExecuteNonQuery(cmd, sqlBorrarMovimientoCaja) = 1 Then
                                'borrar las lineas del cobro
                                If ExecuteNonQuery(cmd, sqlBorrarLineasCobro) > 0 Then
                                    'borrar la cabecera del cobro
                                    If ExecuteNonQuery(cmd, sqlBorrarCobro) = 1 Then
                                        retVal = True
                                    Else
                                        errorCode = 5   'no se podria hacer la anulacion
                                        AgregaInfo("AnularCobro", "No puedo borrar cabecera del cobro:" & cobro_id, -errorCode)
                                    End If
                                Else
                                    errorCode = 4   'no se podria hacer la anulacion
                                    AgregaInfo("AnularCobro", "No puedo borrar lineas del cobro:" & cobro_id, -errorCode)
                                End If

                            Else
                                errorCode = 3   'no se podria hacer la anulacion
                                AgregaInfo("AnularCobro", "No puedo borrar el mov de caja:" & cobro_id, -errorCode)
                            End If


                        Else
                            errorCode = 2   'no se podria hacer la anulacion
                            AgregaInfo("AnularCobro", "Caja Ya Cerrada..imposible anular cobro:" & cobro_id, -errorCode)
                        End If
                    Else
                        errorCode = 1   'no se podria hacer la anulacion
                        AgregaInfo("AnularCobro", "Fecha del cobro distinto de fecha del hotel:" & cobro_id, -errorCode)
                    End If

                End While
            Catch ex As Exception
                errorCode = 1   'no se podria hacer la anulacion
                AgregaInfo("AnularCobro", "Excepcion:" & cobro_id, -errorCode)
            End Try

            If retVal = False Then
                errorCode = 1   'no se podria hacer el cambio
            End If
            If Not flushConection(cmd, errorCode) Then
                retVal = False
            End If
            Return retVal
        End Function
        '*******************************************************************************************************************************
        ' Funcion que añade un documento de gasto en un cobro.
        ' La cabecera de la factura ya se creó en CCS. Consta de 3 puntos
        '   1.- Update a facturas añadiendo el campo ref2 con la descripción del servicio
        '   2.- Crear una linea de factura con el servicio, impuestos, cantidad y precio
        '   3.- Añadir una linea de cobro al cobro_id
        ' AUTOR : Javier Nuñez
        ' JULIO 2009
        '********************************************************************************************************************************
        Function Actualiza_gasto_en_cobros(ByVal hotel_id As Integer, ByVal cobro_id As Integer, ByVal factura_id As Integer, ByVal servicio_id As Integer, ByVal cantidad As Double, ByVal precio As Double) As String
            Dim ErrorMsg As String = ""
            Dim descripcion As Object = Nothing
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            Dim factura_idParam As New Odbc.OdbcParameter("@factura_id", factura_id)
            Dim servicio_idParam As New Odbc.OdbcParameter("@servicio_id", servicio_id)
            Dim cobro_idParam As New Odbc.OdbcParameter("@cobro_id", cobro_id)
            Dim cantidadParam As New Odbc.OdbcParameter("@cantidad", cantidad)
            Dim precioParam As New Odbc.OdbcParameter("@precio", precio)
            Dim ImporteParam As New Odbc.OdbcParameter("@importe", cantidad * precio)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(servicio_idParam)
            Dim sql As String = "SELECT nombre_servicio FROM servicios WHERE servicio_id = ? "
            descripcion = ExecuteScalar(cmd, sql)
            If IsNothing(descripcion) Then
                ErrorMsg = "Error servicio no encontrado"
            End If
            Dim ref2Param As New Odbc.OdbcParameter("@descripcion", descripcion)
            ' Ponemos Ref2 de la factura la descripcion del servicio en este caso el gasto
            sql = "UPDATE facturas SET " _
            & " ref_fra2 = ? " _
            & " where factura_id = ? "
            cmd.Parameters.Clear()
            cmd.Parameters.Add(ref2Param)
            cmd.Parameters.Add(factura_idParam)
            Dim errorcode = ExecuteNonQuery(cmd, sql)
            If errorcode <> 1 Then
                ErrorMsg = "Error poniendo ref2 en factura=" & sql
                flushConection(cmd, 1)
                Return ErrorMsg
            End If
            ' una vez cambiada la serie, añado las lineas de factura
            ' pero primero buscamos del servicio_id, el impuesto_id y el porc_impuesto
            sql = "SELECT impuestos.impuesto_id,impuestos.porcentaje FROM servicios_hotel " _
            & "Inner Join impuestos ON servicios_hotel.impuesto_id = impuestos.impuesto_id " _
            & "WHERE servicios_hotel.servicio_id =  ? AND servicios_hotel.hotel_id =  ? "
            Dim impuesto_id As Integer
            Dim porcentaje As Double
            cmd.Parameters.Clear()
            cmd.Parameters.Add(servicio_idParam)
            cmd.Parameters.Add(hotel_idParam)
            Dim reader As DataTableReader = getDataTable(cmd, sql)
            While reader.Read
                impuesto_id = reader.Item("impuesto_id")
                porcentaje = reader.Item("porcentaje")
            End While
            Dim impuesto_idParam As New Odbc.OdbcParameter("@impuesto_id", impuesto_id)
            Dim porcentajeParam As New Odbc.OdbcParameter("@porcentaje", porcentaje)
            sql = "INSERT INTO lineas_factura (hotel_id,factura_id,descripcion,cantidad,precio,impuesto_id,porc_impuesto,servicio_id,unidad_calculo_id,tipo_linea_factura,fecha) VALUES (?,?,?,?,?,'1','0',?,'1','A',now())"
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            cmd.Parameters.Add(factura_idParam)
            cmd.Parameters.Add(ref2Param)
            cmd.Parameters.Add(cantidadParam)
            cmd.Parameters.Add(precioParam)
            cmd.Parameters.Add(servicio_idParam)
            cmd.Parameters.Add(impuesto_idParam)
            cmd.Parameters.Add(porcentajeParam)
            errorcode = ExecuteNonQuery(cmd, sql)
            If errorcode <> 1 Then
                ErrorMsg = "Error insertando linea de factura sql=" & sql
                flushConection(cmd, 1)
                Return ErrorMsg
            End If
            ' Cambiamos el estado de ambas facturas a 1 para que ponga nº de contador de facturas
            ' Aunque no se necesita para nada
            If Not (CambiarEstadoFactura(cmd, factura_id, 1, False)) Then
                ErrorMsg = "Error cambiando a estado 1 factura =" & CStr(factura_id)
                flushConection(cmd, 1)
                Return ErrorMsg
            End If
            ' Y ahora la pongo como actualizada
            If Not (CambiarEstadoFactura(cmd, factura_id, 2, False)) Then
                ErrorMsg = "Error cambiando a estado 2 factura =" & CStr(factura_id)
                flushConection(cmd, 1)
                Return ErrorMsg
            End If

            ' Finalmente añadimos la factura de la serie 8 al cobro. 
            sql = "INSERT INTO lineas_cobro (cobro_id,factura_id,importe) VALUES (?,?,?)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add(cobro_idParam)
            cmd.Parameters.Add(factura_idParam)
            cmd.Parameters.Add(ImporteParam)
            errorcode = ExecuteNonQuery(cmd, sql)
            If errorcode <> 1 Then
                ErrorMsg = "Error insertando linea de cobro sql=" & sql
                flushConection(cmd, 1)
                Return ErrorMsg
            End If
            flushConection(cmd, 0)
            Return ErrorMsg
        End Function
        '*******************************************************************************************************************************
        '* Funcion que creando con CCS un descuento para un cobro (son dos cabeceras de factura descuento_id y factura_id)             *
        '* Cambia la serie a uno de ellos, crea la linea del descuento para las dos series una con signo cambiado y añade una al cobro *
        '* Javier Nuñez                                                                                                                *
        '* MAYO 2009                                                                                                                   *
        '* Modificacion Septiembre 2009                                                                                                *
        '* Mismo caso que deposito pero con serie_id = 4 y la nueva factura no cambia de serie                                         *
        '*******************************************************************************************************************************
        Function Actualiza_descuento_en_cobros(ByVal hotel_id As Integer, ByVal cobro_id As Integer, ByVal factura_id As Integer, ByVal descuento_id As Integer, ByVal descripcion As String, ByVal cantidad As Double, ByVal precio As Double, ByVal serie_id As Integer) As String
            Dim ErrorMsg As String = ""
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim factura_idParam As New Odbc.OdbcParameter("@factura_id", factura_id)
            Dim descuento_idParam As New Odbc.OdbcParameter("@descuento_id", descuento_id)
            Dim cobro_idParam As New Odbc.OdbcParameter("@cobro_id", cobro_id)
            Dim descripcionParam As New Odbc.OdbcParameter("@descripcion", descripcion)
            Dim cantidadParam As New Odbc.OdbcParameter("@cantidad", cantidad)
            Dim precioParam As New Odbc.OdbcParameter("@precio", precio)
            Dim ImporteParam As New Odbc.OdbcParameter("@importe", cantidad * precio)
            Dim serie_idParam As New Odbc.OdbcParameter("@serie_id", serie_id)
            ' cambio a la serie 6 una de ellas como rectificativa de la anterior
            ' Esta será la que perdurará para otro cobro y a la que habrá que cambiar en la linea de factura el signo a la cantidad
            If serie_id = 7 Then
                serie_idParam.value = 6
            End If
            Dim sql As String = ""
            sql = "UPDATE facturas SET "
            sql = sql & "serie_id=?,"
            sql = sql & "id_factura_rectificada =? "
            sql = sql & " where factura_id = ? "
            cmd.Parameters.Clear()
            cmd.Parameters.Add(serie_idparam)
            cmd.Parameters.Add(factura_idParam)
            cmd.Parameters.Add(descuento_idParam)
            Dim errorcode = ExecuteNonQuery(cmd, sql)
            If errorcode <> 1 Then
                ErrorMsg = "Error cambiando la factura de serie sql=" & sql
                flushConection(cmd, 1)
                Return ErrorMsg
            End If
            ' una vez cambiada la serie, añado las lineas de factura
            ' pero primero buscamos el servicio_id, el impuesto_id y el porc_impuesto
            sql = "SELECT series.servicio_id AS servicio_id,series.impuesto_id As impuesto_id,impuestos.porcentaje As porcentaje " _
            & "FROM series " _
            & "Inner Join impuestos ON series.impuesto_id = impuestos.impuesto_id " _
            & "WHERE series.serie_id = ? "
            cmd.Parameters.Clear()
            cmd.Parameters.Add(serie_idParam)
            Dim servicio_id As Integer
            Dim impuesto_id As Integer
            Dim porcentaje As Double
            Dim reader As DataTableReader = getDataTable(cmd, sql)

            While reader.Read
                servicio_id = reader.Item("servicio_id")
                impuesto_id = reader.Item("impuesto_id")
                porcentaje = reader.Item("porcentaje")
            End While
            Dim servicio_idParam As New Odbc.OdbcParameter("@servicio_id", servicio_id)
            Dim impuesto_idParam As New Odbc.OdbcParameter("@impuesto_id", impuesto_id)
            Dim porcentajeParam As New Odbc.OdbcParameter("@porcentaje", porcentaje)
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            sql = "INSERT INTO lineas_factura (hotel_id,factura_id,descripcion,cantidad,precio,impuesto_id,porc_impuesto,servicio_id,unidad_calculo_id,tipo_linea_factura,fecha) VALUES (?,?,?,?,?,'1','0',?,'1','A',now())"
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            cmd.Parameters.Add(factura_idParam)
            cmd.Parameters.Add(descripcionParam)
            cmd.Parameters.Add(cantidadParam)
            cmd.Parameters.Add(precioParam)
            cmd.Parameters.Add(servicio_idParam)
            cmd.Parameters.Add(impuesto_idParam)
            cmd.Parameters.Add(porcentajeParam)
            errorcode = ExecuteNonQuery(cmd, sql)
            If errorcode <> 1 Then
                ErrorMsg = "Error insertando 1ª linea de factura sql=" & sql
                flushConection(cmd, 1)
                Return ErrorMsg
            End If
            cantidadParam.Value = -cantidad
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            cmd.Parameters.Add(descuento_idParam)
            cmd.Parameters.Add(descripcionParam)
            cmd.Parameters.Add(cantidadParam)
            cmd.Parameters.Add(precioParam)
            cmd.Parameters.Add(servicio_idParam)
            cmd.Parameters.Add(impuesto_idParam)
            cmd.Parameters.Add(porcentajeParam)
            errorcode = ExecuteNonQuery(cmd, sql)
            If errorcode <> 1 Then
                ErrorMsg = "Error insertando 2ª linea de factura sql=" & sql
                flushConection(cmd, 1)
                Return ErrorMsg
            End If
            ' Cambiamos el estado de ambas facturas a 1 para que ponga nº de contador de facturas
            ' Aunque no se necesita para nada
            If Not (CambiarEstadoFactura(cmd, factura_id, 1, False)) Then
                ErrorMsg = "Error cambiando a estado 1 factura =" & CStr(factura_id)
                flushConection(cmd, 1)
                Return ErrorMsg

            End If
            If Not (CambiarEstadoFactura(cmd, descuento_id, 1, False)) Then
                ErrorMsg = "Error cambiando a estado 1 descuento =" & CStr(descuento_id)
                flushConection(cmd, 1)
                Return ErrorMsg
            End If

            ' Ya hora la pongo como actualizada
            If Not (CambiarEstadoFactura(cmd, factura_id, 2, False)) Then
                ErrorMsg = "Error cambiando a estado 2 factura =" & CStr(factura_id)
                flushConection(cmd, 1)
                Return ErrorMsg

            End If
            If Not (CambiarEstadoFactura(cmd, descuento_id, 2, False)) Then
                ErrorMsg = "Error cambiando a estado 2 descuento =" & CStr(descuento_id)
                flushConection(cmd, 1)
                Return ErrorMsg
            End If

            ' Finalmente añadimos la factura de la serie 7 (la invisible) al cobro, quedará pendiente la 6 
            sql = "INSERT INTO lineas_cobro (cobro_id,factura_id,importe) VALUES (?,?,?)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add(cobro_idParam)
            cmd.Parameters.Add(factura_idParam)
            cmd.Parameters.Add(ImporteParam)
            errorcode = ExecuteNonQuery(cmd, sql)
            If errorcode <> 1 Then
                ErrorMsg = "Error insertando linea de cobro sql=" & sql
                flushConection(cmd, 1)
                Return ErrorMsg
            End If
            flushConection(cmd, 0)
            Return ErrorMsg
        End Function


        Shared sqlEstadoFactura = "select estado_factura_id from facturas where factura_id=?"
        Shared sqlCuentaLineasFacturas = "select count(*) from lineas_factura where factura_id=?"
        Shared sqlCambiarEstadoFactura = "update facturas set estado_factura_id=2 where estado_factura_id=1 and factura_id=?"
        Public Function CambiarEstadoFactura(ByVal cmd As Odbc.OdbcCommand, ByVal factura_id As Integer, ByVal estado As Integer, ByVal validar As Boolean) As Boolean
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            If Not RecalculaFactura(cmd, factura_id) Then
                errorCode = 2
                AgregaInfo("CambiarEstadoFactura", "No puedo recalcular la  factura:" & factura_id, -errorCode)
            End If
            If errorCode = 0 Then

                cmd.Parameters.Clear()
                Dim factura_idParam As New Odbc.OdbcParameter("@factura_id", factura_id)
                cmd.Parameters.Add(factura_idParam)
                Dim estado_anterior As Integer = Nothing
                estado_anterior = ExecuteScalar(cmd, sqlEstadoFactura)

                Select Case estado_anterior
                    Case 0
                        If estado = 1 And ExecuteScalar(cmd, sqlCuentaLineasFacturas) > 0 Then
                            'todo comprobar que tiene al menos 1 linea
                            retVal = True
                            If Not validar Then
                                'todo obtener numero de factura
                                If ObtieneNumeroFactura(cmd, factura_id) = -1 Then
                                    retVal = False
                                End If
                            End If
                        End If
                    Case 1
                        If estado = 2 Then
                            If validar Then
                                retVal = True
                            Else
                                If ExecuteNonQuery(cmd, sqlCambiarEstadoFactura) = 1 Then
                                    retVal = True
                                Else
                                    retVal = False
                                End If

                            End If

                        End If
                End Select

                If retVal = False Then
                    errorCode = 1   'no se podria hacer el cambio
                    AgregaInfo("CambiarEstadoFactura", "No puedo cambiar el estado de la factura:" & factura_id, -errorCode)
                End If
            End If

            If errorCode <> 0 Then
                retVal = False
            End If
            Return retVal
        End Function
        Function CambiarEstadoFactura(ByVal factura_id, ByVal estado, ByVal validar)
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = CambiarEstadoFactura(cmd, factura_id, estado, validar)
            If retVal = False Then
                errorCode = 1   'no se podria hacer el cambio
            End If
            If Not flushConection(cmd, errorCode) Then
                retVal = False
            End If
            Return retVal
        End Function
        Shared sqlEstadoReserva = "SELECT estado_reserva_id FROM reservas WHERE reserva_id =  ? "
        'Dim sqlCambiarEstadoReserva = "Update reservas set estado_reserva_id=?,user_id=?,fecha_modificacion=now(),fecha_llegada=fecha_prevista_llegada,fecha_salida=fecha_prevista_salida where reserva_id=? and estado_reserva_id=?"
        'Dim sqlCambiarEstadoReserva = "Update reservas set estado_reserva_id=?,user_id=?,fecha_modificacion=now(),fecha_llegada=null,fecha_salida=null where reserva_id=? and estado_reserva_id=?"
        'Dim sqlCambiarEstadoReserva = "Update reservas set estado_reserva_id=?,user_id=?,fecha_modificacion=now(),fecha_llegada=null where reserva_id=? and estado_reserva_id=?"
        Shared sqlCambiarEstadoReserva = "Update reservas set fecha_salida=case ?<4 when true then null else fecha_salida end,estado_reserva_id=?,user_id=?,fecha_modificacion=now() where reserva_id=? and estado_reserva_id=?"
        Shared sqlCuentaServicios = "SELECT count(*) FROM reservas_servicios WHERE reservas_servicios.reserva_id =  ?"
        Shared sqlCuentaLineasFacturaSinFacturas = "SELECT count(*) FROM lineas_factura Left Join facturas ON lineas_factura.factura_id = facturas.Factura_Id WHERE lineas_factura.reserva_id = ? AND ( facturas.Estado_Factura_Id = 0 or facturas.Estado_Factura_Id is null)"
        '    Dim sqlCuentaServiciosSinContrato = "SELECT count(*)-count(contrato_id) FROM reservas_servicios WHERE reservas_servicios.reserva_id =  ?"
        Shared sqlCuentaLineasFacturaSinFacturasYTipo = "select count(*) from lineas_factura where factura_id is null and lineas_factura.reserva_id=? and tipo_linea_factura=?"
        Shared sqlCuentaLineasFacturaSinFacturasYDistintoTipo = "select count(*) from lineas_factura where factura_id is null and lineas_factura.reserva_id=? and tipo_linea_factura<>?"
        Shared sqlActulizaFechaSalidaLlegadaReserva = "update reservas set fecha_llegada=fecha_prevista_llegada,fecha_salida=? where (permite_devolucion=1 or fecha_prevista_salida=?) and reserva_id=?"
        Shared sqlFacturaAnticipada = "" _
        & " select factura_anticipada from clientes" _
& " where cliente_id =( " _
& " SELECT " _
& " reservas.cliente_id " _
& " FROM " _
& " reservas " _
& " WHERE " _
& " reservas.reserva_id =? " _
& " ) "
        Shared sqlObtieneFechaSalidaYHotelReserva = "select ifnull(fecha_salida,fecha_prevista_salida) as fecha_salida,hotel_id  from reservas where reserva_id=?"

        Function CambiarEstadoReserva(ByVal reserva As Integer, ByVal estado As Integer, ByVal validar As Boolean) As Boolean
            Dim errorCode As Integer = 0
            Dim retVal As Boolean = True
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try
                errorCode = CambiarEstadoReserva(cmd, reserva, estado, validar)
            Catch ex As Exception
                errorCode = 2
            End Try

            If Not flushConection(cmd, errorCode) Then
                retVal = False
            End If
            Return retVal
        End Function
        Shared olddatosReservaActual As tablaServicios = Nothing
        Public Function obtieneServiciosReservaCache(ByVal reserva As Integer)
            Dim datosReservaActual As tablaServicios = Nothing
            If Not IsNothing(olddatosReservaActual) Then
                If olddatosReservaActual.reserva_id = reserva Then
                    datosReservaActual = olddatosReservaActual
                End If
            End If
            If IsNothing(datosReservaActual) Then
                datosReservaActual = obtieneServiciosReserva(reserva)
            End If
            olddatosReservaActual = datosReservaActual
            If Not IsNothing(olddatosReservaActual) Then
                olddatosReservaActual.reserva_id = reserva
            End If
            Return datosReservaActual
        End Function
        Private Function obtieneServiciosReservaCache(ByVal cmd As Odbc.OdbcCommand, ByVal reserva As Integer)
            Dim datosReservaActual As tablaServicios = Nothing
            If Not IsNothing(olddatosReservaActual) Then
                If olddatosReservaActual.reserva_id = reserva Then
                    datosReservaActual = olddatosReservaActual
                End If
            End If
            If IsNothing(datosReservaActual) Then
                datosReservaActual = obtieneServiciosReserva(cmd, reserva)
            End If
            olddatosReservaActual = datosReservaActual
            If Not IsNothing(olddatosReservaActual) Then
                olddatosReservaActual.reserva_id = reserva
            End If
            Return datosReservaActual
        End Function
        Public Function generarEfactura(ByVal factura_id As Integer) As Boolean
            Dim retVal As Boolean = True
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try

                Dim cif_empresa As String = "44503094G"
                Dim cif_hotel As String = "44503094G"
                Dim nombre_hotel As String = "Gran Can"
                Dim nombre_cliente As String = "Cayetano"
                Dim hotel_id As Integer = 2
                Dim numero_factura As String = "1111"
                Dim serie_factura As String = "FAC"
                Dim numero_factura_rectificada As String = Nothing
                Dim serie_factura_rectificada As String = Nothing
                Dim fecha_factura As Date = Today
                Dim direccion_hotel As String = "aki"
                Dim direccion_cliente As String = "alli"
                Dim codigopostal_hotel As String = "35460"
                Dim codigopostal_cliente As String = "35460"
                Dim poblacion_hotel As String = "Galdar"
                Dim provincia_hotel As String = "Galdar"
                Dim poblacion_cliente As String = "Galdar"
                Dim provincia_cliente As String = "Galdar"

                cmd.Parameters.Clear()
                Dim factura_idParam As New Odbc.OdbcParameter("@factura_id", factura_id)
                cmd.Parameters.Add(factura_idParam)

                Dim reader As DataTableReader = getDataTable(cmd, sqlObtieneDatosFacturaParaApunte)

                Dim tefa As New FacturaElectronica.Facturae
                Dim header As New FacturaElectronica.FileHeaderType
                Dim batch As New FacturaElectronica.BatchType
                Dim total_factura As New FacturaElectronica.ImporteType
                total_factura.TotalAmount = 1500.55
                header.Modality = FacturaElectronica.ModalityType.I 'una unica factura
                batch.InvoicesCount = 1 'una unica factura
                batch.BatchIdentifier = "000" & numero_factura
                batch.TotalInvoicesAmount = total_factura
                batch.TotalExecutableAmount = total_factura
                batch.TotalOutstandingAmount = total_factura
                batch.InvoiceCurrencyCode = FacturaElectronica.CurrencyCodeType.EUR 'en euros
                'ahora viene seller (nosotros) buyer(ellos)
                Dim seller_centro(1) As FacturaElectronica.AdministrativeCentreType
                Dim seller As New FacturaElectronica.EmpresaType
                'rellenar datos de hotel
                With seller
                    Dim legal As New FacturaElectronica.LegalEntityType
                    Dim direccion As New FacturaElectronica.AddressType
                    .Item = legal
                    legal.CorporateName = nombre_hotel
                    legal.Item = direccion
                    'FacturaE 3.0,cvc-complex-type.2.4.b: The content of element 'LegalEntity' is not complete. One of '{"":TradeName, "":RegistrationData, "":AddressInSpain, "":OverseasAddress}' is expected.
                    'legal.TradeName = "GRUPO HD"

                    direccion.CountryCode = FacturaElectronica.PaisType.ESP
                    direccion.Address = direccion_hotel
                    direccion.PostCode = codigopostal_hotel
                    direccion.Town = poblacion_hotel
                    direccion.Province = provincia_hotel
                    .TaxIdentification = New FacturaElectronica.TaxIdentificationType
                    .TaxIdentification.PersonTypeCode = FacturaElectronica.PersonTypeCodeType.J 'juridica
                    .TaxIdentification.ResidenceTypeCode = FacturaElectronica.ResidenceTypeCodeType.R 'residente
                    .TaxIdentification.TaxIdentificationNumber = "ES" + cif_hotel
                    '.AdministrativeCentres = seller_centro
                    '.AdministrativeCentres(0) = New FacturaElectronica.AdministrativeCentreType
                    '.AdministrativeCentres(0).CentreCode = hotel_id
                    '.AdministrativeCentres(0).RoleTypeCode = FacturaElectronica.RoleTypeCodeType.Item01

                End With

                Dim buyer_centro(1) As FacturaElectronica.AdministrativeCentreType
                Dim buyer As New FacturaElectronica.EmpresaType

                'rellenar datos de empresa
                With buyer
                    Dim legal As New FacturaElectronica.LegalEntityType
                    Dim direccion As New FacturaElectronica.AddressType
                    .Item = legal
                    legal.Item = direccion
                    legal.CorporateName = nombre_cliente
                    '                    legal.TradeName = nombre_cliente
                    direccion.CountryCode = FacturaElectronica.PaisType.ESP
                    direccion.Address = direccion_cliente
                    direccion.PostCode = codigopostal_cliente
                    direccion.Town = poblacion_cliente
                    direccion.Province = provincia_cliente
                    .TaxIdentification = New FacturaElectronica.TaxIdentificationType
                    .TaxIdentification.PersonTypeCode = FacturaElectronica.PersonTypeCodeType.J 'juridica
                    .TaxIdentification.ResidenceTypeCode = FacturaElectronica.ResidenceTypeCodeType.R 'residente
                    .TaxIdentification.TaxIdentificationNumber = "ES" + cif_empresa
                    '.AdministrativeCentres = buyer_centro
                    '.AdministrativeCentres(0) = New FacturaElectronica.AdministrativeCentreType
                    '.AdministrativeCentres(0).CentreCode = hotel_id
                    '.AdministrativeCentres(0).RoleTypeCode = FacturaElectronica.RoleTypeCodeType.Item01
                End With

                tefa.Parties = New FacturaElectronica.PartiesType
                tefa.Parties.SellerParty = seller
                tefa.Parties.BuyerParty = buyer
                'la factura y sus lineas
                Dim invoices(1) As FacturaElectronica.InvoiceType
                tefa.Invoices = invoices
                tefa.Invoices(0) = New FacturaElectronica.InvoiceType
                tefa.Invoices(0).InvoiceHeader = New FacturaElectronica.InvoiceHeaderType
                With tefa.Invoices(0).InvoiceHeader
                    .InvoiceNumber = numero_factura
                    .InvoiceSeriesCode = serie_factura
                    .InvoiceDocumentType = FacturaElectronica.InvoiceDocumentTypeType.FC 'factura completa
                    If IsNothing(numero_factura_rectificada) Then
                        .InvoiceClass = FacturaElectronica.InvoiceClassType.OO
                    Else
                        .InvoiceClass = FacturaElectronica.InvoiceClassType.OR
                        .Corrective = New FacturaElectronica.CorrectiveType
                        .Corrective.InvoiceNumber = numero_factura_rectificada
                        .Corrective.InvoiceSeriesCode = serie_factura_rectificada

                    End If
                End With
                tefa.Invoices(0).InvoiceIssueData = New FacturaElectronica.InvoiceIssueDataType
                With tefa.Invoices(0).InvoiceIssueData
                    .IssueDate = fecha_factura
                    .InvoiceCurrencyCode = FacturaElectronica.CurrencyCodeType.EUR
                    .TaxCurrencyCode = FacturaElectronica.CurrencyCodeType.EUR
                    .InvoicingPeriod = New FacturaElectronica.PeriodDates
                    .InvoicingPeriod.StartDate = fecha_factura
                    .InvoicingPeriod.EndDate = fecha_factura
                End With
                Dim lista_lineas As New ArrayList
                Dim cuota_total As Decimal = 0
                Dim Total As Decimal = 0
                Dim basecci As FicheroContabilidad.BaseCCI = New FicheroContabilidad.BaseCCI(0)

                While reader.Read
                    Dim linea As New FacturaElectronica.InvoiceLineType
                    Dim Base As Decimal
                    Dim cuota As Decimal
                    With reader
                        Base = Math.Round(.Item("Precio_Base") * .Item("Cantidad"), 2, MidpointRounding.AwayFromZero)
                        Total += Base
                        If .IsDBNull(.GetOrdinal("Porc_Igic")) Or .IsDBNull(.GetOrdinal("CTA_IGIC")) Then
                            retVal = False
                        Else

                            cuota = basecci.agregaImpuesto(.Item("Porc_Igic"), Base, .Item("CTA_IGIC"))
                        End If
                    End With
                    With linea
                        Dim taxes(1) As FacturaElectronica.TaxType
                        .TaxesOutputs = taxes
                        taxes(0) = New FacturaElectronica.TaxType
                        Dim efbase As New FacturaElectronica.ImporteType
                        efbase.TotalAmount = Base - cuota
                        Dim efcuota As New FacturaElectronica.ImporteType
                        efcuota.TotalAmount = cuota
                        taxes(0).TaxableBase = efbase
                        taxes(0).TaxAmount = efcuota
                        'taxes(0).TaxRate = "05,00"
                        taxes(0).TaxRate = reader.Item("Porc_Igic")
                        taxes(0).TaxTypeCode = FacturaElectronica.TaxTypeCodeType.Item01
                        .Quantity = reader("cantidad")
                        .UnitPriceWithoutTax = Math.Round((Base - cuota) / reader("cantidad"), 6)
                        .TotalCost = (Base - cuota)
                        .ItemDescription = reader("descripcion")
                        .GrossAmount = .TotalCost
                    End With
                    lista_lineas.Add(linea)
                End While
                Dim lineas(lista_lineas.Count) As FacturaElectronica.InvoiceLineType
                lista_lineas.ToArray.CopyTo(lineas, 0)
                tefa.Invoices(0).Items = lineas

                Dim imp(1) As FacturaElectronica.TaxType
                'TODO por cada tipo de impuesto generar un total
                imp(0) = New FacturaElectronica.TaxType
                Dim baseimp As New FacturaElectronica.ImporteType()
                baseimp.TotalAmount = 40.15
                imp(0).TaxableBase = baseimp
                imp(0).TaxAmount = baseimp
                imp(0).TaxRate = 15.99
                imp(0).TaxTypeCode = FacturaElectronica.TaxTypeCodeType.Item01
                tefa.Invoices(0).TaxesOutputs = imp

                'tefa.Invoices(0).TaxesWithheld = imp
                tefa.Invoices(0).InvoiceTotals = New FacturaElectronica.InvoiceTotalsType
                With tefa.Invoices(0).InvoiceTotals
                    .TotalGrossAmount = 10.15
                    .TotalGrossAmountBeforeTaxes = 10.15
                    .TotalTaxOutputs = 10.15
                    .TotalTaxesWithheld = 10.15
                    .InvoiceTotal = 10.15

                    .TotalOutstandingAmount = 10.15
                    .TotalExecutableAmount = 10.15
                End With

                'lineas facturas
                'generar base por linea
                'acumular base y cuota

                'batch.InvoiceCurrencyCode =

                header.Batch = batch
                tefa.FileHeader = header
                '            Dim efactura As DataSet = New DataSet("Test")
                '            efactura.ReadXml("C:\Proyectos Codecharge\ClasesGesHotel_tano\ClasesGesHotel\Facturae30.xsd")

                'x()
                'obtener datos de factura
                'obtener el xsd
                'popular datos
                'genera xml
                Dim serializer As New XmlSerializer(GetType(FacturaElectronica.Facturae))
                Dim temp As String
                Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream()
                Dim tem = New System.Xml.XmlTextWriter(stream, System.Text.Encoding.UTF8)
                serializer.Serialize(tem, tefa)
                temp = System.Text.Encoding.UTF8.GetString(stream.ToArray())
                Console.WriteLine(temp)
                'certificar normal xml

                'grabar blob en tabla facturas
            Catch ex As Exception
                retVal = False
            Finally
                'retVal = False
                If Not retVal Then
                    errorCode = 1
                End If
                flushConection(cmd, errorCode)
            End Try
            Return retVal

        End Function
        Shared sqlEnviarEmailReserva = "" _
& " SELECT " _
& " reservas.email,case reservas.estado_reserva_id when 2 then 'Anulacion' else 'Confirmacion' end as estado, " _
& " hoteles.email_reservas, " _
& " hoteles.email_ventas, " _
& " hoteles.email_smtp " _
& " FROM " _
& " reservas" _
& " Inner Join hoteles ON reservas.hotel_id = hoteles.hotel_id " _
& " WHERE " _
& " reservas.reserva_id =  ? AND " _
& " reservas.email IS NOT NULL  "
        Public Function readHtmlPage(ByVal url As String) As String
            Dim result As String
            Dim objResponse As Net.WebResponse
            Dim objRequest As Net.WebRequest = System.Net.HttpWebRequest.Create(url)
            objResponse = objRequest.GetResponse()

            Dim sr As IO.StreamReader = New IO.StreamReader(objResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("windows-1252"))
            result = sr.ReadToEnd
            sr.Close()
            Return result
        End Function

        Function regenerarLineasFacturasReserva(ByVal reserva_id As Integer)
            'Return True
            Dim errorCode As Integer = 0
            Dim retVal As Boolean = True
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try
                cmd.Parameters.Clear()
                Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
                cmd.Parameters.Add(reserva_idParam)
                Dim hotel_id As Integer = ExecuteScalar(cmd, sqlObtieneHotelReserva)
                Dim fecha As Date = FechaHotel(cmd, hotel_id)

                cmd.Parameters.Clear()
                cmd.Parameters.Add(reserva_idParam)

                Dim clientefactura As Boolean
                Dim tmpt = ExecuteScalar(cmd, sqlFacturaAnticipada)
                If IsDBNull(tmpt) Then
                    tmpt = False
                End If
                clientefactura = tmpt
                If clientefactura Then
                    Dim estado_anterior As Integer = Nothing
                    estado_anterior = ExecuteScalar(cmd, sqlEstadoReserva)
                    If estado_anterior >= 3 And estado_anterior <= 4 Then
                        olddatosReservaActual = Nothing
                        Dim datosReservaActual As tablaServicios = obtieneServiciosReservaCache(cmd, reserva_id)

                        If datosReservaActual.sumaErrores = 0 Then
                            Dim fechamin As Date = datosReservaActual.servicios.Compute("min(fecha)", "")
                            Dim fechamax As Date = datosReservaActual.servicios.Compute("max(fecha)", "")
                            'fechamax = fechamax.AddDays(-1)
                            If fechamin < fecha Then
                                fechamin = fecha
                            End If

                            While retVal And fechamin <= fechamax
                                retVal = generaAjuste(cmd, reserva_id, datosReservaActual, fechamin)
                                fechamin = fechamin.AddDays(1)
                                olddatosReservaActual = Nothing
                                datosReservaActual = obtieneServiciosReservaCache(cmd, reserva_id)
                            End While
                            If retVal Then
                                retVal = generaAjuste(cmd, reserva_id, datosReservaActual, Nothing, False, False, Nothing, True)
                                'retVal = generaAjuste(cmd, reserva_id, datosReservaActual)
                            End If
                            If retVal Then
                            Else
                                errorCode = 2
                                AgregaInfo("regenerarLineasFacturasReserva", "No puedo generar Ajuste:" & reserva_id, -errorCode)
                            End If
                        Else
                            errorCode = 1
                            AgregaInfo("regenerarLineasFacturasReserva", "Reserva con errores o sin servicios:" & reserva_id, -errorCode)
                        End If
                    End If
                End If
            Catch ex As Exception
                errorCode = 3
                AgregaInfo("regenerarLineasFacturasReserva", "Execpcion:" & reserva_id, -errorCode)
            End Try
            If Not flushConection(cmd, errorCode) Then
                retVal = False
            End If
            Return retVal
        End Function
        Private Function enviarEmailReserva(ByVal cmd As Odbc.OdbcCommand, ByVal reserva As Integer)
            Try
                cmd.Parameters.Clear()
                Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva)
                cmd.Parameters.Add(reserva_idParam)
                Dim reader As DataTableReader = getDataTable(cmd, sqlEnviarEmailReserva)
                While reader.Read
                    Dim body As String
                    If ConnectionString = "DSN=geshotel" Then
                        body = readHtmlPage("http://srvgeshotel/geshotel/ImpresoReserva.aspx?reserva_id=" & CStr(reserva))
                    Else
                        body = readHtmlPage("http://srvgeshotel/geshotel2/ImpresoReserva.aspx?reserva_id=" & CStr(reserva))

                    End If
                    'Dim body As String = readHtmlPage("http://10.0.0.2/geshotel2/ImpresoReserva.aspx?reserva_id=6329")
                    Dim message As Net.Mail.MailMessage = New Net.Mail.MailMessage(reader("email_ventas"), reader("email"), reader("estado") & " Reserva Nº:" & reserva, body)
                    'Dim plainView As System.Net.Mail.AlternateView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(body, Nothing, "text/plain")
                    'plainView.TransferEncoding = Net.Mime.TransferEncoding.QuotedPrintable
                    'Dim htmlView As System.Net.Mail.AlternateView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(body, Nothing, "text/html")
                    'htmlView.TransferEncoding = Net.Mime.TransferEncoding.QuotedPrintable
                    'message.AlternateViews.Add(plainView)
                    'message.AlternateViews.Add(htmlView)
                    message.IsBodyHtml = True
                    message.BodyEncoding = System.Text.Encoding.GetEncoding("windows-1252")
                    'message.BodyEncoding = System.Text.Encoding.UTF8
                    message.Bcc.Add(reader("email_reservas"))
                    Dim client As Net.Mail.SmtpClient = New Net.Mail.SmtpClient(reader("email_smtp"))
                    client.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials
                    client.Send(message)
                End While
            Catch ex As Exception

            End Try
        End Function
        Function CambiarEstadoReserva(ByVal cmd As Odbc.OdbcCommand, ByVal reserva As Integer, ByVal estado As Integer, ByVal validar As Boolean, Optional ByVal forzarprecheckout As Boolean = False) As Integer

            Dim errorCode As Integer = 0
            Dim retVal As Boolean = False
            Dim datosReservaActual As tablaServicios = obtieneServiciosReservaCache(cmd, reserva)

            If Not IsNothing(datosReservaActual) Then
                Dim nerrores As Integer = datosReservaActual.sumaErrores()
                cmd.Parameters.Clear()
                Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva)
                cmd.Parameters.Add(reserva_idParam)
                Dim estado_anterior As Integer = Nothing
                estado_anterior = ExecuteScalar(cmd, sqlEstadoReserva)
                'todo leer si es de tipo blokeo.
                Dim bloqueo As Boolean = False
                If IsDBNull(estado_anterior) Then
                    'pend. finalizar
                    estado_anterior = 0
                End If
                If IsDBNull(estado) Then
                    'pend. finalizar
                    estado = 0
                End If

                '2:      Anulada
                '3: 	 checked-in
                '4:      checked-out



                Select Case estado_anterior
                    Case 0
                        If estado = 1 Then
                            '1:      Pendiente entrar
                            'TODO para poder actualizar la reserva no puede tener errores

                            'TODO si es de tipo blokeo..comprobar que todas las lineas de reserva
                            'tienen contrato
                            Dim sersincon As Integer = 0
                            If bloqueo Then
                                'sersincon = Me.ExecuteScalar(cmd, sqlCuentaServiciosSinContrato)
                            End If
                            If nerrores = 0 And sersincon = 0 And ExecuteScalar(cmd, sqlCuentaServicios) > 0 Then
                                'TODO: comprobar que tiene al menos una linea de servicios
                                retVal = True
                                

                            Else
                                AgregaInfo("CambiarEstadoReserva", "Reserva con errores o sin servicios:" & reserva, -1)
                            End If
                        End If
                    Case 1
                        '1:      Pendiente entrar
                        If estado = 0 Then
                            'pend. finalizar
                            retVal = True
                        End If

                        If estado = 2 Then
                            '2:      Anulada
                            retVal = True
                            

                        End If
                        If estado = 3 Then
                            '3: 	 checked-in
                            If Not bloqueo Then
                                'TODO Regenerar los contratos de los servicios si no es bloqueo
                                'TODO Obtener contrato activo para esa reserva
                            End If
                            'TODO comprobar que todas las lineas de reserva tienen contrato
                            Dim sersincon As Integer = 0
                            'sersincon = Me.ExecuteScalar(cmd, sqlCuentaServiciosSinContrato)
                            If nerrores = 0 And sersincon = 0 And ExecuteScalar(cmd, sqlCuentaServicios) > 0 Then
                                'TODO: comprobar que tiene al menos una linea de servicios
                                '                            retVal = True
                                'solo permitir checkin si fecha_prevista_desde es la misma que fecha del hotel
                                Dim clientefactura As Boolean
                                Dim tmpt = ExecuteScalar(cmd, sqlFacturaAnticipada)
                                If IsDBNull(tmpt) Then
                                    tmpt = False
                                End If
                                clientefactura = tmpt

                                If ComparaFechaHotel(cmd, reserva) Then
                                    'TODO: si hay facturacion al checking....meter todas las lineas de factura
                                    retVal = True
                                    If Not validar Then


                                        If clientefactura Then
                                            retVal = generaAjuste(cmd, reserva, datosReservaActual, Nothing, True)
                                            If retVal Then
                                                retVal = GeneraFacturasReserva(cmd, reserva)
                                            End If
                                        End If

                                        If Not retVal Then
                                            AgregaInfo("CambiarEstadoReserva", "No puedo facturar al checkin:" & reserva, -1)
                                        Else
                                            'da igual si falla o no
                                            ActivaTelefonosReserva(cmd, reserva, 1)
                                        End If
                                    End If
                                End If

                            Else
                                AgregaInfo("CambiarEstadoReserva", "Reserva con errores o sin servicios:" & reserva, -1)
                            End If
                        End If
                    Case 2
                        '2:      Anulada
                        If estado = 1 Then
                            '1:      Pendiente entrar
                            retVal = True
                        End If
                        If estado = 0 Then
                            'pend. finalizar
                            retVal = True
                        End If
                        'TODO que pasa si esta en checkin y aun no se ha facturado nada?

                    Case 3
                        '3: 	 checked-in
                        If nerrores = 0 And estado = 4 Then
                            '4:      checked-out
                            'TODO: comprobar ke se puede
                            'TODO: cambiar fecha de salida por la fecha del check-out
                            'TODO: generar ajuste 
                            retVal = True
                            If Not validar Then
                                'cambiar fecha salida si se permite devoluciones o fecha prevista salida es igual a fecha hotel
                                'si cliente_id_factura o cliente_id permite factura hacerla
                                retVal = generaAjuste(cmd, reserva, datosReservaActual)

                                'da igual si falla o no
                                ActivaTelefonosReserva(cmd, reserva, 0)
                            End If

                        End If
                        If nerrores = 0 And estado = 5 And Not validar Then
                            'estaba en checkin
                            'da igual si falla o no
                            ActivaTelefonosReserva(cmd, reserva, 1)
                            'ajustar y asignar todo a una factura cuyo cliente es cliente_id_factura o cliente_id 
                            retVal = generaAjuste(cmd, reserva, datosReservaActual)
                            If retVal Then
                                retVal = GeneraFacturasReserva(cmd, reserva)
                                If retVal Then
                                    If obtieneImportePendienteFacturas(cmd, reserva, True, True) <> 0 Or forzarprecheckout = True Then
                                        estado = 4    'falta por cobrar facturas
                                    End If
                                End If
                            End If
                        End If
                    Case 4
                        

                        '4: 	 checked-out
                        If estado = 3 Then
                            '1:      checkin
                            retVal = True
                        End If
                        If nerrores = 0 And estado = 5 Then
                            '5:      checked-out
                            'comprobar ke existan lineas ke aun no esten en facturas actualizadas
                            If ExecuteScalar(cmd, sqlCuentaLineasFacturaSinFacturas) = 0 Then
                                'comprobar que todas sus facturas de contado este cobradas.
                                If obtieneImportePendienteFacturas(cmd, reserva, True) = 0 Then
                                    'comprobar que no tiene anticipos pendientes
                                    If ObtienePendienteAnticipoReserva(cmd, reserva) = 0 Then
                                        retVal = True
                                    Else
                                        'se necesita devolver los anticipos pendientes o consumirlos con una factura
                                        AgregaInfo("CambiarEstadoReserva", "Hay anticipos pendientes para esta reserva:" & reserva, -1)
                                    End If
                                Else
                                    AgregaInfo("CambiarEstadoReserva", "Hay facturas no de credito pendientes de cobro para esta reserva:" & reserva, -1)
                                End If

                            Else
                                AgregaInfo("CambiarEstadoReserva", "Existen lineas de factura sin asignar:" & reserva, -1)
                            End If
                        End If
                    Case 5
                        'poner en pre-checkout una reserva facturada con fecha de salida hoy
                        If estado = 4 Then
                            'obtiene fecha hotel
                            'obtiene fecha salida reserva
                            Dim dt As DataTableReader = getDataTable(cmd, sqlObtieneFechaSalidaYHotelReserva)
                            While dt.Read
                                Dim fecha_hotel As Date = FechaHotel(cmd, dt("hotel_id"))
                                Dim fecha_salida_reserva As Date = dt("fecha_salida")
                                If fecha_hotel = fecha_salida_reserva Then
                                    retVal = True
                                End If
                            End While
                        End If
                End Select
                If nerrores <> 0 Then
                    AgregaInfo("CambiarEstadoReserva", "La reserva tiene lineas con errores:" & reserva, 0)
                End If
                If Not validar And retVal Then
                    'procesar el cambio
                    cmd.Parameters.Clear()
                    Dim estadoParam As New Odbc.OdbcParameter("@estado_id", estado)
                    Dim estadoParam1 As New Odbc.OdbcParameter("@estado_id1", estado)
                    Dim user_idParam As New Odbc.OdbcParameter("@user_id", userId)
                    Dim estado_reserva_idParam As New Odbc.OdbcParameter("@estado_reserva_id", estado_anterior)
                    cmd.Parameters.Add(estadoParam1)
                    cmd.Parameters.Add(estadoParam)
                    cmd.Parameters.Add(user_idParam)
                    cmd.Parameters.Add(reserva_idParam)
                    cmd.Parameters.Add(estado_reserva_idParam)
                    If (ExecuteNonQuery(cmd, sqlCambiarEstadoReserva) = 1) Then
                    Else
                        errorCode = 2 'no se pudo cambiar el estado fisico
                        AgregaInfo("CambiarEstadoReserva", "No se pudo cambiar el estado de la reserva:" & reserva, -errorCode)
                    End If

                End If
            Else
                retVal = False
            End If

            If retVal = False Then
                errorCode = 1   'no se podria hacer el cambio
            Else
                If Not validar And (estado = 1 Or estado = 2) Then
                    enviarEmailReserva(cmd, reserva)
                End If
            End If


            Return errorCode
        End Function
        Private Function GeneraFacturasReserva(ByVal cmd As Odbc.OdbcCommand, ByVal reserva As Integer)
            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva)
            'obtener forma de pago
            'Me.preparaFactura(cmd, 1, reserva)

            'crear 2 facturas una con los mov manuales al primer huesped
            'y la otra mov auto al cliente_id_factura o cliente_id 

            Dim facm As Factura
            Dim retVal1 As Boolean = True
            Dim retVal2 As Boolean = True
            Dim retVal As Boolean = True
            'cuenta cuantas lineas tipo A existen
            Dim tipoParam As New Odbc.OdbcParameter("@tipo", 0)
            tipoParam.Value = "A"
            cmd.Parameters.Clear()
            cmd.Parameters.Add(reserva_idParam)
            cmd.Parameters.Add(tipoParam)
            If Me.ExecuteScalar(cmd, sqlCuentaLineasFacturaSinFacturasYTipo) > 0 Then
                'TODO: crear tantas facturas como pag_facturas existan
                Dim fac As Factura '= abreFactura(cmd, -1, reserva)
                fac = preparaFactura(cmd, 2, reserva)
                Dim cola As New Queue
                If Not IsNothing(fac) Then
                    cola = obtienePag_Factura(fac, "A")
                End If
                If cola.Count = 0 Then
                    retVal = False
                    AgregaInfo("GeneraFacturasReserva", "Error al extraer las pag_factura de la reserva:" & reserva, -1)
                Else
                    While cola.Count > 0 And retVal = True And retVal1 = True
                        If IsNothing(fac) Then
                            fac = preparaFactura(cmd, 2, reserva)
                        End If

                        If Not IsNothing(fac) Then
                            fac.excuteTrans = False
                            If asignaLineasAFactura(fac, "tipo_linea_factura='A'", cola.Dequeue) > 0 Then
                                actualizaFactura(fac)
                                If fac.factura_id <> -1 Then
                                    retVal1 = CambiarEstadoFactura(cmd, fac.factura_id, 1, False)
                                    'todo cobrar factura si es de contado?
                                End If
                            Else
                                retVal = False
                                AgregaInfo("GeneraFacturasReserva", "Factura Sin lineas:" & reserva, -1)
                            End If
                        Else
                            retVal = False
                            AgregaInfo("GeneraFacturasReserva", "No pudo crear cabecera factura lineas automaticas para la Reserva:" & reserva, -1)
                        End If
                        fac = Nothing
                    End While
                End If
            End If
            tipoParam.Value = "A"
            cmd.Parameters.Clear()
            cmd.Parameters.Add(reserva_idParam)
            cmd.Parameters.Add(tipoParam)
            If Me.ExecuteScalar(cmd, sqlCuentaLineasFacturaSinFacturasYDistintoTipo) > 0 Then
                If retVal = True Then
                    facm = preparaFactura(cmd, 1, reserva, True)
                    If Not IsNothing(facm) Then
                        facm.excuteTrans = False
                        If asignaLineasAFactura(facm, "tipo_linea_factura<>'A'") > 0 Then
                            actualizaFactura(facm)
                            If facm.factura_id <> -1 Then
                                retVal2 = CambiarEstadoFactura(cmd, facm.factura_id, 1, False)
                            End If
                        Else
                            retVal = False
                            AgregaInfo("GeneraFacturasReserva", "Factura sin lineas:" & reserva, -1)
                        End If
                    Else
                        retVal = False
                        AgregaInfo("GeneraFacturasReserva", "No pudo crear cabecera factura lineas manuales para la Reserva:" & reserva, -1)

                    End If
                End If
            End If

            If retVal And retVal1 And retVal2 Then
            Else
                retVal = False      'fallo de facturas
                AgregaInfo("GeneraFacturasReserva", "Fallo al crear facturas para la Reserva:" & reserva, -1)

            End If
            Return retVal
        End Function
        Shared sqlObtieneFechaMayorReserva = "select max(fecha) from lineas_factura where lineas_factura.reserva_id=? and lineas_factura.tipo_linea_factura =  'A'"
        Shared sqlObtieneFechaPrevistaSalida = "select ifnull(fecha_salida,fecha_prevista_salida) as fecha_prevista_salida from reservas where reserva_id=?"
        Shared sqlObtieneTotalPorServicio = "" _
    & "     SELECT lineas_factura.tipo_linea_factura,max(lineas_factura.pag_factura) as pag_factura," _
    & " max(lineas_factura.porc_impuesto) as porc_impuesto ,max(lineas_factura.impuesto_id) as impuesto_id,max(lineas_factura.contrato_id) as contrato_id,max(lineas_factura.descripcion) as descripcion,lineas_factura.servicio_id, " _
    & " lineas_factura.unidad_calculo_id," _
    & " Sum(lineas_factura.cantidad) as cantidad, " _
    & " Sum(cantidad*precio) AS baseimponible, " _
    & " Sum(cantidad*ifnull(precio_produccion,precio)) AS baseimponible_produccion, " _
    & " max(fecha) AS fecha " _
    & " FROM " _
    & " lineas_factura" _
    & " WHERE " _
    & " (lineas_factura.tipo_linea_factura =  'A' or lineas_factura.tipo_linea_factura =  'D') AND " _
    & " lineas_factura.reserva_id =  ?  and (lineas_factura.fecha=? or ?=1)" _
    & " GROUP BY " _
    & " lineas_factura.servicio_id," _
    & " lineas_factura.unidad_calculo_id,lineas_factura.tipo_linea_factura"
        '    & " AND lineas_factura.factura_id IS NULL " _
        Shared sqlObtieneHotelReserva = "select hotel_id from reservas where reserva_id=?"
        Shared sqlObiteneDevolucionReserva = "select permite_devolucion from reservas where reserva_id=?"
        Public Function NormalizaReserva(ByVal reserva_id As Integer) As Boolean
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            If Not NormalizaReserva(cmd, reserva_id) Then
                errorCode = 1
            End If
            flushConection(cmd, errorCode)
        End Function
        Private Function NormalizaReserva(ByVal cmd As Odbc.OdbcCommand, ByVal reserva_id As Integer) As Boolean
            'Return True
            Try
                Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
                cmd.Parameters.Clear()
                cmd.Parameters.Add(reserva_idParam)
                Dim reserva As New DataSet
                getDataSet(cmd, sqlCabReserva, reserva, "reserva")
                If reserva.Tables("reserva").Rows.Count > 0 Then
                    Dim cab As DataRow = reserva.Tables("reserva").Rows(0)
                    getDataSet(cmd, sqlReservasHabitaciones, reserva, "habitaciones_bloqueos")
                    getDataSet(cmd, sqlCabHuespedes, reserva, "reservas_huespedes")
                    Dim fecha_hotel As Date = FechaHotel(cmd, cab("hotel_id"))

                    'ajusta habitaciones
                    Dim x As Integer
                    Dim rows As DataRowCollection = reserva.Tables("habitaciones_bloqueos").Rows

                    Dim fecha_salida As Date
                    Dim fecha_llegada As Date
                    Dim fect
                    fect = cab("fecha_salida")
                    If IsDBNull(fect) Then
                        fect = cab("fecha_prevista_salida")
                    End If
                    fecha_salida = fect
                    fect = cab("fecha_llegada")
                    If IsDBNull(fect) Then
                        fect = cab("fecha_prevista_llegada")
                    End If
                    fecha_llegada = fect
                    If fecha_salida < fecha_hotel Then
                        fecha_hotel = fecha_salida
                    End If
                    Dim z As Integer = rows.Count - 1
                    If rows.Count >= 0 Then

                        For x = 0 To z
                            If cab("estado_reserva_id") = 2 Then
                                'borrar las habitaciones
                                rows(x).Delete()
                                'Console.WriteLine("B-" & rows.Count & "-" & reserva_id)
                            Else
                                Dim des As Integer
                                Dim desvio As Boolean = False
                                For des = 0 To z 'rows.Count - 1
                                    If des <> x And (rows(des)("fecha_desde") = rows(x)("fecha_hasta") Or rows(x)("fecha_desde") = rows(des)("fecha_hasta")) Then
                                        desvio = True
                                    End If
                                Next
                                Dim fecha_hasta = rows(x)("fecha_hasta")
                                If Not IsDBNull(fecha_hasta) Then
                                    If Not desvio Then
                                        If z > 0 Then
                                            'Console.WriteLine("N-" & rows.Count & "-" & cab("estado_reserva_id") & "-" & fecha_llegada & "-" & fecha_hasta & " -" & reserva_id)
                                        Else
                                            If fecha_salida <> fecha_hasta Then
                                                'fecha salida habitacion superior...cortarla
                                                rows(x)("fecha_hasta") = fecha_salida
                                                'Console.WriteLine("S-" & rows.Count & "-" & cab("estado_reserva_id") & "-" & fecha_salida & "-" & fecha_hasta & " -" & reserva_id)
                                            End If
                                        End If

                                    Else
                                        If rows.Count = 2 Then
                                            If fecha_salida < fecha_hasta And x = 1 Then
                                                rows(x)("fecha_hasta") = fecha_salida
                                                'Console.WriteLine("S-" & rows.Count & "-" & cab("estado_reserva_id") & "-" & fecha_salida & "-" & fecha_hasta & " -" & reserva_id)
                                            End If
                                        End If
                                    End If
                                End If
                                Dim fecha_desde = rows(x)("fecha_desde")
                                If Not IsDBNull(fecha_desde) Then

                                    If Not desvio Then
                                        If z > 0 Then
                                            'Console.WriteLine("N-" & rows.Count & "-" & cab("estado_reserva_id") & "-" & fecha_llegada & "-" & fecha_desde & " -" & reserva_id)
                                        Else
                                            If fecha_llegada <> fecha_desde Then
                                                rows(x)("fecha_desde") = fecha_llegada
                                                'Console.WriteLine("L-" & rows.Count & "-" & cab("estado_reserva_id") & "-" & fecha_llegada & "-" & fecha_desde & " -" & reserva_id)
                                            End If
                                        End If
                                    Else
                                        If z = 1 Then
                                            If fecha_llegada <> fecha_desde And x = 0 Then
                                                rows(x)("fecha_desde") = fecha_llegada
                                                'Console.WriteLine("D-" & rows.Count & "-" & cab("estado_reserva_id") & "-" & fecha_llegada & "-" & fecha_desde & " -" & reserva_id)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next

                        'getDataSet(cmd, sqlReservasHabitaciones, reserva, "habitaciones_bloqueos")
                        'ajusta huespedes

                        rows = reserva.Tables("reservas_huespedes").Rows
                        z = rows.Count - 1
                        If rows.Count >= 0 Then
                            For x = 0 To z
                                If rows(x)("fecha_llegada") < fecha_llegada Then
                                    rows(x)("fecha_llegada") = fecha_llegada
                                End If
                                If rows(x)("fecha_llegada") > fecha_llegada Then
                                    Dim y = reserva.Tables("reservas_huespedes").Compute("count(fecha_llegada)", "fecha_llegada='" & rows(x)("fecha_llegada") & "'")
                                    If IsDBNull(y) Then
                                        y = 0
                                    End If
                                    If y = z + 1 Then
                                        For y = 0 To z
                                            rows(y)("fecha_llegada") = fecha_llegada
                                        Next
                                        'Console.WriteLine("G-" & cab("estado_reserva_id") & "-" & reserva_id)
                                    Else
                                        'Console.WriteLine("F-" & cab("estado_reserva_id") & "-" & reserva_id)

                                    End If
                                End If
                                If Not rows(x).IsNull("fecha_salida") Then
                                    If rows(x)("fecha_salida") > fecha_salida Then
                                        rows(x)("fecha_salida") = fecha_salida
                                    End If
                                End If
                                'If rows(x).IsNull("habitacion_id") Then
                                Dim rrows() As DataRow = reserva.Tables("habitaciones_bloqueos").Select("fecha_desde<='" & fecha_hotel & "' and fecha_hasta>='" & fecha_hotel & "' ")
                                If rrows.Length > 0 Then
                                    If rrows(0)("habitacion_id") > 0 Then
                                        If rows(x).IsNull("habitacion_id") Then
                                            'Console.WriteLine("C-" & rrows.Length & "-" & cab("estado_reserva_id") & "-" & rrows(0)("habitacion_id") & "-" & reserva_id)
                                            rows(x)("habitacion_id") = rrows(0)("habitacion_id")
                                        Else
                                            If rows(x)("habitacion_id") <> rrows(0)("habitacion_id") Then
                                                'Console.WriteLine("C-" & rrows.Length & "-" & cab("estado_reserva_id") & "-" & rrows(0)("habitacion_id") & "-" & rows(x)("habitacion_id") & "-" & reserva_id)
                                                rows(x)("habitacion_id") = rrows(0)("habitacion_id")
                                            End If
                                        End If

                                    End If
                                End If
                                'End If
                            Next
                        End If
                        If reserva.HasChanges Then
                            Dim writer As Odbc.OdbcDataAdapter
                            If Not IsNothing(reserva.Tables("habitaciones_bloqueos").GetChanges) Then
                                writer = getDataAdapter(cmd, sqlReservasHabitaciones)
                                writer.Fill(reserva.Tables("habitaciones_bloqueos"))
                                writer.Update(reserva.Tables("habitaciones_bloqueos"))
                            End If
                            If Not IsNothing(reserva.Tables("reservas_huespedes").GetChanges) Then
                                writer = getDataAdapter(cmd, sqlCabHuespedes)
                                writer.Fill(reserva.Tables("reservas_huespedes"))
                                writer.Update(reserva.Tables("reservas_huespedes"))
                            End If
                            
                        End If
                    End If

                End If
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function
        Public Function generaAjuste(ByVal reserva As Integer, ByVal datosnuevos As tablaServicios, Optional ByVal fechaini As String = Nothing, Optional ByVal alcheckin As Boolean = False, Optional ByVal soloAgregar As Boolean = False, Optional ByVal tipo_linea_fac As String = Nothing)
            Dim errorCode As Integer = 1
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim resultado = generaAjuste(cmd, reserva, datosnuevos, fechaini, alcheckin, soloAgregar, tipo_linea_fac)
            If Not flushConection(cmd, errorCode) Then
                resultado = Nothing
            End If
            Return resultado
        End Function
        Private Function generaAjuste(ByVal cmd As Odbc.OdbcCommand, ByVal reserva As Integer, ByVal datosnuevos As tablaServicios, Optional ByVal fechaini As String = Nothing, Optional ByVal alcheckin As Boolean = False, Optional ByVal soloAgregar As Boolean = False, Optional ByVal tipo_linea_fac As String = Nothing, Optional ByVal regenera As Boolean = False)
            Try


                Dim datos As DataSet = getDataSet(cmd, sqlLineasFacturasPorDiaYHotel)
                Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva)
                Dim nerrores As Integer = datosnuevos.sumaErrores()
                'cambiar fecha salida si se permite devoluciones o fecha prevista salida es igual a fecha hotel
                cmd.Parameters.Clear()
                cmd.Parameters.Add(reserva_idParam)
                Dim fechamayor As Object = ExecuteScalar(cmd, sqlObtieneFechaMayorReserva)
                Dim fecha_prevista_salida As Object = ExecuteScalar(cmd, sqlObtieneFechaPrevistaSalida)
                Dim hotel_id As Integer = ExecuteScalar(cmd, sqlObtieneHotelReserva)
                Dim devo As Boolean = ExecuteScalar(cmd, sqlObiteneDevolucionReserva)
                Dim fecha As Date = FechaHotel(cmd, hotel_id)
                'todo regeneerar
                'crear todo lo ke le toca desde la fecha hotel hasta fecha prevista salida
                'ajustar al ultimo dia..lo ke faltaria del pasado

                'If regenera Then
                'fechaini = fecha
                'End If
                If alcheckin Then
                    fechaini = fecha
                    'datosnuevos.borrarDeTabla("1=1")
                End If
                'obtener fecha mayor lineas
                If Not IsDBNull(fechamayor) And IsNothing(fechaini) And Not devo Then
                    'si fecha>=fecha del hotel y fecha>fecha prevista salida coger la fecha prevista salida
                    fechamayor = fechamayor.AddDays(1)
                    If (fechamayor >= fecha And fechamayor >= fecha_prevista_salida) Or regenera Then
                        If fecha_prevista_salida >= fecha Then
                            fecha = fecha_prevista_salida
                        End If
                    Else
                        fecha = fechamayor
                    End If
                End If

                'solo si es genera ajuste final
                If IsNothing(fechaini) And Not regenera Then
                    'borrar lineas superiores a la fecha del hotel si soporta devolucion y no estan incluidas en facturas
                    Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
                    Dim fecha1Param As New Odbc.OdbcParameter("@fecha1", fecha)
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(fechaParam)
                    cmd.Parameters.Add(fecha1Param)
                    cmd.Parameters.Add(reserva_idParam)
                    If Me.ExecuteNonQuery(cmd, sqlActulizaFechaSalidaLlegadaReserva) = 1 Then
                        'NormalizaReserva(cmd, reserva)
                        datosnuevos = obtieneServiciosReserva(cmd, reserva)
                        If IsNothing(datosnuevos) Then
                            nerrores = 1
                        Else
                            nerrores = datosnuevos.sumaErrores()
                        End If

                    End If
                End If
                'añadir columna virtual cantidad*precio_produccion
                datosnuevos.servicios.Columns.Add("importe_produccion", System.Type.GetType("System.Double"), "cantidad*precio_produccion")

                Dim fechaIniParam As New Odbc.OdbcParameter("@fechaIni", Now)
                If IsDate(fechaini) Then
                    fechaIniParam.Value = CDate(fechaini)
                End If
                Dim todosParam As New Odbc.OdbcParameter("@todos", 0)
                If IsNothing(fechaini) Then
                    todosParam.Value = 1
                End If



                'Dim resultado As New tablaServicios
                If nerrores = 0 Then
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(reserva_idParam)

                    cmd.Parameters.Add(fechaIniParam)
                    cmd.Parameters.Add(todosParam)
                    Dim reader As DataTableReader = getDataTable(cmd, sqlObtieneTotalPorServicio)
                    If Not IsNothing(fechaini) And alcheckin = False Then
                        datosnuevos.borrarDeTabla("fecha<>'" & fechaini & "'")
                        fecha = fechaini
                        devo = False
                    End If
                    While reader.Read And Not soloAgregar
                        'TODO borrar de tabla nueva los fechas superiores al dia maximo ya facturado si hay devolucion
                        'TODO nuevo precio_produccion
                        'todo filtrar servicios contrato defecto y contratos normales para no mezclar los ajustes
                        Dim tipocontrato As Integer = 0
                        If reader.Item("tipo_linea_factura") = "A" Then
                            tipocontrato = 0
                        Else
                            tipocontrato = 1
                        End If
                        'For tipocontrato = 0 To 1
                        Dim filtro As String = "defecto=" & tipocontrato & " and servicio_id=" & reader.Item("servicio_id") & "  and ucid=" & reader.Item("unidad_calculo_id")
                        If devo Then
                            datosnuevos.borrarDeTabla(filtro & " and fecha>'" & reader.Item("fecha") & "'")
                        End If
                        Dim numreg As Integer = datosnuevos.servicios.Select(filtro).Length
                        Dim cant As Single = 0
                        Dim baseimponible As Single = 0
                        Dim baseimponible_produccion As Single = 0
                        Dim contrato_id As Integer
                        Dim descripcion As String
                        Dim impuesto_id As Integer
                        Dim porc_impuesto As Single
                        Dim servicio_id As Integer
                        Dim ucid As Integer
                        Dim pag_factura As Integer
                        Dim tipo_linea_factura As String = "A"
                        'If tipocontrato = 1 Then
                        'tipo_linea_factura = "D"
                        'End If
                        'If reserva = 1415 Then
                        'reserva += 1
                        'reserva -= 1
                        'End If
                        If numreg = 0 Then
                            If reader.IsDBNull(reader.GetOrdinal("contrato_id")) Then
                                contrato_id = 0
                            Else
                                contrato_id = reader.Item("contrato_id")
                            End If

                            descripcion = reader.Item("descripcion")
                            impuesto_id = reader.Item("impuesto_id")
                            porc_impuesto = reader.Item("porc_impuesto")
                            servicio_id = reader.Item("servicio_id")
                            ucid = reader.Item("unidad_calculo_id")
                            Dim dpag = reader.Item("pag_factura")
                            If IsDBNull(dpag) Then
                                pag_factura = 1
                            Else
                                pag_factura = dpag
                            End If
                            'pag_factura = reader.Item("pag_factura")
                            tipo_linea_factura = reader.Item("tipo_linea_factura")
                        Else
                            cant = datosnuevos.servicios.Compute("sum(cantidad)", filtro)
                            baseimponible = datosnuevos.servicios.Compute("sum(importe)", filtro) 'es la misma ke produccion
                            baseimponible_produccion = datosnuevos.servicios.Compute("sum(importe_produccion)", filtro)
                            Dim contrato_idt = datosnuevos.servicios.Compute("max(contrato_id)", filtro)
                            If IsDBNull(contrato_idt) Then
                                contrato_id = 0
                            Else
                                contrato_id = contrato_idt
                            End If

                            descripcion = datosnuevos.servicios.Compute("max(descripcion)", filtro)
                            impuesto_id = datosnuevos.servicios.Compute("max(impuesto_id)", filtro)
                            porc_impuesto = datosnuevos.servicios.Compute("max(porc_impuesto)", filtro)
                            servicio_id = datosnuevos.servicios.Compute("max(servicio_id)", filtro)
                            ucid = datosnuevos.servicios.Compute("max(ucid)", filtro)
                            Dim dpag = datosnuevos.servicios.Compute("max(pag_factura)", filtro)
                            If IsDBNull(dpag) Then
                                pag_factura = 1
                            Else
                                pag_factura = dpag
                            End If

                            Dim defecto As Integer = datosnuevos.servicios.Compute("max(defecto)", filtro)
                            If defecto = 0 Then
                                tipo_linea_factura = "A"
                            Else
                                tipo_linea_factura = "D"
                            End If

                        End If
                        'TODO:que pasa con baseimponible_produccion y ajustes?
                        'If CSng(reader.Item("cantidad")) <> cant Or CSng(reader.Item("baseimponible")) <> baseimponible Then
                        If CSng(reader.Item("cantidad")) <> cant Or CSng(reader.Item("baseimponible")) <> baseimponible Or CSng(reader.Item("baseimponible_produccion")) <> baseimponible_produccion Then
                            Console.WriteLine(reader.Item("cantidad") & "-" & cant)
                            Console.WriteLine(reader.Item("baseimponible") & "-" & baseimponible)
                            Console.WriteLine(reader.Item("baseimponible_produccion") & "-" & baseimponible_produccion)
                            cant = cant - reader.Item("cantidad")
                            'ke pasa si cant es cero
                            'casos
                            'cantidad=0 base igual...precio produccion distinto 
                            'devolver lo anterior y crear linea con lo nuevo?
                            'cantidad=0 base distinta...precio produccion distinto
                            'cantidad=0 base distinta...precio produccion igual

                            Dim Row As DataRow
                            baseimponible = (baseimponible - reader.Item("baseimponible")) '/ cant
                            baseimponible_produccion = (baseimponible_produccion - reader.Item("baseimponible_produccion")) '/ cant

                            If cant <> 0 Then
                            Else
                                cant = -1
                                Row = datos.Tables(0).Rows.Add()
                                Row.Item("hotel_id") = hotel_id
                                Row.Item("unidad_calculo_id") = ucid
                                Row.Item("fecha") = fecha 'todo cambiar por fecha del hotel
                                Row.Item("reserva_id") = reserva
                                Row.Item("contrato_id") = contrato_id
                                'Row.Item("descripcion") = "Ajuste-" & descripcion
                                Row.Item("descripcion") = descripcion
                                'baseimponible_produccion = (baseimponible_produccion - reader.Item("baseimponible_produccion")) / cant
                                Row.Item("cantidad") = cant
                                Row.Item("precio") = 0
                                Row.Item("precio_produccion") = 0
                                Row.Item("impuesto_id") = impuesto_id
                                Row.Item("porc_impuesto") = porc_impuesto
                                Row.Item("tipo_linea_factura") = tipo_linea_factura
                                Row.Item("servicio_id") = servicio_id
                                Row.Item("pag_factura") = pag_factura
                                cant = 1
                            End If

                            If Math.Abs(cant) > 1 Or 1 = 1 Then
                                'si la cantidad a ajustar es mayor de 1...para evitar problemas con decimales
                                Dim lcant = cant
                                If cant > 0 Then
                                    cant -= 1
                                Else
                                    cant += 1
                                End If
                                Dim rbaseimponible As Single = 0
                                Dim rbaseimponible_produccion As Single = 0
                                If cant = 0 Then
                                    cant = 0
                                    'rbaseimponible = baseimponible - Math.Truncate(baseimponible)
                                    'rbaseimponible_produccion = baseimponible_produccion - Math.Truncate(baseimponible_produccion)
                                Else
                                    rbaseimponible = baseimponible - (Math.Truncate(baseimponible / cant) * cant)
                                    rbaseimponible_produccion = baseimponible_produccion - (Math.Truncate(baseimponible_produccion / cant) * cant)
                                End If
                                If rbaseimponible <> 0 Or rbaseimponible_produccion <> 0 Then
                                    baseimponible -= rbaseimponible
                                    baseimponible_produccion -= rbaseimponible_produccion
                                    Row = datos.Tables(0).Rows.Add()
                                    Row.Item("hotel_id") = hotel_id
                                    Row.Item("unidad_calculo_id") = ucid
                                    Row.Item("fecha") = fecha 'todo cambiar por fecha del hotel
                                    Row.Item("reserva_id") = reserva
                                    Row.Item("contrato_id") = contrato_id
                                    'Row.Item("descripcion") = "Ajuste-" & descripcion
                                    Row.Item("descripcion") = descripcion
                                    'baseimponible_produccion = (baseimponible_produccion - reader.Item("baseimponible_produccion")) / cant
                                    Row.Item("cantidad") = 1
                                    Row.Item("precio") = rbaseimponible
                                    Row.Item("precio_produccion") = Math.Round(rbaseimponible_produccion, 2, MidpointRounding.AwayFromZero)
                                    Row.Item("impuesto_id") = impuesto_id
                                    Row.Item("porc_impuesto") = porc_impuesto
                                    Row.Item("tipo_linea_factura") = tipo_linea_factura
                                    Row.Item("servicio_id") = servicio_id
                                    Row.Item("pag_factura") = pag_factura
                                Else
                                    cant = lcant
                                End If
                            End If
                            If cant <> 0 Then
                                Row = datos.Tables(0).Rows.Add()
                                Row.Item("hotel_id") = hotel_id
                                Row.Item("unidad_calculo_id") = ucid
                                Row.Item("fecha") = fecha 'todo cambiar por fecha del hotel
                                Row.Item("reserva_id") = reserva
                                Row.Item("contrato_id") = contrato_id
                                'Row.Item("descripcion") = "Ajuste-" & descripcion
                                Row.Item("descripcion") = descripcion
                                'baseimponible_produccion = (baseimponible_produccion - reader.Item("baseimponible_produccion")) / cant
                                Row.Item("cantidad") = cant
                                Row.Item("precio") = baseimponible / cant
                                Row.Item("precio_produccion") = Math.Round(baseimponible_produccion / cant, 2, MidpointRounding.AwayFromZero)
                                Row.Item("impuesto_id") = impuesto_id
                                Row.Item("porc_impuesto") = porc_impuesto
                                Row.Item("tipo_linea_factura") = tipo_linea_factura
                                Row.Item("servicio_id") = servicio_id
                                Row.Item("pag_factura") = pag_factura
                            End If
                        End If
                        datosnuevos.borrarDeTabla(filtro)
                        'Next
                    End While
                    Dim y
                    For y = 0 To datosnuevos.servicios.Rows.Count - 1
                        'agrupar los registros faltantes y añadir al resultado
                        'si permite devolucion...solo las fechas menores a dia de hoy del hotel
                        If devo = False Or datosnuevos.servicios.Rows(y)("fecha") <= fecha Or alcheckin Then
                            Dim Row As DataRow = datos.Tables(0).Rows.Add()
                            Row.Item("hotel_id") = hotel_id
                            Row.Item("unidad_calculo_id") = datosnuevos.servicios.Rows(y)("ucid")
                            If alcheckin Then
                                Row.Item("fecha") = datosnuevos.servicios.Rows(y)("fecha")
                                Row.Item("descripcion") = datosnuevos.servicios.Rows(y)("descripcion")
                            Else
                                Row.Item("fecha") = fecha 'todo cambiar por fecha del hotel
                                'Row.Item("descripcion") = "Ajuste-" & datosnuevos.servicios.Rows(y)("descripcion")
                                Row.Item("descripcion") = datosnuevos.servicios.Rows(y)("descripcion")
                            End If
                            Row.Item("reserva_id") = reserva
                            Row.Item("contrato_id") = datosnuevos.servicios.Rows(y)("contrato_id")
                            Row.Item("cantidad") = datosnuevos.servicios.Rows(y)("cantidad")
                            Row.Item("precio") = datosnuevos.servicios.Rows(y)("precio")
                            Row.Item("precio_produccion") = datosnuevos.servicios.Rows(y)("precio_produccion")
                            Row.Item("impuesto_id") = datosnuevos.servicios.Rows(y)("impuesto_id")
                            Row.Item("porc_impuesto") = datosnuevos.servicios.Rows(y)("porc_impuesto")
                            Dim defecto As Integer = datosnuevos.servicios.Rows(y)("defecto")
                            If defecto = 0 Then
                                Row.Item("tipo_linea_factura") = "A"
                            Else
                                If Not IsNothing(tipo_linea_fac) Then
                                    Row.Item("tipo_linea_factura") = tipo_linea_fac
                                Else
                                    Row.Item("tipo_linea_factura") = "D"
                                End If

                            End If
                            Row.Item("servicio_id") = datosnuevos.servicios.Rows(y)("servicio_id")
                            Row.Item("pag_factura") = datosnuevos.servicios.Rows(y)("pag_factura")
                        End If
                    Next
                    Dim writer As Odbc.OdbcDataAdapter
                    writer = getDataAdapter(cmd, sqlLineasFacturasPorDiaYHotel)
                    writer.Fill(datos.Tables(0))
                    'AddHandler writer.RowUpdating, AddressOf OnRowUpdating
                    writer.Update(datos.Tables(0))
                    Return True
                Else
                    AgregaInfo("generaAjuste", "Existen errores en los servicios (al procesar el ajuste):" & reserva, -1)
                    Return False
                End If
            Catch ex As Exception
                AgregaInfo("generaAjuste", "Execption:" & reserva & "-" & ex.Message, -1)
                Return False
            End Try
        End Function
        Shared sqlMaestroOferta = "select * from ofertas where oferta_id=?"
        Shared sqlHijoLineasOfertas = "select * from ofertas_tipos_de_servicio where oferta_id=?"
        Shared sqlPuedoDuplicarOferta = "SELECT count(*) FROM reservas_ofertas WHERE reservas_ofertas.oferta_id =  ?"
        Function preparaDuplicacionOferta(ByVal oferta As Integer) As duplicarTablas
            'iniciar transaccion
            Dim errorCode As Integer = 0
            Dim retval As Boolean = False
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim ofertaParam As New Odbc.OdbcParameter("@oferta_id", oferta)
            'todo comprobar que ese dia no haya sido generado
            cmd.Parameters.Clear()
            cmd.Parameters.Add(ofertaParam)
            Dim dt As duplicarTablas = Nothing
            Try
                dt = New duplicarTablas(cmd, Me.userId)
                Dim sqlHijos(0) As String
                sqlHijos(0) = sqlHijoLineasOfertas
                Dim nsqlHijos(0) As String
                nsqlHijos(0) = "ofertas_tipos_de_servicio"
                dt.preparaDuplicacion(sqlMaestroOferta, nsqlHijos, sqlHijos, sqlHijos, sqlPuedoDuplicarOferta, "oferta_id", "oferta_id_original", "oferta_id_siguiente")
                If IsNothing(dt) Then
                    errorCode = 2 'no existe registro duplicacion
                    AgregaInfo("preparaDuplicacionOferta", "No existe registro duplicacion oferta:" & oferta, -errorCode)

                End If
            Catch ex As Exception
                errorCode = 1 'error al preparar el duplicado
                AgregaInfo("preparaDuplicacionOferta", "Error al preparar el duplicado oferta:" & oferta, -errorCode)
            End Try

            'finalizar transaccion

            If errorCode <> 0 Then
                dt = Nothing
                If Not IsNothing(cmd.Transaction) Then
                    cmd.Transaction.Rollback()
                End If
            End If

            Return dt
        End Function
        Shared sqlMaestroContrato = "select * from contratos where contrato_id=?"
        Shared sqlHijoLineasDeContrato = "select * from lineas_de_contrato where contrato_id=?"
        Shared sqlHijoFicherosDeContrato = "select * from ficheros_contrato where contrato_id=?"
        Shared sqlHijoOfertas = "select * from ofertas where contrato_id=?" 'todo falta rejilla
        Shared sqlHijosOfertas_rejillas = "select * from ofertas_rejillas where oferta_id in (select oferta_id from ofertas where contrato_id=?)"
        Shared sqlHijosOfertas_codigos = "select * from ofertas_codigos where oferta_id in (select oferta_id from ofertas where contrato_id=?)"
        Shared sqlHijosOfertas_servicios = "select * from ofertas_servicios where oferta_id in (select oferta_id from ofertas where contrato_id=?)"
        Shared sqlPuedoDuplicarContrato = "" _
    & "     SELECT " _
    & "    count(contrato_id) " _
    & " FROM " _
    & "    geshotel.reservas_contratos " _
    & "    INNER JOIN geshotel.reservas  " _
    & "        ON (reservas_contratos.reserva_id = reservas.reserva_id) " _
    & " WHERE reservas_contratos.contrato_id=? and " _
    & " (reservas.bloquear_tarifa =1 or reservas.estado_reserva_id >=4) "
        Shared sqlReservasACambiarAlDuplicar = "" _
    & "     SELECT " _
    & "    distinct reservas_contratos.reserva_id " _
    & " FROM " _
    & "    geshotel.reservas_contratos " _
    & "    INNER JOIN geshotel.reservas  " _
    & "        ON (reservas_contratos.reserva_id = reservas.reserva_id) " _
    & " WHERE reservas_contratos.contrato_id=? and " _
    & " (reservas.bloquear_tarifa =0 and reservas.estado_reserva_id <=3) "
        Private Function CambiarContratosReserva(ByVal cmd As Odbc.OdbcCommand, ByVal contrato_original As Integer, ByVal contrato_duplicado As Integer, ByVal conversionOfertas As DataTable)
            'todo
            'por cada oferta duplicada..llevarse las sub tablas de oferta
            'ofertas_codigos,ofertas_rejillas,ofertas_servicios
            Dim retval As Boolean = False
            Try

            
                Dim contratoParam As New Odbc.OdbcParameter("@contrato_id", contrato_original)
                Dim reservaParam As New Odbc.OdbcParameter("@reserva_id", 0)
                Dim ofertaParam As New Odbc.OdbcParameter("@oferta_id", 0)
                cmd.Parameters.Clear()
                cmd.Parameters.Add(contratoParam)
                Dim reader As DataTableReader = getDataTable(cmd, sqlReservasACambiarAlDuplicar)
                While reader.Read
                    cmd.Parameters.Clear()
                    reservaParam.Value = reader("reserva_id")
                    cmd.Parameters.Add(reservaParam)
                    Dim datos As DataSet = getDataSet(cmd, sqlObtieneReservasContratos)
                    Dim x As Integer
                    For x = 0 To datos.Tables(0).Rows.Count - 1
                        If datos.Tables(0).Rows(x)("contrato_id") = contrato_original Then
                            'para cada reserva...reemplazar contrato_original por contrato_duplicado en reservas_contratos
                            datos.Tables(0).Rows(x)("contrato_id") = contrato_duplicado
                        End If
                    Next
                    Dim writer As Odbc.OdbcDataAdapter
                    writer = getDataAdapter(cmd, sqlObtieneReservasContratos)
                    writer.Fill(datos.Tables(0))
                    writer.Update(datos.Tables(0))
                    'y reemplazar en reservas_ofertas las ofertas del contrato_original por las del contrato_duplicado
                    'para mantener la posible activacion/desactivacion...solo de las manuales
                    'problemas...las automaticas deberia borrarse
                    'si la oferta era manual y paso a automatica tambien deberia borrarse
                    datos = getDataSet(cmd, sqlReservasOfertas)
                    For x = 0 To datos.Tables(0).Rows.Count - 1
                        If datos.Tables(0).Rows(x)("tipo") = "A" Then
                            'si es automatico lo borro...ya lo volvera a coger si toka el regenerador
                            datos.Tables(0).Rows(x).Delete()
                        Else
                            If datos.Tables(0).Rows(x)("activa") = 0 Then
                                'si no esta activo lo borro...ya lo volvera a coger si toka el regenerador
                                datos.Tables(0).Rows(x).Delete()
                            Else
                                Dim destino_id As Integer = 0
                                Dim rows() As DataRow = conversionOfertas.Select("origen_id=" & datos.Tables(0).Rows(x)("oferta_id"))
                                If rows.Length > 0 Then
                                    destino_id = rows(0)("destino_id")
                                End If
                                'localizo el destino_id
                                If destino_id > 0 Then
                                    'si esta activo y ahora es automatico..lo borro
                                    cmd.Parameters.Clear()
                                    ofertaParam.Value = destino_id 'reader("destino_id")
                                    cmd.Parameters.Add(ofertaParam)
                                    Dim desds As DataSet = getDataSet(cmd, sqlMaestroOferta, True)
                                    If desds.Tables(0).Rows(0)("aplicable_auto") = 1 Then
                                        datos.Tables(0).Rows(x).Delete()
                                    End If
                                Else
                                    'no existe en el destino..asi ke ya no va..lo borro
                                    datos.Tables(0).Rows(x).Delete()
                                End If


                            End If
                        End If
                    Next
                    writer = getDataAdapter(cmd, sqlReservasOfertas)
                    writer.Fill(datos.Tables(0))
                    writer.Update(datos.Tables(0))
                    'ultimo paso opcional..regenerar la reserva..quitar para velocidad
                    'obtieneServiciosReserva(cmd, CInt(reader("reserva_id")))

                End While
                retval = True
            Catch ex As Exception
                'fallo goldo
                retval = False
            End Try

            Return retval
        End Function
        Private Sub eventoAlDuplicar(ByVal sender As Object)
            Dim dat As Date = Now
            Dim dt As duplicarTablas = sender
            If CambiarContratosReserva(dt.cmd, dt.objd.origen_id, dt.objd.destino_id, dt.objd.THT_DataTables(2)) = True Then
                'todo oks
            Else
                'algun error...hay ke parar todo!!
                dt.lastError = 1
            End If
            'Console.WriteLine("hits-" & cachedHits)
            'Console.WriteLine("misses-" & cachedHitsMisses)
            'Console.WriteLine("del-" & borrarHits)
            'Dim xxl As TimeSpan = (Now - dat)
            'Console.WriteLine(xxl.ToString)
            '
            'xxl = Nothing
        End Sub
        Function preparaDuplicacionContrato(ByVal contrato As Integer) As duplicarTablas
            'iniciar transaccion
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim contratoParam As New Odbc.OdbcParameter("@contrato_id", contrato)
            'todo comprobar que ese dia no haya sido generado
            cmd.Parameters.Clear()
            cmd.Parameters.Add(contratoParam)
            Dim dt As duplicarTablas = Nothing
            Try
                dt = New duplicarTablas(cmd, Me.userId)
                Dim sqlHijos(5) As String
                sqlHijos(0) = sqlHijoLineasDeContrato
                sqlHijos(1) = sqlHijoFicherosDeContrato
                sqlHijos(2) = sqlHijoOfertas
                sqlHijos(3) = sqlHijosOfertas_rejillas
                sqlHijos(4) = sqlHijosOfertas_codigos
                sqlHijos(5) = sqlHijosOfertas_servicios
                Dim nsqlHijos(5) As String
                nsqlHijos(0) = "lineas_de_contrato"
                nsqlHijos(1) = "ficheros_contrato"
                nsqlHijos(2) = "ofertas"
                nsqlHijos(3) = "ofertas_rejillas"
                nsqlHijos(4) = "ofertas_codigos"
                nsqlHijos(5) = "ofertas_servicios"
                Dim nsqlIdHijos(5) As String
                nsqlIdHijos(0) = "linea_contrato_id"
                nsqlIdHijos(1) = "fichero_id"
                nsqlIdHijos(2) = "oferta_id"
                nsqlIdHijos(3) = "oferta_id"
                nsqlIdHijos(4) = "oferta_id"
                nsqlIdHijos(5) = "oferta_id"
                dt.preparaDuplicacion(sqlMaestroContrato, nsqlHijos, sqlHijos, nsqlIdHijos, sqlPuedoDuplicarContrato, "contrato_id", "contrato_id_original", "contrato_id_siguiente")
                If IsNothing(dt) Then
                    errorCode = 2 'no existe registro duplicacion
                    AgregaInfo("preparaDuplicacionContrato", "No existe registro duplicacion contrato:" & contrato, -errorCode)
                Else
                    AddHandler dt.EndDuplicate, AddressOf eventoAlDuplicar
                End If
            Catch ex As Exception
                errorCode = 1 'error al preparar el duplicado
                AgregaInfo("preparaDuplicacionContrato", "Error al preparar el duplicado contrato:" & contrato, -errorCode)
            End Try

            'finalizar transaccion
            If errorCode <> 0 Then
                dt = Nothing
                If Not IsNothing(cmd.Transaction) Then
                    cmd.Transaction.Rollback()
                End If
            End If

            Return dt
        End Function
        Function cierraDuplicacion(ByVal dt As duplicarTablas)
            Return dt.finalizaDuplicacion()
        End Function
        Shared sqlExisteCierre = "select count(*) from cierres where fecha_cierre=? and hotel_id=?"
        Shared sqlExisteCierreEnTpv = "select count(*) from cierres_tpv where fecha_cierre=? and hotel_id=?"
        Shared sqlExisteCierreTpv = "select fecha_cierre_tpv from cierres where fecha_cierre=? and hotel_id=?"
        Shared sqlCreaCierre = "" _
    & " insert into cierres (fecha_cierre,hotel_id,user_id,fecha_actualizacion) " _
    & " values(?,?,?,now())"

        '    Dim sqlBorrarLineasFacturasAutomaticasPorDia = "" _
        '& " delete from lineas_factura where fecha=? and tipo_linea_factura='A' " _
        '& " and reserva_id in (SELECT reservas.reserva_id FROM reservas WHERE reservas.hotel_id =  ?)"

        'Dim sqlBorrarLineasFacturasAutomaticasPorDia = "delete from lineas_factura where fecha=? and hotel_id=? and tipo_linea_factura='A'"
        Shared sqlObtieneReservasAFacturarPorDia = "" _
    & "     SELECT " _
    & " reservas.reserva_id" _
    & " FROM" _
    & " reservas" _
    & " WHERE" _
    & "    ? BETWEEN  ifnull(reservas.fecha_llegada,reservas.fecha_prevista_llegada) AND ifnull(reservas.fecha_salida,fecha_prevista_salida) and reservas.hotel_id =  ? AND" _
    & " reservas.estado_reserva_id =  3"
        Shared sqlLineasFacturasPorDiaYHotel = "select * from lineas_factura where 1=0"
        '   Dim sqlLineasFacturasPorDiaYHotel = "select * from lineas_factura where fecha=? and tipo_linea_factura='A'"
        Private Function ExisteCierreContable(ByVal cmd As Odbc.OdbcCommand, ByVal hotel As Integer, ByVal fecha As Date, Optional ByVal tpv As Boolean = False) As Boolean
            Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
            Dim hotelParam As New Odbc.OdbcParameter("@hotel", hotel)
            'todo comprobar que ese dia no haya sido generado
            cmd.Parameters.Clear()
            cmd.Parameters.Add(fechaParam)
            cmd.Parameters.Add(hotelParam)
            If tpv Then
                If IsDBNull(ExecuteScalar(cmd, sqlExisteCierreTpv)) Then
                    Return False
                Else
                    Return True
                End If
            Else
                If ExecuteScalar(cmd, sqlExisteCierre) = 0 Then
                    Return False
                End If
                Return True
            End If
        End Function
        Private Function ExisteCierreContableTpv(ByVal cmd As Odbc.OdbcCommand, ByVal hotel As Integer, ByVal fecha As Date) As Boolean
            Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
            Dim hotelParam As New Odbc.OdbcParameter("@hotel", hotel)
            'todo comprobar que ese dia no haya sido generado
            cmd.Parameters.Clear()
            cmd.Parameters.Add(fechaParam)
            cmd.Parameters.Add(hotelParam)

            If ExecuteScalar(cmd, sqlExisteCierreEnTpv) = 0 Then
                Return False
            End If
            Return True
        End Function
        Function generaLineasFacturas(ByVal fecha As Date, ByVal hotel As Integer)
            'iniciar transaccion
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            'Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
            'Dim hotelParam As New Odbc.OdbcParameter("@hotel", hotel)
            'todo comprobar que ese dia no haya sido generado
            'cmd.Parameters.Clear()
            'cmd.Parameters.Add(fechaParam)
            'cmd.Parameters.Add(hotelParam)

            If Not ExisteCierreContable(cmd, hotel, fecha) Then
                'TODO generar Faltantes o Sobrantes por caja

                GenerarFaltantesOSobrantes(cmd, hotel, fecha)
                'borrar todas las lineas de facturas automaticas para ese dia quitar en futuro

                'cmd.Parameters.Clear()
                'cmd.Parameters.Add(fechaParam)
                'cmd.Parameters.Add(hotelParam)
                'ExecuteNonQuery(cmd, sqlBorrarLineasFacturasAutomaticasPorDia)
                Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
                Dim hotelParam As New Odbc.OdbcParameter("@hotel", hotel)

                'obtener lista de reservas activas para ese dia
                cmd.Parameters.Clear()
                cmd.Parameters.Add(fechaParam)
                cmd.Parameters.Add(hotelParam)

                Dim reader As DataTableReader = getDataTable(cmd, sqlObtieneReservasAFacturarPorDia)

                'Dim resultado As New tablaServicios
                ''Dim writer As Odbc.OdbcDataAdapter
                If Not IsNothing(reader) Then
                    Dim reserva_id As Integer
                    Try
                        'Dim datos As DataSet = getDataSet(cmd, sqlLineasFacturasPorDiaYHotel)
                        'Dim mea = startMeasure()

                        While errorCode = 0 And reader.Read
                            'generar tabla de lineas de facturas automaticas para ese dia
                            reserva_id = reader("reserva_id")

                            Dim x As tablaServicios = obtieneServiciosReserva(cmd, reserva_id, fecha, fecha)
                            If IsNothing(x) Then
                                errorCode = 5 'existe una reserva con errores
                                AgregaInfo("generaLineasFacturas", "Existe una reserva vacia:" & reader("reserva_id"), -errorCode)
                            Else
                                If x.erroresAntesBorrar > 0 Then
                                    errorCode = 3 'existe una reserva con errores
                                    AgregaInfo("generaLineasFacturas", "Existe una reserva con errores:" & reader("reserva_id"), -errorCode)
                                Else
                                    If Not generaAjuste(cmd, reader("reserva_id"), x, fecha) Then
                                        errorCode = 4
                                        AgregaInfo("generaLineasFacturas", "No puedo realizar Ajustes diarios:" & reader("reserva_id"), -errorCode)
                                    End If

                                End If
                            End If
                        End While
                        'stopMeasure(mea)
                        'TODO: obtener todos los tickets manuales de ese dia 
                        'y crear las lineas de factura

                        '
                        ''writer = getDataAdapter(cmd, sqlLineasFacturasPorDiaYHotel)
                        ''writer.Fill(datos.Tables(0))
                        ''writer.Update(datos.Tables(0))

                        'actualizar fecha de cierre 
                        Dim useridParam As New Odbc.OdbcParameter("@userid", userId)
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(fechaParam)
                        cmd.Parameters.Add(hotelParam)
                        cmd.Parameters.Add(useridParam)
                        Dim num As Integer = ExecuteNonQuery(cmd, sqlCreaCierre)
                        If num = 1 Then
                            If CrearCierreContable(cmd, fecha, hotel) Then
                                'todo correcto
                                'errorCode = 5
                                Try
                                    'todo crear fichero polica
                                    If ConnectionString <> "DSN=geshotel2" Then
                                        CrearFicheroPolicia(cmd, fecha, hotel)
                                    End If
                                Catch ex As Exception
                                    AgregaInfo("generaLineasFacturas", "No puedo Crear el fichero policia:" & fecha, -errorCode)
                                End Try

                            Else
                                errorCode = 4 'no pudo crear el asiento cierre
                                AgregaInfo("generaLineasFacturas", "No puedo Crear el cierre Contable:" & fecha, -errorCode)
                            End If
                        Else
                            errorCode = 3 'no pudo crear el cierre
                            AgregaInfo("generaLineasFacturas", "No se pudo crear el cierre:" & fecha & "-" & hotel, -errorCode)

                        End If

                    Catch ex As Exception
                        errorCode = 1
                        AgregaInfo("generaLineasFacturas", "No se pudo crear el cierre:" & fecha & "-" & hotel & "-" & reserva_id, -errorCode)

                    Finally

                    End Try
                End If
            Else
                errorCode = 2 'ya existia el cierre
                AgregaInfo("generaLineasFacturas", "Ya existia cierre:" & fecha & "-" & hotel, -errorCode)

            End If
            'errorCode = 1
            'finalizar transaccion
            flushConection(cmd, errorCode)
            flushCache()
            If errorCode = 0 Then
                Try
                    generarPreCheckoutsHotel(hotel)
                Catch ex As Exception
                    AgregaInfo("generaLineasFacturas", "Fallo al hacer los precheckouts:" & fecha, -errorCode)
                End Try
                Try
                    crearLimpiezas(hotel, fecha)
                Catch ex As Exception
                    AgregaInfo("generaLineasFacturas", "No puedo Crear el fichero policia:" & fecha, -errorCode)
                End Try
                Try
                    generarTablasPostCierre(hotel, fecha)
                Catch ex As Exception
                    AgregaInfo("generaLineasFacturas", "No puedo Geenerar Tablas PostCierre:" & fecha, -errorCode)
                End Try
            End If
            Return errorCode
        End Function
        Shared sqlReservasEnCheckingHotelFecha = "" _
& " SELECT " _
& " reservas.reserva_id " _
& " FROM " _
& " reservas" _
& " WHERE " _
& " reservas.estado_reserva_id =  3 AND " _
& " ifnull(reservas.fecha_salida,reservas.fecha_prevista_salida ) =  ? and reservas.hotel_id =  ? "


        Public Function generarPreCheckoutsHotel(ByVal hotel_id As Integer) As Boolean
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try
                Dim fecha As Date = FechaHotel(cmd, hotel_id)

                Dim fechaParam As New Odbc.OdbcParameter("@fecha", Format(fecha, "yyyy-MM-dd"))
                Dim hotelParam As New Odbc.OdbcParameter("@hotel", hotel_id)

                'obtener lista de reservas activas para ese dia
                cmd.Parameters.Clear()
                cmd.Parameters.Add(fechaParam)
                cmd.Parameters.Add(hotelParam)
                Dim reader As DataTableReader = getDataTable(cmd, sqlReservasEnCheckingHotelFecha)
                While reader.Read
                    CambiarEstadoReserva(cmd, reader("reserva_id"), 5, False, True)
                End While
            Catch ex As Exception
                errorCode = 1
            End Try
            flushConection(cmd, errorCode)
            Return True
        End Function

        Shared sqlObtieneCajasHotel = "" _
    & "      SELECT " _
    & " Sum(lineas_arqueo.importe_teorico-lineas_arqueo.importe_real) AS total, " _
    & " arqueos_caja.caja_id, " _
    & " arqueos_caja.fecha,lineas_arqueo.forma_pago_id " _
    & " FROM " _
    & " arqueos_caja " _
    & " Inner Join lineas_arqueo ON lineas_arqueo.arqueo_id = arqueos_caja.arqueo_id " _
    & " Inner Join cajas ON arqueos_caja.caja_id = cajas.caja_id  " _
    & " WHERE " _
    & " arqueos_caja.tipo_arqueo_id =  2 AND " _
    & " cajas.hotel_id =  ? AND " _
    & " arqueos_caja.fecha =  ? " _
    & " GROUP BY " _
    & " arqueos_caja.caja_id, " _
    & " arqueos_caja.fecha,lineas_arqueo.forma_pago_id "
        Private Function GenerarFaltantesOSobrantes(ByVal cmd As Odbc.OdbcCommand, ByVal hotel_id As Integer, ByVal fecha As Date)
            'todo rellenar logica
            cmd.Parameters.Clear()
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
            cmd.Parameters.Add(hotel_idParam)
            cmd.Parameters.Add(fechaParam)
            Dim reader As DataTableReader = Me.getDataTable(cmd, sqlObtieneCajasHotel)
            While reader.Read
                'cada caja tiene ke estar cerrada
                'la suma de los movimientos menos el declarado distinto de zero
                Dim ajuste As Single = reader.Item("total")
                If ajuste <> 0 Then
                    Dim tipomov = 6 'Faltante de caja
                    If ajuste < 0 Then
                        ajuste = -ajuste
                        tipomov = 7 'Sobrante de caja
                    End If
                    'crear el movimiento...saltarse caja cerrada
                    CrearMovimientoCaja(cmd, tipomov, fecha, reader.Item("caja_id"), ajuste, Nothing, reader.Item("forma_pago_id"), True)
                End If
            End While

            Return True
        End Function
        Function GenerarFaltantesOSobrantes(ByVal hotel_id As Integer, ByVal fecha As Date)
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim resultado = GenerarFaltantesOSobrantes(cmd, hotel_id, fecha)
            If Not flushConection(cmd, errorCode) Then
                resultado = Nothing
            End If
            Return resultado
        End Function



        Shared sqlServiciosContratos = "SELECT DISTINCT lineas_de_contrato.servicio_id,servicios.nombre_servicio" _
    & " FROM lineas_de_contrato Inner Join servicios ON lineas_de_contrato.servicio_id = servicios.servicio_id " _
    & " WHERE lineas_de_contrato.contrato_id IN  (?) order by servicios.nombre_servicio "
        Shared sqlObtieneDatosReserva = "" _
            & "     SELECT" _
            & " reservas.hotel_id," _
            & " reservas.cliente_id, " _
            & " reservas.fecha_prevista_llegada as fecha_llegada, " _
            & " reservas.fecha_prevista_salida as fecha_salida " _
            & " FROM " _
            & " reservas " _
            & " WHERE " _
            & " reservas.reserva_id =  ? "
        Function obtieneListaServiciosValida(ByVal reserva_id As Integer) As DataTable
            Dim errorCode As Integer = 0
            Dim resultado As DataTable = Nothing
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try
                cmd.Parameters.Clear()
                'Console.WriteLine(Join(contratos.ToArray, ","))
                Dim reservaParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
                cmd.Parameters.Add(reservaParam)
                Dim reader As DataTableReader = getDataTable(cmd, sqlObtieneDatosReserva)

                While reader.Read
                    resultado = obtieneListaServiciosValida(cmd, reader.Item("hotel_id"), reader.Item("cliente_id"), reader.Item("fecha_llegada"), reader.Item("fecha_salida"))
                End While
                If IsNothing(resultado) Then
                    errorCode = 1
                    AgregaInfo("obtieneListaServiciosValida", "No hay lista de servicios validad:" & reserva_id, -errorCode)
                End If
            Catch ex As Exception
                errorCode = 2
                AgregaInfo("obtieneListaServiciosValida", "No hay lista de servicios validad:" & reserva_id, -errorCode)
            End Try
            If Not flushConection(cmd, errorCode) Then
                resultado = Nothing
            End If
            Return resultado
        End Function
        Function obtieneListaServiciosValida(ByVal hotel_id As Integer, ByVal cliente_id As Integer, ByVal fecha_ini As Date, ByVal fecha_fin As Date) As DataTable
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim resultado As DataTable = obtieneListaServiciosValida(cmd, hotel_id, cliente_id, fecha_ini, fecha_fin)
            If Not flushConection(cmd, errorCode) Then
                resultado = Nothing
            End If
            Return resultado
        End Function
        Private Function obtieneListaServiciosValida(ByVal cmd As Odbc.OdbcCommand, ByVal hotel_id As Integer, ByVal cliente_id As Integer, ByVal fecha_ini As Date, ByVal fecha_fin As Date) As DataTable
            Dim contratos As ArrayList = obtieneContratoActivosCliente(cmd, hotel_id, cliente_id, fecha_ini, fecha_fin)
            Dim resultado As DataTable = obtieneListaServiciosValida(cmd, contratos)
            Return resultado
        End Function

        Private Function obtieneListaServiciosValida(ByVal cmd As Odbc.OdbcCommand, ByVal contratos As ArrayList) As DataTable
            'opcion 1
            'todo...deberia sacar la fecha ini y fecha fin de la reserva
            'todo...obtener lista de contratos del cliente
            'todo...obtener todos los servicios distintos de esa lista de contratos
            'obtieneContratoActivosCliente(cmd, reader.Item("hotel_id"), reader.Item("cliente_id"), reader.Item("fecha_prevista_llegada"), reader.Item("fecha_prevista_salida"))
            cmd.Parameters.Clear()
            'Console.WriteLine(Join(contratos.ToArray, ","))
            'Dim contratosParam As New Odbc.OdbcParameter("@contrato_id", )
            'contratosParam.DbType = DbType.
            'cmd.Parameters.Add(contratosParam)

            Dim reader As DataSet = getDataSet(cmd, Replace(sqlServiciosContratos, "?", Join(contratos.ToArray, ",")))
            Return reader.Tables(0)
        End Function
        Shared sqlTotalFacturasReserva = "" _
& " SELECT " _
& " concat(convert( reservas.estado_reserva_id ,char),'-',convert(ifnull(sum(lineas_factura.cantidad*lineas_factura.precio),'NULL'),char)) " _
& " FROM " _
& "  reservas left join lineas_factura on reservas.reserva_id=lineas_factura.reserva_id  " _
& " WHERE " _
& " reservas.reserva_id = ? "

        Function obtieneImporteTotalReservaFacturas(ByVal reserva_id As Integer, ByVal def As Decimal) As Decimal
            Dim errorCode As Integer = 0
            Dim resultado = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            cmd.Parameters.Clear()
            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
            'Dim defParam As New Odbc.OdbcParameter("@def", def)
            'cmd.Parameters.Add(defParam)
            cmd.Parameters.Add(reserva_idParam)

            Try
                resultado = ExecuteScalar(cmd, sqlTotalFacturasReserva)
                If IsDBNull(resultado) Then
                    resultado = 0
                Else
                    If resultado.substring(0, 2) = "2-" Or resultado.substring(0, 2) = "1-" Or resultado.substring(0, 2) = "0-" Then
                        resultado = def
                    Else
                        resultado = resultado.substring(2).replace(".", ",")
                        If resultado = "NULL" Then
                            resultado = 0
                        End If
                    End If

                End If
            Catch ex As Exception
                errorCode = 0

            End Try

            If Not flushConection(cmd, errorCode) Then
                resultado = 0
            End If
            Return resultado
        End Function
        Shared sqlCobradoReserva = "" _
& " select sum(drv.importe) from" _
& " ( " _
& " SELECT distinct  " _
& " lineas_cobro.linea_cobro, " _
& " lineas_cobro.factura_id, " _
& " lineas_cobro.importe " _
& " FROM " _
& " lineas_factura " _
& " Inner Join facturas ON lineas_factura.factura_id = facturas.factura_id " _
& " Inner Join lineas_cobro ON facturas.factura_id = lineas_cobro.factura_id Inner Join clientes ON facturas.cliente_id = clientes.cliente_id" _
& " WHERE " _
& " lineas_factura.reserva_id =  ? and clientes.permite_credito=0" _
& " ) drv "
        Function obtieneImporteTotalCobradoReserva(ByVal reserva_id As Integer) As Decimal
            Dim errorCode As Integer = 0
            Dim resultado = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            cmd.Parameters.Clear()
            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
            'Dim defParam As New Odbc.OdbcParameter("@def", def)
            'cmd.Parameters.Add(defParam)
            cmd.Parameters.Add(reserva_idParam)

            Try
                resultado = ExecuteScalar(cmd, sqlCobradoReserva)
                If IsDBNull(resultado) Then
                    resultado = 0
                Else
                End If
            Catch ex As Exception
                errorCode = 0

            End Try

            If Not flushConection(cmd, errorCode) Then
                resultado = 0
            End If
            Return resultado
        End Function
        Shared sqlImporteManualReserva = "" _
& " SELECT " _
& " sum(lineas_factura.cantidad*lineas_factura.precio) " _
& " FROM " _
& " lineas_factura " _
& " WHERE " _
& " lineas_factura.reserva_id =  ? AND " _
& " lineas_factura.tipo_linea_factura IN  ('M') "
        Function obtieneImporteManualReserva(ByVal reserva_id As Integer) As Decimal
            Dim errorCode As Integer = 0
            Dim resultado = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            cmd.Parameters.Clear()
            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
            'Dim defParam As New Odbc.OdbcParameter("@def", def)
            'cmd.Parameters.Add(defParam)
            cmd.Parameters.Add(reserva_idParam)

            Try
                resultado = ExecuteScalar(cmd, sqlImporteManualReserva)
                If IsDBNull(resultado) Then
                    resultado = 0
                Else
                End If
            Catch ex As Exception
                errorCode = 0

            End Try

            If Not flushConection(cmd, errorCode) Then
                resultado = 0
            End If
            Return resultado
        End Function
        Function ClientePermiteCredito(ByVal cliente_id As Integer) As Boolean
            Dim errorCode As Integer = 0
            Dim resultado = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", cliente_id)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(cliente_idParam)
            Try
                Dim clientes As DataSet = getDataSet(cmd, sqlCabCliente)
                If clientes.Tables(0).Rows(0)("permite_credito") = 0 Then
                    resultado = False
                Else
                    resultado = True
                End If
            Catch ex As Exception
                errorCode = 0
            End Try
            If Not flushConection(cmd, errorCode) Then
                resultado = False
            End If
            Return resultado
        End Function


        Function obtieneImporteTotalReserva(ByVal reserva_id As Integer, Optional ByVal concobros As Boolean = False) As Decimal
            Dim x As tablaServicios = obtieneServiciosReservaCache(reserva_id)
            'Dim x As tablaServicios = obtieneServiciosReserva(reserva_id)
            If Not IsNothing(x) Then
                If concobros Then
                    Dim total As Single = 0
                    'si el cliente de la reserva permite credito se suma las autos
                    Dim cliente_id As Integer = ObtieneClienteFacturaReserva(reserva_id)
                    If Not ClientePermiteCredito(cliente_id) Then
                        total = x.sumaImporte()
                    End If
                    'total = x.sumaImporte()
                    'resto todo lo cobrado
                    total -= obtieneImporteTotalCobradoReserva(reserva_id)
                    'sumo todo lo manual
                    total += obtieneImporteManualReserva(reserva_id)
                    Return total
                Else
                    Return x.sumaImporte()
                End If

            Else
                Return 0
            End If
        End Function
        Shared sqlObtieneReservasEntreFechas = "" _
    & "     SELECT reserva_id,ifnull(fecha_llegada,fecha_prevista_llegada) as fecha_prevista_llegada,ifnull(fecha_salida,fecha_prevista_salida) as fecha_prevista_salida " _
    & " FROM reservas " _
    & " WHERE ? between ifnull(fecha_llegada,fecha_prevista_llegada) and ifnull(fecha_salida,fecha_prevista_salida) " _
    & " AND reservas.hotel_id = ? and estado_reserva_id not in (0,2) "
        Shared sqlGenTablaSalidaErrores = "SELECT 1 as reserva_id, now() as fecha_prevista_llegada, now() as fecha_prevista_salida, " _
    & "1 AS estado_factura_id, date_format(now(),'%d/%m/%Y' ) AS Fecha_Factura " _
    & " ,'' AS descripcion, 1 AS errores, 1 AS num "

        Function ObtieneErroresReservasOld(ByVal fecha As Date, ByVal hotel_id As Integer) As DataTable
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim resultado As DataSet = Nothing
            Try
                resultado = getDataSet(cmd, sqlGenTablaSalidaErrores)
                resultado.Tables(0).Rows.Clear()
                cmd.Parameters.Clear()
                Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
                Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
                cmd.Parameters.Add(fechaParam)
                cmd.Parameters.Add(hotel_idParam)
                Dim reader As DataTableReader = getDataTable(cmd, sqlObtieneReservasEntreFechas)
                Dim max As Integer = 1
                Dim act As Integer = 0
                'ThreadPool.QueueUserWorkItem(
                While reader.Read 'And act < max
                    act += 1
                    Dim reserva_id As Integer = reader.Item("reserva_id")
                    Dim fllegada As Date = reader.Item("fecha_prevista_llegada")
                    Dim fsalida As Date = reader.Item("fecha_prevista_salida")


                    Dim resulreserva As tablaServicios = obtieneServiciosReserva(cmd, reserva_id, fllegada, reader.Item("fecha_prevista_salida"))

                    Dim errores As Integer = 0
                    If IsNothing(resulreserva) Then
                        errores = 1
                    Else
                        errores = resulreserva.sumaErrores()
                    End If
                    If errores > 0 Then
                        'todo insertar registro en tabla de salida
                        Dim dr As DataRow = resultado.Tables(0).Rows.Add()
                        dr.Item("reserva_id") = reader.Item("reserva_id")
                        dr.Item("fecha_prevista_llegada") = reader.Item("fecha_prevista_llegada")
                        dr.Item("fecha_prevista_salida") = reader.Item("fecha_prevista_salida")
                        dr.Item("estado_factura_id") = 1
                        dr.Item("Fecha_Factura") = fecha
                        dr.Item("descripcion") = "con errores"
                        dr.Item("errores") = errores
                        dr.Item("num") = errores
                    End If
                End While
            Catch ex As Exception
                errorCode = 1
                AgregaInfo("ObtieneErroresReservas", "Fallo al obtener los posibles errores de la reservas:" & ex.Message, -errorCode)
            End Try
            If Not flushConection(cmd, errorCode) Then
                resultado = Nothing
            End If

            If IsNothing(resultado) Then
                Return Nothing
            Else
                Return New DataView(resultado.Tables(0)).ToTable
            End If

        End Function
        Private Class errorContador
            Public contador As Integer
        End Class
        Private Class errorReservaClass
            Public reserva_id As Integer
            Public fecha_ini As Date
            Public fecha_fin As Date
            'Public resultado As DataSet
            'Public contador As errorContador
        End Class
        Private Class bloqueReservas
            Public datos As New System.Collections.Queue
            Public resultado As DataSet
            Public contador As errorContador
            Public fecha As Date
        End Class
        Function ObtieneErroresReservas(ByVal fecha As Date, ByVal hotel_id As Integer) As DataTable
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection(IsolationLevel.RepeatableRead)
            Dim resultado As DataSet = getDataSet(cmd, sqlGenTablaSalidaErrores)
            resultado.Tables(0).Rows.Clear()
            cmd.Parameters.Clear()

            Dim fechaParam As New Odbc.OdbcParameter("@fecha", convertFecha(fecha))
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            cmd.Parameters.Add(fechaParam)
            cmd.Parameters.Add(hotel_idParam)
            Dim reader As DataTableReader = getDataTable(cmd, sqlObtieneReservasEntreFechas)
            If Not flushConection(cmd, errorCode) Then
                resultado = Nothing
            End If
            Dim max As Integer = 3
            Dim act As New errorContador
            act.contador = 0
            'ThreadPool.QueueUserWorkItem(
            Dim maxt, compt As Integer

            'ThreadPool.SetMaxThreads(max, max)
            'ThreadPool.SetMinThreads(max, max)

            'ThreadPool.GetMaxThreads(maxt, compt)
            ThreadPool.GetAvailableThreads(maxt, compt)
            'Console.WriteLine("MaxTreads:" & maxt & " - " & compt)
            Dim bloque As New bloqueReservas
            bloque.resultado = resultado
            bloque.contador = act
            bloque.fecha = fecha
            While reader.Read 'And act < max
                SyncLock act
                    act.contador += 1
                End SyncLock
                Dim estado As New errorReservaClass
                estado.reserva_id = reader.Item("reserva_id")
                estado.fecha_ini = reader.Item("fecha_prevista_llegada")
                estado.fecha_fin = reader.Item("fecha_prevista_salida")

                bloque.datos.Enqueue(estado)

                'estado.resultado = resultado
                'estado.contador = act
                'ThreadPool.QueueUserWorkItem(AddressOf HiloErroresReservas, estado)
            End While
            Dim x As Integer
            For x = 0 To max
                ThreadPool.QueueUserWorkItem(AddressOf HiloErroresReservas, bloque)
            Next


            While act.contador > 1 And bloque.datos.Count > 0
                HiloErroresReservas(bloque)
                '                Thread.Sleep(100)
            End While
            While act.contador > 0
                'HiloErroresReservas(bloque)
                Thread.Sleep(10)
            End While


            If IsNothing(resultado) Then
                Return Nothing
            Else
                Return New DataView(resultado.Tables(0)).ToTable
            End If

        End Function
        Shared sqlWarningCierreHuespedes = "" _
& " SELECT count(*) " _
& " FROM " _
& " reservas_huespedes left join habitaciones_bloqueos on reservas_huespedes.reserva_id=habitaciones_bloqueos.reserva_id " _
& " WHERE " _
& " ifnull(reservas_huespedes.habitacion_id,habitaciones_bloqueos.habitacion_id) IS NULL AND " _
& " reservas_huespedes.reserva_id =  ? "

        Private Sub HiloErroresReservas(ByVal blosta As Object)

            Dim bloque As bloqueReservas = blosta
            Dim estado As errorReservaClass
            SyncLock bloque.datos.SyncRoot
                Try
                    estado = bloque.datos.Dequeue

                Catch ex As Exception
                    estado = Nothing
                End Try
            End SyncLock
            If Not estado Is Nothing Then

                Dim z As New GesHotelClase(Me.userId)
                Dim cmd As Odbc.OdbcCommand = prepareConection(IsolationLevel.RepeatableRead)
                'cmd.Parameters.Clear()
                Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", 0)
                'cmd.Parameters.Add(reserva_idParam)


                While Not IsNothing(estado)
                    Try
                        Dim resulreserva As tablaServicios = z.obtieneServiciosReserva(cmd, estado.reserva_id, estado.fecha_ini, estado.fecha_fin, True)
                        Dim errores As Integer = 0
                        Dim tipoError As Integer = 0
                        Dim descrip As String = ""

                        If IsNothing(resulreserva) Then
                            errores = 1
                            tipoError = 1
                            descrip = "Reserva invalida"
                        Else
                            If resulreserva.sumaErrores() > 0 Then
                                errores = 1 'resulreserva.sumaErrores()
                                tipoError = 1
                                descrip = "Reserva con errores por dia"
                            End If
                        End If
                        'todo comprobar que si tiene facturas
                        'la suma de todas de distinto de cero

                        If errores = 0 Then
                            Dim facs As String = z.ObtieneFacturasPendientesReserva(cmd, estado.reserva_id, True)
                            If Not IsNothing(facs) Then
                                If facs <> "" Then
                                    Dim totalfacs As Single = z.obtieneImportePendienteFactura(cmd, facs.Split(","))
                                    If Not IsNothing(totalfacs) Then
                                        If totalfacs = 0 Then
                                            errores = 1
                                            tipoError = 1
                                            descrip = "Reservas con saldo cero"
                                        End If
                                    End If
                                End If
                            End If

                        End If
                        'errores = 1

                        'Console.WriteLine(estado.reserva_id)
                        'If estado.reserva_id = 7017 Then
                        'Dim xx As Integer
                        'xx = 0
                        'End If
                        If errores = 0 Then
                            'warning
                            'le falta habitacion o hay huespedes sin habitacion asignada
                            'numero de habitaciones a facturar no coincide con las asignadas-falta
                            Dim fecha_buscar As Date = bloque.fecha
                            If estado.fecha_fin = bloque.fecha Then
                                fecha_buscar = estado.fecha_fin.AddDays(-1)
                            End If
                            Dim habsusadas As ArrayList = z.ObtieneReservasHabitacion(cmd, 0, fecha_buscar, fecha_buscar, estado.reserva_id)
                            If habsusadas.Count = 0 Then 'And estado.fecha_fin <> bloque.fecha Then
                                descrip = "Reserva Sin Hab."
                                tipoError = 1
                                errores = 0
                            Else
                                reserva_idParam.Value = estado.reserva_id
                                cmd.Parameters.Clear()
                                'Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", 0)
                                cmd.Parameters.Add(reserva_idParam)
                                Dim nreg As Integer = ExecuteScalar(cmd, sqlWarningCierreHuespedes)
                                If nreg > 0 Then
                                    descrip = "Huespedes Sin Hab."
                                    tipoError = 1
                                End If
                            End If
                        End If
                        If errores > 0 Or tipoError > 0 Then
                            'todo insertar registro en tabla de salida
                            Dim dr As DataRow
                            SyncLock bloque.resultado
                                dr = bloque.resultado.Tables(0).Rows.Add()
                            End SyncLock
                            dr.Item("reserva_id") = estado.reserva_id
                            dr.Item("fecha_prevista_llegada") = estado.fecha_ini
                            dr.Item("fecha_prevista_salida") = estado.fecha_fin
                            dr.Item("estado_factura_id") = 1
                            dr.Item("Fecha_Factura") = bloque.fecha
                            dr.Item("descripcion") = descrip
                            dr.Item("errores") = errores
                            dr.Item("num") = tipoError

                        End If
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                    SyncLock bloque.contador
                        bloque.contador.contador -= 1
                    End SyncLock
                    SyncLock bloque.datos.SyncRoot
                        Try
                            estado = bloque.datos.Dequeue
                        Catch ex As Exception
                            estado = Nothing
                        End Try
                    End SyncLock
                End While
                'Console.WriteLine(estado.contador.contador & "-fin-" & estado.reserva_id)
                'z.conn.Close()
                flushConection(cmd, 1)
            End If

        End Sub
        Shared sqlReservasDescuentos = "" _
& " SELECT" _
& " reservas_descuentos.reserva_id, " _
& " reservas_descuentos.servicio_id, " _
& " reservas_descuentos.tipo_descuento_id, " _
& " reservas_descuentos.descuento, " _
& " servicios_hotel.impuesto_id, " _
& " impuestos.porcentaje, " _
& " servicios.nombre_servicio,servicios.tipo_servicio_id" _
& " FROM " _
& " reservas_descuentos " _
& " Inner Join servicios_hotel ON reservas_descuentos.servicio_id = servicios_hotel.servicio_id " _
& " Inner Join reservas ON reservas_descuentos.reserva_id = reservas.reserva_id AND reservas.hotel_id = servicios_hotel.hotel_id " _
& " Inner Join impuestos ON servicios_hotel.impuesto_id = impuestos.impuesto_id " _
& " Inner Join servicios ON servicios_hotel.servicio_id = servicios.servicio_id " _
& " where reservas_descuentos.reserva_id=?"
        Shared sqlReservasServicios = "select * from reservas_servicios where reserva_id=?"
        Shared sqlReservasHabitaciones = "select * from habitaciones_bloqueos where reserva_id=?"
        Shared sqlEquivalencias = "select * from equivalencia_reservas_servicios"
        Shared sqlServicios = "select * from servicios"
        Shared sqlHabitacion_id = "select habitacion_id from habitaciones where hotel_id=? and numero_habitacion=? limit 0,1"
        Private Function ObtieneHabitacion_Id(ByVal cmd As Odbc.OdbcCommand, ByVal hotel_id As Integer, ByVal habitacion As Object) As Integer
            Dim habitacion_id As Integer = 0
            Try
                cmd.Parameters.Clear()
                Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
                cmd.Parameters.Add(hotel_idParam)
                Dim habitacionParam As New Odbc.OdbcParameter("@habitacion", habitacion)
                cmd.Parameters.Add(habitacionParam)
                habitacion_id = ExecuteScalar(cmd, sqlHabitacion_id, True)

            Catch ex As Exception
                AgregaInfo("ObtieneHabitacion_Id", ex.Message, -1)
            End Try

            Return habitacion_id
        End Function
        Shared sqlOfertasTienenCodigo = "SELECT count(*) FROM ofertas_codigos WHERE ofertas_codigos.codigo_oferta =  @codigo AND ofertas_codigos.oferta_id IN  (@ofertas_id)"
        Function obtieneServiciosReserva(ByVal res As MetaReserva, Optional ByVal crear As Boolean = False) As tablaServicios
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim resultado As tablaServicios
            resultado = New tablaServicios
            Dim datos As DataSet
            Try
                'validar res
                If res.hotel_id > 0 Then
                    'cargar tabla equivalencias
                    Dim equivalencias As DataSet = getDataSet(cmd, sqlEquivalencias)
                    Dim unidades_calculos As DataSet = getDataSet(cmd, sqlUnidadesCalculos)
                    Dim servicios As DataSet = getDataSet(cmd, sqlServicios)
                    datos = preparaDatasetReserva(cmd, 0)
                    'cmd.Parameters.Clear()
                    'Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", 0)
                    'cmd.Parameters.Add(reserva_idParam)
                    'ExecuteNonQuery(cmd, "delete from reservas where reserva_id=?")
                    'Dim datos As DataSet = getDataSet(cmd, sqlCabReserva)
                    Dim row As DataRow
                    If Not IsNothing(res.habitacion) Then
                        res.habitacion_id = ObtieneHabitacion_Id(cmd, res.hotel_id, res.habitacion)
                        AgregaInfo("obtieneServiciosReserva", res.habitacion & "-" & res.habitacion_id, -errorCode)

                    End If
                    If Not IsNothing(res.habitacion_id) Then
                        row = datos.Tables("reservas_habitaciones").Rows.Add()
                        row.Item("habitacion_id") = res.habitacion_id
                        row.Item("tipo_bloqueo_id") = 1
                        row.Item("fecha_desde") = res.fecha_prevista_llegada
                        row.Item("fecha_hasta") = res.fecha_prevista_salida
                        row.Item("user_id") = userId
                        row.Item("fecha_modificacion") = Now
                    End If
                    row = datos.Tables("reserva").Rows.Add()

                    If res.tipo_tarjeta_id <> 0 Then
                        row.Item("tipo_tarjeta_id") = res.tipo_tarjeta_id
                    End If
                    If res.tarjeta_credito <> "" Then
                        row.Item("tarjeta_credito") = res.tarjeta_credito
                    End If
                    If res.caducidad <> "" Then
                        row.Item("caducidad") = res.caducidad
                    End If
                    If res.cod_seguridad <> "" Then
                        row.Item("cod_seguridad") = res.cod_seguridad
                    End If
                    If res.email <> "" Then
                        row.Item("email") = res.email
                    End If



                    row.Item("reserva_id") = 0
                    row.Item("hotel_id") = res.hotel_id
                    row.Item("estado_reserva_id") = 0
                    row.Item("canal_reserva_id") = res.canal_reserva_id
                    row.Item("cliente_id") = res.cliente_id
                    If res.cliente_id_factura <> 0 Then
                        row.Item("cliente_id_factura") = res.cliente_id_factura
                    End If
                    row.Item("fecha_reserva") = res.fecha_reserva
                    row.Item("fecha_prevista_llegada") = res.fecha_prevista_llegada
                    row.Item("fecha_prevista_salida") = res.fecha_prevista_salida
                    Try
                        row.Item("hora_prevista_llegada") = CDate(res.hora_prevista_llegada).TimeOfDay
                    Catch ex As Exception

                    End Try
                    Try
                        row.Item("hora_prevista_salida") = CDate(res.hora_prevista_salida).TimeOfDay
                    Catch ex As Exception

                    End Try
                    
                    Try
                        row.Item("codigo_oferta") = res.codigo_oferta
                    Catch ex As Exception

                    End Try
                    Try
                        row.Item("observaciones_llegada") = res.observaciones
                    Catch ex As Exception

                    End Try

                    row.Item("bono_referencia") = res.bono_referencia
                    row.Item("bloquear_tarifa") = res.bloquear_tarifa
                    row.Item("vip") = res.vip
                    row.Item("permite_devolucion") = res.permite_devolucion
                    row.Item("user_id") = userId
                    row.Item("fecha_modificacion") = Now

                    'Dim writer As Odbc.OdbcDataAdapter
                    'writer = getDataAdapter(cmd, sqlCabReserva)
                    'writer.Fill(datos.Tables(0))
                    'writer.Update(datos.Tables(0))
                    Dim reserva_id As Integer = 0 'ExecuteScalar(cmd, "SELECT LAST_INSERT_ID()")
                    'mete lineas reserva
                    'reserva_idParam.Value = reserva_id
                    'cmd.Parameters.Clear()
                    'cmd.Parameters.Add(reserva_idParam)
                    'datos = getDataSet(cmd, sqlReservasServicios)
                    Dim x As Integer
                    'crea la habitacion
                    Dim contador As Integer = 0
                    Dim servs As New ArrayList()

                    Dim rows() As DataRow = equivalencias.Tables(0).Select("servicio_opcion_id=" & res.habitacion_servicio_id)
                    servs.Add(res.habitacion_servicio_id)
                    If rows.Length > 0 Then
                        For x = 0 To rows.Length - 1
                            servs.Add(rows(x).Item("servicio_id"))
                        Next
                    End If

                    If IsNothing(res.pension_servicio_id) OrElse res.pension_servicio_id = 0 Then
                        servs.Add(0)
                    Else
                        servs.Add(res.pension_servicio_id)
                        rows = equivalencias.Tables(0).Select("servicio_opcion_id=" & res.pension_servicio_id)
                        If rows.Length > 0 Then
                            For x = 0 To rows.Length - 1
                                servs.Add(rows(x).Item("servicio_id"))
                            Next
                        End If
                    End If

                    Dim y As Integer
                    For y = 0 To servs.Count - 1
                        Dim tipo = servicios.Tables(0).Compute("max(tipo_unidad_calculo_id)", "servicio_id=" & servs(y))
                        If IsDBNull(tipo) Then
                            tipo = 2
                        End If
                        If IsNothing(tipo) Then
                        Else
                            If tipo = 1 Then
                                If res.numero_habitaciones > 0 Then
                                    row = datos.Tables("reservas_servicios").Rows.Add()
                                    row.Item("servicio_reserva_id") = contador
                                    row.Item("reserva_id") = reserva_id

                                    row.Item("servicio_id") = servs(y)
                                    row.Item("unidad_calculo_id") = 1 ' servicio?
                                    row.Item("cantidad") = res.numero_habitaciones
                                    row.Item("flag_contrato") = 1
                                    row.Item("servicio_extra") = 0
                                    contador += 1
                                End If
                            End If
                            If tipo = 2 Then
                                For x = 0 To res.unidades_calculos.Length - 1
                                    If res.unidades_calculos(x).cantidad > 0 Then
                                        Dim servicioAsignar As Integer = servs(y)
                                        Dim ucidAsignar As Integer = res.unidades_calculos(x).unidad_calculo_id
                                        Dim rowsuc() As DataRow = unidades_calculos.Tables(0).Select("unidad_calculo_id=" & res.unidades_calculos(x).unidad_calculo_id)
                                        Dim rowseq() As DataRow = equivalencias.Tables(0).Select("servicio_id=" & servicioAsignar)

                                        If rowsuc.Length > 0 And rowseq.Length = 0 Then
                                            If Not rowsuc(0).IsNull("servicio_id") Then
                                                'todo si uc es bebe y no es alojamiento
                                                'cambiar servicio por el asignado
                                                'y uc por SRV
                                                ucidAsignar = 1 'servicio
                                                servicioAsignar = rowsuc(0).Item("servicio_id")
                                            End If
                                        End If
                                        If servicioAsignar <> 0 Then
                                            row = datos.Tables("reservas_servicios").Rows.Add()
                                            row.Item("servicio_reserva_id") = contador
                                            row.Item("reserva_id") = reserva_id
                                            row.Item("servicio_id") = servicioAsignar
                                            row.Item("unidad_calculo_id") = ucidAsignar
                                            row.Item("cantidad") = res.unidades_calculos(x).cantidad
                                            row.Item("flag_contrato") = 1
                                            row.Item("servicio_extra") = 0
                                            contador += 1
                                        End If
                                    End If
                                Next
                            End If
                        End If

                    Next

                    'writer = getDataAdapter(cmd, sqlReservasServicios)
                    'writer.Fill(datos.Tables(0))
                    'writer.Update(datos.Tables(0))

                    resultado = obtieneServiciosReserva(cmd, datos, Nothing, Nothing)
                    'todo si codigo_oferta no es nulo...comprobar ke exista al menos una oferta para ese contrato
                    'con esa oferta o mostrar error
                    Try
                        If Not IsNothing(res.codigo_oferta) Then
                            If res.codigo_oferta <> "" Then
                                Dim ofertas As DataTable = datos.Tables("reservas_ofertas")
                                Dim ofertas_id As String = ""
                                Dim xx As Integer
                                For xx = 0 To ofertas.Rows.Count - 1
                                    If ofertas_id = "" Then
                                        ofertas_id = ofertas.Rows(xx)("oferta_id")
                                    Else
                                        ofertas_id &= "," & ofertas.Rows(xx)("oferta_id")
                                    End If
                                Next
                                Dim tmp As String = sqlOfertasTienenCodigo.replace("@codigo", "'" & res.codigo_oferta & "'")
                                tmp = tmp.Replace("@ofertas_id", ofertas_id)
                                If ExecuteScalar(cmd, tmp) = 0 Then
                                    'no hay ofertas ke coincidan con el codigo....asi ke error
                                    res.errores = "Codigo Oferta No Existe"
                                    resultado = Nothing
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        errorCode = 3
                        AgregaInfo("obtieneServiciosReserva", "Fallo al comprobar codigos:", -errorCode)
                    End Try
                    'todo por cada oferta manual crear combinaciones
                    'y almacenarlas en distintas versiones por columna combinacion
                    If IsNothing(resultado) Then
                        errorCode = 2
                        AgregaInfo("obtieneServiciosReserva", "No se puede calcular los servicios de la meta-reserva:", -errorCode)
                    End If
                Else
                    errorCode = 1
                    AgregaInfo("obtieneServiciosReserva", "Meta-reserva: invalida", -errorCode)
                End If
            Catch ex As Exception
                errorCode = 3
                AgregaInfo("obtieneServiciosReserva", ex.Message, -errorCode)
                resultado = New tablaServicios
            End Try
            If Not IsNothing(resultado) Then
                'dumpResultado(resultado)

                If Not crear Or resultado.sumaErrores() > 0 Or resultado.servicios.Rows.Count = 0 Or IsNothing(datos) Then
                    'existen errores..o no hay datos...o simplemente es un preview
                    errorCode = 1
                Else
                    Try
                        Dim resobject = grabaDatasetReserva(cmd, datos, 0)
                        If Not IsNothing(resobject) Then
                            resultado.reserva_id = resobject
                            'asignarle los huespedes a la reserva
                            If Not IsNothing(res.huespedes) Then
                                If res.huespedes.Length > 0 Then
                                    If Not actualizaHuespedesReserva(cmd, resultado.reserva_id, res.huespedes) Then
                                        errorCode = 4
                                        AgregaInfo("obtieneServiciosReserva", "Meta-huespedes: invalidos", -errorCode)
                                    End If
                                End If
                            End If

                        Else
                            errorCode = 6
                            AgregaInfo("obtieneServiciosReserva", "No graba reserva", -errorCode)
                        End If

                    Catch ex As Exception
                        errorCode = 5
                        AgregaInfo("obtieneServiciosReserva", "excepcion al grabaDatasetReserva:", -errorCode)
                    End Try

                End If
            Else
                errorCode = 1
            End If


            If Not flushConection(cmd, errorCode) Then
                '                resultado = Nothing
            End If

            If errorCode = 0 Then
                If CambiarEstadoReserva(resultado.reserva_id, 1, False) <> 0 Then
                    errorCode = 7
                    AgregaInfo("obtieneServiciosReserva", "No pudo cambiar estado", -errorCode)
                End If
            End If
            'If errorCode <> 0 Then
            'Return Nothing
            ' Else
            Return resultado
            'End If

        End Function
        Function obtieneServiciosReserva(ByVal cmd As Odbc.OdbcCommand, ByVal res As MetaReserva, Optional ByVal crear As Boolean = False) As tablaServicios
            Dim errorCode As Integer = 0
            'Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim resultado As tablaServicios
            resultado = New tablaServicios
            Dim datos As DataSet
            Try
                'validar res
                If res.hotel_id > 0 Then
                    'cargar tabla equivalencias
                    Dim equivalencias As DataSet = getDataSet(cmd, sqlEquivalencias)
                    Dim unidades_calculos As DataSet = getDataSet(cmd, sqlUnidadesCalculos)
                    Dim servicios As DataSet = getDataSet(cmd, sqlServicios)
                    datos = preparaDatasetReserva(cmd, 0)
                    'cmd.Parameters.Clear()
                    'Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", 0)
                    'cmd.Parameters.Add(reserva_idParam)
                    'ExecuteNonQuery(cmd, "delete from reservas where reserva_id=?")
                    'Dim datos As DataSet = getDataSet(cmd, sqlCabReserva)
                    Dim row As DataRow
                    If Not IsNothing(res.habitacion) Then
                        res.habitacion_id = ObtieneHabitacion_Id(cmd, res.hotel_id, res.habitacion)
                        AgregaInfo("obtieneServiciosReserva", res.habitacion & "-" & res.habitacion_id, -errorCode)

                    End If
                    If Not IsNothing(res.habitacion_id) Then
                        row = datos.Tables("reservas_habitaciones").Rows.Add()
                        row.Item("habitacion_id") = res.habitacion_id
                        row.Item("tipo_bloqueo_id") = 1
                        row.Item("fecha_desde") = res.fecha_prevista_llegada
                        row.Item("fecha_hasta") = res.fecha_prevista_salida
                        row.Item("user_id") = userId
                        row.Item("fecha_modificacion") = Now
                    End If
                    row = datos.Tables("reserva").Rows.Add()

                    row.Item("reserva_id") = 0
                    row.Item("hotel_id") = res.hotel_id
                    row.Item("estado_reserva_id") = 1
                    row.Item("canal_reserva_id") = res.canal_reserva_id
                    row.Item("cliente_id") = res.cliente_id
                    If res.cliente_id_factura <> 0 Then
                        row.Item("cliente_id_factura") = res.cliente_id_factura
                    End If
                    row.Item("fecha_reserva") = res.fecha_reserva
                    row.Item("fecha_prevista_llegada") = res.fecha_prevista_llegada
                    row.Item("fecha_prevista_salida") = res.fecha_prevista_salida
                    Try
                        row.Item("hora_prevista_llegada") = CDate(res.hora_prevista_llegada).TimeOfDay
                    Catch ex As Exception

                    End Try
                    Try
                        row.Item("hora_prevista_salida") = CDate(res.hora_prevista_salida).TimeOfDay
                    Catch ex As Exception

                    End Try
                    Try
                        row.Item("observaciones_llegada") = res.observaciones
                    Catch ex As Exception

                    End Try

                    row.Item("bono_referencia") = res.bono_referencia
                    row.Item("bloquear_tarifa") = res.bloquear_tarifa
                    row.Item("permite_devolucion") = res.permite_devolucion
                    row.Item("user_id") = userId
                    row.Item("fecha_modificacion") = Now

                    'Dim writer As Odbc.OdbcDataAdapter
                    'writer = getDataAdapter(cmd, sqlCabReserva)
                    'writer.Fill(datos.Tables(0))
                    'writer.Update(datos.Tables(0))
                    Dim reserva_id As Integer = 0 'ExecuteScalar(cmd, "SELECT LAST_INSERT_ID()")
                    'mete lineas reserva
                    'reserva_idParam.Value = reserva_id
                    'cmd.Parameters.Clear()
                    'cmd.Parameters.Add(reserva_idParam)
                    'datos = getDataSet(cmd, sqlReservasServicios)
                    Dim x As Integer
                    'crea la habitacion
                    Dim contador As Integer = 0
                    Dim servs As New ArrayList()

                    Dim rows() As DataRow = equivalencias.Tables(0).Select("servicio_opcion_id=" & res.habitacion_servicio_id)
                    servs.Add(res.habitacion_servicio_id)
                    If rows.Length > 0 Then
                        For x = 0 To rows.Length - 1
                            servs.Add(rows(x).Item("servicio_id"))
                        Next
                    End If

                    If IsNothing(res.pension_servicio_id) OrElse res.pension_servicio_id = 0 Then
                        servs.Add(0)
                    Else
                        servs.Add(res.pension_servicio_id)
                        rows = equivalencias.Tables(0).Select("servicio_opcion_id=" & res.pension_servicio_id)
                        If rows.Length > 0 Then
                            For x = 0 To rows.Length - 1
                                servs.Add(rows(x).Item("servicio_id"))
                            Next
                        End If
                    End If

                    Dim y As Integer
                    For y = 0 To servs.Count - 1
                        Dim tipo = servicios.Tables(0).Compute("max(tipo_unidad_calculo_id)", "servicio_id=" & servs(y))
                        If IsDBNull(tipo) Then
                            tipo = 2
                        End If
                        If IsNothing(tipo) Then
                        Else
                            If tipo = 1 Then
                                If res.numero_habitaciones > 0 Then
                                    row = datos.Tables("reservas_servicios").Rows.Add()
                                    row.Item("servicio_reserva_id") = contador
                                    row.Item("reserva_id") = reserva_id

                                    row.Item("servicio_id") = servs(y)
                                    row.Item("unidad_calculo_id") = 1 ' servicio?
                                    row.Item("cantidad") = res.numero_habitaciones
                                    row.Item("flag_contrato") = 1
                                    contador += 1
                                End If
                            End If
                            If tipo = 2 Then
                                For x = 0 To res.unidades_calculos.Length - 1
                                    If res.unidades_calculos(x).cantidad > 0 Then
                                        Dim servicioAsignar As Integer = servs(y)
                                        Dim ucidAsignar As Integer = res.unidades_calculos(x).unidad_calculo_id
                                        Dim rowsuc() As DataRow = unidades_calculos.Tables(0).Select("unidad_calculo_id=" & res.unidades_calculos(x).unidad_calculo_id)
                                        Dim rowseq() As DataRow = equivalencias.Tables(0).Select("servicio_id=" & servicioAsignar)

                                        If rowsuc.Length > 0 And rowseq.Length = 0 Then
                                            If Not rowsuc(0).IsNull("servicio_id") Then
                                                'todo si uc es bebe y no es alojamiento
                                                'cambiar servicio por el asignado
                                                'y uc por SRV
                                                ucidAsignar = 1 'servicio
                                                servicioAsignar = rowsuc(0).Item("servicio_id")
                                            End If
                                        End If
                                        If servicioAsignar <> 0 Then
                                            row = datos.Tables("reservas_servicios").Rows.Add()
                                            row.Item("servicio_reserva_id") = contador
                                            row.Item("reserva_id") = reserva_id
                                            row.Item("servicio_id") = servicioAsignar
                                            row.Item("unidad_calculo_id") = ucidAsignar
                                            row.Item("cantidad") = res.unidades_calculos(x).cantidad
                                            row.Item("flag_contrato") = 1
                                            contador += 1
                                        End If
                                    End If
                                Next
                            End If
                        End If

                    Next

                    'writer = getDataAdapter(cmd, sqlReservasServicios)
                    'writer.Fill(datos.Tables(0))
                    'writer.Update(datos.Tables(0))

                    resultado = obtieneServiciosReserva(cmd, datos, Nothing, Nothing)

                    'todo por cada oferta manual crear combinaciones
                    'y almacenarlas en distintas versiones por columna combinacion
                    If IsNothing(resultado) Then
                        errorCode = 2
                        AgregaInfo("obtieneServiciosReserva", "No se puede calcular los servicios de la meta-reserva:", -errorCode)
                    End If
                Else
                    errorCode = 1
                    AgregaInfo("obtieneServiciosReserva", "Meta-reserva: invalida", -errorCode)
                End If
            Catch ex As Exception
                errorCode = 3
                AgregaInfo("obtieneServiciosReserva", ex.Message, -errorCode)
                resultado = New tablaServicios
            End Try
            If Not IsNothing(resultado) Then
                'dumpResultado(resultado)

                If Not crear Or resultado.sumaErrores() > 0 Or resultado.servicios.Rows.Count = 0 Or IsNothing(datos) Then
                    'existen errores..o no hay datos...o simplemente es un preview
                    errorCode = 1
                Else
                    Try
                        Dim resobject As Object = grabaDatasetReserva(cmd, datos, 0)
                        If Not IsNothing(resobject) Then
                            resultado.reserva_id = resobject
                            'asignarle los huespedes a la reserva
                            If Not IsNothing(res.huespedes) Then
                                If res.huespedes.Length > 0 Then
                                    If Not actualizaHuespedesReserva(cmd, resultado.reserva_id, res.huespedes) Then
                                        errorCode = 4
                                        AgregaInfo("obtieneServiciosReserva", "Meta-huespedes: invalidos", -errorCode)
                                    End If
                                End If
                            End If
                        Else
                            errorCode = 6
                            AgregaInfo("obtieneServiciosReserva", "no graba datos res:", -errorCode)
                        End If
                    Catch ex As Exception
                        errorCode = 5
                        AgregaInfo("obtieneServiciosReserva", "excepcion al grabaDatasetReserva:", -errorCode)
                    End Try

                End If
            Else
                errorCode = 1
            End If


            'If Not flushConection(cmd, errorCode) Then
            '                resultado = Nothing
            'End If

            If errorCode <> 0 Then
                Return Nothing
            Else
                Return resultado
            End If

        End Function
        Function obtieneServiciosReserva(ByVal reserva_id As Integer) As tablaServicios
            Return obtieneServiciosReserva(reserva_id, Nothing, Nothing)
        End Function
        Private Function obtieneServiciosReserva(ByVal cmd As Odbc.OdbcCommand, ByVal reserva_id As Integer) As tablaServicios
            Return obtieneServiciosReserva(cmd, reserva_id, Nothing, Nothing)
        End Function
        Shared sqlTablaReservasOld = "" _
        & " Select * from reservas_servicios" _
        & " where reserva_id=?"

        Function obtieneServiciosReserva(ByVal reserva_id As Integer, ByVal fecha_ini As Object, ByVal fecha_fin As Object) As tablaServicios
            'Dim dt As Date = Now
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim resultado As tablaServicios = Nothing
            Try
                resultado = obtieneServiciosReserva(cmd, reserva_id, fecha_ini, fecha_fin)
                If IsNothing(resultado) Then
                    errorCode = 1
                    AgregaInfo("obtieneServiciosReserva", "No se puede calcular los servicios de la reserva:" & reserva_id, -errorCode)
                End If
            Catch ex As Exception
                errorCode = 2
                AgregaInfo("obtieneServiciosReserva", ex.Message, -errorCode)
            End Try
            'Console.Write((Now - dt))
            'Console.WriteLine("-")
            If Not flushConection(cmd, errorCode) Then
                resultado = Nothing
            End If
            'Console.Write((Now - dt))
            'Console.WriteLine("-")
            Return resultado
        End Function
        Shared sqlUCReservasOld = "" _
    & "    SELECT " _
    & " reservas_servicios.unidad_calculo_id, " _
    & " Max(reservas_servicios.cantidad) as cantidad " _
    & " FROM " _
    & " reservas_servicios " _
    & " WHERE " _
    & " reservas_servicios.reserva_id =  ? " _
    & " GROUP BY " _
    & " reservas_servicios.unidad_calculo_id "
        Shared sqlUCReservas = "" _
    & " select unidad_calculo_id_padre as unidad_calculo_id,sum(cantidad) as cantidad from" _
    & " (SELECT " _
    & " unidades_calculo_detalladas.unidad_calculo_id_padre, " _
    & " unidades_calculo_detalladas.unidad_calculo_id_hijo, " _
    & " Max(ifnull(reservas_servicios.cantidad,0)) as cantidad " _
    & " FROM (" _
    & "     SELECT " _
    & " unidades_calculo.unidad_calculo_id AS unidad_calculo_id_padre, " _
    & " ifnull(unidades_calculo_agrupados.unidad_calculo_hijo_id,unidades_calculo.unidad_calculo_id) AS unidad_calculo_id_hijo " _
    & " FROM " _
    & " unidades_calculo " _
    & " Left Join unidades_calculo_agrupados ON unidades_calculo.unidad_calculo_id = unidades_calculo_agrupados.unidad_calculo_padre_id " _
    & " ) unidades_calculo_detalladas " _
    & " Left Join reservas_servicios ON unidades_calculo_detalladas.unidad_calculo_id_hijo = reservas_servicios.unidad_calculo_id " _
    & " WHERE " _
    & " reservas_servicios.reserva_id = ? or " _
    & " reservas_servicios.reserva_id IS NULL " _
    & " GROUP BY " _
    & " unidades_calculo_detalladas.unidad_calculo_id_padre, " _
    & " unidades_calculo_detalladas.unidad_calculo_id_hijo " _
    & " ) drv group by unidad_calculo_id_padre "
        Shared sqlUnidadesCalculoDetalladas = "" _
    & "SELECT " _
    & " unidades_calculo.unidad_calculo_id AS unidad_calculo_id_padre, " _
    & " ifnull(unidades_calculo_agrupados.unidad_calculo_hijo_id,unidades_calculo.unidad_calculo_id) AS unidad_calculo_id_hijo " _
    & " FROM " _
    & " unidades_calculo " _
    & " Left Join unidades_calculo_agrupados ON unidades_calculo.unidad_calculo_id = unidades_calculo_agrupados.unidad_calculo_padre_id "
        Shared sqlResultadoUC = "select 1 as unidad_calculo_id,0.0 as cantidad from hoteles where 1=0"
        Private Function obtieneUCSReserva(ByVal cmd As Odbc.OdbcCommand, ByVal ds As DataSet) As DataSet
            cmd.Parameters.Clear()
            Dim datos As DataTableReader = getDataTable(cmd, sqlUnidadesCalculoDetalladas, True)
            Dim destino As DataSet = getDataSet(cmd, sqlResultadoUC, True)
            Dim destable As DataTable = destino.Tables(0)
            'Dim destable As DataTable = Me.readerToTable(getDataTable(cmd, sqlResultadoUC, True))
            Dim origen As DataTable = ds.Tables("reservas_servicios")
            Dim cant As Object
            Dim rows() As DataRow
            Dim row As DataRow
            While datos.Read
                cant = origen.Compute("max (cantidad)", "unidad_calculo_id=" & datos.Item("unidad_calculo_id_hijo"))
                If IsDBNull(cant) Then
                    cant = 0
                End If
                rows = destable.Select("unidad_calculo_id=" & datos.Item("unidad_calculo_id_padre"))
                If rows.Length > 0 Then
                    row = rows(0)
                Else
                    row = destable.Rows.Add()
                End If
                row.Item("unidad_calculo_id") = datos.Item("unidad_calculo_id_padre")
                If row.IsNull("cantidad") Then
                    row.Item("cantidad") = cant
                Else
                    row.Item("cantidad") += cant
                End If
            End While
            Return destino
        End Function
        Private Function obtieneUCSReserva(ByVal cmd As Odbc.OdbcCommand, ByVal reserva As Integer) As DataSet
            cmd.Parameters.Clear()
            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva)
            cmd.Parameters.Add(reserva_idParam)
            Return getDataSet(cmd, sqlUCReservas)
        End Function
        Shared sqlUCHijas = "" _
    & "SELECT " _
    & " unidades_calculo.unidad_calculo_id AS unidad_calculo_id_padre, " _
    & " ifnull(unidades_calculo_agrupados.unidad_calculo_hijo_id,unidades_calculo.unidad_calculo_id) AS unidad_calculo_id_hijo " _
    & " FROM " _
    & " unidades_calculo " _
    & " Left Join unidades_calculo_agrupados ON unidades_calculo.unidad_calculo_id = unidades_calculo_agrupados.unidad_calculo_padre_id "
        'Private cachedUCHijas As DataSet
        Private Function obtieneUCHijas(ByVal cmd As Odbc.OdbcCommand) As DataSet
            Return getDataSet(cmd, sqlUCHijas, True)
        End Function
        Private Function obtieneUCHijas(ByVal cmd As Odbc.OdbcCommand, ByVal ucidPadre As Integer) As ArrayList
            Dim dr As DataRow() = obtieneUCHijas(cmd).Tables(0).Select("unidad_calculo_id_padre=" & ucidPadre)
            Dim ar As New ArrayList()
            Dim x As DataRow
            For Each x In dr
                ar.Add(x.Item("unidad_calculo_id_hijo"))
            Next
            Return ar
        End Function
        Private Function perteneceUC(ByVal ucds As DataSet, ByVal ucidPadre As Integer, ByVal ucidHijo As Integer) As Boolean
            Return ((ucds.Tables(0).Compute("count(unidad_calculo_id_padre)", "unidad_calculo_id_padre=" & ucidPadre & " and unidad_calculo_id_hijo=" & ucidHijo)) > 0)
            'Dim num As Integer = 
            'If num > 0 Then
            'Return True
            'Else
            'Return False
            'End If
        End Function
        Shared sqlCondiciones = "select * from condiciones_linea_contrato where linea_contrato_id=?"
        Shared sqlCondicionesContratos = "select condiciones_linea_contrato.* from lineas_de_contrato inner join condiciones_linea_contrato on lineas_de_contrato.linea_contrato_id=condiciones_linea_contrato.linea_contrato_id where lineas_de_contrato.contrato_id=?"
        Shared sqlCondicionesOfertas = "select * from condiciones_ofertas where oferta_id=?"
        Shared sqlCondicionesOfertasContratos = "select condiciones_ofertas.* from ofertas inner join condiciones_ofertas on ofertas.oferta_id=condiciones_ofertas.oferta_id where ofertas.contrato_id in (?)"
        Private Function cumpleCondicionesOfertas(ByVal cmd As Odbc.OdbcCommand, ByVal oferta_id As Integer, ByVal ucsTable As DataSet)
            Return cumpleCondiciones(cmd, sqlCondicionesOfertas, oferta_id, ucsTable)
        End Function
        'Private Function cumpleCondicionesLineaContrato(ByVal cmd As Odbc.OdbcCommand, ByVal linea_contrato_id As Integer, ByVal ucsTable As DataSet)
        '    Return cumpleCondiciones(cmd, sqlCondiciones, linea_contrato_id, ucsTable)
        'End Function
        Private Function cumpleCondiciones(ByVal cond As DataTableReader, ByVal ucsTable As DataSet)
            If IsNothing(ucsTable) Then
                Return True
            End If
            Dim ucs As DataTable = ucsTable.Tables(0)
            Dim cumple As Boolean = True
            While cumple And cond.Read
                Dim uc = cond.Item("unidad_calculo_id")
                Dim rows As DataRow() = ucs.Select("unidad_calculo_id=" & uc)
                Dim cant = Nothing
                If rows.Length > 0 Then
                    cant = rows(0).Item("cantidad")
                Else
                    cumple = False
                End If
                If Not IsNothing(cant) Then
                    Dim ocant = cond.Item("cantidad")
                    Select Case cond.Item("tipo_condicion_id")
                        Case 1 '1	=
                            If Not (cant = ocant) Then
                                cumple = False
                            End If
                        Case 2 '2	>
                            If Not (cant > ocant) Then
                                cumple = False
                            End If
                        Case 3 '3	>=
                            If Not (cant >= ocant) Then
                                cumple = False
                            End If
                        Case 4 '4	<
                            If Not (cant < ocant) Then
                                cumple = False
                            End If
                        Case 5 '5	<=
                            If Not (cant <= ocant) Then
                                cumple = False
                            End If
                    End Select
                End If
            End While
            Return cumple
        End Function

        Private Function cumpleCondiciones(ByVal cmd As Odbc.OdbcCommand, ByVal query As String, ByVal id As Integer, ByVal ucsTable As DataSet)
            If IsNothing(ucsTable) Then
                Return True
            End If
            cmd.Parameters.Clear()
            Dim idParam As New Odbc.OdbcParameter("@id", id)
            cmd.Parameters.Add(idParam)
            Dim cond As DataTableReader = getDataTable(cmd, query, True)
            Return cumpleCondiciones(cond, ucsTable)
        End Function

        Shared sqlTablaReservas = "" _
    & "     SELECT 0.0 as precio_servicio," _
    & " reservas_servicios.flag_contrato,reservas_servicios.servicio_reserva_id," _
    & " reservas_servicios.reserva_id," _
    & " reservas_servicios.servicio_id," _
    & " reservas_servicios.unidad_calculo_id," _
    & " ifnull(reservas_servicios.fecha_desde,reservas.fecha_prevista_llegada) as fecha_desde," _
    & " ifnull(reservas_servicios.fecha_hasta,reservas.fecha_prevista_salida) as fecha_hasta," _
    & " reservas_servicios.cantidad," _
    & " servicios_hotel.impuesto_id," _
    & " impuestos.porcentaje," _
    & " reservas.hotel_id,reservas.estado_reserva_id,reservas.bloquear_tarifa," _
    & " reservas.cliente_id," _
    & " datediff(ifnull(reservas.fecha_salida,reservas.fecha_prevista_salida),ifnull(reservas.fecha_llegada,reservas.fecha_prevista_llegada)) as dias_estancia, " _
    & " datediff(ifnull(reservas.fecha_llegada,reservas.fecha_prevista_llegada),ifnull(fecha_reserva,'01/01/2001')) as dias_antelacion, " _
    & " reservas.fecha_reserva," _
    & " reservas.fecha_llegada," _
    & " reservas.fecha_salida," _
    & " reservas.fecha_prevista_llegada," _
    & " reservas.fecha_prevista_salida,unidades_calculo.tipo_unidad_calculo_id,servicios.abreviatura,servicios.tipo_servicio_id,unidades_calculo.UC" _
    & " FROM" _
    & " reservas_servicios" _
    & " Inner Join reservas ON reservas_servicios.reserva_id = reservas.reserva_id" _
    & " Inner Join servicios_hotel ON reservas.hotel_id = servicios_hotel.hotel_id AND reservas_servicios.servicio_id = servicios_hotel.servicio_id" _
    & " Inner Join impuestos ON servicios_hotel.impuesto_id = impuestos.impuesto_id" _
    & " Inner Join servicios ON servicios_hotel.servicio_id = servicios.servicio_id" _
    & " Inner Join unidades_calculo ON reservas_servicios.unidad_calculo_id = unidades_calculo.unidad_calculo_id" _
    & " WHERE" _
    & " reservas.reserva_id in (?)"
        Shared sqlObtieneReservasContratos = "select * from reservas_contratos where reserva_id=?"
        'Dim sqlBorrarReservasContratos = "delete from reservas_contratos where reserva_id=?"
        'Dim sqlInsertaReservaContrato = "insert into reservas_contratos(reserva_id,contrato_id) values(?,?)"
        '& " reservas_servicios.contrato_id," _
        Private Function preProcesaServiciosOldOLd(ByVal reader As DataTableReader) As DataTableReader
            'todo agrupar por fecha/servicio/uc
            'si dos servicios tienen misma fecha,servicio/uc..sumar cantidades
            'y borrar excendentes

            Dim resultado As New ArrayList  'lista donde se marcan los ya procesados
            Dim tmpTable As New DataTable
            tmpTable.Load(reader)
            tmpTable.Columns.Item("fecha_desde").ReadOnly = False
            tmpTable.Columns.Item("fecha_hasta").ReadOnly = False
            reader = tmpTable.CreateDataReader()
            'Console.WriteLine(tmpTable.Rows.Count)
            Dim id_fecha_desde As Integer = reader.GetOrdinal("fecha_desde")
            Dim id_fecha_hasta As Integer = reader.GetOrdinal("fecha_hasta")
            Dim id_cantidad As Integer = reader.GetOrdinal("cantidad")
            While reader.Read
                Dim key As String = "servicio_id=" & reader.Item("servicio_id") & " and unidad_calculo_id=" & reader.Item("unidad_calculo_id")
                If Not resultado.Contains(key) Then
                    resultado.Add(key)
                    Dim rescan As Boolean = True
                    While rescan = True
                        rescan = False
                        'tmpTable.AcceptChanges()
                        Dim subTable() As DataRow = tmpTable.Select(key, "fecha_desde asc,fecha_hasta asc")
                        If subTable.Length > 1 Then
                            'agrupar
                            Dim x As Integer
                            'For x = 0 To subTable.Length - 1
                            '    Console.WriteLine(subTable(x).Item("fecha_desde") & " -" & subTable(x).Item("fecha_hasta") & "-" & subTable(x).Item("cantidad"))
                            'Next
                            'Console.WriteLine("****")
                            For x = 0 To subTable.Length - 1 And rescan = False
                                Dim y As Integer
                                For y = x + 1 To subTable.Length - 1 And rescan = False
                                    If subTable(x).Item(id_fecha_desde) = subTable(y).Item(id_fecha_desde) And subTable(x).Item("fecha_hasta") = subTable(y).Item(id_fecha_hasta) Then
                                        'sus fechas coinciden..se suman y se borra la ultima linea
                                        subTable(x).Item(id_cantidad) += subTable(y).Item(id_cantidad)
                                        subTable(y).Delete()
                                        rescan = True
                                    Else
                                        'caso 2
                                        'fecha desde,hasta dentro del primero
                                        If subTable(y).Item(id_fecha_desde) >= subTable(x).Item(id_fecha_desde) And subTable(y).Item(id_fecha_desde) < subTable(x).Item(id_fecha_hasta) Then 'And subTable(y).Item("fecha_hasta") >= subTable(x).Item("fecha_desde") And subTable(y).Item("fecha_hasta") <= subTable(x).Item("fecha_hasta") Then
                                            'If subTable(y).Item("fecha_desde") >= subTable(x).Item("fecha_desde") And subTable(y).Item("fecha_hasta") <= subTable(x).Item("fecha_hasta") Then
                                            Dim dostage As Boolean = True
                                            If Not (subTable(y).Item(id_fecha_hasta) = subTable(x).Item(id_fecha_hasta) Or subTable(y).Item(id_fecha_desde) = subTable(x).Item(id_fecha_desde)) Then

                                                If subTable(y).Item(id_fecha_hasta) < subTable(x).Item(id_fecha_hasta) Then
                                                    Dim row As DataRow = tmpTable.Rows.Add(subTable(x).ItemArray)
                                                    row.Item(id_fecha_desde) = subTable(y).Item(id_fecha_hasta)
                                                    row.Item(id_fecha_hasta) = subTable(x).Item(id_fecha_hasta)
                                                Else
                                                    Dim row As DataRow = tmpTable.Rows.Add(subTable(y).ItemArray)
                                                    row.Item(id_fecha_hasta) = subTable(y).Item(id_fecha_hasta)
                                                    row.Item(id_fecha_desde) = subTable(x).Item(id_fecha_hasta)
                                                    subTable(x).Item(id_fecha_hasta) = subTable(y).Item(id_fecha_desde)
                                                    subTable(y).Item(id_fecha_hasta) = row.Item(id_fecha_desde)
                                                    subTable(y).Item(id_cantidad) += subTable(x).Item(id_cantidad)
                                                    dostage = False
                                                End If

                                            End If
                                            If dostage Then
                                                If subTable(y).Item(id_fecha_desde) = subTable(x).Item(id_fecha_desde) Then
                                                    subTable(x).Item(id_cantidad) += subTable(y).Item(id_cantidad)
                                                    subTable(y).Item(id_fecha_desde) = subTable(x).Item(id_fecha_hasta) '.AddDays(1)
                                                Else
                                                    subTable(y).Item(id_cantidad) += subTable(x).Item(id_cantidad)
                                                    subTable(x).Item(id_fecha_hasta) = subTable(y).Item(id_fecha_desde)
                                                End If
                                            End If
                                            'subTable(x).Item("fecha_hasta") = subTable(y).Item("fecha_desde")
                                            rescan = True
                                            'fecha hasta 1=fecha desde 2
                                            'fecha desde 3=fecha hasta 2
                                            'fecha hasta 3=fecha hasta 1
                                        Else
                                            'caso 3
                                            'fecha desde dentro del primero
                                            'fecha hasta 1=fecha desde 2
                                            'fecha hasta 2=fecha hasta 1
                                            'fecha desde 3=fecha hasta 1
                                            'fecha hasta 3=fecha hasta 2

                                            'caso 4
                                            'fechas no colisioanan
                                        End If

                                    End If
                                Next
                            Next
                            'Console.WriteLine(subTable(0).Item("fecha_desde"))
                        End If
                    End While
                End If
            End While
            'tmpTable()
            'Console.WriteLine(tmpTable.Rows.Count)
            tmpTable.AcceptChanges()
            'reader = tmpTable.CreateDataReader()
            'While reader.Read
            'Console.WriteLine(reader.Item("servicio_id") & "-" & reader.Item("fecha_desde") & " - " & reader.Item("fecha_hasta") & "-" & reader.Item("cantidad"))
            'End While
            'Console.WriteLine(tmpTable.Rows.Count)
            reader = tmpTable.CreateDataReader()
            Return reader
        End Function
        Private Function preProcesaServicios(ByVal reader As DataTableReader) As DataTableReader
            Dim tmpTable As New DataTable
            tmpTable.Load(reader)
            Return preProcesaServicios(tmpTable)
        End Function
        Private Function preProcesaServiciosOld(ByVal reader As DataTableReader) As DataTableReader
            'todo agrupar por fecha/servicio/uc
            'si dos servicios tienen misma fecha,servicio/uc..sumar cantidades
            'y borrar excendentes
            Dim values(reader.FieldCount - 1) As Object

            Dim resultado As New ArrayList  'lista donde se marcan los ya procesados
            Dim tmpTable As New DataTable
            'tmpTable.Rows.Add(reader.Item.
            tmpTable.Load(reader)
            'ordena por id iria mas rapido?
            'tmpTable = New DataView(tmpTable, "", "reserva_id", DataViewRowState.CurrentRows).ToTable
            tmpTable.Columns.Item("fecha_desde").ReadOnly = False
            tmpTable.Columns.Item("fecha_hasta").ReadOnly = False
            reader = tmpTable.CreateDataReader()
            Dim tmpTable1 As DataTable = tmpTable.Clone

            'Console.WriteLine(tmpTable.Rows.Count)
            Dim id_fecha_desde As Integer = reader.GetOrdinal("fecha_desde")
            Dim id_fecha_hasta As Integer = reader.GetOrdinal("fecha_hasta")
            Dim id_cantidad As Integer = reader.GetOrdinal("cantidad")
            Dim key As String
            Dim fmax As Date
            Dim fmin As Date
            Dim fstart As Date
            Dim canto
            Dim cantidad As Object
            Dim ncantidad As Object
            Dim filtro As String
            Dim row As DataRow
            While reader.Read

                key = "flag_contrato=" & reader.Item("flag_contrato") & " and reserva_id=" & reader.Item("reserva_id") & " and servicio_id=" & reader.Item("servicio_id") & " and unidad_calculo_id=" & reader.Item("unidad_calculo_id")
                If Not resultado.Contains(key) Then
                    resultado.Add(key)
                    'obtiene fecha mayor


                    fmax = tmpTable.Compute("max(fecha_hasta)", key)
                    'obtiene fecha menor
                    fmin = tmpTable.Compute("min(fecha_desde)", key)
                    fstart = fmin
                    cantidad = Nothing
                    ncantidad = Nothing
                    'optimizar...si solo hay un tramo pa ke koño recorrerme todos...
                    'en realidad...obtener cada tramo y generar los x tramos fmin,fmax
                    If tmpTable.Select(key).Length = 1 Then
                        fmin = fmax
                        filtro = key & " and '" & fmin & "' >=fecha_desde and '" & fmin & "' <=fecha_hasta"
                        cantidad = tmpTable.Compute("sum(cantidad)", filtro)
                        If IsDBNull(cantidad) Then
                            cantidad = 0
                        End If
                    End If

                    While fmin <= fmax
                        filtro = key & " and '" & fmin & "' >=fecha_desde and '" & fmin & "' <=fecha_hasta"
                        canto = tmpTable.Compute("sum(cantidad)", filtro)
                        If IsDBNull(canto) Then
                            ncantidad = 0
                        Else
                            ncantidad = canto
                        End If

                        If IsNothing(cantidad) Then
                            cantidad = ncantidad
                            fstart = fmin
                        Else
                            If cantidad <> ncantidad Then
                                'crear registro con grupo de cantidades
                                If cantidad = 0 Then
                                Else
                                    reader.GetValues(values)
                                    row = tmpTable1.Rows.Add(values)
                                    row.Item("cantidad") = cantidad
                                    row.Item("fecha_desde") = fstart
                                    row.Item("fecha_hasta") = fmin
                                End If
                                fstart = fmin
                                cantidad = ncantidad
                            End If
                        End If
                        fmin = fmin.AddDays(1)
                    End While
                    If cantidad = 0 Then
                    Else
                        reader.GetValues(values)
                        row = tmpTable1.Rows.Add(values)
                        row.Item("cantidad") = cantidad
                        row.Item("fecha_desde") = fstart
                        row.Item("fecha_hasta") = fmin.AddDays(-1)
                    End If
                End If
            End While
            tmpTable1.AcceptChanges()
            reader = tmpTable1.CreateDataReader()
            Return reader
        End Function
        Private Function preProcesaServicios(ByVal tmpTable As DataTable) As DataTableReader
            'todo agrupar por fecha/servicio/uc
            'si dos servicios tienen misma fecha,servicio/uc..sumar cantidades
            'y borrar excendentes

            Dim values(tmpTable.Columns.Count - 1) As Object

            Dim resultado As New ArrayList  'lista donde se marcan los ya procesados
            'Dim tmpTable As New DataTable
            Dim reader As DataTableReader
            'tmpTable.Rows.Add(reader.Item.
            'tmpTable.Load(reader)
            'ordena por id iria mas rapido?
            'tmpTable = New DataView(tmpTable, "", "reserva_id", DataViewRowState.CurrentRows).ToTable
            tmpTable.Columns.Item("fecha_desde").ReadOnly = False
            tmpTable.Columns.Item("fecha_hasta").ReadOnly = False
            reader = tmpTable.CreateDataReader()
            Dim tmpTable1 As DataTable = tmpTable.Clone

            'Console.WriteLine(tmpTable.Rows.Count)
            Dim id_fecha_desde As Integer = reader.GetOrdinal("fecha_desde")
            Dim id_fecha_hasta As Integer = reader.GetOrdinal("fecha_hasta")
            Dim id_cantidad As Integer = reader.GetOrdinal("cantidad")
            Dim key As String
            Dim fmax As Date
            Dim fmin As Date
            Dim fstart As Date
            Dim canto
            Dim cantidad As Object
            Dim ncantidad As Object
            Dim filtro As String
            Dim row As DataRow
            While reader.Read

                key = "flag_contrato=" & reader.Item("flag_contrato") & " and reserva_id=" & reader.Item("reserva_id") & " and servicio_id=" & reader.Item("servicio_id") & " and unidad_calculo_id=" & reader.Item("unidad_calculo_id")
                If Not resultado.Contains(key) Then
                    resultado.Add(key)
                    'obtiene fecha mayor
                    'Dim dv As DataTable = (New DataView(tmpTable, key, "", DataViewRowState.CurrentRows)).ToTable
                    fmax = tmpTable.Compute("max(fecha_hasta)", key)
                    'obtiene fecha menor
                    fmin = tmpTable.Compute("min(fecha_desde)", key)
                    fstart = fmin
                    cantidad = Nothing
                    ncantidad = Nothing
                    'optimizar...si solo hay un tramo pa ke koño recorrerme todos...
                    'en realidad...obtener cada tramo y generar los x tramos fmin,fmax
                    If tmpTable.Select(key).Length = 1 Then
                        fmin = fmax
                        filtro = key & " and '" & fmin & "' >=fecha_desde and '" & fmin & "' <=fecha_hasta"
                        cantidad = tmpTable.Compute("sum(cantidad)", filtro)
                        fmin = fmax.AddDays(1)
                        If IsDBNull(cantidad) Then
                            cantidad = 0
                        End If
                    End If

                    While fmin <= fmax
                        filtro = key & " and '" & fmin & "' >=fecha_desde and '" & fmin & "' <=fecha_hasta"
                        canto = tmpTable.Compute("sum(cantidad)", filtro)
                        If IsDBNull(canto) Then
                            ncantidad = 0
                        Else
                            ncantidad = canto
                        End If

                        If IsNothing(cantidad) Then
                            cantidad = ncantidad
                            fstart = fmin
                        Else
                            If cantidad <> ncantidad Then
                                'crear registro con grupo de cantidades
                                If cantidad = 0 Then
                                Else
                                    reader.GetValues(values)
                                    row = tmpTable1.Rows.Add(values)
                                    row.Item("cantidad") = cantidad
                                    row.Item("fecha_desde") = fstart
                                    row.Item("fecha_hasta") = fmin
                                End If
                                fstart = fmin
                                cantidad = ncantidad
                            End If
                        End If
                        fmin = fmin.AddDays(1)
                    End While
                    If cantidad = 0 Then
                    Else
                        reader.GetValues(values)
                        row = tmpTable1.Rows.Add(values)
                        row.Item("cantidad") = cantidad
                        row.Item("fecha_desde") = fstart
                        row.Item("fecha_hasta") = fmin.AddDays(-1)
                    End If
                End If
            End While
            tmpTable1.AcceptChanges()
            reader = tmpTable1.CreateDataReader()
            Return reader
        End Function
        Private Function preparaDatasetReserva(ByVal cmd As Odbc.OdbcCommand, ByVal reserva_id As Integer) As DataSet
            Dim ds As New DataSet
            cmd.Parameters.Clear()
            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
            cmd.Parameters.Add(reserva_idParam)
            getDataSet(cmd, sqlCabReserva, ds, "reserva")
            getDataSet(cmd, sqlReservasServicios, ds, "reservas_servicios")
            getDataSet(cmd, sqlObtieneReservasContratos, ds, "reservas_contratos")
            getDataSet(cmd, sqlReservasOfertas, ds, "reservas_ofertas")
            Dim clone As DataTable = ds.Tables("reservas_ofertas").Copy()
            'Dim clone As DataTable = New DataView(ds.Tables("reservas_ofertas")).ToTable
            clone.TableName = "reservas_ofertas_subclone"
            clone.AcceptChanges()
            ds.Tables.Add(clone)
            getDataSet(cmd, sqlReservasHabitaciones, ds, "reservas_habitaciones")
            getDataSet(cmd, sqlReservasDescuentos, ds, "reservas_descuentos")
            Return ds
        End Function
        Private Function grabaDatasetReserva(ByVal cmd As Odbc.OdbcCommand, ByVal ds As DataSet, Optional ByVal reserva_id As Integer = 0) As Object
            'actualizar todas las tablas y cambiar reserva_id por la nueva si la hubiese
            Try
                If Not IsNothing(ds.Tables("reservas_ofertas_subclone")) And Not IsNothing(ds.Tables("reservas_ofertas").GetChanges) Then
                    'comparar con su clone
                    

                    Dim dtori As DataTable = ds.Tables("reservas_ofertas")
                    Dim dtdes As DataTable = ds.Tables("reservas_ofertas_subclone")
                    If dtori.Rows.Count = dtdes.Rows.Count Then
                        'comprobar fila a fila
                        Dim x As Integer
                        Dim z As Integer = dtori.Rows.Count - 1
                        Dim aquitar As Boolean = False
                        For x = 0 To z
                            If dtori.Rows(x).RowState = DataRowState.Deleted Then
                                aquitar = True
                                x = z
                            Else
                                If dtori.Rows(x)("oferta_id") <> dtdes.Rows(x)("oferta_id") Or dtori.Rows(x)("tipo") <> dtdes.Rows(x)("tipo") Or dtori.Rows(x)("activa") <> dtdes.Rows(x)("activa") Or Not dtori.Rows(x)("oferta_usada").Equals(dtdes.Rows(x)("oferta_usada")) Then
                                    aquitar = True
                                    x = z
                                End If
                            End If
                            
                        Next
                        If Not aquitar Then
                            ds.Tables.Remove(dtori)
                            dtdes.TableName = "reservas_ofertas"
                        End If

                    End If

                End If
                If (ds.HasChanges Or reserva_id = 0) And reserva_id <> -1 Then
                    'TODO actualizar si ha cambiado
                    Console.WriteLine(reserva_id)
                    Dim writer As Odbc.OdbcDataAdapter

                    Dim filas As DataRowCollection
                    Dim x As Integer
                    cmd.Parameters.Clear()
                    Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
                    cmd.Parameters.Add(reserva_idParam)
                    If reserva_id = 0 Then
                        writer = getDataAdapter(cmd, sqlCabReserva)
                        writer.Fill(ds.Tables("reserva"))
                        writer.Update(ds.Tables("reserva"))
                        reserva_id = ExecuteScalar(cmd, "SELECT LAST_INSERT_ID()")
                    End If
                    reserva_idParam.Value = reserva_id
                    'todo...grabar siempre reservas servicios..
                    filas = ds.Tables("reservas_servicios").Rows
                    Dim fcount As Integer = filas.Count - 1
                    For x = 0 To fcount
                        If Not filas(x).RowState = DataRowState.Deleted Then
                            If filas(x)("reserva_id") <> reserva_id Then
                                filas(x)("reserva_id") = reserva_id
                            End If
                        End If
                    Next
                    If Not IsNothing(ds.Tables("reservas_servicios").GetChanges) Then
                        writer = getDataAdapter(cmd, sqlReservasServicios)
                        writer.Fill(ds.Tables("reservas_servicios"))
                        writer.Update(ds.Tables("reservas_servicios"))
                    End If



                    filas = ds.Tables("reservas_contratos").Rows

                    For x = 0 To filas.Count - 1
                        If Not filas(x).RowState = DataRowState.Deleted Then
                            filas(x)("reserva_id") = reserva_id
                        End If
                    Next
                    filas = ds.Tables("reservas_ofertas").Rows
                    For x = 0 To filas.Count - 1
                        If Not filas(x).RowState = DataRowState.Deleted Then
                            filas(x)("reserva_id") = reserva_id
                        End If
                    Next
                    filas = ds.Tables("reservas_habitaciones").Rows
                    For x = 0 To filas.Count - 1
                        If Not filas(x).RowState = DataRowState.Deleted Then
                            filas(x)("reserva_id") = reserva_id
                        End If
                    Next
                    writer = getDataAdapter(cmd, sqlObtieneReservasContratos)
                    writer.Fill(ds.Tables("reservas_contratos"))
                    writer.Update(ds.Tables("reservas_contratos"))
                    writer = getDataAdapter(cmd, sqlReservasOfertas)
                    writer.Fill(ds.Tables("reservas_ofertas"))
                    writer.Update(ds.Tables("reservas_ofertas"))
                    writer = getDataAdapter(cmd, sqlReservasHabitaciones)
                    writer.Fill(ds.Tables("reservas_habitaciones"))
                    writer.Update(ds.Tables("reservas_habitaciones"))

                End If
                Return reserva_id
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Private Function obtieneServiciosReserva(ByVal cmd As Odbc.OdbcCommand, ByVal reserva_id As Integer, ByVal fecha_ini As Object, ByVal fecha_fin As Object, Optional ByVal noupdate As Boolean = False) As tablaServicios
            'AgregaInfo("obtieneServiciosReserva", reserva_id & "_" & New System.Diagnostics.StackTrace(True).ToString(), -1)
            Dim resultado As tablaServicios
            Try
                If Not noupdate Then
                    NormalizaReserva(cmd, reserva_id)
                End If
                Dim ds As DataSet = preparaDatasetReserva(cmd, reserva_id)
                resultado = obtieneServiciosReserva(cmd, ds, fecha_ini, fecha_fin)
                If Not noupdate Then
                    Dim resobject As Object = grabaDatasetReserva(cmd, ds, reserva_id)
                    If IsNothing(resobject) Then
                        resultado = Nothing
                    End If
                End If
            Catch ex As Exception
                resultado = Nothing
            End Try

            Return resultado
        End Function
        Shared sqlServiciosHoteles = "" _
& " SELECT servicios.servicio_id as servicio_id," _
& " servicios_hotel.impuesto_id, " _
& " impuestos.porcentaje, " _
& " servicios.tipo_servicio_id, " _
& " servicios.abreviatura " _
& " FROM" _
& " servicios_hotel " _
& " Inner Join servicios ON servicios_hotel.servicio_id = servicios.servicio_id " _
& " Inner Join impuestos ON servicios_hotel.impuesto_id = impuestos.impuesto_id " _
& " WHERE " _
& " servicios_hotel.hotel_id =  ? "
        Shared sqlUnidadesCalculos = "select * from unidades_calculo"
        Private Function convierteReservasServicios(ByVal cmd As Odbc.OdbcCommand, ByVal ds As DataSet, Optional ByVal paso As Integer = 0) As DataTable
            cmd.Parameters.Clear()
            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", 0)
            cmd.Parameters.Add(reserva_idParam)

            'getDataTable(cmd, sqlTablaReservas, True)
            'datos.add(New DataView(getDataTable(cmd, sqlTablaReservas, True)))
            Dim datos As DataSet = getDataSet(cmd, sqlTablaReservas, True)
            If ds.Tables("reserva").Rows.Count > 0 Then

                Dim ucs As DataTable = getDataSet(cmd, sqlUnidadesCalculos, True).Tables(0) ' se puede cachear
                'Dim ucs As DataTable = readerToTable(Me.getDataTable(cmd, sqlUnidadesCalculos, True)) ' se puede cachear
                Dim dcucs(0) As DataColumn
                dcucs(0) = ucs.Columns("unidad_calculo_id")
                ucs.PrimaryKey = dcucs

                Dim cabres As DataRow = ds.Tables("reserva").Rows(0)
                cmd.Parameters.Clear()
                Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", cabres("hotel_id"))
                cmd.Parameters.Add(hotel_idParam)
                Dim servhoteles As DataTable = getDataSet(cmd, sqlServiciosHoteles, True).Tables(0) ' se puede cachear
                'Dim servhoteles As DataTable = readerToTable(Me.getDataTable(cmd, sqlServiciosHoteles, True)) ' se puede cachear

                Dim dc(0) As DataColumn
                dc(0) = servhoteles.Columns("servicio_id")
                servhoteles.PrimaryKey = dc

                Dim reader As DataTableReader = ds.Tables("reservas_servicios").CreateDataReader
                Dim dias_estancia As Integer = 0
                Dim dias_antelacion As Integer = 0
                'datediff(ifnull(reservas.fecha_salida,reservas.fecha_prevista_salida),ifnull(reservas.fecha_llegada,reservas.fecha_prevista_llegada))
                Dim fechaini As Date
                If cabres.IsNull("fecha_salida") Then
                    fechaini = cabres("fecha_prevista_salida")
                Else
                    fechaini = cabres("fecha_salida")
                End If
                Dim fechafin As Date
                If cabres.IsNull("fecha_llegada") Then
                    fechafin = cabres("fecha_prevista_llegada")
                Else
                    fechafin = cabres("fecha_llegada")
                End If
                dias_estancia = DateDiff(DateInterval.DayOfYear, fechafin, fechaini)
                dias_antelacion = DateDiff(DateInterval.DayOfYear, cabres("fecha_reserva"), fechafin)
                'datediff(ifnull(reservas.fecha_llegada,reservas.fecha_prevista_llegada),ifnull(fecha_reserva,'01/01/2001'))
                Dim row As DataRow
                'Dim filas() As DataRow
                Dim servicio_extra As Integer
                Dim rowl As DataRow
                While reader.Read
                    If reader.IsDBNull(reader.GetOrdinal("servicio_extra")) Then
                        servicio_extra = 0
                    Else
                        servicio_extra = reader("servicio_extra")
                    End If
                    If paso >= 0 And ((paso = 0 And servicio_extra = 1) Or (paso = 1 And servicio_extra <> 1) Or reader("flag_contrato") = 0) Then
                        'no recalculo si era un servicio extra o es de cliente directo
                    Else
                        row = datos.Tables(0).Rows.Add()
                        'servicio_reserva_id,reserva_id,servicio_id,unidad_calculo_id,fecha_desde,fecha_hasta,cantidad
                        ',impuesto_id,porcentaje,hotel_id,estado_reserva_id,bloquear_tarifa,cliente_id,dias_estancia,dias_antelacion,
                        'fecha_reserva,fecha_llegada,fecha_salida,fecha_prevista_llegada,fecha_prevista_salida,fecha_prevista_salida,tipo_servicio_id
                        'UC,abreviatura
                        'tabla reservas_servicios
                        'row("contrato_id_fijo") = reader("contrato_id_fijo")
                        row("servicio_reserva_id") = reader("servicio_reserva_id")
                        row("reserva_id") = reader("reserva_id")
                        row("servicio_id") = reader("servicio_id")
                        row("unidad_calculo_id") = reader("unidad_calculo_id")
                        row("cantidad") = reader("cantidad")
                        If reader.IsDBNull(reader.GetOrdinal("fecha_desde")) Then
                            row("fecha_desde") = fechafin
                        Else
                            row("fecha_desde") = reader("fecha_desde")
                        End If

                        If reader.IsDBNull(reader.GetOrdinal("fecha_hasta")) Then
                            row("fecha_hasta") = fechaini
                        Else
                            row("fecha_hasta") = reader("fecha_hasta")
                        End If
                        Try
                            row("flag_contrato") = reader("flag_contrato")
                        Catch ex As Exception
                            row("flag_contrato") = 1
                        End Try
                        row("precio_servicio") = reader("precio_servicio")


                        'tabla servicios_hotel
                        rowl = servhoteles.Rows.Find(reader("servicio_id"))
                        'filas = servhoteles.Select("servicio_id=" & reader("servicio_id"))
                        'If filas.Length > 0 Then
                        If Not IsNothing(rowl) Then
                            'rowl = filas(0)
                            row("impuesto_id") = rowl("impuesto_id")
                            row("porcentaje") = rowl("porcentaje")
                            row("tipo_servicio_id") = rowl("tipo_servicio_id")
                            row("abreviatura") = rowl("abreviatura")
                        End If

                        'cab reserva
                        row("hotel_id") = cabres("hotel_id")
                        row("estado_reserva_id") = cabres("estado_reserva_id")
                        row("bloquear_tarifa") = cabres("bloquear_tarifa")
                        row("cliente_id") = cabres("cliente_id")
                        row("dias_estancia") = dias_estancia
                        row("dias_antelacion") = dias_antelacion
                        row("fecha_reserva") = cabres("fecha_reserva")
                        row("fecha_llegada") = cabres("fecha_llegada")
                        row("fecha_salida") = cabres("fecha_salida")
                        row("fecha_prevista_llegada") = cabres("fecha_prevista_llegada")
                        row("fecha_prevista_salida") = cabres("fecha_prevista_salida")
                        'unidades calculo
                        'filas = ucs.Select("unidad_calculo_id=" & reader("unidad_calculo_id"))
                        rowl = ucs.Rows.Find(reader("unidad_calculo_id"))
                        If Not IsNothing(rowl) Then
                            row("UC") = rowl("UC")
                        End If
                    End If
                End While
            End If
            Return datos.Tables(0) '.CreateDataReader
        End Function
        Private Function obtieneServiciosReserva(ByVal cmd As Odbc.OdbcCommand, ByVal ds As DataSet, ByVal fecha_ini As Object, ByVal fecha_fin As Object, Optional ByVal paso As Integer = 0, Optional ByVal forzarPaso As Boolean = False) As tablaServicios

            Dim errorCode As Integer = 0
            'Dim reserva_id As Integer = 0 'quitar
            'TODO:cambiar leer las ucs y cantidades directamente del dataset lineas_reserva
            '//x

            Dim ucs As DataSet = obtieneUCSReserva(cmd, ds)
            Dim ucHijas As DataSet = obtieneUCHijas(cmd)


            Dim resultado As New tablaServicios
            resultado.servicios.Columns.Add("impuesto_id", System.Type.GetType("System.Int16"))
            resultado.servicios.Columns.Add("dias_estancia", System.Type.GetType("System.Int16"))
            resultado.servicios.Columns.Add("dias_antelacion", System.Type.GetType("System.Int16"))
            'resultado.servicios.Columns.Add("porc_impuesto", System.Type.GetType("System.Decimal"))
            resultado.servicios.Columns.Add("fecha_reserva", System.Type.GetType("System.DateTime"))
            resultado.servicios.Columns.Add("fecha_llegada", System.Type.GetType("System.DateTime"))
            resultado.servicios.Columns.Add("fecha_salida", System.Type.GetType("System.DateTime"))

            'TODO:no usar query y usar el dataset
            'todo:convierte reservas_servicios a formato preprocesa
            Dim rpaso As Integer = paso
            If forzarPaso Then
                rpaso = -1
            End If
            Dim reader As DataTableReader
            'Dim reader As DataTableReader = getDataTable(cmd, sqlTablaReservas)
            reader = preProcesaServicios(convierteReservasServicios(cmd, ds, rpaso))

            'Dim ncontratoid As New ArrayList
            Dim bloqueo As Boolean = False
            Dim estado_reserva_id As Integer
            'todo cargar blokeo

            Try
                Using reader
                    Dim contrareader As DataTableReader = Nothing
                    Dim fllegada As DateTime
                    Dim fsalida As DateTime
                    Dim fdesde As DateTime '= fllegada
                    Dim fhasta As DateTime '= fsalida
                    Dim flag_contrato As Boolean
                    Dim flag_directo As Boolean
                    Dim dv As DataView
                    Dim ultimodvcontrato_id As Integer
                    While reader.Read And errorCode = 0
                        '
                        'TODO si no hay blokeo y no esta en checkin-checkout 
                        'obtener el contrato_id activo para ese cliente
                        estado_reserva_id = reader.Item("estado_reserva_id")
                        bloqueo = reader.Item("bloquear_tarifa")

                        If estado_reserva_id = 0 Or estado_reserva_id = 2 Or (estado_reserva_id = 1 And Not bloqueo) Or (estado_reserva_id = 3 And Not bloqueo) Then
                            contrareader = obtieneContratoActivosCliente(cmd, reader.Item("hotel_id"), reader.Item("cliente_id"), reader.Item("fecha_prevista_llegada"), reader.Item("fecha_prevista_salida"), 1)
                        Else
                            contrareader = ds.Tables("reservas_contratos").CreateDataReader
                        End If

                        'todo ejecutar funcion por todos los contratos.
                        'Dim ienu As IEnumerator = ncontratoid.GetEnumerator
                        
                        Dim contrato_idParam As New Odbc.OdbcParameter("@contrato_id", 0)
                        While contrareader.Read() And errorCode = 0

                            'todo agregar solo si el servicio es para el touroperador y este es el contrato tour
                            'o si no es para touroperador y el contrato no es de touroperador

                            If Not reader.IsDBNull(reader.GetOrdinal("flag_contrato")) Then
                                flag_contrato = reader.Item("flag_contrato")
                            Else
                                flag_contrato = True
                            End If
                            'If Not reader.IsDBNull(reader.GetOrdinal("directo")) Then
                            flag_directo = contrareader("directo")
                            'End If
                            If flag_contrato And flag_directo = False Or (Not flag_contrato And flag_directo = True) Then
                                If ultimodvcontrato_id <> contrareader("contrato_id") Then
                                    'calcTime("sub1", True)
                                    ultimodvcontrato_id = contrareader("contrato_id")
                                    cmd.Parameters.Clear()
                                    contrato_idParam.Value = contrareader("contrato_id")
                                    cmd.Parameters.Add(contrato_idParam)
                                    'dv = getDataView(cmd, sqlTablaServicioContrato, True)
                                    'dv = New DataView(getDataSet(cmd, sqlTablaServicioContrato, True).Tables(0), "", "", DataViewRowState.CurrentRows)
                                    'dv = New DataView(getTable(cmd, sqlTablaServicioContrato, True), "", "", DataViewRowState.CurrentRows)
                                    dv = New DataView(getTable(cmd, sqlTablaServicioContrato, True))
                                    'calcTime("sub1", False)

                                End If


                                If IsDBNull(reader.Item("fecha_llegada")) Then
                                    fllegada = reader.Item("fecha_prevista_llegada")
                                Else
                                    fllegada = reader.Item("fecha_llegada")
                                End If

                                If IsDBNull(reader.Item("fecha_salida")) Then
                                    fsalida = reader.Item("fecha_prevista_salida")
                                Else
                                    fsalida = reader.Item("fecha_salida")
                                End If


                                'If Not reader.IsDBNull(reader.GetOrdinal("fecha_desde")) Then
                                fdesde = reader.Item("fecha_desde")
                                'End If
                                'If Not reader.IsDBNull(reader.GetOrdinal("fecha_hasta")) Then
                                fhasta = reader.Item("fecha_hasta")
                                'End If

                                If fdesde < fllegada OrElse fdesde > fsalida Then
                                    fdesde = fllegada
                                End If
                                If fhasta > fsalida OrElse fhasta < fllegada Then
                                    fhasta = fsalida
                                End If
                                'Console.WriteLine(reader.Item("cantidad"))


                                Dim x As tablaServicios = Nothing
                                If Not reader.IsDBNull(reader.GetOrdinal("porcentaje")) Then
                                    'calcTime("obtieneTablaServicioContrato", True)
                                    x = obtieneTablaServicioContrato(cmd, ucHijas, contrareader("contrato_id"), reader.Item("servicio_id"), reader.Item("unidad_calculo_id"), reader.Item("UC"), reader.Item("cantidad"), fdesde, fhasta, reader.Item("servicio_reserva_id"), ucs, reader.Item("porcentaje"), flag_directo, reader.Item("precio_servicio"), dv)
                                    'calcTime("obtieneTablaServicioContrato", False)
                                Else
                                    errorCode = 2 'servicio sin % de impuesto
                                    AgregaInfo("obtieneServiciosReserva", "servicio sin % de impuesto:" & reader.Item("servicio_id"), -errorCode)
                                End If
                                'paralelizar
                                If Not IsNothing(x) Then
                                    x.borrarDeTabla("cantidad=0 and importe=0 and error=0")
                                    x.agregaCampo("dias_estancia", System.Type.GetType("System.Int16"), reader.Item("dias_estancia"))
                                    x.agregaCampo("dias_antelacion", System.Type.GetType("System.Int16"), reader.Item("dias_antelacion"))
                                    x.agregaCampo("impuesto_id", System.Type.GetType("System.Int16"), reader.Item("impuesto_id"))
                                    x.agregaCampo("fecha_reserva", System.Type.GetType("System.DateTime"), "'" & reader.Item("fecha_reserva") & "'")
                                    x.agregaCampo("fecha_llegada", System.Type.GetType("System.DateTime"), "'" & fllegada & "'")
                                    x.agregaCampo("fecha_salida", System.Type.GetType("System.DateTime"), "'" & fsalida & "'")
                                    resultado.agregaTabla(x, True)
                                Else
                                    errorCode = 1 'devuelve tabla servicios null
                                    AgregaInfo("obtieneServiciosReserva", "devuelve tabla servicios null:", -errorCode)
                                End If
                            End If
                        End While
                    End While
                End Using

                Dim al As ArrayList = resultado.obtieneDistintos("contrato_id_defecto")

                'si al y ncontratoid son distintos
                'falta comparar con base de datos


                Dim cambio As Boolean = False
                'If estado_reserva_id < 2 And Not bloqueo Then
                If estado_reserva_id = 0 Or estado_reserva_id = 2 Or (estado_reserva_id = 1 And Not bloqueo) Or (estado_reserva_id = 3 And Not bloqueo) Then
                    cambio = True
                End If

                'todo:insertar o borrar datos del dataset y no de la bd de reservas_contratos
                If cambio Then
                    'si no esta blokeado vaciar reservas_contratos
                    'optimizar...si lo ke vas a meter es igual a lo ke estaba metido...no se toka
                    Dim rows As DataRowCollection = ds.Tables("reservas_contratos").Rows
                    Dim ienual As IEnumerator = al.GetEnumerator
                    Dim hacambiado As Boolean = False
                    If errorCode = 0 And rows.Count = al.Count Then

                        While hacambiado = False And ienual.MoveNext
                            Dim contrato_id As Integer
                            Dim defecto As Boolean
                            contrato_id = CInt(CStr(ienual.Current).Split("_")(0))
                            defecto = CBool(CStr(ienual.Current).Split("_")(1))
                            Dim cont As Integer = 0
                            Dim subcont As Integer = 0
                            For cont = 0 To rows.Count - 1
                                Dim row As DataRow = rows(cont)
                                If row("contrato_id") = contrato_id And row("directo") = defecto Then
                                    subcont = 1
                                End If
                            Next
                            If subcont = 0 Then
                                hacambiado = True
                            End If
                        End While
                    Else
                        hacambiado = True
                    End If
                    If hacambiado Then
                        Dim x As Integer
                        For x = 0 To rows.Count - 1
                            rows(x).Delete()
                        Next
                        ienual = al.GetEnumerator
                        While errorCode = 0 And ienual.MoveNext
                            Dim contrato_id As Integer
                            Dim defecto As Boolean
                            contrato_id = CInt(CStr(ienual.Current).Split("_")(0))
                            defecto = CBool(CStr(ienual.Current).Split("_")(1))
                            Dim row As DataRow = rows.Add()
                            row("reserva_id") = 0
                            row("contrato_id") = contrato_id
                            row("directo") = defecto
                        End While
                    End If
                End If
                al = resultado.obtieneDistintos("contrato_id")
                'todo:asegurarse ke ofertas usa el dataset y no accesos a BD
                'si tiene oferta validad...aplicarla sobre el resultado total
                'se cambian tipo y oferta,tipo imputacion deberia ser diario
                obtieneOfertasReserva(cmd, ds, al, resultado, ucs, paso)
            Finally
            End Try
            If paso <= 0 Then
                If errorCode <> 0 Then
                    resultado = Nothing
                Else

                    resultado.servicios = resultado.servicios.Copy()
                    resultado.borrarDeTabla("cantidad=0")
                    'TODO: calcular la media por servicio/uc y asignarla dia
                    resultado.redondear(2, metaresid, metaresidhash)
                    Dim tmptab As DataTable = resultado.ObtieneMediaServiciosUc()
                    resultado.ActualizarMediaServiciosUC(tmptab)
                    'todo añadir descuentos
                    If ds.Tables.Contains("reservas_descuentos") Then
                        Dim rows As DataRowCollection = ds.Tables("reservas_descuentos").Rows
                        Dim x As Integer
                        If resultado.servicios.Rows.Count > 0 Then
                            For x = 0 To rows.Count - 1
                                Dim imp As Single
                                If rows(x)("tipo_descuento_id") = 2 Or rows(x)("tipo_descuento_id") = 1 Then
                                    If rows(x)("tipo_descuento_id") = 2 Then
                                        imp = rows(x)("descuento")
                                    Else
                                        'suma todos los servicios con tipo_servicio_id igual
                                        Dim impt = resultado.servicios.Compute("sum(importe)", "tipo_servicio_id=" & rows(x)("tipo_servicio_id"))
                                        If IsDBNull(impt) Then
                                            impt = 0
                                        End If
                                        imp = impt * rows(x)("descuento") / 100
                                    End If

                                    Dim row As DataRow = resultado.servicios.Rows.Add(resultado.servicios.Rows(0).ItemArray)
                                    'tipo_servicio_id()
                                    row("contrato_id") = DBNull.Value
                                    row("tipo_servicio_id") = rows(x)("tipo_servicio_id")
                                    row("servicio_id") = rows(x)("servicio_id")
                                    row("ucid") = 1 ' servicio 
                                    row("cantidad") = 1 ' cantidad 
                                    row("defecto") = 0 'defecto
                                    'row("fecha") = fecha_ini
                                    row("descripcion") = rows(x)("nombre_servicio")
                                    row("impuesto_id") = rows(x)("impuesto_id")
                                    row("porc_impuesto") = rows(x)("porcentaje")

                                    row("precio_produccion") = -imp
                                    row("importe") = -imp
                                    row("precio") = -imp '-(imp - (imp * rows(x)("porcentaje") / 100))
                                    'row("tipo_linea_factura") = "A"
                                    'tipo_linea_factura
                                    'importe
                                End If
                            Next
                        End If
                    End If
                    'dumpDataTable(resultado.servicios)
                    '                dumpDataTable(tmptab)
                    If Not IsNothing(fecha_ini) And Not IsNothing(fecha_fin) Then
                        resultado.erroresAntesBorrar = resultado.sumaErrores()
                        Dim fini As Date = fecha_ini
                        Dim ffin As Date = fecha_fin
                        resultado.borrarDeTabla("not (fecha>= '" & fini & "' and fecha <='" & ffin & "')")
                        'resultado.borrarDeTabla("fecha BETWEEN '" & fini & "' and '" & ffin & "'")
                    End If

                End If

            End If

            Return resultado
        End Function

        Shared sqlContratoHotelClienteFechaOld = "" _
                & " SELECT distinct" _
                & " contratos.contrato_id,clientes.cliente_defecto as directo" _
                & " FROM " _
                & " contratos left join clientes on contratos.cliente_id=clientes.cliente_id " _
                & " WHERE " _
                & " contratos.hotel_id =  ? AND " _
                & " (contratos.cliente_id =  ? or contratos.cliente_id in (SELECT c.cliente_id FROM clientes AS c Inner Join hoteles AS h ON h.empresa_id = c.empresa_id  WHERE c.cliente_defecto = 1 and h.hotel_id=contratos.hotel_id)) " _
                & " and contrato_id_siguiente is null AND " _
                & " (" _
                & " ? between contratos.fecha_desde and contratos.fecha_hasta " _
                & " or " _
                & " ? between contratos.fecha_desde and contratos.fecha_hasta " _
                & " )" _
                & " order by contratos.fecha_desde"

        Shared sqlContratoHotelClienteFecha = "select drvk.contrato_id,min(drvk.directo) as directo from (" _
        & " SELECT distinct" _
        & " contratos.contrato_id,0 as directo" _
        & " FROM " _
        & " contratos left join clientes on contratos.cliente_id=clientes.cliente_id " _
        & " WHERE " _
        & " contratos.hotel_id =  ? AND " _
        & " contratos.cliente_id =  ?" _
        & " and contrato_id_siguiente is null AND " _
        & " (" _
        & " ? between contratos.fecha_desde and contratos.fecha_hasta " _
        & " or " _
        & " ? between contratos.fecha_desde and contratos.fecha_hasta " _
        & " )" _
        & " union all SELECT distinct" _
        & " contratos.contrato_id,clientes.cliente_defecto as directo" _
        & " FROM " _
        & " contratos left join clientes on contratos.cliente_id=clientes.cliente_id " _
        & " WHERE " _
        & " contratos.hotel_id =  ? AND " _
        & " clientes.cliente_defecto =  1" _
        & " and contrato_id_siguiente is null AND " _
        & " (" _
        & " ? between contratos.fecha_desde and contratos.fecha_hasta " _
        & " or " _
        & " ? between contratos.fecha_desde and contratos.fecha_hasta " _
        & " )" _
        & " ) drvk group by drvk.contrato_id order by 2 desc,1"
        '    & " ?>=contratos.fecha_desde AND  ?<=contratos.fecha_hasta " _
        Private Function obtieneContratoActivosCliente(ByVal cmd As Odbc.OdbcCommand, ByVal hotel As Integer, ByVal cliente As Integer, ByVal fechaini As Date, ByVal fechafin As Date, Optional ByVal tipo As Integer = 0) As Object
            cmd.Parameters.Clear()
            ' Create a SqlParameter for each parameter in the stored procedure.
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel)
            Dim hotel_id1Param As New Odbc.OdbcParameter("@hotel_id1", hotel)
            Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", cliente)
            Dim fechainiParam As New Odbc.OdbcParameter("@fechaini", fechaini)
            Dim fechafinParam As New Odbc.OdbcParameter("@fechafin", fechafin)
            Dim fechaini1Param As New Odbc.OdbcParameter("@fechaini1", fechaini)
            Dim fechafin1Param As New Odbc.OdbcParameter("@fechafin1", fechafin)
            cmd.Parameters.Add(hotel_idParam)
            cmd.Parameters.Add(cliente_idParam)
            cmd.Parameters.Add(fechainiParam)
            cmd.Parameters.Add(fechafinParam)

            cmd.Parameters.Add(hotel_id1Param)
            cmd.Parameters.Add(fechaini1Param)
            cmd.Parameters.Add(fechafin1Param)
            Dim dtr As DataTableReader = getDataTable(cmd, sqlContratoHotelClienteFecha, True)
            If tipo = 0 Then
                Dim x As New ArrayList()
                While dtr.Read()
                    x.Add(dtr.Item("contrato_id"))
                End While
                Return x
            Else
                Return dtr
            End If

        End Function

        Private Function obtieneContratoActivoCliente(ByVal cmd As Odbc.OdbcCommand, ByVal hotel As Integer, ByVal cliente As Integer, ByVal fechaini As Date, ByVal fechafin As Date)
            Dim dtr As ArrayList = obtieneContratoActivosCliente(cmd, hotel, cliente, fechaini, fechafin)
            Dim contrato_id = 0
            If dtr.Count > 0 Then
                contrato_id = dtr.Item(dtr.Count - 1)
            End If
            Return contrato_id
        End Function
        Shared sqlLineasTickets = "" _
        & " SELECT" _
     & " tickets.cliente_id AS cliente_id_ticket," _
     & "  tickets.cliente_id_contrato, " _
     & " tickets.hotel_id, " _
     & " tickets.fecha, " _
     & " reservas.cliente_id AS cliente_id_reserva, " _
     & " lineas_ticket.servicio_id, " _
     & " lineas_ticket.unidad_calculo_id, " _
     & " lineas_ticket.cantidad,lineas_ticket.linea_ticket_id, " _
     & " servicios_hotel.impuesto_id,impuestos.porcentaje" _
     & " FROM " _
     & " tickets" _
     & " Left Join reservas ON tickets.reserva_id = reservas.reserva_id " _
     & " Inner Join lineas_ticket ON tickets.ticket_id = lineas_ticket.ticket_id" _
     & " Inner Join servicios_hotel ON tickets.hotel_id = servicios_hotel.hotel_id AND lineas_ticket.servicio_id = servicios_hotel.servicio_id" _
     & " Inner Join impuestos ON servicios_hotel.impuesto_id = impuestos.impuesto_id " _
     & " WHERE " _
     & " tickets.ticket_id =  ?"
        Shared sqlActualizaLineaTickets = "" _
    & " update lineas_ticket set" _
    & " contrato_id=?" _
    & " ,descripcion=?" _
    & " ,impuesto_id=?" _
    & " ,porc_impuesto=?" _
    & " ,precio=?" _
    & " WHERE" _
    & " linea_ticket_id =  ?"
        Shared sqlLimpiaLineaTickets = "" _
    & " update lineas_ticket set" _
    & " contrato_id=null" _
    & " ,descripcion=null" _
    & " ,impuesto_id=null" _
    & " ,porc_impuesto=null" _
    & " ,precio=null" _
    & " WHERE" _
    & " ticket_id =  ?"


        Function generaCamposLineasTickets(ByVal ticket As Integer)
            Dim errorCode As Integer = 0


            Dim cmd As Odbc.OdbcCommand = prepareConection()


            cmd.Parameters.Clear()
            Dim ticketParam As New Odbc.OdbcParameter("@ticket_id", ticket)
            cmd.Parameters.Add(ticketParam)
            'limpia campos
            ExecuteNonQuery(cmd, sqlLimpiaLineaTickets)
            'Transaccion.Commit()

            'Transaccion = conn.BeginTransaction(IsolationLevel.Serializable)
            'cmd.CommandType = CommandType.Text
            'cmd.Connection = conn
            'cmd.Transaction = Transaccion

            'cmd.Parameters.Clear()
            ''Dim ticketParam As New Odbc.OdbcParameter("@ticket_id", ticket)
            'cmd.Parameters.Add(ticketParam)
            'limpia campos
            'ExecuteNonQuery(cmd, sqlLimpiaLineaTickets)
            Dim reader As DataTableReader = getDataTable(cmd, sqlLineasTickets)
            Dim contrato_id = Nothing
            Dim cliente = Nothing
            While reader.Read And errorCode = 0
                If IsNothing(contrato_id) Then
                    'todo logica otros clientes
                    cliente = reader.Item("cliente_id_ticket")
                    If Not reader.IsDBNull(reader.GetOrdinal("cliente_id_contrato")) Then
                        cliente = reader.Item("cliente_id_contrato")
                    End If

                    contrato_id = obtieneContratoActivoCliente(cmd, reader.Item("hotel_id"), cliente, reader.Item("fecha"), reader.Item("fecha"))
                End If
                Dim x As tablaServicios = obtieneServicioPorDia(cmd, contrato_id, reader.Item("servicio_id"), reader.Item("unidad_calculo_id"), reader.Item("cantidad"), reader.Item("fecha"), reader.Item("porcentaje"))
                Dim linea_contrato_id = Nothing
                Dim descripcion = Nothing
                Dim precio = Nothing
                Dim impuesto_id = Nothing 'reader.Item("impuesto_id")
                Dim porcentaje = Nothing 'reader.Item("porcentaje")
                'Dim importeConIgic = Nothing 'reader.Item("porcentaje")
                Dim linea_ticket_id = reader.Item("linea_ticket_id")
                'Dim servicio_id = Nothing
                Dim graba As Boolean = False
                If Not IsNothing(x) Then
                    'todo update servicio
                    If x.servicios.Rows.Count > 0 Then
                        linea_contrato_id = x.servicios.Rows(0).Item("grupo")
                        descripcion = x.servicios.Rows(0).Item("descripcion")
                        precio = x.servicios.Rows(0).Item("precio")
                        impuesto_id = reader.Item("impuesto_id")
                        porcentaje = reader.Item("porcentaje")
                        'importeConIgic = x.servicios.Rows(0).Item("importeConIgic")
                        'servicio_id = reader.Item("servicio_id")
                        graba = True
                        'linea_ticket_id= reader.Item("linea_ticket_id")
                    End If
                End If
                If graba Then
                    Dim contrato_idParam As New Odbc.OdbcParameter("@contrato_id", contrato_id)
                    Dim descripcionParam As New Odbc.OdbcParameter("@descripcion", descripcion)
                    Dim precioParam As New Odbc.OdbcParameter("@precio", precio)
                    Dim impuesto_idParam As New Odbc.OdbcParameter("@impuesto_id", impuesto_id)
                    Dim porc_impuestoParam As New Odbc.OdbcParameter("@porc_impuesto", porcentaje)
                    Dim linea_ticket_idParam As New Odbc.OdbcParameter("@linea_ticket_id", linea_ticket_id)
                    'Dim importeConIgicParam As New Odbc.OdbcParameter("@importeConIgic", importeConIgic)

                    If IsNothing(linea_contrato_id) Then
                        contrato_idParam.Value = Nothing
                    End If
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(contrato_idParam)
                    cmd.Parameters.Add(descripcionParam)
                    cmd.Parameters.Add(impuesto_idParam)
                    cmd.Parameters.Add(porc_impuestoParam)
                    cmd.Parameters.Add(precioParam)
                    'cmd.Parameters.Add(importeConIgicParam)
                    cmd.Parameters.Add(linea_ticket_idParam)
                    Dim num = ExecuteNonQuery(cmd, sqlActualizaLineaTickets)
                    If num = 1 Then
                    Else
                        errorCode = 1 'no puede actualizar registro
                        AgregaInfo("generaCamposLineasTickets", "No pudo actualizar la linea del ticket:" & linea_ticket_id, -errorCode)

                    End If
                End If
            End While
            flushConection(cmd, errorCode)
            Return errorCode
        End Function
        Shared sqlBorrarOferta = "delete  from ofertas where oferta_id=? and (select count(*) from reservas_ofertas r where r.oferta_id=ofertas.oferta_id and r.activa=1)=0 "
        Public Function BorrarOferta(ByVal oferta_id As Integer)
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try
                cmd.Parameters.Clear()
                Dim oferta_idParam As New Odbc.OdbcParameter("@oferta_id", oferta_id)
                cmd.Parameters.Add(oferta_idParam)
                Me.ExecuteNonQuery(cmd, sqlBorrarOferta)
            Catch ex As Exception
                errorCode = 1
            End Try
            flushConection(cmd, errorCode)
            Return errorCode
        End Function

        Public Class menormayor
            Implements IComparer

            ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
            Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
                If x.valor = y.valor Then
                    Return 0
                End If
                If x.valor > y.valor Then
                    Return -1
                Else
                    Return 1
                End If
            End Function 'IComparer.Compare

        End Class 'menormayor
        Public Class mayormenor
            Implements IComparer

            ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
            Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
                If x.valor = y.valor Then
                    Return 0
                End If
                If x.valor < y.valor Then
                    Return -1
                Else
                    Return 1
                End If

            End Function 'IComparer.Compare

        End Class 'menormayor
        Private Class keyvalor
            Public key As String
            Public valor As Single
        End Class
        Public Function cobrarFactura(ByVal arrfac() As String, ByVal cobro_id As Integer, Optional ByVal tipo_cobro_id As Integer = 1, Optional ByVal parcial As Boolean = False, Optional ByRef importe As Single = Nothing)
            Dim retVal As Boolean = True
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try
                'Dim arrfac() As String = facturas.Split(",")
                Dim x As Integer
                Dim total As Single
                Dim facposneg As New ArrayList()

                'Dim facnegpos As New SortedList
                While retVal And x < arrfac.Length
                    Dim factura_id As Integer = arrfac(x)
                    Dim tmpi As Single = obtieneImportePendienteFactura(cmd, factura_id, tipo_cobro_id)
                    'tmpi = 0
                    Dim xk As New keyvalor
                    xk.key = "" & factura_id
                    xk.valor = tmpi
                    facposneg.Add(xk)
                    total += tmpi
                    x += 1
                End While
                If total = importe Then
                    parcial = False
                Else
                    parcial = True
                End If
                If total < 0 Then
                    facposneg.Sort(New menormayor)
                    'facnegpos.CopyTo(arrfac)
                Else
                    facposneg.Sort(New mayormenor)
                    'facposneg.CopyTo(arrfac)
                End If

                If retVal Then
                    x = 0
                    While retVal And x < facposneg.Count
                        Dim factura_id As Integer = facposneg(x).key
                        retVal = cobrarFactura(cmd, factura_id, cobro_id, tipo_cobro_id, parcial, importe)
                        x += 1
                    End While
                End If
            Catch ex As Exception
                retVal = False
                errorCode = 1
            End Try
            If Not flushConection(cmd, errorCode) Then
                retVal = False
            End If
            Return retVal
        End Function
        Public Function cobrarFactura(ByVal factura_id As Integer, ByVal cobro_id As Integer, Optional ByVal tipo_cobro_id As Integer = 1, Optional ByVal parcial As Boolean = False, Optional ByRef importe As Single = Nothing)
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = cobrarFactura(cmd, factura_id, cobro_id, tipo_cobro_id, parcial, importe)
            If Not flushConection(cmd, errorCode) Then
                retVal = False
            End If
            Return retVal
        End Function
        Shared sqlCobros = "select * from cobros where 1=0"
        Shared sqlLineasCobros = "select * from lineas_cobro where 1=0"

        Private Function cobrarFactura(ByVal cmd As Odbc.OdbcCommand, ByVal factura_id As Integer, ByVal cobro_id As Integer, Optional ByVal tipo_cobro_id As Integer = 1, Optional ByVal parcial As Boolean = False, Optional ByRef importe As Single = Nothing)
            'todo obtiene importe facturas
            'todo obtiene lo ya cobrado

            'todo si importe=0 fallo gordo
            Dim tmpi As Single = obtieneImportePendienteFactura(cmd, factura_id, tipo_cobro_id)
            If IsNothing(importe) Then
                importe = tmpi
            End If
            If parcial Then
                'que pasa si neg.
                If tmpi < 0 Then
                    If importe > 0 Then
                    Else
                        If tmpi < importe Or importe = 0 Then
                            tmpi = importe
                        End If
                    End If
                Else
                    If tmpi > importe And importe >= 0 Then
                        tmpi = importe
                    End If
                End If
            End If
            importe -= tmpi
            'If tmpi <> 0 Then
            Dim datosCobros As DataSet = getDataSet(cmd, sqlLineasCobros)
            Dim rowLin As DataRow = datosCobros.Tables(0).Rows.Add()
            rowLin.Item("cobro_id") = cobro_id
            rowLin.Item("factura_id") = factura_id
            rowLin.Item("importe") = tmpi
            Dim writer As Odbc.OdbcDataAdapter
            writer = getDataAdapter(cmd, sqlLineasCobros)
            writer.Fill(datosCobros.Tables(0))
            writer.Update(datosCobros)
            'End If
            Return True
        End Function
        Shared sqlCreaCobroDeFactura = "insert into cobros(fecha,tipo_cobro_id,hotel_id,caja_id,forma_pago_id,fecha_contabilizacion,observaciones,Estado_Cobro_Id,user_id,fecha_modificacion)" _
    & "    SELECT " _
    & "facturas.Fecha_Factura AS fecha, " _
    & "     ? AS tipo_cobro_id, " _
    & " facturas.hotel_id, " _
    & "     ? AS caja_id, " _
    & " facturas.Forma_Pago_Id, " _
    & "     null AS fecha_contabilizacion, " _
    & "     null AS observaciones, " _
    & "     '0' AS estado_cobro_id, " _
    & "     ? AS user_id, " _
    & "     ? AS fecha_modificacion " _
    & " FROM" _
    & " facturas " _
    & " WHERE " _
    & " facturas.Factura_Id =  ?"
        Shared sqlCrearLineasCobro = "insert into lineas_cobro(cobro_id,factura_id,importe) values (?,?,?)"
        Shared sqlCrearCobroAnticipo = "insert into cobros(fecha,tipo_cobro_id,hotel_id,caja_id,forma_pago_id,fecha_contabilizacion,observaciones,estado_cobro_id,user_id,fecha_modificacion)" _
    & " SELECT  " _
    & "         ? AS fecha," _
    & "         ? AS tipo_cobro_id,  " _
    & " anticipos.hotel_id AS hotel_id," _
    & " anticipos.caja_id AS caja_id, " _
    & " anticipos.forma_pago_id AS forma_pago_id, " _
    & "        null AS fecha_contabilizacion, " _
    & "        null AS observaciones, " _
    & "         0 AS estado_cobro_id, " _
    & "         ? AS user_id, " _
    & " now() AS fecha_modificacion " _
    & " FROM " _
    & " anticipos" _
    & " WHERE " _
    & " anticipos.anticipo_id =  ? "
        Shared sqlCrearLineasCobroAnticipo = "insert into lineas_cobro(cobro_id,factura_id,importe)" _
    & "         SELECT" _
    & "         ? AS cobro_id, " _
    & " lineas_anticipo.Factura_Id AS factura_id, " _
    & " lineas_anticipo.Importe AS importe " _
    & " FROM " _
    & " lineas_anticipo " _
    & " WHERE " _
    & " lineas_anticipo.Anticipo_Id =  ? AND " _
    & " lineas_anticipo.Fecha_Contabilizacion IS NULL "
        Shared sqlActualizaLineasAnticipo = "update lineas_anticipo set fecha_contabilizacion=now() where anticipo_id=? and Fecha_Contabilizacion IS NULL "
        Shared sqlObtieneHotelAnticipo = "select hotel_id from anticipos where anticipo_id=?"
        Shared sqlCuentaLineasAnticiposPendientes = "select count(*) from lineas_anticipo where anticipo_id=? and Fecha_Contabilizacion IS NULL "
        Private Function CrearCobro(ByVal cmd As Odbc.OdbcCommand, ByVal Anticipo_id As Integer)
            Dim retVal As Integer = 0
            Dim anticipo_idParam As New Odbc.OdbcParameter("@anticipo_id", Anticipo_id)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(anticipo_idParam)
            Dim nant As Integer = ExecuteScalar(cmd, sqlCuentaLineasAnticiposPendientes)
            If nant > 0 Then
                Dim hotel_id As Integer = ExecuteScalar(cmd, sqlObtieneHotelAnticipo)
                Dim fecha As Date = FechaHotel(cmd, hotel_id)
                cmd.Parameters.Clear()
                Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
                Dim tipo_cobro_idParam As New Odbc.OdbcParameter("@tipo_cobro_id", 5)
                Dim userIdParam As New Odbc.OdbcParameter("@userId", userId)
                cmd.Parameters.Add(fechaParam)
                cmd.Parameters.Add(tipo_cobro_idParam)
                cmd.Parameters.Add(userIdParam)
                cmd.Parameters.Add(anticipo_idParam)
                'creo cabecera cobro
                If Me.ExecuteNonQuery(cmd, sqlCrearCobroAnticipo) = 1 Then
                    retVal = ExecuteScalar(cmd, "SELECT LAST_INSERT_ID();")
                    Dim cobro_idParam As New Odbc.OdbcParameter("@cobro_id", retVal)
                    'meto lineas del cobro
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(cobro_idParam)
                    cmd.Parameters.Add(anticipo_idParam)
                    If Me.ExecuteNonQuery(cmd, sqlCrearLineasCobroAnticipo) = nant Then
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(anticipo_idParam)
                        If Me.ExecuteNonQuery(cmd, sqlActualizaLineasAnticipo) = nant Then
                        Else
                            'no coinciden las lineas
                            retVal = -3
                            AgregaInfo("CrearCobro", "no coinciden las lineas del anticipo:" & Anticipo_id, retVal)

                        End If
                    Else
                        'no coinciden las lineas
                        retVal = -3
                        AgregaInfo("CrearCobro", "no coinciden las lineas del anticipo:" & Anticipo_id, retVal)

                    End If
                Else
                    'no pudo crear cabecera de cobros
                    retVal = -2
                    AgregaInfo("CrearCobro", "no pudo crear cabecera de cobros del anticipo:" & Anticipo_id, retVal)

                End If
            Else
                'no hay lineas pendientes
                retVal = -1
                AgregaInfo("CrearCobro", "no hay lineas pendientes de anticipo:" & Anticipo_id, retVal)

            End If
            Return retVal
        End Function

        Private Function CrearCobro(ByVal cmd As Odbc.OdbcCommand, ByVal tipo_cobro_id As Integer, ByVal factura_id As Integer, ByVal caja_id As Integer) As Integer
            'TODO Cambiar fecha?
            Dim retVal As Integer = 0
            cmd.Parameters.Clear()
            Dim tipo_cobro_idParam As New Odbc.OdbcParameter("@tipo_cobro_id", tipo_cobro_id)
            Dim caja_idParam As New Odbc.OdbcParameter("@caja_id", caja_id)
            Dim user_idParam As New Odbc.OdbcParameter("@user_id", userId)
            Dim fecha_modificacionParam As New Odbc.OdbcParameter("@fecha_modificacion", Now)
            Dim Factura_IdParam As New Odbc.OdbcParameter("@factura_id", factura_id)
            cmd.Parameters.Add(tipo_cobro_idParam)
            cmd.Parameters.Add(caja_idParam)
            cmd.Parameters.Add(user_idParam)
            cmd.Parameters.Add(fecha_modificacionParam)
            cmd.Parameters.Add(Factura_IdParam)
            If ExecuteNonQuery(cmd, sqlCreaCobroDeFactura) > 0 Then
                retVal = ExecuteScalar(cmd, "SELECT LAST_INSERT_ID();")
                Dim importe As Single = obtieneImportePendienteFactura(cmd, factura_id)
                cmd.Parameters.Clear()
                Dim cobro_idParam As New Odbc.OdbcParameter("@cobro_id", retVal)
                Dim importeParam As New Odbc.OdbcParameter("@importe", importe)
                cmd.Parameters.Add(cobro_idParam)
                cmd.Parameters.Add(Factura_IdParam)
                cmd.Parameters.Add(importeParam)
                If ExecuteNonQuery(cmd, sqlCrearLineasCobro) = 0 Then
                    retVal = 0 'no pudo crear las lineas de cobro
                    AgregaInfo("CrearCobro", "no pudo crear las lineas de cobro de factura:" & factura_id, retVal)
                End If
            End If
            Return retVal
        End Function
        'Dim sqlTObtieneFacturasReserva = "select distinct l.factura_id from lineas_factura l where l.reserva_id=? and not l.factura_id is null"
        Public Function obtieneImportePendienteFacturas(ByVal reserva_id As String, ByVal sincredito As Boolean, Optional ByVal absoluto As Boolean = True)
            Dim retval As Single = 0
            Dim errorCode As Integer = 0
            Dim reserva As Integer = 0
            Try
                reserva = reserva_id
            Catch ex As Exception
            End Try
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try
                retval = obtieneImportePendienteFacturas(cmd, reserva, sincredito, absoluto)
            Catch ex As Exception
                errorCode = 0
            End Try
            flushConection(cmd, errorCode)
            Return retval
        End Function

        Private Function obtieneImportePendienteFacturas(ByVal cmd As Odbc.OdbcCommand, ByVal reserva_id As Integer, ByVal sincredito As Boolean, Optional ByVal absoluto As Boolean = True)
            Dim retval As Single = 0
            cmd.Parameters.Clear()
            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
            cmd.Parameters.Add(reserva_idParam)
            Dim reader As DataTableReader = getDataTable(cmd, sqlObtieneFacturasReserva)
            Dim contar As Boolean
            While reader.Read
                If sincredito And reader.Item("credito") Then
                    'solo facturacs ke no sean de credito
                    contar = False
                Else
                    contar = True
                End If
                If contar Then
                    If absoluto Then
                        'Console.WriteLine(reader.Item("factura_id"))
                        retval += Math.Abs(obtieneImportePendienteFactura(cmd, CInt(reader.Item("factura_id"))))
                    Else
                        retval += obtieneImportePendienteFactura(cmd, CInt(reader.Item("factura_id")))
                    End If

                End If
            End While
            Return retval
        End Function
        'Shared sqlImportePendienteFacturaO = "select sum(cantidad*precio*?)-(select ifnull(sum(importe),0) from lineas_cobro l where l.factura_id=lineas_factura.factura_id) from lineas_factura where lineas_factura.factura_id=?"
        'Shared sqlImportePendienteFactura = "select sum(cantidad*precio*?)-sum(ifnull(lineas_cobro.importe,0)) from lineas_factura left join lineas_cobro on lineas_factura.factura_id=lineas_cobro.factura_id where lineas_factura.factura_id=?"
        '        Shared sqlImporteFactura = "select ifnull(sum(round(cantidad*precio,2)),0) from lineas_factura where lineas_factura.factura_id=?"
        Shared sqlImporteFactura = "select importe_total from facturas where factura_id=?"
        Shared SqlCobradoFactura = "select ifnull(sum(lineas_cobro.importe),0) from  lineas_cobro where lineas_cobro.factura_id=?"
        Private Function obtieneImportePendienteFactura(ByVal cmd As Odbc.OdbcCommand, ByVal arrfac() As String, Optional ByVal tipo_cobro_id As Integer = 1) As Single
            Dim retVal As Single = 0
            Dim errorCode As Integer = 0
            Try
                'Dim arrfac() As String = facturas.Split(",")
                Dim x As Integer
                While x < arrfac.Length
                    Dim factura_id As Integer = arrfac(x)
                    retVal += obtieneImportePendienteFactura(cmd, factura_id, tipo_cobro_id)
                    x += 1
                End While
            Catch ex As Exception
                retVal = Nothing
                errorCode = -1
            End Try
            Return retVal
        End Function

        Public Function obtieneImportePendienteFactura(ByVal arrfac() As String, Optional ByVal tipo_cobro_id As Integer = 1) As Single
            Dim retVal As Single = 0
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = obtieneImportePendienteFactura(cmd, arrfac, tipo_cobro_id)
            If IsNothing(retVal) Then
                retVal = 0
                errorCode = -1
            End If
            If Not flushConection(cmd, errorCode) Then
                retVal = False
            End If
            Return retVal
        End Function
        Public Function obtieneImportePendienteFactura(ByVal factura_id As Integer, Optional ByVal tipo_cobro_id As Integer = 1) As Single
            Dim retVal As Single
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = obtieneImportePendienteFactura(cmd, factura_id, tipo_cobro_id)
            If Not flushConection(cmd, errorCode) Then
                retVal = False
            End If
            Return retVal
        End Function

        Private Function obtieneImportePendienteFactura(ByVal cmd As Odbc.OdbcCommand, ByVal factura_id As Integer, Optional ByVal tipo_cobro_id As Integer = 1) As Single

            Dim retVal As Single = 0
            cmd.Parameters.Clear()
            Dim Factura_IdParam As New Odbc.OdbcParameter("@factura_id", factura_id)
            cmd.Parameters.Add(Factura_IdParam)

            'Dim multiParam As New Odbc.OdbcParameter("@multi", 1)
            If tipo_cobro_id > 1 Then
                'multiParam.Value = 0
            Else
                retVal += Math.Round(ExecuteScalar(cmd, sqlImporteFactura), 2, MidpointRounding.AwayFromZero)
            End If
            'cmd.Parameters.Add(multiParam)


            retVal = Math.Round(retVal - ExecuteScalar(cmd, SqlCobradoFactura), 2, MidpointRounding.AwayFromZero)
            Return retVal

        End Function
        Shared sqlCabeceraTicket = "select * from tickets where ticket_id=? and fecha_contabilizacion is null"
        Shared sqlListaLineasTickets = "select * from lineas_ticket where lineas_ticket.ticket_id =  ?"
        Shared sqlLineasTicketInvalidas = "" _
    & " SELECT count(*) " _
    & " FROM " _
    & " lineas_ticket " _
    & " WHERE " _
    & " (lineas_ticket.contrato_id IS NULL  or lineas_ticket.precio is null)  " _
    & " and lineas_ticket.ticket_id =  ? "

        Public Function contabilizarTicket(ByVal ticket_id As Integer, ByVal validar As Boolean)
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            cmd.Parameters.Clear()
            Dim ticket_idParam As New Odbc.OdbcParameter("@ticket_id", ticket_id)
            cmd.Parameters.Add(ticket_idParam)
            Try
                Dim ninvalidas As Integer = ExecuteScalar(cmd, sqlLineasTicketInvalidas)
                Dim dlin As DataTableReader = getDataTable(cmd, sqlListaLineasTickets)
                If ninvalidas = 0 And dlin.HasRows Then
                    'todas las lineas del ticket tienen precio y hay almenos una linea en el ticket
                    Dim datos As DataSet = getDataSet(cmd, sqlCabeceraTicket)

                    If datos.Tables(0).Rows.Count = 1 Then

                        Dim reserva_id = datos.Tables(0).Rows(0).Item("reserva_id")
                        Dim crearfac As Boolean = datos.Tables(0).Rows(0).Item("serie_id") = 4 Or Not IsDBNull(datos.Tables(0).Rows(0).Item("forma_pago_id"))
                        If (crearfac) Or (Not crearfac And Not IsDBNull(reserva_id)) Then
                            If Not validar Then
                                'TODO crear cabecera factura si no se paga por reserva

                                Dim fac As Factura
                                If Not crearfac Then
                                    'se paga por reserva
                                    'todo crear lineas de factura contra la reserva
                                    fac = abreFactura(cmd, -1, reserva_id)
                                    fac.factura_id = Nothing
                                Else
                                    Dim fpagoid As Integer = 1
                                    If Not datos.Tables(0).Rows(0).IsNull("forma_pago_id") Then
                                        fpagoid = datos.Tables(0).Rows(0)("forma_pago_id")
                                    End If
                                    fac = preparaFactura(cmd, -1, datos.Tables(0).Rows(0).Item("cliente_id"), fpagoid, datos.Tables(0).Rows(0).Item("fecha"), datos.Tables(0).Rows(0).Item("hotel_id"), datos.Tables(0).Rows(0).Item("serie_id"))
                                End If
                                'TODO crear lineas de facturas
                                Dim tipolinea As String = "M"
                                Dim tipocobro As Integer = 1
                                Dim empieza As Integer = 1
                                If datos.Tables(0).Rows(0).Item("serie_id") = 4 Then
                                    tipolinea = "D"
                                    tipocobro = 3
                                    'empieza es zero si tipo cobro es deposito y es contra reserva
                                    If Not IsDBNull(reserva_id) Then
                                        empieza = 0
                                    End If

                                End If
                                While dlin.Read
                                    Dim x As Integer
                                    Dim num As Integer = 0
                                    For x = empieza To 1
                                        Dim row As DataRow = agregaLineaFactura(fac)
                                        row.Item("fecha") = datos.Tables(0).Rows(0).Item("fecha")
                                        row.Item("reserva_id") = reserva_id
                                        If fac.factura_id = 0 Or num = 1 Then
                                            row.Item("factura_id") = System.DBNull.Value
                                        Else
                                            row.Item("factura_id") = fac.factura_id
                                        End If
                                        row.Item("contrato_id") = dlin.Item("contrato_id")
                                        row.Item("descripcion") = dlin.Item("descripcion")
                                        If num = 1 Then
                                            row.Item("cantidad") = -dlin.Item("cantidad")
                                        Else
                                            row.Item("cantidad") = dlin.Item("cantidad")
                                        End If
                                        row.Item("hotel_id") = datos.Tables(0).Rows(0).Item("hotel_id")
                                        row.Item("precio") = dlin.Item("precio")
                                        row.Item("precio_produccion") = dlin.Item("precio")
                                        row.Item("impuesto_id") = dlin.Item("impuesto_id")
                                        row.Item("porc_impuesto") = dlin.Item("porc_impuesto")
                                        row.Item("servicio_id") = dlin.Item("servicio_id")
                                        row.Item("unidad_calculo_id") = dlin.Item("unidad_calculo_id")
                                        row.Item("tipo_linea_factura") = tipolinea 'M o D
                                        num += 1
                                    Next
                                End While
                                actualizarLineas(fac)
                                'todo actualizar factura
                                Dim pudoactualizar As Boolean = False
                                Dim pudoactualizarcobro As Boolean = False
                                If crearfac Then
                                    pudoactualizar = CambiarEstadoFactura(cmd, fac.factura_id, 1, False)
                                    If pudoactualizar Then
                                        'todo cobrar factura
                                        Dim cobro_id As Integer = CrearCobro(cmd, tipocobro, fac.factura_id, datos.Tables(0).Rows(0).Item("caja_id"))
                                        If cobro_id > 0 Then
                                            pudoactualizarcobro = CambiarEstadoCobro(cmd, cobro_id, 1, False)
                                            If pudoactualizarcobro Then
                                                'todo correcto
                                            Else
                                                'no se pudo actualizar el cobro
                                                AgregaInfo("ContabilizarTicket", "No se puede actualizar el cobro para el ticket:" & ticket_id, -1)
                                            End If
                                        Else
                                            'no se pudo crear cobro
                                            AgregaInfo("ContabilizarTicket", "No se puede crear cobro para el ticket:" & ticket_id, -1)
                                        End If
                                    Else
                                        'no se pudo actualizar la factura
                                        AgregaInfo("ContabilizarTicket", "No se puede actualizar la facutura para el ticket:" & ticket_id, -1)
                                    End If
                                Else
                                    pudoactualizar = True
                                    pudoactualizarcobro = True
                                End If
                                If pudoactualizar And pudoactualizarcobro Then
                                    If fac.factura_id = 0 Then
                                        datos.Tables(0).Rows(0).Item("factura_id") = System.DBNull.Value
                                    Else
                                        datos.Tables(0).Rows(0).Item("factura_id") = fac.factura_id
                                    End If

                                    datos.Tables(0).Rows(0).Item("fecha_contabilizacion") = Now
                                    datos.Tables(0).Rows(0).Item("user_id") = userId
                                    datos.Tables(0).Rows(0).Item("fecha_actualizacion") = Now
                                    datos.Tables(0).Rows(0).Item("estado_ticket_id") = 2
                                    Dim writer As Odbc.OdbcDataAdapter
                                    writer = getDataAdapter(cmd, sqlCabeceraTicket)
                                    writer.Fill(datos.Tables(0))
                                    writer.Update(datos.Tables(0))
                                    retVal = True
                                End If
                            Else
                                'TODO comprobar que caja no esta cerrada solo si forma de pago distinto a reserva
                                If Not IsDBNull(datos.Tables(0).Rows(0).Item("forma_pago_id")) Then
                                    If EstaCajaAbierta(cmd, datos.Tables(0).Rows(0).Item("caja_id"), datos.Tables(0).Rows(0).Item("fecha")) Then
                                        retVal = True
                                    Else
                                        retVal = False
                                        AgregaInfo("ContabilizarTicket", "La caja del ticket esta cerrada:" & ticket_id, -1)
                                        'caja esta cerrada
                                    End If
                                Else
                                    'todo comprobar ke tenga una reserv
                                    If IsDBNull(reserva_id) Then
                                        retVal = False
                                        AgregaInfo("ContabilizarTicket", "Se necesita una reserva valida en el ticket:" & ticket_id, -1)
                                    Else
                                        'comprobar que reserva sea valida para asignarle el ticket
                                        If CambiarEstadoReserva(cmd, reserva_id, 4, True) = 0 Then
                                            retVal = True
                                        Else
                                            retVal = False
                                            AgregaInfo("ContabilizarTicket", "Se necesita una reserva valida en el ticket:" & ticket_id, -1)
                                        End If
                                    End If

                                End If
                            End If
                        Else
                            'falta reserva_id?
                        End If
                    End If
                Else
                    retVal = False  'por ke?
                End If
            Catch
                errorCode = 1
                AgregaInfo("ContabilizarTicket", "Error al contablizar el ticket:" & ticket_id, -1)

            End Try
            If Not flushConection(cmd, errorCode) Then
                retVal = False
            End If

            Return retVal
        End Function
        Public Function crearLineasFacturas(ByVal reserva_id As Integer, ByVal servicio_id As Integer, ByVal unidad_calculo_id As Integer, ByVal cantidad As Single, Optional ByVal fecha_desde As Object = Nothing, Optional ByVal fecha_hasta As Object = Nothing)

            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim resultado As tablaServicios = Nothing
            Try
                'obtiene datos de la reserva
                Dim ds As DataSet = preparaDatasetReserva(cmd, reserva_id)
                'vacio lineas antiguas

                ds.Tables("reservas_servicios").Clear()
                ds.Tables("reservas_contratos").Clear()
                ds.Tables("reservas_ofertas").Clear()
                ds.Tables("reservas_ofertas_subclone").Clear()
                ds.Tables("reservas_descuentos").Clear()

                Dim dr As DataRow = ds.Tables("reservas_servicios").Rows.Add
                dr("servicio_reserva_id") = 1
                dr("reserva_id") = reserva_id
                dr("servicio_id") = servicio_id
                dr("unidad_calculo_id") = unidad_calculo_id
                dr("cantidad") = cantidad
                If IsNothing(fecha_desde) Then
                    fecha_desde = ds.Tables("reserva").Rows(0)("fecha_prevista_llegada")
                End If
                Dim fh As Date = FechaHotel(cmd, ds.Tables("reserva").Rows(0)("hotel_id"))
                If fecha_desde < fh Then
                    fecha_desde = fh
                End If
                If IsNothing(fecha_hasta) Then
                    fecha_hasta = ds.Tables("reserva").Rows(0)("fecha_prevista_salida")
                End If
                If fecha_hasta > ds.Tables("reserva").Rows(0)("fecha_prevista_salida") Then
                    'Console.Write(DateDiff(DateInterval.Day, ds.Tables("reserva").Rows(0)("fecha_prevista_salida"), fecha_hasta))
                    If fecha_desde <> fh Or DateDiff(DateInterval.Day, ds.Tables("reserva").Rows(0)("fecha_prevista_salida"), fecha_hasta) > 1 Then
                        fecha_hasta = ds.Tables("reserva").Rows(0)("fecha_prevista_salida")
                    End If

                End If
                ds.Tables("reserva").Rows(0)("fecha_prevista_salida") = fecha_hasta
                ds.Tables("reserva").Rows(0)("fecha_salida") = fecha_hasta
                dr("fecha_desde") = fecha_desde
                dr("fecha_hasta") = fecha_hasta
                dr("flag_contrato") = 0
                dr("servicio_extra") = 1

                'todo asignar en reservas_servicios la linea


                ds.Tables("reserva").Rows(0)("estado_reserva_id") = 0 'desbloquea reserva
                ds.Tables("reservas_contratos").Clear() 'limppia contratos
                ds.Tables("reservas_ofertas").Clear() 'limppia reservas
                ds.Tables("reservas_ofertas_subclone").Clear()
                'meto linea ficticia
                'obtengo precios
                resultado = obtieneServiciosReserva(cmd, ds, fecha_desde, fecha_hasta, -1)



                'todo lo ke sea menor a la fecha de trabajo hotel..se mueve a fecha trabajo hotel
                'dumpResultado(resultado)
                'inserto lineas
                'cambiar tipo de D a M
                If Not IsNothing(resultado) Then
                    If resultado.servicios.Rows.Count > 0 Then
                        Dim writer As Odbc.OdbcDataAdapter
                        Dim dt As DataTable = ds.Tables("reservas_servicios")
                        Dim x As Integer
                        dt.AcceptChanges()
                        For x = 0 To dt.Rows.Count - 1
                            dt.Rows(x).SetAdded()
                        Next

                        If Not IsNothing(ds.Tables("reservas_servicios").GetChanges) Then
                            cmd.Parameters.Clear()
                            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
                            cmd.Parameters.Add(reserva_idParam)
                            writer = getDataAdapter(cmd, sqlReservasServicios)
                            writer.Fill(ds.Tables("reservas_servicios"))
                            writer.Update(ds.Tables("reservas_servicios"))
                        End If
                        generaAjuste(cmd, reserva_id, resultado, fecha_desde, True, True, "M")
                    Else
                        errorCode = 3
                        AgregaInfo("crearLineasFacturas", "No hay lineas que generar:" & reserva_id, -errorCode)
                    End If
                Else
                    errorCode = 2
                    AgregaInfo("crearLineasFacturas", "No hay nada que generar:" & reserva_id, -errorCode)
                End If

            Catch ex As Exception
                errorCode = 1
                AgregaInfo("crearLineasFacturas", "No se puede calcular los servicios de la reserva:" & reserva_id, -errorCode)

            End Try
            If Not flushConection(cmd, errorCode) Then
                resultado = Nothing
            End If
            Return resultado


        End Function
        Private Function obtieneServicioPorDia(ByVal cmd As Odbc.OdbcCommand, ByVal contrato_id As Integer, ByVal servicio As Integer, ByVal unidad_calculo_id As Integer, ByVal cantidad As Integer, ByVal fecha As Date, ByVal porcimpuesto As Decimal) As tablaServicios
            Dim errorCode As Integer = 0
            Dim resultado As tablaServicios = Nothing

            If Not IsDBNull(contrato_id) Then
                'TODO obtiene las lineas ke genera esa reserva
                Dim ucHijas As DataSet = obtieneUCHijas(cmd)
                resultado = obtieneTablaServicioContrato(cmd, ucHijas, contrato_id, servicio, unidad_calculo_id, "", cantidad, fecha, fecha.AddDays(1), 0, Nothing, porcimpuesto)
                If Not IsNothing(resultado) Then
                    If resultado.servicios.Rows.Count > 1 Then
                        'TODO agrupa y suma si hay mas de una fila
                    End If
                    '                Console.WriteLine(x.servicios.Rows(0).Item("descripcion"))
                End If

            Else
                errorCode = 1 'no hay contrato activo
                AgregaInfo("obtieneServicioPorDia", "No hay contrato activo:" & contrato_id, -errorCode)
            End If



            If errorCode <> 0 Then
                resultado = Nothing
            Else
            End If

            Return resultado

        End Function
        Shared sqlComprobarOfertas = "" _
& " SELECT DISTINCT reservas_ofertas.reserva_id,reservas.estado_reserva_id,contratos.cliente_id,clientes.razon " _
& " /* " _
& " group_concat(DISTINCT " _
& " convert (reservas_ofertas.reserva_id, char)) " _
& " */ " _
& " FROM reservas Inner Join reservas_ofertas ON reservas_ofertas.reserva_id = reservas.reserva_id " _
& " Inner Join ofertas ON reservas_ofertas.oferta_id = ofertas.oferta_id " _
& " Inner Join contratos ON ofertas.contrato_id = contratos.contrato_id " _
& " inner join clientes on clientes.cliente_id=contratos.cliente_id" _
& " WHERE " _
& " reservas.estado_reserva_id IN  (1,3,4,5) AND " _
& " ofertas.tipo_oferta_id IN  (14, 15) AND " _
& " reservas_ofertas.activa =  '1' "

        Public Function PruebaOfertas()
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim reader As DataTableReader = Me.getDataTable(cmd, sqlComprobarOfertas)
            While reader.Read
                'If reader("reserva_id") = 5126 Then
                'sqlOfertasContratos = sqlOfertasContratosOld
                'End If

                sqlOfertasContratos = sqlOfertasContratosOld

                Dim ds As DataSet = preparaDatasetReserva(cmd, reader("reserva_id"))
                Dim imp As Single = obtieneServiciosReserva(cmd, ds, Nothing, Nothing).sumaImporte()

                'Dim imp As Single = obtieneImporteTotalReserva(reader("reserva_id"))
                flushCache()

                sqlOfertasContratos = sqlOfertasContratosNew
                Dim dsn As DataSet = preparaDatasetReserva(cmd, reader("reserva_id"))
                Dim impnew As Single = obtieneServiciosReserva(cmd, dsn, Nothing, Nothing).sumaImporte()

                'Dim impnew As Single = obtieneImporteTotalReserva(reader("reserva_id"))
                If imp <> impnew Then
                    Console.WriteLine(reader("razon") & "-" & reader("reserva_id") & "-" & reader("estado_reserva_id") & "-" & imp & "-" & impnew & "-")
                End If
                flushCache()
            End While
            flushConection(cmd, errorCode)
        End Function
        Shared sqlReservasOfertas = "select * from reservas_ofertas where reserva_id=?"
        'Dim sqlOfertasContratos = "select * from ofertas where  contrato_id in (?)"
        Shared sqlOfertaCodigos = "select ofertas_codigos.* from ofertas inner join ofertas_codigos on ofertas.oferta_id=ofertas_codigos.oferta_id where ofertas.contrato_id in (?)"

        Shared sqlOfertasContratos = "" _
    & " SELECT ofertas.*,ifnull(ofertas.orden_aplicacion,tipos_de_oferta.orden_aplicacion) as super_orden_aplicacion FROM ofertas " _
    & " Inner Join tipos_de_oferta ON ofertas.tipo_oferta_id = tipos_de_oferta.tipo_oferta_id " _
    & " where  contrato_id in (?) " _
    & " order by super_orden_aplicacion asc,ofertas.oferta_id "

        Public sqlOfertasContratosOld = "" _
    & " SELECT ofertas.* FROM ofertas " _
    & " Inner Join tipos_de_oferta ON ofertas.tipo_oferta_id = tipos_de_oferta.tipo_oferta_id " _
    & " where  contrato_id in (?) " _
    & " order by tipos_de_oferta.orden_aplicacion asc "

        Public sqlOfertasContratosNew = "" _
    & " SELECT ofertas.* FROM ofertas " _
    & " Inner Join tipos_de_oferta ON ofertas.tipo_oferta_id = tipos_de_oferta.tipo_oferta_id " _
    & " where  contrato_id in (?) " _
    & " order by tipos_de_oferta.orden_aplicacion asc,ofertas.oferta_id "

        Shared sqlOfertasRejilla = "select * from ofertas_rejillas where oferta_id=?"
        Shared sqlOfertasRejillaContratos = "select ofertas_rejillas.* from ofertas inner join ofertas_rejillas on ofertas.oferta_id=ofertas_rejillas.oferta_id where ofertas.contrato_id in (?)"
        Shared sqlOfertasServiciosAdicionalesContratos = "select ofertas_servicios.* from ofertas inner join ofertas_servicios on ofertas.oferta_id=ofertas_servicios.oferta_id where ofertas.contrato_id in (?)"
        Shared sqlOfertasServiciosAdicionales = "select * from ofertas_servicios where oferta_id=?"
        Shared sqlCuentaOfertas = "" _
    & " SELECT distinct reservas.reserva_id" _
    & " FROM " _
    & " reservas_ofertas " _
    & " Inner Join reservas ON reservas_ofertas.reserva_id = reservas.reserva_id " _
    & " WHERE " _
    & " reservas.estado_reserva_id in (1,3) AND " _
    & " reservas_ofertas.activa =  1 AND " _
    & " reservas_ofertas.oferta_id =  ? "

        'aplicable_auto=1 and
        Private Function compactarServicios(ByVal servicios_adicionales As DataTable, ByVal paso As Integer)
            Dim rows() As DataRow
            Dim x As Integer
            Dim y As Integer



            rows = servicios_adicionales.Select("", "servicio_id,unidad_calculo_id,cantidad,fecha_desde")
            Dim toinc As New Hashtable
            For x = 0 To rows.Length - 1
                If Not rows(x).RowState = DataRowState.Detached Then
                    For y = x + 1 To rows.Length - 1
                        If Not rows(y).RowState = DataRowState.Detached Then
                            If rows(y)("precio_servicio").Equals(rows(x)("precio_servicio")) And rows(y)("cantidad") = rows(x)("cantidad") And rows(y)("unidad_calculo_id") = rows(x)("unidad_calculo_id") And rows(y)("servicio_id") = rows(x)("servicio_id") Then
                                If Not rows(y).IsNull("fecha_desde") And Not rows(x).IsNull("fecha_hasta") Then
                                    If rows(y)("fecha_desde") = CDate(rows(x)("fecha_hasta")).AddDays(1) Then
                                        rows(x)("fecha_hasta") = rows(y)("fecha_hasta")
                                        rows(y).Delete()
                                        toinc(x) = rows(x)
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
            Next
            If paso < 0 Then
                Dim iter As IEnumerator = toinc.Values.GetEnumerator
                While iter.MoveNext
                    Dim row As DataRow = iter.Current
                    row("fecha_hasta") = CDate(row("fecha_hasta")).AddDays(1)
                End While
            End If
            servicios_adicionales.AcceptChanges()
            'sumar servicios iguales
            rows = servicios_adicionales.Select("", "servicio_id,unidad_calculo_id,cantidad,fecha_desde")
            For x = 0 To rows.Length - 1
                If Not rows(x).RowState = DataRowState.Detached Then
                    For y = x + 1 To rows.Length - 1
                        If Not rows(y).RowState = DataRowState.Detached Then
                            If rows(y)("precio_servicio").Equals(rows(x)("precio_servicio")) And rows(y)("unidad_calculo_id") = rows(x)("unidad_calculo_id") And rows(y)("servicio_id") = rows(x)("servicio_id") Then
                                If rows(y).IsNull("fecha_desde") And rows(x).IsNull("fecha_desde") And rows(y).IsNull("fecha_hasta") And rows(x).IsNull("fecha_hasta") Then
                                    rows(x)("cantidad") += rows(y)("cantidad")
                                    rows(y).Delete()
                                End If
                            End If
                        End If
                    Next
                End If
            Next
            'servicios fecha desde=fecha hasta
            'incrementar un dia la fecha hasta
            servicios_adicionales.AcceptChanges()
            'sumar servicios iguales
            rows = servicios_adicionales.Select("", "servicio_id,unidad_calculo_id,cantidad,fecha_desde")
            For x = 0 To rows.Length - 1
                If Not rows(x).RowState = DataRowState.Detached Then
                    If Not rows(x).IsNull("fecha_desde") And Not rows(x).IsNull("fecha_hasta") Then
                        If rows(x)("fecha_desde") = rows(x)("fecha_hasta") Then
                            rows(x)("fecha_hasta") = rows(x)("fecha_hasta").addDays(1)
                        End If
                    End If
                End If
            Next
            servicios_adicionales.AcceptChanges()
        End Function
        Shared sqlOfertaTieneCodigo = "select oferta_id from ofertas_codigos where oferta_id=? and codigo_oferta=?"
        Private Function obtieneOfertasReserva(ByVal cmd As Odbc.OdbcCommand, ByVal ds As DataSet, ByVal contratos As ArrayList, ByVal resultado As tablaServicios, Optional ByVal ucs As DataSet = Nothing, Optional ByVal paso As Integer = 0) As DataTable
            Dim datos As DataTable = ds.Tables("reservas_ofertas")  'getDataSet(cmd, sqlReservasOfertas)
            Dim quitardatos As Boolean = False
            'TODO filtrar solo las ofertas que se podrian aplicar
            Dim ofertasUsadas As Hashtable
            If IsNothing(resultado.ofertasUsadas) Then
                resultado.ofertasUsadas = New Hashtable
            End If
            ofertasUsadas = resultado.ofertasUsadas
            Dim clon_reservas_servicios As DataTable
            If contratos.Count <> 0 Then
                clon_reservas_servicios = ds.Tables("reservas_servicios").Clone()
                clon_reservas_servicios.Clear()

                Dim ucHijas As DataSet = ucs
                If ucHijas Is Nothing Then
                    ucHijas = obtieneUCSReserva(cmd, ds)
                End If
                Dim fecha_hotel As Date = FechaHotel(cmd, ds.Tables("reserva").Rows(0)("hotel_id"))
                'cmd.Parameters.Clear()
                'Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
                'cmd.Parameters.Add(reserva_idParam)
                Dim servicios As DataTable = resultado.servicios
                servicios.Columns("ambito_id").ColumnName = "ambito_id1"
                servicios.Columns("tipo").ColumnName = "tipo1"
                servicios.Columns("grupo").ColumnName = "grupo1"
                servicios.Columns("uc").ColumnName = "uc1"
                servicios.Columns("ucid").ColumnName = "ucid1"
                servicios.Columns("tipo_oferta_id").ColumnName = "tipo_oferta_id1"
                servicios.Columns("n").ColumnName = "n1"
                servicios.Columns("m").ColumnName = "m1"
                servicios.Columns("impuesto_incluido").ColumnName = "impuesto_incluido1"

                servicios.Columns.Add("ambito_id", System.Type.GetType("System.Int32"), "")
                servicios.Columns.Add("tipo", System.Type.GetType("System.Int32"), "")
                'servicios.Columns.Add("grupo", System.Type.GetType("System.Int32"), "")
                servicios.Columns.Add("grupo", System.Type.GetType("System.String"), "")
                servicios.Columns.Add("uc", System.Type.GetType("System.Int32"), "")
                servicios.Columns.Add("ucid", System.Type.GetType("System.Int32"), "")
                servicios.Columns.Add("tipo_oferta_id", System.Type.GetType("System.Int32"), "")
                servicios.Columns.Add("n", System.Type.GetType("System.Double"), "")
                servicios.Columns.Add("m", System.Type.GetType("System.Double"), "")
                servicios.Columns.Add("impuesto_incluido", System.Type.GetType("System.Int32"), "")

                'TODO obtener las ofertas automaticas posibles
                cmd.Parameters.Clear()
                'Console.WriteLine(Join(contratos.ToArray, ","))
                'Dim contratosParam As New Odbc.OdbcParameter("@contrato_id", Join(contratos.ToArray, ","))
                'cmd.Parameters.Add(contratosParam)

                'Dim ofertas As DataTableReader = getDataTable(cmd, sqlOfertasContratos, True)
                Dim ofertas As DataTableReader = getDataTable(cmd, Replace(sqlOfertasContratos, "?", Join(contratos.ToArray, ",")), True)
                Dim ofertas_codigos As DataTable = getDataSet(cmd, Replace(sqlOfertaCodigos, "?", Join(contratos.ToArray, ",")), True).tables(0)
                Dim dvcondofertas As DataView = New DataView(getDataSet(cmd, Replace(sqlCondicionesOfertasContratos, "?", Join(contratos.ToArray, ",")), True).tables(0))
                Dim dvconofertascodigos As DataView = New DataView(getDataSet(cmd, Replace(sqlOfertasServiciosAdicionalesContratos, "?", Join(contratos.ToArray, ",")), True).tables(0))
                Dim dvconofertasrejilla As DataView = New DataView(getDataSet(cmd, Replace(sqlOfertasRejillaContratos, "?", Join(contratos.ToArray, ",")), True).tables(0))
                'sqlOfertasRejillaContratos
                Dim fecha_salida As Date
                fecha_salida = ds.Tables("reserva").Rows(0)("fecha_prevista_salida")
                If Not ds.Tables("reserva").Rows(0).IsNull("fecha_salida") Then
                    fecha_salida = ds.Tables("reserva").Rows(0)("fecha_salida")
                End If
                If paso >= 0 Then
                    fecha_salida = fecha_salida.AddDays(-1)
                End If
                Dim fecha_llegada As Date
                fecha_llegada = ds.Tables("reserva").Rows(0)("fecha_prevista_llegada")
                If Not ds.Tables("reserva").Rows(0).IsNull("fecha_llegada") Then
                    fecha_llegada = ds.Tables("reserva").Rows(0)("fecha_llegada")
                End If

                Try

                    While ofertas.Read
                        'todo leer la rejilla de esa oferta
                        cmd.Parameters.Clear()
                        'If ofertas.Item("oferta_id") = 126 Then
                        'Dim x = 0
                        'End If
                        'Console.WriteLine(Join(contratos.ToArray, ","))
                        'Dim oferta_idParam As New Odbc.OdbcParameter("@oferta_id", ofertas.Item("oferta_id"))
                        'cmd.Parameters.Add(oferta_idParam)

                        dvconofertasrejilla.RowFilter = "oferta_id=" & ofertas.Item("oferta_id")
                        Dim rejilla As DataTable
                        rejilla = dvconofertasrejilla.ToTable()
                        'dvconofertasrejilla
                        'rejilla = getTable(cmd, sqlOfertasRejilla, True)
                        dvconofertascodigos.RowFilter = "oferta_id=" & ofertas.Item("oferta_id")
                        Dim servicios_adicionales As DataTable
                        servicios_adicionales = dvconofertascodigos.ToTable()
                        'servicios_adicionales = getTable(cmd, sqlOfertasServiciosAdicionales, True)

                        'cuenta lineas
                        Dim filtro As String = "1=1"
                        'todo si oferta es de un contrato tourpoperador..solo aplicar a los no directos
                        'Console.Write(ofertas.Item("contrato_id"))
                        Dim def As Object = resultado.servicios.Compute("min(defecto)", "contrato_id=" & ofertas.Item("contrato_id"))
                        If Not IsDBNull(def) Then
                            If def = 0 Then
                                def = 0
                            End If
                            filtro &= " and defecto=" & def
                        End If


                        'javier.nunez.casanovas:  días de antelación es número de días entre fecha de llegada y fecha de reserva
                        If Not IsDBNull(ofertas.Item("dias_de_antelacion")) Then
                            filtro &= " and dias_antelacion>=" & ofertas.Item("dias_de_antelacion")
                        End If
                        'todo dias minimos estancia
                        If Not IsDBNull(ofertas.Item("estancia_minima_dias")) Then
                            filtro &= " and dias_estancia>=" & ofertas.Item("estancia_minima_dias")
                        End If
                        'todo añadir fechas en el filtro
                        'fecha_reserva
                        If Not IsDBNull(ofertas.Item("fecha_reserva_desde")) Then
                            filtro &= " and fecha_reserva>='" & ofertas.Item("fecha_reserva_desde") & " '"
                        End If
                        If Not IsDBNull(ofertas.Item("fecha_reserva_hasta")) Then
                            filtro &= " and fecha_reserva<='" & ofertas.Item("fecha_reserva_hasta") & " '"
                        End If
                        Dim campofecha As String = "fecha"
                        If ofertas.Item("tipo_aplicacion_oferta_id") = "L" Then
                            campofecha = "fecha_llegada"
                        End If
                        If Not IsDBNull(ofertas.Item("fecha_desde")) Then
                            filtro &= " and " & campofecha & ">='" & ofertas.Item("fecha_desde") & " '"
                        End If
                        If Not IsDBNull(ofertas.Item("fecha_hasta")) Then
                            filtro &= " and " & campofecha & "<='" & ofertas.Item("fecha_hasta") & " '"
                        End If
                        If Not IsDBNull(ofertas.Item("unidad_calculo_id")) Then
                            'si es un uc que contiene..subdividir
                            'de donde leo? cachedUCHijas
                            Dim z As String
                            z = Join(obtieneUCHijas(cmd, ofertas.Item("unidad_calculo_id")).ToArray, ",")
                            filtro &= " and ucid1 in (" & z & " )"
                        End If
                        If Not IsDBNull(ofertas.Item("servicio_id")) Then
                            filtro &= " and servicio_id=" & ofertas.Item("servicio_id")
                        End If
                        If Not IsDBNull(ofertas.Item("tipo_servicio_id")) Then
                            filtro &= " and tipo_servicio_id=" & ofertas.Item("tipo_servicio_id")
                        End If
                        'todo por tipo de contrato?
                        Dim filasACambiar As DataRow()
                        'todo obtener filas que podrian cambiar con esta oferta en vez del numero
                        'Console.Write(filtro & "-")
                        If Not IsDBNull(ofertas.Item("servicio_ligado_id")) Then
                            'obtener numero servicios ke koincidan
                            Dim nregs As Object = resultado.servicios.Compute("count(servicio_id)", "servicio_id=" & ofertas.Item("servicio_ligado_id"))
                            If IsDBNull(nregs) Then
                                nregs = 0
                            End If
                            If nregs = 0 Then
                                filtro &= " and 1=0"
                            End If
                        End If


                        filasACambiar = resultado.servicios.Select(filtro)
                        'Console.WriteLine(filtro)
                        Dim filaOferta As DataRow() = datos.Select("oferta_id=" & ofertas.Item("oferta_id"))
                        Dim tiene_codigo As Boolean
                        Dim sin_codigos As Boolean
                        tiene_codigo = ofertas_codigos.Select("oferta_id=" & ofertas.Item("oferta_id") & " and codigo_oferta='" & ds.Tables("reserva").Rows(0)("codigo_oferta") & "'").Length > 0
                        sin_codigos = ofertas_codigos.Select("oferta_id=" & ofertas.Item("oferta_id")).Length = 0

                        If filasACambiar.Length > 0 Then
                            'existen servicios con esas combinaciones
                            Dim nueva = False
                            Dim encupo As Boolean = False
                            If Not IsDBNull(ofertas.Item("cupo_oferta")) Then
                                'TODO:si tiene cupo,contar cuantas veces esta esa oferta activa
                                'en reservas checkin ...solo si reserva entra en fecha_hotel?
                                Dim oferta_idParam As New Odbc.OdbcParameter("@oferta_id", ofertas.Item("oferta_id"))
                                cmd.Parameters.Add(oferta_idParam)

                                Dim cupo As Integer = ofertas.Item("cupo_oferta")
                                Dim ofertasds As DataSet = getDataSet(cmd, sqlCuentaOfertas)

                                Dim nofertas = ofertasds.Tables(0).Compute("count(reserva_id)", "reserva_id not in (" & ds.Tables("reserva").Rows(0)("reserva_id") & ")")
                                If IsNothing(nofertas) Then
                                    nofertas = 0
                                End If
                                If nofertas >= cupo Or ds.Tables("reserva").Rows(0)("fecha_prevista_llegada") <> fecha_hotel Then
                                    'If filaOferta.Length = 1 Then
                                    'Dim row As DataRow = filaOferta(0)
                                    'row.Item("tipo") = "M"
                                    'row.Item("activa") = 0
                                    'End If
                                    encupo = False
                                Else
                                    If filaOferta.Length = 1 Then
                                        Dim row As DataRow = filaOferta(0)
                                        row.Item("tipo") = "A"
                                        row.Item("activa") = 1
                                    End If
                                    encupo = True
                                End If
                            End If

                            If filaOferta.Length = 0 Then
                                'no existe asi ke creamos la fila
                                'siempre que la reserva no este blokeada
                                Dim row As DataRow = datos.Rows.Add()
                                row.Item("oferta_id") = ofertas.Item("oferta_id")
                                row.Item("reserva_id") = ds.Tables("reserva").Rows(0)("reserva_id")
                                If ofertas.Item("aplicable_auto") = 1 Or encupo Then
                                    row.Item("tipo") = "A"
                                    row.Item("activa") = 1
                                Else
                                    row.Item("tipo") = "M"
                                    row.Item("activa") = 0
                                End If
                                'si oferta tiene ese codigo...auto activarla
                                If tiene_codigo Then
                                    row.Item("activa") = 1
                                End If

                                nueva = True
                            Else
                                'auto activar las filas cuyo codigo coincida
                                If tiene_codigo Then
                                    Dim x As Integer
                                    Dim z As Integer = filaOferta.Length - 1
                                    For x = 0 To z
                                        filaOferta(x)("activa") = 1
                                    Next
                                End If
                                filaOferta(0)("oferta_usada") = 0
                            End If
                            ofertasUsadas(ofertas.Item("oferta_id")) = ofertas.Item("oferta_id")
                        Else
                            'no existe...borrar si existia en reservas_ofertas
                            'siempre que la reserva no este blokeada
                            If filaOferta.Length <> 0 Then
                                filaOferta(0).Delete()
                            Else
                                'ofertasUsadas(ofertas.Item("oferta_id")) = ofertas.Item("oferta_id")
                            End If
                        End If
                        filaOferta = datos.Select("activa=1 and oferta_id=" & ofertas.Item("oferta_id"))
                        'todo comprobar que cumple las condiciones
                        Dim cumple As Boolean
                        'cumple = cumpleCondicionesOfertas(cmd, ofertas.Item("oferta_id"), ucHijas)
                        dvcondofertas.RowFilter = "oferta_id=" & ofertas.Item("oferta_id")
                        cumple = cumpleCondiciones(dvcondofertas.ToTable.CreateDataReader, ucHijas)
                        '//x
                        If cumple And filaOferta.Length > 0 Then
                            ofertasUsadas(ofertas.Item("oferta_id")) = ofertas.Item("oferta_id")
                            filaOferta(0)("oferta_usada") = 0
                            If sin_codigos Or tiene_codigo Then


                                'TODO aplicar oferta a todas esas filas
                                'siempre que exista en reservas_ofertas

                                'cambio estructura tabla
                                'chapu cambiar por parametro a la llamada funcion

                                'resetear todas las filas
                                'todo cambiar a al otro loop
                                Dim enu As IEnumerator
                                enu = servicios.Rows.GetEnumerator()
                                While enu.MoveNext
                                    Dim row As DataRow = enu.Current
                                    With row
                                        .Item("tipo") = DBNull.Value
                                        .Item("grupo") = DBNull.Value
                                        .Item("uc") = DBNull.Value
                                        .Item("ucid") = DBNull.Value
                                        .Item("tipo_oferta_id") = DBNull.Value
                                        .Item("n") = DBNull.Value
                                        .Item("m") = DBNull.Value
                                        .Item("impuesto_incluido") = DBNull.Value
                                    End With
                                End While



                                '                filasACambiar = servicios.Select(filtro)
                                enu = filasACambiar.GetEnumerator()
                                Dim impuesto_incluido As Boolean = ofertas.Item("impuesto_incluido")
                                While enu.MoveNext
                                    'todo solo elegir fechas que esten dentro de la oferta
                                    Dim row As DataRow = enu.Current
                                    If paso <= 0 And servicios_adicionales.Rows.Count > 0 Then
                                        Dim clon_x As Integer
                                        For clon_x = 0 To servicios_adicionales.Rows.Count - 1
                                            Dim servicio_comp = servicios_adicionales.Rows(clon_x)("servico_id_existe")
                                            If IsDBNull(servicio_comp) Then
                                                servicio_comp = 0
                                            End If
                                            If servicio_comp = 0 Or servicio_comp = row("servicio_id") Then
                                                'Console.WriteLine(servicio_comp & "-" & row("servicio_id"))
                                                Dim clon_row As DataRow = clon_reservas_servicios.Rows.Add
                                                clon_row("servicio_id") = servicios_adicionales.Rows(clon_x)("servicio_id")
                                                If paso < 0 Then
                                                    clon_row("flag_contrato") = 0
                                                Else
                                                    clon_row("flag_contrato") = 1
                                                End If

                                                clon_row("reserva_id") = ds.Tables("reserva").Rows(0)("reserva_id")
                                                clon_row("servicio_reserva_id") = clon_x + 1
                                                clon_row("unidad_calculo_id") = row("ucid1")
                                                clon_row("cantidad") = row("cantidad")
                                                If paso >= 0 And row("fecha") = fecha_llegada Then
                                                    clon_row("fecha_desde") = fecha_llegada
                                                Else
                                                    clon_row("fecha_desde") = row("fecha")
                                                End If
                                                If paso >= 0 And row("fecha") = fecha_salida Then
                                                    clon_row("fecha_hasta") = fecha_salida
                                                Else
                                                    'If paso < 0 Then
                                                    'clon_row("fecha_hasta") = CDate(row("fecha")).AddDays(1)
                                                    'Else
                                                    clon_row("fecha_hasta") = row("fecha") 'CDate(row("fecha")).AddDays(1)
                                                    'End If
                                                End If
                                                If Not servicios_adicionales.Rows(clon_x).IsNull("precio") Then
                                                    clon_row("precio_servicio") = servicios_adicionales.Rows(clon_x)("precio")
                                                End If
                                                clon_row("servicio_extra") = 1
                                                If Not servicios_adicionales.Rows(clon_x).IsNull("unidad_calculo_id") Then
                                                    clon_row("unidad_calculo_id") = servicios_adicionales.Rows(clon_x)("unidad_calculo_id")
                                                End If
                                                If Not servicios_adicionales.Rows(clon_x).IsNull("cantidad") Then
                                                    clon_row("cantidad") = servicios_adicionales.Rows(clon_x)("cantidad")
                                                End If
                                            End If
                                        Next


                                    End If

                                    If Not IsDBNull(ofertas.Item("precio")) Then
                                        'posible problema con tipos distinto de diario!
                                        row.Item("precio") = ofertas.Item("precio")
                                        row.Item("importe") = row.Item("cantidad") * row.Item("precio")
                                    End If
                                    row.Item("tipo") = ofertas.Item("tipo_imputacion_id") 'todo leer tipos de oferta 0-diario,1-llegada,2-salida
                                    'todo crear un grupo ke coincida con esa linea
                                    row.Item("grupo") = row.Item("mgrupo")
                                    'todo revisar
                                    If ofertas.Item("ambito_oferta_id") = 1 Then
                                        row.Item("ambito_id") = 1
                                    Else
                                        row.Item("ambito_id") = 2
                                    End If
                                    row.Item("ucid") = ofertas.Item("unidad_calculo_id")
                                    row.Item("tipo_oferta_id") = ofertas.Item("tipo_oferta_id")
                                    row.Item("n") = ofertas.Item("n")
                                    'si m es euros.y si tiene impuestos incluidos recalcular m
                                    row.Item("m") = ofertas.Item("m")
                                    row.Item("impuesto_incluido") = impuesto_incluido
                                    'todo meter rejilla ofertas
                                    row.Item("rejilla") = rejilla
                                    'row.Item("servicios_adicionales") = servicios_adicionales
                                End While

                                resultado.servicios.AcceptChanges()
                                resultado.recalculaImportePorGrupo()
                                'si tiene cambios es ke la oferta se aplico de algun modo
                                If Not IsNothing(resultado.servicios.GetChanges()) Then
                                    filaOferta(0)("oferta_usada") = 1
                                Else
                                    filaOferta(0)("oferta_usada") = 0
                                End If
                                resultado.servicios.AcceptChanges()
                                'todo agrupar por ucid,fecha,servicio en cada ciclo de ofertas
                                'servicios.AcceptChanges()
                            End If
                        End If
                    End While
                Catch ex As Exception
                    AgregaInfo("obtieneOfertasReserva", "[fallo en oferta=" & ofertas.Item("oferta_id") & "]", -1)

                    Throw New Exception("[fallo en oferta=" & ofertas.Item("oferta_id") & "]", ex)

                End Try

                servicios.Columns.Remove("ambito_id")
                servicios.Columns.Remove("tipo")
                servicios.Columns.Remove("grupo")
                servicios.Columns.Remove("uc")
                servicios.Columns.Remove("ucid")
                servicios.Columns.Remove("tipo_oferta_id")
                servicios.Columns.Remove("n")
                servicios.Columns.Remove("m")

                servicios.Columns("ambito_id1").ColumnName = "ambito_id"
                servicios.Columns("tipo1").ColumnName = "tipo"
                servicios.Columns("grupo1").ColumnName = "grupo"
                servicios.Columns("uc1").ColumnName = "uc"
                servicios.Columns("ucid1").ColumnName = "ucid"
                servicios.Columns("tipo_oferta_id1").ColumnName = "tipo_oferta_id"
                servicios.Columns("n1").ColumnName = "n"
                servicios.Columns("m1").ColumnName = "m"
            Else
                quitardatos = True
            End If
            'si hay servicios adicionales
            Dim tmptable As DataTable = ds.Tables("reservas_servicios")
            If paso <= 0 Then
                If Not IsNothing(clon_reservas_servicios) Then
                    compactarServicios(clon_reservas_servicios, paso)
                End If

                'sincroniza los servicios extras con reservas_servicios

                Dim filtroextras As String
                If paso < 0 Then
                    filtroextras = "servicio_extra=1" ' and flag_contrato=0"
                Else
                    filtroextras = "servicio_extra=1 and flag_contrato=1"
                End If

                Dim rows() As DataRow = tmptable.Select(filtroextras)
                Dim count_clon As Integer = 0
                If Not IsNothing(clon_reservas_servicios) Then
                    count_clon = clon_reservas_servicios.Rows.Count

                End If
                If paso >= 0 Then
                    While rows.Length > count_clon
                        rows(0).Delete()
                        'tmptable.AcceptChanges()
                        rows = tmptable.Select(filtroextras)
                    End While
                End If
                If count_clon > 0 Then
                    Dim posrow As Integer = 0
                    If paso < 0 Then
                        posrow = rows.Length
                        count_clon += rows.Length
                    End If
                    While rows.Length < count_clon
                        tmptable.Rows.Add(clon_reservas_servicios.Rows(0).ItemArray)
                        'tmptable.AcceptChanges()
                        rows = tmptable.Select(filtroextras)
                    End While
                    Dim xrows As Integer
                    For xrows = 0 To count_clon - 1 - posrow
                        Dim xcolumns As Integer
                        For xcolumns = 0 To tmptable.Columns.Count - 1
                            If tmptable.Columns(xcolumns).ColumnName <> "servicio_reserva_id" Then
                                rows(xrows + posrow)(xcolumns) = clon_reservas_servicios.Rows(xrows)(xcolumns)
                            End If
                        Next
                    Next
                End If
            End If
            If Not IsNothing(clon_reservas_servicios) Then
                clon_reservas_servicios.AcceptChanges()
                'todo...agregar servicios a reservas_servicios con flag servicio_extra a 1



                If clon_reservas_servicios.Rows.Count > 0 Then
                    Dim fmin As Object = clon_reservas_servicios.Compute("min(fecha_desde)", "")
                    Dim fmax As Object = clon_reservas_servicios.Compute("max(fecha_hasta)", "")
                    'If paso < 0 And Not IsDBNull(fmax) Then
                    'fmax = CDate(fmax).AddDays(1)
                    'End If
                    ds.Tables.Remove(tmptable)
                    ds.Tables.Add(clon_reservas_servicios)
                    'ds.Tables("reservas_servicios") = clon_reservas_servicios

                    Dim tmptableofertas As DataTable = ds.Tables("reservas_ofertas")
                    Dim clon_reservas_oferta As DataTable = tmptableofertas.Copy()
                    ds.Tables.Remove(tmptableofertas)
                    ds.Tables.Add(clon_reservas_oferta)
                    Dim forzar As Boolean = False
                    If paso = -1 Then
                        forzar = True

                    End If

                    Dim neoser As tablaServicios = obtieneServiciosReserva(cmd, ds, fmin, fmax, 1, forzar)
                    ds.Tables.Remove(clon_reservas_oferta)
                    ds.Tables.Add(tmptableofertas)
                    ds.Tables.Remove(clon_reservas_servicios)
                    ds.Tables.Add(tmptable)
                    If Not IsNothing(neoser) Then
                        'neoser.ofertasUsadas
                        Dim ienu As IEnumerator = neoser.ofertasUsadas.Keys.GetEnumerator()
                        While ienu.MoveNext
                            ofertasUsadas(ienu.Current) = neoser.ofertasUsadas(ienu.Current)
                        End While
                        Dim rowadded() As DataRow = clon_reservas_oferta.Select("", "", DataViewRowState.Added)
                        Dim x As Integer
                        For x = 0 To rowadded.Length - 1
                            If tmptableofertas.Select("oferta_id=" & rowadded(x)("oferta_id"), "").Length = 0 Then
                                'si fue borrada en paso 0...obtener la configuracion en akel momento
                                Dim rowsdel() As DataRow = tmptableofertas.Select("oferta_id=" & rowadded(x)("oferta_id"), "", DataViewRowState.Deleted)
                                If rowsdel.Length > 0 Then
                                    Dim xx As Integer
                                    For xx = 0 To rowsdel.Length - 1
                                        rowsdel(xx).RejectChanges()
                                        'rowsdel(xx)("precio") = rowadded(x)("precio")
                                        'rowsdel(x).SetModified()
                                    Next
                                Else
                                    tmptableofertas.Rows.Add(rowadded(x).ItemArray)
                                End If

                            End If
                        Next
                        Dim dt As DataTable = resultado.servicios.Copy()
                        dt.Merge(neoser.servicios)
                        resultado.servicios = dt
                    End If

                End If
            End If
            'volver a procesar esos servicios contra las ofertas existentes
            'y añadir al resultado global

            Dim arrofertas As String = Join(New ArrayList(ofertasUsadas.Keys).ToArray, ",")
            If IsNothing(arrofertas) Then
                arrofertas = "0"
            End If
            If 1 = 1 Then
                Dim filaOferta As DataRow() = datos.Select(" not oferta_id  in (" & arrofertas & ")")
                If filaOferta.Length > 0 Then
                    Dim x As Integer
                    For x = 0 To filaOferta.Length - 1
                        filaOferta(x).Delete()
                    Next
                End If
            End If



            If quitardatos Then
                Return Nothing
            Else
                Return datos
            End If

        End Function
        Private Function obtieneOfertasReservaOld(ByVal cmd As Odbc.OdbcCommand, ByVal reserva_id As Integer, ByVal contratos As ArrayList, ByVal resultado As tablaServicios, Optional ByVal ucs As DataSet = Nothing) As DataTable
            If contratos.Count = 0 Then
                Return Nothing
            End If


            Dim ucHijas As DataSet = ucs
            If ucHijas Is Nothing Then
                ucHijas = obtieneUCSReserva(cmd, reserva_id)
            End If

            cmd.Parameters.Clear()
            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
            cmd.Parameters.Add(reserva_idParam)


            Dim datos As DataSet = getDataSet(cmd, sqlReservasOfertas)

            Dim servicios As DataTable = resultado.servicios
            servicios.Columns("ambito_id").ColumnName = "ambito_id1"
            servicios.Columns("tipo").ColumnName = "tipo1"
            servicios.Columns("grupo").ColumnName = "grupo1"
            servicios.Columns("uc").ColumnName = "uc1"
            servicios.Columns("ucid").ColumnName = "ucid1"
            servicios.Columns("tipo_oferta_id").ColumnName = "tipo_oferta_id1"
            servicios.Columns("n").ColumnName = "n1"
            servicios.Columns("m").ColumnName = "m1"
            servicios.Columns("impuesto_incluido").ColumnName = "impuesto_incluido1"

            servicios.Columns.Add("ambito_id", System.Type.GetType("System.Int32"), "")
            servicios.Columns.Add("tipo", System.Type.GetType("System.Int32"), "")
            'servicios.Columns.Add("grupo", System.Type.GetType("System.Int32"), "")
            servicios.Columns.Add("grupo", System.Type.GetType("System.String"), "")
            servicios.Columns.Add("uc", System.Type.GetType("System.Int32"), "")
            servicios.Columns.Add("ucid", System.Type.GetType("System.Int32"), "")
            servicios.Columns.Add("tipo_oferta_id", System.Type.GetType("System.Int32"), "")
            servicios.Columns.Add("n", System.Type.GetType("System.Double"), "")
            servicios.Columns.Add("m", System.Type.GetType("System.Double"), "")
            servicios.Columns.Add("impuesto_incluido", System.Type.GetType("System.Int32"), "")

            'TODO obtener las ofertas automaticas posibles
            cmd.Parameters.Clear()
            'Console.WriteLine(Join(contratos.ToArray, ","))
            Dim contratosParam As New Odbc.OdbcParameter("@contrato_id", Join(contratos.ToArray, ","))
            cmd.Parameters.Add(contratosParam)

            Dim ofertas As DataTableReader = getDataTable(cmd, sqlOfertasContratos, True)

            'TODO filtrar solo las ofertas que se podrian aplicar


            While ofertas.Read
                'todo leer la rejilla de esa oferta
                cmd.Parameters.Clear()
                'Console.WriteLine(Join(contratos.ToArray, ","))
                Dim oferta_idParam As New Odbc.OdbcParameter("@oferta_id", ofertas.Item("oferta_id"))
                cmd.Parameters.Add(oferta_idParam)

                Dim rejilla As DataTable = getTable(cmd, sqlOfertasRejilla, True)

                'cuenta lineas
                Dim filtro As String = "1=1"
                'javier.nunez.casanovas:  días de antelación es número de días entre fecha de llegada y fecha de reserva
                If Not IsDBNull(ofertas.Item("dias_de_antelacion")) Then
                    filtro &= " and dias_antelacion>=" & ofertas.Item("dias_de_antelacion")
                End If
                'todo dias minimos estancia
                If Not IsDBNull(ofertas.Item("estancia_minima_dias")) Then
                    filtro &= " and dias_estancia>=" & ofertas.Item("estancia_minima_dias")
                End If
                'todo añadir fechas en el filtro
                'fecha_reserva
                If Not IsDBNull(ofertas.Item("fecha_reserva_desde")) Then
                    filtro &= " and fecha_reserva>='" & ofertas.Item("fecha_reserva_desde") & " '"
                End If
                If Not IsDBNull(ofertas.Item("fecha_reserva_hasta")) Then
                    filtro &= " and fecha_reserva<='" & ofertas.Item("fecha_reserva_hasta") & " '"
                End If
                Dim campofecha As String = "fecha"
                If ofertas.Item("tipo_aplicacion_oferta_id") = "L" Then
                    campofecha = "fecha_llegada"
                End If
                If Not IsDBNull(ofertas.Item("fecha_desde")) Then
                    filtro &= " and " & campofecha & ">='" & ofertas.Item("fecha_desde") & " '"
                End If
                If Not IsDBNull(ofertas.Item("fecha_hasta")) Then
                    filtro &= " and " & campofecha & "<='" & ofertas.Item("fecha_hasta") & " '"
                End If
                If Not IsDBNull(ofertas.Item("unidad_calculo_id")) Then
                    'si es un uc que contiene..subdividir
                    'de donde leo? cachedUCHijas
                    Dim z As String
                    z = Join(obtieneUCHijas(cmd, ofertas.Item("unidad_calculo_id")).ToArray, ",")
                    filtro &= " and ucid1 in (" & z & " )"
                End If
                If Not IsDBNull(ofertas.Item("servicio_id")) Then
                    filtro &= " and servicio_id=" & ofertas.Item("servicio_id")
                End If
                If Not IsDBNull(ofertas.Item("tipo_servicio_id")) Then
                    filtro &= " and tipo_servicio_id=" & ofertas.Item("tipo_servicio_id")
                End If
                Dim filasACambiar As DataRow()
                'todo obtener filas que podrian cambiar con esta oferta en vez del numero
                'Console.Write(filtro & "-")
                filasACambiar = resultado.servicios.Select(filtro)
                'Console.WriteLine(filasACambiar.Length)
                Dim filaOferta As DataRow() = datos.Tables(0).Select("oferta_id=" & ofertas.Item("oferta_id"))
                If filasACambiar.Length > 0 Then
                    'existen servicios con esas combinaciones
                    Dim nueva = False
                    If filaOferta.Length = 0 Then
                        'no existe asi ke creamos la fila
                        'siempre que la reserva no este blokeada
                        Dim row As DataRow = datos.Tables(0).Rows.Add()
                        row.Item("oferta_id") = ofertas.Item("oferta_id")
                        row.Item("reserva_id") = reserva_id
                        If ofertas.Item("aplicable_auto") = 1 Then
                            row.Item("tipo") = "A"
                            row.Item("activa") = 1
                        Else
                            row.Item("tipo") = "M"
                            row.Item("activa") = 0
                        End If
                        nueva = True
                    End If
                Else
                    'no existe...borrar si existia en reservas_ofertas
                    'siempre que la reserva no este blokeada
                    If filaOferta.Length <> 0 Then
                        filaOferta(0).Delete()
                    End If
                End If
                filaOferta = datos.Tables(0).Select("activa=1 and oferta_id=" & ofertas.Item("oferta_id"))
                'todo comprobar que cumple las condiciones
                Dim cumple As Boolean = cumpleCondicionesOfertas(cmd, ofertas.Item("oferta_id"), ucHijas)
                If cumple And filaOferta.Length > 0 Then
                    'TODO aplicar oferta a todas esas filas
                    'siempre que exista en reservas_ofertas

                    'cambio estructura tabla
                    'chapu cambiar por parametro a la llamada funcion

                    'resetear todas las filas
                    'todo cambiar a al otro loop
                    Dim enu As IEnumerator
                    enu = servicios.Rows.GetEnumerator()
                    While enu.MoveNext
                        Dim row As DataRow = enu.Current
                        row.Item("tipo") = DBNull.Value
                        row.Item("grupo") = DBNull.Value
                        row.Item("uc") = DBNull.Value
                        row.Item("ucid") = DBNull.Value
                        row.Item("tipo_oferta_id") = DBNull.Value
                        row.Item("n") = DBNull.Value
                        row.Item("m") = DBNull.Value
                        row.Item("impuesto_incluido") = DBNull.Value
                    End While



                    '                filasACambiar = servicios.Select(filtro)
                    enu = filasACambiar.GetEnumerator()
                    Dim impuesto_incluido As Boolean = ofertas.Item("impuesto_incluido")
                    While enu.MoveNext
                        'todo solo elegir fechas que esten dentro de la oferta
                        Dim row As DataRow = enu.Current
                        If Not IsDBNull(ofertas.Item("precio")) Then
                            row.Item("precio") = ofertas.Item("precio")
                            row.Item("importe") = row.Item("cantidad") * row.Item("precio")
                        End If
                        row.Item("tipo") = 0
                        'todo crear un grupo ke coincida con esa linea
                        row.Item("grupo") = row.Item("mgrupo")
                        'todo revisar
                        If ofertas.Item("ambito_oferta_id") = 1 Then
                            row.Item("ambito_id") = 1
                        Else
                            row.Item("ambito_id") = 2
                        End If
                        row.Item("ucid") = ofertas.Item("unidad_calculo_id")
                        row.Item("tipo_oferta_id") = ofertas.Item("tipo_oferta_id")
                        row.Item("n") = ofertas.Item("n")
                        'si m es euros.y si tiene impuestos incluidos recalcular m
                        row.Item("m") = ofertas.Item("m")
                        row.Item("impuesto_incluido") = impuesto_incluido
                        'todo meter rejilla ofertas
                        row.Item("rejilla") = rejilla
                    End While
                    resultado.recalculaImportePorGrupo()
                    'todo agrupar por ucid,fecha,servicio en cada ciclo de ofertas
                    'servicios.AcceptChanges()
                End If
            End While


            If datos.HasChanges Then
                'TODO actualizar si ha cambiado
                Dim writer As Odbc.OdbcDataAdapter
                writer = getDataAdapter(cmd, sqlReservasOfertas)
                writer.Fill(datos.Tables(0))
                writer.Update(datos.Tables(0))
            End If
            servicios.Columns.Remove("ambito_id")
            servicios.Columns.Remove("tipo")
            servicios.Columns.Remove("grupo")
            servicios.Columns.Remove("uc")
            servicios.Columns.Remove("ucid")
            servicios.Columns.Remove("tipo_oferta_id")
            servicios.Columns.Remove("n")
            servicios.Columns.Remove("m")

            servicios.Columns("ambito_id1").ColumnName = "ambito_id"
            servicios.Columns("tipo1").ColumnName = "tipo"
            servicios.Columns("grupo1").ColumnName = "grupo"
            servicios.Columns("uc1").ColumnName = "uc"
            servicios.Columns("ucid1").ColumnName = "ucid"
            servicios.Columns("tipo_oferta_id1").ColumnName = "tipo_oferta_id"
            servicios.Columns("n1").ColumnName = "n"
            servicios.Columns("m1").ColumnName = "m"
            Return datos.Tables(0)
        End Function
        Shared sqlObtieneImpuestoIncluido = "select impuesto_incluido from contratos where contrato_id=?"
        Shared sqlTablaServicioContrato = "" _
    & " SELECT" _
    & " lineas_de_contrato.*, " _
    & " servicios.nombre_servicio, " _
    & " servicios.tipo_servicio_id," _
    & " tipos_de_oferta.Oferta, " _
    & " unidades_calculo.descripcion_unidad_calculo, " _
    & " frecuencia_facturacion.descripcion as descripcion_frecuencia_id, " _
    & " tipos_de_imputacion.imputacion " _
    & " FROM " _
    & " servicios " _
    & " Left Join lineas_de_contrato ON servicios.servicio_id = lineas_de_contrato.servicio_id and lineas_de_contrato.contrato_id =?" _
    & " Left Join tipos_de_oferta ON lineas_de_contrato.tipo_oferta_id = tipos_de_oferta.tipo_oferta_id " _
    & " Left Join unidades_calculo ON lineas_de_contrato.unidad_calculo_id = unidades_calculo.unidad_calculo_id " _
    & " Left Join frecuencia_facturacion ON lineas_de_contrato.frecuencia_id = frecuencia_facturacion.frecuencia_id " _
    & " Left Join tipos_de_imputacion ON lineas_de_contrato.tipo_imputacion_id = tipos_de_imputacion.tipo_imputacion_id "

        Shared sqlTablaServicioContratoOld = "" _
    & " SELECT" _
    & " lineas_de_contrato.*, " _
    & " servicios.nombre_servicio, " _
    & " servicios.tipo_servicio_id," _
    & " tipos_de_oferta.Oferta, " _
    & " unidades_calculo.descripcion_unidad_calculo, " _
    & " frecuencia_facturacion.descripcion as descripcion_frecuencia_id, " _
    & " tipos_de_imputacion.imputacion " _
    & " FROM " _
    & " servicios " _
    & " Left Join lineas_de_contrato ON servicios.servicio_id = lineas_de_contrato.servicio_id and lineas_de_contrato.contrato_id =?" _
    & " Left Join tipos_de_oferta ON lineas_de_contrato.tipo_oferta_id = tipos_de_oferta.tipo_oferta_id " _
    & " Left Join unidades_calculo ON lineas_de_contrato.unidad_calculo_id = unidades_calculo.unidad_calculo_id " _
    & " Left Join frecuencia_facturacion ON lineas_de_contrato.frecuencia_id = frecuencia_facturacion.frecuencia_id " _
    & " Left Join tipos_de_imputacion ON lineas_de_contrato.tipo_imputacion_id = tipos_de_imputacion.tipo_imputacion_id " _
    & "  WHERE " _
    & " servicios.servicio_id  =  ? "
        Shared camposDias() As String = {"Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado"}


        Private Function obtieneTablaServicioContrato(ByVal cmd As Odbc.OdbcCommand, ByVal ucHijas As DataSet, ByVal contrato_id As Integer, ByVal servicio_id As Integer, ByVal unidad_calculo_id As Integer, ByVal UCServicio As String, ByVal cantidad As Single, ByVal fecha_ini As Date, ByVal fecha_fin As Date, ByVal grupo As Integer, ByVal ucs As DataSet, ByVal porcimpuesto As Decimal, Optional ByVal defecto As Boolean = False, Optional ByVal precio_servicio As Object = Nothing, Optional ByVal dvcontrato As DataView = Nothing) As tablaServicios
            Dim errorCode As Integer = 0
            cmd.Parameters.Clear()
            Dim contrato_idParam As New Odbc.OdbcParameter("@contrato_id", contrato_id)
            cmd.Parameters.Add(contrato_idParam)
            Dim impuesto_incluido As Boolean = ExecuteScalar(cmd, sqlObtieneImpuestoIncluido, True)
            Dim reader As DataTableReader
            Dim resultado As New tablaServicios
            resultado.servicios.BeginLoadData()
            Try
                If IsNothing(dvcontrato) Then
                    Dim subds As DataSet = getDataSet(cmd, sqlTablaServicioContrato, True)
                    Dim dv As DataView = New DataView(subds.Tables(0), "servicio_id=" & servicio_id, "", DataViewRowState.CurrentRows)
                    reader = dv.ToTable.CreateDataReader()
                Else
                    dvcontrato.RowFilter = "servicio_id=" & servicio_id
                    'dvcontrato.GetEnumerator()
                    reader = dvcontrato.ToTable.CreateDataReader()
                End If
                Dim dsCondContratos As DataView = Nothing
                Dim tmpcheckcond As DataTable = getDataSet(cmd, sqlCondicionesContratos, True).tables(0)
                If tmpcheckcond.Rows.Count > 0 Then
                    dsCondContratos = New DataView(tmpcheckcond)
                End If


                'reader = getDataTable(cmd, sqlTablaServicioContrato, True) 'cmd.ExecuteReader()
                Dim desdecol As Integer = reader.GetOrdinal("desde")
                Dim hastacol As Integer = reader.GetOrdinal("hasta")
                Dim tipoimpucol As Integer = reader.GetOrdinal("tipo_imputacion_id")
                Dim frecol As Integer = reader.GetOrdinal("frecuencia_id")
                Dim tipoofertacol As Integer = reader.GetOrdinal("tipo_oferta_id")
                Dim o_linea_contrato_id As Integer = reader.GetOrdinal("linea_contrato_id")
                Dim o_unidad_calculo_id As Integer = reader.GetOrdinal("unidad_calculo_id")

                Using reader
                    Dim ttabla As New tablaServicios
                    Dim fini As Date
                    Dim ffin As Date
                    Dim tipo As Integer
                    Dim uc As Integer
                    Dim descripcion As String
                    Dim tipo_oferta_id As Integer
                    Dim noreg As Boolean
                    Dim desc_oferta As String
                    ttabla.servicios.BeginLoadData()
                    While reader.Read
                        'todo comprobar condiciones si las hubiese
                        Dim cumple As Boolean = True
                        Dim pertenece As Boolean = True

                        If Not IsNothing(dsCondContratos) And Not IsDBNull(reader.Item(o_linea_contrato_id)) Then
                            'cumple = cumpleCondicionesLineaContrato(cmd, reader.Item(o_linea_contrato_id), ucs)
                            dsCondContratos.RowFilter = "linea_contrato_id=" & reader.Item(o_linea_contrato_id)
                            cumple = cumpleCondiciones(dsCondContratos.ToTable.CreateDataReader, ucs)
                        End If
                        If cumple And Not IsDBNull(reader.Item(o_unidad_calculo_id)) Then
                            pertenece = perteneceUC(ucHijas, reader.Item(o_unidad_calculo_id), unidad_calculo_id)
                        End If
                        'pertenece = True
                        'If pertenece Then

                        fini = fecha_ini
                        ffin = fecha_fin
                        If Not reader.IsDBNull(tipoimpucol) Then
                            tipo = reader.Item(tipoimpucol)
                        Else
                            tipo = 0
                        End If
                        If Not reader.IsDBNull(frecol) Then
                            uc = reader.Item(frecol)
                        Else
                            uc = 2 'diario
                        End If
                        If reader.IsDBNull(tipoofertacol) Then
                            tipo_oferta_id = 0
                        Else
                            tipo_oferta_id = reader.Item(tipoofertacol)
                        End If

                        Select Case uc
                            Case 1
                                'si uc es una vez
                                If tipo = 2 Then
                                    'si se imputa a la salida
                                    'que pasara si la fecha fini =fecha fin?
                                    'fini = fecha_fin.AddDays(-1)
                                Else
                                    'si se imputa a la llegada o prorrateado (seria error)
                                    'ffin = fini.AddDays(1)
                                End If
                            Case 2
                                'si uc es diario
                                tipo = 0
                        End Select
                        descripcion = reader.Item("nombre_servicio")
                        desc_oferta = reader.Item("Oferta") & "(" & reader.Item("n") & "," & reader.Item("m") & ")"
                        Dim noregori As Boolean
                        'comprobar que exista entrada en lineas de contrato
                        noregori = (reader.IsDBNull(desdecol) Or reader.IsDBNull(hastacol))
                        If noregori = False Then
                            'comprobar que el dia de la semana esta activo
                            If reader.Item(camposDias(fini.DayOfWeek)) = 0 Then
                                noregori = True
                            End If
                        End If
                        'comprobar que esta entre las fechas



                        'Dim count As Integer = 0
                        Dim precio As Decimal = 0
                        'todo precio_servicio
                        If Not IsNothing(precio_servicio) And Not IsDBNull(precio_servicio) Then
                            precio = precio_servicio
                        Else
                            If reader.IsDBNull(reader.GetOrdinal("importe")) Then
                                precio = 0
                            Else
                                precio = reader.Item("importe")
                            End If
                        End If


                        Dim Row As DataRow = Nothing
                        While fini < ffin
                            'todo llevar un contador de cuantas veces voy ejecutando un servicio
                            If Row Is Nothing Then
                                Row = ttabla.servicios.Rows.Add()
                                With Row
                                    .Item("contrato_id_defecto") = contrato_id & "_" & defecto
                                    .Item("defecto") = defecto
                                    .Item("tipo_servicio_id") = reader.Item("tipo_servicio_id")
                                    .Item("contrato_id") = contrato_id
                                    .Item("desc_oferta") = desc_oferta
                                    .Item("desc_uc") = reader.Item("descripcion_unidad_calculo") 'esta desc esta mal
                                    .Item("desc_uc_reserva") = UCServicio
                                    .Item("desc_frecuencia") = reader.Item("descripcion_frecuencia_id")
                                    .Item("desc_tipo") = reader.Item("imputacion")
                                    .Item("servicio_id") = servicio_id
                                    .Item("cantidad") = cantidad
                                    .Item("grupo") = reader.Item("linea_contrato_id")
                                    .Item("pag_factura") = reader.Item("pag_factura")
                                    .Item("mgrupo") = grupo
                                    .Item("tipo") = tipo
                                    .Item("uc") = uc
                                    .Item("ucid") = unidad_calculo_id 'que hacer?
                                    .Item("ambito_id") = reader.Item("ambito_oferta_id")
                                    .Item("impuesto_incluido") = impuesto_incluido
                                    .Item("porc_impuesto") = porcimpuesto
                                End With
                            Else
                                Row = ttabla.servicios.Rows.Add(Row.ItemArray)
                            End If
                            With Row
                                .Item("fecha") = fini
                                noreg = noregori
                                If noreg = False Then
                                    'comprobar que esta entre las fechas
                                    If Not (fini >= reader.Item("desde") And fini <= reader.Item("hasta")) Then
                                        noreg = True
                                    End If
                                End If
                                If noreg = False And cumple And pertenece Then
                                    .Item("precio") = precio
                                    .Item("tipo_oferta_id") = tipo_oferta_id
                                    .Item("n") = reader.Item("n")
                                    .Item("m") = reader.Item("m")
                                    .Item("importe") = precio * cantidad
                                    .Item("descripcion") = descripcion
                                    .Item("error") = 0
                                Else
                                    .Item("importe") = 0
                                    .Item("descripcion") = "Error-" & descripcion
                                    .Item("error") = 1
                                End If
                            End With
                            fini = fini.AddDays(1)
                        End While

                        If ttabla.servicios.Rows.Count > 0 Then
                            ttabla.recalculaImportePorGrupo()
                            resultado.sumaTabla(ttabla)
                            'resultado.agregaTabla(ttabla, True)
                            ttabla.limpiar()
                        End If
                        'End If
                    End While
                    ttabla.servicios.EndLoadData()
                End Using
            Catch ex As Exception
                errorCode = -1
                AgregaInfo("obtieneTableServicioContrato", "Excepcion:" & ex.Message, -errorCode)

            Finally

            End Try
            resultado.servicios.EndLoadData()
            If errorCode = 0 Then
            Else
                resultado = Nothing
            End If

            Return resultado
        End Function
        Shared sqlObtieneCuposClienteDia = "" _
& " select cupos.cliente_id,sum(cupos.cupo) as habitaciones_disponibles,sum(cupo*tipos_habitacion.numero_personas) as CapacidadHotel,sum(cupos.cupo*cupos.garantia/100) as garantia from  " _
& " ( " _
& " select max(cupo_id) as cupo_id from " _
& " ( " _
& " SELECT cupos.cliente_id,cupos.cupo_id,cupos.tipo_habitacion_id " _
& " FROM cupos  " _
& " WHERE cupos.hotel_id =  ? AND (cupos.cliente_id =  ? or ?=0) and (tipo_habitacion_id=? or 0=? ) AND  ? between cupos.fecha_desde and cupos.fecha_hasta " _
& " ) drv group by drv.cliente_id,drv.tipo_habitacion_id" _
& " ) drv2 inner join  cupos on drv2.cupo_id=cupos.cupo_id inner join tipos_habitacion on cupos.tipo_habitacion_id=tipos_habitacion.tipo_habitacion_id group by cupos.cliente_id"

        Private Function ObtieneCupoClienteDia(ByVal cmd As Odbc.OdbcCommand, ByVal hotel_id As Integer, ByVal cliente_id As Integer, ByVal fecha As Date, Optional ByVal tipo_habitacion_id As Integer = 0)
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0

            cmd.Parameters.Clear()
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", cliente_id)
            Dim cliente_id1Param As New Odbc.OdbcParameter("@cliente_id1", cliente_id)
            Dim fechaParam As New Odbc.OdbcParameter("@fecha", convertFecha(fecha))
            Dim tipo_habitacion_idParam As New Odbc.OdbcParameter("@tipo_habitacion_id", tipo_habitacion_id)
            Dim tipo_habitacion_id1Param As New Odbc.OdbcParameter("@tipo_habitacion_id1", tipo_habitacion_id)
            cmd.Parameters.Add(hotel_idParam)
            cmd.Parameters.Add(cliente_idParam)
            cmd.Parameters.Add(cliente_id1Param)
            cmd.Parameters.Add(tipo_habitacion_idParam)
            cmd.Parameters.Add(tipo_habitacion_id1Param)
            cmd.Parameters.Add(fechaParam)
            'Return Me.ExecuteScalar(cmd, sqlObtieneCuposClienteDia)
            Dim datos As DataTableReader = Me.getDataTable(cmd, sqlObtieneCuposClienteDia)
            If cliente_id <> 0 Then


                Dim dev(1) As Integer
                dev(0) = 0
                dev(1) = 0
                While datos.Read
                    'Return Me.ExecuteScalar(cmd, sqlObtienetHabitacionesDisponibles)
                    dev(0) += datos.Item("habitaciones_disponibles")
                    Try
                        dev(1) += datos.Item("CapacidadHotel")
                    Catch ex As Exception

                    End Try

                End While
                Return dev
            Else
                Return Me.readerToTable(datos)

            End If
        End Function
        Shared sqlPlanningMensual = "" _
& " select tipos_habitacion.tipo_habitacion_id AS tipo_habitacion_id,tipos_habitacion.desc_corta AS TIPO_HABITACION,0 AS AGENCIA,'' AS NOMBRE_AGENCIA,hoteles.hotel AS Nombre_Hotel," _
& "  0 as DISPONIBLES_1, 0 as DISPONIBLES_2, 0 as DISPONIBLES_3, 0 as DISPONIBLES_4, 0 as DISPONIBLES_5, 0 as DISPONIBLES_6, 0 as DISPONIBLES_7, 0 as DISPONIBLES_8, 0 as DISPONIBLES_9, 0 as DISPONIBLES_10, 0 as DISPONIBLES_11, 0 as DISPONIBLES_12, 0 as DISPONIBLES_13, 0 as DISPONIBLES_14, 0 as DISPONIBLES_15, 0 as DISPONIBLES_16, 0 as DISPONIBLES_17, 0 as DISPONIBLES_18, 0 as DISPONIBLES_19, 0 as DISPONIBLES_20, 0 as DISPONIBLES_21, 0 as DISPONIBLES_22, 0 as DISPONIBLES_23, 0 as DISPONIBLES_24, 0 as DISPONIBLES_25, 0 as DISPONIBLES_26, 0 as DISPONIBLES_27, 0 as DISPONIBLES_28, 0 as DISPONIBLES_29, 0 as DISPONIBLES_30, 0 as DISPONIBLES_31," _
& "  0 as RESERVAS_1, 0 as RESERVAS_2, 0 as RESERVAS_3, 0 as RESERVAS_4, 0 as RESERVAS_5, 0 as RESERVAS_6, 0 as RESERVAS_7, 0 as RESERVAS_8, 0 as RESERVAS_9, 0 as RESERVAS_10, 0 as RESERVAS_11, 0 as RESERVAS_12, 0 as RESERVAS_13, 0 as RESERVAS_14, 0 as RESERVAS_15, 0 as RESERVAS_16, 0 as RESERVAS_17, 0 as RESERVAS_18, 0 as RESERVAS_19, 0 as RESERVAS_20, 0 as RESERVAS_21, 0 as RESERVAS_22, 0 as RESERVAS_23, 0 as RESERVAS_24, 0 as RESERVAS_25, 0 as RESERVAS_26, 0 as RESERVAS_27, 0 as RESERVAS_28, 0 as RESERVAS_29, 0 as RESERVAS_30, 0 as RESERVAS_31 ," _
& "  0 as LIBRES_1, 0 as LIBRES_2, 0 as LIBRES_3, 0 as LIBRES_4, 0 as LIBRES_5, 0 as LIBRES_6, 0 as LIBRES_7, 0 as LIBRES_8, 0 as LIBRES_9, 0 as LIBRES_10, 0 as LIBRES_11, 0 as LIBRES_12, 0 as LIBRES_13, 0 as LIBRES_14, 0 as LIBRES_15, 0 as LIBRES_16, 0 as LIBRES_17, 0 as LIBRES_18, 0 as LIBRES_19, 0 as LIBRES_20, 0 as LIBRES_21, 0 as LIBRES_22, 0 as LIBRES_23, 0 as LIBRES_24, 0 as LIBRES_25, 0 as LIBRES_26, 0 as LIBRES_27, 0 as LIBRES_28, 0 as LIBRES_29, 0 as LIBRES_30, 0 as LIBRES_31" _
& "," _
& " 0 as VDISPONIBLES_1, 0 as VDISPONIBLES_2, 0 as VDISPONIBLES_3, 0 as VDISPONIBLES_4, 0 as VDISPONIBLES_5, 0 as VDISPONIBLES_6, 0 as VDISPONIBLES_7, 0 as VDISPONIBLES_8, 0 as VDISPONIBLES_9, 0 as VDISPONIBLES_10, 0 as VDISPONIBLES_11, 0 as VDISPONIBLES_12, 0 as VDISPONIBLES_13, 0 as VDISPONIBLES_14, 0 as VDISPONIBLES_15, 0 as VDISPONIBLES_16, 0 as VDISPONIBLES_17, 0 as VDISPONIBLES_18, 0 as VDISPONIBLES_19, 0 as VDISPONIBLES_20, 0 as VDISPONIBLES_21, 0 as VDISPONIBLES_22, 0 as VDISPONIBLES_23, 0 as VDISPONIBLES_24, 0 as VDISPONIBLES_25, 0 as VDISPONIBLES_26, 0 as VDISPONIBLES_27, 0 as VDISPONIBLES_28, 0 as VDISPONIBLES_29, 0 as VDISPONIBLES_30, 0 as VDISPONIBLES_31, " _
& " 0 as VRESERVAS_1, 0 as VRESERVAS_2, 0 as VRESERVAS_3, 0 as VRESERVAS_4, 0 as VRESERVAS_5, 0 as VRESERVAS_6, 0 as VRESERVAS_7, 0 as VRESERVAS_8, 0 as VRESERVAS_9, 0 as VRESERVAS_10, 0 as VRESERVAS_11, 0 as VRESERVAS_12, 0 as VRESERVAS_13, 0 as VRESERVAS_14, 0 as VRESERVAS_15, 0 as VRESERVAS_16, 0 as VRESERVAS_17, 0 as VRESERVAS_18, 0 as VRESERVAS_19, 0 as VRESERVAS_20, 0 as VRESERVAS_21, 0 as VRESERVAS_22, 0 as VRESERVAS_23, 0 as VRESERVAS_24, 0 as VRESERVAS_25, 0 as VRESERVAS_26, 0 as VRESERVAS_27, 0 as VRESERVAS_28, 0 as VRESERVAS_29, 0 as VRESERVAS_30, 0 as VRESERVAS_31 , " _
& " 0 as VLIBRES_1, 0 as VLIBRES_2, 0 as VLIBRES_3, 0 as VLIBRES_4, 0 as VLIBRES_5, 0 as VLIBRES_6, 0 as VLIBRES_7, 0 as VLIBRES_8, 0 as VLIBRES_9, 0 as VLIBRES_10, 0 as VLIBRES_11, 0 as VLIBRES_12, 0 as VLIBRES_13, 0 as VLIBRES_14, 0 as VLIBRES_15, 0 as VLIBRES_16, 0 as VLIBRES_17, 0 as VLIBRES_18, 0 as VLIBRES_19, 0 as VLIBRES_20, 0 as VLIBRES_21, 0 as VLIBRES_22, 0 as VLIBRES_23, 0 as VLIBRES_24, 0 as VLIBRES_25, 0 as VLIBRES_26, 0 as VLIBRES_27, 0 as VLIBRES_28, 0 as VLIBRES_29, 0 as VLIBRES_30, 0 as VLIBRES_31 " _
& " FROM hoteles Inner Join tipos_habitacion_hotel ON hoteles.hotel_id = tipos_habitacion_hotel.hotel_id Inner Join tipos_habitacion ON tipos_habitacion_hotel.tipo_habitacion_id = tipos_habitacion.tipo_habitacion_id where hoteles.hotel_id=?"
        Private Sub HiloPlanningGeneral(ByVal blosta As Object)

            Dim estado() As Object
            SyncLock blosta.syncroot
                Try
                    estado = blosta.Dequeue
                Catch ex As Exception
                    estado = Nothing
                    Return
                End Try
            End SyncLock
            Dim z As New GesHotelClase(Me.userId)
            Dim limpiar As Boolean = False
            Dim cmd As Odbc.OdbcCommand = Nothing
            If IsNothing(cmd) Then
                cmd = prepareConection(IsolationLevel.RepeatableRead)
                limpiar = True
            End If



            While Not estado Is Nothing
                Try
                    estado(1) = ObtienePlanningDiario(cmd, estado(2), estado(3), estado(4), estado(5), estado(6), estado(7), estado(8)).Tables(0).CreateDataReader()
                Catch ex As Exception
                    Console.WriteLine("jare!")
                End Try
                estado(9).Enqueue(estado)
                SyncLock blosta.syncroot
                    Try
                        estado = blosta.Dequeue
                    Catch ex As Exception
                        estado = Nothing
                    End Try
                End SyncLock
            End While
            If limpiar Then
                flushConection(cmd, 1)
            End If

        End Sub
        Public Function ObtienePlanningMensual(ByVal hotel_id As Integer, ByVal ano As Integer, ByVal mes As Integer, Optional ByVal cliente_id As Integer = 0, Optional ByVal garantia As Integer = 0) As DataSet
            Dim fini As Date = New Date(ano, mes, 1)
            Dim ffin As Date = fini.AddMonths(1)
            Return ObtienePlanningMensual(fini, ffin, hotel_id, cliente_id, garantia)
        End Function
        Public Function ObtienePlanningMensual(ByVal fini As Date, ByVal ffin As Date, ByVal hotel_id As Integer, Optional ByVal cliente_id As Integer = 0, Optional ByVal garantia As Integer = 0) As DataSet
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection(IsolationLevel.RepeatableRead)
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            Dim datos As DataSet = getDataSet(cmd, sqlPlanningMensual)
            flushConection(cmd, errorCode)
            'Dim datosTiposHab As DataTableReader = getDataSet(cmd, sqlTipoHabitacionServicioHotel).Tables(0).CreateDataReader
            Dim tabla As DataTable = datos.Tables(0)
            Dim x As Integer
            Dim caches As New Hashtable
            Dim restab As New Queue
            Dim fintab As New Queue
            Dim reader As DataTableReader
            'Dim fini As Date = New Date(ano, mes, 1)
            'Dim ffin As Date = fini.AddMonths(1)
            Dim contador As Integer = tabla.Rows.Count
            For x = 0 To tabla.Rows.Count - 1
                'While datosTiposHab.Read
                Dim row As DataRow = tabla.Rows(x)
                Console.WriteLine(row.Item("tipo_habitacion_id"))
                Dim mato(10) As Object
                mato(0) = row
                mato(2) = hotel_id
                mato(3) = fini
                mato(4) = ffin
                mato(5) = garantia
                mato(6) = cliente_id
                mato(7) = row.Item("tipo_habitacion_id")
                mato(8) = caches
                mato(9) = fintab
                restab.Enqueue(mato)
                If x = 0 Or 0 = 1 Then
                    HiloPlanningGeneral(restab)
                    'reader = ObtienePlanningDiario(cmd, hotel_id, fini, ffin, garantia, cliente_id, row.Item("tipo_habitacion_id"), caches).Tables(0).CreateDataReader()
                    ' = reader
                Else
                    ThreadPool.QueueUserWorkItem(AddressOf HiloPlanningGeneral, restab)
                End If
            Next

            'End While
            Dim mat(10) As Object
            mat = fintab.Dequeue()
            While Not IsNothing(mat)
                Dim row As DataRow
                row = mat(0)
                reader = mat(1)
                Dim dia As Integer
                While reader.Read
                    dia = DateDiff(DateInterval.DayOfYear, fini, CDate(reader.Item("fecha"))) + 1
                    'dia = CDate(reader.Item("fecha")).Day
                    If reader.Item("TIPO_HABITACION") <> "DES" Then 'cambiar por un flag?
                        row("DISPONIBLES_" & dia) = reader.Item("disponibles")
                        row("RESERVAS_" & dia) = reader.Item("ocupadas")
                        row("LIBRES_" & dia) = reader.Item("libres")
                    Else
                        row("DISPONIBLES_" & dia) = 0
                        row("RESERVAS_" & dia) = 0
                        row("LIBRES_" & dia) = 0
                    End If

                    row("VDISPONIBLES_" & dia) = reader.Item("disponibles")
                    row("VRESERVAS_" & dia) = reader.Item("ocupadas")
                    row("VLIBRES_" & dia) = reader.Item("libres")
                End While
                contador -= 1
                mat = Nothing
                While contador > 0 And IsNothing(mat)
                    Try
                        mat = fintab.Dequeue()
                    Catch ex As Exception
                        'todo sleep
                        HiloPlanningGeneral(restab)
                        If fintab.Count = 0 Then
                            Thread.Sleep(100)
                        End If
                    End Try
                End While
            End While

            tabla.AcceptChanges()
            Return datos

        End Function
        Public Function ObtienePlanningMensualOld(ByVal hotel_id As Integer, ByVal ano As Integer, ByVal mes As Integer, Optional ByVal cliente_id As Integer = 0, Optional ByVal garantia As Integer = 0) As DataSet
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            Dim datos As DataSet = getDataSet(cmd, sqlPlanningMensual)
            'Dim datosTiposHab As DataTableReader = getDataSet(cmd, sqlTipoHabitacionServicioHotel).Tables(0).CreateDataReader
            Dim tabla As DataTable = datos.Tables(0)
            Dim x As Integer
            Dim caches As New Hashtable
            For x = 0 To tabla.Rows.Count - 1
                'While datosTiposHab.Read
                Dim row As DataRow = tabla.Rows(x)
                Dim fini As Date = New Date(ano, mes, 1)
                Dim ffin As Date = fini.AddMonths(1)
                Console.WriteLine(row.Item("tipo_habitacion_id"))
                Dim reader As DataTableReader = ObtienePlanningDiario(cmd, hotel_id, fini, ffin, garantia, cliente_id, row.Item("tipo_habitacion_id"), caches).Tables(0).CreateDataReader()
                'pivotar tabla
                'tabla.Clear()

                'Dim rows() As DataRow
                'row = tabla.Rows.Add()
                Dim dia As Integer
                While reader.Read
                    'Dim fecha As Date = 
                    dia = CDate(reader.Item("fecha")).Day
                    'rows = tabla.Select("TIPO_HABITACION='" & reader.Item("TIPO_HABITACION") & "'")
                    'If rows.Length > 0 Then
                    'row = rows(0)
                    row("DISPONIBLES_" & dia) = reader.Item("disponibles")
                    row("RESERVAS_" & dia) = reader.Item("ocupadas")
                    row("LIBRES_" & dia) = reader.Item("libres")
                    'End If
                End While
            Next
            'End While
            flushConection(cmd, errorCode)
            tabla.AcceptChanges()
            Return datos

        End Function

        Shared sqlPlaningDiario = "" _
& " select 'H1' as TIPO_HABITACION,'2008-01-01' as fecha, " _
& " 0 as libres, " _
& " 0 as disponibles, " _
& " 0 as ocupadas,0 as ocupadas1,0 as garantia, " _
& " 0.1 as PorHab, " _
& " 0 as Llegadas, " _
& " 0 as Salidas, " _
& " 0 as TPax,0 as Adultos,0.1 as PorOcup, " _
& " 0 as Bebes, " _
& " 0 as Ninos, " _
& " 0 as Ninos2, " _
& " 0 as SS_A,0 as SS_N1,0 as SS_N2,0 as SS_B," _
& " 0 as HD_A,0 as HD_N1,0 as HD_N2,0 as HD_B, " _
& " 0 as MP_A,0 as MP_N1,0 as MP_N2,0 as MP_B, " _
& " 0 as PC_A,0 as PC_N1,0 as PC_N2,0 as PC_B, " _
& " 0 as TI_A,0 as TI_N1,0 as TI_N2,0 as TI_B, " _
& " 0 as SS, " _
& " 0 as HD, " _
& " 0 as MP, " _
& " 0 as PC," _
& " 0 as TI from hoteles where 1=0"
        Shared sqlObtieneReservasValidasEntreFechas = "" _
& " SELECT " _
& " * " _
& " FROM " _
& " reservas " _
& " WHERE " _
& " reservas.estado_reserva_id not in (0,2) and  " _
& " reservas.hotel_id=? and (?=0 or reservas.cliente_id=? ) and ( " _
& " ifnull(reservas.fecha_llegada,fecha_prevista_llegada) between ? and ?  " _
& " or ifnull(reservas.fecha_salida,fecha_prevista_salida) between ? and ?" _
& " or ? between ifnull(reservas.fecha_llegada,fecha_prevista_llegada)  and ifnull(reservas.fecha_salida,fecha_prevista_salida)" _
& " or ? between ifnull(reservas.fecha_llegada,fecha_prevista_llegada)  and ifnull(reservas.fecha_salida,fecha_prevista_salida)" _
& " )"
        Shared sqlObtieneHabitacionesDispHotelEntreFechas = "" _
& " SELECT " _
& " habitaciones.habitacion_id,habitaciones.numero_habitacion,habitaciones.fecha_inicio, " _
& " habitaciones_bloqueos.fecha_desde, " _
& " habitaciones_bloqueos.fecha_hasta, " _
& " habitaciones_bloqueos.tipo_bloqueo_id,habitaciones_bloqueos.reserva_id " _
& " FROM " _
& " habitaciones " _
& " Left Join habitaciones_bloqueos ON habitaciones.habitacion_id = habitaciones_bloqueos.habitacion_id and  (" _
& " ( " _
& "         ?  between habitaciones_bloqueos.fecha_desde and habitaciones_bloqueos.fecha_hasta " _
& " or  ? between habitaciones_bloqueos.fecha_desde and habitaciones_bloqueos.fecha_hasta " _
& " or habitaciones_bloqueos.fecha_desde between ? and ? " _
& " or habitaciones_bloqueos.fecha_hasta between ? and ? " _
& " ) or true=?) " _
& " WHERE " _
& " habitaciones.hotel_id =  ? order by habitaciones.numero_habitacion"
        Shared sqlObtieneHabitacionesHotel = "SELECT habitaciones.habitacion_id,habitaciones.numero_habitacion,habitaciones.fecha_inicio FROM habitaciones WHERE habitaciones.hotel_id = ? order by habitaciones.numero_habitacion"
        Shared sqlTipoHabitacionServicioHotel = "" _
& " SELECT tipos_habitacion.desc_corta,tipos_habitacion.tipo_habitacion_id,tipos_habitacion_hotel.servicio_id " _
& " FROM " _
& " tipos_habitacion_hotel Inner Join tipos_habitacion ON tipos_habitacion_hotel.tipo_habitacion_id = tipos_habitacion.tipo_habitacion_id " _
& " WHERE tipos_habitacion_hotel.hotel_id =  ? and (tipos_habitacion.desvios=0 or 1=?)"
        Shared sqlListadoSalidas = "Select 999 As SS,999 AS HD,999 As MP,999 AS PC, 999 AS TI,'' As Hab, 'B1' As tipo_hab, 1 As cant_hab,'Cliente' AS cliente, 'SS' As Regimen,99999 As Reserva,999 As pax, 99 As N1, 99 As N2, 99 As B,'touroperador' As touroperador,'hh:mm' As hora_llegada,'hh:mm' As hora_salida, '31/01/2009' As fecha_llegada,'31/01/2009' As fecha_salida,999 As dias, 'observaciones entrada' As observaciones_llegada,'observaciones salida' As observaciones_salida,'observaciones' As observaciones from hoteles where 1=0"
        Shared sqlListadoSalidasReservasFSal = "select clientes.razon as touroperador,reservas_primer_huesped.razon as huesped,reservas_primer_huesped.numero_habitacion,reservas.reserva_id,datediff(ifnull(reservas.fecha_salida,reservas.fecha_prevista_salida),ifnull(reservas.fecha_llegada,reservas.fecha_prevista_llegada)) as dias,ifnull(reservas.fecha_llegada,reservas.fecha_prevista_llegada) as fecha_llegada,ifnull(reservas.fecha_salida,reservas.fecha_prevista_salida) as fecha_salida," _
& " reservas.observaciones,reservas.observaciones_llegada,reservas.observaciones_salida,reservas.hora_prevista_salida as hora_salida,reservas.hora_prevista_llegada as hora_llegada " _
& " from reservas left join clientes on reservas.cliente_id=clientes.cliente_id left join reservas_primer_huesped on reservas.reserva_id=reservas_primer_huesped.reserva_id " _
& " where reservas.hotel_id=? " _
& " and ifnull(reservas.fecha_salida,reservas.fecha_prevista_salida)=? " _
& " and reservas.estado_reserva_id not in (0,2) and (reservas.cliente_id=? or ?=0) order by reservas.cliente_id"
        Shared sqlListadoSalidasReservasFLleg = "select clientes.razon as touroperador,reservas_primer_huesped.razon as huesped,reservas_primer_huesped.numero_habitacion,reservas.reserva_id,datediff(ifnull(reservas.fecha_salida,reservas.fecha_prevista_salida),ifnull(reservas.fecha_llegada,reservas.fecha_prevista_llegada)) as dias,ifnull(reservas.fecha_llegada,reservas.fecha_prevista_llegada) as fecha_llegada,ifnull(reservas.fecha_salida,reservas.fecha_prevista_salida) as fecha_salida," _
& " reservas.observaciones,reservas.observaciones_llegada,reservas.observaciones_salida,reservas.hora_prevista_salida as hora_salida,reservas.hora_prevista_llegada as hora_llegada " _
& " from reservas left join clientes on reservas.cliente_id=clientes.cliente_id left join reservas_primer_huesped on reservas.reserva_id=reservas_primer_huesped.reserva_id " _
& " where reservas.hotel_id=? " _
& " and ifnull(reservas.fecha_llegada,reservas.fecha_prevista_llegada)=? " _
& " and reservas.estado_reserva_id not in (0,2) and (reservas.cliente_id=? or ?=0) order by reservas.cliente_id"

        'Dim sqlListadoReservas = "Select 1 As Hab, 'B1' As tipo_hab, 'Cliente' AS cliente, 99999 As Reserva,999 As pax, 999 As SS,999 AS Des,999 As MP,999 AS PC, 999 AS TI,'touroperador' As touroperador,'hh:mm' As hora_salida, '31/01/2009' As fecha_salida, 'observaciones entrada' As observaciones"
        Shared sqlListadoReservasActivas = "select clientes.razon as touroperador,reservas_primer_huesped.razon as huesped,reservas_primer_huesped.numero_habitacion,reservas.reserva_id,datediff(ifnull(reservas.fecha_salida,reservas.fecha_prevista_salida),ifnull(reservas.fecha_llegada,reservas.fecha_prevista_llegada)) as dias,ifnull(reservas.fecha_llegada,reservas.fecha_prevista_llegada) as fecha_llegada,ifnull(reservas.fecha_salida,reservas.fecha_prevista_salida) as fecha_salida," _
& " reservas.observaciones,reservas.observaciones_llegada,reservas.observaciones_salida,reservas.hora_prevista_salida as hora_salida,reservas.hora_prevista_llegada as hora_llegada " _
& " from reservas left join clientes on reservas.cliente_id=clientes.cliente_id left join reservas_primer_huesped on reservas.reserva_id=reservas_primer_huesped.reserva_id " _
& " where reservas.hotel_id=? " _
& " and ifnull(reservas.fecha_llegada,reservas.fecha_prevista_llegada)<=? and ifnull(reservas.fecha_salida,reservas.fecha_prevista_salida)>? " _
& " and reservas.estado_reserva_id not in (0,2) and (reservas.cliente_id=? or ?=0) order by reservas.cliente_id"

        Public Function ObtieneListadoReservas(ByVal hotel_id As Integer, ByVal fechaini As Date, Optional ByVal cliente_id As Integer = 0, Optional ByVal orderby As Integer = 0) As DataSet
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim datos As DataSet = getDataSet(cmd, sqlListadoSalidas)
            Try
                cmd.Parameters.Clear()
                Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
                Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", cliente_id)
                Dim cliente_id1Param As New Odbc.OdbcParameter("@cliente_id1", cliente_id)
                Dim fechainiParam As New Odbc.OdbcParameter("@fechaini", convertFecha(fechaini))
                Dim fechaini1Param As New Odbc.OdbcParameter("@fechaini1", convertFecha(fechaini))
                cmd.Parameters.Add(hotel_idParam)
                cmd.Parameters.Add(fechainiParam)
                cmd.Parameters.Add(fechaini1Param)
                cmd.Parameters.Add(cliente_idParam)
                cmd.Parameters.Add(cliente_id1Param)
                Dim reader As DataTableReader = getDataTable(cmd, sqlListadoReservasActivas)
                procesarDatosListado(cmd, reader, datos, fechaini)
                datos.Tables(0).Columns.Add("HabNum", System.Type.GetType("System.Int32"), "1000+Hab")
                Dim dt As DataTable = New DataView(datos.Tables(0), "", "HabNum", DataViewRowState.CurrentRows).ToTable
                datos = New DataSet
                datos.Merge(dt)


            Catch ex As Exception
                datos = getDataSet(cmd, sqlListadoSalidas)
                errorCode = 1
            End Try
            flushConection(cmd, errorCode)
            Return datos
        End Function
        Public Function ObtieneListadoLlegadas(ByVal hotel_id As Integer, ByVal fechaini As Date, Optional ByVal cliente_id As Integer = 0) As DataSet
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim datos As DataSet = getDataSet(cmd, sqlListadoSalidas)
            Try
                cmd.Parameters.Clear()
                Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
                Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", cliente_id)
                Dim cliente_id1Param As New Odbc.OdbcParameter("@cliente_id1", cliente_id)
                Dim fechainiParam As New Odbc.OdbcParameter("@fechaini", convertFecha(fechaini))
                cmd.Parameters.Add(hotel_idParam)
                cmd.Parameters.Add(fechainiParam)
                cmd.Parameters.Add(cliente_idParam)
                cmd.Parameters.Add(cliente_id1Param)
                Dim reader As DataTableReader = getDataTable(cmd, sqlListadoSalidasReservasFLleg)
                procesarDatosListado(cmd, reader, datos)
            Catch ex As Exception
                datos = getDataSet(cmd, sqlListadoSalidas)
                errorCode = 1
            End Try
            flushConection(cmd, errorCode)
            Return datos
        End Function


        Public Function ObtieneListadoSalidas(ByVal hotel_id As Integer, ByVal fechaini As Date, Optional ByVal cliente_id As Integer = 0) As DataSet
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim datos As DataSet = getDataSet(cmd, sqlListadoSalidas)
            Try
                cmd.Parameters.Clear()
                Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
                Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", cliente_id)
                Dim cliente_id1Param As New Odbc.OdbcParameter("@cliente_id1", cliente_id)

                Dim fechainiParam As New Odbc.OdbcParameter("@fechaini", convertFecha(fechaini))
                cmd.Parameters.Add(hotel_idParam)
                cmd.Parameters.Add(fechainiParam)
                cmd.Parameters.Add(cliente_idParam)
                cmd.Parameters.Add(cliente_id1Param)

                Dim reader As DataTableReader = getDataTable(cmd, sqlListadoSalidasReservasFSal)
                procesarDatosListado(cmd, reader, datos)
            Catch ex As Exception
                datos = getDataSet(cmd, sqlListadoSalidas)
                errorCode = 1
            End Try
            flushConection(cmd, errorCode)
            Return datos
        End Function
        Shared sqlObtieneOfertasReserva = "" _
& " SELECT" _
& " group_concat(ofertas.texto) " _
& " FROM " _
& " reservas_ofertas " _
& " Inner Join ofertas ON reservas_ofertas.oferta_id = ofertas.oferta_id " _
& " WHERE " _
& " reservas_ofertas.reserva_id =  ? AND " _
& " reservas_ofertas.activa =  1 " _
& " group by reservas_ofertas.reserva_id "
        Private Sub procesarDatosListado(ByVal cmd As Odbc.OdbcCommand, ByVal reader As DataTableReader, ByVal datos As DataSet, Optional ByVal fecha As Object = Nothing)
            While reader.Read
                'If reader.Item("reserva_id") = 2168 Then
                'Dim zk = 0
                'End If
                Dim dr As DatosReserva = obtieneReservaDatosListados(cmd, reader.Item("reserva_id"), fecha)
                cmd.Parameters.Clear()
                'Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", 570)

                Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reader.Item("reserva_id"))
                cmd.Parameters.Add(reserva_idParam)
                Dim ofe As Object = ExecuteScalar(cmd, sqlObtieneOfertasReserva)
                If IsNothing(ofe) Then
                    ofe = ""
                End If
                Dim row As DataRow = datos.Tables(0).Rows.Add()
                row.Item("Hab") = reader.Item("numero_habitacion")
                row.Item("tipo_hab") = dr.tipo_hab
                row.Item("cant_hab") = dr.cant_hab
                row.Item("cliente") = reader.Item("huesped")
                row.Item("Regimen") = dr.regimen
                row.Item("reserva") = reader.Item("reserva_id")
                row.Item("SS") = dr.SS
                row.Item("HD") = dr.HD
                row.Item("MP") = dr.MP
                row.Item("PC") = dr.PC
                row.Item("TI") = dr.TI

                row.Item("pax") = dr.pax
                row.Item("n1") = dr.n1
                row.Item("n2") = dr.n2
                row.Item("b") = dr.b
                row.Item("touroperador") = reader.Item("touroperador")
                row.Item("hora_salida") = reader.Item("hora_salida")
                row.Item("hora_llegada") = reader.Item("hora_llegada")
                row.Item("fecha_llegada") = CDate(reader.Item("fecha_llegada")).ToShortDateString
                row.Item("fecha_salida") = CDate(reader.Item("fecha_salida")).ToShortDateString
                row.Item("dias") = reader.Item("dias")
                row.Item("observaciones") = reader.Item("observaciones")
                row.Item("observaciones_salida") = reader.Item("observaciones_salida")
                row.Item("observaciones_llegada") = reader.Item("observaciones_llegada") & " " & ofe
                'Dim res As DataTableReader = 
            End While
        End Sub
        Class DatosReserva
            Public SS As Integer
            Public HD As Integer
            Public MP As Integer
            Public PC As Integer
            Public TI As Integer
            Public pax As Integer
            Public a As Integer
            Public n1 As Integer
            Public n2 As Integer
            Public b As Integer
            Public tipo_hab As String
            Public cant_hab As Integer
            Public regimen As String
            Public ofertas As String
            Public bono As String
            Public fecha_desde As Date
            Public fecha_hasta As Date
            Public primer_huesped As String
            Public habitacion As String
        End Class
        Public Function obtieneReservaDatosListados(ByVal reserva_id As Integer) As DatosReserva
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim datos As DatosReserva
            Try
                datos = obtieneReservaDatosListados(cmd, reserva_id)
            Catch ex As Exception
                errorCode = 1
                datos = New DatosReserva
            End Try
            flushConection(cmd, errorCode)
            Return datos
        End Function
        Shared sqlReservaPrimerHuesped As String = "select * from reservas_primer_huesped where reserva_id=?"
        Shared sqlReservaPrimerCliente As String = "" _
& " SELECT clientes.razon, " _
& " ( " _
& " SELECT " _
& " habitaciones.numero_habitacion " _
& " FROM " _
& " (select max(habitaciones_bloqueos.habitacion_bloqueo_id) AS habitacion_bloqueo_id from habitaciones_bloqueos where habitaciones_bloqueos.reserva_id=? )  " _
& " as reserva_ultimo_bloqueo_habitacion " _
& " Inner Join habitaciones_bloqueos ON reserva_ultimo_bloqueo_habitacion.habitacion_bloqueo_id = habitaciones_bloqueos.habitacion_bloqueo_id " _
& " Inner Join habitaciones ON habitaciones_bloqueos.habitacion_id = habitaciones.habitacion_id " _
& " ) as numero_habitacion  " _
& " FROM reservas_huespedes Inner Join clientes ON reservas_huespedes.cliente_id = clientes.cliente_id WHERE reservas_huespedes.reserva_id =  ? LIMIT 1 "

        Private Function obtieneReservaDatosListados(ByVal cmd As Odbc.OdbcCommand, ByVal reserva_id As Integer, Optional ByVal fecha As Object = Nothing) As DatosReserva
            Dim cabres As DataSet = getDataSet(cmd, Replace(sqlCabReserva, "?", reserva_id))
            'Dim respri As DataSet = getDataSet(cmd, Replace(sqlReservaPrimerHuesped, "?", reserva_id))
            Dim respri As DataSet = getDataSet(cmd, Replace(sqlReservaPrimerCliente, "?", reserva_id))
            Dim corders As DataTable = New DataTable("dt_tmp")
            corders.Load(preProcesaServicios(getDataTable(cmd, Replace(sqlTablaReservas, "?", reserva_id))))
            'si tiene fecha
            'seleccionar los que caen en esa fecha
            Dim filtro As String = ""
            If Not IsNothing(fecha) Then
                filtro = "fecha_desde<='" & fecha & "' and fecha_hasta>'" & fecha & "' "
            End If
            corders = New DataView(corders, filtro, "", DataViewRowState.CurrentRows).ToTable
            'obtener el mayor por servicio,uc
            Dim x As Integer
            Dim neworders As New Hashtable
            Dim xc As Integer = corders.Rows.Count - 1
            Dim key
            For x = 0 To xc
                key = corders.Rows(x).Item("servicio_id") & "_" & corders.Rows(x).Item("unidad_calculo_id")
                If Not neworders.ContainsKey(key) Then
                    neworders(key) = corders.Rows(x)
                Else
                    If corders.Rows(x).Item("cantidad") > neworders(key).item("cantidad") Then
                        neworders(key) = corders.Rows(x)
                    End If
                End If
            Next
            Dim filas(neworders.Count - 1) As DataRow
            neworders.Values.CopyTo(filas, 0)

            Dim dr As New DatosReserva
            dr.pax = 0
            dr.a = 0
            dr.n1 = 0
            dr.n2 = 0
            dr.b = 0
            Try
                If Not cabres.Tables(0).Rows(0).IsNull("bono_referencia") Then
                    dr.bono = cabres.Tables(0).Rows(0)("bono_referencia")
                End If
                dr.fecha_desde = cabres.Tables(0).Rows(0)("fecha_prevista_llegada")
                dr.fecha_hasta = cabres.Tables(0).Rows(0)("fecha_prevista_salida")
                dr.habitacion = " "
                dr.primer_huesped = " "
                If respri.Tables(0).Rows.Count > 0 Then
                    If Not IsDBNull(respri.Tables(0).Rows(0)("numero_habitacion")) Then
                        dr.habitacion = respri.Tables(0).Rows(0)("numero_habitacion")
                    End If
                    If Not IsDBNull(respri.Tables(0).Rows(0)("razon")) Then
                        dr.primer_huesped = respri.Tables(0).Rows(0)("razon")
                    End If
                End If

            Catch ex As Exception
                Console.Write(ex.Message)
            End Try
            Dim abrv As New Hashtable
            xc = filas.Length - 1
            For x = 0 To xc
                With filas(x)
                    abrv(.Item("abreviatura")) += .Item("cantidad")
                    If .Item("tipo_servicio_id") = 1 And .Item("tipo_unidad_calculo_id") = 1 Then
                        dr.tipo_hab = .Item("abreviatura")
                        dr.cant_hab = .Item("cantidad")
                    End If
                    If .Item("tipo_servicio_id") = 2 Or .Item("abreviatura") = "A1" Or .Item("abreviatura") = "A2" Then
                        If dr.regimen = "" OrElse dr.regimen = "A1" OrElse dr.regimen = "A2" Then
                            dr.regimen = .Item("abreviatura")
                        End If
                    End If
                    If .Item("UC") = "A" Then
                        If .Item("cantidad") > dr.a Then
                            dr.a = .Item("cantidad")
                        End If
                    End If
                    If .Item("UC") = "N1" Then
                        If .Item("cantidad") > dr.n1 Then
                            dr.n1 = .Item("cantidad")
                        End If
                    End If
                    If .Item("UC") = "N2" Then
                        If .Item("cantidad") > dr.n2 Then
                            dr.n2 = .Item("cantidad")
                        End If
                    End If
                    If .Item("UC") = "B" Then
                        If .Item("cantidad") > dr.b Then
                            dr.b = .Item("cantidad")
                        End If
                    End If
                End With
            Next
            dr.pax = dr.a + dr.n1 + dr.n2
            dr.SS = dr.pax - abrv("HD") - abrv("MP") - abrv("PC") - abrv("TI")
            dr.HD = abrv("HD")
            dr.MP = abrv("MP")
            dr.PC = abrv("PC")
            dr.TI = abrv("TI")
            Return dr
        End Function
        Public Function ObtienePlanningDiario(ByVal hotel_id As Integer, ByVal fechaini As Date, ByVal fechafin As Date, ByVal garantia As Integer, Optional ByVal cliente_id As Integer = 0, Optional ByVal tipo_habitacion_id As Integer = 0) As DataSet
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim datos As DataSet = ObtienePlanningDiario(cmd, hotel_id, fechaini, fechafin, garantia, cliente_id, tipo_habitacion_id, Nothing, True)
            flushConection(cmd, errorCode)
            Return datos
        End Function
        Shared sqlDesglosePensionAgencia = "" _
& " select 0 as cliente_id,'Agencia' as Agencia," _
& " 0 as SS_A,0 as SS_N1,0 as SS_N2,0 as SS_B, " _
& " 0 as HD_A,0 as HD_N1,0 as HD_N2,0 as HD_B, " _
& " 0 as MP_A,0 as MP_N1,0 as MP_N2,0 as MP_B, " _
& " 0 as PC_A,0 as PC_N1,0 as PC_N2,0 as PC_B, " _
& " 0 as TI_A,0 as TI_N1,0 as TI_N2,0 as TI_B from hoteles where 1=0"
        Shared OldsqlClientesConContratosHotel = "" _
& " SELECT distinct clientes.cliente_id,clientes.razon " _
& " FROM clientes " _
& " Inner Join contratos ON contratos.cliente_id = clientes.cliente_id " _
& " where  contratos.hotel_id=? " _
& " order by clientes.razon "
        Shared sqlClientesConContratosHotel = "" _
        & "         SELECT distinct clientes.cliente_id,clientes.razon" _
& " FROM clientes  " _
& " where clientes.grupo_cliente_id in (2) or clientes.cliente_defecto=1 " _
& "  order by clientes.razon "

        Private Class agenciaDesglose
            Public hotel_id As Integer
            Public cliente_id As Integer
            Public fechaini As Date
            Public fechafin As Date
            Public resultado As DataSet
            Public row As DataRow
            Public datos As System.Collections.Queue
            Public procesando As System.Collections.Queue
        End Class
        Private Sub HiloDesgloseAgencia(ByVal blosta As Object)
            Dim z As New GesHotelClase(Me.userId)
            Dim cmd As Odbc.OdbcCommand = prepareConection()

            Dim bloque As System.Collections.Queue = blosta
            Dim estado As agenciaDesglose
            Do
                SyncLock bloque.SyncRoot
                    Try
                        estado = bloque.Dequeue
                        If Not estado Is Nothing Then
                            estado.procesando.Enqueue(estado)
                        End If
                    Catch ex As Exception
                        estado = Nothing
                    End Try
                End SyncLock
                If Not estado Is Nothing Then

                    Dim datos As DataSet = ObtienePlanningDiario(cmd, estado.hotel_id, estado.fechaini, estado.fechafin, 0, estado.cliente_id)
                    estado.resultado = datos
                    SyncLock bloque.SyncRoot
                        Try
                            estado.datos.Enqueue(estado)
                            estado.procesando.Dequeue()
                        Catch ex As Exception
                        End Try
                    End SyncLock

                End If
            Loop While Not estado Is Nothing
            
            flushConection(cmd, 1)
        End Sub
        Public Function ObtieneDesglosePensionAgencia(ByVal hotel_id As Integer, ByVal fechaini As Date, ByVal fechafin As Date) As DataSet
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim resultado As DataSet = getDataSet(cmd, sqlDesglosePensionAgencia)

            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            'todo obtiene todas las agencias con contrato para ese hotel
            Dim reader As DataTableReader = getDataTable(cmd, sqlClientesConContratosHotel)
            'Dim caches As New Hashtable
            Dim batch As New batchtasks
            batch.maxThreads = 5
            Dim filastable As New Hashtable
            While reader.Read
                'por cada agencia obtener su planning diario
                Dim row As DataRow = resultado.Tables(0).Rows.Add
                row("cliente_id") = reader("cliente_id")
                row("agencia") = reader("razon")
                Dim obj() = {hotel_id, fechaini, fechafin, 0, reader("cliente_id"), 0}
                batch.addTask(Me, "ObtienePlanningDiario", reader("cliente_id"), obj)
                filastable(reader("cliente_id")) = row
            End While
            flushConection(cmd, errorCode)
            batch.waitForCompletition()
            'Dim colaDatos As Queue = batch.getResultQueue()
            Dim colad As Hashtable = batch.getResultHashTable()
            Dim ienu As IEnumerator = colad.Keys.GetEnumerator
            While ienu.MoveNext
                Dim tabla As DataTable = colad(ienu.Current).Tables(0)
                Dim row As DataRow = filastable(ienu.Current)

                If tabla.Rows.Count > 0 Then

                    row("SS_A") = tabla.Compute("sum(SS_A)", "")
                    row("SS_N1") = tabla.Compute("sum(SS_N1)", "")
                    row("SS_N2") = tabla.Compute("sum(SS_N2)", "")
                    row("SS_B") = tabla.Compute("sum(SS_B)", "")
                    row("HD_A") = tabla.Compute("sum(HD_A)", "")
                    row("HD_N1") = tabla.Compute("sum(HD_N1)", "")
                    row("HD_N2") = tabla.Compute("sum(HD_N2)", "")
                    row("HD_B") = tabla.Compute("sum(HD_B)", "")
                    row("MP_A") = tabla.Compute("sum(MP_A)", "")
                    row("MP_N1") = tabla.Compute("sum(MP_N1)", "")
                    row("MP_N2") = tabla.Compute("sum(MP_N2)", "")
                    row("MP_B") = tabla.Compute("sum(MP_B)", "")
                    row("PC_A") = tabla.Compute("sum(PC_A)", "")
                    row("PC_N1") = tabla.Compute("sum(PC_N1)", "")
                    row("PC_N2") = tabla.Compute("sum(PC_N2)", "")
                    row("PC_B") = tabla.Compute("sum(PC_B)", "")
                    row("TI_A") = tabla.Compute("sum(TI_A)", "")
                    row("TI_N1") = tabla.Compute("sum(TI_N1)", "")
                    row("TI_N2") = tabla.Compute("sum(TI_N2)", "")
                    row("TI_B") = tabla.Compute("sum(TI_B)", "")
                End If


            End While


            Return resultado
        End Function
        Public Function ObtieneDesglosePensionAgenciaNew(ByVal hotel_id As Integer, ByVal fechaini As Date, ByVal fechafin As Date) As DataSet
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim resultado As DataSet = getDataSet(cmd, sqlDesglosePensionAgencia)

            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            'todo obtiene todas las agencias con contrato para ese hotel
            Dim reader As DataTableReader = getDataTable(cmd, sqlClientesConContratosHotel)
            'Dim caches As New Hashtable

            Dim colaentrada As New System.Collections.Queue
            Dim colasalida As New System.Collections.Queue
            Dim colaprocesando As New System.Collections.Queue
            While reader.Read

                'por cada agencia obtener su planning diario
                Dim row As DataRow = resultado.Tables(0).Rows.Add
                row("cliente_id") = reader("cliente_id")
                row("agencia") = reader("razon")
                Dim objdes As New agenciaDesglose
                objdes.hotel_id = hotel_id
                objdes.fechaini = fechaini
                objdes.fechafin = fechafin
                objdes.cliente_id = reader("cliente_id")
                objdes.row = row
                objdes.datos = colasalida
                objdes.procesando = colaprocesando
                colaentrada.Enqueue(objdes)
            End While
            flushConection(cmd, errorCode)

            Dim x As Integer
            For x = 0 To 5

                ThreadPool.QueueUserWorkItem(AddressOf HiloDesgloseAgencia, colaentrada)
            Next

            While colaentrada.Count + colaprocesando.Count + colasalida.Count > 0

                While colasalida.Count > 0
                    Dim estado As agenciaDesglose
                    SyncLock colaentrada.SyncRoot
                        Try
                            estado = colasalida.Dequeue
                        Catch ex As Exception
                            estado = Nothing
                        End Try
                    End SyncLock
                    If Not estado Is Nothing Then
                        Dim row As DataRow = estado.row
                        Dim tabla As DataTable = estado.resultado.Tables(0)

                        If tabla.Rows.Count > 0 And 1 = 0 Then

                            row("SS_A") = tabla.Compute("sum(SS_A)", "")
                            row("SS_N1") = tabla.Compute("sum(SS_N1)", "")
                            row("SS_N2") = tabla.Compute("sum(SS_N2)", "")
                            row("SS_B") = tabla.Compute("sum(SS_B)", "")
                            row("HD_A") = tabla.Compute("sum(HD_A)", "")
                            row("HD_N1") = tabla.Compute("sum(HD_N1)", "")
                            row("HD_N2") = tabla.Compute("sum(HD_N2)", "")
                            row("HD_B") = tabla.Compute("sum(HD_B)", "")
                            row("MP_A") = tabla.Compute("sum(MP_A)", "")
                            row("MP_N1") = tabla.Compute("sum(MP_N1)", "")
                            row("MP_N2") = tabla.Compute("sum(MP_N2)", "")
                            row("MP_B") = tabla.Compute("sum(MP_B)", "")
                            row("PC_A") = tabla.Compute("sum(PC_A)", "")
                            row("PC_N1") = tabla.Compute("sum(PC_N1)", "")
                            row("PC_N2") = tabla.Compute("sum(PC_N2)", "")
                            row("PC_B") = tabla.Compute("sum(PC_B)", "")
                            row("TI_A") = tabla.Compute("sum(TI_A)", "")
                            row("TI_N1") = tabla.Compute("sum(TI_N1)", "")
                            row("TI_N2") = tabla.Compute("sum(TI_N2)", "")
                            row("TI_B") = tabla.Compute("sum(TI_B)", "")
                        End If
                        'agrupar por pension
                    End If

                End While
                Thread.Sleep(20)
                'If colaentrada.Count > 0 Then
                'HiloDesgloseAgencia(colaentrada)
                'End If

            End While


            Return resultado
        End Function
        Public Function ObtieneDesglosePensionAgenciaOld(ByVal hotel_id As Integer, ByVal fechaini As Date, ByVal fechafin As Date) As DataSet
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim resultado As DataSet = getDataSet(cmd, sqlDesglosePensionAgencia)

            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            'todo obtiene todas las agencias con contrato para ese hotel
            Dim reader As DataTableReader = getDataTable(cmd, sqlClientesConContratosHotel)
            Dim caches As New Hashtable


            While reader.Read

                'por cada agencia obtener su planning diario
                Dim row As DataRow = resultado.Tables(0).Rows.Add
                row("cliente_id") = reader("cliente_id")
                row("agencia") = reader("razon")
                'If row("cliente_id") = 5090 Then
                'row("agencia") = reader("razon")
                'End If

                Dim datos As DataSet = ObtienePlanningDiario(cmd, hotel_id, fechaini, fechafin, 0, reader("cliente_id"))


                Dim tabla As DataTable = datos.Tables(0)
                If tabla.Rows.Count > 0 Then
                    row("SS_A") = tabla.Compute("sum(SS_A)", "")
                    row("SS_N1") = tabla.Compute("sum(SS_N1)", "")
                    row("SS_N2") = tabla.Compute("sum(SS_N2)", "")
                    row("SS_B") = tabla.Compute("sum(SS_B)", "")
                    row("HD_A") = tabla.Compute("sum(HD_A)", "")
                    row("HD_N1") = tabla.Compute("sum(HD_N1)", "")
                    row("HD_N2") = tabla.Compute("sum(HD_N2)", "")
                    row("HD_B") = tabla.Compute("sum(HD_B)", "")
                    row("MP_A") = tabla.Compute("sum(MP_A)", "")
                    row("MP_N1") = tabla.Compute("sum(MP_N1)", "")
                    row("MP_N2") = tabla.Compute("sum(MP_N2)", "")
                    row("MP_B") = tabla.Compute("sum(MP_B)", "")
                    row("PC_A") = tabla.Compute("sum(PC_A)", "")
                    row("PC_N1") = tabla.Compute("sum(PC_N1)", "")
                    row("PC_N2") = tabla.Compute("sum(PC_N2)", "")
                    row("PC_B") = tabla.Compute("sum(PC_B)", "")
                    row("TI_A") = tabla.Compute("sum(TI_A)", "")
                    row("TI_N1") = tabla.Compute("sum(TI_N1)", "")
                    row("TI_N2") = tabla.Compute("sum(TI_N2)", "")
                    row("TI_B") = tabla.Compute("sum(TI_B)", "")
                End If
                'agrupar por pension

            End While

            flushConection(cmd, errorCode)
            Return resultado
        End Function

        Shared BORRAR_sqlHabitacionesBloqueadas As String = "" _
        & " SELECT  count(distinct(habitaciones_bloqueos.habitacion_id))" _
& " FROM reservas Inner Join habitaciones_bloqueos ON habitaciones_bloqueos.reserva_id = reservas.reserva_id " _
& " WHERE reservas.hotel_id = ? AND reservas.estado_reserva_id NOT IN  (0,2) and habitaciones_bloqueos.habitacion_id!=0 " _
& " AND ? BETWEEN  habitaciones_bloqueos.fecha_desde AND DATE_ADD(habitaciones_bloqueos.fecha_hasta, INTERVAL -1 DAY) " _
& " AND (reservas.cliente_id =  ? or ?=0)"
        Shared BORRAR_sqlHabitacionesBloqueadasNueva As String = "" _
        & " SELECT  GROUP_CONCAT(convert(reservas.reserva_id,char)) as reservas" _
& " FROM reservas Inner Join habitaciones_bloqueos ON habitaciones_bloqueos.reserva_id = reservas.reserva_id " _
& " WHERE reservas.hotel_id = ? AND reservas.estado_reserva_id NOT IN  (0,2) and habitaciones_bloqueos.habitacion_id!=0" _
& " AND ? BETWEEN  habitaciones_bloqueos.fecha_desde AND DATE_ADD(habitaciones_bloqueos.fecha_hasta, INTERVAL -1 DAY) " _
& " AND (reservas.cliente_id =  ? or ?=0)"
        Shared BORRAR_sqlHabitacionesBloqueadasNuevaO As String = "" _
        & " SELECT  reservas.reserva_id,habitaciones_bloqueos.habitacion_id" _
& " FROM reservas Inner Join habitaciones_bloqueos ON habitaciones_bloqueos.reserva_id = reservas.reserva_id " _
& " WHERE reservas.hotel_id = ? AND reservas.estado_reserva_id NOT IN  (0,2) and habitaciones_bloqueos.habitacion_id!=0" _
& " AND ? BETWEEN  habitaciones_bloqueos.fecha_desde AND DATE_ADD(habitaciones_bloqueos.fecha_hasta, INTERVAL -1 DAY) " _
& " AND (reservas.cliente_id =  ? or ?=0)"
        Shared sqlHabitacionesBloqueadasRango As String = "" _
        & " SELECT  tipos_habitacion.desvios as desviado,reservas.cliente_id,reservas.reserva_id,reservas.fecha_prevista_llegada,reservas.fecha_prevista_salida,habitaciones.tipo_habitacion_id,habitaciones_bloqueos.habitacion_bloqueo_id," _
& " habitaciones.habitacion_id,habitaciones_bloqueos.fecha_desde,habitaciones_bloqueos.fecha_hasta" _
& " FROM habitaciones inner join tipos_habitacion on tipos_habitacion.tipo_habitacion_id=habitaciones.tipo_habitacion_id Inner Join habitaciones_bloqueos ON habitaciones_bloqueos.habitacion_id = habitaciones.habitacion_id Inner Join reservas ON habitaciones_bloqueos.reserva_id = reservas.reserva_id  " _
& " WHERE reservas.hotel_id = ? AND reservas.estado_reserva_id NOT IN  (0,2) " _
& " AND (reservas.cliente_id =  ? or ?=0 or 1=1) and " _
& " (habitaciones_bloqueos.fecha_desde BETWEEN ? and ? " _
& " or habitaciones_bloqueos.fecha_hasta  BETWEEN ? and ?" _
& " or habitaciones_bloqueos.fecha_desde<=? and habitaciones_bloqueos.fecha_hasta>=?) "

        Shared sqlHabitacionesBloqueadasRangoOld As String = "" _
& " SELECT  reservas.*,habitaciones_bloqueos.*,habitaciones.*" _
& " FROM habitaciones Inner Join habitaciones_bloqueos ON habitaciones_bloqueos.habitacion_id = habitaciones.habitacion_id Inner Join reservas ON habitaciones_bloqueos.reserva_id = reservas.reserva_id  " _
& " WHERE reservas.hotel_id = ? AND reservas.estado_reserva_id NOT IN  (0,2) " _
& " AND (reservas.cliente_id =  ? or ?=0 or 1=1) and " _
& " (habitaciones_bloqueos.fecha_desde BETWEEN ? and ? " _
& " or habitaciones_bloqueos.fecha_hasta  BETWEEN ? and ?" _
& " or habitaciones_bloqueos.fecha_desde<=? and habitaciones_bloqueos.fecha_hasta>=?) "
        Private Function contarDistintasEn(ByVal campo As String, ByVal origen() As DataRow, ByVal destino() As DataRow) As Integer
            Dim arr As New Hashtable
            Dim x As Integer
            Dim quitar As Integer = 0
            Dim xl As Integer = destino.Length - 1
            For x = 0 To xl
                arr((destino(x)(campo))) += 1 ' arr(destino(x)(campo)) + 1
            Next
            xl = origen.Length - 1
            For x = 0 To xl
                If arr.ContainsKey(origen(x)(campo)) Then
                    quitar += 1
                Else
                    arr((origen(x)(campo))) += 1
                End If
                'quitar += arr(origen(x)(campo))
                'arr((origen(x)(campo))) += 1
            Next
            Return quitar
        End Function
        Private Function CalculaCruze(ByVal campo As String, ByVal campovalor As String, ByVal origen As DataTable, ByVal destino() As DataRow, ByVal filtroadvan() As String) As String()
            Dim arr As New Hashtable
            Dim x As Integer
            Dim xl As Integer = origen.Rows.Count - 1
            If filtroadvan(0) <> "" Then
                For x = 0 To xl
                    If origen.Rows(x)(filtroadvan(0)) = filtroadvan(1) Then
                        arr((origen.Rows(x)(campo))) += origen.Rows(x)(campovalor)
                    End If
                Next
            Else
                For x = 0 To xl
                    'If origen.Rows(x)(filtroadvan(0)) = filtroadvan(1) Then
                    arr((origen.Rows(x)(campo))) += origen.Rows(x)(campovalor)
                    'End If
                Next
            End If

            xl = destino.Length - 1
            For x = 0 To xl
                If arr.ContainsKey(destino(x)(campo)) Then
                    arr((destino(x)(campo))) -= 1
                End If
            Next
            Dim enu As IEnumerator = arr.Keys.GetEnumerator


            Dim val As Integer
            Dim cant As Integer
            Dim tmp As String = ""
            While enu.MoveNext
                tmp &= enu.Current & ","
                val = arr(enu.Current)
                If val > 0 Then
                    cant += val
                End If
            End While
            If tmp <> "" Then
                tmp = tmp.Substring(0, tmp.Length - 1)
            End If
            Dim retval(2) As String
            retval(0) = cant
            retval(1) = tmp
            Return retval
        End Function
        Private Function filtraDesvios(ByVal orders As DataTable, ByVal bloqueos As DataSet)
            'encontrar el tipo desvio..a fuego 10
            'filtrar solo los servicios tipos de hab
            'encontrar si tiene alguna habitacion desviada
            'si el desvio es completo cambiar tipo de hab
            'si el desvio es parcial cambiar tipo de hab y crear nueva linea con el resto
            Dim filtroHab As String = "0=0 " '"servicio_id<>0 and unidad_calculo_id=1 and tipo_servicio_id=1 "
            Dim dvb As DataView = New DataView(bloqueos.Tables(0), "desviado=1", "reserva_id", DataViewRowState.CurrentRows)
            If dvb.Count > 0 Then
                'encontrar si tiene alguna habitacion desviada
                'Console.WriteLine(dvb.Count)
                Dim y As Integer
                For y = 0 To dvb.Count - 1
                    Dim rows() As DataRow = orders.Select(filtroHab & " and reserva_id=" & dvb(y).Row("reserva_id"))

                    Dim x As Integer
                    If rows.Length <> 0 Then
                        For x = 0 To rows.Length - 1
                            If rows(x)("fecha_desde") = dvb(y).Row("fecha_desde") And rows(x)("fecha_hasta") = dvb(y).Row("fecha_hasta") Then
                                'si el desvio es completo cambiar tipo de hab
                                rows(x)("cantidad") = 0
                            Else
                                If rows(x)("fecha_desde") <= dvb(y).Row("fecha_desde") And rows(x)("fecha_hasta") >= dvb(y).Row("fecha_hasta") Then
                                    'si el desvio es parcial cambiar tipo de hab y crear nueva linea con el resto
                                    Dim row As DataRow = orders.Rows.Add(rows(x).ItemArray)
                                    row("cantidad") = 0
                                    row("fecha_desde") = dvb(y).Row("fecha_desde")
                                    row("fecha_hasta") = dvb(y).Row("fecha_hasta")

                                    If rows(x)("fecha_desde") = dvb(y).Row("fecha_desde") Or rows(x)("fecha_hasta") = dvb(y).Row("fecha_hasta") Then
                                        'si estan en los bordes 2 tramos
                                        If rows(x)("fecha_desde") = dvb(y).Row("fecha_desde") Then
                                            rows(x)("fecha_desde") = dvb(y).Row("fecha_hasta") '+1?
                                        Else
                                            rows(x)("fecha_hasta") = dvb(y).Row("fecha_desde") '-1?
                                        End If
                                    Else
                                        'si no estan en los bordes 3 tramos
                                        row = orders.Rows.Add(rows(x).ItemArray)
                                        rows(x)("fecha_hasta") = dvb(y).Row("fecha_desde") '-1?
                                        row("fecha_desde") = dvb(y).Row("fecha_hasta") '+1?
                                    End If
                                End If

                            End If
                        Next
                        
                    Else

                    End If
                    
                Next

            End If

        End Function
        Private Function ObtienePlanningDiario(ByVal cmd As Odbc.OdbcCommand, ByVal hotel_id As Integer, ByVal fechaini As Date, ByVal fechafin As Date, ByVal garantia As Integer, Optional ByVal cliente_id As Integer = 0, Optional ByVal tipo_habitacion_id As Integer = 0, Optional ByVal cachedHash As Hashtable = Nothing, Optional ByVal sindesvios As Boolean = False) As DataSet
            Dim errorCode As Integer = 0
            cmd.Parameters.Clear()
            Dim datos As DataSet = getDataSet(cmd, sqlPlaningDiario, True)
            'Dim fechaini As Date
            'Dim fechafin As Date
            If fechaini > fechafin Then
                Dim ft As Date = fechaini
                fechaini = fechafin
                fechafin = ft
            End If
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", cliente_id)
            Dim cliente_id1Param As New Odbc.OdbcParameter("@cliente_id1", cliente_id)
            Dim fechainiParam As New Odbc.OdbcParameter("@fechaini", convertFecha(fechaini))
            Dim fechafinParam As New Odbc.OdbcParameter("@fechafin", convertFecha(fechafin))
            Dim fechaini1Param As New Odbc.OdbcParameter("@fechaini1", convertFecha(fechaini))
            Dim fechafin1Param As New Odbc.OdbcParameter("@fechafin1", convertFecha(fechafin))
            Dim fechaini2Param As New Odbc.OdbcParameter("@fechaini2", convertFecha(fechaini))
            Dim fechafin2Param As New Odbc.OdbcParameter("@fechafin2", convertFecha(fechafin))
            'cmd.Parameters.Add(fechainiParam)
            ' cmd.Parameters.Add(fechafinParam)
            'cmd.Parameters.Add(fechaini1Param)
            'cmd.Parameters.Add(fechafin1Param)
            'cmd.Parameters.Add(fechaini2Param)
            'cmd.Parameters.Add(fechafin2Param)

            cmd.Parameters.Add(hotel_idParam)
            Dim todosParam As New Odbc.OdbcParameter("@todos", 0)
            If sindesvios Then
                todosParam.Value = 0
            Else
                todosParam.Value = 1
            End If
            cmd.Parameters.Add(todosParam)

            Dim datosTiposHab As DataTable = getDataSet(cmd, sqlTipoHabitacionServicioHotel, True).Tables(0)
            'Dim lectorDisp As DataTable = getDataSet(cmd, sqlObtieneHabitacionesHotel).Tables(0)

            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            cmd.Parameters.Add(cliente_idParam)
            cmd.Parameters.Add(cliente_id1Param)
            cmd.Parameters.Add(fechainiParam)
            cmd.Parameters.Add(fechafinParam)
            cmd.Parameters.Add(fechaini1Param)
            cmd.Parameters.Add(fechafin1Param)
            cmd.Parameters.Add(fechaini2Param)
            cmd.Parameters.Add(fechafin2Param)

            cmd.Parameters.Add(todosParam)
            'Dim mea = startMeasure()
            Dim cacheKey As String = hotel_idParam.Value & "_" & cliente_idParam.Value & "_" & fechainiParam.Value & "_" & fechafinParam.Value
            Dim bloqueos As DataSet = Nothing
            Dim lectorD As DataTable
            Dim orders As DataTable
            If Not IsNothing(cachedHash) Then
                If cachedHash.Count > 0 Then
                    bloqueos = cachedHash("bloqueos")
                    lectorD = cachedHash("lectorD")
                    orders = cachedHash("orders")
                End If
            End If
            If IsNothing(bloqueos) Then
                Dim dt As Date = Now


                Dim tmpc As Integer = cliente_idParam.Value
                Dim tmpc1 As Integer = cliente_id1Param.Value
                cliente_idParam.Value = 0
                cliente_id1Param.Value = 0

                bloqueos = getDataSet(cmd, sqlHabitacionesBloqueadasRango, True)
                cliente_idParam.Value = tmpc
                cliente_id1Param.Value = tmpc1
                Dim lector As DataSet = getDataSet(cmd, sqlObtieneReservasValidasEntreFechas)



                lectorD = lector.Tables(0)
                'todo por cada reserva obtener su combinacion de servicios por dia
                Dim reader As DataTableReader = lectorD.CreateDataReader



                cmd.Parameters.Clear()
                Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", 0)
                cmd.Parameters.Add(reserva_idParam)
                orders = New DataTable("dt_tmp")
                Dim matresid As String = "0"
                If reader.Read Then
                    matresid = reader.Item("reserva_id")
                    While reader.Read
                        matresid &= "," & reader.Item("reserva_id")
                    End While
                End If
                Dim ko As String = Replace(sqlTablaReservas, "?", matresid)
                'Dim dtr As DataTable = getDataSet(cmd, ko).Tables(0)
                Dim dtr As DataTableReader = getDataTable(cmd, ko)
                'orders.BeginLoadData()

                orders.Load(preProcesaServicios(dtr))
                filtraDesvios(orders, bloqueos)
                'orders.EndLoadData()
                'Console.WriteLine(orders.Rows.Count)
                If orders.Rows.Count > 0 Or 1 = 1 Then
                    orders.Columns.Add("ucidabre", System.Type.GetType("System.String"), "reserva_id+'-'+unidad_calculo_id+abreviatura")
                    orders.Columns.Add("sumador", System.Type.GetType("System.Int32"), 1)
                End If
                'grabar orders
                'grabar lectorD
                'grabar bloqueos
                If Not IsNothing(cachedHash) Then
                    cachedHash.Add("orders", orders)
                    cachedHash.Add("lectorD", lectorD)
                    cachedHash.Add("bloqueos", bloqueos)
                End If
                Dim xxl As TimeSpan = (Now - dt)
                Console.WriteLine(xxl.ToString)
            End If
            Dim filtroHab As String = "unidad_calculo_id=1 and tipo_servicio_id=1 "
            Dim filtroHabSinTipo As String = filtroHab
            Dim filtipohab As String = ""
            Dim filtroadvan(2) As String
            filtroadvan(0) = ""
            filtroadvan(1) = ""
            If tipo_habitacion_id <> 0 Then
                filtroadvan(0) = "servicio_id"
                filtroadvan(1) = obtieneValorColumna(datosTiposHab, "servicio_id", "tipo_habitacion_id=" & tipo_habitacion_id, "0")
                filtroHab = filtroHab & " and " & filtroadvan(0) & "=" & filtroadvan(1)
                'filtroHabitaciones &= " and "
                filtipohab = "tipo_habitacion_id=" & tipo_habitacion_id & " and "

            End If

            Dim filtroAdultos As String
            Dim filtroPensiones As String
            Dim filtroHabitaciones As String
            Dim filtroHabitacionesSinTipo As String
            Dim filtroHabitacionesLLegadas As String
            Dim filtroHabitacionesSalidas As String
            Dim row As DataRow
            Dim pre_tipo_hab = obtieneValorColumna(datosTiposHab, "desc_corta", "tipo_habitacion_id=" & tipo_habitacion_id, "00")

            While fechaini < fechafin

                'Dim filtroLlegadas = "fecha_prevista_llegada='" & fechaini & "'"
                'Dim filtroSalidas = "fecha_prevista_salida='" & fechaini & "'"
                filtroAdultos = "(fecha_desde <='" & fechaini & "' and fecha_hasta >'" & fechaini & "')"
                filtroPensiones = "tipo_servicio_id=2 and (fecha_desde <='" & fechaini & "' and fecha_hasta >'" & fechaini & "')"
                filtroHabitaciones = filtroHab & " and (fecha_desde <='" & fechaini & "' and fecha_hasta >'" & fechaini & "')"
                filtroHabitacionesSinTipo = filtroHabSinTipo & " and (fecha_desde <='" & fechaini & "' and fecha_hasta >'" & fechaini & "')"
                filtroHabitacionesLLegadas = filtroHab & " and (fecha_desde ='" & fechaini & "' )"
                filtroHabitacionesSalidas = filtroHab & " and (fecha_hasta ='" & fechaini & "' )"
                row = datos.Tables(0).Rows.Add()
                row.Item("SS_A") = 0
                row.Item("SS_N1") = 0
                row.Item("SS_N2") = 0
                row.Item("SS_B") = 0

                row.Item("HD_A") = 0
                row.Item("HD_N1") = 0
                row.Item("HD_N2") = 0
                row.Item("HD_B") = 0

                row.Item("MP_A") = 0
                row.Item("MP_N1") = 0
                row.Item("MP_N2") = 0
                row.Item("MP_B") = 0

                row.Item("PC_A") = 0
                row.Item("PC_N1") = 0
                row.Item("PC_N2") = 0
                row.Item("PC_B") = 0

                row.Item("TI_A") = 0
                row.Item("TI_N1") = 0
                row.Item("TI_N2") = 0
                row.Item("TI_B") = 0

                'row.Item("llegadas") = lectorD.Compute("count(reserva_id)", filtroLlegadas)
                'row.Item("salidas") = lectorD.Compute("count(reserva_id)", filtroSalidas)
                row.Item("fecha") = fechaini.ToString("dd/MM/yyyy") 'fechaini.ToString("dd-MM-yyyy")
                '                row.Item("disponibles") = lectorDisp.Compute("count(habitacion_id)", filtroDisponibles)
                'cambiar por las disponibles a una fecha y no las libres
                'row.Item("disponibles") = ObtieneHabitacionesLibresHotel(cmd, hotel_id, fechaini, fechaini).Tables(0).Rows.Count
                row.Item("PorOcup") = 0
                row.Item("Garantia") = 0


                If cliente_id = 0 Then
                    Dim datmat() As Integer = ObtieneHabitacionesDisponiblesHotelDia(cmd, hotel_id, fechaini, tipo_habitacion_id, sindesvios)
                    row.Item("disponibles") = datmat(0)
                    row.Item("PorOcup") = datmat(1)
                Else
                    Dim datmat() As Integer = ObtieneCupoClienteDia(cmd, hotel_id, cliente_id, fechaini, tipo_habitacion_id)
                    row.Item("disponibles") = datmat(0)
                    row.Item("PorOcup") = datmat(1)
                End If

                'obtener por dia y 
                Dim matucs As Hashtable
                Dim matpen As Hashtable
                'If orders.Rows.Count > 0 Or 1 = 1 Then
                If 1 = 1 Then
                    ''Dim rowtodump() As DataRow = orders.Select(filtroHabitaciones) 'numero de servicios tipo habitacion y uc servicio por dia
                    'Dim xt As Integer
                    'For xt = 0 To rowtodump.Length - 1
                    'Console.WriteLine(rowtodump(xt).Item("cantidad") & "- " & rowtodump(xt).Item("reserva_id") & "- " & rowtodump(xt).Item("fecha_hasta"))
                    'Next
                    Dim totc As Integer = 0
                    Dim rows() As DataRow
                    If garantia = 1 Then
                        rows = orders.Select(filtroHabitaciones, "cliente_id")
                        Dim matcli As Hashtable = AgruparRowsPor(rows, "reserva_id", "cliente_id", "sumador")
                        'Dim arrk(matcli.Values.Count)
                        'matcli.Values.CopyTo(arrk, 0)
                        Dim matcli1 As DataTable = ObtieneCupoClienteDia(cmd, hotel_id, 0, fechaini, tipo_habitacion_id)
                        Dim matcli1Rows() As DataRow
                        If cliente_id <> 0 Then
                            matcli1Rows = matcli1.Select("cliente_id=" & cliente_id)
                        Else
                            matcli1Rows = matcli1.Select("")
                        End If
                        Dim xx As Integer
                        Dim drow As DataRow
                        Dim xxlen As Integer = matcli1Rows.Length - 1
                        For xx = 0 To xxlen
                            drow = matcli1Rows(xx)
                            If drow.Item("garantia") > matcli("" & drow.Item("cliente_id")) Then
                                totc += drow.Item("garantia") - matcli("" & drow.Item("cliente_id"))
                            End If
                            'totc += arrk(xx)
                            'Console.WriteLine(arrk(xx))
                        Next
                    End If
                    row.Item("Garantia") = totc
                    Dim cantc
                    Dim cantc1

                    'todo buscar registros
                    Dim cantlleg = 0
                    Dim cantsalidas = 0
                    cantlleg = orders.Compute("sum(cantidad)", filtroHabitacionesLLegadas)
                    If IsDBNull(cantlleg) Then
                        cantlleg = 0
                    End If
                    Dim filasllegadas() As DataRow = bloqueos.Tables(0).Select(filtipohab & " desviado=0 and fecha_prevista_llegada='" & fechaini & "'")
                    Dim fl As Integer
                    'todo contar habitaciones repetidas?
                    Dim compkit As Integer = 0
                    If 0 = 1 And filasllegadas.Length > 0 Then
                        Dim subkeys As String = ""
                        Dim subkey As String
                        Dim tmpfl() As DataRow
                        Dim flsiz As Integer = filasllegadas.Length - 1
                        For fl = 0 To flsiz
                            subkey = "habitacion_bloqueo_id<>" & filasllegadas(fl)("habitacion_bloqueo_id")
                            tmpfl = bloqueos.Tables(0).Select(filtipohab & subkeys & subkey & " and habitacion_id=" & filasllegadas(fl)("habitacion_id") & " and fecha_desde<='" & fechaini & "' and fecha_hasta>'" & fechaini & "'")
                            If tmpfl.Length > 0 Then
                                If subkeys = "" Then
                                    subkeys = subkey & " and "
                                Else
                                    subkeys = subkeys & subkey & " and "
                                End If

                                cantlleg -= 1
                                compkit += 1
                            End If
                        Next
                    End If
                    Dim akitar As Integer = contarDistintasEn("habitacion_id", filasllegadas, bloqueos.Tables(0).Select(filtipohab & " fecha_desde<'" & fechaini & "' and fecha_hasta>'" & fechaini & "'"))
                    If akitar <> compkit Then
                    End If
                    cantlleg -= akitar

                    cantsalidas = orders.Compute("sum(cantidad)", filtroHabitacionesSalidas)
                    If IsDBNull(cantsalidas) Then
                        cantsalidas = 0
                    End If

                    Dim filassalidas() As DataRow = bloqueos.Tables(0).Select(filtipohab & " desviado=0 and fecha_prevista_salida='" & fechaini & "'")
                    akitar = contarDistintasEn("habitacion_id", filassalidas, bloqueos.Tables(0).Select(filtipohab & " fecha_desde<'" & fechaini & "' and fecha_hasta>'" & fechaini & "'"))
                    cantsalidas -= akitar

                    If 1 = 0 And filassalidas.Length > 0 Then
                        Dim subkeys As String = ""
                        Dim subkey As String
                        Dim tmpfl() As DataRow
                        Dim flsiz As Integer = filassalidas.Length - 1
                        For fl = 0 To flsiz
                            subkey = "habitacion_bloqueo_id<>" & filassalidas(fl)("habitacion_bloqueo_id")
                            tmpfl = bloqueos.Tables(0).Select(filtipohab & subkeys & subkey & " and habitacion_id=" & filassalidas(fl)("habitacion_id") & " and fecha_desde<'" & fechaini & "' and fecha_hasta>='" & fechaini & "'")
                            If tmpfl.Length > 0 Then
                                If subkeys = "" Then
                                    subkeys = subkey & " and "
                                Else
                                    subkeys = subkeys & subkey & " and "
                                End If
                                cantsalidas -= 1
                            End If
                        Next
                    End If
                    row.Item("llegadas") = cantlleg
                    row.Item("salidas") = cantsalidas
                    'filtroHabitacionesSalidas





                    'Dim cantc1ini
                    'cantc1 = orders.Compute("sum(cantidad)", filtroHabitaciones) 'numero de servicios tipo habitacion y uc servicio por dia
                    'If IsDBNull(cantc1) Then
                    'cantc1 = 0
                    'End If
                    'cantc1ini = cantc1
                    'cmd.Parameters.Clear()
                    'cmd.Parameters.Add(hotel_idParam)
                    'fechainiParam.Value = convertFecha(fechaini)
                    'cmd.Parameters.Add(fechainiParam)
                    'cmd.Parameters.Add(cliente_idParam)
                    'cmd.Parameters.Add(cliente_id1Param)

                    'falta tipo hab
                    'Dim readerHabs As DataTableReader = getDataTable(cmd, sqlHabitacionesBloqueadasNuevaO)
                    Dim rowres() As DataRow
                    Dim rowrest() As DataRow
                    'Dim resremove = Me.ExecuteScalar(cmd, sqlHabitacionesBloqueadasNueva)
                    Dim filblo As String = "(cliente_id=" & cliente_id & " or " & cliente_id & "=0) and " & filtipohab & filtroAdultos


                    Dim resmat As String = ""

                    If 1 = 1 Then
                        rowres = bloqueos.Tables(0).Select(filtroAdultos, "habitacion_id")
                        'nueva funcion de cruze-asignacion hab
                        Dim cruzhab As DataTable = New DataView(orders, filtroHabitacionesSinTipo, "reserva_id", DataViewRowState.CurrentRows).ToTable
                        'cruzhab.Columns.Add("sumador", System.Type.GetType("System.Int32"), 1)
                        Dim matcalcu() As String = CalculaCruze("reserva_id", "cantidad", cruzhab, rowres, filtroadvan)
                        If 1 = 0 Then
                            'kk()
                            Dim enut As IEnumerator = rowres.GetEnumerator
                            Dim dr As DataRow
                            Dim drmat() As DataRow
                            While enut.MoveNext()
                                dr = enut.Current
                                drmat = cruzhab.Select(" reserva_id=" & dr("reserva_id") & " and cantidad>0")
                                If drmat.Length > 0 Then
                                    drmat(0)("cantidad") -= 1
                                    'Else
                                    'habitacion asignada de mas?
                                    'Console.WriteLine("comprobar:" & dr("reserva_id"))
                                    'drmat(0)("cantidad") -= 0
                                End If
                            End While
                            rowres = cruzhab.Select(filtroHabitaciones)
                            enut = rowres.GetEnumerator
                            cantc1 = 0
                            While enut.MoveNext()
                                dr = enut.Current
                                If resmat = "" Then
                                    resmat = dr.Item("reserva_id")
                                Else
                                    resmat = resmat & "," & dr.Item("reserva_id")
                                End If
                                'todo sumar solo cantidades positivas
                                cantc1 += dr.Item("cantidad")
                            End While
                        End If
                        'If matcalcu(0) <> cantc1 Then
                        cantc1 = matcalcu(0)
                        resmat = matcalcu(1)
                        'End If

                        'cantc1 = cruzhab.Compute("sum(cantidad)", filtroHabitaciones)
                    End If
                    rowres = bloqueos.Tables(0).Select(filblo, "habitacion_id")
                    cantc = AgruparRowsPor(rowres, "habitacion_id", "habitacion_id", "reserva_id").Count
                    If 1 = 0 Then
                        Dim enu As IEnumerator = rowres.GetEnumerator
                        While enu.MoveNext()
                            'If Not IsNothing(resremove) Then
                            Dim dr As DataRow = enu.Current
                            If resmat = "" Then
                                resmat = dr.Item("reserva_id")
                            Else
                                resmat = resmat & "," & dr.Item("reserva_id")
                            End If
                            rowrest = orders.Select(filtroHabitacionesSinTipo & " and reserva_id =" & dr.Item("reserva_id"))
                            If rowrest.Length > 0 Then
                                Dim xk As Integer
                                For xk = 0 To rowrest.Length - 1
                                    cantc1 -= rowrest(xk)("cantidad")
                                Next
                            End If
                        End While
                    End If

                    'rowres = orders.Select(filtroHabitaciones & " and reserva_id not in (" & resmat & ")") 'numero de servicios tipo habitacion y uc servicio por dia

                    'cantc = ExecuteScalar(cmd, sqlHabitacionesBloqueadas)

                    If IsNothing(cantc) Or IsDBNull(cantc) Then
                        cantc = 0
                    End If
                    If IsNothing(cantc1) Or IsDBNull(cantc1) Then
                        cantc1 = 0
                    End If

                    cantc += cantc1

                    row.Item("ocupadas1") = totc + cantc1
                    row.Item("ocupadas") = totc + cantc
                    'filtrar reservas ke tengan tipo de habitacion
                    Dim filtraReservasPorHab As String = ""
                    If tipo_habitacion_id <> 0 Then
                        Dim rowHabs() As DataRow = orders.Select(filtroHabitaciones)
                        Dim enur As IEnumerator = rowHabs.GetEnumerator
                        Dim dr As DataRow
                        While enur.MoveNext
                            dr = enur.Current
                            filtraReservasPorHab &= dr("reserva_id") & ","
                            'If filtraReservasPorHab = "" Then
                            'filtraReservasPorHab = dr("reserva_id")
                            'Else
                            'filtraReservasPorHab = filtraReservasPorHab & "," & dr("reserva_id")
                            'End If
                        End While
                        If filtraReservasPorHab <> "" Then
                            filtraReservasPorHab = filtraReservasPorHab.Substring(0, filtraReservasPorHab.Length - 1)
                        Else
                            filtraReservasPorHab = "0"
                        End If
                        filtraReservasPorHab = "reserva_id in (" & filtraReservasPorHab & ") and "
                        If resmat <> "" Then
                            filtraReservasPorHab = " reserva_id in (" & resmat & ") and "
                        End If
                    End If
                    rows = orders.Select(filtraReservasPorHab & filtroAdultos, "reserva_id,unidad_calculo_id")

                    'Dim campos As New ArrayList()
                    'campos.Add("reserva_id")
                    'campos.Add("ucidabre")
                    'campos.Add("cantidad")
                    'campos.Add("fecha_desde")
                    'campos.Add("fecha_hasta")
                    'dumpDataTable(rows, campos)

                    matucs = AgruparRowsPor(rows, "reserva_id", "unidad_calculo_id", "cantidad")


                    Dim enuc As IEnumerator = matucs.Keys.GetEnumerator

                    Dim keytot As String = ""
                    Dim keyto As String
                    While enuc.MoveNext
                        keyto = ""
                        Select Case enuc.Current
                            Case 2
                                keyto = "A"
                            Case 3
                                keyto = "N1"
                            Case 4
                                keyto = "N2"
                            Case 5
                                keyto = ""
                        End Select

                        If keyto <> "" Then
                            row.Item("SS_" & keyto) += matucs(enuc.Current)
                            rows = orders.Select(filtraReservasPorHab & filtroPensiones & " and unidad_calculo_id=" & enuc.Current, "reserva_id,ucidabre")
                            matpen = AgruparRowsPor(rows, "reserva_id", "ucidabre", "cantidad", 3)
                            Dim enug As IEnumerator = matpen.Keys.GetEnumerator
                            While enug.MoveNext

                                Try
                                    row.Item("SS_" & keyto) -= matpen(enug.Current)
                                    row.Item(enug.Current & "_" & keyto) += matpen(enug.Current)
                                Catch ex As Exception
                                    Dim k As Integer = 0
                                End Try

                            End While
                        End If

                    End While
                    row.Item("SS_B") = 0    'bebes en solo alojamiento cuenta como zero

                    rows = orders.Select(filtraReservasPorHab & filtroPensiones, "reserva_id,ucidabre")
                    matpen = AgruparRowsPor(rows, "reserva_id", "ucidabre", "cantidad", 3)


                    'por cada ucs obtener las pensiones

                Else
                    matpen = New Hashtable
                    matucs = New Hashtable
                End If
                matpen("SS") += 0
                matpen("HD") += 0
                matpen("MP") += 0
                matpen("PC") += 0
                matpen("TI") += 0

                'matpen("SS") = matpen("A1") + matpen("A2")
                matucs("5") += 0
                matucs("2") += 0
                matucs("3") += 0
                matucs("4") += 0
                matucs("7") += 0

                row.Item("TPax") = matucs("2") + matucs("3") + matucs("4") 'adultos
                row.Item("Adultos") = matucs("2")
                row.Item("Bebes") = matucs("5") 'bebes
                row.Item("Ninos") = matucs("3")  'niños
                row.Item("Ninos2") = matucs("4") 'niños2
                If row.Item("PorOcup") = 0 Then
                    row.Item("PorOcup") = 0
                Else
                    row.Item("PorOcup") = (row.Item("TPax") / row.Item("PorOcup")) * 100
                End If


                matpen("SS") = row.Item("TPax") - matpen("HD") - matpen("MP") - matpen("PC") - matpen("TI")
                Dim x As IEnumerator = matpen.Keys.GetEnumerator()
                While x.MoveNext
                    Try
                        row.Item(x.Current) = matpen(x.Current)
                    Catch ex As Exception
                        
                    End Try

                End While





                If row.IsNull("ocupadas") Then
                    row.Item("ocupadas") = 0
                End If
                If row.IsNull("disponibles") Then
                    row.Item("disponibles") = 0
                End If
                'row.Item("ocupadas") -= row.Item("salidas")
                'row.Item("disponibles") += row.Item("ocupadas")
                row.Item("libres") = row.Item("disponibles") - row.Item("ocupadas")
                If row("disponibles") = 0 Then
                    row.Item("PorHab") = 0
                Else
                    row.Item("PorHab") = Math.Round((row.Item("ocupadas") / row.Item("disponibles")) * 100, 2)
                End If
                'row.Item("TIPO_HABITACION") = obtieneValorColumna(datosTiposHab, "desc_corta", "tipo_habitacion_id=" & tipo_habitacion_id, "00")

                row.Item("TIPO_HABITACION") = pre_tipo_hab
                fechaini = fechaini.AddDays(1)
            End While


            'mea = stopMeasure(mea)

            Return datos
        End Function
        Private Function obtieneValorColumna(ByVal origen As DataTable, ByVal columna As String, ByVal filtro As String, ByVal defecto As String)
            Dim retvalue As String = defecto
            Dim filas() As DataRow = origen.Select(filtro)
            If filas.Length > 0 Then
                If Not filas(0).IsNull(columna) Then
                    retvalue = filas(0).Item(columna)
                End If
            End If
            Return retvalue
        End Function
        Private Function AgruparRowsPor(ByVal rows() As DataRow, ByVal campo1 As String, ByVal campo2 As String, ByVal campo3 As String, Optional ByVal tam As Integer = 0) As Hashtable
            Dim x As Integer
            Dim lid As String = -1
            Dim ucid As String = "-1"
            Dim ucidcant As Single = 0
            Dim matucs As New Hashtable
            Dim acucid As String
            Dim z As Integer = rows.Length - 1
            For x = 0 To z
                acucid = rows(x).Item(campo2)
                'If tam > 0 Then
                'acucid = acucid.Substring(0, tam)
                'End If

                If ucid = "-1" Then
                    ucid = acucid
                    lid = rows(x).Item(campo1)
                    ucidcant = 0
                End If
                If ucid = acucid And lid = rows(x).Item(campo1) And rows(x).Item(campo3) > ucidcant Then
                    ucidcant = rows(x).Item(campo3)
                End If
                If (lid <> rows(x).Item(campo1) Or ucid <> acucid) Then
                    If tam > 0 Then
                        matucs(ucid.Substring(ucid.Length - 2)) += ucidcant
                    Else
                        matucs(ucid) += ucidcant
                    End If

                    ucid = "-1"
                    lid = -1
                    x -= 1
                End If
            Next
            If ucid <> "-1" Then
                If tam > 0 Then
                    matucs(ucid.Substring(ucid.Length - 2)) += ucidcant
                Else
                    matucs(ucid) += ucidcant
                End If
            End If

            Return (matucs)
        End Function
        Public Sub dumpDataTable(ByVal tabla As DataRow(), Optional ByVal campos As ArrayList = Nothing)
            Dim y As Integer
            Dim x As Integer
            If IsNothing(campos) Then
                For y = 0 To tabla.Length - 1
                    For x = 0 To tabla(0).Table.Columns.Count - 1
                        If tabla(y).IsNull(x) Then
                            Console.Write("null ,")
                        Else
                            Try
                                Console.Write(tabla(y).Item(x))
                                Console.Write(" ,")
                            Catch ex As Exception

                            End Try

                        End If

                    Next
                    Console.WriteLine()
                Next
            Else
                For y = 0 To tabla.Length - 1
                    For x = 0 To campos.Count - 1
                        If tabla(y).IsNull(campos(x)) Then
                            Console.Write("null ,")
                        Else
                            Try
                                Console.Write(tabla(y).Item(campos(x)))
                                Console.Write(" ,")
                            Catch ex As Exception

                            End Try

                        End If

                    Next
                    Console.WriteLine()
                Next
            End If


        End Sub
        Public Sub dumpDataTable(ByVal tabla As DataTable)
            Dim readerd As DataTableReader = tabla.CreateDataReader
            Dim x
            While readerd.Read
                For x = 0 To tabla.Columns.Count - 1
                    If readerd.IsDBNull(x) Then
                        Console.Write("null ,")
                    Else
                        Try
                            Console.Write(readerd.Item(x) & " ,")
                        Catch ex As Exception

                        End Try

                    End If

                Next
                Console.WriteLine()
            End While
        End Sub
        Public Function dumpResultado(ByVal resultado As tablaServicios)

            Dim readerd As DataTableReader = resultado.ordenarPor("fecha").ToTable.CreateDataReader
            While readerd.Read
                Console.WriteLine(readerd.Item("fecha_llegada") & "-" & readerd.Item("fecha") & "-" & readerd.Item("descripcion") & "-" & readerd.Item("cantidad") & "-" & readerd.Item("servicio_id") & "-" & readerd.Item("precio") & "-" & readerd.Item("importe") & "-" & readerd.Item("impuesto_id") & "-" & readerd.Item("porc_impuesto"))
            End While
            Return True
        End Function
        Public Function TestDB()
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim x = ExecuteScalar(cmd, "select count(*) from aplicaciones")
            Console.Write("Aplicaciones:" & x)
            flushConection(cmd, errorCode)
            Return errorCode
        End Function

        Public Sub New(ByVal uid As Integer)
            userId = uid
        End Sub

        Public Class BaseCCI
            Private TotalesImpuestos As Hashtable = New Hashtable()
            Private TotalesBases As Hashtable = New Hashtable()
            Public Total As Decimal
            Function agregaImpuesto(ByVal porcentaje As Decimal, ByVal base As Decimal)
                'todo round
                Dim antbase As Decimal = TotalesBases.Item(porcentaje)
                antbase += base
                Total += base
                TotalesBases.Item(porcentaje) = antbase
                Dim cuota As Decimal
                'cuota = Decimal.Round(((porcentaje * base) / 100), 2, MidpointRounding.AwayFromZero)
                cuota = ((porcentaje * base) / 100)
                Total += cuota
                cuota = Decimal.Round(cuota, 2, MidpointRounding.AwayFromZero)
                Dim ant As Decimal = TotalesImpuestos.Item(porcentaje)
                ant += cuota
                'Total += cuota
                TotalesImpuestos.Item(porcentaje) = ant
                Return cuota
            End Function
            Function obtieneImpuestos()
                Dim ar As New ArrayList
                Dim enu As IEnumerator = TotalesBases.Keys.GetEnumerator
                While enu.MoveNext
                    Dim ar1 As New ArrayList
                    ar1.Add(TotalesBases.Item(enu.Current))
                    ar1.Add(enu.Current)
                    ar1.Add(TotalesImpuestos.Item(enu.Current))
                    ar.Add(ar1)
                End While

                Return ar
            End Function
        End Class
        Shared sqlObtieneCierreFechaHotel = "select * from cierres where hotel_id=? and fecha_cierre=?"
        Shared sqlObtieneEmpresaHotel = "select empresa_contable from hoteles,empresas where empresas.empresa_id=hoteles.empresa_id and hotel_id=?"
        Function CrearCierreContable(ByVal fecha As Date, ByVal hotel_id As Integer)
            'comprobar que no se haya generado el cierre contable anteriormente
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = CrearCierreContable(cmd, fecha, hotel_id)
            If Not retVal Then
                errorCode = 1
            End If
            If Not flushConection(cmd, errorCode) Then
                retVal = False
            End If
            Return retVal
        End Function
        Shared sqlDatosFicheroPolicia As String = "SELECT hoteles.hotel,hoteles.ruta_fichero_policia,hoteles.contador_fichero_policia,hoteles.identificador_fichero_policia FROM hoteles WHERE hoteles.hotel_id = ?"
        Shared sqlLineasFicheroPolicia As String = "" _
& " SELECT distinct " _
& " clientes.nif, " _
& "         clientes.tipo_documento_id AS tipo,  " _
& " clientes.fecha_documento, " _
& " clientes.razon, " _
& " clientes.sexo_id, " _
& " clientes.fecha_nacimiento, " _
& " reservas_huespedes.fecha_llegada, " _
& " naciones.nacion " _
& " FROM " _
& " reservas_huespedes " _
& " Inner Join clientes ON reservas_huespedes.cliente_id = clientes.cliente_id " _
& " Inner Join reservas ON reservas.reserva_id = reservas_huespedes.reserva_id " _
& " Inner Join naciones ON clientes.nacion_id = naciones.nacion_id " _
& " WHERE " _
& " reservas.estado_reserva_id >=3 AND" _
& " reservas.hotel_id =  ? AND " _
& " reservas_huespedes.fecha_llegada =  ?"
        Shared sqlIncrementaContadorFicheroPolicia = "update hoteles set contador_fichero_policia=ifnull(contador_fichero_policia,0)+1 WHERE hoteles.hotel_id = ?"
        Function CrearFicheroPolicia(ByVal fecha As Date, ByVal hotel_id As Integer)
            'comprobar que no se haya generado el cierre contable anteriormente
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = CrearFicheroPolicia(cmd, fecha, hotel_id)
            If Not retVal Then
                errorCode = 1
            End If
            If Not flushConection(cmd, errorCode) Then
                retVal = False
            End If
            Return retVal
        End Function
        Private Function CrearFicheroPolicia(ByVal cmd As Odbc.OdbcCommand, ByVal fecha As Date, ByVal hotel_id As Integer) As Boolean
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            cmd.Parameters.Clear()
            Try
                Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
                Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
                cmd.Parameters.Add(hotel_idParam)
                'obtiene parametros fichero policia del hotel
                Dim reader As DataTableReader = getDataTable(cmd, sqlDatosFicheroPolicia)
                cmd.Parameters.Add(fechaParam)
                Dim cierre As DataSet = Me.getDataSet(cmd, sqlObtieneCierreFechaHotel)
                If cierre.Tables(0).Rows.Count > 0 Then
                    ExecuteScalar(cmd, sqlIncrementaContadorFicheroPolicia)
                    While reader.Read
                        'obtiene llegadas de ese dia
                        Dim lineas As DataTableReader = getDataTable(cmd, sqlLineasFicheroPolicia)
                        Dim fp As New FicheroPolicia
                        fp.FicheroPolicia(reader.Item("identificador_fichero_policia"), reader.Item("ruta_fichero_policia"), reader.Item("hotel"), reader.Item("contador_fichero_policia"))
                        While lineas.Read
                            Try
                                Dim razon As String = lineas.Item("razon")
                                Dim matnom() As String = razon.Split(" ")
                                Dim ape1 As String = ""
                                Dim ape2 As String = ""
                                Dim nombre As String = ""
                                If matnom.Length = 1 Then
                                    ape1 = matnom(0)
                                End If
                                If matnom.Length = 2 Then
                                    ape1 = matnom(0)
                                    nombre = matnom(1)
                                End If
                                If matnom.Length = 3 Then
                                    ape1 = matnom(0)
                                    ape2 = matnom(1)
                                    nombre = matnom(2)
                                End If
                                If matnom.Length > 3 Then
                                    ape1 = matnom(0)
                                    ape2 = matnom(1)
                                    nombre = matnom(matnom.Length - 1)
                                End If
                                fp.agregaLinea(lineas.Item("nif"), lineas.Item("tipo"), lineas.Item("fecha_documento"), ape1, ape2, nombre, lineas.Item("sexo_id"), lineas.Item("fecha_nacimiento"), lineas.Item("nacion"), lineas.Item("fecha_llegada"))

                            Catch ex As Exception

                            End Try
                        End While
                        fp.generarFichero()
                        cierre.Tables(0).Rows(0).Item("fichero_policia") = fp.rutas(0)
                        Dim writer As Odbc.OdbcDataAdapter
                        writer = getDataAdapter(cmd, sqlObtieneCierreFechaHotel)
                        writer.Fill(cierre.Tables(0))
                        writer.Update(cierre.Tables(0))
                    End While
                End If

                retVal = True
            Catch ex As Exception

            End Try
            Return retVal
        End Function

        Function CrearCierreContable(ByVal cmd As Odbc.OdbcCommand, ByVal fecha As Date, ByVal hotel_id As Integer)
            'comprobar que no se haya generado el cierre contable anteriormente
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            cmd.Parameters.Clear()
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
            cmd.Parameters.Add(hotel_idParam)
            Dim emp As String = ExecuteScalar(cmd, sqlObtieneEmpresaHotel)
            cmd.Parameters.Add(fechaParam)
            If Not emp Is Nothing Then

                Dim empano As String = emp.Substring(0, 3) & fecha.Year

                Dim cierre As DataSet = Me.getDataSet(cmd, sqlObtieneCierreFechaHotel)

                If cierre.Tables(0).Rows.Count > 0 Then
                    'se podria cerrar
                    'prepara fichero contable
                    If cierre.Tables(0).Rows(0).IsNull("fecha_contabilizacion") Then 'quitar

                        Dim fc As FicheroContabilidad = ObtieneFicheroConta(cmd, empano, hotel_id) '001 empresa '06 año
                        If GeneraAsientosProduccion(cmd, fc) Then
                            If GeneraAsientosFacturas(cmd, fc, "RECEP2") Then
                                'fc.generaImpuestos("RECEP2")
                                If GeneraAsientosMovimientosCaja(cmd, fc, "RECEP3") Then
                                    If GeneraAsientosMovimientosCaja(cmd, fc, "RECEP5") Then
                                        If GeneraAsientosFacturas(cmd, fc, "RECEP4") Then
                                            If fc.generarFichero() Then
                                                'todo actualizar cierre
                                                cierre.Tables(0).Rows(0).Item("fichero_cierre") = fc.rutas(1)
                                                cierre.Tables(0).Rows(0).Item("fecha_contabilizacion") = Now
                                                retVal = True
                                            Else
                                                errorCode = 3 'no pude crear el fichero de cierre
                                                AgregaInfo("CrearCierreContable", "No pude crear el fichero de cierre:" & fecha, -errorCode)
                                            End If
                                        Else
                                            errorCode = 8 'fallo al crear asiento facturas recep4
                                            AgregaInfo("CrearCierreContable", "Fallo al crear asiento facturas recep4:" & fecha, -errorCode)
                                        End If
                                    Else
                                        errorCode = 9 'fallo al crear asiento cajas recep5
                                        AgregaInfo("CrearCierreContable", "Fallo al crear asiento cajas recep5:" & fecha, -errorCode)
                                    End If
                                Else
                                    errorCode = 7 'fallo al crear asiento cajas
                                    AgregaInfo("CrearCierreContable", "Fallo al crear asiento cajas recep3:" & fecha, -errorCode)
                                End If
                            Else
                                errorCode = 6 'fallo al crear asiento facturas
                                AgregaInfo("CrearCierreContable", "Fallo al crear asiento facturas:" & fecha, -errorCode)
                            End If
                        Else
                            errorCode = 5 'fallo al crear asiento produccion
                            AgregaInfo("CrearCierreContable", "Fallo al crear asiento produccion:" & fecha, -errorCode)
                        End If
                    Else
                        errorCode = 2 'ya estaba cerrado
                        AgregaInfo("CrearCierreContable", "Ya estaba cerrado:" & fecha, -errorCode)
                    End If
                Else
                    errorCode = 1 'no hay cierre del hotel
                    AgregaInfo("CrearCierreContable", "No hay cierre del hotel:" & fecha, -errorCode)
                End If
                If errorCode = 0 Then
                    Dim writer As Odbc.OdbcDataAdapter
                    writer = getDataAdapter(cmd, sqlObtieneCierreFechaHotel)
                    writer.Fill(cierre.Tables(0))
                    writer.Update(cierre.Tables(0))
                End If
            Else
                errorCode = 4 'empresa no tiene asignado centro contable
                AgregaInfo("CrearCierreContable", "Empresa no tiene asignado centro contable:" & fecha, -errorCode)
            End If

            'Generar Asientos de Produccion
            'Generar Asientos de Facturas
            'Generar Asientos de Movimientos de Caja

            Return retVal

        End Function
        Shared sqlDatosContablesHotelOld = "select cta_manocorriente,dpto_contable,(select c.cta_contable_anticipo from clientes c where c.empresa_id=hoteles.empresa_id and c.cliente_defecto=1 limit 0,1) as cta_contable_anticipo_defecto,(select c.cta_contable from clientes c where c.empresa_id=hoteles.empresa_id and c.cliente_defecto=1 limit 0,1) as cta_contable_defecto,(select c.dpto_contable from clientes c where c.empresa_id=hoteles.empresa_id and c.cliente_defecto=1 limit 0,1) as dpto_contable_defecto from hoteles where hotel_id=?"
        Shared sqlDatosContablesHotel = "" _
        & " select cta_manocorriente,dpto_contable," _
& " ifnull((select ch.cta_depositos from clientes c inner join clientes_hotel ch on c.cliente_id=ch.cliente_id  where length(ch.cta_depositos)<>0 and ch.hotel_id=hoteles.hotel_id and c.cliente_defecto=1 limit 0,1) ,(select c.cta_depositos from clientes c  where c.empresa_id=hoteles.empresa_id and c.cliente_defecto=1 limit 0,1)) as cta_deposito_defecto, " _
& " ifnull((select ch.cta_anticipos from clientes c inner join clientes_hotel ch on c.cliente_id=ch.cliente_id  where length(ch.cta_anticipos)<>0 and ch.hotel_id=hoteles.hotel_id and c.cliente_defecto=1 limit 0,1) ,(select c.cta_contable_anticipo from clientes c  where c.empresa_id=hoteles.empresa_id and c.cliente_defecto=1 limit 0,1)) as cta_contable_anticipo_defecto, " _
& " ifnull((select ch.cta_contable from clientes c inner join clientes_hotel ch on c.cliente_id=ch.cliente_id  where length(ch.cta_contable)<>0 and ch.hotel_id=hoteles.hotel_id and c.cliente_defecto=1 limit 0,1) ,(select c.cta_contable from clientes c  where c.empresa_id=hoteles.empresa_id and c.cliente_defecto=1 limit 0,1)) as cta_contable_defecto, " _
& " ifnull((select ch.dpto_contable from clientes c inner join clientes_hotel ch on c.cliente_id=ch.cliente_id  where length(ch.dpto_contable)<>0 and ch.hotel_id=hoteles.hotel_id and c.cliente_defecto=1 limit 0,1) ,(select c.dpto_contable from clientes c  where c.empresa_id=hoteles.empresa_id and c.cliente_defecto=1 limit 0,1)) as dpto_contable_defecto " _
& " from hoteles where hotel_id=? "


        Shared sqlApuntesProduccion = "" _
    & "     SELECT" _
    & " lineas_factura.fecha, " _
    & " servicios_hotel.cta_contable," _
    & " servicios_hotel.dpto_contable, " _
    & " round(Sum((lineas_factura.cantidad*ifnull(lineas_factura.precio_produccion,lineas_factura.precio))*100/(100+lineas_factura.porc_impuesto)),2) AS total, " _
    & " lineas_factura.servicio_id " _
    & " FROM " _
    & " lineas_factura " _
    & " Inner Join servicios_hotel ON lineas_factura.hotel_id = servicios_hotel.hotel_id AND lineas_factura.servicio_id = servicios_hotel.servicio_id" _
    & " WHERE  " _
    & " lineas_factura.hotel_id =  ?  and lineas_factura.fecha = ?" _
    & " GROUP BY " _
    & " lineas_factura.servicio_id"
        '   & " Sum(round((lineas_factura.cantidad*ifnull(lineas_factura.precio_produccion,lineas_factura.precio))*100/(100+lineas_factura.porc_impuesto),2)) AS total, " _

        Private Function GeneraAsientosProduccion(ByVal cmd As Odbc.OdbcCommand, ByVal fc As FicheroContabilidad)
            'fc.agregarApunte("ANTICI", signoc, .Item("Fecha_Anticipo"), "", "", .Item("Cta_Cliente_Anticipo"), descriptivoCliente, multiplicador * .Item("Importe"))
            'todo filtrar por sw_produccion

            Dim retValue As Boolean = True
            Dim readerHotel As DataTableReader = getDataTable(cmd, sqlDatosContablesHotel)
            Dim reader As DataTableReader = getDataTable(cmd, sqlApuntesProduccion)
            'Dim reader As DataTableReader = Me.getDataSet(cmd, sqlApuntesProduccion).CreateDataReader
            Dim total As Single = 0
            Dim counter As Integer
            Dim fecha As Date
            While reader.Read And retValue
                counter += 1
                total += reader.Item("total")
                fecha = reader.Item("fecha")

                If reader.IsDBNull(reader.GetOrdinal("dpto_contable")) Or reader.IsDBNull(reader.GetOrdinal("cta_contable")) Then
                    'servicio no tiene los datos contables para ese hotel
                    retValue = False
                Else
                    If reader.Item("total") <> 0 Then
                        fc.agregarApunte("RECEP1", "H", reader.Item("fecha"), "", reader.Item("dpto_contable"), reader.Item("cta_contable"), "PRODUCCION DEL DIA", reader.Item("total"))
                    End If
                End If
            End While
            If counter > 0 And retValue Then
                If readerHotel.Read() Then
                    If readerHotel.IsDBNull(readerHotel.GetOrdinal("dpto_contable")) Or readerHotel.IsDBNull(readerHotel.GetOrdinal("cta_manocorriente")) Then
                        retValue = False
                        'los datos contables estan incompletos
                    Else
                        'redondeo ya que al sumar los singles..pueden salir 3 decimales.
                        total = Math.Round(total, 2, MidpointRounding.AwayFromZero)
                        fc.agregarApunte("RECEP1", "D", fecha, "", readerHotel.Item("dpto_contable"), readerHotel.Item("cta_manocorriente"), "PRODUCCION CREDITO DIA", total)
                    End If
                Else
                    retValue = False
                    'no existen datos contables del hotel
                End If
            End If
            Return retValue
        End Function

        Shared sqlApuntesMovimientosCajaCobros = "" _
    & " SELECT" _
    & " facturas.serie_id, " _
    & " series.abreviatura,facturas.numero_factura, " _
    & " ifnull(facturas.ref_fra2,' ') as ref_fra2, " _
    & " cobros.cobro_id, " _
    & " cobros.hotel_id, " _
    & " cobros.fecha, " _
    & " cobros.tipo_cobro_id, " _
    & " clientes.razon As razon, " _
    & " Sum(lineas_cobro.importe) AS total, " _
    & " ifnull(clientes_hotel.cta_anticipos,clientes.cta_contable_anticipo) AS cta_contable_cliente_anticipo, " _
    & " ifnull(clientes_hotel.cta_depositos,clientes.cta_depositos) AS cta_contable_depositos, " _
    & " ifnull(clientes_hotel.cta_contable,clientes.cta_contable) AS cta_contable_cliente, " _
    & " ifnull(clientes_hotel.dpto_contable,clientes.dpto_contable) AS dpto_contable_cliente, " _
    & " formas_pago_hotel.cta_contable, " _
    & " formas_pago_hotel.dpto_contable, " _
    & " tipos_cobro.descripcion AS descriptivo, " _
    & " (SELECT servicios_hotel.cta_contable FROM lineas_factura Inner Join servicios_hotel ON lineas_factura.servicio_id = servicios_hotel.servicio_id where facturas.serie_id=8 and lineas_factura.factura_id=facturas.factura_id LIMIT 1) as cta_contable_serie, " _
    & " (SELECT servicios_hotel.dpto_contable FROM lineas_factura Inner Join servicios_hotel ON lineas_factura.servicio_id = servicios_hotel.servicio_id where facturas.serie_id=8 and lineas_factura.factura_id=facturas.factura_id LIMIT 1) as dpto_contable_serie, " _
    & " (select cierre_dia from cajas where cajas.caja_id=cobros.caja_id) as cierre_dia " _
    & " FROM " _
    & " cobros " _
    & " Left Join tipos_cobro ON cobros.tipo_cobro_id = tipos_cobro.tipo_cobro_id " _
    & " Left Join lineas_cobro ON lineas_cobro.cobro_id = cobros.cobro_id " _
    & " Left Join facturas ON lineas_cobro.factura_id = facturas.factura_id " _
    & " Left Join clientes_hotel ON clientes_hotel.hotel_id = facturas.hotel_id and clientes_hotel.cliente_id=facturas.cliente_id " _
    & " Left Join clientes ON facturas.cliente_id = clientes.cliente_id " _
    & " Left Join formas_pago_hotel ON cobros.hotel_id = formas_pago_hotel.hotel_id AND cobros.forma_pago_id = formas_pago_hotel.forma_pago_id " _
    & " Inner Join series ON facturas.serie_id = series.serie_id " _
    & " WHERE " _
    & "      cobros.hotel_id =  ? AND " _
    & "      cobros.fecha =  ? " _
    & " GROUP BY" _
    & "      cobros.hotel_id, " _
    & "      cobros.fecha, " _
    & "      cobros.tipo_cobro_id, " _
    & "      cobros.cobro_id, " _
    & "     lineas_cobro.factura_id " _
    & " order by" _
    & " cierre_dia,hotel_id,fecha,tipo_cobro_id,cobro_id,lineas_cobro.factura_id"

        Shared sqlApuntesMovimientosCajaAnticipos = "" _
    & " SELECT      anticipos.anticipo_id, " _
    & "      anticipos.hotel_id, " _
    & "     anticipos.fecha, " _
    & "     anticipos.tipo_anticipo_id, " _
    & "      anticipos.importe AS total, " _
    & "      clientes.cta_contable_anticipo AS cta_contable_cliente_anticipo, " _
    & "      clientes.cta_contable AS cta_contable_cliente, " _
    & "      clientes.dpto_contable AS dpto_contable_cliente, " _
    & "      formas_pago_hotel.cta_contable, " _
    & "      formas_pago_hotel.dpto_contable " _
    & " FROM " _
    & " anticipos " _
    & " Left Join formas_pago_hotel ON anticipos.hotel_id = formas_pago_hotel.hotel_id AND anticipos.forma_pago_id = formas_pago_hotel.forma_pago_id" _
    & " Left Join clientes ON anticipos.cliente_id = clientes.cliente_id " _
    & " WHERE " _
    & "      anticipos.hotel_id =  ? AND " _
    & "      anticipos.fecha =  ? " _
    & " GROUP BY " _
    & "      anticipos.hotel_id, " _
    & "      anticipos.fecha, " _
    & "      anticipos.tipo_anticipo_id, " _
    & "      anticipos.anticipo_id "
        Shared sqlApuntesMovimientosCajaFalSob = "" _
    & " SELECT" _
    & " arqueos_caja.arqueo_id, " _
    & " cajas.hotel_id, " _
    & " arqueos_caja.fecha, " _
    & " lineas_arqueo.importe_teorico-lineas_arqueo.importe_real AS total, " _
    & " ifnull(cajas.cta_contable,hoteles.cta_contable_cajas) AS cta_contable_cliente," _
    & " ifnull(cajas.dpto_contable,hoteles.dpto_contable) AS dpto_contable_cliente, " _
    & " formas_pago_hotel.cta_contable, " _
    & " formas_pago_hotel.dpto_contable,cajas.nombre_caja as descriptivo " _
    & " FROM " _
    & " arqueos_caja " _
    & " Left Join cajas ON arqueos_caja.caja_id = cajas.caja_id " _
    & " Left Join lineas_arqueo ON arqueos_caja.arqueo_id = lineas_arqueo.arqueo_id " _
    & " Left Join formas_pago_hotel ON cajas.hotel_id = formas_pago_hotel.hotel_id AND lineas_arqueo.forma_pago_id = formas_pago_hotel.forma_pago_id" _
    & " Left join hoteles on cajas.hotel_id=hoteles.hotel_id" _
    & " WHERE " _
    & "           cajas.hotel_id =  ? AND  " _
    & "           arqueos_caja.fecha=  ? " _
    & " and arqueos_caja.tipo_arqueo_id=2 " _
    & " GROUP BY  " _
    & " cajas.hotel_id, " _
    & " arqueos_caja.fecha, lineas_arqueo.forma_pago_id," _
    & " arqueos_caja.arqueo_id order by arqueos_caja.arqueo_id"
        Shared sqlApuntesMovimientosCajaDotRet = "" _
    & " SELECT " _
    & " dotaciones.dotacion_id, " _
    & " dotaciones.hotel_id, " _
    & " dotaciones.fecha, " _
    & " dotaciones.tipo_dotacion_id, " _
    & " dotaciones.importe AS total, " _
    & " hoteles.cta_contable_banco AS cta_contable_cliente," _
    & " hoteles.dpto_contable AS dpto_contable_cliente, " _
    & " formas_pago_hotel.cta_contable, " _
    & " formas_pago_hotel.dpto_contable, " _
    & " dotaciones.caja_id,cajas.nombre_caja as descriptivo" _
    & " FROM " _
    & " dotaciones Left Join cajas ON dotaciones.caja_id = cajas.caja_id left Join hoteles ON dotaciones.hotel_id = hoteles.hotel_id  " _
    & " ,formas_pago_hotel " _
    & " WHERE  " _
    & "           dotaciones.hotel_id =  ? AND  " _
    & "           dotaciones.fecha =  ? and formas_pago_hotel.forma_pago_id=1 and formas_pago_hotel.hotel_id=dotaciones.hotel_id" _
    & " GROUP BY  " _
    & "           dotaciones.hotel_id,  " _
    & "          dotaciones.fecha,  " _
    & "           dotaciones.tipo_dotacion_id,  " _
    & "           dotaciones.dotacion_id "
        '   & " left Join formas_pago_empresa ON hoteles.empresa_id = formas_pago_empresa.empresa_id  " _
        Shared sqlApuntesMovimientosCajaGastos = "" _
    & " SELECT " _
    & " gastos.gasto_id, " _
    & " gastos.hotel_id, " _
    & " gastos.fecha, " _
    & " gastos.tipo_gasto_id, " _
    & " gastos.importe AS total, " _
    & " tipos_gasto.cta_contable AS cta_contable_cliente, " _
    & " tipos_gasto.dpto_contable AS dpto_contable_cliente, " _
    & " formas_pago_hotel.cta_contable, " _
    & " formas_pago_hotel.dpto_contable, " _
    & " gastos.caja_id, " _
    & " cajas.nombre_caja AS descriptivo, " _
    & " impuestos.porcentaje, " _
    & " impuestos.cta_contable as imp_cta_contable, " _
    & " impuestos.dpto_contable as imp_dpto_contable " _
    & " FROM " _
    & " gastos " _
    & " Left Join tipos_gasto ON tipos_gasto.tipo_gasto_id = gastos.tipo_gasto_id " _
    & " Left Join cajas ON gastos.caja_id = cajas.caja_id " _
    & " Left Join formas_pago_hotel ON gastos.hotel_id = formas_pago_hotel.hotel_id AND gastos.forma_pago_id = formas_pago_hotel.forma_pago_id" _
    & " left Join impuestos ON gastos.impuesto_id = impuestos.impuesto_id " _
    & " WHERE   " _
    & "                gastos.hotel_id =  ? AND   " _
    & "                gastos.fecha = ? " _
    & " GROUP BY   " _
    & " gastos.hotel_id, " _
    & " gastos.fecha, " _
    & " gastos.tipo_gasto_id, " _
    & " gastos.gasto_id "

        Private Class matrizContable
            Public tipoH As String
            Public tipoD As String
            Public mul As Single
        End Class
        Private Function obtieneMatrizSignoContable(ByVal valor As Single) As matrizContable
            Dim x As New matrizContable
            x.tipoH = "H"
            x.tipoD = "D"
            x.mul = 1
            If valor < 0 Then
                x.tipoH = "D"
                x.tipoD = "H"
                x.mul = -1
            End If
            Return x
        End Function
        Private Function GeneraAsientosMovimientosCaja(ByVal cmd As Odbc.OdbcCommand, ByVal fc As FicheroContabilidad, ByVal apunteDesc As String)
            'todo cambiar
            'cobros
            'todo comprobar cuentas.
            'Dim  apunteDesc= "RECEP3"
            Dim cpparam(cmd.Parameters.Count - 1) As Odbc.OdbcParameter
            cmd.Parameters.CopyTo(cpparam, 0)

            Dim readerHotel As DataTableReader = getDataTable(cmd, sqlDatosContablesHotel)
            readerHotel.Read()
            Dim cta_contable_anticipo_defecto As String = readerHotel.Item("cta_contable_anticipo_defecto")
            Dim cta_contable_defecto As String = readerHotel.Item("cta_contable_defecto")
            Dim dpto_contable_defecto As String = readerHotel.Item("dpto_contable_defecto")
            Dim cta_depositos_defecto As String = readerHotel.Item("cta_deposito_defecto")
            Dim retval As Boolean = True
            Dim errroCode As Integer = 0

            Dim reader As DataTableReader

            If retval Then
                'cobros/devolucion--depositios/dev.depo--cobros anticipos.
                reader = getDataTable(cmd, sqlApuntesMovimientosCajaCobros)
                Dim cobros As New Hashtable
                Dim lcobro_id As Integer = -1
                Dim cta_contable_cliente As String
                Dim dpto_contable_cliente As String
                Dim dpto_contable As String
                Dim cta_contable As String
                Dim campocuenta As String
                Dim fecha As Date
                Dim razon As String
                'Dim matcont As matrizContable
                Dim descrip As String
                If apunteDesc = "RECEP5" Then
                    apunteDesc = "RECEP5"
                End If
                While reader.Read And retval
                    Dim cierre_dia As Integer = reader("cierre_dia")
                    If (apunteDesc = "RECEP3" And cierre_dia = 0) Or (apunteDesc <> "RECEP3" And cierre_dia = 1) Then
                        'no toka en este pase
                    Else
                        If Not cobros.ContainsKey(reader.Item("cobro_id")) Then
                            If lcobro_id <> -1 Then
                                '    matcont = obtieneMatrizSignoContable(cobros(lcobro_id))
                                '   fc.agregarApunte(apunteDesc, matcont.tipoD, fecha, "", dpto_contable, cta_contable, "Cobro " & lcobro_id, cobros(lcobro_id) * matcont.mul, 0, False)
                                'matcont = obtieneMatrizSignoContable(cobros(lcobro_id))
                                'Garra de Javier se pone el nombre del cliente
                                'razon = reader.Item("razon")
                                fc.agregarApunte(apunteDesc, "D", fecha, "", dpto_contable, cta_contable, "Cobro " & lcobro_id & " " & razon, cobros(lcobro_id), 0, False)
                                'fc.agregarApunte(apunteDesc, "D", fecha, "", dpto_contable, cta_contable, "Cobro " & lcobro_id, cobros(lcobro_id), 0, False)
                            End If
                            retval = CambiarEstadoCobro(cmd, reader.Item("cobro_id"), 2, False)
                            If retval Then
                                cobros(reader.Item("cobro_id")) = 0.0
                            End If
                        End If
                        If retval Then
                            cta_contable_cliente = cta_contable_defecto
                            dpto_contable_cliente = dpto_contable_defecto
                            dpto_contable = reader("dpto_contable")
                            cta_contable = reader("cta_contable")
                            campocuenta = "cta_contable_cliente"
                            fecha = reader.Item("fecha")

                            If Not reader.IsDBNull(reader.GetOrdinal(campocuenta)) Then
                                cta_contable_cliente = reader.Item(campocuenta)
                                If Not reader.IsDBNull(reader.GetOrdinal("dpto_contable_cliente")) Then
                                    dpto_contable_cliente = reader.Item("dpto_contable_cliente")
                                End If
                            End If
                            If Not reader.IsDBNull(reader.GetOrdinal("cta_contable_serie")) Then
                                cta_contable_cliente = reader.Item("cta_contable_serie")
                                If Not reader.IsDBNull(reader.GetOrdinal("dpto_contable_serie")) Then
                                    dpto_contable_cliente = reader.Item("dpto_contable_serie")
                                End If
                            End If
                            ' Garra de Javier
                            If reader.Item("serie_id") = 4 Then
                                'no existe ese campo
                                If Not reader.IsDBNull(reader.GetOrdinal("cta_contable_depositos")) Then
                                    cta_contable_cliente = reader.Item("cta_contable_depositos")
                                Else
                                    cta_contable_cliente = cta_depositos_defecto
                                End If
                                If Len(cta_contable_cliente) < 6 Then
                                    cta_contable_cliente = cta_depositos_defecto
                                End If
                                If Len(cta_contable_cliente) < 6 Then
                                    cta_contable_cliente = cta_contable_defecto
                                End If
                            End If

                            If IsNothing(cta_contable_cliente) Or IsNothing(dpto_contable_cliente) Or IsNothing(dpto_contable) Or IsNothing(cta_contable) Then
                                retval = False
                                errroCode = 1   'faltan datos contables
                            Else
                                'todo agrupar por cobro_id
                                'meter los cobros en un hash
                                'actualizar todos los cobros
                                ' Garra de Javier .....En el cobro salga en el nº de documento el nº de factura
                                ' Si es un anticipo o deposito - que será reader.item("numero_factura")-1
                                lcobro_id = reader.Item("cobro_id")
                                cobros(reader.Item("cobro_id")) += reader.Item("total")
                                Dim numero_factura As String
                                If Not reader.IsDBNull(reader.GetOrdinal("numero_factura")) Then
                                    numero_factura = reader.Item("numero_factura")
                                Else
                                    numero_factura = 0
                                End If

                                If reader.Item("serie_id") = 5 Or reader.Item("serie_id") = 4 Then 'anticipos o depositos
                                    descrip = reader.Item("ref_fra2")
                                    If reader.Item("total") < 0 Then
                                        'devolucion del cobro resto 1 a l numero de factura
                                        numero_factura = CInt(numero_factura) - 1
                                    End If
                                Else
                                    descrip = reader.Item("abreviatura") & " " & numero_factura & " " & reader.Item("ref_fra2")
                                End If
                                ' Quieren en el descriptivo el nombre del cliente. Añado por la cara la serie
                                ' Garra de Javier
                                descrip = reader.Item("abreviatura") & " " & reader.Item("razon")
                                'matcont = obtieneMatrizSignoContable(reader.Item("total"))
                                'fc.agregarApunte(apunteDesc, matcont.tipoH, reader.Item("fecha"), "", dpto_contable_cliente, cta_contable_cliente, descrip, reader.Item("total") * matcont.mul, 0, True)
                                'matcont = obtieneMatrizSignoContable(reader.Item("total"))
                                'Añado el numero de factura al apunte
                                If reader.Item("serie_id") = 8 Then
                                    fc.agregarApunte(apunteDesc, "D", reader.Item("fecha"), CStr(numero_factura), dpto_contable_cliente, cta_contable_cliente, descrip, -reader.Item("total"), 0, True)
                                Else
                                    fc.agregarApunte(apunteDesc, "H", reader.Item("fecha"), CStr(numero_factura), dpto_contable_cliente, cta_contable_cliente, descrip, reader.Item("total"), 0, True)
                                End If
                                razon = reader.Item("razon")
                                'todo actualizar estado cobro(s)
                            End If
                        End If
                    End If
                End While
                If retval Then
                    If lcobro_id <> -1 Then
                        'matcont = obtieneMatrizSignoContable(cobros(lcobro_id))
                        'fc.agregarApunte(apunteDesc, matcont.tipoD, fecha, "", dpto_contable, cta_contable, "Cobro " & lcobro_id, cobros(lcobro_id) * matcont.mul, 0, False)
                        'matcont = obtieneMatrizSignoContable(cobros(lcobro_id))
                        fc.agregarApunte(apunteDesc, "D", fecha, "", dpto_contable, cta_contable, "Cobro " & lcobro_id & " " & razon, cobros(lcobro_id), 0, False)
                    End If
                End If
                cmd.Parameters.Clear()
                cmd.Parameters.AddRange(cpparam)
            End If
            If apunteDesc = "RECEP3" Then

                If retval Then
                    'faltantes/sobrantes cajas
                    reader = getDataTable(cmd, sqlApuntesMovimientosCajaFalSob)
                    Dim larqueo As Integer = -1
                    Dim narqueo As Integer = -1
                    While reader.Read And retval
                        narqueo = reader.Item("arqueo_id")
                        Dim tot As Single = 0
                        If Not reader.IsDBNull(reader.GetOrdinal("total")) Then
                            tot = reader.Item("total")
                        End If

                        If tot <> 0 Then
                            Dim cta_contable_cliente As String = Nothing
                            Dim dpto_contable_cliente As String = Nothing
                            Dim dpto_contable As String = Nothing
                            If Not reader.IsDBNull(reader.GetOrdinal("dpto_contable")) Then
                                dpto_contable = reader.Item("dpto_contable")
                            End If
                            Dim cta_contable As String = Nothing
                            If Not reader.IsDBNull(reader.GetOrdinal("cta_contable")) Then
                                cta_contable = reader.Item("cta_contable")
                            End If
                            If Not reader.IsDBNull(reader.GetOrdinal("cta_contable_cliente")) Then
                                cta_contable_cliente = reader.Item("cta_contable_cliente")
                            End If
                            If Not reader.IsDBNull(reader.GetOrdinal("dpto_contable_cliente")) Then
                                dpto_contable_cliente = reader.Item("dpto_contable_cliente")
                            End If

                            If Not retval Or IsNothing(cta_contable_cliente) Or IsNothing(dpto_contable_cliente) Or IsNothing(dpto_contable) Or IsNothing(cta_contable) Then
                                retval = False
                                errroCode = 1   'faltan datos contables
                            Else
                                Dim descrip As String = "SOB "
                                If tot < 0 Then
                                    descrip = "FAL "
                                End If
                                descrip += reader.Item("descriptivo") 'y forma de pago?
                                Dim matcont As matrizContable = obtieneMatrizSignoContable(tot)
                                fc.agregarApunte(apunteDesc, matcont.tipoD, reader.Item("fecha"), "", dpto_contable, cta_contable, descrip, tot * matcont.mul)
                                fc.agregarApunte(apunteDesc, matcont.tipoH, reader.Item("fecha"), "", dpto_contable_cliente, cta_contable_cliente, descrip, tot * matcont.mul)
                                'todo actualizar estado anticipo(s)
                            End If
                        End If
                        If retval And larqueo <> narqueo Then
                            larqueo = narqueo
                            retval = CambiarEstadoArqueo(cmd, narqueo, 1, False)
                            retval = CambiarEstadoArqueo(cmd, narqueo, 2, False)
                        End If
                    End While
                    If retval And larqueo <> narqueo And narqueo <> -1 Then
                        larqueo = narqueo
                        retval = CambiarEstadoArqueo(cmd, narqueo, 1, False)
                        retval = CambiarEstadoArqueo(cmd, narqueo, 2, False)
                    End If
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddRange(cpparam)
                End If


                If retval Then
                    'dotaciones/retiradas fondos
                    reader = getDataTable(cmd, sqlApuntesMovimientosCajaDotRet)
                    While reader.Read And retval
                        Dim cta_contable_cliente As String = Nothing '= cta_contable_defecto
                        Dim dpto_contable_cliente As String = Nothing '= dpto_contable_defecto
                        Dim dpto_contable As String = reader("dpto_contable")
                        Dim cta_contable As String = reader("cta_contable")

                        Dim campocuenta As String = "cta_contable_cliente"
                        If Not reader.IsDBNull(reader.GetOrdinal(campocuenta)) Then
                            cta_contable_cliente = reader.Item(campocuenta)
                            dpto_contable_cliente = reader.Item("dpto_contable_cliente")
                        End If
                        If IsNothing(cta_contable_cliente) Or IsNothing(dpto_contable_cliente) Or IsNothing(dpto_contable) Or IsNothing(cta_contable) Then
                            retval = False
                            errroCode = 1   'faltan datos contables
                        Else
                            Dim descrip As String = "DOTACION "
                            Dim tot = reader.Item("total")
                            If reader.Item("tipo_dotacion_id") = 2 Then 'dev anti
                                tot = -tot
                                descrip = "RETIRADA "
                            End If
                            descrip += reader.Item("descriptivo")
                            Dim matcont As matrizContable = obtieneMatrizSignoContable(tot)
                            fc.agregarApunte(apunteDesc, matcont.tipoD, reader.Item("fecha"), "", dpto_contable, cta_contable, descrip, tot * matcont.mul)
                            fc.agregarApunte(apunteDesc, matcont.tipoH, reader.Item("fecha"), "", dpto_contable_cliente, cta_contable_cliente, descrip, tot * matcont.mul)
                            'todo actualizar estado arqueo(s) una vez
                            retval = CambiarEstadoDotacion(cmd, reader.Item("dotacion_id"), 2, False)

                        End If
                    End While
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddRange(cpparam)
                End If


                If retval Then
                    'gastos
                    reader = getDataTable(cmd, sqlApuntesMovimientosCajaGastos)
                    While reader.Read And retval
                        Dim cta_contable_cliente As String = Nothing '= cta_contable_defecto
                        Dim dpto_contable_cliente As String = Nothing '= dpto_contable_defecto
                        Dim dpto_contable As String = reader("dpto_contable")
                        Dim cta_contable As String = reader("cta_contable")

                        Dim campocuenta As String = "cta_contable_cliente"
                        If Not reader.IsDBNull(reader.GetOrdinal(campocuenta)) Then
                            cta_contable_cliente = reader.Item(campocuenta)
                            dpto_contable_cliente = reader.Item("dpto_contable_cliente")
                        End If
                        If IsNothing(cta_contable_cliente) Or IsNothing(dpto_contable_cliente) Or IsNothing(dpto_contable) Or IsNothing(cta_contable) Then
                            retval = False
                            errroCode = 1   'faltan datos contables
                        Else
                            Dim descrip As String = "GASTOS "
                            Dim tot = reader.Item("total")
                            Dim base As BaseCCI = New BaseCCI


                            'If reader.Item("tipo_dotacion_id") = 2 Then 'dev anti
                            'tot = -tot
                            'descrip = "RETIRADA "
                            'End If
                            descrip += reader.Item("descriptivo")
                            Dim cuota As Single = 0
                            Dim matcont As matrizContable = obtieneMatrizSignoContable(tot)
                            If reader.IsDBNull(reader.GetOrdinal("porcentaje")) Or reader.IsDBNull(reader.GetOrdinal("imp_cta_contable")) Or reader.IsDBNull(reader.GetOrdinal("imp_dpto_contable")) Then
                            Else
                                cuota = base.agregaImpuesto(reader.Item("porcentaje"), tot)
                                fc.agregarApunte(apunteDesc, matcont.tipoD, reader.Item("fecha"), "", reader.Item("imp_cta_contable"), reader.Item("imp_dpto_contable"), descrip, cuota * matcont.mul)
                            End If
                            fc.agregarApunte(apunteDesc, matcont.tipoD, reader.Item("fecha"), "", dpto_contable_cliente, cta_contable_cliente, descrip, (tot - cuota) * matcont.mul)
                            fc.agregarApunte(apunteDesc, matcont.tipoH, reader.Item("fecha"), "", dpto_contable, cta_contable, descrip, tot * matcont.mul)
                            'todo actualizar estado gasto(s) una vez
                            retval = CambiarEstadoGasto(cmd, reader.Item("gasto_id"), 2, False)

                        End If
                    End While
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddRange(cpparam)
                End If
            End If
            Return retval
        End Function

        Private Function GeneraAsientosMovimientosCajaOld(ByVal cmd As Odbc.OdbcCommand, ByVal fc As FicheroContabilidad)
            'todo cambiar
            'cobros
            'todo comprobar cuentas.
            Dim apunteDesc = "RECEP3"
            Dim cpparam(cmd.Parameters.Count - 1) As Odbc.OdbcParameter
            cmd.Parameters.CopyTo(cpparam, 0)

            Dim readerHotel As DataTableReader = getDataTable(cmd, sqlDatosContablesHotel)
            readerHotel.Read()
            Dim cta_contable_anticipo_defecto As String = readerHotel.Item("cta_contable_anticipo_defecto")
            Dim cta_contable_defecto As String = readerHotel.Item("cta_contable_defecto")
            Dim dpto_contable_defecto As String = readerHotel.Item("dpto_contable_defecto")
            Dim retval As Boolean = True
            Dim errroCode As Integer = 0

            Dim reader As DataTableReader

            If retval Then
                'cobros/devolucion--depositios/dev.depo--cobros anticipos.
                reader = getDataTable(cmd, sqlApuntesMovimientosCajaCobros)
                While reader.Read And retval
                    Dim cta_contable_cliente As String = cta_contable_defecto
                    Dim dpto_contable_cliente As String = dpto_contable_defecto
                    Dim dpto_contable As String = reader("dpto_contable")
                    Dim cta_contable As String = reader("cta_contable")

                    Dim campocuenta As String = "cta_contable_cliente"
                    'If reader.Item("tipo_cobro_id") = 5 Then 'anticipo
                    '    'usar cta_contable_anticipo
                    '    'campocuenta = "cta_contable_cliente_anticipo"

                    '    If reader.IsDBNull(reader.GetOrdinal("cta_contable_cliente_anticipo")) Then
                    '        cta_contable = cta_contable_anticipo_defecto
                    '        dpto_contable = dpto_contable_defecto
                    '    Else
                    '        cta_contable = reader.Item("cta_contable_cliente_anticipo")
                    '        dpto_contable = reader.Item("dpto_contable_cliente")
                    '    End If

                    'End If

                    If Not reader.IsDBNull(reader.GetOrdinal(campocuenta)) Then
                        cta_contable_cliente = reader.Item(campocuenta)
                        If Not reader.IsDBNull(reader.GetOrdinal("dpto_contable_cliente")) Then
                            dpto_contable_cliente = reader.Item("dpto_contable_cliente")
                        End If

                    End If


                    If IsNothing(cta_contable_cliente) Or IsNothing(dpto_contable_cliente) Or IsNothing(dpto_contable) Or IsNothing(cta_contable) Then
                        retval = False
                        errroCode = 1   'faltan datos contables
                    Else
                        Dim descrip As String = reader.Item("descriptivo")
                        Dim matcont As matrizContable = obtieneMatrizSignoContable(reader.Item("total"))

                        fc.agregarApunte(apunteDesc, matcont.tipoD, reader.Item("fecha"), "", dpto_contable, cta_contable, descrip, reader.Item("total") * matcont.mul)
                        fc.agregarApunte(apunteDesc, matcont.tipoH, reader.Item("fecha"), "", dpto_contable_cliente, cta_contable_cliente, descrip, reader.Item("total") * matcont.mul)
                        'todo actualizar estado cobro(s)
                        retval = CambiarEstadoCobro(cmd, reader.Item("cobro_id"), 2, False)
                    End If
                End While
                cmd.Parameters.Clear()
                cmd.Parameters.AddRange(cpparam)
            End If

            If retval And 1 = 0 Then  'deshabilitado...los anticipos ya no se generan asi
                'anticipos/dev anticipos
                reader = getDataTable(cmd, sqlApuntesMovimientosCajaAnticipos)
                While reader.Read And retval
                    Dim cta_contable_cliente As String = cta_contable_defecto
                    Dim dpto_contable_cliente As String = dpto_contable_defecto
                    Dim dpto_contable As String = reader("dpto_contable")
                    Dim cta_contable As String = reader("cta_contable")

                    '                    Dim campocuenta As String = "cta_contable_cliente"
                    Dim campocuenta As String = "cta_contable_cliente_anticipo"

                    If reader.IsDBNull(reader.GetOrdinal(campocuenta)) Then
                        cta_contable = cta_contable_anticipo_defecto
                        dpto_contable = dpto_contable_defecto
                    Else
                        cta_contable = reader.Item(campocuenta)
                        dpto_contable = reader.Item("dpto_contable_cliente")
                    End If

                    '                    If Not reader.IsDBNull(reader.GetOrdinal(campocuenta)) Then
                    'cta_contable_cliente = reader.Item(campocuenta)
                    'dpto_contable_cliente = reader.Item("dpto_contable_cliente")
                    'End If
                    If IsNothing(cta_contable_cliente) Or IsNothing(dpto_contable_cliente) Or IsNothing(dpto_contable) Or IsNothing(cta_contable) Then
                        retval = False
                        errroCode = 1   'faltan datos contables
                    Else
                        Dim descrip As String = "ANTICIPO "
                        Dim tot = reader.Item("total")
                        If reader.Item("tipo_anticipo_id") = 2 Then 'dev anti
                            tot = -tot
                            descrip = "DEV.ANTI "
                        End If
                        Dim matcont As matrizContable = obtieneMatrizSignoContable(tot)
                        fc.agregarApunte(apunteDesc, matcont.tipoD, reader.Item("fecha"), "", dpto_contable, cta_contable, descrip, tot * matcont.mul)
                        fc.agregarApunte(apunteDesc, matcont.tipoH, reader.Item("fecha"), "", dpto_contable_cliente, cta_contable_cliente, descrip, tot * matcont.mul)
                        'todo actualizar estado arqueo(s) una vez
                        retval = CambiarEstadoAnticipo(cmd, reader.Item("anticipo_id"), 1, False)
                        retval = CambiarEstadoAnticipo(cmd, reader.Item("anticipo_id"), 2, False)
                    End If
                End While
                cmd.Parameters.Clear()
                cmd.Parameters.AddRange(cpparam)
            End If

            If retval Then
                'faltantes/sobrantes cajas
                reader = getDataTable(cmd, sqlApuntesMovimientosCajaFalSob)
                Dim larqueo As Integer = -1
                Dim narqueo As Integer = -1
                While reader.Read And retval
                    narqueo = reader.Item("arqueo_id")
                    Dim tot As Single = 0
                    If Not reader.IsDBNull(reader.GetOrdinal("total")) Then
                        tot = reader.Item("total")
                    End If

                    If tot <> 0 Then
                        Dim cta_contable_cliente As String = Nothing
                        Dim dpto_contable_cliente As String = Nothing
                        Dim dpto_contable As String = Nothing
                        If Not reader.IsDBNull(reader.GetOrdinal("dpto_contable")) Then
                            dpto_contable = reader.Item("dpto_contable")
                        End If
                        Dim cta_contable As String = Nothing
                        If Not reader.IsDBNull(reader.GetOrdinal("cta_contable")) Then
                            cta_contable = reader.Item("cta_contable")
                        End If
                        If Not reader.IsDBNull(reader.GetOrdinal("cta_contable_cliente")) Then
                            cta_contable_cliente = reader.Item("cta_contable_cliente")
                        End If
                        If Not reader.IsDBNull(reader.GetOrdinal("dpto_contable_cliente")) Then
                            dpto_contable_cliente = reader.Item("dpto_contable_cliente")
                        End If

                        If Not retval Or IsNothing(cta_contable_cliente) Or IsNothing(dpto_contable_cliente) Or IsNothing(dpto_contable) Or IsNothing(cta_contable) Then
                            retval = False
                            errroCode = 1   'faltan datos contables
                        Else
                            Dim descrip As String = "SOB "
                            If tot < 0 Then
                                descrip = "FAL "
                            End If
                            descrip += reader.Item("descriptivo") 'y forma de pago?
                            Dim matcont As matrizContable = obtieneMatrizSignoContable(tot)
                            fc.agregarApunte(apunteDesc, matcont.tipoD, reader.Item("fecha"), "", dpto_contable, cta_contable, descrip, tot * matcont.mul)
                            fc.agregarApunte(apunteDesc, matcont.tipoH, reader.Item("fecha"), "", dpto_contable_cliente, cta_contable_cliente, descrip, tot * matcont.mul)
                            'todo actualizar estado anticipo(s)
                        End If
                    End If
                    If retval And larqueo <> narqueo Then
                        larqueo = narqueo
                        retval = CambiarEstadoArqueo(cmd, narqueo, 1, False)
                        retval = CambiarEstadoArqueo(cmd, narqueo, 2, False)
                    End If
                End While
                If retval And larqueo <> narqueo And narqueo <> -1 Then
                    larqueo = narqueo
                    retval = CambiarEstadoArqueo(cmd, narqueo, 1, False)
                    retval = CambiarEstadoArqueo(cmd, narqueo, 2, False)
                End If
                cmd.Parameters.Clear()
                cmd.Parameters.AddRange(cpparam)
            End If


            If retval Then
                'dotaciones/retiradas fondos
                reader = getDataTable(cmd, sqlApuntesMovimientosCajaDotRet)
                While reader.Read And retval
                    Dim cta_contable_cliente As String = Nothing '= cta_contable_defecto
                    Dim dpto_contable_cliente As String = Nothing '= dpto_contable_defecto
                    Dim dpto_contable As String = reader("dpto_contable")
                    Dim cta_contable As String = reader("cta_contable")

                    Dim campocuenta As String = "cta_contable_cliente"
                    If Not reader.IsDBNull(reader.GetOrdinal(campocuenta)) Then
                        cta_contable_cliente = reader.Item(campocuenta)
                        dpto_contable_cliente = reader.Item("dpto_contable_cliente")
                    End If
                    If IsNothing(cta_contable_cliente) Or IsNothing(dpto_contable_cliente) Or IsNothing(dpto_contable) Or IsNothing(cta_contable) Then
                        retval = False
                        errroCode = 1   'faltan datos contables
                    Else
                        Dim descrip As String = "DOTACION "
                        Dim tot = reader.Item("total")
                        If reader.Item("tipo_dotacion_id") = 2 Then 'dev anti
                            tot = -tot
                            descrip = "RETIRADA "
                        End If
                        descrip += reader.Item("descriptivo")
                        Dim matcont As matrizContable = obtieneMatrizSignoContable(tot)
                        fc.agregarApunte(apunteDesc, matcont.tipoD, reader.Item("fecha"), "", dpto_contable, cta_contable, descrip, tot * matcont.mul)
                        fc.agregarApunte(apunteDesc, matcont.tipoH, reader.Item("fecha"), "", dpto_contable_cliente, cta_contable_cliente, descrip, tot * matcont.mul)
                        'todo actualizar estado arqueo(s) una vez
                        retval = CambiarEstadoDotacion(cmd, reader.Item("dotacion_id"), 2, False)

                    End If
                End While
                cmd.Parameters.Clear()
                cmd.Parameters.AddRange(cpparam)
            End If


            If retval Then
                'gastos
                reader = getDataTable(cmd, sqlApuntesMovimientosCajaGastos)
                While reader.Read And retval
                    Dim cta_contable_cliente As String = Nothing '= cta_contable_defecto
                    Dim dpto_contable_cliente As String = Nothing '= dpto_contable_defecto
                    Dim dpto_contable As String = reader("dpto_contable")
                    Dim cta_contable As String = reader("cta_contable")

                    Dim campocuenta As String = "cta_contable_cliente"
                    If Not reader.IsDBNull(reader.GetOrdinal(campocuenta)) Then
                        cta_contable_cliente = reader.Item(campocuenta)
                        dpto_contable_cliente = reader.Item("dpto_contable_cliente")
                    End If
                    If IsNothing(cta_contable_cliente) Or IsNothing(dpto_contable_cliente) Or IsNothing(dpto_contable) Or IsNothing(cta_contable) Then
                        retval = False
                        errroCode = 1   'faltan datos contables
                    Else
                        Dim descrip As String = "GASTOS "
                        Dim tot = reader.Item("total")
                        Dim base As BaseCCI = New BaseCCI


                        'If reader.Item("tipo_dotacion_id") = 2 Then 'dev anti
                        'tot = -tot
                        'descrip = "RETIRADA "
                        'End If
                        descrip += reader.Item("descriptivo")
                        Dim cuota As Single = 0
                        Dim matcont As matrizContable = obtieneMatrizSignoContable(tot)
                        If reader.IsDBNull(reader.GetOrdinal("porcentaje")) Or reader.IsDBNull(reader.GetOrdinal("imp_cta_contable")) Or reader.IsDBNull(reader.GetOrdinal("imp_dpto_contable")) Then
                        Else
                            cuota = base.agregaImpuesto(reader.Item("porcentaje"), tot)
                            fc.agregarApunte(apunteDesc, matcont.tipoD, reader.Item("fecha"), "", reader.Item("imp_cta_contable"), reader.Item("imp_dpto_contable"), descrip, cuota * matcont.mul)
                        End If
                        fc.agregarApunte(apunteDesc, matcont.tipoD, reader.Item("fecha"), "", dpto_contable_cliente, cta_contable_cliente, descrip, (tot - cuota) * matcont.mul)
                        fc.agregarApunte(apunteDesc, matcont.tipoH, reader.Item("fecha"), "", dpto_contable, cta_contable, descrip, tot * matcont.mul)
                        'todo actualizar estado gasto(s) una vez
                        retval = CambiarEstadoGasto(cmd, reader.Item("gasto_id"), 2, False)

                    End If
                End While
                cmd.Parameters.Clear()
                cmd.Parameters.AddRange(cpparam)
            End If
            Return retval
        End Function
        'prepara fichero
        'Dim fc As FicheroContabilidad = ObtieneFicheroConta(cmd, "00106") '001 empresa '06 año

        'fc.agregarApunte("ANTICI", signoc, .Item("Fecha_Anticipo"), "", "", .Item("Cta_Cliente_Anticipo"), descriptivoCliente, multiplicador * .Item("Importe"))
        'fc.agregarApunte("ANTICI", signob, fecha, "", "", cbanco, descriptivoBanco, total, 1)

        'genera y cierra fichero
        'If errorCode = 0 And fc.NumeroLineas > 1 Then
        'TODO genera lineas de bancos
        'If fc.generarFichero() Then
        'Else
        'no pude crear el fichero plano
        'errorCode = 2
        'End If
        'End If
        Shared sqlApuntesFacturas = "" _
    & " SELECT" _
    & " facturas.Factura_Id,facturas.serie_id," _
    & " ifnull((select clientes_hotel.cta_anticipos from clientes_hotel where clientes_hotel.cliente_id=facturas.cliente_id and clientes_hotel.hotel_id=facturas.hotel_id and length(clientes_hotel.cta_anticipos)<>0) ,(select clientes.cta_contable_anticipo from clientes where clientes.cliente_id=facturas.cliente_id) ) as cta_contable_anticipo,  " _
    & " ifnull((select clientes_hotel.cta_depositos from clientes_hotel where clientes_hotel.cliente_id=facturas.cliente_id and clientes_hotel.hotel_id=facturas.hotel_id and length(clientes_hotel.cta_depositos)<>0) ,(select clientes.cta_depositos from clientes where clientes.cliente_id=facturas.cliente_id) ) as cta_deposito  " _
    & " FROM " _
    & " facturas " _
    & " WHERE " _
    & " facturas.hotel_id =  ? AND " _
    & " facturas.Fecha_Factura =  ? and facturas.estado_factura_id=1 "
        Private Function GeneraAsientosFacturas(ByVal cmd As Odbc.OdbcCommand, ByVal fc As FicheroContabilidad, ByVal asiento As String)
            'todo cambiar
            'todo si asiento=recep4...
            Dim retValue As Boolean = True
            Dim errorCode As Integer = 0
            Dim readerHotel As DataTableReader = getDataTable(cmd, sqlDatosContablesHotel)
            readerHotel.Read()

            If readerHotel.IsDBNull(readerHotel.GetOrdinal("cta_contable_defecto")) Or readerHotel.IsDBNull(readerHotel.GetOrdinal("cta_manocorriente")) Or readerHotel.IsDBNull(readerHotel.GetOrdinal("dpto_contable")) Then
                errorCode = 1 'datos del hotel incompletos
                retValue = False
            Else
                Dim cta_manocorriente As String = readerHotel.Item("cta_manocorriente")

                Dim dpto_contable As String = readerHotel.Item("dpto_contable")
                Dim cta_contable_defecto As String = readerHotel.Item("cta_contable_defecto")
                Dim reader As DataTableReader = getDataTable(cmd, sqlApuntesFacturas)
                Dim hotel_id As Integer = cmd.Parameters(0).Value



                While retValue And reader.Read
                    'cmd.Parameters.Clear()
                    'Dim factura_idParam As New Odbc.OdbcParameter("@factura_id", reader.Item("factura_id"))
                    'cmd.Parameters.Add(factura_idParam)
                    cmd.Parameters(0).Value = reader.Item("factura_id")
                    If asiento = "RECEP4" And reader.Item("serie_id") = 5 Then  'Anticipo
                        cta_manocorriente = readerHotel.Item("cta_contable_anticipo_defecto")
                        If Not reader.IsDBNull(reader.GetOrdinal("cta_contable_anticipo")) Then
                            cta_manocorriente = reader("cta_contable_anticipo")
                        End If
                    End If
                    If asiento = "RECEP4" And reader.Item("serie_id") = 4 Then  'Depositos
                        cta_manocorriente = readerHotel.Item("cta_deposito_defecto")
                        If Not reader.IsDBNull(reader.GetOrdinal("cta_deposito")) Then
                            cta_manocorriente = reader("cta_deposito")
                        End If
                        If Len(cta_manocorriente) = 0 Then  ' No han metido depósitos por ningún lado
                            cta_manocorriente = readerHotel.Item("cta_contable_anticipo_defecto")
                        End If
                    End If
                    'comprobar que factura es valida
                    If (asiento = "RECEP4" And reader.Item("serie_id") >= 4) Or (asiento <> "RECEP4" And reader.Item("serie_id") < 4) Then
                        'If reader.Item("factura_id") = 2631 Then
                        'Dim xk = 0
                        'End If
                        retValue = AgregaApunteDeFactura(cmd, fc, asiento, cta_manocorriente, dpto_contable, cta_contable_defecto)
                        If retValue Then
                            'guardar los parametros

                            fc.generaImpuestos(asiento)
                            fc.CuentasImpuestos.Clear()
                            Dim cpparam(cmd.Parameters.Count - 1) As Odbc.OdbcParameter
                            cmd.Parameters.CopyTo(cpparam, 0)
                            'Console.WriteLine(reader.Item("factura_id"))
                            retValue = CambiarEstadoFactura(cmd, reader.Item("factura_id"), 2, False)
                            'If Not retValue Then
                            'Console.WriteLine(reader.Item("factura_id"))
                            'End If
                            cmd.Parameters.Clear()
                            cmd.Parameters.AddRange(cpparam)
                            'poner los parametros otra vez
                        Else
                            'cmd.Parameters(0).Value = reader.Item("factura_id")
                            'AgregaApunteDeFactura(cmd, fc, asiento, cta_manocorriente, dpto_contable, cta_contable_defecto)
                            AgregaInfo("GeneraAsientosFacturas", "Problema Factura_id:" & reader.Item("factura_id"), -1)
                            Console.WriteLine("apunte jodido")

                        End If
                    End If
                End While
                
                cmd.Parameters(0).Value = hotel_id
            End If

            Return retValue
        End Function
        Shared sqlObtieneDatosFacturaParaApunte = "" _
    & " SELECT " _
    & " facturas.Numero_Factura, " _
    & " lineas_factura.reserva_id AS reserva_id, " _
    & " lineas_factura.precio AS Precio_Base, " _
    & " lineas_factura.cantidad, " _
    & " lineas_factura.porc_impuesto AS Porc_Igic, " _
    & " facturas.Fecha_Factura, " _
    & " facturas.Ref_Fra2, " _
    & " ifnull(clientes_hotel.cta_contable,clientes.cta_contable) AS Cta_Contable_Factura, " _
    & " series.factura AS tipo_factura, " _
    & " series.Abreviatura AS serie, " _
    & " clientes.razon AS Razon_Social, " _
    & " clientes.nif, " _
    & " impuestos.dpto_contable AS Departamento_Contable, " _
    & " impuestos.cta_contable AS CTA_IGIC, " _
    & " facturas.Ref_Fra2 AS Concepto,'NADA' AS Cta_Contable_Concepto,lineas_factura.descripcion " _
    & " FROM " _
    & " facturas " _
    & " left Join clientes_hotel ON clientes_hotel.cliente_Id = facturas.cliente_id and clientes_hotel.hotel_id=facturas.hotel_id" _
    & " left Join lineas_factura ON lineas_factura.factura_id = facturas.Factura_Id " _
    & " left Join impuestos ON lineas_factura.impuesto_id = impuestos.impuesto_id " _
    & " left Join hoteles ON hoteles.empresa_id = impuestos.empresa_id AND hoteles.hotel_id = facturas.hotel_id " _
    & " left Join clientes ON facturas.Cliente_Id = clientes.cliente_id " _
    & " left Join series ON facturas.Serie_id = series.Serie_Id " _
    & " WHERE " _
    & " facturas.Factura_Id =  ? "
        Private Function AgregaApunteDeFactura(ByVal cmd As Odbc.OdbcCommand, ByVal fc As FicheroContabilidad, ByVal asiento As String, ByVal cta_manocorriente As String, ByVal dpto_contable As String, ByVal cta_contable_defecto As String)
            Dim retValue As Boolean = True
            Dim errorCode = 0
            Dim cont As Boolean = False
            cmd.CommandText = sqlObtieneDatosFacturaParaApunte
            Dim reader As DataTableReader
            Dim previousConnectionState As ConnectionState = cmd.Connection.State
            Try
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                Dim basecci As FicheroContabilidad.BaseCCI = fc.preparaBases(1)
                'Me.getDataSet()
                'reader = getDataSet(cmd, sqlObtieneDatosFacturaParaApunte).CreateDataReader()
                reader = readerToDataTable(cmd.ExecuteReader())
                Dim Total As Decimal = 0
                Dim TotalBases As Decimal = 0
                With reader
                    While .Read And retValue
                        ' BI=Precio/(1+(IGIC/100))
                        Dim Base As Double = Math.Round(.Item("Precio_Base") * .Item("Cantidad"), 2, MidpointRounding.AwayFromZero)
                        Total += Base
                        TotalBases += Base
                        'todo idenficar base al D o al H

                        If .IsDBNull(.GetOrdinal("Porc_Igic")) Or .IsDBNull(.GetOrdinal("CTA_IGIC")) Then
                            'falta cuenta igic en esta linea
                            errorCode = 3
                            retValue = False
                        Else
                            fc.agregarBases(basecci, Base, .Item("Porc_Igic"), .Item("CTA_IGIC"))
                        End If
                    End While
                End With
                If retValue Then
                    reader = readerToDataTable(cmd.ExecuteReader())
                    Dim REF2 As String = ""
                    With reader
                        If .Read Then
                            If cont = False Then
                                If .IsDBNull(.GetOrdinal("Ref_Fra2")) Then
                                    REF2 = ""
                                Else
                                    REF2 = .Item("Ref_Fra2")
                                End If

                                If REF2 = "***" Then
                                    REF2 = "*** Num. " + .Item("Numero_Factura")
                                End If
                                Dim descriptivoCliente As String = .Item("Serie") + REF2
                                '.GetOrdinal("serie")
                                ' Modificacion de Javier para que salga ref2 en el asiento de los Anticipos
                                ' Si la serie es No es una factura. En teoría depositos no genera ==> solo anticipos
                                If .Item("tipo_factura") = 0 And Not .IsDBNull(.GetOrdinal("ref_Fra2")) Then ' No es una factura propiamente dicha sino un deposito o anticipo
                                    REF2 = .Item("Ref_Fra2")
                                    If REF2 <> "" Then
                                        descriptivoCliente = REF2
                                    End If
                                End If
                                Dim Cta_Contable_Factura As String = cta_contable_defecto
                                If Not .IsDBNull(.GetOrdinal("Cta_Contable_Factura")) Then
                                    Cta_Contable_Factura = .Item("Cta_Contable_Factura")
                                End If
                                If .IsDBNull(.GetOrdinal("Numero_Factura")) Or Cta_Contable_Factura Is Nothing Or .IsDBNull(.GetOrdinal("serie")) Then
                                    errorCode = 4 'datos de factura incompletos
                                Else
                                    Dim numero_factura As Integer = .Item("Numero_Factura")
                                    If .Item("tipo_factura") = 0 And Total < 0 Then  'Deposito o anticipo
                                        numero_factura -= 1
                                    End If
                                    fc.agregarApunte(asiento, "D", .Item("Fecha_Factura"), CStr(numero_factura), "", Cta_Contable_Factura, descriptivoCliente, Total)
                                    Dim nif As String = ""
                                    If Not IsDBNull(.Item("NIF")) Then
                                        nif = .Item("NIF")
                                    End If
                                    fc.agregarFactura(.Item("Fecha_Factura"), .Item("serie"), .Item("Numero_Factura"), .Item("Razon_Social"), nif, Cta_Contable_Factura)
                                    fc.agregaBase(basecci)
                                    cont = True
                                End If
                            End If
                            If cont Then
                                'Base Imponible
                                Dim concepto As String
                                If Not .IsDBNull(.GetOrdinal("Concepto")) Then
                                    concepto = .Item("Concepto")
                                Else
                                    'concepto = "FACTURA NUM "
                                    concepto = ""
                                End If
                                fc.agregarApunte(asiento, "H", .Item("Fecha_Factura"), .Item("Numero_Factura"), dpto_contable, cta_manocorriente, concepto, basecci.sumaBases)
                            End If

                        End If
                    End With

                    If cont = False Then
                        'no tiene lineas de factura
                        errorCode = 2
                    End If
                End If
            Catch
                errorCode = 1   'error de calculos
            Finally
                If previousConnectionState = ConnectionState.Closed Then
                    cmd.Connection.Close()
                End If
            End Try
            If errorCode = 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        'enlaze contable
        Private Function ObtieneFicheroConta(ByVal cmd As Odbc.OdbcCommand, ByVal EmpresaAno As String, ByVal hotel_id As Integer)
            Dim Empresa As String = EmpresaAno.Substring(0, 3)
            Dim Ano As String = EmpresaAno.Substring(5)
            Dim fc As New FicheroContabilidad
            'todo elegir clase dependiendo de configuracion contable
            'fc.FicheroContabilidad(cargaParametros(cmd, "RUTA_FICHEROS_CONTABLES"), cargaParametros(cmd, "RUTA_BACKUPFICHEROS_CONTABLES"), Empresa, Ano)
            'leer ruta de la tabla empresas
            If ConnectionString = "DSN=geshotel2" Then
                fc.FicheroContabilidad("c:/temp_prueba/", "c:/temp_prueba/", Empresa, Ano, hotel_id, "Gestion Hotelera")
            Else
                fc.FicheroContabilidad("c:/temp/", "c:/temp/", Empresa, Ano, hotel_id, "Gestion Hotelera")
            End If

            Return fc
        End Function
        Dim sqlLLamadasParametros = "" _
& " SELECT" _
& " llamadas_porcentaje_incremento.hotel_id," _
& " llamadas_porcentaje_incremento.porcentaje_incremento_llamadas, " _
& " llamadas_porcentaje_incremento.ruta_entrada, " _
& " llamadas_porcentaje_incremento.ruta_salida, " _
& " llamadas_porcentaje_incremento.servicio_id, " _
& " impuestos.porcentaje as porc_impuesto, " _
& " impuestos.impuesto_id " _
& " FROM " _
& " llamadas_porcentaje_incremento " _
& " Inner Join servicios_hotel ON llamadas_porcentaje_incremento.hotel_id = servicios_hotel.hotel_id AND llamadas_porcentaje_incremento.servicio_id = servicios_hotel.servicio_id " _
& " Inner Join impuestos ON servicios_hotel.impuesto_id = impuestos.impuesto_id " _
& " where llamadas_porcentaje_incremento.hotel_id=? "

        Dim sqlLLamadas = "select * from llamadas where llamada_id=0"
        Dim sqlObtieneHabitacionPorExtension = "" _
& "        SELECT" _
& " habitaciones.habitacion_id " _
& " FROM " _
& " habitaciones " _
& " WHERE " _
& " habitaciones.hotel_id =  ? AND " _
& " habitaciones.extension =  ? "
        Dim sqlExisteLLamada = "" _
& " SELECT " _
& " llamadas.llamada_id " _
& " FROM " _
& " llamadas " _
& " WHERE " _
& " llamadas.hotel_id =  ? AND " _
& " llamadas.extension =  ? AND " _
& " llamadas.fecha_hora =  ? "

        Function ObtieneLLamadasHotel(ByVal hotel_id As Integer)
            Dim retVal As Single = 0
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim fechamin As Date = FechaHotel(cmd, hotel_id)
            'retVal = ObtienePendienteAnticipoReserva(cmd, reserva_id)
            'If retVal > 0 Then
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            Dim extensionParam As New Odbc.OdbcParameter("@extension", "")
            Dim fecha_horaParam As New Odbc.OdbcParameter("@fecha_hora", Now())
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            Dim readerParametros As DataTableReader = getDataTable(cmd, sqlLLamadasParametros)
            Dim ds As DataSet = getDataSet(cmd, sqlLLamadas)
            'Dim fecha As Date
            'Dim fechaset As Boolean = False
            While readerParametros.Read And errorCode = 0
                Dim ruta As String = readerParametros.Item("ruta_entrada")
                'imp quitar
                If ConnectionString = "DSN=geshotel2" Then
                    ruta = "D:/LLAMADAS.DAT.PART"
                End If
                Dim cenclase = New Centralita()
                Dim cenlla As Centralita.Llamada() = cenclase.procesFicheroLlamadas(ruta)
                Dim x As Integer
                Try


                    For x = 0 To cenlla.Length - 1
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(hotel_idParam)
                        cmd.Parameters.Add(extensionParam)
                        cmd.Parameters.Add(fecha_horaParam)
                        extensionParam.Value = cenlla(x).extension
                        fecha_horaParam.Value = cenlla(x).fecha_hora
                        Dim lla_id = Me.ExecuteScalar(cmd, sqlExisteLLamada)
                        If IsNothing(lla_id) Or IsDBNull(lla_id) Then
                            lla_id = 0
                        End If
                        'comprueba si existe linea
                        If lla_id = 0 Then
                            Dim row As DataRow = ds.Tables(0).Rows.Add
                            'row("llamada_id") = 1
                            row("hotel_id") = readerParametros("hotel_id")
                            row("extension") = cenlla(x).extension
                            row("fecha_hora") = cenlla(x).fecha_hora
                            row("duracion") = cenlla(x).duracion
                            row("numero") = cenlla(x).numero
                            row("coste") = cenlla(x).coste + (cenlla(x).coste * readerParametros("porcentaje_incremento_llamadas") / 100)
                            row("porcentaje_incremento") = readerParametros("porcentaje_incremento_llamadas")
                            Dim hab_id = Me.ExecuteScalar(cmd, sqlObtieneHabitacionPorExtension) 'encontrar la habitacion para esa extension
                            If Not IsNothing(hab_id) Then
                                row("habitacion_id") = hab_id
                                Dim fecha_res As Date = cenlla(x).fecha_hora
                                If fecha_res < fechamin Then
                                    fecha_res = New Date(fechamin.Year, fechamin.Month, fechamin.Day, fecha_res.Hour, fecha_res.Minute, fecha_res.Second)
                                End If
                                Dim res_id As ArrayList = ObtieneReservasHabitacion(cmd, row("habitacion_id"), fecha_res.ToShortDateString, fecha_res.ToShortDateString)
                                If Not IsNothing(res_id) Then
                                    'primera reserva cuyo estado no sea 0 or 2
                                    'reserva cuyo estado sea checkin?
                                    If res_id.Count > 0 Then
                                        row("reserva_id") = res_id(0)

                                        Try
                                            Dim dsr As DataSet = preparaDatasetReserva(cmd, row("reserva_id"))
                                            'todo crear reserva_servicio
                                            Dim dr As DataRow = ds.Tables("reservas_servicios").Rows.Add
                                            dr("servicio_reserva_id") = 1
                                            dr("reserva_id") = row("reserva_id")
                                            dr("servicio_id") = readerParametros("servicio_id")
                                            dr("unidad_calculo_id") = 1
                                            dr("cantidad") = 1
                                            dr("fecha_desde") = fecha_res
                                            dr("fecha_hasta") = CDate(fecha_res).AddDays(1)
                                            dr("flag_contrato") = 0
                                            dr("servicio_extra") = 1
                                            dr("precio_servicio") = row("coste")
                                            grabaDatasetReserva(cmd, dsr, row("reserva_id"))
                                        Catch ex As Exception
                                            'si da error ignorarlo..
                                        End Try
                                        Dim fac As Factura
                                        fac = abreFactura(cmd, -1, row("reserva_id"))
                                        fac.factura_id = Nothing


                                        Dim rowlineas As DataRow = agregaLineaFactura(fac)
                                        rowlineas.Item("fecha") = fecha_res ' datos.Tables(0).Rows(0).Item("fecha")
                                        rowlineas.Item("reserva_id") = row("reserva_id")
                                        rowlineas.Item("factura_id") = System.DBNull.Value
                                        rowlineas.Item("contrato_id") = System.DBNull.Value 'dlin.Item("contrato_id")

                                        rowlineas.Item("descripcion") = "Ll. " & row("numero") & " " & convertTime(row("fecha_hora")) & " D:" & convertTime(row("duracion")) ' dlin.Item("descripcion")
                                        rowlineas.Item("cantidad") = 1

                                        rowlineas.Item("hotel_id") = hotel_id
                                        rowlineas.Item("precio") = row("coste") 'quitar posible impuesto
                                        rowlineas.Item("precio_produccion") = rowlineas.Item("precio")
                                        rowlineas.Item("impuesto_id") = readerParametros("impuesto_id")
                                        rowlineas.Item("porc_impuesto") = readerParametros("porc_impuesto")
                                        rowlineas.Item("servicio_id") = readerParametros("servicio_id")
                                        rowlineas.Item("unidad_calculo_id") = 1 'servicio dlin.Item("unidad_calculo_id")
                                        rowlineas.Item("tipo_linea_factura") = "M" 'M o D
                                        rowlineas.Item("pag_factura") = 1
                                        actualizarLineas(fac)
                                        Dim linea_factura_id As Integer = ExecuteScalar(cmd, "SELECT LAST_INSERT_ID()")
                                        row("linea_factura_id") = linea_factura_id
                                        'crear linea de factura sobre esa reserva
                                    End If
                                End If
                            End If

                            'row("linea_factura_id") = 0 'encontrar la habitacion para esa extension
                            'row("reserva_id") = 0 'encontrar la habitacion para esa extension

                            Dim writer As Odbc.OdbcDataAdapter
                            writer = getDataAdapter(cmd, sqlLLamadas)
                            writer.Fill(ds.Tables(0))
                            writer.Update(ds.Tables(0))
                            Dim llamada_id As Integer = ExecuteScalar(cmd, "SELECT LAST_INSERT_ID()")
                            If llamada_id <> 0 Then
                                If Not IsNothing(row("habitacion_id")) And Not IsDBNull(row("habitacion_id")) Then
                                    'errorCode = ActualizarAnticipo(cmd, anticipo_id)
                                    'AgregaInfo("ObtieneLLamadasHotel", "Actualizando llamada:" & llamada_id, -errorCode)
                                End If
                            Else
                                errorCode = 10 'no inserto el registro
                                AgregaInfo("ObtieneLLamadasHotel", "No pudo crear la llamada:" & llamada_id, -errorCode)
                            End If
                        End If
                    Next
                Catch ex As Exception
                    errorCode = 2 'fallo en las lineas de llamadas
                    AgregaInfo("ObtieneLLamadasHotel", "No pudo crear las lineas del hotel:" & hotel_id, -errorCode)
                End Try
                If errorCode = 0 Then
                    If Not cenclase.FinalizaProcesoLLamadas() Then
                        errorCode = 1 'fallo al borrar ficheros llamadas
                    End If
                End If



            End While
            'End If
            flushConection(cmd, errorCode)
            Return retVal

        End Function
        Dim sqlObtienePrimerHuespededReserva = "SELECT clientes.razon FROM reservas_huespedes Inner Join clientes ON reservas_huespedes.cliente_id = clientes.cliente_id WHERE reservas_huespedes.reserva_id = ? LIMIT 1"
        Private Function RefrescaTelefonoHabitacion(ByVal cmd As Odbc.OdbcCommand, ByVal habitacion_id As Integer, Optional ByVal cenclaseExterna As Centralita = Nothing) As Boolean

            Dim retVal As Boolean = False
            Try
                Dim errorCode As Integer = 0
                Dim habitacion_idParam As New Odbc.OdbcParameter("@habitacion_id", habitacion_id)
                'Dim habitacion_id_oldParam As New Odbc.OdbcParameter("@habitacion_id_old", habitacion_id)
                cmd.Parameters.Clear()
                cmd.Parameters.Add(habitacion_idParam)
                Dim readerHabitacion As DataTableReader = getDataTable(cmd, sqlObtineDatosHabitacion)
                While readerHabitacion.Read
                    Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", readerHabitacion("hotel_id"))
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(hotel_idParam)
                    Dim readerParametros As DataTableReader = getDataTable(cmd, sqlLLamadasParametros, True)
                    'obtiene fecha del hotel
                    Dim fecha_hotel As Date = FechaHotel(cmd, readerHabitacion("hotel_id"))
                    'comprobar si esta en una reserva para la fecha del hotel sqlHabitacionEstaBlokeada
                    Dim reservas As ArrayList = ObtieneReservasHabitacion(cmd, habitacion_id, fecha_hotel, fecha_hotel)
                    'todo encontrar la primera reserva en checkin
                    Dim reserva_id As Integer = 0
                    If reservas.Count > 0 Then
                        reserva_id = reservas(0)
                    End If
                    Dim razon = ""
                    If reserva_id <> 0 Then
                        'obtiene el primer huespede reserva
                        Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
                        'Dim reserva_id_oldParam As New Odbc.OdbcParameter("@reserva_id", 0)
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(reserva_idParam)
                        'cmd.Parameters.Add(reserva_id_oldParam)
                        razon = ExecuteScalar(cmd, sqlObtienePrimerHuespededReserva)
                        If IsNothing(razon) Then
                            razon = ""
                        End If
                    End If
                    While readerParametros.Read
                        Dim cenclase As Centralita
                        If IsNothing(cenclaseExterna) Then
                            cenclase = New Centralita()
                            'cenclase.preparaComandosTelefonos(readerParametros.Item("ruta_salida"))
                        Else
                            cenclase = cenclaseExterna
                        End If

                        Dim estado As Char = "O"
                        If readerHabitacion.IsDBNull(readerHabitacion.GetOrdinal("estado_telefono")) Then
                        Else
                            If readerHabitacion("estado_telefono") = 1 Then
                                estado = "I"
                            End If
                        End If
                        If Not readerHabitacion.IsDBNull(readerHabitacion.GetOrdinal("extension")) Then
                            cenclase.agregaComandosTelefonos(readerParametros.Item("ruta_salida"), estado, readerHabitacion("extension"), razon, "20000000")
                        End If
                        If IsNothing(cenclaseExterna) Then
                            cenclase.finalizaComandosTelefonos()
                        End If

                    End While
                    'End If
                End While
                retVal = True
            Catch ex As Exception
                'Console.WriteLine(ex.Message)

            End Try
            Return retVal
        End Function
        Function RefrescaTelefonoHabitacion(ByVal habitacion_id As Integer, Optional ByVal cenclaseExterna As Centralita = Nothing) As Boolean
            Dim retVal As Single = 0
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = RefrescaTelefonoHabitacion(cmd, habitacion_id, cenclaseExterna)
            If Not retVal Then
                errorCode = 1
            End If
            flushConection(cmd, errorCode)
            Return retVal
        End Function
        Dim sqlHabitacionesPendientesProcesar = "" _
& " SELECT " _
& " * " _
& " FROM " _
& " habitaciones " _
& " WHERE " _
& " habitaciones.estado_procesado IS NULL  OR " _
& " habitaciones.estado_procesado =  0 "

        Function RefrescaTelefonosHabitaciones()
            Dim retVal As Single = 0
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim cenclase As Centralita = New Centralita()
            Try
                Dim dshab As DataSet = getDataSet(cmd, sqlHabitacionesPendientesProcesar)
                Dim filas As DataRowCollection = dshab.Tables(0).Rows
                Dim x As Integer
                For x = 0 To filas.Count - 1
                    'Console.WriteLine(x)
                    retVal = RefrescaTelefonoHabitacion(cmd, filas(x)("habitacion_id"), cenclase)
                    If retVal Then
                        filas(x)("estado_procesado") = 1
                    End If

                Next
                Dim writer As Odbc.OdbcDataAdapter
                writer = getDataAdapter(cmd, sqlHabitacionesPendientesProcesar)
                writer.Fill(dshab.Tables(0))
                writer.Update(dshab.Tables(0))
            Catch ex As Exception
                errorCode = 2
            End Try
            If errorCode = 0 Then
                cenclase.finalizaComandosTelefonos()
            End If

            'If Not retVal Then
            'errorCode = 1
            'End If
            flushConection(cmd, errorCode)
            Return retVal
        End Function
        Public Function CambiaEstadoTelefonoHabitacion(ByVal habitacion_id As Integer, ByVal estado As Integer) As Boolean
            Dim retVal As Single = 0
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = CambiaEstadoTelefonoHabitacion(cmd, habitacion_id, estado)
            If Not retVal Then
                errorCode = 1
            End If
            flushConection(cmd, errorCode)
            Return retVal
        End Function

        Private Function CambiaEstadoTelefonoHabitacion(ByVal cmd As Odbc.OdbcCommand, ByVal habitacion_id As Integer, ByVal estado As Integer) As Boolean
            Try
                Dim habitacion_idParam As New Odbc.OdbcParameter("@habitacion_id", habitacion_id)
                cmd.Parameters.Clear()
                cmd.Parameters.Add(habitacion_idParam)
                'habitacion_idParam.Value = habs(x)
                Dim dshab As DataSet = getDataSet(cmd, sqlObtineDatosHabitacion)
                dshab.Tables(0).Rows(0)("estado_procesado") = 0
                dshab.Tables(0).Rows(0)("estado_telefono") = estado
                Dim writer As Odbc.OdbcDataAdapter
                writer = getDataAdapter(cmd, sqlObtineDatosHabitacion)
                writer.Fill(dshab.Tables(0))
                writer.Update(dshab.Tables(0))
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function ActivaTelefonosReserva(ByVal reserva_id As Integer, ByVal estado As Integer) As Boolean
            Dim retVal As Single = 0
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = ActivaTelefonosReserva(cmd, reserva_id, estado)
            If Not retVal Then
                errorCode = 1
            End If
            flushConection(cmd, errorCode)
            Return retVal
        End Function

        Private Function ActivaTelefonosReserva(ByVal cmd As Odbc.OdbcCommand, ByVal reserva_id As Integer, ByVal estado As Integer) As Boolean
            Try
                Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
                'Dim habitacion_idParam As New Odbc.OdbcParameter("@habitacion_id", 0)
                'Dim reserva_id_oldParam As New Odbc.OdbcParameter("@reserva_id", 0)
                cmd.Parameters.Clear()
                cmd.Parameters.Add(reserva_idParam)
                'cmd.Parameters.Add(reserva_id_oldParam)
                Dim readerReserva As DataTableReader = getDataTable(cmd, sqlCabReserva, True)
                While readerReserva.Read
                    'cambiar fechas por fecha del hotel?
                    Dim habs As ArrayList = ObtieneReservasHabitacion(cmd, 0, readerReserva("fecha_prevista_llegada"), readerReserva("fecha_prevista_llegada"), reserva_id)
                    Dim x As Integer
                    For x = 0 To habs.Count - 1
                        If habs(x) <> 0 Then
                            If Not CambiaEstadoTelefonoHabitacion(cmd, habs(x), estado) Then
                                Return False
                            End If
                        End If
                    Next
                End While
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function


        Private Function RecalculaFactura(ByVal cmd As Odbc.OdbcCommand, ByVal factura_id As Integer) As Boolean
            Dim retVal As Boolean = True
            Dim cuota As Decimal = 0
            Dim Total As Decimal = 0
            Try


                cmd.Parameters.Clear()
                Dim factura_idParam As New Odbc.OdbcParameter("@factura_id", factura_id)
                cmd.Parameters.Add(factura_idParam)

                Dim reader As DataTableReader = getDataTable(cmd, sqlObtieneDatosFacturaParaApunte)
                Dim basecci As FicheroContabilidad.BaseCCI = New FicheroContabilidad.BaseCCI(1)
                '                Dim TotalBases As Decimal = 0
                Dim reserva_id As Object = System.DBNull.Value
                Dim tiene_lineas As Boolean = False
                With reader
                    While .Read And retVal
                        ' BI=Precio/(1+(IGIC/100))
                        If Not .IsDBNull(.GetOrdinal("precio_base")) Then
                            tiene_lineas = True
                            If Not .IsDBNull(.GetOrdinal("reserva_id")) Then
                                reserva_id = .Item("reserva_id")
                            End If
                            Dim Base As Decimal = Math.Round(.Item("Precio_Base") * .Item("Cantidad"), 2, MidpointRounding.AwayFromZero)
                            Total += Base
                            If .IsDBNull(.GetOrdinal("Porc_Igic")) Or .IsDBNull(.GetOrdinal("CTA_IGIC")) Then
                                'falta cuenta igic en esta linea
                                'errorCode = 3
                                retVal = False
                            Else
                                basecci.agregaImpuesto(.Item("Porc_Igic"), Base, .Item("CTA_IGIC"))
                                'fc.agregarBases(BaseCCI, Base, .Item("Porc_Igic"), .Item("CTA_IGIC"))
                            End If
                        End If
                    End While
                End With

                'Dim bases As Decimal = 0
                Dim ar As ArrayList = basecci.obtieneImpuestos()
                Dim enu As IEnumerator = ar.GetEnumerator
                While enu.MoveNext
                    ar = enu.Current
                    cuota += ar(2)
                End While


                'Dim enu As IEnumerator = basecci.CuentasImpuestos.Keys.GetEnumerator
                'While enu.MoveNext
                'cuota += basecci.sumaCuotas(enu.Current)
                'End While
                'cortar decimales
                'Total = Decimal.Truncate(Total * 100) / 100
                cuota = Decimal.Truncate(cuota * 100) / 100
                'cuota = Total - cuota
                'calcula el total de la factura
                'calcula su cuota
                'calcula el total producido de esa factura
                'grabar en la cabecera de factura

                Dim ds As DataSet = getDataSet(cmd, sqlCabAbreFactura)
                If tiene_lineas Then
                    ds.Tables(0).Rows(0).Item("Importe_total") = Total
                    ds.Tables(0).Rows(0).Item("Cuota") = cuota
                    ds.Tables(0).Rows(0).Item("reserva_id") = reserva_id
                Else
                    ds.Tables(0).Rows(0).Item("Importe_total") = System.DBNull.Value
                    ds.Tables(0).Rows(0).Item("Cuota") = System.DBNull.Value
                    ds.Tables(0).Rows(0).Item("reserva_id") = System.DBNull.Value

                End If
                Dim writer As Odbc.OdbcDataAdapter
                writer = getDataAdapter(cmd, sqlCabAbreFactura)
                writer.Fill(ds.Tables(0))
                writer.Update(ds.Tables(0))
            Catch ex As Exception
                retVal = False

            End Try
            Return retVal
        End Function
        '        Shared sqlObtieneFacturasNoPendientes = "SELECT distinct facturas.factura_id FROM facturas inner join lineas_factura on facturas.factura_id=lineas_factura.factura_id WHERE facturas.estado_factura_id <> 0"
        Shared sqlObtieneFacturasNoPendientes = "SELECT facturas.factura_id FROM facturas "
        Public Function RecalculaFacturas() As Boolean
            Dim retVal As Boolean = True
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try
                cmd.Parameters.Clear()
                Dim reader As DataTableReader = getDataTable(cmd, sqlObtieneFacturasNoPendientes)
                Dim cont As Integer = 0
                While retVal And reader.Read
                    Dim factura_id As Integer = reader("factura_id")
                    retVal = RecalculaFactura(cmd, factura_id)
                    cont += 1
                    If cont Mod 1000 = 0 Then
                        Console.WriteLine(cont)
                    End If

                End While
            Catch ex As Exception
                retVal = False
            Finally
                If Not retVal Then
                    errorCode = 1
                End If
                flushConection(cmd, errorCode)
            End Try
            Return retVal
        End Function
        'Shared sqlObtieneFacturasConDescuadres = "SELECT facturas.hotel_id,(SELECT min(cajas.caja_id) FROM cajas WHERE cajas.hotel_id=facturas.hotel_id and cajas.cierre_dia = 0) as caja_id,facturas.cliente_id,facturas.factura_id,facturas.Importe_Total,(select sum(l.importe) from lineas_cobro l where l.factura_id=facturas.factura_id) as cobrado,round(sum(lineas_factura.cantidad*lineas_factura.precio),2) totalviejo,facturas.Importe_Total-round(sum(lineas_factura.cantidad*lineas_factura.precio),2) as dif FROM facturas Inner Join lineas_factura ON facturas.factura_id = lineas_factura.factura_id where facturas.Importe_Total<>(select sum(l.importe) from lineas_cobro l where l.factura_id=facturas.factura_id) group by facturas.hotel_id,facturas.cliente_id,facturas.factura_id having Importe_Total<>totalviejo and abs(round(importe_total,2)-round(cobrado,2))>0 and abs(round(importe_total,2)-round(cobrado,2))<1"
        Shared sqlObtieneFacturasConDescuadres = "select facturas.hotel_id,(SELECT min(cajas.caja_id) FROM cajas WHERE cajas.hotel_id=facturas.hotel_id and cajas.cierre_dia = 0) as caja_id,facturas.cliente_id,facturas.factura_id,ifnull(importe_total,0) as total ,round((select sum(importe) from lineas_cobro where lineas_cobro.factura_id=facturas.factura_id),2) as cobrado,ifnull(importe_total,0) -round((select sum(importe) from lineas_cobro where lineas_cobro.factura_id=facturas.factura_id),2) as dif from facturas group by facturas.hotel_id,facturas.cliente_id,facturas.factura_id having  not cobrado is null and  total-cobrado<>0 and abs(total-cobrado)>0 and abs(total-cobrado)<1"
        Public Function ArreglaCobrosFacturas()
            Dim retVal As Boolean = True
            Dim errorCode As Integer = 0
            Dim lhotel_id As Integer = -1
            Dim lcaja_id As Integer = -1
            Dim lcliente_id As Integer = -1
            Dim cobro_id As Integer = -1
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try
                cmd.Parameters.Clear()
                Dim reader As DataTableReader = getDataTable(cmd, sqlObtieneFacturasConDescuadres)
                Dim cont As Integer = 0
                Dim fecha As Date
                While retVal And reader.Read
                    Dim factura_id As Integer = reader("factura_id")
                    fecha = FechaHotel(cmd, reader("hotel_id"))
                    If EstaCajaAbierta(cmd, reader("caja_id"), fecha) Then
                        If reader("hotel_id") <> lhotel_id Or reader("caja_id") <> lcaja_id Or reader("cliente_id") <> lcliente_id Then
                            If cobro_id <> -1 Then
                                'actualizar a 2 el cobro
                                If Not CambiarEstadoCobro(cmd, cobro_id, 2, False, fecha.AddDays(-1)) Then
                                    retVal = False
                                End If
                                cobro_id = -1
                            End If
                            lhotel_id = reader("hotel_id")
                            lcaja_id = reader("caja_id")
                            lcliente_id = reader("cliente_id")
                        End If
                        If cobro_id = -1 Then
                            cobro_id = CrearCobro(cmd, 1, factura_id, reader("caja_id"))
                        Else
                            cobrarFactura(cmd, factura_id, cobro_id, 1, False)
                        End If
                        cont += 1
                        If cont Mod 1000 = 0 Then
                            Console.WriteLine(cont)
                        End If
                    End If
                End While
                If retVal And cobro_id <> -1 Then
                    'actualizar a 2 el cobro
                    If Not CambiarEstadoCobro(cmd, cobro_id, 2, False, fecha.AddDays(-1)) Then
                        retVal = False
                    End If
                    cobro_id = -1
                End If
            Catch ex As Exception
                retVal = False
            Finally
                'retVal = False
                If Not retVal Then
                    errorCode = 1
                End If
                flushConection(cmd, errorCode)
            End Try
            Return retVal

        End Function
        Shared sqlObtieneLineasFacturasTPV = "select * from tickets_hoteles where hotel_id=? and fecha=? order by caja_hotel_id,caja_id"
        Public Function ImportarTpvExternos(ByVal hotel_id As Integer, ByVal fecha As Date)
            Dim retVal As Boolean = True
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try
                'comprobar que no exista cierre contable
                If Not ExisteCierreContable(cmd, hotel_id, fecha) Then
                    'comprobar que exista cierre del tpv
                    If Not ExisteCierreContable(cmd, hotel_id, fecha, True) Then
                        'comprobar que los tpv externos ya esten cerrados
                        If Not ExisteCierreContableTpv(cmd, hotel_id, fecha) Then
                            Dim lineasreader As DataTableReader = getDataTable(cmd, sqlObtieneLineasFacturasTPV)
                            Dim facturaPorCaja As New Hashtable
                            While lineasreader.Read And errorCode = 0
                                'crear 1 factura por caja tpv y por caja del hotel
                                'cobrar la factura con todas las formas de pago (comprobar caja abierta)
                                'comprobar que no queda importe pendiente en las facturas creadas
                                'marcar importacion de datos tpv para ese hotel y fecha
                            End While

                        Else
                            errorCode = 4
                            AgregaInfo("ImportarTpvExternos", "Los tpv externos no estan cerrados:" & hotel_id, -errorCode)
                        End If

                    Else
                        errorCode = 3
                        AgregaInfo("ImportarTpvExternos", "Ya se han importado los tpv externos:" & hotel_id, -errorCode)
                    End If

                Else
                    errorCode = 2
                    AgregaInfo("ImportarTpvExternos", "Ya esta cerrado el hotel:" & hotel_id, -errorCode)
                End If
            Catch ex As Exception
                retVal = False
            End Try

            If Not retVal Then
                errorCode = 1
            End If
            flushConection(cmd, errorCode)
            Return retVal
        End Function
        Shared sqlCrearReserva = "select * from reservas where reserva_id=?"
        Shared sqlCrearLineasReserva = "select * from reservas_servicios where reserva_id=?"
        Function CrearReservas(ByVal reserva_id As Integer, ByVal numero As Integer)
            'crear reserva
            'darle checkin
            'hacer checkout automatico de reservas con errores
            'cerrar todos los checkout
            'todo utilizar una reserva como plantilla y solo cambiar cantidades
            'cantidades entre 1 y 4
            'fechas entre 5 y 15 dias
            'hotel 4
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
            cmd.Parameters.Add(reserva_idParam)
            Dim dscab As DataSet = Me.getDataSet(cmd, sqlCrearReserva)
            Dim dslin As DataSet = Me.getDataSet(cmd, sqlCrearLineasReserva)
            Dim rowcab As DataRow = dscab.Tables(0).Rows(0)
            Dim rowlin As DataRow
            Dim x As Integer
            Dim fini As Date
            Dim ffin As Date
            Dim nfil As Integer = dslin.Tables(0).Rows.Count - 1
            Dim randObj As Random = New Random(0)
            Dim oldcants As New Hashtable
            For x = 0 To numero

                fini = New Date(2008, 1 + (Rnd() * 11), 1 + (Rnd() * 26))
                ffin = fini.AddDays(Rnd() * 15 + 5)
                ffin = New Date(ffin.Year, ffin.Month, ffin.Day)
                If ffin.Year = 2009 Then
                    ffin = New Date(2008, 12, 31)
                End If
                Dim dt As DataTable = ObtieneHabitacionesLibresHotel(cmd, rowcab("hotel_id"), fini, ffin).Tables(0)
                If dt.Rows.Count > 0 Then
                    Console.WriteLine(x)
                    rowcab.BeginEdit()
                    rowcab("fecha_prevista_llegada") = fini
                    rowcab("fecha_prevista_salida") = ffin

                    rowcab.SetAdded()
                    rowcab.EndEdit()
                    Dim writer As Odbc.OdbcDataAdapter
                    writer = getDataAdapter(cmd, sqlCrearReserva)
                    writer.Fill(dscab.Tables(0))
                    writer.Update(dscab.Tables(0))
                    reserva_id = ExecuteScalar(cmd, "SELECT LAST_INSERT_ID()")
                    'actualizar todos los servicios
                    Dim y As Integer
                    For y = 0 To nfil
                        rowlin = dslin.Tables(0).Rows(y)
                        rowlin.BeginEdit()
                        'rowlin("servicio_reserva_id") = System.DBNull.Value
                        If oldcants(rowlin("servicio_reserva_id")) Then
                            rowlin("cantidad") = oldcants(rowlin("servicio_reserva_id"))
                        Else
                            oldcants(rowlin("servicio_reserva_id")) = rowlin("cantidad")
                        End If
                        rowlin("reserva_id") = reserva_id
                        rowlin("cantidad") = randObj.Next(1, rowlin("cantidad"))
                        'mas tarde cambio cantidades
                        rowlin.SetAdded()
                        rowlin.EndEdit()
                    Next
                    writer = getDataAdapter(cmd, sqlCrearLineasReserva)
                    writer.Fill(dslin.Tables(0))
                    writer.Update(dslin.Tables(0))
                    'asignarle una habitacion a la reserva


                    Dim err = 0
                    Dim cycle As Integer = 0
                    While err = 0 And dt.Rows.Count > 0
                        Dim hab As Integer = dt.Rows(0).Item("habitacion_id")
                        dt.Rows.Remove(dt.Rows(0))
                        err = bloqueaHabitacion(cmd, hab, fini, ffin, False, reserva_id)
                        cycle += 1
                    End While
                    If cycle > 1 Then
                        MsgBox("har")
                    End If
                    If err = 0 Then
                        x = numero
                    End If
                Else
                    x -= 1
                End If

                'darle al checkin de esa reserva
                'CambiarEstadoReserva(cmd, reserva_id, 3, False)
            Next
            flushConection(cmd, 0)
            Return True
        End Function
        Shared sqlcrearcierresquery = "SELECT reserva_id FROM reservas WHERE hotel_id =  ? AND fecha_prevista_salida =  ?"
        Shared sqlcrearcierresquery1 = "SELECT reserva_id FROM reservas WHERE hotel_id =  ? AND fecha_prevista_llegada =  ?"

        Sub CrearCierres(ByVal hotel_id As Integer, ByVal ano As Integer)
            Dim fini As Date = New Date(ano, 5, 20)
            Dim fec As Integer
            Dim fecha As Date
            For fec = 0 To 31
                'obtiene reservas ke acaban este dia
                'y se hace checkout automatico
                'gesclase.CambiarEstadoReserva(resid, 5, False)

                flushCache()
                fecha = fini.AddDays(fec)
                Dim cmd As Odbc.OdbcCommand = prepareConection()
                Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
                Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
                Dim reserva_idParam As New Odbc.OdbcParameter("@fecha", 0)
                Dim salidas As Integer = 0
                Dim llegadas As Integer = 0
                Dim facturas As Integer = 0
                cmd.Parameters.Clear()
                cmd.Parameters.Add(hotel_idParam)
                cmd.Parameters.Add(fechaParam)
                Dim reader As DataTableReader = getDataTable(cmd, sqlcrearcierresquery)
                While reader.Read
                    CambiarEstadoReserva(cmd, reader("reserva_id"), 5, False)
                    CambiarEstadoReserva(cmd, reader("reserva_id"), 5, False)
                    'todo obtener las facturas de esa reserva y cobrarlas
                    cmd.Parameters.Clear()
                    reserva_idParam.Value = reader("reserva_id")
                    cmd.Parameters.Add(reserva_idParam)
                    Dim readerfac As DataTableReader = getDataTable(cmd, sqlObtieneFacturasReserva)
                    While readerfac.Read
                        'Dim cobro_id As Integer = CrearCobro(cmd, 1, readerfac("factura_id"), 6)
                        'CambiarEstadoCobro(cmd, cobro_id, 1, False)
                        facturas += 1
                    End While

                    salidas += 1
                End While
                cmd.Parameters.Clear()
                cmd.Parameters.Add(hotel_idParam)
                cmd.Parameters.Add(fechaParam)
                reader = getDataTable(cmd, sqlcrearcierresquery1)

                While reader.Read
                    CambiarEstadoReserva(cmd, reader("reserva_id"), 3, False)
                    llegadas += 1
                End While

                flushConection(cmd, 0)
                Dim mea = startMeasure()
                generaLineasFacturas(fecha, hotel_id)
                Console.Write("dia:" & fecha & ": llegadas: " & llegadas & "- salidas:" & salidas)
                stopMeasure(mea)
            Next
        End Sub
        Public Shared Function ConvertToHtmlFile(ByVal targetTable As DataTable) As String
            Dim myHtmlFile As String = ""

            If (targetTable Is Nothing) Then
                Throw New System.ArgumentNullException("targetTable")
            Else
                'Continue.
            End If

            'Get a worker object.
            Dim myBuilder As System.Text.StringBuilder = New System.Text.StringBuilder()

            'Open tags and write the top portion.

            myBuilder.Append("<table border='1px' cellpadding='5' cellspacing='0' ")
            myBuilder.Append("style='border: solid 1px Silver; ffont-size: x-small;'>")

            'Add the headings row.
            myBuilder.Append("<th align='left' valign='top'>" & targetTable.TableName & "<th>")
            myBuilder.Append("<tr align='left' valign='top'>")

            For Each myColumn As DataColumn In targetTable.Columns
                myBuilder.Append("<td align='left' valign='top'>")
                myBuilder.Append(myColumn.ColumnName)
                myBuilder.Append("</td>")
            Next myColumn

            myBuilder.Append("</tr>")


            'Add the data rows.
            For Each myRow As DataRow In targetTable.Rows
                myBuilder.Append("<tr align='left' valign='top'>")

                For Each myColumn As DataColumn In targetTable.Columns
                    myBuilder.Append("<td align='left' valign='top'>")
                    myBuilder.Append(myRow(myColumn.ColumnName).ToString())
                    myBuilder.Append("</td>")
                Next myColumn


                myBuilder.Append("</tr>")
            Next myRow

            'Close tags.
            myBuilder.Append("</table>")
            'Get the string for return.
            myHtmlFile = myBuilder.ToString()

            Return myHtmlFile
        End Function

        Shared sqlISTACabecera As String = "select empresas.empresa as RAZON_SOCIAL," _
& " cabecera.hotel as NOMBRE_ESTABLECIMIENTO, " _
& " replace(empresas.cif,'-','') as CIF_NIF," _
& " cabecera.numero_registro_ista as NUMERO_REGISTRO, " _
& " cabecera.direccion as DIRECCION, " _
& " cabecera.zip as CODIGO_POSTAL, " _
& " cabecera.poblacion as LOCALIDAD, " _
& " cabecera.municipio_ista as MUNICIPIO, " _
& " provincias.provincia as PROVINCIA, " _
& " replace(replace(replace(cabecera.telefono,')',''),'(',''),' ','') as TELEFONO_1, " _
& " replace(replace(replace(cabecera.telefono,')',''),'(',''),' ','') as TELEFONO_2, " _
& " replace(replace(replace(cabecera.fax,')',''),'(',''),' ','') as FAX_1, " _
& " replace(replace(replace(cabecera.fax,')',''),'(',''),' ','') as FAX_2, " _
& " 'HOTELES' as TIPO, " _
& " 'H5' as CATEGORIA, " _
& " 0 as HABITACIONES, " _
& " 0 as PLAZAS_DISPONIBLES_SIN_SUPLETORIAS, " _
& " 'http://www.hdhotels.com/' as URL " _
& " from empresas inner join hoteles as cabecera on empresas.empresa_id=cabecera.empresa_id left join provincias on provincias.provincia_id=cabecera.provincia_id where cabecera.hotel_id=?"
        Shared sqlISTAAlojamiento As String = "select " _
        & " '000' as ID_PAIS," _
        & " '00000' as ID_PROVINCIA_ISLA," _
        & " 1 as N_DIA," _
        & " 0 as ENTRADAS," _
        & " 0 as SALIDAS," _
        & " 0 as PERNOCTACIONES" _
        & " from hoteles as ALOJAMIENTO where hotel_id=0"

        Shared sqlISTAHabitaciones As String = "select " _
& " 1 as HABITACIONES_N_DIA," _
& " 0 as PLAZAS_SUPLETORIAS," _
& " 0 as HABITACIONES_DOBLES_USO_DOBLE," _
& " 0 as HABITACIONES_DOBLES_USO_INDIVIDUA," _
& " 0 as HABITACIONES_OTRAS" _
& " from hoteles as HABITACIONES where hotel_id=0"

        Shared sqlISTAPrecios As String = "select " _
& " 1000.99 as REVPAR_MENSUAL," _
& " 1000.99 as ADR_MENSUAL," _
& " 1000.99 as ADR_TOUROPERADOR_TRADICIONAL," _
& " 99.99 as PCTN_HABITACIONES_OCUPADAS_TOUROPERADOR_TRADICIONAL," _
& " 1000.99 as ADR_TOUROPERADOR_ONLINE," _
& " 99.99 as PCTN_HABITACIONES_OCUPADAS_TOUROPERADOR_ONLINE," _
& " 1000.99 as ADR_EMPRESAS," _
& " 99.99 as PCTN_HABITACIONES_OCUPADAS_EMPRESAS," _
& " 1000.99 as ADR_AGENCIA_DE_VIAJE_TRADICIONAL," _
& " 99.99 as PCTN_HABITACIONES_OCUPADAS_AGENCIA_TRADICIONAL," _
& " 1000.99 as ADR_AGENCIA_DE_VIAJE_ONLINE," _
& " 99.99 as PCTN_HABITACIONES_OCUPADAS_AGENCIA_ONLINE," _
& " 1000.99 as ADR_PARTICULARES," _
& " 99.99 as PCTN_HABITACIONES_OCUPADAS_PARTICULARES," _
& " 1000.99 as ADR_GRUPOS," _
& " 99.99 as PCTN_HABITACIONES_OCUPADAS_GRUPOS," _
& " 1000.99 as ADR_INTERNET," _
& " 99.99 as PCTN_HABITACIONES_OCUPADAS_INTERNET," _
& " 1000.99 as ADR_OTROS," _
& " 99.99 as PCTN_HABITACIONES_OCUPADAS_OTROS" _
& " from hoteles as PRECIOS where hotel_id=0"
        Shared sqlISTAPERSONAL_OCUPADO = "select " _
& " 1000.99 as PERSONAL_NO_REMUNERADO," _
& " 1000.99 as PERSONAL_REMUNERADO_FIJO," _
& " 1000.99 as PERSONAL_REMUNERADO_EVENTUAL " _
        & " from hoteles where hotel_id=0"
        Shared sqlISTALlegadasSalidasPernoctaciones = "" _
& " SELECT" _
& " reservas_huespedes.fecha_llegada, " _
& " ifnull(reservas_huespedes.fecha_salida,ifnull(reservas.fecha_salida,fecha_prevista_salida)) as fecha_salida, " _
& " concat(ifnull(naciones.pais_ista,'ESP'),'-',case ifnull(naciones.pais_ista,'ESP') when 'ESP' then ifnull(provincias.provincia_ista,pd.provincia_ista) else 0 end) as nacion_id,  " _
& " count(*) as cantidad " _
& " FROM " _
& " reservas_huespedes " _
& " Inner Join reservas ON reservas_huespedes.reserva_id = reservas.reserva_id " _
& " Inner Join clientes ON reservas_huespedes.cliente_id = clientes.cliente_id " _
& " left Join naciones ON clientes.nacion_id = naciones.nacion_id " _
& " left Join provincias ON provincias.provincia_id = clientes.provincia_id " _
& " left Join provincias pd ON pd.defecto_ista = 1 " _
& " WHERE " _
& " reservas.hotel_id=? and reservas.estado_reserva_id NOT IN  (0,1,2) " _
& " and  " _
& " (reservas_huespedes.fecha_llegada between  ? and  ? " _
& " or  ifnull(reservas_huespedes.fecha_salida,ifnull(reservas.fecha_salida,fecha_prevista_salida)) between  ? and  ? " _
& " ) " _
& " group by reservas_huespedes.fecha_llegada, ifnull(reservas_huespedes.fecha_salida,ifnull(reservas.fecha_salida,fecha_prevista_salida)),naciones.pais_ista,ifnull(provincias.provincia_ista,0) "
        Shared sqlISTAHabitacionesOcupadasPorDiaTipo = "" _
& " SELECT distinct" _
& " habitaciones.habitacion_id, " _
& " habitaciones.tipo_habitacion_id " _
& " FROM " _
& " habitaciones_bloqueos " _
& " Inner Join habitaciones ON habitaciones_bloqueos.habitacion_id = habitaciones.habitacion_id " _
& " Inner Join reservas ON habitaciones_bloqueos.reserva_id = reservas.reserva_id " _
& " Inner Join tipos_habitacion ON habitaciones.tipo_habitacion_id = tipos_habitacion.tipo_habitacion_id " _
& " WHERE " _
& " tipos_habitacion.desvios=0 and  " _
& " reservas.estado_reserva_id IN  (3,4,5) AND " _
& " habitaciones.hotel_id =  ? AND " _
& " habitaciones_bloqueos.fecha_desde <>  habitaciones_bloqueos.fecha_hasta " _
& " and habitaciones_bloqueos.fecha_hasta<>?" _
& " and " _
& "         ?  between habitaciones_bloqueos.fecha_desde and habitaciones_bloqueos.fecha_hasta "
        Shared sqlISTAEnvios = "select * from envios_ista where hotel_id=? and ano=? and mes=?"
        Shared sqlISTAPreciosPor = "" _
& " SELECT " _
& " clientes.permite_credito, " _
& " lineas_factura.fecha, " _
& " Sum(lineas_factura.cantidad*lineas_factura.precio) AS precio, " _
& " Sum(case lineas_factura.unidad_calculo_id=1 when 1 then lineas_factura.cantidad else 0 end) AS nhab,Sum(lineas_factura.cantidad*lineas_factura.precio) /Sum(case lineas_factura.unidad_calculo_id=1 when 1 then lineas_factura.cantidad else 0 end) as pvp_medio " _
& " FROM " _
& " lineas_factura " _
& " Inner Join reservas ON lineas_factura.reserva_id = reservas.reserva_id " _
& " Inner Join servicios ON lineas_factura.servicio_id = servicios.servicio_id " _
& " Left Join clientes ON reservas.cliente_id = clientes.cliente_id " _
& " WHERE " _
& " lineas_factura.hotel_id =  ? AND " _
& " reservas.estado_reserva_id IN  (3, 4,5) AND " _
& " lineas_factura.fecha between  ? and ? " _
& " and servicios.tipo_servicio_id=1 " _
& " group by clientes.permite_credito,lineas_factura.fecha "

        Private Function CargarColumnasIsta(ByVal rowo As DataRow, ByVal row As DataRow)
            Dim x As Integer
            For x = 0 To row.Table.Columns.Count - 1
                'Console.WriteLine(row.Table.Columns(x).ColumnName)
                Try
                    If rowo.IsNull(row.Table.Columns(x).ColumnName) Then
                    End If
                Catch ex As Exception
                    Console.WriteLine(row.Table.Columns(x).ColumnName)
                End Try
            Next

            For x = 0 To rowo.Table.Columns.Count - 1
                row(rowo.Table.Columns(x).ColumnName) = rowo(rowo.Table.Columns(x).ColumnName)
            Next
        End Function

        Public Function obtieneDatosISTA(ByVal hotel_id As Integer, ByVal ano As Integer, ByVal mes As Integer)
            'Dim istads As New DataSet
            'Dim Report As StiReport = New StiReport()
            Dim istads As DataSet = New DataSet("Test")
            '            istads.ReadXmlSchema("C:\Proyectos Codecharge\ClasesGesHotel_tano\ClasesGesHotel\ista.xsd")
            istads.ReadXml("C:\Proyectos Codecharge\ClasesGesHotel_tano\ClasesGesHotel\ista.xsd")
            'crear encuesta
            Dim encuesta_id As Integer
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Try


                Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
                Dim anoParam As New Odbc.OdbcParameter("@ano", ano)
                Dim mesParam As New Odbc.OdbcParameter("@mes", mes)
                cmd.Parameters.Clear()
                cmd.Parameters.Add(hotel_idParam)
                cmd.Parameters.Add(anoParam)
                cmd.Parameters.Add(mesParam)

                Dim dsenvios As DataSet = getDataSet(cmd, sqlISTAEnvios)

                For encuesta_id = 1 To 1
                    Dim row As DataRow = istads.Tables("ENCUESTA").NewRow   'crear ENCUESTA
                    row("ENCUESTA_Id") = encuesta_id
                    istads.Tables("ENCUESTA").Rows.Add(row)
                    'campos a rellenar en row
                    Dim cabecera_id As Integer
                    For cabecera_id = 1 To 1

                        Dim residencia_id As Integer = 1
                        Dim x As Date
                        Dim fecha_desde As New Date(ano, mes, 1)
                        Dim fecha_hasta As New Date(ano, mes, 1)
                        fecha_hasta = fecha_hasta.AddMonths(1).AddDays(-1)
                        Dim mathab() As Integer = ObtieneHabitacionesDisponiblesHotelDia(cmd, hotel_id, fecha_desde, 0, True)

                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(hotel_idParam)
                        Dim ds As DataSet = getDataSet(cmd, sqlISTACabecera)



                        row = istads.Tables("CABECERA").NewRow    'crear CABECERA
                        CargarColumnasIsta(ds.Tables(0).Rows(0), row)
                        'deberia sacar la media de todo el mes o con el primer dia del mes me vale?
                        Dim rowcab As DataRow = row
                        Dim npec As Integer = 0
                        rowcab("DIAS_ABIERTO_MES_REFERENCIA") = npec.ToString("00")
                        row("HABITACIONES") = mathab(0)
                        row("PLAZAS_DISPONIBLES_SIN_SUPLETORIAS") = mathab(1)

                        'enganchar la encuesta_id?
                        row("ENCUESTA_Id") = encuesta_id
                        row("CABECERA_Id") = cabecera_id
                        istads.Tables("CABECERA").Rows.Add(rowcab)

                        row = istads.Tables("FECHA_REFERENCIA").NewRow    'crear FECHA_REFERENCIA
                        row("MES") = mes.ToString("00")
                        row("ANYO") = ano.ToString("0000")
                        row("CABECERA_Id") = cabecera_id
                        istads.Tables("FECHA_REFERENCIA").Rows.Add(row)


                        row = istads.Tables("ALOJAMIENTO").NewRow    'crear  ALOJAMIENTO
                        Dim alojamiento_id As Integer = 1
                        row("ALOJAMIENTO_Id") = alojamiento_id
                        row("ENCUESTA_Id") = encuesta_id

                        istads.Tables("ALOJAMIENTO").Rows.Add(row)



                        Dim fecha_desdeParam As New Odbc.OdbcParameter("@fecha_desde", convertFecha(fecha_desde))
                        Dim fecha_hastaParam As New Odbc.OdbcParameter("@fecha_hasta", convertFecha(fecha_hasta))
                        Dim fecha_desde1Param As New Odbc.OdbcParameter("@fecha_desde1", convertFecha(fecha_desde))
                        Dim fecha_hasta1Param As New Odbc.OdbcParameter("@fecha_hasta1", convertFecha(fecha_hasta))

                        cmd.Parameters.Add(fecha_desdeParam)
                        cmd.Parameters.Add(fecha_hastaParam)
                        cmd.Parameters.Add(fecha_desde1Param)
                        cmd.Parameters.Add(fecha_hasta1Param)

                        Dim dshuespedes As DataSet = getDataSet(cmd, sqlISTALlegadasSalidasPernoctaciones)
                        Dim dsprecios As DataSet = getDataSet(cmd, sqlISTAPreciosPor)
                        'sacar los paises distintos
                        Dim naciones As Hashtable = AgruparRowsPor(dshuespedes.Tables(0).Select("", "nacion_id"), "nacion_id", "nacion_id", "cantidad")
                        Dim naci As String
                        For Each naci In naciones.Keys
                            'por cada residencia pais/provincia
                            row = istads.Tables("RESIDENCIA").NewRow    'crear  RESIDENCIA
                            row("ALOJAMIENTO_Id") = alojamiento_id
                            'residencia_id = naci
                            row("RESIDENCIA_Id") = residencia_id
                            Dim nacp() As String = naci.Split("-")
                            If nacp(1) <> "0" Then
                                row("ID_PROVINCIA_ISLA") = nacp(1)
                                row.Table.Columns("ID_PAIS").AllowDBNull = True
                                row("ID_PAIS") = Nothing
                            Else
                                row("ID_PAIS") = nacp(0)
                                row.Table.Columns("ID_PROVINCIA_ISLA").AllowDBNull = True
                                row("ID_PROVINCIA_ISLA") = Nothing
                            End If

                            istads.Tables("RESIDENCIA").Rows.Add(row)
                            Dim dv As DataTable = New DataView(dshuespedes.Tables(0), "nacion_id='" & naci & "'", "fecha_llegada", DataViewRowState.CurrentRows).ToTable
                            'por dia

                            x = fecha_desde

                            While x <= fecha_hasta
                                row = istads.Tables("MOVIMIENTO").NewRow    'crear  RESIDENCIA
                                'row("ALOJAMIENTO_ID") = mes
                                row("RESIDENCIA_Id") = residencia_id
                                row("N_DIA") = x.Day.ToString("00")

                                row("ENTRADAS") = dv.Compute("sum(cantidad)", "fecha_llegada='" & convertFecha(x) & "'")
                                row("SALIDAS") = dv.Compute("sum(cantidad)", "fecha_salida='" & convertFecha(x) & "'")
                                row("PERNOCTACIONES") = dv.Compute("sum(cantidad)", "fecha_llegada<='" & convertFecha(x) & "' and fecha_salida>'" & convertFecha(x) & "'")
                                If row.IsNull("ENTRADAS") Then
                                    row("ENTRADAS") = 0
                                End If
                                If row.IsNull("SALIDAS") Then
                                    row("SALIDAS") = 0
                                End If
                                If row.IsNull("PERNOCTACIONES") Then
                                    row("PERNOCTACIONES") = 0
                                End If

                                'row("ID_PROVINCIA_ISLA") = ""

                                istads.Tables("MOVIMIENTO").Rows.Add(row)
                                x = x.AddDays(1)
                            End While
                            residencia_id += 1
                        Next

                        x = fecha_desde
                        Dim habitacion_id As Integer = 1
                        row = istads.Tables("HABITACIONES").NewRow    'crear  RESIDENCIA
                        row("ENCUESTA_Id") = encuesta_id
                        row("HABITACIONES_id") = habitacion_id
                        istads.Tables("HABITACIONES").Rows.Add(row)
                        While x <= fecha_hasta
                            'por dia

                            row = istads.Tables("HABITACIONES_MOVIMIENTO").NewRow    'crear  RESIDENCIA
                            row("HABITACIONES_id") = habitacion_id
                            row("HABITACIONES_N_DIA") = x.Day.ToString("00")
                            row("PLAZAS_SUPLETORIAS") = 0
                            fecha_desdeParam.Value = convertFecha(x)
                            fecha_hastaParam.Value = convertFecha(x)
                            Dim dshabitaciones As DataSet = getDataSet(cmd, sqlISTAHabitacionesOcupadasPorDiaTipo)
                            Dim nhabs As Object = 0
                            nhabs = dshabitaciones.Tables(0).Rows.Count
                            If IsDBNull(nhabs) Then
                                nhabs = 0
                            Else
                                If nhabs > 0 Then
                                    npec += 1
                                End If
                            End If
                            row("HABITACIONES_DOBLES_USO_DOBLE") = nhabs
                            row("HABITACIONES_DOBLES_USO_INDIVIDUAL") = 0
                            row("HABITACIONES_OTRAS") = 0
                            istads.Tables("HABITACIONES_MOVIMIENTO").Rows.Add(row)
                            x = x.AddDays(1)
                        End While
                        rowcab("DIAS_ABIERTO_MES_REFERENCIA") = npec.ToString("00")
                        row = istads.Tables("PRECIOS").NewRow    'crear  PRECIOS
                        row("ENCUESTA_Id") = encuesta_id
                        row("REVPAR_MENSUAL") = 0
                        row("ADR_MENSUAL") = 0
                        row("ADR_TOUROPERADOR_TRADICIONAL") = 0
                        row("PCTN_HABITACIONES_OCUPADAS_TOUROPERADOR_TRADICIONAL") = 0
                        row("ADR_TOUROPERADOR_ONLINE") = 0
                        row("PCTN_HABITACIONES_OCUPADAS_TOUROPERADOR_ONLINE") = 0
                        row("ADR_EMPRESAS") = 0
                        row("PCTN_HABITACIONES_OCUPADAS_EMPRESAS") = 0
                        row("ADR_AGENCIA_DE_VIAJE_TRADICIONAL") = 0
                        row("PCTN_HABITACIONES_OCUPADAS_AGENCIA_TRADICIONAL") = 0
                        row("ADR_AGENCIA_DE_VIAJE_ONLINE") = 0
                        row("PCTN_HABITACIONES_OCUPADAS_AGENCIA_ONLINE") = 0
                        row("ADR_PARTICULARES") = 0
                        row("PCTN_HABITACIONES_OCUPADAS_PARTICULARES") = 0
                        row("ADR_GRUPOS") = 0
                        row("PCTN_HABITACIONES_OCUPADAS_GRUPOS") = 0
                        row("ADR_INTERNET") = 0
                        row("PCTN_HABITACIONES_OCUPADAS_INTERNET") = 0
                        row("ADR_OTROS") = 0
                        row("PCTN_HABITACIONES_OCUPADAS_OTROS") = 0
                        Dim tothab As Object = dsprecios.Tables(0).Compute("sum(nhab)", "")
                        If IsDBNull(tothab) Then
                            tothab = 0
                        End If
                        Dim totREVPAR As Object = dsprecios.Tables(0).Compute("sum(pvp_medio)", "")
                        If IsDBNull(totREVPAR) Then
                            totREVPAR = 0
                        End If
                        Dim totmen As Object = dsprecios.Tables(0).Compute("avg(pvp_medio)", "")
                        If IsDBNull(totmen) Then
                            totmen = 0
                        End If
                        Dim tottour As Object = dsprecios.Tables(0).Compute("avg(pvp_medio)", "permite_credito=1")
                        If IsDBNull(tottour) Then
                            tottour = 0
                        End If
                        Dim totdire As Object = dsprecios.Tables(0).Compute("avg(pvp_medio)", "permite_credito=0")
                        If IsDBNull(totdire) Then
                            totdire = 0
                        End If
                        Dim tottourhab As Object = dsprecios.Tables(0).Compute("sum(nhab)", "permite_credito=1")
                        If IsDBNull(tottourhab) Then
                            tottourhab = 0
                        End If
                        Dim totdirehab As Object = dsprecios.Tables(0).Compute("sum(nhab)", "permite_credito=0")
                        If IsDBNull(totdirehab) Then
                            totdirehab = 0
                        End If

                        row("ADR_TOUROPERADOR_TRADICIONAL") = Math.Round(tottour, 2, MidpointRounding.AwayFromZero)
                        row("PCTN_HABITACIONES_OCUPADAS_TOUROPERADOR_TRADICIONAL") = Math.Round(tottourhab / tothab * 100, 2, MidpointRounding.AwayFromZero)
                        row("ADR_PARTICULARES") = Math.Round(totdire, 2, MidpointRounding.AwayFromZero)
                        row("PCTN_HABITACIONES_OCUPADAS_PARTICULARES") = Math.Round(totdirehab / tothab * 100, 2, MidpointRounding.AwayFromZero)
                        row("ADR_MENSUAL") = Math.Round(totmen, 2, MidpointRounding.AwayFromZero)
                        row("REVPAR_MENSUAL") = Math.Round(totREVPAR, 2, MidpointRounding.AwayFromZero)
                        istads.Tables("PRECIOS").Rows.Add(row)
                    Next


                    row = istads.Tables("PERSONAL_OCUPADO").NewRow    'crear  PERSONAL_OCUPADO
                    row("ENCUESTA_ID") = encuesta_id
                    row("PERSONAL_NO_REMUNERADO") = 0
                    row("PERSONAL_REMUNERADO_FIJO") = 0
                    row("PERSONAL_REMUNERADO_EVENTUAL") = 0
                    If dsenvios.Tables(0).Rows.Count > 0 Then
                        row("PERSONAL_NO_REMUNERADO") = dsenvios.Tables(0).Rows(0)("PERSONAL_NO_REMUNERADO")
                        row("PERSONAL_REMUNERADO_FIJO") = dsenvios.Tables(0).Rows(0)("PERSONAL_REMUNERADO_FIJO")
                        row("PERSONAL_REMUNERADO_EVENTUAL") = dsenvios.Tables(0).Rows(0)("PERSONAL_REMUNERADO_EVENTUAL")

                    End If
                    'row("ID_PROVINCIA_ISLA") = ""

                    istads.Tables("PERSONAL_OCUPADO").Rows.Add(row)

                Next
            Catch ex As Exception
                istads.Tables.Clear()
            End Try
            'Me.dumpDataTable(row.Table)
            flushConection(cmd, 0)
            'Dim tmp As New IO.StringWriter
            'istads.WriteXml(tmp)

            'Console.Write(tmp.ToString())
            'Dim tabi As Integer
            'Dim tmpra As String = ""
            'For tabi = 0 To istads.Tables.Count - 1
            'tmpra &= ConvertToHtmlFile(istads.Tables(tabi))
            'Next
            'Console.WriteLine(tmpra

            Validate("C:\Proyectos Codecharge\ClasesGesHotel_tano\ClasesGesHotel\ista.xsd", New IO.MemoryStream(System.Text.Encoding.ASCII.GetBytes(obtieneXMLdeDataset(istads))))
            Return istads
        End Function


        Public Function obtieneXMLdeDataset(ByVal istads As DataSet) As String
            'todo quitar cabecera
            '

            Dim xml As String = istads.GetXml
            Dim header As String = "<?xml version='1.0' encoding='ISO-8859-1'?>"
            xml = header + xml.Replace("<NewDataSet>", "").Replace("</NewDataSet>", "")
            '            Return xml
            Dim tmp As New IO.StringWriter
            istads.Tables("ENCUESTA").WriteXml(tmp, False)
            xml = tmp.ToString
            xml = header + xml.Replace("<NewDataSet>", "").Replace("</NewDataSet>", "")
            'cambiar fecha_referencia de sitio
            Dim fech As String = xml.Substring(xml.IndexOf("<FECHA_REFERENCIA>"), "</FECHA_REFERENCIA>".Length + xml.IndexOf("</FECHA_REFERENCIA>") - xml.IndexOf("<FECHA_REFERENCIA>"))
            xml = xml.Remove(xml.IndexOf(fech), fech.Length)
            xml = xml.Insert(xml.IndexOf("<CABECERA>") + "<CABECERA>".Length, fech)
            Return xml
        End Function
        Public Shared mErrorsList As New ArrayList
        Shared Function Validate(ByVal Schema As String, ByVal XMLDoc As IO.Stream) As ArrayList

            Dim objWorkingXML As New System.Xml.XmlDocument
            Dim objValidateXML As System.Xml.XmlValidatingReader
            Dim objSchemasColl As New System.Xml.Schema.XmlSchemaCollection
            mErrorsList.Clear()
            objSchemasColl.Add("", Schema)

            'This loads XML string
            objValidateXML = New System.Xml.XmlValidatingReader(New System.Xml.XmlTextReader(XMLDoc))

            objValidateXML.Schemas.Add(objSchemasColl)

            'This is how you CATCH the errors (with a handler function)
            AddHandler objValidateXML.ValidationEventHandler, AddressOf ValidationCallBack

            'This is WHERE the validation occurs.. WHEN the XML Document READS throughthe validating reader
            Try
                objWorkingXML.Load(objValidateXML)

            Catch ex As Exception
                mErrorsList.Add(ex.Message)
            Finally

                objValidateXML.Close()
            End Try


            Return mErrorsList

        End Function

        Shared Sub ValidationCallBack(ByVal sender As Object, ByVal e As System.Xml.Schema.ValidationEventArgs)
            'mErrorsList.Add(e.Message)
            Console.WriteLine(e.Message)
        End Sub

        Public Function obtieneDatosISTAOld(ByVal hotel_id As Integer, ByVal ano As Integer, ByVal mes As Integer)
            'Dim istads As New DataSet
            'Dim Report As StiReport = New StiReport()
            Dim istads As DataSet = New DataSet("Test")
            istads.ReadXmlSchema("C:\Proyectos Codecharge\ClasesGesHotel_tano\ClasesGesHotel\ista.xsd")
            'crear encuesta
            Dim row As DataRow = istads.Tables("ENCUESTA").Rows.Add()   'crear una encuesta
            'campos a rellenar en row

            row = istads.Tables("CABECERA").Rows.Add()   'crear una encuesta

            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            Dim ds As DataSet = getDataSet(cmd, sqlISTACabecera)
            ds.DataSetName = "ENCUESTA"
            ds.Tables(0).TableName = "CABECERA"
            getDataSet(cmd, sqlISTAAlojamiento, ds, "ALOJAMIENTO")
            getDataSet(cmd, sqlISTAHabitaciones, ds, "HABITACIONES")
            getDataSet(cmd, sqlISTAPrecios, ds, "PRECIOS")
            getDataSet(cmd, sqlISTAPERSONAL_OCUPADO, ds, "PERSONAL_OCUPADO")
            ds.Tables("ALOJAMIENTO").Rows.Add()
            ds.Tables("HABITACIONES").Rows.Add()
            ds.Tables("PRECIOS").Rows.Add()
            ds.Tables("PERSONAL_OCUPADO").Rows.Add()
            Dim tmp As New IO.StringWriter
            ds.WriteXml(tmp)

            Console.Write(tmp.ToString())
            flushConection(cmd, 0)
        End Function

        Sub pruebaBatch()
            Dim cmd As Odbc.OdbcCommand = prepareConectionOnlyRead()
            Dim ds As DataSet = getDataSet(cmd, "select reserva_id as reservas_reserva_id,0 as valor from reservas where reserva_id between 18000 and 18100")
            Dim x As Object = Me
            Dim tableIndex As Integer = 0
            flushConection(cmd, 0)
            Dim batch As New geshotel.BatchTasks
            batch.maxThreads = 0
            Dim tdr As DataRowCollection = ds.Tables(tableIndex).Rows
            Dim ti As Integer
            For ti = 0 To tdr.Count - 1
                Dim param() = {tdr(ti)("reservas_reserva_id"), False}
                batch.addTask(x, "obtieneImporteTotalReserva", ti, param, tdr(ti), "valor")
            Next
            batch.waitForCompletition()
            
        End Sub
    End Class
End Namespace
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data
Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Namespace geshotelk
    Public Class duplicarTablas
        Private sqlTablaMaestra As String
        Private sqlTablaHijas() As String
        Private sqlTablaHijasN() As String
        Private sqlTablasIdHijas() As String
        Private sqlPuedoDuplicar As String
        Private usuario As Integer
        Public lastError As Integer = 0

        Public Class ObjDuplicacion
            'tabla maestra origen
            Public TMO_DataAdapter As MysqlDataAdapter
            'tabla maestra destino
            Public TMD_DataAdapter As MysqlDataAdapter
            'tabla hijas origen
            Public THO_DataAdapters() As MysqlDataAdapter
            'tabla hijas destino
            Public THD_DataAdapters() As MysqlDataAdapter
            Public THT_DataTables() As DataTable
            Public ds As DataSet 'con todas las tablas
            Public tr As MysqlTransaction 'la transaccion
            Public origen_id As Integer
            Public destino_id As Integer

        End Class
        Public objd As New ObjDuplicacion
        Public cmd As MysqlCommand
        Private clavePrimaria As String
        Private campoEnlazeDuplicados As String
        Private campoEnlazeDuplicadosSiguiente As String
        Public Event EndDuplicate(ByVal sender As Object)
        Protected Overridable Sub OnEndDuplicate()
            RaiseEvent EndDuplicate(Me)
        End Sub
        Public Function preparaDuplicacion(ByVal sqlMaestro As String, ByVal sqlHijosN() As String, ByVal sqlHijos() As String, ByVal sqlIdHijos() As String, ByVal sqlPuedo As String, ByVal campoPrimario As String, ByVal campoEnlazeMaestro As String, ByVal campoEnlazeMaestroSiguiente As String)
            sqlPuedoDuplicar = sqlPuedo
            clavePrimaria = campoPrimario
            campoEnlazeDuplicados = campoEnlazeMaestro
            campoEnlazeDuplicadosSiguiente = campoEnlazeMaestroSiguiente
            sqlTablaMaestra = sqlMaestro
            sqlTablaHijas = sqlHijos
            sqlTablaHijasN = sqlHijosN
            sqlTablasIdHijas = sqlIdHijos
            'todo rellenar tablas

            Dim errorCode As Integer = 0

            objd.ds = New DataSet()
            Dim myDataRowsCommandBuilder As MysqlCommandBuilder

            cmd.CommandText = sqlTablaMaestra
            objd.TMO_DataAdapter = New MysqlDataAdapter(cmd)
            myDataRowsCommandBuilder = New MysqlCommandBuilder(objd.TMO_DataAdapter)
            objd.TMO_DataAdapter.Fill(objd.ds, "TMO")

            objd.TMD_DataAdapter = New MysqlDataAdapter(cmd)
            myDataRowsCommandBuilder = New MysqlCommandBuilder(objd.TMD_DataAdapter)
            objd.TMD_DataAdapter.Fill(objd.ds, "TMD")
            Dim sqlTablaHija As String
            Dim count As Integer = 0
            ReDim objd.THO_DataAdapters(sqlTablaHijas.Length)
            ReDim objd.THD_DataAdapters(sqlTablaHijas.Length)
            ReDim objd.THT_DataTables(sqlTablaHijas.Length)
            For Each sqlTablaHija In sqlTablaHijas
                cmd.CommandText = sqlTablaHija
                objd.THO_DataAdapters(count) = New MysqlDataAdapter(cmd)
                myDataRowsCommandBuilder = New MysqlCommandBuilder(objd.THO_DataAdapters(count))
                myDataRowsCommandBuilder.ConflictOption = ConflictOption.OverwriteChanges
                objd.THO_DataAdapters(count).Fill(objd.ds, "THO" & count)

                objd.THD_DataAdapters(count) = New MysqlDataAdapter(cmd)
                myDataRowsCommandBuilder = New MysqlCommandBuilder(objd.THD_DataAdapters(count))
                myDataRowsCommandBuilder.ConflictOption = ConflictOption.OverwriteChanges
                objd.THD_DataAdapters(count).Fill(objd.ds, "THD" & count)

                objd.THT_DataTables(count) = New DataTable()
                objd.THT_DataTables(count).Columns.Add("origen_id", System.Type.GetType("System.Int32"), "")
                objd.THT_DataTables(count).Columns.Add("destino_id", System.Type.GetType("System.Int32"), "")
                count += 1
            Next
            'Dim x(0) As DataColumn
            'x(0) = objd.ds.Tables("Lineas_PlantillaD").Columns("Linea_Plantilla_Id")
            'objd.ds.Tables("Lineas_PlantillaD").PrimaryKey = x
            'todos los campos que hayan sido modificados o una lista de camppos
            Return True
        End Function
        Public Function ejecutaDuplicacion()

            lastError = 1
            Try

                Dim ds As DataSet = objd.ds
                If ds.HasChanges() And IsDBNull(ds.Tables("TMO").Rows(0).Item(campoEnlazeDuplicadosSiguiente)) Then  ' Dice si se ha tocado algo pero es posible que no hayan cambios
                    'Cogemos los posibles cambios de tabla maestra y de las tablas hijas y los ponemos en un DataTable
                    Dim cdt_TMD As DataTable = ds.Tables("TMD").GetChanges()
                    Dim cambiadoCabecera As Boolean = False
                    If Not IsNothing(cdt_TMD) Then 'Si hay posibles cambios en la Tabla Maestra
                        'todo compara todas las columnas con el original
                        'Recorremos todas las columnas comparando origen y destino
                        ' Se usa el equals porque compara objetos y no tengo que mirar los values
                        Dim x As Integer
                        Dim tmd As DataTable = ds.Tables("TMD")
                        With ds.Tables("TMO")
                            For x = 0 To .Columns.Count - 1
                                Try
                                    If tmd.Rows(0).RowState = DataRowState.Deleted Then
                                        cambiadoCabecera = True
                                    Else
                                        If Not .Rows(0).Item(x).Equals(tmd.Rows(0).Item(x)) Then
                                            ' Si los objetos son distintos la Cabecera ha cambiado
                                            cambiadoCabecera = True
                                        End If
                                    End If

                                Catch ex As Exception
                                    cambiadoCabecera = True
                                End Try
                            Next
                        End With
                    End If

                    Dim cambiadoLineas As Boolean = False
                    ' Hago lo mismo con las tablas hijas
                    Dim sqlTablaHija As String
                    Dim count As Integer = 0
                    If cambiadoCabecera = False Then
                        For Each sqlTablaHija In sqlTablaHijas
                            Dim cdt_THD As DataTable = ds.Tables("THD" & count).GetChanges()
                            If Not IsNothing(cdt_THD) Then
                                If ds.Tables("THO" & count).Rows.Count <> ds.Tables("THD" & count).Rows.Count Then
                                    ' Si el número de lineas Origen/Destino es diferente las líneas han cambiado
                                    cambiadoLineas = True
                                Else
                                    With ds.Tables("THO" & count)
                                        Dim y As Integer
                                        Dim maxy As Integer = .Rows.Count - 1
                                        If ds.Tables("THD" & count).Rows.Count - 1 > maxy Then
                                            maxy = ds.Tables("THD" & count).Rows.Count - 1
                                        End If
                                        For y = 0 To maxy   ' Para cada fila
                                            Dim x As Integer
                                            For x = 0 To .Columns.Count - 1   'Compruebo cada columna
                                                Try
                                                    If Not .Rows(y).Item(x).Equals(ds.Tables("THD" & count).Rows(y).Item(x)) Then
                                                        cambiadoLineas = True
                                                    End If
                                                Catch ex As Exception
                                                    cambiadoLineas = True
                                                End Try
                                            Next
                                        Next
                                    End With
                                End If
                            End If
                            count += 1
                        Next
                    End If
                    If cambiadoCabecera Or cambiadoLineas Then
                        'ha cambiado la cabecera
                        'ha cambiado las lineas
                        objd.origen_id = ds.Tables("TMD").Rows(0).Item(clavePrimaria)
                        objd.destino_id = ds.Tables("TMD").Rows(0).Item(clavePrimaria)

                        Dim nueva_plantilla_id As Integer = -1
                        Dim puedoDuplicar As Boolean = False
                        'comproboar que se necesita duplicacion sino actualizar tabla directamente
                        cmd.CommandText = sqlPuedoDuplicar
                        If cmd.ExecuteScalar() <> 0 Then
                            puedoDuplicar = True
                        End If
                        If puedoDuplicar = False Then
                            'si ha borrado la cabecera...
                            If ds.Tables("TMD").Rows(0).RowState = DataRowState.Deleted Then
                                count = 0
                                For Each sqlTablaHija In sqlTablaHijas
                                    objd.THD_DataAdapters(count).SelectCommand.CommandText = sqlTablaHija
                                    objd.THD_DataAdapters(count).Update(ds.Tables("THD" & count))
                                    count += 1
                                Next
                            Else
                                nueva_plantilla_id = ds.Tables("TMD").Rows(0).Item(clavePrimaria)
                                'si existe campo fecha mod
                                ds.Tables("TMD").Rows(0).Item("Fecha_Modificacion") = Now()
                                ds.Tables("TMD").Rows(0).Item("user_id") = usuario
                                'si existe campo usuario
                            End If
                            objd.TMD_DataAdapter.SelectCommand.CommandText = sqlTablaMaestra
                            objd.TMD_DataAdapter.Update(ds.Tables("TMD"))
                            count = 0
                            Dim lastid As Integer = 0
                            For Each sqlTablaHija In sqlTablaHijas
                                Dim tochange As DataTable = ds.Tables("THD" & count).GetChanges
                                If Not IsNothing(tochange) Then
                                    'cambiar usuario y fecha modif
                                    Dim xx As Integer
                                    For xx = 0 To tochange.Rows.Count - 1
                                        Try
                                            tochange.Rows(xx).Item("Fecha_Modificacion") = Now()
                                            tochange.Rows(xx).Item("user_id") = usuario
                                        Catch ex As Exception

                                        End Try
                                    Next

                                    objd.THD_DataAdapters(count).SelectCommand.CommandText = sqlTablaHija
                                    objd.THD_DataAdapters(count).Update(tochange)
                                    'crear un registro en origen/destino
                                    '                                Dim origen_id As Integer
                                    Dim destino_id As Object
                                    cmd.CommandText = "SELECT LAST_INSERT_ID();"
                                    destino_id = cmd.ExecuteScalar()
                                    If lastid <> destino_id And destino_id > 0 Then 'altamente improbable que pase alguna vez..
                                        Dim row As DataRow = objd.THT_DataTables(count).Rows.Add()
                                        row("origen_id") = destino_id
                                        row("destino_id") = destino_id
                                        lastid = destino_id
                                    End If
                                End If
                                count += 1
                            Next
                        Else
                            'TODO: si tiene plantilla hija no se podra modificar.
                            Try
                                'si rows es borrado...borrado de cabecera y no grabo las lineas nuevas
                                If ds.Tables("TMD").Rows(0).RowState <> DataRowState.Deleted Then
                                    'si existe campo fecha mod
                                    ds.Tables("TMD").Rows(0).Item("Fecha_Modificacion") = Now()
                                    ds.Tables("TMD").Rows(0).Item("user_id") = usuario
                                    'todo campo que enlaza los duplicados
                                    ds.Tables("TMD").Rows(0).Item(campoEnlazeDuplicados) = ds.Tables("TMO").Rows(0).Item(clavePrimaria)
                                    ds.Tables("TMD").Rows(0).AcceptChanges()
                                    ds.Tables("TMD").Rows(0).SetAdded()

                                    'actualizar primero la tabla maestra destino y sacar el nuevo id que se obtuvo
                                    objd.TMD_DataAdapter.SelectCommand.CommandText = sqlTablaMaestra
                                    objd.TMD_DataAdapter.Update(ds.Tables("TMD"))
                                    'es posible ke tmd ya tenga la id?
                                    cmd.CommandText = "SELECT LAST_INSERT_ID();"
                                    nueva_plantilla_id = cmd.ExecuteScalar()

                                    'nueva_plantilla_id = ObtieneUltimaIdInsertada(objd.PlantillasD_DataAdapter.SelectCommand)
                                Else
                                    nueva_plantilla_id = ds.Tables("TMO").Rows(0).Item(clavePrimaria)
                                End If
                                'actualiza la tabla maestra original
                                objd.TMO_DataAdapter.SelectCommand.CommandText = sqlTablaMaestra
                                ds.Tables("TMO").Rows(0).Item("Fecha_Modificacion") = Now()
                                ds.Tables("TMO").Rows(0).Item("user_id") = usuario
                                ds.Tables("TMO").Rows(0).Item(campoEnlazeDuplicadosSiguiente) = nueva_plantilla_id
                                objd.TMO_DataAdapter.Update(ds.Tables("TMO"))


                                'pasar el nuevo id de tabla maestra a las lineas de tabla hija
                                If nueva_plantilla_id <> ds.Tables("TMO").Rows(0).Item(clavePrimaria) Then
                                    count = 0
                                    Dim subTablasId As New Hashtable
                                    For Each sqlTablaHija In sqlTablaHijas
                                        objd.THO_DataAdapters(count).SelectCommand.CommandText = sqlTablaHija
                                        objd.THO_DataAdapters(count).Update(ds.Tables("THO" & count))

                                        With ds.Tables("THD" & count)
                                            Dim y As Integer
                                            For y = 0 To .Rows.Count - 1
                                                'actualizar las lineas de plantilla
                                                If count = 3 Then
                                                    count = count
                                                End If
                                                Dim borrada As Boolean = False
                                                If .Rows(y).RowState <> DataRowState.Deleted Then
                                                    Try
                                                        .Rows(y).Item(clavePrimaria) = nueva_plantilla_id
                                                    Catch ex As Exception

                                                    End Try
                                                    Try
                                                        .Rows(y).Item("Fecha_modificacion") = Now()
                                                    Catch ex As Exception

                                                    End Try
                                                    Try
                                                        .Rows(y).Item("user_id") = usuario
                                                    Catch ex As Exception

                                                    End Try


                                                    .Rows(y).AcceptChanges()
                                                    .Rows(y).SetAdded()
                                                Else
                                                    .Rows(y).RejectChanges()
                                                    Try
                                                        .Rows(y).Item("Fecha_modificacion") = Now()

                                                    Catch ex As Exception

                                                    End Try
                                                    Try
                                                        .Rows(y).Item("user_id") = usuario
                                                    Catch ex As Exception

                                                    End Try

                                                    borrada = True
                                                End If
                                                'sera mas lento pero en cada update construir tabla con las conversiones
                                                'todo obtener la id de la nueva matriz
                                                'si la id pertenece a otra tabla hija echa anteriormente
                                                Dim origen_id As Object = .Rows(y)(0)  'a guevo la primera columna de la hija es la id!
                                                Dim destino_id As Integer = -1
                                                If subTablasId.ContainsKey(sqlTablasIdHijas(count)) Then
                                                    'obtener el nuevo valor usando la tabla de conversion?
                                                    If subTablasId(sqlTablasIdHijas(count)) <> count Then
                                                        Dim convtable As DataTable = objd.THT_DataTables(subTablasId(sqlTablasIdHijas(count)))
                                                        origen_id = .Rows(y)(sqlTablasIdHijas(count))
                                                        Dim conrows() As DataRow = convtable.Select("origen_id=" & origen_id)
                                                        If conrows.Length > 0 Then
                                                            destino_id = conrows(0)("destino_id")
                                                            .Rows(y).Item(sqlTablasIdHijas(count)) = destino_id
                                                        Else
                                                            .Rows(y).RejectChanges()
                                                            Try
                                                                .Rows(y).Item("Fecha_modificacion") = Now()

                                                            Catch ex As Exception

                                                            End Try
                                                            Try
                                                                .Rows(y).Item("user_id") = usuario
                                                            Catch ex As Exception

                                                            End Try
                                                            borrada = True
                                                        End If
                                                    End If
                                                End If

                                                objd.THD_DataAdapters(count).SelectCommand.CommandText = sqlTablaHija
                                                'objd.THD_DataAdapters(count).Update(ds.Tables("THD" & count).GetChanges) 'me aseguro una fila
                                                'objd.THD_DataAdapters(count).Update(ds.Tables("THD" & count)) 'me aseguro una fila
                                                Dim toupdate(0) As DataRow
                                                toupdate(0) = .Rows(y)
                                                objd.THD_DataAdapters(count).Update(toupdate) 'me aseguro una fila
                                                If Not borrada Then
                                                    If ds.Tables("THD" & count).Columns(0).ColumnName <> sqlTablasIdHijas(count) Then
                                                        origen_id = .Rows(y)(0)
                                                        destino_id = -1
                                                    End If
                                                    If destino_id = -1 Then
                                                        cmd.CommandText = "SELECT LAST_INSERT_ID();"
                                                        destino_id = cmd.ExecuteScalar()
                                                    End If

                                                    Dim row As DataRow = objd.THT_DataTables(count).Rows.Add()
                                                    If IsDBNull(origen_id) Then
                                                        origen_id = destino_id
                                                    End If
                                                    row("origen_id") = origen_id
                                                    row("destino_id") = destino_id
                                                End If

                                            Next
                                        End With
                                        If Not subTablasId.ContainsKey(sqlTablasIdHijas(count)) Then
                                            subTablasId(sqlTablasIdHijas(count)) = count
                                        End If

                                        count += 1
                                    Next
                                End If

                            Catch
                                nueva_plantilla_id = -2
                            End Try
                        End If
                        If nueva_plantilla_id < -1 Then
                            lastError = 1
                        Else
                            lastError = 0
                        End If

                        If nueva_plantilla_id > 0 Then
                            'llamar a la funcion externa de operaciones con objeto
                            objd.destino_id = nueva_plantilla_id 'y si es la misma que el evento decida
                            OnEndDuplicate()
                            If lastError <> 0 Then
                                nueva_plantilla_id = -1
                            End If
                        End If
                        Return nueva_plantilla_id
                    Else
                        'no hay cambios
                        Return -1
                    End If
                    Return -2
                End If
                'no se han tocado ninguna tabla
                Return -3
            Catch ex As Exception
                'alguna excepcion
                Return -4
            End Try
            Return True
        End Function
        Public Function finalizaDuplicacion()
            If Not IsNothing(cmd.Transaction) Then
                If lastError = 0 Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
            End If
            Return True
        End Function
        Public Function agregarFilaTablaHija(ByVal tabla As String, Optional ByVal row As DataRow = Nothing) As DataRow
            If IsNothing(row) Then
                Return objd.ds.Tables("THD" & encuentraIndexTabla(tabla)).Rows.Add()
            Else
                Return objd.ds.Tables("THD" & encuentraIndexTabla(tabla)).Rows.Add(row.ItemArray)
            End If

        End Function
        Private Function encuentraIndexTabla(ByVal tabla As String) As Integer
            Dim retVal As Integer = 0
            Dim x As String
            For Each x In sqlTablaHijasN
                If x.Equals(tabla) Then
                    Return retVal
                End If
                retVal += 1
            Next
            Return retVal
        End Function
        Public Function obtieneNuevaId(ByVal tabla As String, ByVal id As Integer) As Integer
            'primero se hay duplicado saca de las tablas origen/destino
            'si no hay duplicado devuelve la misma id
            'si id es negativo...obtiene el ultimo registro insertado para esa tabla
            Dim retval As Integer
            Dim count As Integer = encuentraIndexTabla(tabla)
            If id < 0 Then
                retval = objd.THT_DataTables(count).Rows.Count - 1
                If retval >= 0 Then
                    retval = objd.THT_DataTables(count).Rows(retval)("destino_id")
                Else
                    'no se creo ninguna fila 
                    retval = -1
                End If
            Else
                Dim dr As DataRow() = objd.THT_DataTables(count).Select("origen_id=" & id)
                If dr.Length > 0 Then
                    retval = dr(0)("destino_id")
                Else
                    retval = id
                End If
            End If

            Return retval
        End Function
        Public Function obtieneFilaTablaHija(ByVal tabla As String, ByVal filter As String) As DataRow
            Dim dr As DataRow() = objd.ds.Tables("THD" & encuentraIndexTabla(tabla)).Select(filter)
            If dr.Length = 1 Then
                Return dr(0)
            Else
                Return Nothing
            End If
        End Function
        Public Function obtieneFilaTablaMaestra() As DataRow
            Return objd.ds.Tables("TMD").Rows(0)
        End Function
        Public Function borrarFilaTablaMaestra()
            objd.ds.Tables("TMD").Rows(0).Delete()
            Dim count As Integer = 0
            Dim sqlTablaHija As String
            For Each sqlTablaHija In sqlTablaHijas
                Dim drc As DataRowCollection = objd.ds.Tables("THD" & count).Rows
                Dim x As Integer
                For x = 0 To drc.Count - 1
                    drc(x).Delete()
                Next
                count += 1
            Next
            Return True
        End Function
        Public Function VolcarObjeto(ByVal origen As Object, ByVal dr As DataRow, ByVal ignorar As ArrayList) As Object
            Dim x
            Dim errores As String = ""
            For x = 0 To dr.Table.Columns.Count - 1
                Try
                    If Not ignorar.Contains(dr.Table.Columns(x).ColumnName) Then
                        Dim valor As Object = origen(dr.Table.Columns(x).ColumnName).Value
                        Try
                            If origen(dr.Table.Columns(x).ColumnName).isempty Then
                                valor = Nothing
                            End If
                        Catch ex As Exception
                            errores &= "," & dr.Table.Columns(x).ColumnName & "-ee-" & ex.Message
                        End Try

                        If IsNothing(valor) Then
                            If Not dr.IsNull(dr.Table.Columns(x).ColumnName) Then
                                errores &= "," & dr.Table.Columns(x).ColumnName
                                dr.Item(dr.Table.Columns(x).ColumnName) = System.DBNull.Value
                            End If
                        Else
                            If dr.IsNull(dr.Table.Columns(x).ColumnName) Then
                                errores &= "," & dr.Table.Columns(x).ColumnName
                                dr.Item(dr.Table.Columns(x).ColumnName) = valor
                            Else
                                If dr.Item(dr.Table.Columns(x).ColumnName) <> valor Then
                                    errores &= "," & dr.Table.Columns(x).ColumnName
                                    dr.Item(dr.Table.Columns(x).ColumnName) = valor
                                End If
                            End If



                        End If
                    End If
                Catch ex As Exception
                    errores &= "," & dr.Table.Columns(x).ColumnName & "-ee-" & ex.Message
                End Try
            Next
            Return errores
        End Function
        Public Sub New(ByVal cmde As MysqlCommand, ByVal usu As Integer)
            cmd = cmde
            usuario = usu
        End Sub


    End Class
End Namespace
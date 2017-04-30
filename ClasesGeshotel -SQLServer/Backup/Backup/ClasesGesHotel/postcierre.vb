Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data
Namespace geshotel
    Partial Public Class GesHotelClase
        Public Function genera_manocorriente(ByVal Hotel_id As Integer, Optional ByVal fecha As Object = Nothing) As Integer
            Dim ErrorCode As Integer = 0
            Dim RowCount As Integer
            Dim nombre_vista As String = "manocorriente_dia"
            Dim nombre_fichero As String = "manocorriente_dia_reserva"
            Dim sqlborra As String = "DELETE  FROM " & nombre_fichero & " WHERE hotel_id = ?"
            Dim sqlinsert As String = "INSERT INTO " & nombre_fichero & " (hotel_id,fecha,reserva_id,servicio_id,cantidad,producido,facturado) " _
            & "Select hotel_id,fecha,reserva_id,servicio_id,cantidad,SUM(producido),SUM(facturado) from " & nombre_vista & " where hotel_id= ? "
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", Hotel_id)
            Dim fechaParam As New Odbc.OdbcParameter("@fecha_factura", fecha)
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            Try
                If IsDate(fecha) Then
                    cmd.Parameters.Add(fechaParam)
                    sqlborra += " AND fecha = ? "
                    sqlinsert += " AND fecha = ? "
                    RowCount = ExecuteNonQuery(cmd, sqlborra)
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(hotel_idParam)
                    cmd.Parameters.Add(fechaParam)
                Else
                    RowCount = ExecuteNonQuery(cmd, sqlborra)
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(hotel_idParam)
                End If
                sqlinsert += "GROUP BY hotel_id,fecha,reserva_id,servicio_id"
                RowCount = ExecuteNonQuery(cmd, sqlinsert)
            Catch ex As Exception
                ErrorCode = 1
            End Try
            flushConection(cmd, ErrorCode)
            Return ErrorCode
        End Function
        Public Function genera_desvios() As Integer
            Dim errorcode As Integer = 0
            Dim RowCount As Integer = 0
            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", 1)
            Dim tipo_hab_idParam As New Odbc.OdbcParameter("@tipo_id", 1)
            Dim desdeParam As New Odbc.OdbcParameter("@desde", Today())
            Dim hastaParam As New Odbc.OdbcParameter("@hasta", Today())
            Dim cmd As Odbc.OdbcCommand = prepareConection()

            Dim sqlinsert As String = "INSERT into desvios (reserva_id,tipo_habitacion_id,desde,hasta,interno,num_habitaciones,coste_unitario) " _
            & " VALUES (?,?,?,?,1,1,0)"
            Dim sql As String = " SELECT reservas.reserva_id,fecha_desde,fecha_hasta,habitaciones.tipo_habitacion_id " _
            & "FROM reservas " _
            & "Inner Join habitaciones_bloqueos ON habitaciones_bloqueos.reserva_id = reservas.reserva_id " _
            & "Inner Join habitaciones ON habitaciones_bloqueos.habitacion_id = habitaciones.habitacion_id " _
            & "WHERE habitaciones.numero_habitacion =  '999' AND reservas.estado_reserva_id >=3 " _
            & "AND (SELECT count(*) from desvios l WHERE l.reserva_id = reservas.reserva_id) =0"
            Dim reader As DataTableReader = getDataTable(cmd, sql)
            Try
                While reader.Read
                    reserva_idParam.Value = reader.Item("reserva_id")
                    tipo_hab_idParam.Value = reader.Item("tipo_habitacion_id")
                    desdeParam.Value = reader.Item("fecha_desde")
                    hastaParam.Value = reader.Item("fecha_hasta")
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(reserva_idParam)
                    cmd.Parameters.Add(tipo_hab_idParam)
                    cmd.Parameters.Add(desdeParam)
                    cmd.Parameters.Add(hastaParam)
                    RowCount = ExecuteNonQuery(cmd, sqlinsert)
                End While
            Catch ex As Exception
                errorcode = 1
            End Try
            flushConection(cmd, errorcode)
            Return errorcode
        End Function
        Public Function genera_historico(ByVal Hotel_id As Integer, ByVal nombre_fichero As String, Optional ByVal fecha As Object = Nothing, Optional ByVal dd As Integer = 0, Optional ByVal aa As Integer = 0) As Integer
            Dim ErrorCode As Integer = 0
            Dim RowCount As Integer
            Dim dia As Integer
            Dim mes As Integer
            Dim ano As Integer
            Dim where As String = ""
            Dim meses() As String = {"", "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre"}

            Dim sql As String = "SELECT lineas_factura.servicio_id As servicio,Sum(lineas_factura.cantidad)As Qty,lineas_factura.unidad_calculo_id As uc," _
            & "lineas_factura.fecha As fecha,ifnull(reservas.cliente_id,facturas.cliente_id) AS cliente, ifnull(lineas_factura.reserva_id,0) As reserva_id," _
            & "servicios.suma_servicio_id,servicios.resta_servicio_id,IF(desvio_id IS NULL,0,1) as desvio " _
            & "FROM lineas_factura " _
            & "Left Join facturas ON lineas_factura.factura_id = facturas.factura_id " _
            & "Left Join reservas ON lineas_factura.reserva_id = reservas.reserva_id " _
            & "Inner Join servicios ON lineas_factura.servicio_id = servicios.servicio_id " _
            & "left Join desvios ON desvios.reserva_id = reservas.reserva_id AND lineas_factura.fecha>=desvios.desde AND lineas_factura.fecha<desvios.hasta " _
            & "WHERE lineas_factura.hotel_id = '" & CStr(Hotel_id) & "' {where} " _
            & "GROUP BY lineas_factura.hotel_id,lineas_factura.servicio_id,lineas_factura.unidad_calculo_id,lineas_factura.reserva_id,fecha,desvio_id"

            Dim sqlborra As String = "DELETE from " & nombre_fichero & " WHERE hotel_id = '" & CStr(Hotel_id) & "' {where}"

            Dim fechaParam As New Odbc.OdbcParameter("@fecha", Today)
            Dim cmd As Odbc.OdbcCommand = prepareConection()

            If IsDate(fecha) Then  ' Solo cargamos un dia. En este caso, no hay que borrar ningún registro
                dia = Day(fecha)
                ano = Year(fecha)
                where = "AND lineas_factura.fecha = ? "
                fechaParam.Value = fecha
                cmd.Parameters.Clear()
                cmd.Parameters.Add(fechaParam)
            Else
                cmd.Parameters.Clear()
                If dd <> 0 Then      ' Queremos la carga de todos los meses el dia que marca dd
                    where = "AND Day(fecha)= '" & CStr(dd) & "' AND Year(fecha)= '" & CStr(aa)
                    sqlborra = sqlborra.Replace("{where}", " AND dia ='" & CStr(dd) & "'  AND any = '" & CStr(aa) & "'")
                    RowCount = ExecuteNonQuery(cmd, sqlborra)
                Else ' Queremos la carga de Todo el año
                    If aa = 0 Then ' Si no pasan el año considero el actual
                        aa = Year(Today)
                    End If
                    ano = aa
                    sqlborra = sqlborra.Replace("{where}", " AND any ='" & CStr(aa) & "'")
                    RowCount = ExecuteNonQuery(cmd, sqlborra)
                    ' La seleccion de lineas de factura será que sean menores que el dia de cierre del hotel
                    ' para ello miramos la fecha del ultimo cierre y ponemos en where fecha < fechacierrehotel
                    Dim fechacierrehotel As Date = FechaHotel(cmd, Hotel_id)

                    fechaParam.Value = fechacierrehotel
                    where = " AND Year(fecha)=  '" & CStr(aa) & "' AND fecha < ?"

                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(fechaParam)

                End If

            End If
            sql = sql.Replace("{where}", where)
            'RowCount = ExecuteNonQuery(cmd, sql)

            Dim diaParam As New Odbc.OdbcParameter("@dia", 1)
            Dim AnoParam As New Odbc.OdbcParameter("@ano", ano)
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", Hotel_id)
            Dim servicio_idParam As New Odbc.OdbcParameter("@servicio_id", 1)
            Dim uc_idParam As New Odbc.OdbcParameter("@uc_id", 1)
            Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", 1)
            Dim cantidadParam As New Odbc.OdbcParameter("@qty", 1)
            Dim cantidadmesParam As New Odbc.OdbcParameter("@qty", 1)
            Dim desvioparam As New Odbc.OdbcParameter("desvio", 0)

            Dim reader As DataTableReader = getDataTable(cmd, sql)
            Dim sqlinsert As String = "INSERT INTO " & nombre_fichero & " (dia,any,hotel_id,servicio_id,uc_id,cliente_id,desvio,{nombre_mes}) VALUES (?,?,?,?,?,?,?,?)" _
            & "ON DUPLICATE KEY UPDATE {nombre_mes} = Ifnull({nombre_mes},0) + ? "

            Dim servicio_suma As Integer = 0
            Dim servicio_resta As Integer = 0
            Dim cont As Integer = 0
            Try
                While reader.Read
                    mes = Month(reader.Item("fecha"))
                    diaParam.Value = Day(reader.Item("fecha"))
                    servicio_idParam.Value = reader.Item("servicio")
                    cantidadParam.Value = reader.Item("Qty")
                    cantidadmesParam.Value = reader.Item("Qty")
                    cliente_idParam.Value = reader.Item("cliente")
                    uc_idParam.Value = reader.Item("uc")
                    desvioparam.Value = reader.Item("desvio")

                    cont += 1
                    If cont Mod 500 = 0 Then
                        Console.WriteLine(cont)
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("suma_servicio_id")) Then
                        servicio_idParam.Value = reader.Item("suma_servicio_id")
                    End If

                    sql = sqlinsert.Replace("{nombre_mes}", meses(mes))

                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(diaParam)
                    cmd.Parameters.Add(AnoParam)
                    cmd.Parameters.Add(hotel_idParam)
                    cmd.Parameters.Add(servicio_idParam)
                    cmd.Parameters.Add(uc_idParam)
                    cmd.Parameters.Add(cliente_idParam)
                    cmd.Parameters.Add(desvioparam)
                    cmd.Parameters.Add(cantidadParam)
                    cmd.Parameters.Add(cantidadmesParam)
                    RowCount = ExecuteNonQuery(cmd, sql)

                    If Not reader.IsDBNull(reader.GetOrdinal("resta_servicio_id")) Then
                        servicio_idParam.Value = reader.Item("resta_servicio_id")
                        cantidadParam.Value = -reader.Item("Qty")
                        cantidadmesParam.Value = -reader.Item("Qty")
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(diaParam)
                        cmd.Parameters.Add(AnoParam)
                        cmd.Parameters.Add(hotel_idParam)
                        cmd.Parameters.Add(servicio_idParam)
                        cmd.Parameters.Add(uc_idParam)
                        cmd.Parameters.Add(cliente_idParam)
                        cmd.Parameters.Add(desvioparam)
                        cmd.Parameters.Add(cantidadParam)
                        cmd.Parameters.Add(cantidadmesParam)
                        RowCount = ExecuteNonQuery(cmd, sql)
                    End If

                End While
            Catch ee As Exception
                Dim err = ee.Message
                ErrorCode = 1
            End Try

            flushConection(cmd, ErrorCode)
            Return ErrorCode
        End Function
        Public Function genera_Solo_Alojamiento(ByVal Hotel_id As Integer, Optional ByVal dd As Integer = 0, Optional ByVal aa As Integer = 0) As Integer
            ' Mierda de funcion para generar las estadísticas de solo Alojamiento
            ' Como no es un servicio a facturar, lo calculamos como diferencia entre las pax y el resto de regímenes
            Dim ErrorCode As Integer = 0
            Dim RowCount As Integer
            Dim dia As Integer
            Dim mes As Integer
            Dim ano As Integer
            Dim where As String = ""
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            If aa = 0 Then ' Si no pasan el año considero el actual
                aa = Year(Today)
            End If
            ano = aa
            Dim sqlservicioSS As String = "Select servicio_id FROM servicios WHERE abreviatura ='SS'"
            Dim servicio_id As Object = ExecuteScalar(cmd, sqlservicioSS)
            If servicio_id Is Nothing Then
                Return 1
            End If
            Dim sqlborra As String = "DELETE from totales_resumen_servicios WHERE hotel_id = '" & CStr(Hotel_id) & "' AND servicio_id = '" _
            & CStr(servicio_id) & "'{where}"
            where = " AND any ='" & CStr(aa) & "'"
            If dd <> 0 Then 'no quieren todos los dias
                where = " AND dia ='" & CStr(dd) & "'"
            End If
            sqlborra = sqlborra.Replace("{where}", where)

            RowCount = ExecuteNonQuery(cmd, sqlborra)
            ' Cargamos los datos de pax
            Dim meses As String = "enero,febrero,marzo,abril,mayo,junio,julio,agosto,septiembre,octubre,noviembre,diciembre"
            Dim sum_meses As String = "SUM(enero),SUM(febrero),SUM(marzo),SUM(abril),SUM(mayo),SUM(junio),SUM(julio),SUM(agosto),SUM(septiembre),SUM(octubre),SUM(noviembre),SUM(diciembre)"

            Dim sqlinsert As String = "INSERT INTO totales_resumen_servicios (dia,any,hotel_id,servicio_id,uc_id,cliente_id,desvio,{meses}) SELECT dia,any,hotel_id," _
            & CStr(servicio_id) & " AS servicio_id,uc_id,cliente_id,desvio,{sum_meses} FROM totales_resumen_servicios INNER JOIN servicios ON totales_resumen_servicios.servicio_id=servicios.servicio_id " _
            & "WHERE servicios.concepto_acelerador_reservas_id = '99' AND " _
            & "totales_resumen_servicios.hotel_id= '" & CStr(Hotel_id) & "' {where} " _
            & "GROUP BY hotel_id,cliente_id,dia,any,uc_id,desvio"
            sqlinsert = sqlinsert.Replace("{where}", where)
            sqlinsert = sqlinsert.Replace("{meses}", meses)
            sqlinsert = sqlinsert.Replace("{sum_meses}", sum_meses)
            RowCount = ExecuteNonQuery(cmd, sqlinsert)
            'Aqui hemos insertado las pax, ahora hay que restar las pensiones, es decir las personas que vinieron
            'con servicio_id que tengan concepto_acelerador_reserva_id = 2
            'flushConection(cmd, ErrorCode)

            Dim arr_meses() As String = {"", "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre"}
            Dim arr_sum_meses() As String = {"", "SUM(enero)", "SUM(febrero)", "SUM(marzo)", "SUM(abril)", "SUM(mayo)", "SUM(junio)", "SUM(julio)", "SUM(agosto)", "SUM(septiembre)", "SUM(octubre)", "SUM(noviembre)", "SUM(diciembre)"}

            Dim sqlupdate As String = "UPDATE totales_resumen_servicios SET "
            Dim i As Integer

            For i = 1 To 12
                sqlupdate += arr_meses(i) + "=" + arr_meses(i) + "+ ? "
                If i < 12 Then
                    sqlupdate += ", "
                End If
            Next

            sqlupdate += "WHERE hotel_id = '" & CStr(Hotel_id) & "' AND servicio_id = '" _
            & CStr(servicio_id) & "' AND any ='" & CStr(aa) & "' And dia= ? AND uc_id = ? AND cliente_id = ? AND desvio= ?"

            ' selecciono los totales de servicio de tipo pension que sean distintos de SS 
            Dim Sql = "SELECT uc_id,cliente_id,dia,desvio,{sum_meses} FROM totales_resumen_servicios join servicios on totales_resumen_servicios.servicio_id=servicios.servicio_id " _
            & "INNER JOIN unidades_calculo ON totales_resumen_servicios.uc_id = unidades_calculo.unidad_calculo_id " _
            & " WHERE hotel_id = '" & CStr(Hotel_id) & "' AND servicios.sw_pension ='1' AND totales_resumen_servicios.servicio_id <>'" & CStr(servicio_id) _
            & "' {where} GROUP BY hotel_id,cliente_id,dia,any,uc_id,desvio"
            Sql = Sql.replace("{sum_meses}", sum_meses)
            Sql = Sql.replace("{where}", where)

            Try
                Dim reader As DataTableReader = getDataTable(cmd, Sql)
                Dim uc_idParam As New Odbc.OdbcParameter("@uc_id", 1)
                Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", 1)
                Dim dia_param As New Odbc.OdbcParameter("@dia", 0)
                Dim desvioparam As New Odbc.OdbcParameter("desvio", 0)
                Dim meses_param(13)
                For i = 1 To 12
                    meses_param(i) = New Odbc.OdbcParameter("@Qty", 0)
                Next
                Dim aux As Integer
                Dim cont As Integer = 0

                While reader.Read
                    cont += 1
                    If cont Mod 100 = 0 Then
                        Console.WriteLine(cont)
                    End If
                    cliente_idParam.Value = reader.Item("cliente_id")
                    uc_idParam.Value = reader.Item("uc_id")
                    dia_param.Value = reader.Item("dia")
                    desvioparam.Value = reader.Item("desvio")
                    For i = 1 To 12
                        aux = -reader.Item(arr_sum_meses(i))
                        If aux <> 0 Then
                            meses_param(i).Value = aux
                        Else
                            meses_param(i).Value = 0
                        End If
                    Next
                    cmd.Parameters.Clear()
                    For i = 1 To 12
                        cmd.Parameters.Add(meses_param(i))
                    Next
                    cmd.Parameters.Add(dia_param)
                    cmd.Parameters.Add(uc_idParam)
                    cmd.Parameters.Add(cliente_idParam)
                    cmd.Parameters.Add(desvioparam)
                    RowCount = ExecuteNonQuery(cmd, sqlupdate)
                    If RowCount <> 1 Then ' Curioso caso Quiere decir que no existía y por lo tanto hay que hacer un insert
                        sqlinsert = "INSERT INTO totales_resumen_servicios (dia,any,hotel_id,servicio_id,uc_id,cliente_id,desvio,{meses}) " _
                        & "VALUES (?," & CStr(aa) & "," & CStr(Hotel_id) & "," & CStr(servicio_id) & ",?,?,?"

                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(dia_param)
                        cmd.Parameters.Add(uc_idParam)
                        cmd.Parameters.Add(cliente_idParam)
                        cmd.Parameters.Add(desvioparam)
                        For i = 1 To 12
                            sqlinsert += ",?"
                            cmd.Parameters.Add(meses_param(i))
                        Next
                        sqlinsert += ")"
                        sqlinsert = sqlinsert.Replace("{meses}", meses)
                        RowCount = ExecuteNonQuery(cmd, sqlinsert)
                    End If
                End While
            Catch ex As Exception
                Dim msg As String = ex.Message
                ErrorCode = 1
            End Try

            flushConection(cmd, ErrorCode)

        End Function
        Function Genera_produccion_Agencia_Dia(ByVal Hotel_id As Integer, Optional ByVal fecha As Object = Nothing) As Integer
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim errorCode As Integer = 0
            Dim totproducido As Double = 0
            Dim rowcount As Integer
            Dim cont As Integer = 0
            Dim sqlborra As String = "Delete from totales_agencia_dia Where hotel_id=? {where}"
            Dim where As String = ""
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", Hotel_id)
            Dim fechaParam As New Odbc.OdbcParameter("@fecha", Today)

            Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", 1)
            Dim servicio_idParam As New Odbc.OdbcParameter("@servicio_id", 1)
            Dim cantidadParam As New Odbc.OdbcParameter("@cantidad", 1)
            Dim nhabParam As New Odbc.OdbcParameter("@nhab", 1)
            Dim nhabParam1 As New Odbc.OdbcParameter("@nhab", 1)
            Dim producidoParam As New Odbc.OdbcParameter("@producido", 1)
            Dim cantidadParam1 As New Odbc.OdbcParameter("@cantidad", 1)
            Dim producidoParam1 As New Odbc.OdbcParameter("@producido", 1)
            Dim habitacionParam As New Odbc.OdbcParameter("@precio", 1)
            Dim habitacionParam1 As New Odbc.OdbcParameter("@precio", 1)
            Dim pensionParam As New Odbc.OdbcParameter("@precio", 1)
            Dim pensionParam1 As New Odbc.OdbcParameter("@precio", 1)
            Dim otrosParam As New Odbc.OdbcParameter("@precio", 1)
            Dim otrosParam1 As New Odbc.OdbcParameter("@precio", 1)

            Dim fechacierrehotel As Date = FechaHotel(cmd, Hotel_id)
            'fechaParam.Value = fechacierrehotel
            If Not (IsNothing(fecha)) Then
                where = "AND fecha = ?"
                fechaParam.Value = fecha
                cmd.Parameters.Add(fechaParam)
            End If
            sqlborra = sqlborra.Replace("{where}", where)

            rowcount = ExecuteNonQuery(cmd, sqlborra)
            Dim cliente_defecto As Integer = ExecuteScalar(cmd, "Select cliente_id FROM clientes Where cliente_defecto=1")

            Dim SqlInsert As String = "INSERT INTO totales_agencia_dia (hotel_id,fecha,cliente_id,servicio_id,cantidad,nhab,producido,produccion_habitacion,produccion_pension,produccion_otros) " _
            & " VALUES (?,?,?,?,?,?,?,?,?,?)" _
            & "ON DUPLICATE KEY UPDATE cantidad = cantidad + ? , nhab = nhab + ? ,producido = producido + ?, produccion_habitacion = produccion_habitacion + ?, " _
            & "produccion_pension = produccion_pension + ?, produccion_otros = produccion_otros + ?"

            Dim Sql As String = "SELECT linea_factura_id,fecha,lineas_factura.servicio_id,cantidad,servicios.tipo_servicio_id,concepto_acelerador_reservas_id," _
            & "(cantidad* ifnull(precio_produccion,precio) * 100) / (100 + porc_impuesto) AS producido," _
            & "tipo_linea_factura,reserva_id," _
            & "(select cliente_id From facturas  where facturas.factura_id=lineas_factura.factura_id) As cliente_factura," _
            & "(select cliente_id from reservas  where reservas.reserva_id= lineas_factura.reserva_id) As cliente_reserva " _
            & "FROM lineas_factura Inner Join servicios ON lineas_factura.servicio_id = servicios.servicio_id " _
            & "WHERE servicios.sw_produccion=1 AND lineas_factura.hotel_id= ? {where}"

            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)

            If Not (IsNothing(fecha)) Then
                where = "AND lineas_factura.fecha = ?"
                fechaParam.Value = fecha
                cmd.Parameters.Add(fechaParam)
            End If
            Sql = Sql.Replace("{where}", where)

            Dim reader As DataTableReader = getDataTable(cmd, Sql)
            Dim tipo_linea As String = ""
            Dim cliente_id As Integer = 0
            Dim cliente_reserva As Integer = 0
            Dim reserva_id As Integer = 0
            Dim tipo_servicio As Integer = 0
            Dim concepto As Integer = 0
            Dim cantidad As Double = 0
            Dim linea_factura_id As Integer
            Try
                While reader.Read
                    cont += 1
                    If cont Mod 1000 = 0 Then
                        Console.WriteLine("Hotel=" & CStr(Hotel_id) & " Contador=" & CStr(cont))
                        'Console.WriteLine("Producido=" & CStr(totproducido))
                    End If

                    linea_factura_id = reader.Item("linea_factura_id")
                    fechaParam.Value = reader.Item("fecha")
                    servicio_idParam.Value = reader.Item("servicio_id")
                    producidoParam.Value = reader.Item("producido")
                    totproducido += producidoParam.Value
                    cantidad = reader.Item("cantidad")
                    cantidadParam.Value = cantidad
                    cantidadParam1.Value = cantidad

                    concepto = 0
                    If Not reader.IsDBNull(reader.GetOrdinal("concepto_acelerador_reservas_id")) Then
                        concepto = reader.Item("concepto_acelerador_reservas_id")
                    End If

                    If concepto = 1 Then
                        nhabParam.Value = cantidad
                        nhabParam1.Value = cantidad
                    Else
                        nhabParam.Value = 0.0
                        nhabParam1.Value = 0.0
                    End If
                    producidoParam1.Value = producidoParam.Value
                    tipo_servicio = reader.Item("tipo_servicio_id")
                    habitacionParam.Value = 0.0
                    habitacionParam1.Value = 0.0
                    pensionParam.Value = 0.0
                    pensionParam1.Value = 0.0
                    otrosParam.Value = 0.0
                    otrosParam1.Value = 0.0
                    Select Case tipo_servicio
                        Case 1
                            habitacionParam.Value = producidoParam.Value
                            habitacionParam1.Value = producidoParam.Value
                        Case 2
                            pensionParam.Value = producidoParam.Value
                            pensionParam1.Value = producidoParam.Value
                        Case Else
                            otrosParam.Value = producidoParam.Value
                            otrosParam1.Value = producidoParam.Value
                    End Select
                    cliente_id = cliente_defecto
                    If Not reader.IsDBNull(reader.GetOrdinal("cliente_factura")) Then
                        cliente_id = reader.Item("cliente_factura")
                    Else
                        If Not reader.IsDBNull(reader.GetOrdinal("reserva_id")) Then
                            tipo_linea = reader.Item("tipo_linea_factura")
                            cliente_id = reader.Item("cliente_reserva")
                            If tipo_linea = "M" Then
                                cliente_id = cliente_defecto
                            End If
                        End If
                    End If
                    ' Ahora nos queda mirar que si el cliente es un huesped (de tipo 3, le ponemos el cliente defecto)
                    cmd.Parameters.Clear()
                    cliente_idParam.Value = cliente_id
                    cmd.Parameters.Add(cliente_idParam)
                    Dim grupo_cliente As Integer = ExecuteScalar(cmd, "Select grupo_cliente_id FROM clientes WHERE cliente_id = ? ")
                    If grupo_cliente > 2 Then
                        cliente_idParam.Value = cliente_defecto
                    End If
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(hotel_idParam)
                    cmd.Parameters.Add(fechaParam)
                    cmd.Parameters.Add(cliente_idParam)
                    cmd.Parameters.Add(servicio_idParam)
                    cmd.Parameters.Add(cantidadParam)
                    cmd.Parameters.Add(nhabParam)
                    cmd.Parameters.Add(producidoParam)
                    cmd.Parameters.Add(habitacionParam)
                    cmd.Parameters.Add(pensionParam)
                    cmd.Parameters.Add(otrosParam)
                    cmd.Parameters.Add(cantidadParam1)
                    cmd.Parameters.Add(nhabParam1)
                    cmd.Parameters.Add(producidoParam1)
                    cmd.Parameters.Add(habitacionParam1)
                    cmd.Parameters.Add(pensionParam1)
                    cmd.Parameters.Add(otrosParam1)
                    If cantidadParam.Value <> 0 Or producidoParam.Value <> 0 Then
                        rowcount = ExecuteNonQuery(cmd, SqlInsert)
                        If rowcount = 0 Then
                            errorCode = 1
                        End If
                    End If
                End While

            Catch ex As Exception
                Dim msg As String = ex.Message
                errorCode = 1
            End Try
            Console.WriteLine(cont)
            Console.WriteLine("Producido=" & CStr(totproducido))
            flushConection(cmd, 0)
            Return errorCode
        End Function
        Public Function generarTablasPostCierre(ByVal Hotel_id As Integer, Optional ByVal fecha As Object = Nothing) As Integer
            Dim errorcode As Integer = 0
            errorcode = genera_manocorriente(Hotel_id, fecha)
            If errorcode <> 0 Then
                Return 1
            End If
            errorcode = genera_historico(Hotel_id, "totales_resumen_servicios", fecha)
            If errorcode <> 0 Then
                Return 2
            End If
            errorcode = genera_desvios()
            Dim dia As Integer = 0
            Dim any As Integer = Year(Today)
            If Not (IsNothing(fecha)) Then
                dia = Day(fecha)
                any = Year(fecha)
            End If
            errorcode = genera_Solo_Alojamiento(Hotel_id, dia, any)
            If errorcode <> 0 Then
                Return 3
            End If
            errorcode = Genera_produccion_Agencia_Dia(Hotel_id, fecha)
            Return errorcode
            If errorcode <> 0 Then
                Return 4
            End If

        End Function

    End Class
End Namespace


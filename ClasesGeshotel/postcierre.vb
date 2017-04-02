Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data
Imports System.Data.Odbc
Imports System.Text
Imports System.IO
Imports System.Collections.Generic

Namespace geshotelk
    Partial Public Class GesHotelClase
        Public Function Materializa_tablas(ByVal cmd As Odbc.OdbcCommand) As Integer
            Dim ErrorCode As Integer = 0

            Dim sql_truncate = "Truncate Table tabla_clientes_repetidos"
            Dim sql_insert As String = "INSERT INTO tabla_clientes_repetidos SELECT * FROM vista_clientes_repetidos"
            Dim RowCount As Integer
            Try
                RowCount = ExecuteNonQuery(cmd, sql_truncate)
                RowCount = ExecuteNonQuery(cmd, sql_insert)
            Catch
            End Try
            Return ErrorCode

        End Function
        Public Function Materializa_tablas() As Integer
            Dim ErrorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            ErrorCode = Materializa_tablas(cmd)
            flushConection(cmd, ErrorCode)
        End Function
        Public Function genera_manocorriente(ByVal cmd As Odbc.OdbcCommand, ByVal Hotel_id As Integer, ByVal fecha As Date) As Integer
            Dim ErrorCode As Integer = 0
            Dim RowCount As Integer
            Dim nombre_vista As String = "manocorriente_dia"
            Dim nombre_fichero As String = "manocorriente_dia_reserva"
            Dim sqlborra As String = "DELETE  FROM " & nombre_fichero & " WHERE hotel_id = ?"
            Dim sqlinsert As String = "INSERT INTO " & nombre_fichero & " (hotel_id,fecha,reserva_id,servicio_id,cantidad,producido,facturado) " _
            & "SELECT hotel_id,fecha,reserva_id,servicio_id,SUM(cantidad),SUM(producido),SUM(facturado) from " _
            & "(select hotel_id,fecha,ifnull(reserva_id,0) AS reserva_id, SUM(cantidad) As Cantidad," _
            & "SUM((((cantidad*ifnull(precio_produccion,precio)) * 100) / (100 + porc_impuesto))) AS producido, " _
            & "0 AS facturado,lineas_factura.servicio_id AS servicio_id " _
            & "FROM lineas_factura join servicios on lineas_factura.servicio_id = servicios.servicio_id " _
            & "WHERE servicios.sw_produccion = 1 And hotel_id={hotel_id} {fecha} " _
            & "GROUP BY lineas_factura.hotel_id,lineas_factura.fecha,lineas_factura.servicio_id,ifnull(lineas_factura.reserva_id,0) " _
            & "UNION ALL " _
            & "SELECT facturas.hotel_id AS hotel_id, " _
            & "facturas.fecha_factura AS fecha," _
            & "ifnull(lineas_factura.reserva_id,0) AS reserva_id, SUM(cantidad) As Cantidad, 0 AS producido," _
            & "SUM((((lineas_factura.cantidad * lineas_factura.precio) * 100) / (100 + lineas_factura.porc_impuesto))) AS facturado," _
            & "servicios.servicio_id AS servicio_id " _
            & "FROM lineas_factura JOIN facturas on lineas_factura.factura_id = facturas.factura_id " _
            & "JOIN servicios ON lineas_factura.servicio_id = servicios.servicio_id " _
            & "JOIN tipos_servicio on servicios.tipo_servicio_id = tipos_servicio.tipo_servicio_id " _
            & "WHERE servicios.sw_produccion = 1 And lineas_factura.hotel_id={hotel_id} {fecha1} " _
            & "GROUP BY facturas.hotel_id,facturas.fecha_factura,servicios.servicio_id,ifnull(lineas_factura.reserva_id,0)) As T " _
            & "GROUP BY hotel_id,fecha,reserva_id,servicio_id "
            sqlinsert = sqlinsert.Replace("{hotel_id}", Hotel_id)
            '& "Select hotel_id,fecha,reserva_id,servicio_id,cantidad,SUM(producido),SUM(facturado) from " & nombre_vista & " where hotel_id= ? "
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", Hotel_id)
            Dim fechaParam As New Odbc.OdbcParameter("@fecha_factura", fecha)

            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            Try
                If IsDate(fecha) Then
                    cmd.Parameters.Add(fechaParam)
                    sqlborra += " AND fecha = ? "
                    sqlinsert = sqlinsert.Replace("{fecha}", "And fecha ='" + fecha.ToString("yyyy-MM-dd") + "'")
                    sqlinsert = sqlinsert.Replace("{fecha1}", "And fecha_factura ='" + fecha.ToString("yyyy-MM-dd") + "'")
                    RowCount = ExecuteNonQuery(cmd, sqlborra)

                Else
                    RowCount = ExecuteNonQuery(cmd, sqlborra)

                End If
                RowCount = ExecuteNonQuery(cmd, sqlinsert)
            Catch ex As Exception
                ErrorCode = 1
            End Try

            Return ErrorCode
        End Function
        Public Function genera_manocorriente(ByVal Hotel_id As Integer, ByVal fecha As Date) As Integer
            Dim Errorcode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Errorcode = genera_manocorriente(cmd, Hotel_id, fecha)
            flushConection(cmd, Errorcode)
            Return Errorcode
        End Function
        Public Function genera_desvios(ByVal cmd As Odbc.OdbcCommand) As Integer

            Dim errorcode As Integer = 0
            Dim RowCount As Integer = 0
            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", 1)
            Dim tipo_hab_idParam As New Odbc.OdbcParameter("@tipo_id", 1)
            Dim desdeParam As New Odbc.OdbcParameter("@desde", Today())
            Dim hastaParam As New Odbc.OdbcParameter("@hasta", Today())


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

            Return errorcode
        End Function
        Public Function genera_desvios() As Integer
            Dim ErrorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            flushConection(cmd, ErrorCode)
            Return ErrorCode
        End Function
        Public Function genera_historico(ByVal cmd As Odbc.OdbcCommand, ByVal Hotel_id As Integer, ByVal nombre_fichero As String, ByVal fecha As Date, Optional ByVal dd As Integer = 0, Optional ByVal aa As Integer = 0) As Integer
            Dim ErrorCode As Integer = 0
            Dim RowCount As Integer
            Dim dia As Integer = Day(fecha)
            Dim mes As Integer = Month(fecha)
            Dim ano As Integer = Year(fecha)
            Dim where As String = ""
            Dim meses() As String = {"", "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre"}
            If aa = 0 Then aa = Year(Today)

            Dim sql As String = "SELECT Sum(reservas_servicios.cantidad)As Qty,reservas_servicios.servicio_id As servicio,reservas_servicios.reserva_id, " _
            & "reservas_servicios.unidad_calculo_id As uc,ifnull(reservas_servicios.fecha_desde,reservas.fecha_prevista_llegada) AS desde, " _
            & "ifnull(reservas_servicios.fecha_hasta,reservas.fecha_prevista_salida) AS hasta, ifnull(reservas.cliente_id,16) AS cliente, " _
            & "servicios.suma_servicio_id,servicios.resta_servicio_id, " _
            & "IF ((SELECT MAX(desvio_id) FROM desvios Where desvios.reserva_id=reservas_servicios.reserva_id AND desvios.desde<=? AND desvios.hasta >= ?) IS NULL,0,1) As desvio " _
            & "FROM reservas_servicios " _
            & "Inner Join servicios ON reservas_servicios.servicio_id = servicios.servicio_id " _
            & "Inner Join reservas ON reservas_servicios.reserva_id = reservas.reserva_id " _
            & "Inner Join unidades_calculo ON reservas_servicios.unidad_calculo_id = unidades_calculo.unidad_calculo_id " _
            & "Left Join desvios ON desvios.reserva_id = reservas.reserva_id " _
            & "WHERE reservas.hotel_id =  '" & CStr(Hotel_id) & "' AND reservas.estado_reserva_id >='3' {where} " _
            & "GROUP BY servicios.nombre_servicio,reservas_servicios.reserva_id,reservas_servicios.unidad_calculo_id "


            Dim sqlborra As String = "UPDATE totales_resumen_servicios SET {nombre_mes}=0 WHERE hotel_id=? AND any=? and dia=?"
            sqlborra = sqlborra.Replace("{nombre_mes}", meses(mes))
            Dim sql_desvio As String = ""

            Dim DesdeParam As New Odbc.OdbcParameter("@fecha", Today)
            Dim HastaParam As New Odbc.OdbcParameter("@fecha", Today)
            Dim Desde1Param As New Odbc.OdbcParameter("@fecha", Today)
            Dim Hasta1Param As New Odbc.OdbcParameter("@fecha", Today)

            Dim fechacierrehotel As Date = FechaHotel(cmd, Hotel_id)
            If IsDate(fecha) Then  ' Solo cargamos un dia. En este caso, no hay que borrar ningún registro


                aa = Year(fecha)
                where = "AND ifnull(reservas_servicios.fecha_desde,reservas.fecha_prevista_llegada) <= ? " _
                & "AND ifnull(reservas_servicios.fecha_hasta,reservas.fecha_prevista_salida) > ? "
                DesdeParam.Value = fecha
                HastaParam.Value = fecha
                Desde1Param.Value = fecha
                Hasta1Param.Value = fecha
            Else
                ErrorCode = 2

                Return ErrorCode
            End If
            sql = sql.Replace("{where}", where)
            Dim diaParam As New Odbc.OdbcParameter("@dia", dia)
            Dim AnoParam As New Odbc.OdbcParameter("@ano", ano)
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", Hotel_id)
            Dim servicio_idParam As New Odbc.OdbcParameter("@servicio_id", 1)
            Dim uc_idParam As New Odbc.OdbcParameter("@uc_id", 1)
            Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", 1)
            Dim cantidadParam As New Odbc.OdbcParameter("@qty", 1)
            Dim cantidadmesParam As New Odbc.OdbcParameter("@qty", 1)
            Dim desvioparam As New Odbc.OdbcParameter("desvio", 0)

            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            cmd.Parameters.Add(AnoParam)
            cmd.Parameters.Add(diaParam)
            RowCount = ExecuteNonQuery(cmd, sqlborra)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(DesdeParam)
            cmd.Parameters.Add(HastaParam)
            cmd.Parameters.Add(Desde1Param)
            cmd.Parameters.Add(Hasta1Param)
            Dim reader As DataTableReader = getDataTable(cmd, sql)
            Dim sqlinsert As String = "INSERT INTO " & nombre_fichero & " (dia,any,hotel_id,servicio_id,uc_id,cliente_id,desvio,{nombre_mes}) VALUES (?,?,?,?,?,?,?,?)" _
            & "ON DUPLICATE KEY UPDATE {nombre_mes} = Ifnull({nombre_mes},0) + ? "

            Dim servicio_suma As Integer = 0
            Dim servicio_resta As Integer = 0
            Dim cont As Integer = 0
            Try
                While reader.Read

                    servicio_idParam.Value = reader.Item("servicio")
                    cantidadParam.Value = reader.Item("Qty")
                    cantidadmesParam.Value = reader.Item("Qty")
                    cliente_idParam.Value = reader.Item("cliente")
                    uc_idParam.Value = reader.Item("uc")
                    desvioparam.Value = reader.Item("desvio")

                    cont += 1
                    If cont Mod 500 = 0 Then
                        Console.WriteLine("Genera_historico=" & cont)
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

            Return ErrorCode
        End Function
        Public Function genera_historico(ByVal Hotel_id As Integer, Optional ByVal nombre_fichero As String = "totales_resumen_servicios", Optional ByVal fecha As Object = Nothing, Optional ByVal dd As Integer = 0, Optional ByVal aa As Integer = 0) As Integer
            Dim ErrorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            ErrorCode = genera_historico(cmd, Hotel_id, nombre_fichero, fecha, dd, aa)
            flushConection(cmd, ErrorCode)
            Return ErrorCode
        End Function
        Public Function genera_Solo_Alojamiento(ByVal cmd As Odbc.OdbcCommand, ByVal Hotel_id As Integer, Optional ByVal dd As Integer = 0, Optional ByVal aa As Integer = 0) As Integer
            ' Mierda de funcion para generar las estadísticas de solo Alojamiento
            ' Como no es un servicio a facturar, lo calculamos como diferencia entre las pax y el resto de regímenes
            Dim ErrorCode As Integer = 0
            Dim RowCount As Integer
            Dim dia As Integer
            Dim mes As Integer
            Dim ano As Integer
            Dim where As String = ""

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
                where = where & " AND dia ='" & CStr(dd) & "'"
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
            Sql = Sql.Replace("{sum_meses}", sum_meses)
            Sql = Sql.Replace("{where}", where)

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
            Return ErrorCode
        End Function
        Public Function genera_Solo_Alojamiento(ByVal Hotel_id As Integer, Optional ByVal dd As Integer = 0, Optional ByVal aa As Integer = 0) As Integer
            Dim ErrorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            ErrorCode = genera_Solo_Alojamiento(cmd, Hotel_id, dd, aa)
            flushConection(cmd, ErrorCode)

        End Function
        Function Genera_informe_produccion(ByVal cmd As Odbc.OdbcCommand, ByVal Hotel_id As Integer, ByVal fecha As Date) As Integer
            Dim errorCode As Integer = 0
            Dim Rowcount As Integer = 0
            Dim sql_borra As String = "DELETE FROM informe_produccion WHERE fecha =? AND hotel_id = ?"
            Dim sql_producido As String = "INSERT INTO informe_produccion SELECT 1 AS tipo_linea, fecha,hotel_id,lineas_factura.servicio_id AS servicio_id,  " _
            & "sum(cantidad) AS cantidad, round(sum((((cantidad * ifnull(precio_produccion,precio)) * 100) / (100 + porc_impuesto))),2) AS importe " _
            & "FROM lineas_factura " _
            & "JOIN servicios ON lineas_factura.servicio_id = servicios.servicio_id " _
            & "WHERE servicios.sw_produccion = '1' AND fecha= ? AND hotel_id = ? " _
            & "GROUP BY lineas_factura.hotel_id,lineas_factura.fecha,lineas_factura.servicio_id "
            Dim sql_facturado As String = "INSERT INTO informe_produccion (SELECT 2 AS tipo_linea, facturas.fecha_factura AS Fecha, facturas.hotel_id AS hotel_id,  Null As Servicio_id,  " _
            & " COUNT(distinct facturas.factura_id) AS cantidad, " _
            & "-(round(sum((((lineas_factura.cantidad * lineas_factura.precio) * 100) / (100 + lineas_factura.porc_impuesto))),2)) AS importe " _
            & "FROM lineas_factura " _
            & "JOIN facturas ON lineas_factura.factura_id = facturas.factura_id " _
            & "JOIN servicios on lineas_factura.servicio_id = servicios.servicio_id " _
            & "WHERE servicios.sw_produccion = '1' AND facturas.fecha_factura= ? AND facturas.hotel_id = ? " _
            & "GROUP BY facturas.hotel_id,facturas.fecha_factura) "
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", Hotel_id)
            Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(fechaParam)
            cmd.Parameters.Add(hotel_idParam)
            Rowcount = ExecuteNonQuery(cmd, sql_borra)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(fechaParam)
            cmd.Parameters.Add(hotel_idParam)
            Rowcount = ExecuteNonQuery(cmd, sql_producido)
            If Rowcount = 0 Then
                errorCode = 1
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add(fechaParam)
            cmd.Parameters.Add(hotel_idParam)
            Rowcount = ExecuteNonQuery(cmd, sql_facturado)
            If Rowcount = 0 Then
                errorCode = 1
            End If
            Return errorCode
        End Function
        Function Genera_informe_produccion(ByVal Hotel_id As Integer, ByVal fecha As Date) As Integer
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim errorCode As Integer = 0
            Genera_informe_produccion(cmd, Hotel_id, fecha)
            flushConection(cmd, 0)
            Return errorCode
        End Function
        Function Genera_produccion_Agencia_Dia(ByVal cmd As Odbc.OdbcCommand, ByVal Hotel_id As Integer, Optional ByVal fecha As Object = Nothing) As Integer
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
            Dim uc_idParam As New Odbc.OdbcParameter("@uc_id", 1)
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

            Dim SqlInsert As String = "INSERT INTO totales_agencia_dia (hotel_id,fecha,cliente_id,servicio_id,uc_id,cantidad,nhab,producido,produccion_habitacion,produccion_pension,produccion_otros) " _
            & " VALUES (?,?,?,?,?,?,?,?,?,?,?)" _
            & "ON DUPLICATE KEY UPDATE cantidad = cantidad + ? , nhab = nhab + ? ,producido = producido + ?, produccion_habitacion = produccion_habitacion + ?, " _
            & "produccion_pension = produccion_pension + ?, produccion_otros = produccion_otros + ?"

            Dim Sql As String = "SELECT linea_factura_id,lineas_factura.fecha,lineas_factura.servicio_id,cantidad,servicios.tipo_servicio_id,unidad_calculo_id,concepto_acelerador_reservas_id," _
            & "(cantidad* ifnull(precio_produccion,precio) * 100) / (100 + porc_impuesto) AS producido," _
            & "tipo_linea_factura,lineas_factura.reserva_id," _
            & "Ifnull(IF (lineas_factura.tipo_linea_factura='M',cliente_directo.cliente_id,null),IF ((select permite_credito FROM clientes where cliente_id =Ifnull(facturas.cliente_id,ifnull(reservas.cliente_id_factura,reservas.cliente_id))),Ifnull(facturas.cliente_id,ifnull(reservas.cliente_id_factura,reservas.cliente_id)),cliente_directo.cliente_id)) As cliente_factura " _
            & "FROM (select cliente_id from clientes where cliente_defecto='1') cliente_directo " _
            & "INNER Join servicios INNER JOIN lineas_factura ON lineas_factura.servicio_id = servicios.servicio_id " _
            & "LEFT JOIN facturas ON lineas_factura.factura_id = facturas.factura_id " _
            & "LEFT JOIN reservas ON lineas_factura.reserva_id = reservas.reserva_id " _
            & "WHERE servicios.sw_produccion=1 AND lineas_factura.hotel_id= ? {where}"

            ' Esta linea la he quitado del select
            '            & "(select cliente_id From facturas  where facturas.factura_id=lineas_factura.factura_id) As cliente_factura," _
            '            & "(select ifnull(cliente_id_factura,cliente_id) from reservas  where reservas.reserva_id= lineas_factura.reserva_id) As cliente_reserva " _


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
            Dim uc_id As Integer = 0
            Dim concepto As Integer = 0
            Dim cantidad As Double = 0
            Dim linea_factura_id As Integer
            Dim cant_total As Double = 0
            Try
                While reader.Read
                    cont += 1
                    If cont Mod 1000 = 0 Then
                        Console.WriteLine("Hotel=" & CStr(Hotel_id) & " Contador=" & CStr(cont))
                        'Console.WriteLine("Producido=" & CStr(totproducido))
                    End If

                    linea_factura_id = reader.Item("linea_factura_id")
                    If linea_factura_id = 1088630 Then
                        Console.WriteLine("Siniestro")
                    End If
                    fechaParam.Value = reader.Item("fecha")
                    servicio_idParam.Value = reader.Item("servicio_id")
                    uc_idParam.Value = reader.Item("unidad_calculo_id")
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
                        '                    Else
                        '                       If Not reader.IsDBNull(reader.GetOrdinal("reserva_id")) Then
                        'tipo_linea = reader.Item("tipo_linea_factura")
                        'cliente_id = reader.Item("cliente_reserva")
                        'If tipo_linea = "M" Then
                        'cliente_id = cliente_defecto
                        'End If
                        'End If
                    End If

                    ' Ahora nos queda mirar que si el cliente no permite credito, le ponemos el cliente defecto)
                    'cmd.Parameters.Clear()
                    cliente_idParam.Value = cliente_id
                    'cmd.Parameters.Add(cliente_idParam)
                    'Dim permite_credito As Integer = ExecuteScalar(cmd, "Select permite_credito FROM clientes WHERE cliente_id = ? ")
                    'If permite_credito = 0 Then
                    'cliente_idParam.Value = cliente_defecto
                    'End If
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(hotel_idParam)
                    cmd.Parameters.Add(fechaParam)
                    cmd.Parameters.Add(cliente_idParam)
                    cmd.Parameters.Add(servicio_idParam)
                    cmd.Parameters.Add(uc_idParam)
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
                    'If cliente_id = "1" And servicio_idParam.Value = 11 Then
                    'cant_total += cantidad
                    'Console.WriteLine("linea_factura_id=" & linea_factura_id & " cantidad=" & cantidad & " Total=" & cant_total)
                    'End If
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
            Return errorCode
        End Function

        Function Genera_produccion_Agencia_Dia(ByVal Hotel_id As Integer, Optional ByVal fecha As Object = Nothing) As Integer
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            errorCode = Genera_produccion_Agencia_Dia(cmd, Hotel_id, fecha)
            flushConection(cmd, 0)
            Return errorCode
        End Function
        Function genera_produccion_ttoo_dia(ByVal cmd As Odbc.OdbcCommand, ByVal hotel_id As Integer, ByVal fecha As Date) As Integer
            ' Esta carga la tabla produccion_ttoo_dia en la que no está sumado todo el credito al cliente extra contado
            ' la operativa es la siguiente.
            ' Todo lo automatico va al cliente_id de la reserva
            ' Todo lo manual de serie 1 va cliente extra contado
            ' Cojo solo serie 1,2 y 9 y con sw_produccion a 1
            Dim cliente_defecto As Integer = ExecuteScalar(cmd, "select cliente_id from clientes where cliente_defecto=1")
            Dim errorcode As Integer = 0
            Dim sql_selec As String = "SELECT lineas_factura.tipo_linea_factura,lineas_factura.cantidad,(cantidad * ifnull(precio_produccion,precio)) As producido ," _
            & "reservas.cliente_id AS ttoo_id,reservas.cliente_id_factura AS reserva_cliente_factura_id," _
            & "lineas_factura.fecha,facturas.serie_id,facturas.cliente_id AS factura_cliente_id, clientes.grupo_cliente_id, " _
            & "lineas_factura.servicio_id " _
            & "FROM lineas_factura " _
            & "LEFT JOIN facturas ON facturas.factura_id = lineas_factura.factura_id " _
            & "LEFT JOIN reservas ON lineas_factura.reserva_id = reservas.reserva_id " _
            & "LEFT JOIN clientes ON reservas.cliente_id_factura = clientes.cliente_id " _
            & "INNER JOIN servicios ON lineas_factura.servicio_id = servicios.servicio_id " _
            & "WHERE servicios.sw_produccion = 1 AND " _
            & "lineas_factura.fecha = ? AND lineas_factura.hotel_id = ? "
            Dim SqlInsert As String = "INSERT INTO produccion_ttoo_dia (hotel_id,fecha,cliente_id,servicio_id,cantidad,importe) " _
            & " VALUES (?,?,?,?,?,?) " _
            & "ON DUPLICATE KEY UPDATE cantidad = cantidad + ? , importe = importe + ? "
            Dim sql_delete As String = "DELETE FROM produccion_ttoo_dia WHERE fecha= ? AND hotel_id =? "
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)

            Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", 1)
            Dim servicio_idParam As New Odbc.OdbcParameter("@servicio_id", 1)
            Dim cantidadParam As New Odbc.OdbcParameter("@cantidad", 1)
            Dim cantidadParam1 As New Odbc.OdbcParameter("@cantidad", 1)
            Dim precioParam As New Odbc.OdbcParameter("@precio", 1)
            Dim precioParam1 As New Odbc.OdbcParameter("@precio", 1)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(fechaParam)
            cmd.Parameters.Add(hotel_idParam)
            ' Primero borro los posibles registros que pudieran haber
            errorcode = ExecuteNonQuery(cmd, sql_delete)
            Dim reader As DataTableReader = getDataTable(cmd, sql_selec)
            Dim tipo_linea As String
            Dim serie_id As Object
            While reader.Read
                Dim cliente_id As Integer
                tipo_linea = reader.Item("tipo_linea_factura")
                serie_id = reader.Item("serie_id")
                cantidadParam.Value = reader.Item("cantidad")
                cantidadParam1.Value = reader.Item("cantidad")
                If reader.Item("producido") <> 0 Then
                    precioParam.Value = reader.Item("producido")
                    servicio_idParam.Value = reader.Item("servicio_id")
                    precioParam1.Value = precioParam.Value
                    Dim ttoo_id = reader.Item("ttoo_id")
                    Dim cliente_factura_id = reader.Item("factura_cliente_id")
                    Dim reserva_cliente_factura_id As Object = reader.Item("reserva_cliente_factura_id")
                    If tipo_linea = "A" Then  ' Todas las automaticas van al ttoo
                        If Not IsDBNull(reserva_cliente_factura_id) AndAlso reader.Item("grupo_cliente_id") = 2 Then
                            cliente_id = reserva_cliente_factura_id
                        Else
                            If IsDBNull(ttoo_id) Then
                                cliente_id = cliente_factura_id
                            Else
                                cliente_id = ttoo_id
                            End If
                        End If
                    Else  ' Las manuales van a ir al cliente al que se le hizo 
                        If IsDBNull(cliente_factura_id) Then
                            cliente_id = cliente_defecto
                        Else
                            cliente_id = cliente_factura_id
                        End If
                    End If
                    ' Si el cliente no permite credito entonces todo lo paso a extra contado
                    cliente_idParam.Value = cliente_id
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(cliente_idParam)
                    Dim grupo_cliente_id = ExecuteScalar(cmd, "SELECT grupo_cliente_id FROM clientes WHERE cliente_id =?")
                    If grupo_cliente_id > 2 Then ' No permite_credito a cliente defecto
                        cliente_idParam.Value = cliente_defecto
                    End If
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(hotel_idParam)
                    cmd.Parameters.Add(fechaParam)
                    cmd.Parameters.Add(cliente_idParam)
                    cmd.Parameters.Add(servicio_idParam)
                    cmd.Parameters.Add(cantidadParam)
                    cmd.Parameters.Add(precioParam)
                    cmd.Parameters.Add(cantidadParam1)
                    cmd.Parameters.Add(precioParam1)
                    ' Hacer el insert
                    errorcode = ExecuteNonQuery(cmd, SqlInsert)
                    If errorcode = 0 Then
                        ' Ha habido un errors
                        errorcode = 1
                    Else
                        errorcode = 0
                    End If
                End If
            End While
            sql_delete = "DELETE FROM produccion_ttoo_dia WHERE hotel_id=? And fecha =? And importe = 0"
            ExecuteNonQuery(cmd, sql_delete)
            Return 0
        End Function
        Function genera_produccion_ttoo_dia(ByVal hotel_id As Integer, ByVal fecha As Date) As Integer

            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim errorCode As Integer = 0
            genera_produccion_ttoo_dia(cmd, hotel_id, fecha)
            flushConection(cmd, 0)
            Return errorCode
        End Function
        Private Function obtieneImporteCCI(ByVal importeEnt As Decimal, ByVal ancho As Integer, ByVal signo As Boolean) As String
            Dim importe As String
            importeEnt = Decimal.Truncate(importeEnt * 100)
            If signo Then
                If importeEnt < 0 Then
                    importe = (-importeEnt) & "-"
                Else
                    importe = importeEnt & "+"
                End If
            Else
                importe = importeEnt
            End If
            Return importe.PadLeft(ancho, "0")
        End Function
        Function genera_estadisticos_SAP(ByVal cmd As Odbc.OdbcCommand, ByVal hotel_id As Integer, ByVal fecha As Date) As Integer
            Dim errorcode As Integer = 0
            Dim sql As String = "SELECT hotel_sap FROM sap_hoteles where hotel_id =?"
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
            Dim diaParam As New Odbc.OdbcParameter("@dia", fecha.Day)
            Dim anyParam As New Odbc.OdbcParameter("@dia", fecha.Year)
            Dim mes As Integer = fecha.Month - 1
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            cmd.Parameters.Add(diaParam)
            cmd.Parameters.Add(anyParam)
            Dim segmentoSAP As Object = ExecuteScalar(cmd, sql)
            If IsDBNull(segmentoSAP) Then
                Return 1   ' Horror
            End If
            ' ----------------------------------------------------------------------------------------------
            ' Declaración de variables del fichero plano
            ' ----------------------------------------------------------------------------------------------
            Dim nombreFichero As String = "EST" + segmentoSAP + fecha.ToString("ddMMyyyy") + ".txt"
            Dim ruta As String

            ' ----------------------------------------------------------------------------------------------
            If ConnectionString = "DSN=geshotel2" Then
                ruta = "c:/temp_prueba/SAP/estadisticos/"
            Else
                ruta = "c:/temp/SAP/estadisticos/"
            End If


            ' Cargamos las estadisticas segun la tabla sap_estadisticos
            Dim sb As Text.StringBuilder = New Text.StringBuilder

            Dim ticonv As Decimal = 0
            Dim importe As String = ""
            Dim Reader As DataTableReader = getDataTable(cmd, "SELECT * FROM sap_estadisticos")
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            cmd.Parameters.Add(anyParam)
            While Reader.Read
                Dim valor As Decimal = 0

                Dim sql1 As String = Reader.Item("sql1")
                Dim sql2 As Object = Reader.Item("sql2")
                Dim Reader2 As DataTableReader = getDataTable(cmd, sql1)
                Dim valor1 As Object = 0
                While Reader2.Read
                    valor1 = Reader2.Item(mes)  ' Va del 0 al 11
                End While


                If IsDBNull(valor1) OrElse IsNothing(valor1) Then
                    valor1 = 0
                End If

                Dim valor2 As Object = 0
                If Not IsDBNull(sql2) Then
                    valor2 = ExecuteScalar(cmd, sql2)
                    If IsDBNull(valor2) OrElse IsNothing(valor2) Then
                        valor2 = 0
                    End If
                End If
                If valor2 <> 0 Then
                    valor = valor1 * 100 / valor2
                    valor = valor / diaParam.Value
                Else
                    valor = valor1
                End If
                If Not IsDBNull(Reader.Item("coef_conversion")) Then
                    ticonv += valor * Reader.Item("coef_conversion")
                End If
                importe = obtieneImporteCCI(valor, 8, False)
                sb.AppendFormat("{0,-6}{1,-1}{2,-8}{3,-30}", Reader.Item("codigo"), Reader.Item("tipo"), importe, Reader.Item("descripcion"))
                sb.Append(vbCrLf)
            End While
            ' Ahora falta el valor estadístico de TICON
            importe = obtieneImporteCCI(ticonv, 8, False)
            sb.AppendFormat("{0,-6}{1,-1}{2,-8}{3,-30}", "TICONV", "U", importe, "Total estancias convertidas a TI")
            sb.Append(vbCrLf)
            My.Computer.FileSystem.WriteAllText(ruta & nombreFichero, sb.ToString, True, New System.Text.ASCIIEncoding)
            Return 0
        End Function
        Function genera_estadisticos_SAP(ByVal hotel_id As Integer, fecha As Date) As Integer
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            errorCode = genera_estadisticos_SAP(cmd, hotel_id, fecha)
            flushConection(cmd, errorCode)
            Return errorCode
        End Function
        Function genera_estadisticos_SAP(ByVal fecha As Date) As Integer
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim Reader As DataTableReader = getDataTable(cmd, "SELECT hotel_id FROM hoteles Where empresa_id =1")
            While Reader.Read
                errorCode = genera_estadisticos_SAP(cmd, Reader.Item("hotel_id"), fecha)
            End While
            flushConection(cmd, errorCode)
            Return errorCode
        End Function
        Public Function generarTablasPostCierre(ByVal cmd As Odbc.OdbcCommand, Hotel_id As Integer, Optional ByVal fecha As Object = Nothing) As Integer
            Dim errorcode As Integer = 0
            Console.WriteLine("Llamando a Genera_manocorriente=")
            errorcode = genera_manocorriente(cmd, Hotel_id, fecha)
            If errorcode <> 0 Then
                errorcode = 1
            End If
            Console.WriteLine("Llamando a Genera_desvios=")
            errorcode = genera_desvios()
            Console.WriteLine("Fin Genera_desvios=" & errorcode)
            Console.WriteLine("Fin Genera_desvios=" & errorcode)
            Console.WriteLine("Llamando a Genera_historico=")
            errorcode = genera_historico(cmd, Hotel_id, "totales_resumen_servicios", fecha)
            Console.WriteLine("Fin Genera_historico=" & errorcode)
            If errorcode <> 0 Then
                errorcode = 2
            End If
            Dim dia As Integer = 0
            Dim any As Integer = Year(Today)
            If Not (IsNothing(fecha)) Then
                dia = Day(fecha)
                any = Year(fecha)
            End If
            Console.WriteLine("Llamando a Genera_solo_alojamiento=")
            errorcode = genera_Solo_Alojamiento(cmd, Hotel_id, dia, any)
            Console.WriteLine("Fin Genera_solo_alojamiento=" & errorcode)
            If errorcode <> 0 Then
                errorcode = 3
            End If
            Console.WriteLine("Llamando a Produccion agencia dia=")
            errorcode = Genera_produccion_Agencia_Dia(cmd, Hotel_id, fecha)
            Console.WriteLine("Fin Produccion_agencia_dia=" & errorcode)
            If errorcode <> 0 Then
                errorcode = 4
            End If
            Console.WriteLine("Llamando a informe_produccion=")
            errorcode = Genera_informe_produccion(cmd, Hotel_id, fecha)
            Console.WriteLine("Fin informe Produccion=" & errorcode)
            If errorcode <> 0 Then
                errorcode = 5
            End If
            Console.WriteLine("Llamando a produccion_ttoo_dia=")
            errorcode = genera_produccion_ttoo_dia(cmd, Hotel_id, fecha)
            Console.WriteLine("Fin informe Produccion=" & errorcode)
            If errorcode <> 0 Then
                errorcode = 6
            End If
            ' depuro habitaciones_bloqueos
            ExecuteNonQuery(cmd, "DELETE FROM habitaciones_bloqueos WHERE habitacion_id=0")
            ' fin depuracion
            If Hotel_id = 1 Then ' Meterializo tabla_clientes_repetidos solo en hotel1
                errorcode = Materializa_tablas(cmd)
            End If
            If Hotel_id = 3 Then  ' 1% Publicidad en Reservas de TUI Nordic
                crea_descuento_en_reservas_ttoo(14744)
            End If
            Return errorcode
        End Function
        Public Function generarTablasPostCierre(ByVal Hotel_id As Integer, Optional ByVal fecha As Object = Nothing) As Integer
            Dim errorcode As Integer = 0
            errorcode = genera_manocorriente(Hotel_id, fecha)
            If errorcode <> 0 Then
                errorcode = 1
            End If
            errorcode = genera_desvios()
            errorcode = genera_historico(Hotel_id, "totales_resumen_servicios", fecha)
            If errorcode <> 0 Then
                errorcode = 2
            End If

            Dim dia As Integer = 0
            Dim any As Integer = Year(Today)
            If Not (IsNothing(fecha)) Then
                dia = Day(fecha)
                any = Year(fecha)
            End If
            errorcode = genera_Solo_Alojamiento(Hotel_id, dia, any)
            If errorcode <> 0 Then
                errorcode = 3
            End If
            errorcode = Genera_produccion_Agencia_Dia(Hotel_id, fecha)

            If errorcode <> 0 Then
                errorcode = 4
            End If
            errorcode = Genera_informe_produccion(Hotel_id, fecha)
            If errorcode <> 0 Then
                errorcode = 5
            End If
            If Hotel_id = 1 Then ' Meterializo tabla_clientes_repetidos solo en hotel1
                errorcode = Materializa_tablas()
            End If
            If Hotel_id = 3 Then  ' 1% Publicidad en Reservas de TUI Nordic
                crea_descuento_en_reservas_ttoo(14744)
            End If
            Return errorcode
        End Function
        Public Function genera_usuario_radius(ByVal reserva_id As Integer) As Integer
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim errorcode As Integer = genera_usuario_radius(cmd, reserva_id)

            flushConection(cmd, 0)

        End Function
        Private Function genera_usuario_radius(ByVal cmd As Odbc.OdbcCommand, ByVal reserva_id As Integer) As Integer
            Dim errorcode As Integer = 0
            Dim errcheck As Integer = 0
            Dim sql As String = ""
            Dim connRad As New Odbc.OdbcConnection(radiusConnectionString)

            Dim reserva_idParam As New Odbc.OdbcParameter("@reserva_id", reserva_id)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(reserva_idParam)
            Dim hotel_id = ExecuteScalar(cmd, "SELECT hotel_id FROM reservas WHERE reserva_id =?")

            If IsDBNull(hotel_id) Then
                Return 1
            End If
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            Dim ssid As Object = ExecuteScalar(cmd, "SELECT ssid FROM wifi_ssids WHERE hotel_id =? AND defecto=TRUE")
            If IsDBNull(ssid) OrElse IsNothing(ssid) Then
                ssid = "Wifi-Free"
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add(reserva_idParam)
            Dim clave_wifi = ExecuteScalar(cmd, "SELECT clave_wifi FROM reservas WHERE reserva_id =?")
            If IsDBNull(clave_wifi) Then
                sql = "UPDATE reservas SET clave_wifi=(RIGHT(CONCAT('000',FLOOR(10000*RAND())),4)), ssid=? WHERE reserva_id =?"
                Dim contador = ExecuteNonQuery(cmd, sql)
                If contador <> 1 Then
                    Return 1 ' Error
                End If
                clave_wifi = ExecuteScalar(cmd, "SELECT clave_wifi FROM reservas WHERE reserva_id =?")
                If IsDBNull(clave_wifi) Then
                    Return 1 ' Error
                End If
            End If
            Dim ssidParam As New Odbc.OdbcParameter("ssid", ssid)
            Dim cmdradius As New Odbc.OdbcCommand
            Dim Transaccion As Odbc.OdbcTransaction
            Try
                If Not connRad.State = ConnectionState.Open Then
                    connRad.Open()
                End If
                Transaccion = connRad.BeginTransaction(IsolationLevel.Serializable)
                cmdradius.Connection = connRad
                cmdradius.CommandType = CommandType.Text
                cmdradius.Transaction = Transaccion
                ' Lo que queda es meter el registro en radcheck
                Dim sql_insert_radcheck As String = "INSERT INTO radcheck (username, attribute,op, value,hotel_id) VALUES (?, 'Cleartext-Password',':=', ?,?)"
                Dim sql_insert_group As String = "INSERT INTO radusergroup (username,groupname,priority) VALUES(?,?,1)"
                If Not IsDBNull(ssid) And Not IsDBNull(clave_wifi) Then
                    Dim passwordParam As New Odbc.OdbcParameter("@password", clave_wifi)

                    cmdradius.Parameters.Add(reserva_idParam)
                    cmdradius.Parameters.Add(passwordParam)
                    cmdradius.Parameters.Add(hotel_idParam)

                    errcheck = ExecuteNonQuery(cmdradius, sql_insert_radcheck)
                    If errcheck = 1 Then
                        cmdradius.Parameters.Clear()
                        cmdradius.Parameters.Add(reserva_idParam)
                        cmdradius.Parameters.Add(ssidParam)
                        errcheck = ExecuteNonQuery(cmdradius, sql_insert_group)
                    End If
                End If
            Catch ex As Exception
                errorcode = 1 ' Error
            End Try
            If Not IsNothing(Transaccion) Then
                If errorcode <> 0 Then
                    Transaccion.Rollback()
                Else
                    Transaccion.Commit()
                End If
                connRad.Close()
            End If

        End Function
        Public Function genera_usuarios_radius(ByVal hotel_id As Integer, ByVal fecha As Date) As Integer
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim errorcode As Integer = genera_usuarios_radius(cmd, hotel_id, fecha)
            flushConection(cmd, 0)
        End Function
        Private Function genera_usuarios_radius(ByVal cmd As Odbc.OdbcCommand, ByVal hotel_id As Integer, ByVal fecha As Date) As Integer
            Dim errorcode As Integer = 0
            Dim errcheck As Integer = 0
            ' Insertamos en Radius las llegadas de mañana
            Dim fechaparam As New Odbc.OdbcParameter("@fecha", DateAdd(DateInterval.Day, 1, fecha))
            Dim connRad As New Odbc.OdbcConnection(radiusConnectionString)
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            Dim hotel_idParam2 As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            Dim ssid As Object = ExecuteScalar(cmd, "SELECT ssid FROM wifi_ssids WHERE hotel_id =? AND defecto=TRUE")
            If IsDBNull(ssid) OrElse IsNothing(ssid) Then
                ssid = "Wifi-Free"
            End If
            Dim ssidParam As New Odbc.OdbcParameter("ssid", ssid)
            Dim cmdradius As New Odbc.OdbcCommand
            Dim Transaccion As Odbc.OdbcTransaction
            Try
                If Not connRad.State = ConnectionState.Open Then
                    connRad.Open()
                End If
                Transaccion = connRad.BeginTransaction(IsolationLevel.Serializable)
                cmdradius.Connection = connRad
                cmdradius.CommandType = CommandType.Text
                cmdradius.Transaction = Transaccion
            Catch ex As Exception
                Return 1
            End Try

            Dim sql_insert_radcheck As String = "INSERT INTO radcheck (username, attribute,op, value,hotel_id) VALUES (?, 'Cleartext-Password',':=', ?,?)"
            Dim sql_insert_group As String = "INSERT INTO radusergroup (username,groupname,priority) VALUES(?,?,1)"
            Try
                ' Primero borramos de la tabla radusergroup y de radcheck todas los registros del hotel que toca con una sola sentencia sql
                cmdradius.Parameters.Clear()
                cmdradius.Parameters.Add(hotel_idParam2)
                Dim sql As String = "DELETE radcheck,radusergroup FROM radcheck LEFT JOIN radusergroup ON radusergroup.username = radcheck.username WHERE radcheck.hotel_id = ?"
                Dim contador = ExecuteNonQuery(cmdradius, sql)

                ' Despues ponemos clave wifi en todas aquellas reservas que por lo que sea, no tengan
                Dim usernameParam As New Odbc.OdbcParameter("@username", "")
                Dim passwordParam As New Odbc.OdbcParameter("@password", "")
                Dim groupNameParam As New Odbc.OdbcParameter("@groupname", "")
                cmd.Parameters.Clear()
                cmd.Parameters.Add(ssidParam)
                cmd.Parameters.Add(hotel_idParam)

                sql = "UPDATE reservas SET clave_wifi=(RIGHT(CONCAT('000',FLOOR(10000*RAND())),4)), ssid=? WHERE clave_wifi IS NULL And hotel_id = ? And estado_reserva_id IN (1,3,4)"
                contador = ExecuteNonQuery(cmd, sql)

                ' De lo que se trata es de insertar en radcheck al nuevo usuario que es la reserva_id y la contraseña de todas las entradas del dia y Estado pendiente y a las que estan en checkin o salen ese mismo día (checkout)
                sql = "SELECT * FROM reservas WHERE hotel_id = ? And ((estado_reserva_id = 1 AND fecha_prevista_llegada = ?) OR (estado_reserva_id IN (3,4)))"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(hotel_idParam)
                cmd.Parameters.Add(fechaparam)
                Dim reserva_id As Integer
                Dim clave_wifi As Object

                Dim Reader As DataTableReader = getDataTable(cmd, sql)
                While Reader.Read
                    Try
                        ' Para cada una hago un insert en la tabla radcheck y usergroup
                        cmdradius.Parameters.Clear()
                        reserva_id = CStr(Reader.Item("reserva_id"))
                        clave_wifi = CStr(Reader.Item("clave_wifi"))
                        ssid = Reader.Item("ssid")
                        If Not IsDBNull(ssid) And Not IsDBNull(clave_wifi) Then
                            usernameParam.Value = reserva_id
                            passwordParam.Value = clave_wifi
                            groupNameParam.Value = ssid
                            cmdradius.Parameters.Add(usernameParam)
                            cmdradius.Parameters.Add(passwordParam)
                            cmdradius.Parameters.Add(hotel_idParam2)

                            errcheck = ExecuteNonQuery(cmdradius, sql_insert_radcheck)
                            If errcheck = 1 Then
                                cmdradius.Parameters.Clear()
                                cmdradius.Parameters.Add(usernameParam)
                                cmdradius.Parameters.Add(groupNameParam)
                                errcheck = ExecuteNonQuery(cmdradius, sql_insert_group)
                            End If
                        Else
                            errorcode = 0
                        End If

                    Catch ex As Exception

                    End Try


                End While
                '' Borramos las salidas Seleccionamos las reservas en estado = 5 esto es facturado y las borramos de radcheck y usergroup
                'Dim delete_radcheck As String = "DELETE radcheck Where username=?"
                'Dim delete_groupcheck As String = "DELETE radusergroup Where username=?"
                'sql = "SELECT * FROM reservas WHERE estado_reserva_id=5 AND hotel_id = ? AND fecha_prevista_salida = ?"
                'fechaparam.Value = fecha ' En este caso miramos las que se han ido en el día del cierre
                'cmd.Parameters.Clear()
                'cmd.Parameters.Add(hotel_idParam)
                'cmd.Parameters.Add(fechaparam)
                'Reader = getDataTable(cmd, sql)
                'While Reader.Read
                '    cmdradius.Parameters.Clear()
                '    usernameParam.Value = CStr(Reader.Item("reserva_id"))
                '    cmdradius.Parameters.Add(usernameParam)
                '    errcheck = ExecuteNonQuery(cmdradius, delete_radcheck)
                '    errcheck = ExecuteNonQuery(cmdradius, delete_groupcheck)
                'End While
            Catch ex As Exception
                errorcode = 1
            End Try
            If Not IsNothing(Transaccion) Then
                If errorcode <> 0 Then
                    Transaccion.Rollback()
                Else
                    Transaccion.Commit()
                End If
                connRad.Close()
            End If
            Return errorcode
        End Function
        Sub telegram_extras_hotel(ByVal hotel_id As Integer, ByVal fecha As Date)
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            telegram_extras_hotel(cmd, hotel_id, fecha)
            flushConection(cmd, 0)
        End Sub
        Sub telegram_extras_hotel(ByVal cmd As Odbc.OdbcCommand, ByVal hotel_id As Integer, ByVal fecha As Date)
            Dim tipo_mensaje_id As Integer = 3 ' Extras Hotel
            Dim salto_linea = "a3f4g52"  ' Como telegram no gestiona el salto de linea con crlf o lf me creo un salto de linea raro para luego leerlo en la shell linux y separar lineas

            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
            Dim fecha2Param As New Odbc.OdbcParameter("@fecha", DateAdd(DateInterval.Year, -1, fecha))
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)

            Dim hotel = ExecuteScalar(cmd, "SELECT hotel FROM hoteles WHERE hotel_id=?")
            cmd.Parameters.Add(fechaParam)
            cmd.Parameters.Add(fecha2Param)
            Dim mensaje As String = "Informe de Extras Hotel" & salto_linea & hotel & salto_linea & "Fecha : " & fecha & salto_linea & "Datos con IGIC" & salto_linea
            Dim sql As String = "SELECT SUM(importe),servicios.servicio_id,abreviatura,fecha " _
            & "FROM produccion_ttoo_dia " _
            & "INNER JOIN servicios ON produccion_ttoo_dia.servicio_id = servicios.servicio_id " _
            & "WHERE produccion_ttoo_dia.hotel_id = ? AND servicios.tipo_servicio_id NOT IN (1, 2) AND " _
            & "(produccion_ttoo_dia.fecha = ? OR produccion_ttoo_dia.fecha = ?) " _
            & "GROUP BY servicios.servicio_id,abreviatura,fecha " _
            & "ORDER BY servicios.servicio_id,fecha DESC"
            Dim Reader As DataTableReader = getDataTable(cmd, sql)
            Dim act As Double = 0
            Dim ant As Double = 0
            Dim servicio_id As Integer = 0
            Dim total_ant As Double = 0
            Dim total_act As Double = 0

            Dim linea As String = ""
            While Reader.Read
                If Reader.Item("servicio_id") <> servicio_id Then
                    servicio_id = Reader.Item("servicio_id")
                    If linea <> "" Then
                        ' mando la linea
                        mensaje &= salto_linea & linea & FormatNumber(act, 1, , , TriState.True) & "€" & salto_linea & "Año Ant : " & FormatNumber(ant, 1, , , TriState.True) & "€"
                    End If
                    ' Pongo el nuevo servicio y reseteo los importes
                    linea = Reader.Item("abreviatura") & " : "
                    act = 0
                    ant = 0
                End If
                If Reader.Item("fecha") = fecha Then ' Tenemos año actual
                    act = Reader.Item("Sum(importe)")
                    total_act += act
                Else
                    ant = Reader.Item("Sum(importe)")
                    total_ant += ant
                End If
            End While
            ' Aqui estamos en el final y queda enviar la última linea
            mensaje &= salto_linea & linea & FormatNumber(act, 1, , , TriState.True) & salto_linea & "Año Ant : " & FormatNumber(ant, 2, , , TriState.True)
            ' Finalmente informo de los totales 
            mensaje &= salto_linea & "----------------" & salto_linea & " TOTALES EXTRAS" & salto_linea & "Dia Act : " & FormatNumber(total_act, 1, , , TriState.True) & salto_linea & "Año Ant : " & FormatNumber(total_ant, 2, , , TriState.True)
            carga_notificaciones_telegram(cmd, hotel_idParam.Value, tipo_mensaje_id, mensaje)
        End Sub
        Public Sub telegram_cierre_dia(ByVal hotel_id As Integer, ByVal fecha As Date)
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            telegram_cierre_dia(cmd, hotel_id, fecha)
            flushConection(cmd, 0)
        End Sub
        Sub telegram_cierre_dia(ByVal cmd As Odbc.OdbcCommand, ByVal hotel_id As Integer, ByVal fecha As Date)
            ' Preparameos el mensaje para telegram
            ' Contendrá lo siguiente
            ' ***************************************************
            ' Informe de Cierre Hotel
            ' Nombre del Hotel
            ' Fecha: fecha del cierre
            ' Producc.: xxx.xxx,xx
            ' Año Ant : xxx.xxx,xx
            ' Acum dia: x.xxx.xxx,xx
            ' Año Ant : x.xxx.xxx,xx
            ' Ocupacion : xx,x%
            ' Año Ant   : xx,x%
            ' Acum dia : xx,x%
            ' Año Ant  : xx,x%
            ' RevPar   : xxx.xx
            ' Año Ant  : xxx,xx
            ' RevPar mes : xxx,xx
            ' Año Ant  : xxx,xx
            ' *****************************************************
            Dim tipo_mensaje_id As Integer = 2 ' Cierrre dia
            Dim salto_linea = "a3f4g52"  ' Como telegram no gestiona el salto de linea con crlf o lf me creo un salto de linea raro para luego leerlo en la shell linux y separar lineas

            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
            Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
            Dim fecha2Param As New Odbc.OdbcParameter("@fecha", DateAdd(DateInterval.Year, -1, fecha))
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)

            Dim hotel = ExecuteScalar(cmd, "SELECT hotel FROM hoteles WHERE hotel_id=?")
            Dim mensaje As String = "Informe de Cierre Hotel" & salto_linea & hotel & salto_linea & "Fecha : " & fecha & salto_linea & "Datos con IGIC" & salto_linea
            ' Calculo de la producción
            Dim sql As String = "SELECT SUM(importe) " _
            & "FROM produccion_ttoo_dia " _
            & "WHERE hotel_id = ? AND fecha = ?"
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            cmd.Parameters.Add(fechaParam)
            Dim importe = ExecuteScalar(cmd, sql)
            Dim produccion_act = importe
            mensaje &= salto_linea & "Producc.: " & FormatNumber(importe, 2, , , TriState.True)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            cmd.Parameters.Add(fecha2Param)
            importe = ExecuteScalar(cmd, sql)
            Dim produccion_ant = importe
            mensaje &= salto_linea & "Año Ant.: " & FormatNumber(importe, 2, , , TriState.True)
            Dim fecstring = "01/" & fecha.Month & "/" & fecha.Year
            Dim desde As Date = CDate(fecstring)
            Dim hasta As Date = fecha
            sql = "SELECT SUM(importe)" _
            & "FROM produccion_ttoo_dia " _
            & "WHERE produccion_ttoo_dia.hotel_id = ? AND " _
            & "produccion_ttoo_dia.fecha BETWEEN ? AND ?"
            fechaParam.Value = desde
            fecha2Param.Value = hasta
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            cmd.Parameters.Add(fechaParam)
            cmd.Parameters.Add(fecha2Param)
            importe = ExecuteScalar(cmd, sql)
            mensaje &= salto_linea & "Acum. Dia:" & FormatNumber(importe, 0, , , TriState.True)
            fechaParam.Value = DateAdd(DateInterval.Year, -1, desde)
            fecha2Param.Value = DateAdd(DateInterval.Year, -1, hasta)
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            cmd.Parameters.Add(fechaParam)
            cmd.Parameters.Add(fecha2Param)
            importe = ExecuteScalar(cmd, sql)
            mensaje &= salto_linea & "Año Ant.: " & FormatNumber(importe, 0, , , TriState.True)
            sql = "SELECT Count(habitaciones.habitacion_id) FROM habitaciones " _
            & "Inner Join tipos_habitacion_hotel ON habitaciones.tipo_habitacion_id = tipos_habitacion_hotel.tipo_habitacion_id AND habitaciones.hotel_id = tipos_habitacion_hotel.hotel_id " _
            & "Inner Join tipos_habitacion ON habitaciones.tipo_habitacion_id = tipos_habitacion.tipo_habitacion_id " _
            & "WHERE tipos_habitacion.desvios <>  '1' AND habitaciones.hotel_id=?"
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            Dim total_habitaciones = ExecuteScalar(cmd, sql)
            sql = "SELECT SUM(cantidad) " _
            & "FROM reservas_servicios " _
            & "INNER JOIN servicios ON reservas_servicios.servicio_id = servicios.servicio_id " _
            & "INNER JOIN reservas ON reservas_servicios.reserva_id = reservas.reserva_id " _
            & "WHERE reservas.hotel_id = ? AND reservas.estado_reserva_id >='3' AND servicios.concepto_acelerador_reservas_id = 1 AND " _
            & "ifnull(reservas_servicios.fecha_desde,reservas.fecha_prevista_llegada) <=? AND ifnull(reservas_servicios.fecha_hasta,reservas.fecha_prevista_salida) > ?"
            fechaParam.Value = fecha
            fecha2Param.Value = fecha
            cmd.Parameters.Clear()
            cmd.Parameters.Add(hotel_idParam)
            cmd.Parameters.Add(fechaParam)
            cmd.Parameters.Add(fecha2Param)
            Dim hab_act = ExecuteScalar(cmd, sql)
            importe = hab_act * 100 / total_habitaciones
            Dim ocupac_act = importe
            mensaje &= salto_linea & "Ocupac.: " & FormatNumber(importe, 1, , , TriState.True) & " %"
            fechaParam.Value = DateAdd(DateInterval.Year, -1, fecha)
            fecha2Param.Value = fechaParam.Value
            Dim hab_ant = ExecuteScalar(cmd, sql)
            importe = hab_ant * 100 / total_habitaciones
            Dim ocupac_ant = importe
            mensaje &= salto_linea & "Año Ant: " & FormatNumber(importe, 1, , , TriState.True) & " %"
            importe = (produccion_act / hab_act) * ocupac_act / 100
            mensaje &= salto_linea & "RevPar act.: " & FormatNumber(importe, 1, , , TriState.True)
            importe = (produccion_ant / hab_ant) * ocupac_act / 100
            mensaje &= salto_linea & "RevPar ant.: " & FormatNumber(importe, 1, , , TriState.True)
            carga_notificaciones_telegram(cmd, hotel_idParam.Value, tipo_mensaje_id, mensaje)
        End Sub
        Function reviewpro(ByVal cmd As Odbc.OdbcCommand, ByVal fecha As Date, ByVal empresa_id As Integer) As String
            Dim errortxt As String = ""
            Dim empresa_idParam As New Odbc.OdbcParameter("@empresa_id", empresa_id)
            Dim fechaParam As New Odbc.OdbcParameter("@fecha", fecha)
            Dim strQuery As String = "SELECT reservas.hotel_id AS pmsid,hoteles.hotel AS title,reservas.fecha_prevista_llegada AS checkin,reservas.fecha_prevista_salida AS checkout, " _
            & "(select (select SUBSTRING_INDEX(razon,' ',LENGTH(TRIM(razon))-LENGTH(REPLACE(TRIM(razon), ' ', ''))) from clientes where clientes.cliente_id=min(reservas_huespedes.cliente_id)) as cliente_id from reservas_huespedes where reservas_huespedes.reserva_id=reservas.reserva_id) as Apellidos, " _
            & "(select (select SUBSTR(razon FROM LENGTH(SUBSTRING_INDEX(razon,' ',LENGTH(TRIM(razon))-LENGTH(REPLACE(TRIM(razon), ' ', ''))))+2) from clientes where clientes.cliente_id=min(reservas_huespedes.cliente_id)) as cliente_id from reservas_huespedes where reservas_huespedes.reserva_id=reservas.reserva_id) as Nombre," _
            & "(select (select RIGHT(CONCAT('000',habitaciones.numero_habitacion),4)from habitaciones_bloqueos h inner join habitaciones on habitaciones.habitacion_id=h.habitacion_id where h.habitacion_bloqueo_id=max(habitaciones_bloqueos.habitacion_bloqueo_id)) from habitaciones_bloqueos where habitaciones_bloqueos.reserva_id=reservas.reserva_id) as numero_habitacion," _
            & "(select (select naciones.desc_corta from clientes h inner join naciones on naciones.nacion_id=h.nacion_id where h.cliente_id=min(reservas_huespedes.cliente_id)) as cliente_id from reservas_huespedes where reservas_huespedes.reserva_id=reservas.reserva_id) As nacionalidad," _
            & "(select (select ifnull(naciones.idioma_mails,'EN') from clientes h inner join naciones on naciones.nacion_id=h.nacion_id where h.cliente_id=min(reservas_huespedes.cliente_id)) as cliente_id from reservas_huespedes where reservas_huespedes.reserva_id=reservas.reserva_id) As idioma," _
            & "(select (select email from clientes where clientes.cliente_id=min(reservas_huespedes.cliente_id)) as cliente_id from reservas_huespedes where reservas_huespedes.reserva_id=reservas.reserva_id) as email," _
            & "(select (select YEAR(NOW())-YEAR(fecha_nacimiento) from clientes where clientes.cliente_id=min(reservas_huespedes.cliente_id)) as cliente_id from reservas_huespedes where reservas_huespedes.reserva_id=reservas.reserva_id) as edad " _
            & "FROM reservas INNER JOIN hoteles ON reservas.hotel_id = hoteles.hotel_id " _
            & "WHERE hoteles.empresa_id=? AND reservas.fecha_prevista_llegada = ? AND reservas.estado_reserva_id = 3 " _
            & "AND (select (select email from clientes where clientes.cliente_id=min(reservas_huespedes.cliente_id)) as cliente_id from reservas_huespedes where reservas_huespedes.reserva_id=reservas.reserva_id) is not null " _
            & "AND (select (select email from clientes where clientes.cliente_id=min(reservas_huespedes.cliente_id)) as cliente_id from reservas_huespedes where reservas_huespedes.reserva_id=reservas.reserva_id)<>'' "

            cmd.Parameters.Clear()
            cmd.Parameters.Add(empresa_idParam)
            Dim n_hoteles = ExecuteScalar(cmd, "SELECT COUNT(*) FROM hoteles WHERE empresa_id =?")
            cmd.Parameters.Add(fechaParam)
            Dim n_cierres = ExecuteScalar(cmd, "SELECT COUNT(*) FROM cierres INNER JOIN hoteles ON cierres.hotel_id = hoteles.hotel_id WHERE hoteles.empresa_id = ? AND cierres.fecha_cierre =? AND postcierre=1")
            If n_hoteles = n_cierres Then
                ' Generar el fichero CSV de la empresa
                Dim ds As DataSet = getDataSet(cmd, strQuery)
                Dim dt As DataTable = ds.Tables(0)
                Dim nombreFichero As String = "HDHoteles_" + fecha.ToString("ddMMyyyy") + ".csv"
                Dim ruta As String

                If ConnectionString = "DSN=geshotel2" Then
                    ruta = "c:/temp_prueba/reviewpro/"
                Else
                    ruta = "c:/temp/reviewpro/"
                End If


                ' Cargamos las estadisticas segun la tabla sap_estadisticos
                Dim sb As Text.StringBuilder = New Text.StringBuilder

                For k As Integer = 0 To dt.Columns.Count - 1
                    'add separator 
                    sb.Append(dt.Columns(k).ColumnName + ","c)
                Next
                'append new line 
                sb.Append(vbCr & vbLf)
                Try
                    For i As Integer = 0 To dt.Rows.Count - 1
                        For k As Integer = 0 To dt.Columns.Count - 1
                            'add separator 
                            If IsDate(dt.Rows(i)(k)) Then
                                Dim fec As Date = dt.Rows(i)(k)
                                sb.Append(fec.ToString("dd/MM/yyyy") + ","c)
                            Else
                                sb.Append(dt.Rows(i)(k).ToString().Replace(",", ";") + ","c)
                            End If
                        Next
                        'append new line 
                        sb.Append(vbCr & vbLf)
                    Next
                    My.Computer.FileSystem.WriteAllText(ruta & nombreFichero, sb.ToString, True, New System.Text.ASCIIEncoding)
                Catch ex As Exception
                    errortxt = "Excepción " & ex.Message
                End Try
            Else
                errortxt = "Error N. Hoteles =" & n_hoteles & " N. cierres =" & n_cierres
            End If
            Return errortxt
        End Function
        Function reviewpro(ByVal fecha As Date, ByVal empresa_id As Integer) As String
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim errorcode As String = reviewpro(cmd, fecha, empresa_id)
            flushConection(cmd, 0)
            Return errorcode
        End Function
        Sub lanza_postcierres()
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", 1)
            Dim fechaParam As New Odbc.OdbcParameter("@fecha", Today)
            Dim hotel_id As Integer
            Dim fecha As Date
            Dim errorcode As Integer
            Dim errortxt As String = ""
            Dim contenido As String = ""

            Dim ReaderCierres As DataTableReader = getDataTable(cmd, "SELECT fecha_cierre,hotel_id FROM cierres WHERE postcierre=0")
            While ReaderCierres.Read
                Dim msgList As New ArrayList
                hotel_id = ReaderCierres.Item("hotel_id")
                fecha = ReaderCierres.Item("fecha_cierre")
                Dim StartTime As Double = Timer 'Stores start time in variable "StartTime"
                msgList.Add(DateTime.Now() & " Comienzo Postcierre dia " & fecha.ToString("dd/MM/yyyy") & " Hotel =" & hotel_id)
                hotel_idParam.Value = hotel_id
                fechaParam.Value = fecha

                Dim sql As String = ""
                ' Borro las notificaciones a dispositivos móviles de mas de 30 dias
                cmd.Parameters.Clear()
                sql = "DELETE FROM dispositivos_notificaciones WHERE DATEDIFF(NOW(),dispositivos_notificaciones.fecha_cambio_estado)>30"
                Dim result = ExecuteNonQuery(cmd, sql)
                ' primero es poner postcierre a 1 para que nadie mas pueda volverlo a lanzar
                sql = "UPDATE cierres SET postcierre=1 WHERE hotel_id=? AND fecha_cierre =?"
                cmd.Parameters.Add(hotel_idParam)
                cmd.Parameters.Add(fechaParam)
                result = ExecuteNonQuery(cmd, sql)
                If result = 1 Then
                    Try
                        If ConnectionString = "DSN=geshotel" Then
                            CrearFicheroPolicia(cmd, fecha, hotel_id)
                            msgList.Add(DateTime.Now() & " Fichero policia OK")
                        End If
                    Catch ex As Exception
                        msgList.Add(DateTime.Now() & " No puedo Crear el fichero policia")
                        AgregaInfo("postcierre", "No puedo Crear el fichero policia:" & fecha, -1)
                    End Try
                    Try
                        If ConnectionString = "DSN=geshotel" Then
                            generarFicherosBavelHotel(cmd, hotel_id)
                            msgList.Add(DateTime.Now() & " Facturas Bavel OK")
                        End If
                    Catch ex As Exception
                        AgregaInfo("postcierre", "Fallo al generar ficheros pendients bavel:" & fecha, -1)
                        msgList.Add(DateTime.Now() & " Error en Facturas Bavel")
                    End Try
                    Try
                        ObtieneLimpiezas(cmd, hotel_id, DateAdd(DateInterval.Day, 1, fecha))
                        msgList.Add(DateTime.Now() & " Obtiene Limpiezas OK")
                    Catch ex As Exception
                        AgregaInfo("postcierre", "No puedo generar Limpiezas:" & fecha, -1)
                        msgList.Add(DateTime.Now() & " No puedo generar Limpiezas")
                    End Try
                    Try
                        errorcode = generarTablasPostCierre(cmd, hotel_id, fecha)
                        If errorcode <> 0 Then
                            msgList.Add(DateTime.Now() & " Tablas Postcierre con error " & errorcode)
                        End If
                        msgList.Add(DateTime.Now() & " Tablas Postcierre OK")
                    Catch ex As Exception
                        AgregaInfo("postcierre", "No puedo Generar Tablas PostCierre:" & fecha, -1)
                        msgList.Add(DateTime.Now() & " Error Tablas Postcierre")
                    End Try
                    Try
                        errorcode = genera_estadisticos_SAP(cmd, hotel_id, fecha)
                        If errorcode <> 0 Then
                            msgList.Add(DateTime.Now() & " Estadisticos SAP con error " & errorcode)
                        End If
                        msgList.Add(DateTime.Now() & " Estadisticos SAP OK")
                    Catch ex As Exception
                        AgregaInfo("postcierre", "No puedo Generar Estadisticos SAP:" & fecha, -1)
                        msgList.Add(DateTime.Now() & " Error Estadisticos SAP")
                    End Try
                    Try
                        msgList.Add(DateTime.Now() & " Comienzo Radius del hotel " & hotel_id & " del día " & fecha & " ")
                        errorcode = genera_usuarios_radius(cmd, hotel_id, fecha)
                        If errorcode <> 0 Then
                            msgList.Add(DateTime.Now() & " Usuarios Radius con error " & errorcode)
                        End If
                        msgList.Add(DateTime.Now() & " Usuarios Radius del hotel " & hotel_id & " del día " & fecha & "  OK")
                    Catch ex As Exception
                        AgregaInfo("postcierre", "No puedo Generar Usuarios radius:" & fecha, -1)
                        msgList.Add(DateTime.Now() & " Error Usuarios Radius")
                    End Try
                    Try
                        msgList.Add(DateTime.Now() & " Comienzo Fichero ReviePro " & hotel_id & " del día " & fecha & " ")
                        errortxt = reviewpro(cmd, fecha, 1)
                        If errortxt <> "" Then
                            msgList.Add(DateTime.Now() & " Fichero Reviewpro no generado " & errortxt)
                        Else
                            msgList.Add(DateTime.Now() & " Fichero ReviewPro del día " & fecha & " Generado OK")
                        End If

                    Catch ex As Exception

                    End Try
                    telegram_cierre_dia(cmd, hotel_id, fecha)
                    telegram_extras_hotel(cmd, hotel_id, fecha)
                    msgList.Add(DateTime.Now() & " Notificaciones Telegram OK")
                End If
                Dim contenido_telegram As String = ""
                Dim salto_linea = "a3f4g52"  ' Como telegram no gestiona el salto de linea con crlf o lf me creo un salto de linea raro para luego leerlo en la shell linux y separar lineas
                For Each str As String In msgList
                    contenido += str & "<br>"
                    contenido_telegram += str & salto_linea
                Next

                Dim EndTime As Double = Timer   ' Stores End Time
                contenido += " Duracion total del proceso (En segundos) =" + FormatNumber(EndTime - StartTime, 2)
                contenido_telegram += "Duracion total del proceso (En segundos) =" + FormatNumber(EndTime - StartTime, 2)
                carga_notificaciones_telegram(cmd, hotel_id, 5, contenido_telegram)
            End While
            flushConection(cmd, 0)
            If contenido <> "" Then
                enviarEmailError("jnunez@grupohd.com,postmaster@grupohd.com", "Lanza PostCierre Hotel:" & hotel_id & " y Fecha " & fecha.ToString("dd/MM/yyyy"), contenido, True, "postmaster@grupohd.com")
            End If
        End Sub

    End Class
End Namespace


Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Namespace geshotelk


    Public Class tablaServicios
        Public reserva_id As Integer = 0
        Public erroresAntesBorrar As Integer = 0
        Public servicios As New DataTable
        Shared cloneser As DataTable = Nothing
        Public ofertasUsadas As Hashtable
        Private borrarQueue As New Text.StringBuilder
        Public errortxt As String = ""
        Public errornum As Integer = 0
        Public Sub New(ByVal x As DataTable)
            servicios = x.Clone
        End Sub
        Public Sub New()
            If IsNothing(cloneser) Then
                servicios.Columns.Add("fecha", System.Type.GetType("System.DateTime"), "")
                servicios.Columns.Add("servicio_id", System.Type.GetType("System.Int32"), "")
                servicios.Columns.Add("tipo_servicio_id", System.Type.GetType("System.Int32"), "")
                servicios.Columns.Add("importe", System.Type.GetType("System.Decimal"), "")
                servicios.Columns.Add("descripcion", System.Type.GetType("System.String"), "")
                servicios.Columns.Add("error", System.Type.GetType("System.Int32"), "")
                servicios.Columns.Add("cantidad", System.Type.GetType("System.Double"), "")
                servicios.Columns.Add("precio", System.Type.GetType("System.Double"), "")
                servicios.Columns.Add("preciodecimal", System.Type.GetType("System.Decimal"), "precio")
                servicios.Columns.Add("tipo", System.Type.GetType("System.Int32"), "")
                'servicios.Columns.Add("grupo", System.Type.GetType("System.Int32"), "")
                servicios.Columns.Add("grupo", System.Type.GetType("System.String"), "")
                'servicios.Columns.Add("mgrupo", System.Type.GetType("System.Int32"), "")
                servicios.Columns.Add("mgrupo", System.Type.GetType("System.String"), "")
                servicios.Columns.Add("ambito_id", System.Type.GetType("System.Int32"), "")
                servicios.Columns.Add("uc", System.Type.GetType("System.Int32"), "")
                servicios.Columns.Add("ucid", System.Type.GetType("System.Int32"), "")
                servicios.Columns.Add("tipo_oferta_id", System.Type.GetType("System.Int32"), "")
                servicios.Columns.Add("n", System.Type.GetType("System.Double"), "")
                servicios.Columns.Add("m", System.Type.GetType("System.Double"), "")
                servicios.Columns.Add("desc_oferta", System.Type.GetType("System.String"), "")
                servicios.Columns.Add("desc_uc", System.Type.GetType("System.String"), "")
                servicios.Columns.Add("desc_uc_reserva", System.Type.GetType("System.String"), "")
                servicios.Columns.Add("desc_frecuencia", System.Type.GetType("System.String"), "")
                servicios.Columns.Add("desc_tipo", System.Type.GetType("System.String"), "")
                servicios.Columns.Add("contrato_id", System.Type.GetType("System.Int32"), "")
                servicios.Columns.Add("impuesto_incluido", System.Type.GetType("System.Int32"), "")
                servicios.Columns.Add("porc_impuesto", System.Type.GetType("System.Decimal"), "")
                servicios.Columns.Add("rejilla", System.Type.GetType("System.Object"), "")
                'servicios.Columns.Add("importehConIgic", System.Type.GetType("System.Double"), "")
                servicios.Columns.Add("precio_produccion", System.Type.GetType("System.Decimal"), "")
                servicios.Columns.Add("pag_factura", System.Type.GetType("System.Int32"), "")
                servicios.Columns.Add("defecto", System.Type.GetType("System.Int32"), "")
                servicios.Columns.Add("contrato_id_defecto", System.Type.GetType("System.String"), "")

                cloneser = servicios.Clone()
            Else
                servicios = cloneser.Clone()
            End If
        End Sub
        Public Sub limpiar()
            servicios.Clear()
        End Sub
        Public Sub agregaCampo(ByVal campo As String, ByVal tipo As System.Type, ByVal valor As String)
            servicios.Columns.Add(campo, tipo, valor)
        End Sub

        Public Function recalculaImportePorGrupo()
            Dim al As ArrayList = listaGrupos()
            If al.Count = 0 Then Return True
            Dim temptable As New tablaServicios(servicios)
            Dim fmin As Date = servicios.Compute("min(fecha)", "error=0")
            Dim fmax As Date = servicios.Compute("max(fecha)", "error=0")
            Dim difdays As Integer = (fmax - fmin).Days
            If al.Count = 1 Then
                Dim k As Integer = 0
                'For k = 0 To al.Count - 1
                Dim rows() As DataRow = servicios.Select("grupo='" & al(k) & "' and error=0", "fecha", DataViewRowState.CurrentRows)
                'Dim dv As DataView = New DataView(servicios, "1=0", "fecha", DataViewRowState.CurrentRows)
                Dim x As Integer
                Dim filas As Integer = rows.Length
                Dim ini As Integer = 0


                Dim numM As Integer = 0
                For x = 0 To filas - 1
                    ini = -(fmin - CDate(rows(x).Item("fecha"))).Days
                    RecalculaFila(temptable, rows(x), ini, difdays, numM)
                Next
                'Next
            Else
                Dim en As IEnumerator = al.GetEnumerator()
                Dim dv As DataView = New DataView(servicios, "1=0", "fecha", DataViewRowState.CurrentRows)
                While en.MoveNext()
                    'Console.WriteLine(en.Current)
                    'Dim dv As DataView = New DataView(servicios, "grupo='" & en.Current & "' and error=0", "fecha", DataViewRowState.CurrentRows)
                    dv.RowFilter = "grupo='" & en.Current & "' and error=0"
                    Dim filas As Integer = dv.Count
                    Dim rowen As IEnumerator = dv.GetEnumerator()
                    Dim ini As Integer = 0
                    Dim numM As Integer = 0
                    Dim Row As DataRowView
                    'Dim tipofe
                    While rowen.MoveNext
                        Row = rowen.Current
                        ini = -(fmin - CDate(Row.Row.Item("fecha"))).Days
                        RecalculaFila(temptable, Row.Row, ini, difdays, numM)
                    End While
                End While

            End If

            'y al final hacer merge de la tabla paralela
            agregaTabla(temptable, False)
            Return True
        End Function
        Private Sub RecalculaFila(ByVal temptable As tablaServicios, ByVal Row As DataRow, ByRef ini As Integer, ByRef filas As Integer, ByRef numM As Integer)
            ', ByVal fechaini As Date, ByVal fechafin As Date
            Dim TempRow As DataRow = Nothing
            Dim tieneOferta As Boolean
            Dim nocambiar As Boolean
            With Row
                'tipofe = .Item("tipo_oferta_id")
                'If IsDBNull(.Item("tipo_oferta_id")) Then
                'tipofe = 0
                'End If


                If .Item("tipo_oferta_id") <> 0 Then
                    'si hay oferta no se cambian los precios
                    tieneOferta = True
                Else
                    tieneOferta = False
                End If
                nocambiar = False
                Select Case .Item("tipo") 'tipos imputacion
                    Case 0
                    'normal
                    Case 1
                        'llegada
                        'bug usar fechas en vez de contador registros
                        'If .Item("fecha") <> fmin Then
                        If ini <> 0 Then
                            .AcceptChanges()
                            .Item("importe") = 0
                            .Item("precio") = 0
                            .Item("cantidad") = 0
                            nocambiar = True
                        End If
                    Case 2
                        'salida
                        'bug usar fechas en vez de contador registros
                        'If .Item("fecha") <> fmax Then
                        If ini <> filas Then
                            .AcceptChanges()
                            .Item("importe") = 0
                            .Item("precio") = 0
                            .Item("cantidad") = 0
                            nocambiar = True
                        End If
                    Case 3
                        'prorrateado
                        .Item("cantidad") = .Item("cantidad") / filas
                        .Item("importe") = .Item("importe") / filas
                        'nocambiar = True
                        'Row.Item("precio") = Row.Item("importe") / Row.Item("cantidad")
                End Select

                If Not nocambiar Then

                    Select Case .Item("tipo_oferta_id") 'tipos de oferta
                        Case 0 'sin oferta

                        Case 1
                            'si tipo de oferta es n*m
                            If .Item("ambito_id") = 1 Then
                                'si ambito diario
                                If ini Mod .Item("n") = 0 Then
                                    numM = CInt(.Item("m"))
                                End If
                                If numM <> 0 Then
                                    numM -= 1
                                Else
                                    .Item("importe") = 0
                                    .Item("precio") = 0

                                End If
                            Else
                                'si es una vez o reserva
                                'todo crear 2 lineas si cantidad es mayor que N
                                If .Item("cantidad") >= .Item("n") And .Item("precio") > 0 Then
                                    'todo crear una linea en tabla paralela
                                    Dim cant As Integer = .Item("cantidad")
                                    Dim nuevacant As Decimal = cant * CInt(.Item("m")) / .Item("n")
                                    If System.Math.Floor(nuevacant) - nuevacant <> 0 Then
                                        nuevacant = System.Math.Floor(nuevacant) + 1
                                    End If
                                    .Item("cantidad") = nuevacant
                                    .Item("importe") = .Item("precio") * nuevacant
                                    TempRow = temptable.servicios.Rows.Add(.ItemArray)
                                    TempRow("cantidad") = cant - nuevacant
                                    TempRow("importe") = 0
                                    TempRow("precio") = 0

                                End If
                            End If

                        Case 2, 3, 10, 11, 12
                            Dim signo As Integer = -1 'n ud. a  m % dto.
                            Dim precio_total = Nothing
                            Dim igualdad = False   'igualidad es para ....
                            If .Item("tipo_oferta_id") = 3 Or .Item("tipo_oferta_id") = 11 Then
                                'n ud. a  m % recargo
                                signo = 1
                            End If

                            If .Item("tipo_oferta_id") = 10 Or .Item("tipo_oferta_id") = 11 Or .Item("tipo_oferta_id") = 12 Then
                                igualdad = True
                            End If

                            If .Item("tipo_oferta_id") = 4 Or .Item("tipo_oferta_id") = 12 Then
                                'n ud. a m €
                                precio_total = .Item("m")
                            End If
                            'n ud. a  m % dto.
                            If .Item("ambito_id") = 1 Then
                                'si ambito diario
                                If ((ini + 1 >= .Item("n") And igualdad = False)) Or (ini + 1 = .Item("n") And igualdad = True) Then
                                    If IsNothing(precio_total) Then
                                        .Item("importe") = .Item("importe") + (signo * (.Item("importe") * .Item("m") / 100))
                                    Else
                                        .Item("precio") = precio_total
                                        .Item("importe") = .Item("cantidad") * .Item("precio")
                                    End If
                                End If
                            Else
                                'si es una vez o reserva
                                If ((.Item("cantidad") >= .Item("n") And igualdad = False) Or (.Item("cantidad") = .Item("n") And igualdad = True)) And .Item("precio") > 0 Then
                                    TempRow = temptable.servicios.Rows.Add(.ItemArray)
                                    If .Item("n") <= 0 Then
                                    Else
                                        .Item("cantidad") = .Item("cantidad") - .Item("n") + 1
                                    End If

                                    If IsNothing(precio_total) Then
                                        .Item("importe") = .Item("cantidad") * .Item("precio")
                                        .Item("importe") = .Item("importe") + (signo * (.Item("importe") * .Item("m") / 100))
                                    Else
                                        .Item("precio") = precio_total
                                        If .Item("importe") <> 0 Then
                                            .Item("importe") = .Item("cantidad") * .Item("precio")
                                        End If
                                    End If
                                    TempRow("cantidad") = TempRow.Item("cantidad") - .Item("cantidad")
                                    TempRow("importe") = TempRow("cantidad") * TempRow("precio")
                                    If TempRow("cantidad") <= 0 Then
                                        TempRow.Delete()
                                        TempRow = Nothing
                                    End If
                                End If
                            End If
                        Case 18 'La ud. n y -,  m% dto
                            Dim signo As Integer = -1 ' Descuento
                            'n ud. a  m % dto.
                            If .Item("ambito_id") = 1 Then
                                'si ambito diario
                                If (ini + 1 <= .Item("n")) Then

                                    .Item("importe") = .Item("importe") + (signo * (.Item("importe") * .Item("m") / 100))

                                End If
                            Else
                                'si es una vez o reserva
                                If .Item("precio") > 0 Then
                                    TempRow = temptable.servicios.Rows.Add(.ItemArray)
                                    If .Item("cantidad") <= .Item("n") Then
                                        'cant =1 and n=2

                                        .Item("importe") = .Item("cantidad") * .Item("precio")
                                        .Item("importe") = .Item("importe") + (signo * (.Item("importe") * .Item("m") / 100))
                                        TempRow("cantidad") = 0

                                    Else
                                        'cant=3 nd n=2
                                        .Item("importe") = .Item("n") * .Item("precio")
                                        .Item("importe") = .Item("importe") + (-1 * (.Item("importe") * .Item("m") / 100))
                                        TempRow("cantidad") = .Item("cantidad") - .Item("n")
                                        TempRow("importe") = TempRow("cantidad") * TempRow("precio")
                                        .Item("cantidad") = .Item("n")
                                    End If

                                    If TempRow("cantidad") <= 0 Then
                                        TempRow.Delete()
                                        TempRow = Nothing
                                    End If
                                End If
                            End If
                        Case 19 'La ud. n y -, a m €

                            If .Item("ambito_id") = 1 Then
                                'si ambito diario
                                If (ini + 1 <= .Item("n")) Then
                                    .Item("importe") = .Item("cantidad") * .Item("m")

                                End If
                            Else
                                'si es una vez o reserva
                                If .Item("precio") > 0 Then
                                    TempRow = temptable.servicios.Rows.Add(.ItemArray)
                                    If .Item("cantidad") <= .Item("n") Then
                                        'cant =1 and n=2

                                        .Item("importe") = .Item("cantidad") * .Item("m")
                                        TempRow("cantidad") = 0

                                    Else
                                        'cant=3 nd n=2
                                        .Item("importe") = .Item("n") * .Item("m")

                                        TempRow("cantidad") = .Item("cantidad") - .Item("n")
                                        TempRow("importe") = TempRow("cantidad") * TempRow("precio")
                                        .Item("cantidad") = .Item("n")
                                    End If

                                    If TempRow("cantidad") <= 0 Then
                                        TempRow.Delete()
                                        TempRow = Nothing
                                    End If
                                End If
                            End If
                        Case 4 ' La ud n y + a m €
                            Dim n = .Item("n")
                            Dim m = .Item("m")
                            Dim cantidad = .Item("cantidad")
                            Dim precio = .Item("precio")
                            If .Item("ambito_id") = 1 Then
                                'si ambito diario
                                If (ini + 1 >= .Item("n")) Then
                                    .Item("importe") = .Item("cantidad") * .Item("m")

                                End If
                            Else
                                'si es una vez o reserva
                                If .Item("precio") > 0 Then
                                    TempRow = temptable.servicios.Rows.Add(.ItemArray)
                                    If .Item("cantidad") < .Item("n") Then
                                        'cant =1 and n=2

                                        .Item("importe") = .Item("cantidad") * .Item("precio")
                                        TempRow("cantidad") = 0

                                    Else
                                        If .Item("n") = 0 Then  ' Para prevenir el que si la unidad es 0 sume 1 a la cantidad
                                            .Item("n") = 1
                                        End If

                                        'cant=3 nd n=2
                                        .Item("cantidad") = .Item("cantidad") - .Item("n") + 1
                                        .Item("importe") = .Item("cantidad") * .Item("m")

                                        TempRow("cantidad") = .Item("n") - 1
                                        TempRow("importe") = TempRow("cantidad") * TempRow("precio")
                                    End If

                                    If TempRow("cantidad") <= 0 Then
                                        TempRow.Delete()
                                        TempRow = Nothing
                                    End If
                                End If
                            End If
                        Case 5, 6
                            Dim signo As Integer = 1
                            If .Item("tipo_oferta_id") = 6 Then
                                signo = -1
                            End If
                            If .Item("ambito_id") = 1 Then
                                'si ambito diario
                                If filas < .Item("n") Then
                                    .Item("importe") = .Item("importe") + (signo * (.Item("importe") * .Item("m") / 100))
                                End If
                            Else
                                'si es una vez o reserva
                                If .Item("cantidad") < .Item("n") And .Item("precio") > 0 Then
                                    .Item("importe") = .Item("importe") + (signo * (.Item("importe") * .Item("m") / 100))
                                End If
                            End If
                        Case 7, 8
                            Dim signo As Integer = 1
                            If .Item("tipo_oferta_id") = 7 Then
                                signo = -1
                            End If
                            If .Item("ambito_id") = 1 Then
                                'si ambito diario
                                If filas > .Item("n") Then
                                    .Item("importe") = .Item("importe") + (signo * (.Item("importe") * .Item("m") / 100))
                                End If
                            Else
                                'si es una vez o reserva
                                If .Item("cantidad") > .Item("n") And .Item("precio") > 0 Then
                                    .Item("importe") = .Item("importe") + (signo * (.Item("importe") * .Item("m") / 100))
                                End If
                            End If
                        Case 9
                            If .Item("ambito_id") = 1 Then
                                'si ambito diario
                                If filas > .Item("n") Then
                                    .Item("importe") = filas * .Item("m")
                                End If
                            Else
                                'si es una vez o reserva
                                If .Item("cantidad") > .Item("n") And .Item("precio") > 0 Then
                                    .Item("importe") = .Item("cantidad") * .Item("m")
                                End If
                            End If
                        Case 14
                            If .Item("ambito_id") = 1 Then
                                'si ambito diario
                                If filas > .Item("n") Then
                                    .Item("importe") += .Item("m")
                                End If
                            Else
                                'si es una vez o reserva
                                If .Item("cantidad") > .Item("n") Then
                                    'If .Item("cantidad") > .Item("n") And .Item("precio") > 0 Then
                                    .Item("importe") += .Item("m")
                                End If
                            End If
                            If .Item("importe") < 0 Then
                                '.Item("importe") = 0
                            End If
                        Case 15
                            If .Item("ambito_id") = 1 Then
                                'si ambito diario
                                If filas > .Item("n") Then
                                    .Item("importe") += filas * .Item("m")
                                End If
                            Else
                                'si es una vez o reserva
                                If .Item("cantidad") > .Item("n") Then
                                    'If .Item("cantidad") > .Item("n") And .Item("precio") > 0 Then
                                    .Item("importe") += .Item("cantidad") * .Item("m")
                                End If
                            End If
                            If .Item("importe") < 0 Then
                                '.Item("importe") = 0
                            End If
                        Case 16
                            If .Item("ambito_id") = 1 Then
                                'si ambito diario
                                If filas < .Item("n") Then
                                    .Item("importe") += .Item("m")
                                End If
                            Else
                                'si es una vez o reserva
                                If .Item("cantidad") < .Item("n") Then
                                    'If .Item("cantidad") > .Item("n") And .Item("precio") > 0 Then
                                    .Item("importe") += .Item("m")
                                End If
                            End If
                            If .Item("importe") < 0 Then
                                '.Item("importe") = 0
                            End If
                        Case 17
                            If .Item("ambito_id") = 1 Then
                                'si ambito diario
                                If filas < .Item("n") Then
                                    .Item("importe") += filas * .Item("m")
                                End If
                            Else
                                'si es una vez o reserva
                                If .Item("cantidad") < .Item("n") Then
                                    'If .Item("cantidad") > .Item("n") And .Item("precio") > 0 Then
                                    .Item("importe") += .Item("cantidad") * .Item("m")
                                End If
                            End If
                            If .Item("importe") < 0 Then
                                '.Item("importe") = 0
                            End If
                        Case 13
                            'Dim matriz As DataTable
                            If .Item("ambito_id") = 1 Then
                                'si ambito diario
                                'todo procesar matriz
                                CalculaRejilla(temptable, Row, filas, .Item("rejilla"))
                            Else
                                'si es una vez o reserva
                                CalculaRejilla(temptable, Row, .Item("cantidad"), .Item("rejilla"))
                            End If
                    End Select
                End If
                'ini += 1
                fijaImporte(Row)

                If Not IsNothing(TempRow) Then
                    'todo crear grupo fictio
                    TempRow("grupo") = TempRow("grupo") & "-1"
                    fijaImporte(TempRow)
                End If
                If tieneOferta And nocambiar Then
                    'descartar cambios en la fila
                    .RejectChanges()
                    If Not IsNothing(TempRow) Then
                        'TempRow.RejectChanges()
                        TempRow.Delete()
                    End If
                End If
                TempRow = Nothing
            End With
        End Sub
        Private Sub CalculaRejilla(ByVal temptable As tablaServicios, ByVal Row As DataRow, ByVal valor As Integer, ByVal matriz As DataTable)
            Dim n As Integer
            Dim m
            'Dim tipo_comparacion As Integer
            Dim tipo_m As Integer
            Dim x As Integer
            Dim y As Integer
            Dim importetotal As Decimal
            Dim restarCantidad As Integer = 0
            If Not IsNothing(matriz) Then
                matriz.Columns.Add("usado", System.Type.GetType("System.Int32"), "")
            End If
            Dim rejilla_id
            For y = valor To 1 Step -1
                m = Nothing
                rejilla_id = Nothing
                If Not IsNothing(matriz) Then
                    For x = 0 To matriz.Rows.Count - 1 'And Not IsNothing(m)
                        If matriz.Rows(x).IsNull("usado") OrElse matriz.Rows(x).Item("usado") <> 1 Then
                            Select Case matriz.Rows(x).Item("tipo_condicion_id")
                                Case 1 '=
                                    If y = matriz.Rows(x).Item("n") Then
                                        m = matriz.Rows(x).Item("m")
                                        tipo_m = matriz.Rows(x).Item("tipo_aplicacion")
                                        n = 1
                                        matriz.Rows(x).Item("usado") = 1
                                        rejilla_id = matriz.Rows(x).Item("rejilla_id")
                                    End If
                                Case 2 '>
                                    If y > matriz.Rows(x).Item("n") Then
                                        m = matriz.Rows(x).Item("m")
                                        tipo_m = matriz.Rows(x).Item("tipo_aplicacion")
                                        n = y - matriz.Rows(x).Item("n")
                                        matriz.Rows(x).Item("usado") = 1
                                        rejilla_id = matriz.Rows(x).Item("rejilla_id")
                                    End If
                                Case 3 '>=
                                    If y >= matriz.Rows(x).Item("n") Then
                                        m = matriz.Rows(x).Item("m")
                                        tipo_m = matriz.Rows(x).Item("tipo_aplicacion")
                                        n = 1 + y - matriz.Rows(x).Item("n")
                                        matriz.Rows(x).Item("usado") = 1
                                        rejilla_id = matriz.Rows(x).Item("rejilla_id")
                                    End If
                                Case 4 '<
                                    If y < matriz.Rows(x).Item("n") Then
                                        m = matriz.Rows(x).Item("m")
                                        tipo_m = matriz.Rows(x).Item("tipo_aplicacion")
                                        n = y
                                        matriz.Rows(x).Item("usado") = 1
                                        rejilla_id = matriz.Rows(x).Item("rejilla_id")
                                    End If
                                Case 5 '<=
                                    If y <= matriz.Rows(x).Item("n") Then
                                        m = matriz.Rows(x).Item("m")
                                        tipo_m = matriz.Rows(x).Item("tipo_aplicacion")
                                        n = y
                                        matriz.Rows(x).Item("usado") = 1
                                        rejilla_id = matriz.Rows(x).Item("rejilla_id")
                                    End If
                            End Select
                        End If
                    Next
                Else
                    If y = Row.Item("n") Then
                        m = Row.Item("m")
                        tipo_m = 1
                    End If
                End If
                If Not IsNothing(m) Then

                    'Select Case tipo_m
                    '    Case 1 '%
                    'importetotal += n * (Row.Item("precio") + (Row.Item("precio") * m / 100))
                    '    Case 2 '-%
                    'importetotal += n * (Row.Item("precio") - (Row.Item("precio") * m / 100))
                    '    Case 3 'euros
                    'importetotal += n * m
                    'End Select

                    Dim TempRow As DataRow
                    TempRow = temptable.servicios.Rows.Add(Row.ItemArray)
                    TempRow.Item("cantidad") = n
                    'todo crear grupo fictio
                    TempRow.Item("grupo") = TempRow.Item("grupo") & "-" & rejilla_id 'id de la rejilla
                    Try
                        TempRow.Item("mgrupo") = TempRow.Item("mgrupo") & "-" & rejilla_id 'id de la rejilla

                    Catch ex As Exception

                    End Try
                    'Row.Item("grupo") = TempRow.Item("grupo")

                    'recalcular(precio)
                    Select Case tipo_m
                        Case 1 '%
                            TempRow.Item("importe") = n * (TempRow.Item("precio") + (TempRow.Item("precio") * m / 100))
                        Case 2 '-%
                            TempRow.Item("importe") = n * (TempRow.Item("precio") - (TempRow.Item("precio") * m / 100))
                        Case 3 'euros
                            TempRow.Item("importe") = n * m
                    End Select
                    fijaImporte(TempRow)
                    restarCantidad += n
                End If
            Next
            If restarCantidad > 0 Then
                Row.Item("cantidad") -= restarCantidad
                If Row.Item("cantidad") < 0 Then
                    Row.Item("cantidad") = 0
                End If
                Row.Item("importe") = importetotal + Row.Item("cantidad") * Row.Item("precio")
                'Row.Item("cantidad") += restarCantidad
            End If
            If Not IsNothing(matriz) Then
                matriz.Columns.Remove("usado")
            End If
        End Sub
        Private Function fijaImporte(ByVal Row As DataRow)
            With Row
                If .Item("cantidad") <> 0 Then
                    'todo si impuesto incluido cambiar precio e importe total
                    'guardar resto?
                    'Row.Item("importeConIgic") = Row.Item("importe") / Row.Item("cantidad")
                    If .Item("impuesto_incluido") <> 1 Then
                        'Precio Base = Importe*100/(100+IGIC); 
                        Dim neoi As Decimal = (.Item("importe") * (100 + .Item("porc_impuesto"))) / 100
                        If neoi <> .Item("importe") Then
                            .Item("importe") = neoi
                        End If
                        '.Item("importe") = (.Item("importe") * (100 + .Item("porc_impuesto"))) / 100

                    End If
                    Dim neop As Decimal = .Item("importe") / .Item("cantidad")
                    If neop <> .Item("precio") Then
                        .Item("precio") = neop
                    End If
                    '.Item("precio") = .Item("importe") / .Item("cantidad")
                End If
                'If .Item("importe") = 0 Then
                If .Item("importe") = 0 And .Item("precio") <> 0 Then
                    .Item("precio") = 0
                    'Row.Item("importeConIgic") = 0
                End If
            End With
            Return True
        End Function
        Private Function listaGrupos() As ArrayList
            'Return (distinct(New DataView(servicios, "error=0", "grupo", DataViewRowState.CurrentRows), "grupo"))
            Return (distinct(servicios.Select("error=0", "grupo", DataViewRowState.CurrentRows), "grupo"))
        End Function
        Public Function ordenarPor(ByVal order As String) As DataView
            Return New DataView(servicios, "", order, DataViewRowState.CurrentRows)
        End Function
        Private Function distinct(ByVal dr() As DataRow, ByVal campo As String) As ArrayList
            Dim resultado As New Hashtable
            Dim y As Integer = dr.Length - 1
            Dim ser As Object
            Dim x As Integer
            For x = 0 To y
                ser = dr(x)(campo)
                If Not (IsDBNull(ser) Or resultado.Contains(ser)) Then
                    resultado(ser) = 1
                End If
            Next
            Dim resarra As New ArrayList
            resarra.InsertRange(0, resultado.Keys)
            'resultadoys.CopyTo(resarra, 0)
            resarra.Sort()
            Return resarra
        End Function
        Private Function distinct(ByVal dv As DataView, ByVal campo As String) As ArrayList
            Dim resultado As New Hashtable
            Dim reader As DataTableReader = dv.Table.CreateDataReader()
            Dim z As Integer = reader.GetOrdinal(campo)
            Dim ser As Object
            With reader
                While .Read
                    ser = .Item(z)
                    If Not (IsDBNull(ser) Or resultado.Contains(ser)) Then
                        resultado(ser) = 1
                    End If
                End While
            End With
            Dim resarra As New ArrayList
            resarra.InsertRange(0, resultado.Keys)
            'resultadoys.CopyTo(resarra, 0)
            resarra.Sort()
            Return resarra
        End Function
        Private Function distinctOld(ByVal dv As DataView, ByVal campo As String) As ArrayList
            Dim resultado As New ArrayList
            Dim reader As DataTableReader = dv.Table.CreateDataReader()
            Dim z As Integer = reader.GetOrdinal(campo)
            Dim ser As Object
            With reader
                While .Read
                    ser = .Item(z)
                    If Not (IsDBNull(ser) Or resultado.Contains(ser)) Then
                        resultado.Add(ser)
                    End If
                End While
            End With
            resultado.Sort()
            Return resultado
        End Function

        Public Function obtieneDistintos(ByVal campo) As ArrayList
            'Return (distinct(New DataView(servicios, "error=0", Nothing, DataViewRowState.CurrentRows), campo))
            Return (distinct(servicios.Select("error=0", "", DataViewRowState.CurrentRows), campo))
        End Function
        Public Function listaServicios() As ArrayList
            Dim resultado As New ArrayList
            Dim reader As DataTableReader = servicios.CreateDataReader()
            Dim ser As Integer
            Dim serid As Integer = reader.GetOrdinal("servicio_id")
            While reader.Read
                ser = reader.Item(serid)
                If Not resultado.Contains(ser) Then
                    resultado.Add(ser)
                End If
            End While
            resultado.Sort()
            Return resultado
        End Function
        Public Function sumaErrores() As Decimal
            Dim resultado As Decimal = 0
            If servicios.Rows.Count > 0 Then
                resultado = servicios.Compute("sum(error)", "")
            End If
            Return resultado
        End Function
        Public Function sumaProduccion() As Decimal
            Dim resultado As Decimal = 0

            Dim x As Integer
            For x = 0 To servicios.Rows.Count - 1
                resultado += servicios.Rows(x).Item("cantidad") * servicios.Rows(x).Item("precio_produccion")
            Next
            Return resultado
        End Function
        Public Function sumaImporte() As Decimal
            Dim resultado As Decimal = 0
            'Optional ByVal computar As Object = Nothing
            'If IsNothing(computar) Then
            'computar = "sum(importe)"
            'End If
            'If servicios.Rows.Count > 0 Then
            ' resultado = servicios.Compute(computar, "")
            'End If
            'resultado = servicios.Compute("sum(importe)", "")
            resultado = 0
            Dim x As Integer
            For x = 0 To servicios.Rows.Count - 1
                resultado += Math.Round(servicios.Rows(x).Item("importe"), 2, MidpointRounding.AwayFromZero)
            Next
            Return resultado
        End Function
        Public Sub borrarDeTabla(ByVal filtro As String, Optional ByVal queue As Boolean = False)
            If servicios.Rows.Count <> 0 And Not IsNothing(filtro) Then
                GesHotelClase.borrarHits += 1
                Dim trows() As DataRow = servicios.Select(filtro)
                Dim row As DataRow
                With servicios.Rows
                    For Each row In trows
                        .Remove(row)
                    Next
                End With
            End If
        End Sub
        Public Sub borrarDeTablaNew(ByVal filtro As String, Optional ByVal queue As Boolean = False)
            If servicios.Rows.Count <> 0 Then
                If queue Then
                    If IsNothing(filtro) Then
                        If borrarQueue.Length <> 0 Then
                            borrarDeTabla(borrarQueue.ToString, False)
                            borrarQueue.Length = 0
                        End If
                    Else
                        If borrarQueue.Length = 0 Then
                            borrarQueue.Append("(0=1)")
                        End If
                        If filtro <> "" Then
                            borrarQueue.Append(" or (" & filtro & ")")
                        Else
                            borrarQueue.Length = 0
                            borrarQueue.Append("(1=1)")
                        End If
                    End If
                Else
                    GesHotelClase.borrarHits += 1
                    Dim trows() As DataRow = servicios.Select(filtro)
                    Dim row As DataRow
                    With servicios.Rows
                        For Each row In trows
                            .Remove(row)
                        Next
                    End With
                End If
            End If
        End Sub
        Public Sub agregaTablaNew(ByVal datos As tablaServicios, ByVal reemplaza As Boolean)
            If reemplaza Then
                'todo me cargo los datos que puedan chocar con la nueva tabla
                'por servicio y fecha siempre y cuando no tengan error
                Dim reader As DataTableReader = datos.servicios.CreateDataReader
                Dim filtro As String
                Dim o_ucid As Integer = reader.GetOrdinal("ucid")
                Dim o_servicio_id As Integer = reader.GetOrdinal("servicio_id")
                Dim o_fecha As Integer = reader.GetOrdinal("fecha")
                Dim megaborrar As String = ""
                With reader
                    While .Read
                        filtro = "(ucid=" & .Item(o_ucid) & " and servicio_id=" & .Item(o_servicio_id) & " and fecha='" & .Item(o_fecha) & "')"
                        If .Item("error") <> 1 Then
                            If megaborrar = "" Then
                                megaborrar += filtro
                            Else
                                megaborrar += " OR " + filtro
                            End If

                            'borrarDeTabla(filtro)
                        Else
                            'solo lo borro si no habia registros para esa fecha
                            If servicios.Compute("count(servicio_id)", filtro) > 0 Then
                                datos.borrarDeTabla(filtro)
                            End If
                        End If
                    End While
                    If megaborrar <> "" Then
                        borrarDeTabla(megaborrar)
                    End If
                End With
            End If
            servicios.Merge(datos.servicios)
        End Sub

        Public Sub agregaTabla(ByVal datos As tablaServicios, ByVal reemplaza As Boolean)
            If reemplaza Then
                'todo me cargo los datos que puedan chocar con la nueva tabla
                'por servicio y fecha siempre y cuando no tengan error
                Dim reader As DataTableReader = datos.servicios.CreateDataReader
                Dim filtro As String
                Dim o_ucid As Integer = reader.GetOrdinal("ucid")
                Dim o_servicio_id As Integer = reader.GetOrdinal("servicio_id")
                Dim o_fecha As Integer = reader.GetOrdinal("fecha")
                Dim o_error As Integer = reader.GetOrdinal("error")
                Dim o_defecto As Integer = reader.GetOrdinal("defecto")
                With reader
                    While .Read
                        'TODO no reemplazar si
                        filtro = "defecto=" & .Item(o_defecto) & " and ucid=" & .Item(o_ucid) & " and servicio_id=" & .Item(o_servicio_id) & " and fecha='" & .Item(o_fecha) & "'"
                        If .Item(o_error) <> 1 Then
                            borrarDeTabla(filtro, True)
                        Else
                            'solo lo borro si no habia registros para esa fecha
                            If servicios.Compute("count(servicio_id)", filtro) > 0 Then
                                datos.borrarDeTabla(filtro, True)
                            End If
                        End If
                    End While
                End With
            End If
            'servicios.Load(datos.servicios.CreateDataReader)
            datos.borrarDeTabla(Nothing, True)
            borrarDeTabla(Nothing, True)
            servicios.Merge(datos.servicios)
        End Sub
        Public Function buscaFila(ByVal filtro As String) As DataRow
            If servicios.Rows.Count = 0 Then Return Nothing

            Dim rows As DataRow() = servicios.Select(filtro)
            If rows.Length > 0 Then
                Return rows(0)
            Else
                Return Nothing
            End If
        End Function
        Public Sub sumaTabla(ByVal datos As tablaServicios)
            Dim reader As DataTableReader = datos.servicios.CreateDataReader
            Dim filtro As String
            'Dim filtrosb As New Text.StringBuilder
            Dim o_ucid As Integer = reader.GetOrdinal("ucid")
            Dim o_servicio_id As Integer = reader.GetOrdinal("servicio_id")
            Dim o_fecha As Integer = reader.GetOrdinal("fecha")
            Dim o_error As Integer = reader.GetOrdinal("error")
            Dim rowDestino As DataRow
            Dim rowOrigen As DataRow

            'filtrosb.Length = 0
            'filtrosb.Append("ucid=")
            'filtrosb.Append(0)
            'filtrosb.Append(" and servicio_id=")
            'filtrosb.Append(0)
            'filtrosb.Append(" and fecha='")
            'filtrosb.Append(0)
            'filtrosb.Append("'")

            With reader
                While .Read
                    'filtrosb.Length = 0
                    'filtrosb(1) = .Item(o_ucid)
                    'filtrosb(3) = .Item(o_servicio_id)
                    'filtrosb(5) = .Item(o_fecha)

                    'filtrosb.Append("ucid=")
                    ''filtrosb.Append(.Item(o_ucid))
                    'filtrosb.Append(" and servicio_id=")
                    'filtrosb.Append(.Item(o_servicio_id))
                    'filtrosb.Append(" and fecha='")
                    'filtrosb.Append(.Item(o_fecha))
                    'filtrosb.Append("'")

                    filtro = "ucid=" & .Item(o_ucid) & " and servicio_id=" & .Item(o_servicio_id) & " and fecha='" & .Item(o_fecha) & "'"
                    'filtro = filtrosb.ToString
                    rowDestino = buscaFila(filtro)
                    If CInt(.Item(o_error)) = 1 Then
                        'solo lo borro si no habia registros para esa fecha
                        'If CInt(servicios.Compute("count(servicio_id)", filtro)) > 0 Then
                        If Not IsNothing(rowDestino) Then
                            datos.borrarDeTabla(filtro, True)
                        End If
                        'datos.borrarDeTabla(filtro)
                    Else
                        'rowDestino = buscaFila(filtro)
                        If Not IsNothing(rowDestino) Then
                            If CInt(rowDestino.Item("error")) = 1 Then
                                servicios.Rows.Remove(rowDestino)
                            Else
                                rowOrigen = datos.buscaFila(filtro)
                                While Not IsNothing(rowOrigen)
                                    'rowDestino.Item("cantidad") += rowOrigen.Item("cantidad")
                                    rowDestino.Item("importe") += rowOrigen.Item("importe")
                                    rowDestino.Item("precio") = rowDestino.Item("importe") / rowDestino.Item("cantidad")
                                    datos.servicios.Rows.Remove(rowOrigen)
                                    rowOrigen = datos.buscaFila(filtro)
                                End While
                            End If
                        End If
                    End If
                End While
            End With
            datos.borrarDeTabla(Nothing, True)
            servicios.Merge(datos.servicios)
        End Sub
        Public Function redondear(ByVal digits As Integer, Optional ByVal reserva_id As Integer = 0, Optional ByVal mat As Hashtable = Nothing) As Boolean
            Dim x As Integer
            Dim imp As Decimal
            Dim rows As DataRowCollection = servicios.Rows
            Dim z = rows.Count - 1
            For x = 0 To z
                If Not IsDBNull(rows(x).Item("importe")) Then
                    imp = rows(x).Item("importe")
                    If imp <> 0 Then
                        imp = Math.Round(imp, 2, MidpointRounding.AwayFromZero)
                    End If
                    rows(x).Item("importe") = imp
                    rows(x).Item("precio") = imp / rows(x).Item("cantidad")
                End If
            Next
            Return True
        End Function
        Public Function redondearOld(ByVal digits As Integer, Optional ByVal reserva_id As Integer = 0, Optional ByVal mat As Hashtable = Nothing) As Boolean
            Dim x As Integer
            Dim imp As Decimal
            Dim rows As DataRowCollection = servicios.Rows
            Dim z = rows.Count - 1
            For x = 0 To z
                If Not IsDBNull(rows(x).Item("importe")) Then
                    imp = rows(x).Item("importe")
                    If imp <> 0 Then
                        imp = Math.Truncate(imp * 100) / 100
                    End If

                    'imp = Math.Round(imp, digits, MidpointRounding.ToEven)
                    If Not IsNothing(mat) Then
                        If imp <> servicios.Rows(x).Item("importe") Then
                            Dim keys As String = reserva_id & "-" & servicios.Rows(x).Item("importe") & "-" & imp
                            If Not mat.ContainsKey(keys) Then
                                mat.Add(keys, keys)
                            End If
                            'Console.WriteLine(keys)
                        End If
                    End If
                    rows(x).Item("importe") = imp
                    rows(x).Item("precio") = imp / rows(x).Item("cantidad")
                End If
            Next
            Return True
        End Function
        Public Function ActualizarMediaServiciosUC(ByVal datos As DataTable)
            Dim reader As DataTableReader = datos.CreateDataReader
            Dim ucid As String = "ucid"
            Dim x As Integer
            While reader.Read
                Dim filtro As String = "servicio_id=" & reader.Item("servicio_id") & " and ucid=" & reader.Item(ucid) & ""
                Dim drows() As DataRow = servicios.Select(filtro)
                Dim ultfila As DataRow = Nothing
                Dim total As Single = 0
                Dim total_produccion As Single = 0
                Dim precio As Single = 0
                Dim zdr As Integer = drows.Length - 1
                For x = 0 To zdr
                    If drows(x).Item("cantidad") > 0 Then
                        ultfila = drows(x)
                    End If

                    precio = Math.Round(reader.Item("precio"), 2, MidpointRounding.AwayFromZero)
                    total += drows(x).Item("cantidad") * reader.Item("precio")
                    total_produccion += drows(x).Item("cantidad") * precio
                    drows(x).Item("precio_produccion") = precio
                Next
                If Not IsNothing(ultfila) And total <> total_produccion Then
                    If ultfila.Item("cantidad") > 1 Then
                        'creo una linea igual a la ultima fila pero con cantidad 1
                        ultfila("cantidad") -= 1
                        ultfila("importe") = ultfila("cantidad") * ultfila("precio")
                        'fijaImporte(ultfila)
                        ultfila = servicios.Rows.Add(ultfila.ItemArray)
                        ultfila("cantidad") = 1
                        ultfila("importe") = ultfila("cantidad") * ultfila("precio")
                        'fijaImporte(ultfila)
                        'resto cantidad a esa fila
                    End If

                    ultfila.Item("precio_produccion") += ((total - total_produccion) / ultfila.Item("cantidad"))
                    ultfila.Item("precio_produccion") = Math.Round(ultfila.Item("precio_produccion"), 2, MidpointRounding.AwayFromZero)

                End If
            End While
            Return True
        End Function
        Private Shared tablamediauc As DataTable
        Private Function obtieneTablaMediaUC() As DataTable
            Dim resultado As DataTable = tablamediauc
            If IsNothing(resultado) Then
                resultado = New DataTable
                'crear una tabla resultado dias,servicio,uc,cantidad,importe
                resultado.Columns.Add("dias", System.Type.GetType("System.Int32"), "")
                resultado.Columns.Add("servicio_id", System.Type.GetType("System.Int32"), "")
                resultado.Columns.Add("ucid", System.Type.GetType("System.Int32"), "")
                resultado.Columns.Add("cantidad", System.Type.GetType("System.Double"), "")
                resultado.Columns.Add("precio", System.Type.GetType("System.Double"), "")
                resultado.Columns.Add("total", System.Type.GetType("System.Double"), "")
                resultado.Columns.Add("ldia", System.Type.GetType("System.DateTime"), "")
                tablamediauc = resultado
            End If
            Return resultado.Clone
        End Function
        Public Function ObtieneMediaServiciosUc() As DataTable
            Dim resultado As DataTable = obtieneTablaMediaUC()
            Dim reader As DataTableReader = servicios.CreateDataReader()
            Dim ucid As String = "ucid"
            Try
                Dim filtro As String
                Dim lfiltro As String = ""
                Dim drows() As DataRow
                Dim drow As DataRow = Nothing
                While reader.Read
                    'recorrerse servicios..por cada servicio+uc..crear o sumar a la tabla resultado
                    filtro = "servicio_id=" & reader.Item("servicio_id") & " and ucid=" & reader.Item(ucid) & ""
                    If lfiltro <> filtro Then
                        lfiltro = filtro
                        drows = resultado.Select(filtro)
                        If drows.Length > 0 Then
                            drow = drows(0)
                        Else
                            drow = resultado.Rows.Add()
                            drow.Item("dias") = 1
                            drow.Item("servicio_id") = reader.Item("servicio_id")
                            drow.Item("ucid") = reader.Item(ucid)
                            drow.Item("cantidad") = 0
                            drow.Item("precio") = 0
                            drow.Item("total") = 0
                            drow.Item("ldia") = reader.Item("fecha")
                        End If
                    End If
                    'contar dias distintos en los ke ese servicio+uc se encontro
                    If drow.Item("ldia") <> reader.Item("fecha") Then
                        'incrementa cada vez que cambien los dias
                        drow.Item("dias") += 1
                        drow.Item("ldia") = reader.Item("fecha")
                    End If
                    drow.Item("cantidad") += reader.Item("cantidad")

                    drow.Item("total") += (reader.Item("cantidad") * reader.Item("precio"))
                    drow.Item("precio") = drow.Item("total") / drow.Item("cantidad")
                End While
            Catch ex As Exception

            End Try
            'devolver tabla resultado
            Return resultado
        End Function
    End Class
End Namespace
Imports System.Xml.Serialization
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data
Imports MySql.Data.MySqlClient

Namespace geshotelk
    Partial Public Class GesHotelClase
        Private Class linea_bavel
            Public descripcion As String
            Public cantidad As Decimal
            Public precio_base As Decimal
            Public importe_total As Decimal
            Public fecha_desde As Date
            Public fecha_hasta As Date
            Public unidad_calculo_id As Integer
            Public cantidad_maxima As Integer
            Public tempcantmax As Integer
            Public reserva_id As Integer
            Public porc_igic As Decimal
            Public cuota As Decimal

            Public nombre_huesped As String
            Public numero_habitacion As String

            Public numero_pax As Integer
            Public adultos As Integer
            Public n1 As Integer
            Public n2 As Integer
            Public bebes As Integer
        End Class
        Shared sqlHoteles As String = "select hoteles.ruta_bavel as ruta_bavel,hoteles.email_reservas as email,empresas.cif as cif,hoteles.hotel,hoteles.direccion,hoteles.zip,hoteles.poblacion,provincias.provincia,naciones.desc_corta as nacion from hoteles inner join empresas on hoteles.empresa_id=empresas.empresa_id inner join provincias on hoteles.provincia_id=provincias.provincia_id inner join naciones on hoteles.nacion_id=naciones.nacion_id where hotel_id=?"
        Public Function generarEfacturaBavel(ByVal factura_id As Integer, Optional ByRef fb As facbavel = Nothing, Optional ByVal soloProbar As Boolean = False) As String
            Dim retVal As String = Nothing
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = generarEfacturaBavel(cmd, factura_id, fb, soloProbar)
            If IsNothing(retVal) Then
                errorCode = -1
            End If
            flushConection(cmd, errorCode)
            Return retVal
        End Function
        Private Function generarEfacturaBavel(ByVal cmd As Odbc.OdbcCommand, ByVal factura_id As Integer, Optional ByRef fb As facbavel = Nothing, Optional ByVal soloProbar As Boolean = False) As String
            Dim retVal As String = Nothing
            Dim errorCode As Integer = 0

            Try
                'todo:obtener datos factura
                'sqlCabAbreFactura

                cmd.Parameters.Clear()
                Dim factura_idParam As New Odbc.OdbcParameter("@factura_id", factura_id)
                cmd.Parameters.Add(factura_idParam)
                Dim cabfactura As DataRow
                Dim tmpds As DataSet = getDataSet(cmd, sqlCabAbreFactura)
                If Not IsNothing(tmpds) Then
                    If tmpds.Tables.Count > 0 Then
                        If tmpds.Tables(0).Rows.Count > 0 Then
                            cabfactura = tmpds.Tables(0).Rows(0)
                        End If

                    End If

                End If
                If Not IsNothing(cabfactura) Then

                    If cabfactura("estado_factura_id") <> 0 Then
                        'comprobar factura en estado 1
                        Dim hotel_id As Integer = cabfactura("hotel_id")
                        Dim supplier_id As Integer = cabfactura("hotel_id")
                        Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
                        Dim cliente_id As Integer = cabfactura("cliente_id") 'codigo cliente factura
                        Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", cliente_id)


                        If Not IsNothing(fb) Then
                            fb.hotel_id = hotel_id  ' Por defecto el hotel es el que pertoca

                        End If
                        '--------------------------------------------------------------------------------------------------
                        ' Aqui ponemos una garra nueva de Javier JULIO 2013
                        ' -------------------------------------------------------------------------------------------------
                        ' De tal manera que si el cliente_id de bavel es de tipo 99 y la factura tiene pension
                        ' entonces mandamos al fb.hotel_id= 100+hotel_id
                        Dim sql_tipo_factura = "select tipo_bavel from clientes_hotel where cliente_id = ? and hotel_id = ?"
                        cmd.Parameters.Clear()

                        cmd.Parameters.Add(cliente_idParam)
                        cmd.Parameters.Add(hotel_idParam)
                        Dim tipo_bavel = ExecuteScalar(cmd, sql_tipo_factura)
                        If Not IsDBNull(tipo_bavel) Then
                            If tipo_bavel = 99 Then ' Aqui si la factura es de pension, za,za,zasca!
                                Dim sql_importe_tipo_servicio = "SELECT SUM(lineas_factura.cantidad*lineas_factura.precio) " _
                                & "FROM lineas_factura " _
                                & "Inner Join servicios ON lineas_factura.servicio_id = servicios.servicio_id " _
                                & "WHERE lineas_factura.factura_id = ? AND servicios.tipo_servicio_id = ? "
                                Dim tipo_servicio_idParam As New Odbc.OdbcParameter("@tipo_servicio_id", 1)  ' A piñon 1 Habitacion
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add(factura_idParam)
                                cmd.Parameters.Add(tipo_servicio_idParam)
                                Dim importe = ExecuteScalar(cmd, sql_importe_tipo_servicio)
                                If IsNumeric(importe) Then
                                    If importe <> 0 Then
                                        supplier_id = 100 + hotel_id
                                    End If
                                End If
                            End If
                        End If
                        '--------------------------------------------------------------------------------------------------
                        ' FIN CHAPUZA
                        '--------------------------------------------------------------------------------------------------
                        cmd.Parameters.Clear()

                        cmd.Parameters.Add(hotel_idParam)
                        'datos del hotel
                        Dim cabhotel As DataRow = Nothing
                        Try
                            cabhotel = getDataSet(cmd, sqlHoteles, True).Tables(0).Rows(0)
                        Catch ex As Exception

                        End Try

                        'Dim centro_bavel_hotel As String
                        Dim cif_hotel As String
                        Dim nombre_hotel As String
                        Dim direccion_hotel As String
                        Dim codigopostal_hotel As String
                        Dim poblacion_hotel As String
                        Dim provincia_hotel As String
                        Dim pais_hotel As String
                        Dim email_hotel As String
                        Dim datoshotelcompletos As Boolean = False
                        'obtener datos del hotel
                        If Not IsNothing(cabhotel) Then


                            Try
                                'centro_bavel_hotel = cabhotel("centro_bavel")
                                If Not IsNothing(fb) Then
                                    fb.ruta_bavel = cabhotel("ruta_bavel")
                                End If
                                cif_hotel = cabhotel("cif")
                                nombre_hotel = cabhotel("hotel")
                                direccion_hotel = cabhotel("direccion")
                                codigopostal_hotel = cabhotel("zip")
                                poblacion_hotel = cabhotel("poblacion")
                                provincia_hotel = cabhotel("provincia")
                                pais_hotel = cabhotel("nacion")
                                If Not cabhotel.IsNull("email") Then
                                    email_hotel = cabhotel("email")
                                End If
                                'centro_bavel_hotel.Length = 0 Or
                                If pais_hotel.Length = 0 Or provincia_hotel.Length = 0 Or poblacion_hotel.Length = 0 Or cif_hotel.Length = 0 Or nombre_hotel.Length = 0 Or direccion_hotel.Length = 0 Or codigopostal_hotel.Length = 0 Then

                                Else
                                    datoshotelcompletos = True
                                End If
                            Catch ex As Exception

                            End Try
                        End If
                        If datoshotelcompletos Then
                            cif_hotel = filtrarCifBavel(cif_hotel)
                            Dim datosfacturacompletos As Boolean = False
                            Dim numero_factura As String
                            Dim serie_factura As String
                            Dim numero_factura_rectificada As String
                            'Dim serie_factura_rectificada
                            Dim fecha_factura As Date
                            Dim bono_reserva As String
                            'obtiene datos factura
                            Dim total_factura As Decimal
                            Try
                                total_factura = cabfactura("Importe_Total")
                                numero_factura = cabfactura("numero_factura")
                                'si total fac<0 entonces FacturaAbono
                                If total_factura < 0 Then
                                    serie_factura = "FacturaAbono"
                                Else
                                    serie_factura = "FacturaComercial"
                                End If
                                If Not IsNothing(fb) Then
                                    fb.tipofac = serie_factura
                                    If Not cabfactura.IsNull("envio_bavel") Then
                                        fb.envio_bavel = cabfactura("envio_bavel")
                                    End If

                                    If Not cabfactura.IsNull("fecha_envio_bavel") Then
                                        fb.fecha_envio_bavel = cabfactura("fecha_envio_bavel")
                                    End If

                                End If
                                numero_factura_rectificada = Nothing    'todo
                                'serie_factura_rectificada = Nothing 'todo
                                If Not cabfactura.IsNull("id_factura_rectificada") Then
                                    'sacar numero fac rectificada
                                    Dim cabfacrec As DataRow = Nothing
                                    cmd.Parameters.Clear()
                                    Dim facturarec_idParam As New Odbc.OdbcParameter("@factura_id", cabfactura("id_factura_rectificada"))
                                    cmd.Parameters.Add(facturarec_idParam)

                                    Try
                                        cabfacrec = getDataSet(cmd, sqlCabAbreFactura).Tables(0).Rows(0)
                                    Catch ex As Exception

                                    End Try
                                    If Not IsNothing(cabfacrec) Then
                                        numero_factura_rectificada = cabfacrec("numero_factura")
                                    End If
                                End If

                                fecha_factura = cabfactura("fecha_factura")
                                bono_reserva = cabfactura("ref_fra2")

                                If numero_factura.Length = 0 Or serie_factura.Length = 0 Or IsNothing(fecha_factura) Or bono_reserva.Length = 0 Then

                                Else
                                    datosfacturacompletos = True
                                End If
                            Catch ex As Exception

                            End Try

                            If datosfacturacompletos Then

                                'Dim cliente_id As Integer = cabfactura("cliente_id") 'codigo cliente factura
                                'Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", cliente_id)

                                'obtiene datos cliente
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add(cliente_idParam)
                                'datos del cliente
                                Dim cabcliente As DataRow = Nothing
                                Try
                                    cabcliente = getDataSet(cmd, sqlCabCliente, True).Tables(0).Rows(0)
                                Catch ex As Exception

                                End Try

                                Dim cif_cliente As String
                                Dim nombre_cliente As String
                                Dim direccion_cliente As String
                                Dim codigopostal_cliente As String
                                Dim poblacion_cliente As String
                                Dim provincia_cliente As String
                                Dim pais_cliente As String
                                Dim email_cliente As String
                                Dim cliente_id_convertido As String
                                Dim datosclientecompletos As Boolean = False
                                If Not IsNothing(cabcliente) Then
                                    Try
                                        pais_cliente = ObtienePais(cmd, cabcliente("nacion_id"))
                                        cif_cliente = cabcliente("nif")
                                        nombre_cliente = cabcliente("razon")

                                        direccion_cliente = cabcliente("direccion")
                                        If Not cabfactura.IsNull("direccion_fra") Then
                                            direccion_cliente = cabfactura("direccion_fra")
                                        Else
                                            If Not cabcliente.IsNull("direccion_fra") Then
                                                direccion_cliente = cabcliente("direccion_fra")
                                            End If
                                        End If

                                        codigopostal_cliente = "xxxx"
                                        Try
                                            codigopostal_cliente = cabcliente("zip")
                                            If Not cabfactura.IsNull("zip") Then
                                                codigopostal_cliente = cabfactura("zip")
                                            Else
                                                If Not cabcliente.IsNull("zip_fra") Then
                                                    codigopostal_cliente = cabcliente("zip_fra")
                                                End If
                                            End If
                                        Catch ex As Exception

                                        End Try

                                        poblacion_cliente = "xxxx"
                                        Try
                                            poblacion_cliente = cabcliente("poblacion")
                                            If Not cabfactura.IsNull("poblacion_fra") Then
                                                poblacion_cliente = cabfactura("poblacion_fra")
                                            Else
                                                If Not cabcliente.IsNull("poblacion_fra") Then
                                                    poblacion_cliente = cabcliente("poblacion_fra")
                                                End If
                                            End If
                                        Catch ex As Exception

                                        End Try


                                        If pais_cliente <> "ESP" Then
                                            provincia_cliente = "EXTRANJERO"
                                        Else
                                            provincia_cliente = ObtieneProvincia(cmd, cabcliente("provincia_id"))
                                        End If
                                        If Not cabcliente.IsNull("email") Then
                                            email_cliente = cabcliente("email")
                                        End If
                                        cliente_id_convertido = cliente_id
                                        If Not cabcliente.IsNull("cliente_bavel") Then
                                            cliente_id_convertido = cabcliente("cliente_bavel")
                                        Else
                                            'si tiene agencia..sacarlo de la agencia
                                            If Not cabcliente.IsNull("agencia_id") Then
                                                cmd.Parameters.Clear()
                                                Dim agencia_idParam As New Odbc.OdbcParameter("@agencia_id", cabcliente("agencia_id"))
                                                cmd.Parameters.Add(agencia_idParam)
                                                'datos del cliente
                                                Dim cabagencia As DataRow = getDataSet(cmd, sqlCabCliente, True).Tables(0).Rows(0)
                                                If Not cabagencia.IsNull("cliente_bavel") Then
                                                    cliente_id_convertido = cabagencia("cliente_bavel")
                                                End If
                                            End If

                                        End If
                                        'cliente_id_convertido = cliente_id 'usar tabla de conversion
                                        If cliente_id_convertido.Length = 0 Or pais_cliente.Length = 0 Or provincia_cliente.Length = 0 Or cif_cliente.Length = 0 Or nombre_cliente.Length = 0 Or direccion_cliente.Length = 0 Or codigopostal_cliente.Length = 0 Or poblacion_cliente.Length = 0 Then
                                        Else
                                            datosclientecompletos = True
                                        End If
                                    Catch ex As Exception

                                    End Try
                                End If

                                If datosclientecompletos Then
                                    cif_cliente = filtrarCifBavel(cif_cliente)
                                    cmd.Parameters.Clear()
                                    cmd.Parameters.Add(factura_idParam)

                                    Dim lineas_factura As DataTable = Nothing
                                    Try
                                        lineas_factura = getDataSet(cmd, sqlObtieneDatosFacturaParaApunte).Tables(0)
                                    Catch ex As Exception

                                    End Try
                                    If Not IsNothing(lineas_factura) Then

                                        Dim fecha_linea_min As Date = lineas_factura.Compute("min(fecha_linea)", "")
                                        Dim fecha_linea_max As Date = lineas_factura.Compute("max(fecha_linea)", "")
                                        Dim tefa As New FacturaElectronicaBavel.UniversalIntegratedTransaction
                                        tefa.GeneralData = New FacturaElectronicaBavel.CGeneralData
                                        With tefa.GeneralData
                                            .Ref = numero_factura
                                            .Type = serie_factura '"FacturaComercial"
                                            .Date = fecha_factura.ToString("yyyy-MM-dd")
                                            .Currency = "EUR"

                                            .TaxIncluded = True
                                            .TaxIncludedSpecified = True
                                            '.Contract="" ' se podria sacar el contrato mas usado en las lineas
                                            If Not cabfactura.IsNull("ref_fra1") Then
                                                .Concept = cabfactura("ref_fra1") 'concepto generico o ref1
                                            Else
                                                'poner un concepto?
                                                .Concept = "Sin concepto"
                                            End If

                                            .BeginDate = fecha_linea_min.ToString("yyyy-MM-dd")
                                            .EndDate = fecha_linea_max.ToString("yyyy-MM-dd")
                                            .OnlyArchive = False
                                            '.NCF = "vete a saber ke es esto"
                                            .ServiceType = "Reserva Hotelera"
                                            'todo ver si se necesita mas..
                                        End With
                                        tefa.Supplier = New FacturaElectronicaBavel.CSupplier
                                        With tefa.Supplier
                                            ' AQUI tengo que poner la Ñapa para el .SuplierID = Hotel_id o 100+ hotel_id
                                            ' pongo la variable supplier_id que calculé previamente
                                            .SupplierID = supplier_id
                                            .CIF = cif_hotel
                                            .Company = nombre_hotel
                                            .Address = direccion_hotel
                                            .City = poblacion_hotel
                                            .PC = codigopostal_hotel
                                            .Province = provincia_hotel
                                            .Country = pais_hotel
                                            .Email = email_hotel

                                            'todo ver si se necesita mas..
                                        End With


                                        tefa.Client = New FacturaElectronicaBavel.CClient
                                        With tefa.Client
                                            .SupplierClientID = cliente_id_convertido
                                            .CIF = cif_cliente
                                            .Company = nombre_cliente
                                            .Address = direccion_cliente
                                            .City = poblacion_cliente
                                            .PC = codigopostal_cliente
                                            .Province = provincia_cliente
                                            .Country = pais_cliente
                                            .Email = email_cliente

                                        End With
                                        Dim com(0) As FacturaElectronicaBavel.CComment
                                        com(0) = New FacturaElectronicaBavel.CComment
                                        tefa.Comments = com
                                        With com(0)
                                            .Msg = cabfactura("ref_fra1") + " " + cabfactura("ref_fra2")
                                            .Subject = "Observaciones"

                                        End With
                                        'si factura rectifica
                                        If numero_factura_rectificada <> "" Then
                                            Dim ref(0) As FacturaElectronicaBavel.CReference
                                            ref(0) = New FacturaElectronicaBavel.CReference
                                            tefa.References = ref
                                            With ref(0)
                                                .InvoiceRef = numero_factura_rectificada

                                            End With
                                        End If
                                        'aqui van las lineas de la factura
                                        'ProductList

                                        Dim lineas As New ArrayList
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.Add(factura_idParam)

                                        Dim reader As DataTableReader = getDataTable(cmd, sqlObtieneDatosFacturaParaApunte & " order by lineas_factura.unidad_calculo_id,lineas_factura.servicio_id,lineas_factura.fecha,cantidad desc")
                                        Dim tipos_servicios As New Hashtable
                                        While reader.Read
                                            'agrupar por servicio+uc
                                            procesaLineaBavel(reader, tipos_servicios)
                                        End While
                                        fijaLineasBavel(tipos_servicios)
                                        Dim enuser As IEnumerator = tipos_servicios.Values.GetEnumerator
                                        'reader = getDataTable(cmd, sqlObtieneDatosFacturaParaApunte)
                                        'While reader.Read
                                        Dim datres As DatosReserva = Nothing
                                        Dim totalbase As Decimal = 0
                                        Dim totalcuota As Decimal = 0
                                        Dim totalfac As Decimal = 0
                                        Dim errorlineas As Integer = 0

                                        'Dim taxsum(0) As FacturaElectronicaBavel.CTax
                                        'taxsum(0) = New FacturaElectronicaBavel.CTax
                                        'tefa.TaxSummary = taxsum
                                        Dim impuestos As New Hashtable
                                        Dim impuestostotal As New Hashtable
                                        Dim impuestostotalbase As New Hashtable
                                        While enuser.MoveNext
                                            Dim readerd As linea_bavel = enuser.Current
                                            If readerd.reserva_id > 0 Then
                                                Dim linea As New FacturaElectronicaBavel.CProduct
                                                With linea
                                                    If IsNothing(datres) Then
                                                        datres = obtieneReservaDatosListados(cmd, readerd.reserva_id)
                                                        Dim pos = datres.bono.IndexOf("//")
                                                        If pos <> -1 Then
                                                            datres.bono = datres.bono.Split("//", 2, CompareMethod.Text)(0)
                                                        End If

                                                    End If

                                                    .SupplierSKU = readerd.reserva_id '"codigo reserva?"
                                                    .CustomerSKU = datres.bono
                                                    .Item = readerd.descripcion
                                                    .Qty = readerd.cantidad.ToString("0.0000", CultureInfo.InvariantCulture)
                                                    .MU = "Unidades"
                                                    .UP = readerd.precio_base.ToString("0.000000", CultureInfo.InvariantCulture)
                                                    readerd.cantidad = .Qty / 10000
                                                    readerd.precio_base = .UP / 1000000
                                                    Dim total As Decimal = (readerd.cantidad * readerd.precio_base)
                                                    totalbase = totalbase + total

                                                    '.Total = readerd.importe_total.ToString("0.0000", CultureInfo.InvariantCulture)
                                                    'totalfac += (.Total / 10000)
                                                    .Comment = readerd.descripcion 'podrian ser las fechas ?
                                                    Dim tax(0) As FacturaElectronicaBavel.CTax
                                                    tax(0) = New FacturaElectronicaBavel.CTax
                                                    linea.Taxes = tax
                                                    With linea.Taxes(0)
                                                        .Type = "IGIC"
                                                        .Rate = readerd.porc_igic.ToString("0.0000", CultureInfo.InvariantCulture)
                                                        .Amount = readerd.cuota.ToString("0.0000", CultureInfo.InvariantCulture)
                                                        readerd.cuota = .Amount / 10000
                                                        totalcuota = totalcuota + readerd.cuota
                                                        Dim impsumlinea As FacturaElectronicaBavel.CTax
                                                        If Not impuestos.ContainsKey(readerd.porc_igic) Then
                                                            impsumlinea = New FacturaElectronicaBavel.CTax
                                                            impsumlinea.Type = "IGIC"
                                                            impsumlinea.Rate = readerd.porc_igic.ToString("0.0000", CultureInfo.InvariantCulture)
                                                            impsumlinea.Amount = readerd.cuota.ToString("0.0000", CultureInfo.InvariantCulture)
                                                            impsumlinea.Base = Decimal.Subtract(total, readerd.cuota).ToString("0.00", CultureInfo.InvariantCulture)
                                                            impuestostotalbase.Add(readerd.porc_igic, Decimal.Subtract(total, readerd.cuota))
                                                            impuestostotal.Add(readerd.porc_igic, readerd.cuota)
                                                            impuestos.Add(readerd.porc_igic, impsumlinea)
                                                        Else
                                                            impsumlinea = impuestos(readerd.porc_igic)
                                                            Dim imptotcalc As Decimal = impuestostotal(readerd.porc_igic)
                                                            Dim imptotbase As Decimal = impuestostotalbase(readerd.porc_igic)
                                                            imptotbase = imptotbase + Decimal.Subtract(total, readerd.cuota)

                                                            imptotcalc = imptotcalc + readerd.cuota
                                                            impuestostotal(readerd.porc_igic) = imptotcalc
                                                            impuestostotalbase(readerd.porc_igic) = imptotbase
                                                            impsumlinea.Amount = imptotcalc.ToString("0.0000", CultureInfo.InvariantCulture)
                                                            impsumlinea.Base = imptotbase.ToString("0.00", CultureInfo.InvariantCulture)
                                                        End If


                                                        'total += readerd.cuota
                                                    End With

                                                    .Total = total.ToString("0.00", CultureInfo.InvariantCulture)
                                                    '.NetAmount = .Total
                                                    totalfac = Decimal.Add(totalfac, (.Total / 100))



                                                    'ServicesData
                                                    Dim sd(0) As FacturaElectronicaBavel.CServiceData
                                                    sd(0) = New FacturaElectronicaBavel.CServiceData
                                                    linea.ServicesData = sd
                                                    With linea.ServicesData(0)
                                                        .SupplierClientID = cliente_id_convertido
                                                        '----------------------------------------------------------------------------
                                                        ' Tambien sustituyo hotel_id por supplier_id calculado previamente
                                                        ' Que miedo
                                                        '-----------------------------------------------------------------------------
                                                        .SupplierID = supplier_id
                                                        .SupplierName = nombre_hotel
                                                        '.Pax = readerd.nombre_huesped
                                                        .BeginDate = readerd.fecha_desde.ToString("yyyy-MM-dd")
                                                        .EndDate = readerd.fecha_hasta.ToString("yyyy-MM-dd")
                                                        .Voucher = datres.bono
                                                        '.PaxNumber = readerd.numero_pax
                                                        '.AdultsNumber = readerd.adultos
                                                        '.KidsNumber = readerd.n1 + readerd.n2
                                                        '.RoomNumber = readerd.numero_habitacion
                                                        .PaxNumber = datres.pax
                                                        .PaxNumberSpecified = True
                                                        .AdultsNumber = datres.a
                                                        .AdultsNumberSpecified = True
                                                        .KidsNumber = datres.n1 + datres.n2
                                                        .KidsNumberSpecified = True
                                                        .RoomNumber = datres.habitacion

                                                        .Pax = datres.primer_huesped
                                                        .RoomCategory = datres.tipo_hab

                                                        '.ServiceType = 3
                                                        '.BumperSupplierID = 3
                                                    End With

                                                End With
                                                lineas.Add(linea)
                                            Else
                                                errorlineas += 1
                                            End If
                                        End While
                                        If errorlineas = 0 Then
                                            Dim arrayimpuestos As New ArrayList
                                            arrayimpuestos.InsertRange(0, impuestos.Values)
                                            tefa.TaxSummary = arrayimpuestos.ToArray(GetType(FacturaElectronicaBavel.CTax))
                                            tefa.ProductList = lineas.ToArray(GetType(FacturaElectronicaBavel.CProduct))
                                            'totales de la factura
                                            tefa.TotalSummary = New FacturaElectronicaBavel.CTotalSummary

                                            tefa.TotalSummary.Discounts = 0
                                            tefa.TotalSummary.SubTotal = (totalbase - totalcuota).ToString("0.00", CultureInfo.InvariantCulture) 'suma de las bases
                                            totalbase = tefa.TotalSummary.SubTotal / 100
                                            tefa.TotalSummary.Tax = totalcuota.ToString("0.00", CultureInfo.InvariantCulture) 'suma de los impuestos
                                            totalcuota = tefa.TotalSummary.Tax / 100
                                            tefa.TotalSummary.Total = (totalbase + totalcuota).ToString("0.00", CultureInfo.InvariantCulture)
                                            'tefa.TotalSummary.Total = (totalbase).ToString("0.00", CultureInfo.InvariantCulture)
                                            tefa.TotalSummary.GrossAmount = tefa.TotalSummary.Total
                                            Dim ntotal As Decimal = tefa.TotalSummary.Total / 100
                                            If total_factura = ntotal And total_factura = totalfac Then
                                                'If total_factura = totalfac Then
                                                'genera xml
                                                If soloProbar Then
                                                    retVal = "OK"
                                                Else
                                                    Dim serializer As New XmlSerializer(GetType(FacturaElectronicaBavel.UniversalIntegratedTransaction))
                                                    Dim temp As String
                                                    Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream()
                                                    Dim tem = New System.Xml.XmlTextWriter(stream, System.Text.Encoding.UTF8)
                                                    serializer.Serialize(tem, tefa)
                                                    temp = System.Text.Encoding.UTF8.GetString(stream.ToArray())
                                                    retVal = temp.Substring(1)
                                                End If

                                                'Console.WriteLine(temp)
                                            Else
                                                'error grave de decimales
                                                errorCode = 5
                                                AgregaInfo("generarEfacturaBavel", "Total Factura no coincide", -errorCode)
                                                If soloProbar Then
                                                    ListaErrores.Clear()
                                                End If

                                            End If
                                        Else
                                            errorCode = 8
                                            AgregaInfo("generarEfacturaBavel", "Lineas Sin Reserva", -errorCode)

                                        End If
                                    Else
                                        errorCode = 7
                                        AgregaInfo("generarEfacturaBavel", "Factura Sin Lineas", -errorCode)
                                    End If
                                Else
                                    errorCode = 5
                                    AgregaInfo("generarEfacturaBavel", "Informacion del Cliente Incompleto", -errorCode)
                                End If
                            Else
                                errorCode = 4
                                AgregaInfo("generarEfacturaBavel", "Informacion de la factura Incompleta", -errorCode)
                            End If

                        Else
                            errorCode = 3
                            AgregaInfo("generarEfacturaBavel", "Informacion del hotel Incompleta", -errorCode)

                        End If
                    Else
                        errorCode = 2
                        AgregaInfo("generarEfacturaBavel", "Factura no esta en estado actualizado", -errorCode)
                    End If
                Else
                    errorCode = 2
                    AgregaInfo("generarEfacturaBavel", "No existe Factura", -errorCode)
                End If
            Catch ex As Exception
                retVal = Nothing
            Finally
                'retVal = False
                If IsNothing(retVal) Then
                    errorCode = 1
                End If

            End Try
            Return retVal
        End Function
        Shared sqlProvincias = "select provincia from provincias where provincia_id=?"
        Private Function ObtieneProvincia(ByVal cmd As Odbc.OdbcCommand, ByVal provincia_id As Integer) As String
            cmd.Parameters.Clear()
            Dim provincia_idParam As New Odbc.OdbcParameter("@provincia_id", provincia_id)
            cmd.Parameters.Add(provincia_idParam)
            'datos del cliente
            Return Me.ExecuteScalar(cmd, sqlProvincias, True)
        End Function
        Shared sqlNaciones = "select desc_corta from naciones where nacion_id=?"
        Private Function ObtienePais(ByVal cmd As Odbc.OdbcCommand, ByVal nacion_id As Integer) As String
            cmd.Parameters.Clear()
            Dim nacion_idParam As New Odbc.OdbcParameter("@nacion_id", nacion_id)
            cmd.Parameters.Add(nacion_idParam)
            'datos del cliente
            Return Me.ExecuteScalar(cmd, sqlNaciones, True)
        End Function

        Private Sub procesaLineaBavel(ByVal reader As DataTableReader, ByVal tipos_servicios As Hashtable)
            Dim x As linea_bavel = tipos_servicios(reader("servicio_id") & "_" & reader("unidad_calculo_id"))
            If IsNothing(x) Then
                x = New linea_bavel
                x.porc_igic = reader("Porc_igic")
                If Not reader.IsDBNull(reader.GetOrdinal("reserva_id")) Then
                    x.reserva_id = reader("reserva_id")
                End If

                x.unidad_calculo_id = reader("unidad_calculo_id")
                x.descripcion = reader("descripcion")
                x.cantidad = 0
                x.importe_total = 0
                'x.precio_base = 0
                x.cuota = 0
                x.cantidad_maxima = reader("cantidad") 'error reserva un solo dia varias lineas..
                x.tempcantmax = 0
                x.fecha_desde = reader("fecha_linea")
                x.fecha_hasta = reader("fecha_linea")
                tipos_servicios(reader("servicio_id") & "_" & reader("unidad_calculo_id")) = x
            End If
            Dim difdias = DateDiff(DateInterval.Day, x.fecha_hasta, reader("fecha_linea"))
            If difdias <= 1 Then

                x.fecha_hasta = reader("fecha_linea")
                x.cantidad += reader("cantidad")
                'Dim tbase As Decimal = (reader("cantidad") * reader("precio_base"))
                'Dim tcouta As Decimal = tbase - Decimal.Round(((tbase) / (1 + (x.porc_igic / 100))), 2)
                'x.cuota += tcouta
                'x.precio_base += (tbase - tcouta)
                'x.importe_total += tbase

                'x.precio_base = x.importe_total / x.cantidad
                Dim imp As Decimal = reader("precio_base") * reader("cantidad")

                'Dim cuota As Decimal = imp - Math.Round((imp / (1 + (x.porc_igic / 100))), 2, MidpointRounding.AwayFromZero)
                'imp = Math.Round(imp, 2, MidpointRounding.AwayFromZero)
                'x.importe_total += imp
                x.importe_total += Math.Round(reader("precio_base") * reader("cantidad"), 2, MidpointRounding.AwayFromZero)
                'x.cuota += cuota
                'x.precio_base += (imp - cuota) / reader("cantidad")

                'x.importe_total += reader("cantidad") * reader("precio_base")
                If difdias = 1 Then
                    If x.tempcantmax > x.cantidad_maxima Then
                        x.cantidad_maxima = x.tempcantmax
                    End If
                    x.tempcantmax = 0
                End If
                x.tempcantmax += reader("cantidad")
            Else
                'todo: cambiar la id de la tabla hash
                'y empezar otra linea
                tipos_servicios.Remove(reader("servicio_id") & "_" & reader("unidad_calculo_id"))
                tipos_servicios(reader("servicio_id") & "_" & reader("unidad_calculo_id") & convertFecha(x.fecha_hasta)) = x
                procesaLineaBavel(reader, tipos_servicios)
            End If
        End Sub

        Private Sub fijaLineasBavel(ByVal tipos_servicios As Hashtable)
            Dim adultos As Integer = 0
            Dim n1 As Integer = 0
            Dim n2 As Integer = 0
            Dim bebes As Integer = 0
            Dim pax As Integer
            Dim ienu As IEnumerator = tipos_servicios.Keys.GetEnumerator
            While ienu.MoveNext
                Dim x As linea_bavel = tipos_servicios(ienu.Current)
                If x.tempcantmax > x.cantidad_maxima Then
                    x.cantidad_maxima = x.tempcantmax
                End If
                x.tempcantmax = 0


                x.cuota = Math.Round(x.importe_total - (x.importe_total / (1 + (x.porc_igic / 100))), 2)
                ''x.cuota = Decimal.Round(((x.porc_igic * x.importe_total) / 100), 2)
                If x.cantidad = 0 Then
                    'es un ajuste de precio y no de cantidad
                    'posibile solucion crear 2 lineas pos y neg
                    'crear cantidad=1 tipo ajuste
                    x.cantidad = 1
                End If
                If x.cantidad <> 0 Then
                    '                    x.precio_base = (x.importe_total - x.cuota) / x.cantidad
                    x.precio_base = (x.importe_total) / x.cantidad
                End If
                'x.precio_base = x.importe_total - x.cuota
                If x.unidad_calculo_id = 2 Then
                    x.adultos = x.cantidad_maxima
                    If x.adultos > adultos Then
                        adultos = x.adultos
                    End If
                End If
                If x.unidad_calculo_id = 3 Then
                    x.n1 = x.cantidad_maxima
                    If x.n1 > n1 Then
                        n1 = x.n1
                    End If
                End If
                If x.unidad_calculo_id = 4 Then
                    x.n2 = x.cantidad_maxima
                    If x.n2 > n2 Then
                        n2 = x.n2
                    End If
                End If
                If x.unidad_calculo_id = 5 Then
                    x.bebes = x.cantidad_maxima
                    If x.bebes > bebes Then
                        bebes = x.bebes
                    End If
                End If
            End While
            pax = adultos + n1 + n2
            Dim ienua As IEnumerator = tipos_servicios.Keys.GetEnumerator
            While ienua.MoveNext
                Dim x As linea_bavel = tipos_servicios(ienua.Current)
                x.numero_pax = pax
                x.adultos = adultos
                x.n1 = n1
                x.n2 = n2
                x.bebes = bebes
            End While
        End Sub
        Public Class facbavel
            Public tipofac As String
            Public hotel_id As Integer

            Public ruta_bavel As String

            Public envio_bavel As Integer = 0

            Public fecha_envio_bavel As String = Nothing

        End Class
        Function generaFicheroBavel(ByVal cmd As Odbc.OdbcCommand, ByVal factura_id As Integer) As Boolean
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0

            Dim facb As New facbavel
            Dim tmp As String = generarEfacturaBavel(cmd, factura_id, facb)
            If Not IsNothing(tmp) Then
                'si factura ya ha sido generada alguna otra vez...no volvera a generar
                If IsNothing(facb.fecha_envio_bavel) And facb.envio_bavel = 1 Then
                    'actualizar fecha factura envio babel
                    cmd.Parameters.Clear()
                    Dim factura_idParam As New Odbc.OdbcParameter("@factura_id", factura_id)
                    cmd.Parameters.Add(factura_idParam)
                    Dim sqlActualizaFechaEnvioBavel = "update facturas set fecha_envio_bavel=now() where factura_id=?"
                    Dim c As Integer = ExecuteNonQuery(cmd, sqlActualizaFechaEnvioBavel)

                    If c <> 1 Then
                        retVal = False
                    Else
                        retVal = True
                    End If
                    If retVal Then
                        Try
                            Dim fb As New FicheroBavel
                            facb.tipofac = "Factura" 'a fuego pedido por javier nuñez dia 19/10/2010
                            fb.FicheroBavel(facb.tipofac, facb.ruta_bavel, factura_id)
                            fb.agregaContenido(tmp)
                            retVal = fb.generarFichero()
                        Catch ex As Exception
                            retVal = False
                            errorCode = 2
                            AgregaInfo("generaFicheroBavel", "Fichero Factura no creado", -errorCode)
                        End Try

                    End If
                End If

            Else
                'fut...volcar los errores a una tabla de portal...

            End If
            If Not retVal Then
                errorCode = 1
            End If

            Return retVal
        End Function
        Function generaFicheroBavel(ByVal factura_id As Integer) As Boolean
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            errorCode = generaFicheroBavel(cmd, factura_id)
            flushConection(cmd, errorCode)
            Return retVal
        End Function
        Function generarFicherosBavelCliente(ByVal cliente_id As Integer) As Boolean
            'en cada cierre de hotel generar las facturas bavel de ese hotel
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim reader As DataTableReader = Nothing
            Try


                cmd.Parameters.Clear()
                Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", cliente_id)
                cmd.Parameters.Add(cliente_idParam)

                Dim cliente_id1Param As New Odbc.OdbcParameter("@cliente_id1", cliente_id)
                cmd.Parameters.Add(cliente_id1Param)
                Dim sqlObtieneFacturasBavel = "select factura_id from facturas where cliente_id=? or ?=0"

                reader = getDataTable(cmd, sqlObtieneFacturasBavel)
            Catch ex As Exception
                errorCode = 2
                AgregaInfo("generarFicherosBavelCliente", "No puedo obtener lista facturas del cliente", -errorCode)
            Finally
                flushConection(cmd, errorCode)
            End Try

            If Not IsNothing(reader) Then
                Dim contar As Integer = 0
                Dim contare As Integer = 0
                Dim max As Integer = 600000000
                While reader.Read And contar < max
                    ListaErrores.Clear()
                    Dim tmp = generarEfacturaBavel(reader("factura_id"), Nothing, True)
                    If (contar Mod 500) = 0 Then
                        Console.WriteLine(contar)
                    End If
                    If IsNothing(tmp) And ListaErrores.Count = 0 Then
                        Console.WriteLine("fac:" & reader("factura_id") & "-error")
                        contare += 1

                    End If
                    contar += 1
                End While
                Console.WriteLine("tot:" & contar & "-err:" & contare)
            End If
            Return True
        End Function
        Function generarFicherosBavelHotel(ByVal cmd As Odbc.OdbcCommand, ByVal hotel_id As Integer) As Boolean
            'en cada cierre de hotel generar las facturas bavel de ese hotel
            Dim errorCode As Integer = 0
            Dim reader As DataTableReader = Nothing
            Try
                cmd.Parameters.Clear()
                Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
                cmd.Parameters.Add(hotel_idParam)
                Dim sqlObtieneFacturasBavel = "select factura_id from facturas where envio_bavel=1 and fecha_envio_bavel is null and hotel_id=?"

                reader = getDataTable(cmd, sqlObtieneFacturasBavel)
            Catch ex As Exception
                errorCode = 2
                AgregaInfo("generarFicherosBavelHotel", "No puedo obtener lista facturas pendientes a enviar", -errorCode)
                reader = Nothing
            End Try

            If Not IsNothing(reader) Then
                While reader.Read
                    generaFicheroBavel(cmd, reader("factura_id"))
                End While
            End If
            Return True
        End Function
        Function generarFicherosBavelHotel(ByVal hotel_id As Integer) As Boolean
            'en cada cierre de hotel generar las facturas bavel de ese hotel
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            generarFicherosBavelHotel(cmd, hotel_id)
            Return True
        End Function
        Function ColocaEstadoBavel(ByVal factura_id As Integer, Optional ByVal enviar As Boolean = True) As Boolean
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            Dim retVal As Boolean = ColocaEstadoBavel(cmd, factura_id, enviar)
            flushConection(cmd, 0)
        End Function
        Function ColocaEstadoBavel(ByVal cmd As Odbc.OdbcCommand, ByVal factura_id As Integer, Optional ByVal enviar As Boolean = True) As Boolean
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Try
                cmd.Parameters.Clear()
                Dim factura_idParam As New Odbc.OdbcParameter("@factura_id", factura_id)
                cmd.Parameters.Add(factura_idParam)
                Dim cabfactura As DataRow = getDataSet(cmd, sqlCabAbreFactura).Tables(0).Rows(0)
                Dim c As Integer = 1
                '**************************************************
                ' Añadimos que el importe_total ha de ser <>0
                ' Febrero 2012
                ' Javier Nuñez
                '**************************************************
                If EsClienteBavel(cmd, cabfactura("cliente_id") And (cabfactura("serie_id") = 1 Or (cabfactura("serie_id") = 9 And cabfactura("importe_total") > 0)), cabfactura("hotel_id")) And cabfactura("importe_total") <> 0 Then
                    ' *******************************************************************************************************************
                    ' Aqui Garra de Javier Febrero 2012
                    ' Preguntamos si el cliente del hotel envía todas las facturas o solo de algún tipo en especial
                    ' *******************************************************************************************************************
                    Dim sql_tipo_factura = "select tipo_bavel from clientes_hotel where cliente_id = ? and hotel_id = ?"
                    cmd.Parameters.Clear()
                    Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", cabfactura("cliente_id"))
                    Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", cabfactura("hotel_id"))
                    cmd.Parameters.Add(cliente_idParam)
                    cmd.Parameters.Add(hotel_idParam)
                    Dim tipo_bavel = ExecuteScalar(cmd, sql_tipo_factura)
                    If Not IsDBNull(tipo_bavel) Then
                        enviar = False     ' Si hay algo en tipo_bavel entonces por defecto no enviamos
                        If tipo_bavel = 99 Then  'Se envían todas pero por separado JULIO 2013
                            enviar = True
                        Else ' Solo se quieren enviar las de tipo habitación o pensión
                            Dim sql_importe_tipo_servicio = "SELECT SUM(lineas_factura.cantidad*lineas_factura.precio) " _
                            & "FROM lineas_factura " _
                            & "Inner Join servicios ON lineas_factura.servicio_id = servicios.servicio_id " _
                            & "WHERE lineas_factura.factura_id = ? AND servicios.tipo_servicio_id = ? "
                            Dim tipo_servicio_idParam As New Odbc.OdbcParameter("@tipo_servicio_id", tipo_bavel)
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add(factura_idParam)
                            cmd.Parameters.Add(tipo_servicio_idParam)
                            Dim importe = ExecuteScalar(cmd, sql_importe_tipo_servicio)
                            If IsNumeric(importe) Then
                                If importe <> 0 Then
                                    enviar = True
                                End If
                            End If
                        End If
                    End If
                    ' Fin de la garra de Javier Febrero 2012
                    ' **********************************************************************************************************************
                    Dim sqlActualizaEnvioBavel = "update facturas set envio_bavel=1 where fecha_envio_bavel is null and factura_id=?"
                    If Not enviar Then
                        sqlActualizaEnvioBavel = "update facturas set envio_bavel=0 where fecha_envio_bavel is null and factura_id=?"
                    End If
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(factura_idParam)
                    c = ExecuteNonQuery(cmd, sqlActualizaEnvioBavel)
                End If
                If c = 1 Then
                    retVal = True
                End If

            Catch ex As Exception
                errorCode = 2
                AgregaInfo("ColocaEstadoBavel", "No puedo cambiar envio_bavel", -errorCode)
            End Try

            Return retVal
        End Function
        Function EsClienteBavel(ByVal cliente_id As Integer, ByVal hotel_id As Integer) As Boolean
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Dim cmd As Odbc.OdbcCommand = prepareConection()
            retVal = EsClienteBavel(cmd, cliente_id, hotel_id)
            flushConection(cmd, errorCode)
            Return retVal
        End Function
        Function EsClienteBavel(ByVal cmd As Odbc.OdbcCommand, ByVal cliente_id As Integer, ByVal hotel_id As Integer) As Boolean
            Dim retVal As Boolean = False
            Dim errorCode As Integer = 0
            Try
                Dim sqlClienteBavel = "SELECT clientes_hotel.cliente_bavel ,clientes.cliente_bavel FROM clientes left join clientes_hotel on clientes.cliente_id=clientes_hotel.cliente_id WHERE clientes.cliente_id = ? And clientes_hotel.hotel_id = ?"
                cmd.Parameters.Clear()
                Dim cliente_idParam As New Odbc.OdbcParameter("@cliente_id", cliente_id)
                cmd.Parameters.Add(cliente_idParam)
                Dim hotel_idParam As New Odbc.OdbcParameter("@hotel_id", hotel_id)
                cmd.Parameters.Add(hotel_idParam)
                Dim reader As DataTableReader = getDataTable(cmd, sqlClienteBavel)
                Dim cliente As Object
                Dim cliente_hotel As Object
                While reader.Read
                    cliente_hotel = reader.Item(0)
                    If Not IsNothing(cliente_hotel) And Not IsDBNull(cliente_hotel) Then
                        If cliente_hotel.Length > 0 Then
                            Return True
                        End If
                    End If
                    cliente = reader.Item(1)
                    If Not IsNothing(cliente) And Not IsDBNull(cliente) Then
                        If cliente.Length > 0 Then
                            Return True
                        End If
                    End If
                End While
            Catch ex As Exception
                errorCode = 2
                AgregaInfo("EsClienteBavel", "No puedo obtener cliente bavel", -errorCode)
            End Try
            Return retVal
        End Function

        Private Function filtrarCifBavel(ByVal cif As String) As String
            cif = Text.RegularExpressions.Regex.Replace(cif, "[\W]", "")
            Return cif
        End Function

    End Class
End Namespace

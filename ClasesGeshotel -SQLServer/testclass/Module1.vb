Imports System.Text.RegularExpressions


Module Module1
    Dim ids As New ArrayList()
    Public Class upd
        Public sqlQuery As Text.StringBuilder

        Public Sub New(ByVal u As String)
            sqlQuery = New Text.StringBuilder(u)
        End Sub
    End Class


    Public Sub dumpds(ByVal ds As DataSet)
        Dim dr As DataTableReader = ds.Tables(0).CreateDataReader()
        While dr.Read
            Dim x
            For x = 0 To dr.FieldCount - 1
                Console.Write(dr.Item(x))
                Console.Write("-")
            Next
            Console.WriteLine(";")
        End While
    End Sub
    Private Function readRemFile(ByVal url As String) As String
        Dim Source As New Text.StringBuilder
        Dim WebResponse As Net.WebResponse = Net.WebRequest.Create(url).GetResponse
        Dim StreamReader As New IO.StreamReader(WebResponse.GetResponseStream())
        Dim l As String
        l = StreamReader.ReadLine()
        While Not IsNothing(l)
            Source.Append(l)
            l = StreamReader.ReadLine()
        End While

        StreamReader.Close()

        Return Source.ToString()
    End Function
    Public Function resetScriptsPositions(ByVal html As String) As String
        Console.WriteLine(html.Length)
        'Dim regstring As String = "<script[^>]"
        'Dim regstring As String = "<script[^>]*src='([^']*)'*([^>]*>)*</script>"
        'Dim regstring As String = "<script[^>]*src='([^']*)'*>*</script>"
        Dim regs As New Queue
        Dim regstring As String = "<script[^>]*src='([^']*)'*[^>]*>*</script>"
        Dim resultado As New Hashtable
        regs.Enqueue(regstring)
        regs.Enqueue(regstring.Replace("'", """"))
        Do
            regstring = regs.Dequeue()
            For Each match As Match In Regex.Matches(html, regstring)
                If Not resultado.ContainsValue(match.Value) Then
                    html = html.Remove(match.Index, match.Length)
                    'resultado.Add(match.Index, match.Groups(1).Value)
                    resultado.Add(match.Index, match.Value)
                End If
            Next
        Loop While regs.Count > 0
        'busca head y lo enchufa alli
        regstring = "<head[^>]*>"
        For Each match As Match In Regex.Matches(html, regstring)
            regs = New Queue(resultado.Values)
            Dim tmp As String = ""
            While regs.Count > 0
                tmp += regs.Dequeue
            End While
            html = html.Insert(match.Index + match.Length, tmp)
        Next
        Return html
    End Function
    Function testred()
        Dim roundn As Decimal = 0
        Dim rx As Integer
        For rx = 0 To 100
            Console.WriteLine(rx * 0.001 & "-" & Math.Round(rx * 0.001, 2, MidpointRounding.AwayFromZero))
        Next
        Console.ReadKey()
        End
    End Function
    Private Class opcion
        Public contador As Integer
        Public observaciones As String
    End Class
    Function parseRespuestas(ByVal xx As String) As Hashtable
        Dim resp() As String = xx.Split("|")
        Dim ar As New Hashtable
        Dim zz As Integer

        For zz = 0 To resp.Length - 1
            Dim tmp() As String = resp(zz).Split(",")
            Dim opcion As Integer = CInt(tmp(0))
            Dim yy As New opcion
            yy.contador = CInt(tmp(1))
            Dim sb As New Text.StringBuilder
            Dim tt As Integer
            For tt = 2 To tmp.Length - 1
                If sb.Length <> 0 Then
                    sb.Append(",")
                End If
                sb.Append(tmp(tt))
            Next
            yy.observaciones = sb.ToString
            ar(opcion) = yy
        Next
        Return ar
    End Function
    Function cuantos(ByVal cadena As String, ByVal caracter As String) As Integer
        ' Cuenta nº de veces que aparece caracter dentro de cadena
        Dim i As Integer
        Dim num As Integer = 0
        For i = 1 To Len(cadena)
            If Mid(cadena, i, 1) = caracter Then num = num + 1
        Next
        Return num
    End Function
    Sub main()


        Dim xy As New ClasesGesHotel.geshotel.GesHotelClase(1)
        'xy.EmailTraducido(141749, "EMAIL_HOTEL_CREATED_BOOKING", False, False)
        'xy.getBono("moreau", 119, "2015-04-23")
        'xy.generarFicherosBavelHotel(4)
        Dim hotel As Integer
        For hotel = 1 To 4
            'xy.genera_usuarios_radius(hotel, "2015-05-07")
        Next hotel
        Dim desde As Date = "2015-06-09"
        'xy.CrearFicheroPolicia("2015-04-30", 3)
        'xy.reviewpro(desde, 1)
        'xy.ObtienePlanningDiario(2, desde, "2015-06-10", 0, 0, 1)
        'xy.generaFicheroBavel(325654)
        'Console.ReadKey()
        xy.ImportarReservasDingus(4)
        End

        Dim dt As Date = Now
        Dim str As String = "O. NIKLAS INF 18 MONTH *F11 /M. BREAKFAST /A. 41146 BABY CHAIR  NNNJ /A. 41148 BABY TROLLEY  NNNJ /A. 42330 BAMSE 3-5 ÅR/5 DAGAR 130212-130219 NNJN /A. 22269 GUIDE ONLINE SERVICE TI 130212    0 JJNN /A. 50004 KLIMATBIDRAG  JJJJ /A. 99999 TRANSFER . JJJJ /"
        str = Trim(str)
        Dim trolley As String = "BABY CHAIR"
        Dim pos = str.IndexOf(trolley)

        If pos <> -1 Then ' Encontrado
            str = Mid(str, pos + 1, 18)
            Dim frase = str.Split(" ")
            Dim turron As String = frase(2)
            Dim cantidad As Integer = cuantos(turron, "J")
        End If
        Dim s_ticket_id As String = "1234,4567,8901"
        Dim tabla = s_ticket_id.Split(",")
        s_ticket_id = tabla(tabla.length - 1)
        Dim bono = "763033//1234"
        pos = bono.IndexOf("//")
        If pos <> -1 Then
            bono = bono.Split("//", 2, CompareMethod.Text)(0)
        End If
        Dim numero As Integer
        For pos = 1 To 4
            numero = CInt(Math.Floor((9999 - 1000 + 1) * Rnd())) + 1000
        Next

        Dim fecha As Date = "02/03/2015"
        Dim hotel_id As Integer = 3
        Dim x As New ClasesGesHotel.geshotel.GesHotelClase(1)
        'x.getNodi("jnunez", "246379")
        'x.ImportarReservasDingus(1)
        'End
        'x.telegram_extras_hotel(3, "18/11/2014")
        'x.comprueba_overbooking(129024)
        'x.AsignaHabitacionReserva(133656, 487)
        'Dim puedo As Boolean = x.CambiarEstadoReserva(126099, 3, True)
        Dim hasta As Date = "02/03/2015"
        'End
        While fecha < hasta
            'x.generarTablasPostCierre(hotel_id, fecha)

            Console.WriteLine("Dia=" + CStr(fecha))
            fecha = DateAdd(DateInterval.Day, 1, fecha)
        End While
        x.generarTablasPostCierre(hotel_id, fecha)
        'For hotel_id = 3 To 3
        '    x.generarTablasPostCierre(hotel_id, fecha)
        'Next

        'x.genera_estadisticos_SAP(fecha)
        'x.genera_usuarios_radius(hotel_id, fecha)
        'x.obtieneServiciosReserva(115286)
        'x.carga_xml_de_reserva(115881)
        'x.CompruebaEstadoHabitacion(283, 116773, CDate("22/06/2014"), CDate("03/07/2014"))

        'x.AsignaHabitacionReserva(107312, 300)
        'Dim i As Integer
        'For i = 1 To 4
        'x.genera_estadisticos_SAP(4, fecha)
        'Next i
        'x.CambiarEstadoFactura(274008, 1, False)
        'End
        'x.enviarEmailCreacionReserva(113481)
        'x.EmailTraducido(112529, "EMAIL_CONFIRMATION", True, False)
        'x.genera_manocorriente(hotel_id, fecha)
        'Dim valor = x.Comprueba_tarjeta(74313)
        'x.CambiarEstadoReserva(108106, 5, False)
        'Dim kkk = x.ObtieneLLamadasHotel(1)
        'x.ImportarReservasDingus(2)
        'x.generarEfacturaBavel(213659)
        'Dim kk = x.elimina_clientes_duplicados
        'Dim kk = x.generaFicheroBavel(210600)
        'Dim kk = x.CambiarEstadoReserva(79194, 4, False)
        'Dim kk = x.ObtieneNumeroFactura(115286)
        'Dim ds As DataSet = x.ObtieneLimpiezas(2, fecha, 0, 0, 0)
        'Dim total As Single = x.ObtienePendienteAnticipoReserva(80412)
        'x.obtieneServiciosReserva(58374)
        'x.cambia_situacion_habitacion(108668, 3)
        'End
        'x.crearLineasFacturas(1,,1,

        ' Crear huesped para pruebas
        Dim hus As New ClasesGesHotel.geshotel.GesHotelClase.MetaHuesped
        hus.empresa_id = 1
        ''x.generaFicheroBavel(166673)
        'hus.fecha_llegada = "10/09/2012"
        'hus.fecha_salida = "17/09/2012"
        'hus.fecha_nacimiento = "25/05/1963"
        'hus.nacion_id = 1
        'hus.tipo_documento_id = "d"
        'hus.nif = "42809943C"
        'hus.razon = "Nuñez Casanovas Javier"
        'hus.sexo_id = "V"
        'hus.tipo_huesped_id = 1
        'Dim hues(3) As ClasesGesHotel.geshotel.GesHotelClase.MetaHuesped
        'hues(0) = hus
        'hus.fecha_llegada = ""
        'hus.fecha_nacimiento = ""
        'x.actualizaHuespedesReserva(96005, hues)
        ''crear una metareserva para pruebas
        Dim res As New ClasesGesHotel.geshotel.GesHotelClase.MetaReserva
        res.bono_referencia = "903549 1103187608"
        res.cliente_id = 14744
        res.habitacion_servicio_id = 11
        res.hotel_id = 3
        res.pension_servicio_id = 4
        res.fecha_prevista_llegada = "01/04/2013"
        res.fecha_prevista_salida = "02/04/2013"
        res.fecha_reserva = "20/01/2013"
        res.numero_habitaciones = 1
        Dim uc As ClasesGesHotel.geshotel.GesHotelClase.UCS()
        ReDim uc(1)
        uc(0) = New ClasesGesHotel.geshotel.GesHotelClase.UCS
        uc(0).cantidad = 2
        uc(0).unidad_calculo_id = 2
        uc(1) = New ClasesGesHotel.geshotel.GesHotelClase.UCS
        uc(1).cantidad = 2
        uc(1).unidad_calculo_id = 4
        res.unidades_calculos = uc
        res.canal_reserva_id = 3
        Dim hora = Hour(Today)
        'Dim xx = x.obtieneServiciosReserva(res, True)

        'x.CambiarEstadoReserva(80190, 3, False)

        'Dim hasta As Date = "26/08/2014"
        'Dim hotel_id As Integer = 4
        'Dim kk = x.ObtieneLimpiezas(4, fecha)

        Dim dia As Integer = 0
        Dim any As Integer = Year(Today)
        'Dim fecha As Date = "13/08/2014"
        'While fecha <= hasta
        '    x.generarTablasPostCierre(hotel_id, fecha)

        '    Console.WriteLine("Dia=" + CStr(fecha))
        '    fecha = DateAdd(DateInterval.Day, 1, fecha)
        'End While
        'Dim cipherText As String = "41IoWBPU1uqYVBU7BetD2VnE/c3pgfIcrFD/G5bdKPNvarcQ3k/J16aO8bGzpMbRCzR+gGgVjFYpXm0ezGJ3fbzaJ/e4aSHXavtFG/xZ/u8="
        'Dim retval = (x.decodeStringDingus(cipherText, "1GFG7878DEFSCAFCEC", "18"))
        'Console.WriteLine(x.decodeStringDingus(retval, "1GFG7878DEFSCAFCEC", "18"))
        'Console.WriteLine("fin")
        'Dim plaintext As String


        'Dim numInfo As Double = -8.5799999999999983
        'Dim kk As String = Convert.ToDecimal(numInfo).ToString
        'MsgBox(numInfo)
        'x.obtiene()
        'x.recalculaFactura(253402)

        'x.ColocaEstadoBavel(128328)
        'Dim errorcode = x.regenera_estadisticas_any(1, 2012)
        'errorcode = x.regenera_estadisticas_any(2, 2012)
        'errorcode = x.regenera_estadisticas_any(3, 2012)
        'errorcode = x.regenera_estadisticas_any(4, 2012)
        'x.conformaFactura(180995)
        'x.ObtieneEcolimpiezas(3, "10/10/2013", "18/11/2013", 0)
        'x.generaLineasFacturas("13/09/2014", 4)   ' caza de un cierre mal
        'x.lanza_postcierres()
        'x.CrearCierreContable(fecha, hotel_id)
        'x.crea_descuento_en_reserva(78450)
        'x.crea_descuento_en_reservas_ttoo(14744)
        'x.CambiarEstadoReserva(69069, 4, False)
        'x.obtieneServiciosReserva(30998)
        'x.ImportarReservasDingus(2)
        'x.ImportarReservasDingus(2)
        'x.ImportarReservasDingus(4)
        'x.ImportarReservasDingus(3)

        'x.obtieneServiciosReserva(65486)
        'x.ValidarReserva(45952)
        'Dim res As ClasesGesHotel.geshotel.GesHotelClase.MetaReserva = New ClasesGesHotel.geshotel.GesHotelClase.MetaReserva
        'res.cliente_id = 8382
        'res.bono_referencia = "111"
        'res.fecha_prevista_llegada = "2012-01-19"
        'res.fecha_prevista_salida = "2012-01-23"
        'res.habitacion_servicio_id = 94
        'res.hotel_id = 1
        'res.numero_habitaciones = 1
        'res.pension_servicio_id = 2
        'res.fecha_reserva = "2012-01-19"
        'Dim fec As Date = "8/11/2012"
        'Dim Hotel_id = 2
        'x.crea_descuento_tui_nordic()
        'x.carga_valor_en_reservas(2)
        'Dim total = 100
        'Dim kk = x.cambia_ref1_facturas("Hey Apple hey", 4, fec, 52069, total)
        'Dim kk = x.RecalculaFacturas
        'Dim xx = x.Genera_informe_produccion(Hotel_id, fec)
        'Hotel_id = 3
        'kk = x.genera_manocorriente(Hotel_id, fec)
        'xx = x.Genera_informe_produccion(Hotel_id, fec)

        'Dim hasta As Date = "26/08/2014"
        '     Dim reserva_id = 52919
        '        Dim kk = x.bloqueaHabitacion(487, desde, hasta, False, reserva_id, -1, Nothing, True)

        'Dim fecha As String = fec.ToString("yyyy-MM-dd")

        'Dim factura_id As Integer = 118590
        'Dim kk = x.ColocaEstadoBavel(factura_id)
        '        x.obtieneServiciosReserva(res)
        'x.obtieneServiciosReserva()
        'Console.Write(y)
        'x.reserva_check()
        'x.generarEfacturaBavel(101053)
        '        x.generarFicherosBavelHotel(1)
        '        x.generarFicherosBavelHotel(2)
        '       x.generarFicherosBavelHotel(3)
        '      x.generarFicherosBavelHotel(4)

        'Dim fecha As Date = "03/11/2011"
        'Dim hotel_id As Integer = 2
        'x.generaLineasFacturas(fecha, hotel_id)

        'x.CambiarEstadoReserva(47587, 3, False)
        'x.obtieneServiciosReserva(47589)
        'x.CrearAnticipoReserva(47592, 0)

        'cosas de javier
        '        Dim reserva As New ClasesGesHotel.geshotel.GesHotelClase.MetaReserva
        '        reserva.hotel_id = 2
        '        reserva.numero_habitaciones = 25
        '        reserva.bono_referencia = "55555"
        '        reserva.fecha_prevista_llegada = "01/12/2011"
        '        reserva.fecha_prevista_salida = "04/12/2011"
        '        reserva.cliente_id = 23
        '        reserva.habitacion_servicio_id = 10
        '        reserva.habitacion_id = 1
        'Dim i = x.reserva_check(reserva)
        'hasta aki


        'todo crear campo clientes_hotel.precio_dingus 
        'todo crear campo reservas.reserva_dingus_tipo
        'x.obtieneServiciosReserva(56237)
        'x.ImpotarReservasDingus(2)
        'x.obtieneServiciosReserva(47581)
        'Dim tmp As String = x.generarEfacturaBavel(88225, Nothing, False)
        'tmp = tmp + "."

        'x.ObtienePlanningDiario(2, "2011-03-05", "2011-03-06", 0, 0, 10)

        'x.ObtieneDesglosePensionAgencia(1, "2011-03-01", "2011-03-16")

        'x.CambiarEstadoReserva(40409, 5, False)
        'x.CambiarEstadoCobro(32771, 1, False)


        'x.crearLineasFacturas(39835, 44, 1, 2, "2011-03-21", "2011-03-22")


        'x.obtieneServiciosReserva(39846)
        'x.CambiarEstadoReserva(39830, 3, True)
        'x.ObtienePlanningMensual("02/03/2011", "31/03/2011", 2, 0, 0, Nothing)



        'x.reserva_check(0)

        'x.verifyScan()

        'x.ObtieneLLamadasHotel(1)
        'x.CambiarEstadoReserva(33528, 1, False)
        'x.ProcessarEmailBatch()

        'Console.WriteLine("hits-" & x.cachedHits)
        'Dim xxl As TimeSpan = (Now - dt)
        'Console.WriteLine(xxl.ToString)
        'Console.ReadKey()


        'x.CrearCierreContable("2009-05-27", 2)
        'x.CambiarEstadoCobro(235, 1, False)
        'Console.WriteLine(x.ObtieneFacturasPendientesReserva(46))
        'x.CambiarEstadoReserva(31, 5, True)
        'x.CrearFacturaSencilla(2, 2, 5, "prueba anti", 1, 100)
        'x.CrearFicheroPolicia("2009-05-06", 2)
        End

    End Sub
    Sub Main2()
        'Console.Write(System.Uri.EscapeUriString("hola coño"))



        Dim dia As Date = Date.Parse("1/11/2007")
        'x.CambiarEstadoReserva(3, 1, True)
        Dim y As Integer = 0

        For y = 0 To 500
            ids.Add(1)
        Next
        For y = 0 To 3
            Dim t As Threading.Thread
            t = New Threading.Thread(AddressOf background)
            t.Start()
        Next

        Dim ini As Double = Now.Ticks
        While ids.Count > 0
            Threading.Thread.Sleep(0)
        End While
        ini = Now.Ticks - ini
        Console.WriteLine("fin:" & ini / 10000000)
        Console.ReadKey()
    End Sub
    Private Sub background()
        Dim x As New ClasesGesHotel.geshotel.GesHotelClase(1)
        While ids.Count > 0
            Dim id As Integer = ids(0)
            ids.RemoveAt(0)
            x.obtieneImporteTotalReserva(id)
        End While

    End Sub
End Module

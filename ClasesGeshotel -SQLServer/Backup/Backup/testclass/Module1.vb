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


        Dim Source As New System.Text.StringBuilder
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

    Sub main()
        Dim dt As Date = Now
        Dim x As New ClasesGesHotel.geshotel.GesHotelClase(1)
        Dim res_id As ArrayList = ObtieneReservasHabitacion(Nothing, 2, "2010-05-25", "2010-05-25", 0, True)

        'x.ObtieneErroresReservas("2009-11-26", 3)
        'x.generaLineasFacturas("2010-02-26", 2)
        End
        'Dim em As New System.Net.Mail.MailMessage
        'Dim rb As Byte() = IO.File.ReadAllText("/../Styles/BasicPrint/Style.css")
        'Dim x As Date = CDate("").AddDays(1)
        'x.obtieneImporteTotalReserva(4532, True)
        'x.crearLineasFacturas(9464, 39, 1, 1, "2009-09-24", "2009-09-25")
        'x.obtieneServiciosReserva(9466)
        'x.ObtieneErroresReservas("2009-09-24", 2)
        'x.CambiarEstadoReserva(7017, 4, False)
        'Dim y As Integer
        'For y = 7000 To 8400
        'Console.WriteLine(y)
        'x.obtieneServiciosReserva(y)
        'Next

        'x.crearLineasFacturas(5675, 31, 1, 1, "2009-09-03", "2009-09-09")

        'x.CambiarEstadoReserva(7336, 2, False)
        'x.ObtieneErroresReservas("2009-08-17", 2)
        'x.ObtieneDesglosePensionAgencia(2, "2009-08-01", "2009-08-13")
        'x.ObtienePlanningDiario(2, "2009-08-01", "2009-08-13", 0, 0, 0)
        'x.ObtienePlanningMensual(2, 2009, 8, 0, 0)
        'x.CompruebaEstadoHabitacion(7895)
        'x.obtieneImporteTotalReserva(7331)
        'x.obtieneImportePendienteFacturas(7331, True)
        'x.obtieneListaServiciosValida(7331)

        'x.ObtieneFacturasPendientesReserva(7331, True)
        'x.CambiarEstadoReserva(7331, 2, True)
        'x.CambiarEstadoReserva(7331, 3, True)
        'x.CambiarEstadoReserva(7331, 4, True)
        'x.CambiarEstadoReserva(7331, 5, True)
        'x.generaLineasFacturas("2009-07-09", 2)
        'x.BorrarOferta(1119)
        'x.cobrarFactura("6841,6839,6838,6840".Split(","), 338, 1, True, -20)
        'x.obtieneImporteTotalReserva(6923)
        'x.AnularCobro(2505)
        'x.obtienenLimpiezas(2, "2009-07-27", 0)
        'Dim cenclase = New ClasesGesHotel.Centralita()
        'Dim cenlla As ClasesGesHotel.Centralita.Llamada() = cenclase.procesFicheroLlamadas("D:/LLAMADAS.DAT")
        'x.ObtieneLLamadasHotel(2)

        'x.regenerarLineasFacturasReserva(6602)
        'x.generaLineasFacturas("2009-07-15", 2)
        'x.CambiarEstadoCobro(1862, 1, False)
        'Dim kol As String = ""
        'kol.Replace("{SQL_OrderBy}", "")
        'x.generaLineasFacturas("2009-06-29", 2)
        'x.obtienenLimpiezas(2, "2009-06-30", 0)
        'x.obtieneImportePendienteFacturas(5000)
        'x.generarPreCheckoutsHotel(2)

        'x.CambiarEstadoReserva(3000, 5, False)
        'x.obtieneImporteTotalReserva(5468, True)
        'x.ObtieneErroresReservas("2009-06-25", 2)
        'x.ObtienePlanningDiario(2, "2009-06-25", "2009-07-15", 1, 1, 1)
        'x.CambiarEstadoReserva(5252, 3, False)
        'x.crearLineasFacturas(4351, 39, 1, 1, "2009-06-21", "2009-06-22")
        'Console.WriteLine(x.ObtienePendienteAnticipoReserva(4317))
        'x.CambiarEstadoReserva(2460, 5, False)
        'x.cobrarFactura("2884,2735,2783".Split(","), 839, 1, True, 40)
        'x.obtieneImporteTotalReserva(5723)
        'Console.WriteLine(x.obtieneImportePendienteFacturas(4351, True, True))
        'x.obtienenLimpiezas(2, "2009-06-19", 0)
        'x.generaLineasFacturas("2009-06-09", 2)
        'x.CrearCierres(2, 2009)
        'x.CambiarEstadoReserva(2472, 5, False)
        'Dim xx As ClasesGesHotel.tablaServicios = x.obtieneServiciosReserva(3510)
        'x.generaAjuste(3510, xx)

        'Dim ser As ClasesGesHotel.tablaServicios
        'ser = x.obtieneServiciosReserva(2414)
        'Console.WriteLine(ser.sumaImporte())
        'Console.WriteLine(ser.sumaProduccion())
        'x.generaLineasFacturas("2009-05-31", 2)
        'x.CambiarEstadoCobro(234, 1, False)

        'x.crearLineasFacturas(3570, 31, 1, -1)


        'x.obtienenLimpiezas(2, "2009-06-02", 0, 0, 0, 1, 999)

        Console.WriteLine("hits-" & x.cachedHits)
        Dim xxl As TimeSpan = (Now - dt)
        Console.WriteLine(xxl.ToString)
        Console.ReadKey()


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

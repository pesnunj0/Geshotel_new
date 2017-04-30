Imports System.Collections.Generic

Namespace geshotel
    Public Class FicheroContabilidad
        'constructor
        Private nombreFichero As String
        Private rutaFichero As String
        Private rutaFicheroBackup As String
        Private lineasFichero As LinkedList(Of String) = New LinkedList(Of String)
        Private lineasFicheroCache As LinkedList(Of String) = New LinkedList(Of String)
        'Private ultimoacu As ArrayList
        Private fechaMax As Date = "1/1/1900"
        Public CuentasImpuestos As Hashtable = New Hashtable()
        Public CuentasImpuestosIRPF As Hashtable = New Hashtable()
        Public rutas(2) As String
        Private Function plainText(ByVal str As String) As String
            Dim neostr As Char() = str
            Dim x As Integer
            For x = 0 To neostr.Length - 1
                If Char.IsControl(neostr(x)) Then
                    neostr(x) = " "
                End If
            Next
            Return neostr
        End Function

        Public Function NumeroLineas()
            Return lineasFichero.Count
        End Function
        Public Class BaseCCI
            Private TotalesImpuestos As Hashtable = New Hashtable()
            Private TotalesBases As Hashtable = New Hashtable()
            Public CuentasImpuestos As Hashtable = New Hashtable()
            Public Total As Decimal
            Public TotalCuota As Decimal
            Public tipo As Integer
            Sub New(ByVal vtipo)
                tipo = vtipo
            End Sub
            Function agregaImpuesto(ByVal porcentaje As Decimal, ByVal base As Decimal, ByVal cuenta As String)
                'todo round
                CuentasImpuestos(porcentaje) = cuenta
                If tipo = 0 Then
                    Dim antbase As Decimal = TotalesBases.Item(porcentaje)
                    antbase += base
                    Total += base
                    TotalesBases.Item(porcentaje) = antbase
                    Dim cuota As Decimal
                    cuota = Decimal.Round(((porcentaje * base) / 100), 2)
                    Dim ant As Decimal = TotalesImpuestos.Item(porcentaje)
                    ant += cuota
                    Total += cuota
                    TotalCuota += cuota
                    TotalesImpuestos.Item(porcentaje) = ant
                    Return cuota
                End If
                If tipo = 1 Then
                    Dim antbase As Decimal = TotalesBases.Item(porcentaje)
                    antbase += base
                    Total += base
                    TotalesBases.Item(porcentaje) = antbase
                    Dim cuota As Decimal = 0
                    'cuota = Decimal.Round(((porcentaje * base) / 100), 2)
                    Dim ant As Decimal = TotalesImpuestos.Item(porcentaje)
                    ant += cuota
                    Total += cuota
                    TotalCuota += cuota
                    TotalesImpuestos.Item(porcentaje) = ant
                    Return base
                End If
                Return 0
            End Function
            Function obtieneImpuestos()
                Dim ar As New ArrayList
                Dim enu As IEnumerator = TotalesBases.Keys.GetEnumerator
                While enu.MoveNext
                    Dim ar1 As New ArrayList
                    If tipo = 0 Then
                        ar1.Add(TotalesBases.Item(enu.Current))
                        ar1.Add(enu.Current)
                        ar1.Add(TotalesImpuestos.Item(enu.Current))
                        ar.Add(ar1)
                    End If
                    If tipo = 1 Then
                        ' BI=Precio/(1+(IGIC/100))
                        ar1.Add(Math.Round(TotalesBases.Item(enu.Current) / (1 + (enu.Current / 100)), 2))
                        ar1.Add(enu.Current)
                        ar1.Add(TotalesBases.Item(enu.Current) - (Math.Round(TotalesBases.Item(enu.Current) / (1 + (enu.Current / 100)), 2)))
                        ar1.Add(CuentasImpuestos(enu.Current))
                        ar.Add(ar1)
                    End If
                End While

                Return ar
            End Function
            Function sumaBases() As Decimal
                Dim bases As Decimal = 0
                Dim ar As ArrayList = obtieneImpuestos()
                Dim enu As IEnumerator = ar.GetEnumerator
                While enu.MoveNext
                    ar = enu.Current
                    bases += ar(0)
                End While
                Return bases
            End Function
            Function sumaCuotas(ByVal porc As Decimal) As Decimal
                Dim bases As Decimal = 0
                Dim ar As ArrayList = obtieneImpuestos()
                Dim enu As IEnumerator = ar.GetEnumerator
                While enu.MoveNext
                    ar = enu.Current
                    If ar(1) = porc Then
                        bases += ar(0)
                    End If
                End While
                Return bases
            End Function
        End Class

        Public Function FicheroContabilidad(ByVal ruta As String, ByVal rutabackup As String, ByVal empresa As String, ByVal ejercicio As String, ByVal hotel_id As Integer, ByVal programa As String)
            rutaFichero = ruta
            rutaFicheroBackup = rutabackup
            nombreFichero = "G" + empresa.PadLeft(3, "0") + ejercicio.PadLeft(2, "0") + CStr(hotel_id).PadLeft(3, "0") + "E2.DAT"
            Dim sb As Text.StringBuilder = New Text.StringBuilder
            sb.AppendFormat("00GESCONTW{0,-40}000", programa)
            lineasFichero.AddLast(sb.ToString)
            Return True
        End Function
        Public Function FicheroContabilidad(ByVal ruta As String, ByVal rutabackup As String, ByVal empresa As String, ByVal hotel_id As Integer, ByVal ejercicio As String)
            Return FicheroContabilidad(ruta, rutabackup, empresa, ejercicio, hotel_id, "Facturacion")
        End Function
        Private Function obtieneImporteCCI(ByVal importeEnt As Decimal, ByVal ancho As Integer, ByVal signo As Boolean)
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
        Private Function tamMaximo(ByVal str As String, ByVal max As Integer)
            If str.Length < max Then
                Return str
            Else
                Return str.Substring(0, max)
            End If
        End Function
        Function agregarApunte(ByVal TipoApunte As String, ByVal DebeHaber As Char, ByVal fechaDoc As Date, ByVal numeroDocumento As String, ByVal departamento As String, ByVal numeroCuenta As String, ByVal Descripcion As String, ByVal importeEnt As Decimal, Optional ByVal cachea As Boolean = False)
            Return agregarApunte(TipoApunte, DebeHaber, fechaDoc, numeroDocumento, departamento, numeroCuenta, Descripcion, importeEnt, 0, cachea)
        End Function
        Function agregarApunte(ByVal TipoApunte As String, ByVal DebeHaber As Char, ByVal fechaDoc As Date, ByVal numeroDocumento As String, ByVal departamento As String, ByVal numeroCuenta As String, ByVal Descripcion As String, ByVal importeEnt As Decimal, ByVal Posicion As Integer, Optional ByVal cachea As Boolean = False)
            If importeEnt <> 0 Then
                If fechaDoc > fechaMax Then
                    fechaMax = fechaDoc
                End If
                Dim importe As String = obtieneImporteCCI(importeEnt, 18, True)
                Dim fechaDocumento = fechaDoc.ToString("ddMMyyyy")
                Dim concepto As String = "000"
                Dim departamento_contra As String = "000"
                Dim ncuenta_contra As String = ""
                Dim concepto_contra As String = "000"
                'Dim fechaAsiento = Date.Parse(Now).ToString("ddMMyyyy")
                Dim fechaAsiento = fechaDoc.ToString("ddMMyyyy")
                numeroDocumento = numeroDocumento.Trim.PadLeft(7, "0")
                departamento = departamento.Trim.PadLeft(3, "0")
                Dim sb As Text.StringBuilder = New Text.StringBuilder
                'TipoApunte = "FACTUR"
                TipoApunte = tamMaximo(TipoApunte, 6)
                sb.AppendFormat("0101{0,-8}{1,-6}{2,-8}{3,-8}{4,-7}{5,-3}{6,-12}{7,-3}{8,-30}{9,-18}{10,-1}{11,-3}{12,-12}{13,-3}", "00000000", TipoApunte, fechaAsiento, fechaDocumento, tamMaximo(numeroDocumento, 7), tamMaximo(departamento, 3), tamMaximo(numeroCuenta, 12), tamMaximo(concepto, 3), tamMaximo(plainText(Descripcion), 30), importe, DebeHaber, tamMaximo(departamento_contra, 3), ncuenta_contra, concepto_contra)

                'Console.WriteLine(sb.ToString())
                Dim lf As LinkedList(Of String) = lineasFichero
                If cachea Then
                    lf = lineasFicheroCache
                End If
                If Posicion = 0 Then
                    lf.AddLast(sb.ToString)
                Else
                    lf.AddAfter(lineasFichero.First, sb.ToString)
                End If
                If Not cachea And lineasFicheroCache.Count > 0 Then
                    'hacer el flush de lo cacheado
                    While lineasFicheroCache.Count > 0
                        lineasFichero.AddLast(lineasFicheroCache.First.Value)
                        lineasFicheroCache.RemoveFirst()
                    End While

                End If
            End If
            Return True
        End Function
        Function agregarFactura(ByVal fechaFac As Date, ByVal serie As String, ByVal numFactura As String, ByVal razonSocial As String, ByVal Nif As String, ByVal cuentaContable As String)
            numFactura = numFactura.Trim.PadLeft(7, "0")
            Dim fechaFactura = fechaFac.ToString("ddMMyyyy")

            Dim numDocumento As String = ""
            Dim sb As Text.StringBuilder = New Text.StringBuilder
            sb.AppendFormat("10P1{0,-8}{1,-2}{2,-7}{3,-7}{4,-10}{5,-40}{6,-12}{7,-12}{8,-1}{9,-1}{10,-1}{11,-5}{12,-6}", fechaFactura, tamMaximo(serie, 2), tamMaximo(numFactura, 7), "0000000", tamMaximo(numDocumento, 10), tamMaximo(plainText(razonSocial), 40), tamMaximo(Nif, 12), tamMaximo(cuentaContable, 12), "O", " ", " ", "00000", "000000")
            lineasFichero.AddLast(sb.ToString)
            Return True
        End Function
        Function preparaBases()
            Return preparaBases(0)
        End Function
        Function preparaBases(ByVal tipo As Integer)
            Return New BaseCCI(tipo)
        End Function
        Function agregaBase(ByVal basec As BaseCCI)
            Dim ar As ArrayList = basec.obtieneImpuestos()
            Dim enu As IEnumerator = ar.GetEnumerator

            While enu.MoveNext
                Dim obj As ArrayList = enu.Current
                If basec.tipo = 1 Then
                    Dim total As Decimal = Me.CuentasImpuestos.Item(obj(3))
                    total += obj(2)
                    CuentasImpuestos.Item(obj(3)) = total
                End If
                Dim baseImponible As String = obtieneImporteCCI(obj(0), 18, True)
                Dim porcImpuesto As String = obtieneImporteCCI(obj(1), 4, False)
                Dim cuota As String = obtieneImporteCCI(obj(2), 18, True)

                Dim porcRecargo As String = obtieneImporteCCI(0, 4, False)
                Dim cuotaRecargo As String = obtieneImporteCCI(0, 18, True)
                Dim sb As Text.StringBuilder = New Text.StringBuilder
                sb.AppendFormat("11{0,-18}{1,-4}{2,-18}{3,-4}{4,-18}", baseImponible, porcImpuesto, cuota, porcRecargo, cuotaRecargo)
                lineasFichero.AddLast(sb.ToString)
            End While

            Return True
        End Function
        Function agregarBases(ByVal basec As BaseCCI, ByVal basei As Decimal, ByVal porcentaje As Decimal, ByVal cuentaIgic As String)
            Dim cuota As Decimal = basec.agregaImpuesto(porcentaje, basei, cuentaIgic)
            If basec.tipo = 0 Then
                Dim total As Decimal = Me.CuentasImpuestos.Item(cuentaIgic)
                total += cuota
                CuentasImpuestos.Item(cuentaIgic) = total
            End If
            Return True
        End Function
        Function agregarBasesIRPF(ByVal basec As BaseCCI, ByVal basei As Decimal, ByVal porcentaje As Decimal, ByVal cuentaIgic As String)
            Dim cuota As Decimal = basec.agregaImpuesto(porcentaje, basei, cuentaIgic)
            If basec.tipo = 0 Then
                Dim total As Decimal = Me.CuentasImpuestosIRPF.Item(cuentaIgic)
                total += cuota
                CuentasImpuestosIRPF.Item(cuentaIgic) = total
            End If
            Return True
        End Function
        Function generaImpuestos(ByVal nombre)
            Dim enu As IEnumerator = CuentasImpuestos.Keys.GetEnumerator()
            While enu.MoveNext
                agregarApunte(nombre, "H", fechaMax, "", "", enu.Current, "General", CuentasImpuestos(enu.Current))
            End While
            enu = CuentasImpuestosIRPF.Keys.GetEnumerator()
            While enu.MoveNext
                If CuentasImpuestosIRPF(enu.Current) <> 0 Then
                    agregarApunte(nombre, "D", fechaMax, "", "", enu.Current, "General", CuentasImpuestosIRPF(enu.Current))
                End If
            End While
            Return True
        End Function
        Function generaImpuestos()
            Return generaImpuestos("FACTUR")
        End Function
        Function generarFichero()
            'componer fichero
            Dim tenum As IEnumerator = lineasFichero.GetEnumerator()
            Dim sb = New Text.StringBuilder
            While (tenum.MoveNext)
                sb.Append(tenum.Current)
                sb.Append(vbCrLf)
            End While
            'Console.WriteLine(sb.ToString)
            Try
                rutas(0) = rutaFichero & nombreFichero
                rutas(1) = rutaFicheroBackup & nombreFichero & Now.ToString("ddMMyyyy-hhmmss")
                My.Computer.FileSystem.WriteAllText(rutas(0), sb.ToString, True, New System.Text.ASCIIEncoding)
                My.Computer.FileSystem.WriteAllText(rutas(1), sb.ToString, False, New System.Text.ASCIIEncoding)
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function
    End Class
End Namespace
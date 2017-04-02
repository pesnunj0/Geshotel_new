Public Class Centralita
    Public Class Llamada
        Public extension As String
        Public fecha_hora As Date
        Public duracion As Date
        Public numero As String
        Public coste As Single
        Public tipo As Integer

    End Class
    Private ficheroABorrar As String = ""
    Private Function GetFileContents(ByVal FullPath As String, ByRef strContents As ArrayList, Optional ByRef ErrInfo As String = "") As ArrayList
        'Dim strContents As New ArrayList
        Dim objReader As IO.StreamReader
        Try
            objReader = New IO.StreamReader(FullPath)
            Dim linea As String
            linea = objReader.ReadLine()
            While Not IsNothing(linea)
                strContents.Add(linea)
                linea = objReader.ReadLine()

            End While
            objReader.Close()
            Return strContents
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
        Return Nothing
    End Function
    Public Function procesFicheroLlamadas(ByVal fichero As String) As Llamada()
        'copiar fichero a backup+date..borrar original
        'procesar backups+dates pendientes
        '
        Dim arrLlamadas As New ArrayList()
        Dim x As Integer
        Dim sErr As String = ""
        Dim lineas As New ArrayList
        GetFileContents(fichero & ".PART", lineas, sErr)
        System.IO.File.Delete(fichero & ".PART")
        Try
            System.IO.File.Move(fichero, fichero & ".PART")
            GetFileContents(fichero & ".PART", lineas, sErr)
        Catch ex As Exception
            'no pudo leer el fichero .dat
        End Try
        'System.IO.File.Delete(fichero & ".PART")
        Dim tenum As IEnumerator = lineas.GetEnumerator()
        Dim sb As Text.StringBuilder = New Text.StringBuilder
        While (tenum.MoveNext)
            sb.Append(tenum.Current)
            sb.Append(vbCrLf)
        End While
        My.Computer.FileSystem.WriteAllText(fichero & ".PART", sb.ToString, False, New System.Text.ASCIIEncoding)
        ficheroABorrar = fichero & ".PART"
        For x = 0 To lineas.Count - 1
            Dim dat As String = lineas(x)
            If dat.Substring(0, 1) = "T" Then
                Dim llam As New Llamada
                llam.extension = Trim(dat.Substring(1, 10))
                llam.fecha_hora = DateTime.ParseExact(Trim(dat.Substring(11, 12)), "yyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture)
                Dim dur As DateTime = DateTime.ParseExact(Trim((dat.Substring(23, 6))), "HHmmss", System.Globalization.CultureInfo.InvariantCulture)
                llam.duracion = dur
                'Console.WriteLine(Trim(dat.Substring(41, 9)))
                llam.coste = CSng(dat.Substring(30, 6))
                llam.numero = Trim(dat.Substring(41))
                llam.tipo = 1   ' Tipo 1 llamada
                arrLlamadas.Add(llam)
            Else
                If dat.Substring(0, 1) = "E" Then  ' Atencion personal de servicio del hotel
                    Dim llam As New Llamada
                    llam.extension = Trim(dat.Substring(1, 10))
                    llam.fecha_hora = DateTime.ParseExact(Trim(dat.Substring(11, 12)), "yyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture)
                    llam.numero = Trim(dat.Substring(41, 6))
                    If llam.numero < 10 Then
                        ' Es que se ha limpiado la habitación pertinente
                        llam.tipo = 2   ' Tipo 2 Servicio
                        arrLlamadas.Add(llam)
                    End If
                    'append al log
                End If
            End If
        Next
        Return CType(arrLlamadas.ToArray(GetType(Llamada)), Llamada())

    End Function
    Public Function FinalizaProcesoLLamadas() As Boolean
        If ficheroABorrar <> "" Then
            Try
                System.IO.File.Delete(ficheroABorrar)
            Catch ex As Exception
                Return False
            End Try
        End If
        Return True
    End Function
    Private salidas As New Hashtable()
    'Private lineas_salida As Text.StringBuilder
    Public Function preparaComandosTelefonos(ByVal ruta As String) As Boolean
        salidas.Add(ruta, New Text.StringBuilder)
        Return True
    End Function
    Public Function agregaComandosTelefonos(ByVal ruta As String, ByVal estado As Char, ByVal extension As String, ByVal nombre As String, ByVal extras As String) As Boolean
        Dim lineas_salida As Text.StringBuilder = salidas(ruta)
        If IsNothing(lineas_salida) Then
            preparaComandosTelefonos(ruta)
            lineas_salida = salidas(ruta)
        End If
        lineas_salida.AppendFormat("{0,-1}{1,-10}{2,-30}{3,-8}", estado, extension, nombre, extras)
        '        lineas_salida.Append(tmp)
        lineas_salida.Append(vbCrLf)
        Return True
    End Function
    Public Function finalizaComandosTelefonos() As Boolean
        Try
            Dim enu As IEnumerator = salidas.Keys.GetEnumerator()
            While enu.MoveNext
                My.Computer.FileSystem.WriteAllText(enu.Current, salidas(enu.Current).ToString, True, New System.Text.ASCIIEncoding)
            End While

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class

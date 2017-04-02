Imports System.Collections.Generic

Namespace geshotelk
    Public Class FicheroPolicia
        Private nombreFichero As String
        Private rutaFichero As String
        Private rutaFicheroBackup As String
        Private lineasFichero As LinkedList(Of String) = New LinkedList(Of String)
        Private cabecera As String
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
        Function generarFichero()
            'componer fichero
            Dim tenum As IEnumerator = lineasFichero.GetEnumerator()
            Dim sb As New Text.StringBuilder
            cabecera = cabecera & Format(NumeroLineas, "0000")
            sb.Append((cabecera))
            sb.Append(vbCrLf)
            While (tenum.MoveNext)
                sb.Append((tenum.Current))
                sb.Append(vbCrLf)
            End While
            'Console.WriteLine(sb.ToString)
            Try
                rutas(0) = rutaFichero & nombreFichero
                'rutas(1) = rutaFicheroBackup & nombreFichero & Now.ToString("ddMMyyyy-hhmmss")
                My.Computer.FileSystem.WriteAllText(rutas(0), sb.ToString, False, New System.Text.UTF8Encoding)
                'My.Computer.FileSystem.WriteAllText(rutas(1), sb.ToString, False, New System.Text.UTF8Encoding)
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function
        Public Function FicheroPolicia(ByVal nombre As String, ByVal ruta As String, ByVal empresa As String, ByVal contador As Integer)
            rutaFichero = ruta
            'rutaFicheroBackup = rutabackup
            nombreFichero = nombre & "." & Format(contador, "000")
            Dim sb As Text.StringBuilder = New Text.StringBuilder
            Dim fecha = Now()
            cabecera = ("1|" & nombre & "|" & empresa & "|" & Format(fecha, "yyyyMMdd") & "|" & Format(fecha, "HHmm") & "|")
            'lineasFichero.AddLast(sb.ToString)
            Return True
        End Function
        Public Function agregaLinea(ByVal nif As String, ByVal tipo As String, ByVal fecha_doc As Date, ByVal apellido_1 As String, ByVal apellido_2 As String, ByVal nombre As String, ByVal sexo As String, ByVal fecha_nac As Date, ByVal pais As String, ByVal fecha_llegada As Date)
            Dim linea As String = ("2||" & nif & "|" & tipo & "|" & Format(fecha_doc, "yyyyMMdd") & "|" & apellido_1 & "|" & apellido_2 & "|" & nombre & "|" & sexo & "|" & Format(fecha_nac, "yyyyMMdd") & "|" & pais & "|" & Format(fecha_llegada, "yyyyMMdd") & "|")
            lineasFichero.AddLast(linea)
        End Function


    End Class
End Namespace
Imports System.Collections.Generic

Namespace geshotelk
    Public Class FicheroBavel
        Private nombreFichero As String
        Private rutaFichero As String
        Private rutaFicheroBackup As String
        Private lineasFichero As LinkedList(Of String) = New LinkedList(Of String)
        Private cabecera As String
        Public rutas(2) As String
        Public Function NumeroLineas()
            Return lineasFichero.Count
        End Function
        Function generarFichero() As Boolean
            'componer fichero
            Dim tenum As IEnumerator = lineasFichero.GetEnumerator()
            Dim sb As New Text.StringBuilder
            While (tenum.MoveNext)
                sb.Append((tenum.Current))
            End While

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
        Public Function FicheroBavel(ByVal nombre As String, ByVal ruta As String, ByVal factura_id As Integer)
            'Factura_20041223_153423_237867.xml
            rutaFichero = ruta
            'rutaFicheroBackup = rutabackup
            Dim fecha As Date = Now
            nombreFichero = nombre & "_" & fecha.ToString("yyyyMMdd\_hhmmss") & factura_id & ".xml"
            Dim sb As Text.StringBuilder = New Text.StringBuilder

            Return True
        End Function
        Public Function agregaContenido(ByVal contenido As String) As Boolean
            lineasFichero.AddLast(contenido)
            Return True
        End Function


    End Class
End Namespace
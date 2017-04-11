Imports System.Threading
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data
Imports MySql.Data.MySqlClient
Namespace geshotelk
    Partial Public Class GesHotelClase

        Sub fuerzaError()
            'Dim dt As Date = Now
            Dim errorCode As Integer = 0
            Dim cmd As MysqlCommand = prepareConection()
            Dim cmd2 As MysqlCommand = prepareConection()
            errorCode = 1

        End Sub

        Protected Overloads Overrides Sub Finalize()
            MyBase.Finalize()
            'detectar si falta devolver alguna conexion a la bd
            'My.Computer.FileSystem.WriteAllText("C://TEMP//CONLOG.TXT", "Fin clase" & vbNewLine, True, New System.Text.ASCIIEncoding)
            If Not IsNothing(stacksofConnections) Then


                If stacksofConnections.Count <> 0 Then
                    'sacar la funcion ke falta por devolver la conexion
                    'usar el stack trace
                    Dim enu As IEnumerator = stacksofConnections.Keys.GetEnumerator()
                    While enu.MoveNext
                        sendWarnEmail(stacksofConnections(enu.Current))
                    End While

                End If
            End If
            'Console.WriteLine("fin clase")
        End Sub 'Finalize

        Public Sub sendWarnEmail(num)
            My.Computer.FileSystem.WriteAllText("C://TEMP//CONLOG.TXT", "UN ERROR-" & num & vbNewLine, True, New System.Text.ASCIIEncoding)
            If 1 = 0 Then


                Dim message As Net.Mail.MailMessage = New Net.Mail.MailMessage("geshotel@dingus.com", "tanodcr@telefonica.net", "error mysql " & num, "la linea")
                message.IsBodyHtml = True
                Dim client As Net.Mail.SmtpClient = New Net.Mail.SmtpClient("correo")
                'client.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.PickupDirectoryFromIis
                client.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials
                Dim sent As Boolean = False

                Try
                    Dim userState As String = "test message1"
                    client.SendAsync(message, userState)

                    'client.Send(message)
                Catch ex As Exception
                    Console.Write("burgh")
                End Try
            End If
        End Sub

    End Class
End Namespace

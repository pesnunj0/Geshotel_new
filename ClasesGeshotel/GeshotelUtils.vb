Imports geshotel.Data
Imports System.Text.RegularExpressions
Namespace geshotelk
    Public Class GesHotelClaseUtils
        'Public Shared Sub ExcuteMultiple(ByVal action As DataCommand)
        Public Shared Sub ExcuteMultiple(ByVal action As Object)
            Dim query() As String = action.sqlquery.ToString().Split(";")
            If (query.Length > 1) Then
                Dim x As Integer
                For x = 0 To query.Length - 2
                    action.sqlquery = New Text.StringBuilder(query(x))
                    Try
                        action.ExecuteNonQuery()
                    Catch
                    End Try
                Next
                action.sqlquery = New Text.StringBuilder(query(query.Length - 1))
            End If

        End Sub
        'Public Shared Function ObtainLastInsertId(ByVal con As DataAccessObject) As Integer
        Public Shared Function ObtainLastInsertId(ByVal con As Object) As Integer
            Dim sqllastid As String = "SELECT LAST_INSERT_ID()"
            Return con.ExecuteScalar(sqllastid)
        End Function
        Public Shared Function removeFromUrl(ByVal url As String, ByVal toremove As String) As String
            Dim idx As Integer = url.IndexOf(toremove & "=")
            If idx > 0 Then
                url = url.Remove(idx, toremove.Length).Insert(idx, "_removed_")
            End If
            Return url
        End Function

        'Public Shared Sub RedirectLastInsertId(ByVal con As DataAccessObject, ByVal urlvariable As String)
        Public Shared Sub RedirectLastInsertId(ByVal con As Object, ByVal urlvariable As String)
            Dim retval = 0
            Dim sqllastid As String = "SELECT LAST_INSERT_ID()"

            retval = con.ExecuteScalar(sqllastid)
            Dim p As String = ""
            If retval > 0 Then
                p += "&" & urlvariable & "=" & retval
                p = p.Replace("?&", "?")
            End If
            'System.Web.HttpContext.Current.Session("lastid") = p
            'System.Web.HttpContext.Current.Session("lastinsertedid") = retval
        End Sub

        Public Shared Sub PrepareRedirect(ByRef p As String)
            'If Not IsNothing(HttpContext.Current.Items("UpdatePanel")) Then
            '    p += "&FormFilter=" & HttpContext.Current.Items("UpdatePanel")
            '    p = p.Replace("?&", "?")
            'End If
        End Sub
        Public Shared Function resetScriptsPositions(ByVal html As String) As String
            'Console.WriteLine(html.Length)
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
                Dim subs As Integer = 0
                For Each match As Match In Regex.Matches(html, regstring)
                    If Not resultado.ContainsValue(match.Value) Then
                        html = html.Remove(match.Index - subs, match.Length)
                        subs += match.Length
                        'resultado.Add(match.Index, match.Groups(1).Value)
                        Dim ind As Integer = match.Index
                        While resultado.ContainsKey(ind)
                            ind += 1
                        End While
                        resultado.Add(ind, match.Value)
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
    End Class
End Namespace
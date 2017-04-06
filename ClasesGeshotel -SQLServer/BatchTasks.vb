Imports System.Threading
Namespace geshotelk

    Partial Public Class GesHotelClase


        Public Class BatchTasks
            Private Class Task
                Public tocall As Object
                Public functionName As String
                Public parameters() As Object
                Public returnValue As Object
                Public key As Object
                Public exception As Exception

                Public volcarEn As Object
                Public campo As String
            End Class
            Private tareas As New System.Collections.Queue
            Private tareasAcabadas As New Hashtable
            Protected actives As Integer = 0
            Public maxThreads As Integer = 3
            Public Function addTask(ByRef objeto As Object, ByVal funcion As String, ByVal key As Object, ByVal parameters() As Object, Optional ByRef volcaren As Object = Nothing, Optional ByVal campo As String = Nothing)
                Dim x As New Task
                x.tocall = objeto
                x.functionName = funcion
                x.parameters = parameters
                x.key = key
                x.volcarEn = volcaren
                x.campo = campo
                tareas.Enqueue(x)
                actives += 1
                Return x
            End Function
            Private Sub doreflectTask(ByVal state As Object)
                Dim tarea As Task
                Dim listatareas As System.Collections.Queue = state
                While listatareas.Count > 0
                    SyncLock listatareas
                        Try
                            tarea = listatareas.Dequeue
                        Catch ex As Exception
                            tarea = Nothing
                        End Try
                    End SyncLock

                    If Not tarea Is Nothing Then
                        Try
                            Dim mtype As Type = tarea.tocall.GetType()


                            'Dim minfo As System.Reflection.MethodInfo = mtype.GetMethod(tarea.functionName, types)
                            Dim minfo As System.Reflection.MethodInfo = mtype.GetMethod(tarea.functionName, getTypes(tarea.parameters))
                            If Not IsNothing(minfo) Then
                                tarea.returnValue = minfo.Invoke(tarea.tocall, tarea.parameters)
                                'Console.WriteLine(tarea.returnValue)
                                tareasAcabadas(tarea.key) = tarea.returnValue
                                If Not IsNothing(tarea.volcarEn) And Not IsNothing(tarea.campo) Then
                                    SyncLock listatareas
                                        tarea.volcarEn(tarea.campo) = tarea.returnValue
                                    End SyncLock

                                End If
                            End If
                        Catch ex As Exception
                            tarea.returnValue = Nothing
                            tarea.exception = ex
                        Finally
                            SyncLock listatareas
                                actives -= 1
                            End SyncLock
                        End Try
                    End If
                End While

            End Sub
            Public Sub waitForCompletition()
                Dim x As Integer = tareas.Count
                If x > maxThreads Then
                    x = maxThreads
                End If
                While x > 0
                    ThreadPool.QueueUserWorkItem(AddressOf doreflectTask, tareas)
                    x -= 1
                End While
                While actives > 0
                    If tareas.Count > 0 Then
                        doreflectTask(tareas)
                    Else
                        'una forma mas efeciente de esperar a la ultima tarea
                        Thread.Sleep(40)
                    End If
                End While
            End Sub

            Function getResult(ByRef p1 As Object) As Object
                Return tareasAcabadas(p1)
            End Function

            Function getResultQueue() As Collections.Queue
                Dim a(tareasAcabadas.Count) As Object
                tareasAcabadas.CopyTo(a, 0)
                Dim q As New Queue
                Dim b As IEnumerator = a.GetEnumerator()
                While b.MoveNext
                    q.Enqueue(b.Current)
                End While
                Return q
            End Function

            Function getResultHashTable() As Hashtable
                Return tareasAcabadas
            End Function

            Private Function getTypes(ByVal parameters As Object()) As Type()
                Dim types(parameters.Length - 1) As Type
                Dim x As Integer
                For x = 0 To parameters.Length - 1
                    types(x) = parameters(x).GetType
                Next
                Return types
            End Function


        End Class
    End Class

End Namespace
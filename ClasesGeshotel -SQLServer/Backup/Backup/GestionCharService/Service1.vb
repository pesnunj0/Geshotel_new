Public Class Service1

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Agregue el código aquí para iniciar el servicio. Este método debería poner
        ' en movimiento los elementos para que el servicio pueda funcionar.
        Timer1_Tick(Nothing, Nothing)
        Timer1.Enabled = True
    End Sub

    Protected Overrides Sub OnStop()
        ' Agregue el código aquí para realizar cualquier anulación necesaria para detener el servicio.
        Timer1.Enabled = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim x As New ClasesGesHotel.geshotel.GesHotelClase(1)
            x.RefrescaTelefonosHabitaciones()
        Catch ex As Exception
            Dim serName As String = "ServicioGestionChar"
            Dim MyLog As New EventLog() ' create a new event log
            ' Check if the the Event Log Exists
            If Not MyLog.SourceExists(serName) Then
                MyLog.CreateEventSource(serName, serName + " Log") ' Create Log
            End If
            MyLog.Source = serName
            ' Write to the Log
            MyLog.WriteEntry(serName + " Log", "This is log on " & CStr(TimeOfDay), EventLogEntryType.Error)
        End Try
        
    End Sub
End Class

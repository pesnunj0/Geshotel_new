Module Module1

    Sub Main()
        Dim dt As Date = Now
        Try
            'Console.WriteLine("fin")
            Dim x As New ClasesGesHotel.geshotel.GesHotelClase(1)
            x.ObtieneLLamadasHotel(1)
        Catch ex As Exception
            Console.Write(ex.Message)
        End Try

        Try
            'Console.WriteLine("fin")
            Dim x As New ClasesGesHotel.geshotel.GesHotelClase(1)
            x.ObtieneLLamadasHotel(2)
        Catch ex As Exception
            Console.Write(ex.Message)
        End Try
        Try
            'Console.WriteLine("fin")
            Dim x As New ClasesGesHotel.geshotel.GesHotelClase(1)
            x.ObtieneLLamadasHotel(3)
        Catch ex As Exception
            Console.Write(ex.Message)
        End Try
        Try
            'Console.WriteLine("fin")
            Dim x As New ClasesGesHotel.geshotel.GesHotelClase(1)
            x.ObtieneLLamadasHotel(4)
        Catch ex As Exception
            Console.Write(ex.Message)
        End Try
        Try
            'Console.WriteLine("fin")
            Dim x As New ClasesGesHotel.geshotel.GesHotelClase(1)
            x.RefrescaTelefonosHabitaciones()
        Catch ex As Exception
            Console.Write(ex.Message)
        End Try
        Try
            Dim x As New ClasesGesHotel.geshotel.GesHotelClase(1)
            x.ProcessarEmailBatch()
        Catch ex As Exception

        End Try
        Try
            Dim x As New ClasesGesHotel.geshotel.GesHotelClase(1)
            'x.enviarNotificacion("hora:" & Now(), 1, 0) 'abre El google
            x.enviarNotificacionesPendientes() 'Esta se keda!!!

        Catch ex As Exception

        End Try
        Dim xxl As TimeSpan = (Now - dt)
        Console.WriteLine(xxl.ToString)
    End Sub
End Module

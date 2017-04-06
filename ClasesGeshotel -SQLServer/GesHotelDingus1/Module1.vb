Module Module1

    Sub Main()
        Try
            'Console.WriteLine("fin")
            Dim x As New ClasesGesHotel.geshotel.GesHotelClase(1)
            x.ImportarReservasDingus(1)
        Catch ex As Exception
            Console.Write(ex.Message)
        End Try

        Try
            'Console.WriteLine("fin")
            Dim x As New ClasesGesHotel.geshotel.GesHotelClase(2)
            x.ImportarReservasDingus(2)
        Catch ex As Exception
            Console.Write(ex.Message)
        End Try
        Try
            'Console.WriteLine("fin")
            Dim x As New ClasesGesHotel.geshotel.GesHotelClase(3)
            x.ImportarReservasDingus(3)
        Catch ex As Exception
            Console.Write(ex.Message)
        End Try
        Try
            'Console.WriteLine("fin")
            Dim x As New ClasesGesHotel.geshotel.GesHotelClase(4)
            x.ImportarReservasDingus(4)
        Catch ex As Exception
            Console.Write(ex.Message)
        End Try
    End Sub

End Module

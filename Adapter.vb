Module Adapter
    ' Adapter Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/Adapter.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            ' Create adapter and place a request
            Dim target As Target = New Adapter()
            target.Request()
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'Target' class
    Class Target
        Public Overridable Sub Request()
            Console.WriteLine("Called Target Request()")
        End Sub
    End Class

    ' The 'Adapter' class
    Class Adapter
        Inherits Target
        Private _adaptee As New Adaptee()
        Public Overrides Sub Request()
            ' Possibly do some other work
            '  and then call SpecificRequest
            _adaptee.SpecificRequest()
        End Sub
    End Class

    ' The 'Adaptee' class
    Class Adaptee
        Public Sub SpecificRequest()
            Console.WriteLine("Called SpecificRequest()")
        End Sub
    End Class
End Module

Module Proxy
    ' Proxy Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/Proxy.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            ' Create proxy and request a service
            Dim proxy As New Proxy()
            proxy.Request()
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class
    ' The 'Subject' abstract class
    MustInherit Class Subject
        Public MustOverride Sub Request()
    End Class

    ' The 'RealSubject' class
    Class RealSubject
        Inherits Subject
        Public Overrides Sub Request()
            Console.WriteLine("Called RealSubject.Request()")
        End Sub
    End Class

    ' The 'Proxy' class
    Class Proxy
        Inherits Subject
        Private _realSubject As RealSubject
        Public Overrides Sub Request()
            ' Use 'lazy initialization'
            If _realSubject Is Nothing Then
                _realSubject = New RealSubject()
            End If
            _realSubject.Request()
        End Sub
    End Class
End Module

Module Singlton
    ' Singleton Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/Singleton.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            ' Constructor is protected -- cannot use new
            Dim s1 As Singleton = Singleton.Instance()
            Dim s2 As Singleton = Singleton.Instance()
            ' Test for same instance
            If s1 Is s2 Then
                Console.WriteLine("Objects are the same instance")
            End If
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'Singleton' class
    Class Singleton
        Private Shared _instance As Singleton
        ' Constructor is 'protected'
        Protected Sub New()
        End Sub

        Public Shared Function Instance() As Singleton
            ' Uses lazy initialization.
            ' Note: this is not thread safe.
            If _instance Is Nothing Then
                _instance = New Singleton()
            End If
            Return _instance
        End Function
    End Class

End Module


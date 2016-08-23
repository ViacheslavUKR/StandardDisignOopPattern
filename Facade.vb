Module Facade
    ' Facade Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/Facade.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            Dim facade As New Facade()
            facade.MethodA()
            facade.MethodB()
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'Subsystem ClassA' class
    Class SubSystemOne
        Public Sub MethodOne()
            Console.WriteLine(" SubSystemOne Method")
        End Sub
    End Class

    ' The 'Subsystem ClassB' class
    Class SubSystemTwo
        Public Sub MethodTwo()
            Console.WriteLine(" SubSystemTwo Method")
        End Sub
    End Class

    ' The 'Subsystem ClassC' class
    Class SubSystemThree
        Public Sub MethodThree()
            Console.WriteLine(" SubSystemThree Method")
        End Sub
    End Class

    ' The 'Subsystem ClassD' class
    Class SubSystemFour
        Public Sub MethodFour()
            Console.WriteLine(" SubSystemFour Method")
        End Sub
    End Class

    ' The 'Facade' class
    Class Facade
        Private _one As SubSystemOne
        Private _two As SubSystemTwo
        Private _three As SubSystemThree
        Private _four As SubSystemFour
        Public Sub New()
            _one = New SubSystemOne()
            _two = New SubSystemTwo()
            _three = New SubSystemThree()
            _four = New SubSystemFour()
        End Sub
        Public Sub MethodA()
            Console.WriteLine(vbLf & "MethodA() ---- ")
            _one.MethodOne()
            _two.MethodTwo()
            _four.MethodFour()
        End Sub
        Public Sub MethodB()
            Console.WriteLine(vbLf & "MethodB() ---- ")
            _two.MethodTwo()
            _three.MethodThree()
        End Sub
    End Class
End Module

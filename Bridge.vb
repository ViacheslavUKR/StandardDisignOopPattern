Module Bridge
    ' Bridge Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/Bridge.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            Dim ab As Abstraction = New RefinedAbstraction()
            ' Set implementation and call
            ab.Implementor = New ConcreteImplementorA()
            ab.Operation()
            ' Change implemention and call
            ab.Implementor = New ConcreteImplementorB()
            ab.Operation()
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'Abstraction' class
    Class Abstraction
        Protected _implementor As Implementor
        ' Property
        Public WriteOnly Property Implementor() As Implementor
            Set(value As Implementor)
                _implementor = value
            End Set
        End Property
        Public Overridable Sub Operation()
            _implementor.Operation()
        End Sub
    End Class
    ' The 'Implementor' abstract class
    MustInherit Class Implementor
        Public MustOverride Sub Operation()
    End Class

    ' The 'RefinedAbstraction' class
    Class RefinedAbstraction
        Inherits Abstraction
        Public Overrides Sub Operation()
            _implementor.Operation()
        End Sub
    End Class

    ' The 'ConcreteImplementorA' class
    Class ConcreteImplementorA
        Inherits Implementor
        Public Overrides Sub Operation()
            Console.WriteLine("ConcreteImplementorA Operation")
        End Sub
    End Class

    ' The 'ConcreteImplementorB' class
    Class ConcreteImplementorB
        Inherits Implementor
        Public Overrides Sub Operation()
            Console.WriteLine("ConcreteImplementorB Operation")
        End Sub
    End Class
End Module

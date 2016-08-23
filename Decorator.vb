Module Decorator
    ' Decorator Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/Decorator.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            ' Create ConcreteComponent and two Decorators
            Dim c As New ConcreteComponent()
            Dim d1 As New ConcreteDecoratorA()
            Dim d2 As New ConcreteDecoratorB()
            ' Link decorators
            d1.SetComponent(c)
            d2.SetComponent(d1)
            d2.Operation()
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'Component' abstract class
    MustInherit Class Component
        Public MustOverride Sub Operation()
    End Class

    ' The 'ConcreteComponent' class
    Class ConcreteComponent
        Inherits Component
        Public Overrides Sub Operation()
            Console.WriteLine("ConcreteComponent.Operation()")
        End Sub
    End Class

    ' The 'Decorator' abstract class
    MustInherit Class Decorator
        Inherits Component
        Protected component As Component
        Public Sub SetComponent(component As Component)
            Me.component = component
        End Sub
        Public Overrides Sub Operation()
            If component IsNot Nothing Then
                component.Operation()
            End If
        End Sub
    End Class

    ' The 'ConcreteDecoratorA' class
    Class ConcreteDecoratorA
        Inherits Decorator
        Public Overrides Sub Operation()
            MyBase.Operation()
            Console.WriteLine("ConcreteDecoratorA.Operation()")
        End Sub
    End Class

    ' The 'ConcreteDecoratorB' class
    Class ConcreteDecoratorB
        Inherits Decorator
        Public Overrides Sub Operation()
            MyBase.Operation()
            AddedBehavior()
            Console.WriteLine("ConcreteDecoratorB.Operation()")
        End Sub
        Private Sub AddedBehavior()
        End Sub
    End Class
End Module

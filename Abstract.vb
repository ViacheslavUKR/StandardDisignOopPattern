Module Abstract

    ' Abstract Factory Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/AbstractFactory.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            ' Abstract factory #1
            Dim factory1 As AbstractFactory = New ConcreteFactory1()
            Dim client1 As New Client(factory1)
            client1.Run()
            ' Abstract factory #2
            Dim factory2 As AbstractFactory = New ConcreteFactory2()
            Dim client2 As New Client(factory2)
            client2.Run()
            ' Wait for user input
            Console.ReadKey()
        End Sub
    End Class

    ' The 'AbstractFactory' abstract class
    MustInherit Class AbstractFactory
        Public MustOverride Function CreateProductA() As AbstractProductA
        Public MustOverride Function CreateProductB() As AbstractProductB
    End Class

    ' The 'ConcreteFactory1' class
    Class ConcreteFactory1
        Inherits AbstractFactory
        Public Overrides Function CreateProductA() As AbstractProductA
            Return New ProductA1()
        End Function
        Public Overrides Function CreateProductB() As AbstractProductB
            Return New ProductB1()
        End Function
    End Class

    ' The 'ConcreteFactory2' class
    Class ConcreteFactory2
        Inherits AbstractFactory

        Public Overrides Function CreateProductA() As AbstractProductA
            Return New ProductA2()
        End Function

        Public Overrides Function CreateProductB() As AbstractProductB
            Return New ProductB2()
        End Function
    End Class

    ' The 'AbstractProductA' abstract class
    MustInherit Class AbstractProductA
    End Class

    ' The 'AbstractProductB' abstract class
    MustInherit Class AbstractProductB
        Public MustOverride Sub Interact(a As AbstractProductA)
    End Class

    ' The 'ProductA1' class
    Class ProductA1
        Inherits AbstractProductA
    End Class

    ' The 'ProductB1' class
    Class ProductB1
        Inherits AbstractProductB
        Public Overrides Sub Interact(a As AbstractProductA)
            Console.WriteLine(Me.[GetType]().Name + " interacts with " + a.[GetType]().Name)
        End Sub
    End Class

    ' The 'ProductA2' class
    Class ProductA2
        Inherits AbstractProductA
    End Class

    ' The 'ProductB2' class
    Class ProductB2
        Inherits AbstractProductB
        Public Overrides Sub Interact(a As AbstractProductA)
            Console.WriteLine(Me.[GetType]().Name + " interacts with " + a.[GetType]().Name)
        End Sub
    End Class

    ' The 'Client' class. Interaction environment for the products.
    Class Client
        Private _abstractProductA As AbstractProductA
        Private _abstractProductB As AbstractProductB
        ' Constructor
        Public Sub New(factory As AbstractFactory)
            _abstractProductB = factory.CreateProductB()
            _abstractProductA = factory.CreateProductA()
        End Sub
        Public Sub Run()
            _abstractProductB.Interact(_abstractProductA)
        End Sub
    End Class
End Module
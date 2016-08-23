Module FactotyMethod

    ' Factory Method Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/Factory.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            ' An array of creators
            Dim creators As Creator() = New Creator(1) {}
            creators(0) = New ConcreteCreatorA()
            creators(1) = New ConcreteCreatorB()
            ' Iterate over creators and create products
            For Each creator As Creator In creators
                Dim product As Product1 = creator.FactoryMethod()
                Console.WriteLine("Created {0}", product.[GetType]().Name)
            Next
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'Product' abstract class
    MustInherit Class Product1
    End Class

    ' A 'ConcreteProduct' class
    Class ConcreteProductA
        Inherits Product1
    End Class

    ' A 'ConcreteProduct' class
    Class ConcreteProductB
        Inherits Product1
    End Class

    ' The 'Creator' abstract class
    MustInherit Class Creator
        Public MustOverride Function FactoryMethod() As Product1
    End Class

    ' A 'ConcreteCreator' class
    Class ConcreteCreatorA
        Inherits Creator
        Public Overrides Function FactoryMethod() As Product1
            Return New ConcreteProductA()
        End Function
    End Class

    ' A 'ConcreteCreator' class
    Class ConcreteCreatorB
        Inherits Creator
        Public Overrides Function FactoryMethod() As Product1
            Return New ConcreteProductB()
        End Function
    End Class

End Module
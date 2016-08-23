Module Template
    ' Template Method Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/TemplateMethod.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            Dim aA As AbstractClass = New ConcreteClassA()
            aA.TemplateMethod()
            Dim aB As AbstractClass = New ConcreteClassB()
            aB.TemplateMethod()
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'AbstractClass' abstract class
    MustInherit Class AbstractClass
        Public MustOverride Sub PrimitiveOperation1()
        Public MustOverride Sub PrimitiveOperation2()
        ' The "Template method"
        Public Sub TemplateMethod()
            PrimitiveOperation1()
            PrimitiveOperation2()
            Console.WriteLine("")
        End Sub
    End Class

    ' A 'ConcreteClass' class
    Class ConcreteClassA
        Inherits AbstractClass
        Public Overrides Sub PrimitiveOperation1()
            Console.WriteLine("ConcreteClassA.PrimitiveOperation1()")
        End Sub
        Public Overrides Sub PrimitiveOperation2()
            Console.WriteLine("ConcreteClassA.PrimitiveOperation2()")
        End Sub
    End Class

    ' A 'ConcreteClass' class
    Class ConcreteClassB
        Inherits AbstractClass
        Public Overrides Sub PrimitiveOperation1()
            Console.WriteLine("ConcreteClassB.PrimitiveOperation1()")
        End Sub
        Public Overrides Sub PrimitiveOperation2()
            Console.WriteLine("ConcreteClassB.PrimitiveOperation2()")
        End Sub
    End Class
End Module

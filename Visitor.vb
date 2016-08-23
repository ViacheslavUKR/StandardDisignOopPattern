Module Visitor

    ' Visitor Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/Visitor.htm
    Class MainApp
        Public Shared Sub Main()
            ' Setup structure
            Dim o As New ObjectStructure()
            o.Attach(New ConcreteElementA())
            o.Attach(New ConcreteElementB())
            ' Create visitor objects
            Dim v1 As New ConcreteVisitor1()
            Dim v2 As New ConcreteVisitor2()
            ' Structure accepting visitors
            o.Accept(v1)
            o.Accept(v2)
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'Visitor' abstract class
    MustInherit Class Visitor
        Public MustOverride Sub VisitConcreteElementA(concreteElementA As ConcreteElementA)
        Public MustOverride Sub VisitConcreteElementB(concreteElementB As ConcreteElementB)
    End Class

    ' A 'ConcreteVisitor' class
    Class ConcreteVisitor1
        Inherits Visitor
        Public Overrides Sub VisitConcreteElementA(concreteElementA As ConcreteElementA)
            Console.WriteLine("{0} visited by {1}", concreteElementA.[GetType]().Name, Me.[GetType]().Name)
        End Sub
        Public Overrides Sub VisitConcreteElementB(concreteElementB As ConcreteElementB)
            Console.WriteLine("{0} visited by {1}", concreteElementB.[GetType]().Name, Me.[GetType]().Name)
        End Sub
    End Class

    ' A 'ConcreteVisitor' class
    Class ConcreteVisitor2
        Inherits Visitor
        Public Overrides Sub VisitConcreteElementA(concreteElementA As ConcreteElementA)
            Console.WriteLine("{0} visited by {1}", concreteElementA.[GetType]().Name, Me.[GetType]().Name)
        End Sub
        Public Overrides Sub VisitConcreteElementB(concreteElementB As ConcreteElementB)
            Console.WriteLine("{0} visited by {1}", concreteElementB.[GetType]().Name, Me.[GetType]().Name)
        End Sub
    End Class

    ' The 'Element' abstract class
    MustInherit Class Element
        Public MustOverride Sub Accept(visitor As Visitor)
    End Class

    ' A 'ConcreteElement' class
    Class ConcreteElementA
        Inherits Element
        Public Overrides Sub Accept(visitor As Visitor)
            visitor.VisitConcreteElementA(Me)
        End Sub
        Public Sub OperationA()
        End Sub
    End Class

    ' A 'ConcreteElement' class
    Class ConcreteElementB
        Inherits Element
        Public Overrides Sub Accept(visitor As Visitor)
            visitor.VisitConcreteElementB(Me)
        End Sub
        Public Sub OperationB()
        End Sub
    End Class

    ' The 'ObjectStructure' class
    Class ObjectStructure
        Private _elements As New List(Of Element)()
        Public Sub Attach(element As Element)
            _elements.Add(element)
        End Sub
        Public Sub Detach(element As Element)
            _elements.Remove(element)
        End Sub
        Public Sub Accept(visitor As Visitor)
            For Each element As Element In _elements
                element.Accept(visitor)
            Next
        End Sub
    End Class
End Module

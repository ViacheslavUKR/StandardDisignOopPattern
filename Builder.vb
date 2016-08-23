Module Builder
    ' Builder Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/Builder.htm
    Public Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            ' Create director and builders
            Dim director As New Director()
            Dim b1 As Builder = New ConcreteBuilder1()
            Dim b2 As Builder = New ConcreteBuilder2()
            ' Construct two products
            director.Construct(b1)
            Dim p1 As Product = b1.GetResult()
            p1.Show()
            director.Construct(b2)
            Dim p2 As Product = b2.GetResult()
            p2.Show()
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'Director' class
    Class Director
        ' Builder uses a complex series of steps
        Public Sub Construct(builder As Builder)
            builder.BuildPartA()
            builder.BuildPartB()
        End Sub
    End Class

    ' The 'Builder' abstract class
    MustInherit Class Builder
        Public MustOverride Sub BuildPartA()
        Public MustOverride Sub BuildPartB()
        Public MustOverride Function GetResult() As Product
    End Class

    ' The 'ConcreteBuilder1' class
    Class ConcreteBuilder1
        Inherits Builder
        Private _product As New Product()
        Public Overrides Sub BuildPartA()
            _product.Add("PartA")
        End Sub
        Public Overrides Sub BuildPartB()
            _product.Add("PartB")
        End Sub
        Public Overrides Function GetResult() As Product
            Return _product
        End Function
    End Class

    ' The 'ConcreteBuilder2' class
    Class ConcreteBuilder2
        Inherits Builder
        Private _product As New Product()
        Public Overrides Sub BuildPartA()
            _product.Add("PartX")
        End Sub
        Public Overrides Sub BuildPartB()
            _product.Add("PartY")
        End Sub
        Public Overrides Function GetResult() As Product
            Return _product
        End Function
    End Class

    ' The 'Product' class
    Class Product
        Private _parts As New List(Of String)()
        Public Sub Add(part As String)
            _parts.Add(part)
        End Sub
        Public Sub Show()
            Console.WriteLine(vbLf & "Product Parts -------")
            For Each part As String In _parts
                Console.WriteLine(part)
            Next
        End Sub
    End Class


End Module
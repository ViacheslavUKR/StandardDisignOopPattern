Module Composite
    ' Composite Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/Composite.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            ' Create a tree structure
            Dim root As New Composite("root")
            root.Add(New Leaf("Leaf A"))
            root.Add(New Leaf("Leaf B"))
            Dim comp As New Composite("Composite X")
            comp.Add(New Leaf("Leaf XA"))
            comp.Add(New Leaf("Leaf XB"))
            root.Add(comp)
            root.Add(New Leaf("Leaf C"))
            ' Add and remove a leaf
            Dim leaf As New Leaf("Leaf D")
            root.Add(leaf)
            root.Remove(leaf)
            ' Recursively display tree
            root.Display(1)
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'Component' abstract class
    MustInherit Class Component
        Protected name As String
        ' Constructor
        Public Sub New(name As String)
            Me.name = name
        End Sub
        Public MustOverride Sub Add(c As Component)
        Public MustOverride Sub Remove(c As Component)
        Public MustOverride Sub Display(depth As Integer)
    End Class

    ' The 'Composite' class
    Class Composite
        Inherits Component
        Private _children As New List(Of Component)()
        ' Constructor
        Public Sub New(name As String)
            MyBase.New(name)
        End Sub
        Public Overrides Sub Add(component As Component)
            _children.Add(component)
        End Sub
        Public Overrides Sub Remove(component As Component)
            _children.Remove(component)
        End Sub
        Public Overrides Sub Display(depth As Integer)
            Console.WriteLine(New [String]("-"c, depth) & name)
            ' Recursively display child nodes
            For Each component As Component In _children
                component.Display(depth + 2)
            Next
        End Sub
    End Class

    ' The 'Leaf' class
    Class Leaf
        Inherits Component
        ' Constructor
        Public Sub New(name As String)
            MyBase.New(name)
        End Sub
        Public Overrides Sub Add(c As Component)
            Console.WriteLine("Cannot add to a leaf")
        End Sub
        Public Overrides Sub Remove(c As Component)
            Console.WriteLine("Cannot remove from a leaf")
        End Sub
        Public Overrides Sub Display(depth As Integer)
            Console.WriteLine(New [String]("-"c, depth) & name)
        End Sub
    End Class
End Module

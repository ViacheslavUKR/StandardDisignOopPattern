Module Prototype

    ' Prototype Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/Prototype.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            ' Create two instances and clone each
            Dim p1 As New ConcretePrototype1("I")
            Dim c1 As ConcretePrototype1 = DirectCast(p1.Clone(), ConcretePrototype1)
            Console.WriteLine("Cloned: {0}", c1.Id)
            Dim p2 As New ConcretePrototype2("II")
            Dim c2 As ConcretePrototype2 = DirectCast(p2.Clone(), ConcretePrototype2)
            Console.WriteLine("Cloned: {0}", c2.Id)
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'Prototype' abstract class
    MustInherit Class Prototype
        Private _id As String
        ' Constructor
        Public Sub New(id As String)
            Me._id = id
        End Sub
        ' Gets id
        Public ReadOnly Property Id() As String
            Get
                Return _id
            End Get
        End Property
        Public MustOverride Function Clone() As Prototype
    End Class

    ' A 'ConcretePrototype' class 
    Class ConcretePrototype1
        Inherits Prototype
        ' Constructor
        Public Sub New(id As String)
            MyBase.New(id)
        End Sub
        ' Returns a shallow copy
        Public Overrides Function Clone() As Prototype
            Return DirectCast(Me.MemberwiseClone(), Prototype)
        End Function
    End Class

    ' A 'ConcretePrototype' class 
    Class ConcretePrototype2
        Inherits Prototype
        ' Constructor
        Public Sub New(id As String)
            MyBase.New(id)
        End Sub
        ' Returns a shallow copy
        Public Overrides Function Clone() As Prototype
            Return DirectCast(Me.MemberwiseClone(), Prototype)
        End Function
    End Class
End Module
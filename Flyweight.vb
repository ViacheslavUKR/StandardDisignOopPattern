Module Flyweight
    ' Flyweight Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/Flyweight.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            ' Arbitrary extrinsic state
            Dim extrinsicstate As Integer = 22
            Dim factory As New FlyweightFactory()
            ' Work with different flyweight instances
            Dim fx As Flyweight = factory.GetFlyweight("X")
            extrinsicstate = extrinsicstate - 1
            fx.Operation(extrinsicstate)
            Dim fy As Flyweight = factory.GetFlyweight("Y")
            extrinsicstate = extrinsicstate - 1
            fy.Operation(extrinsicstate)
            Dim fz As Flyweight = factory.GetFlyweight("Z")
            extrinsicstate = extrinsicstate - 1
            fz.Operation(extrinsicstate)
            Dim fu As New UnsharedConcreteFlyweight()
            extrinsicstate = extrinsicstate - 1
            fu.Operation(extrinsicstate)
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'FlyweightFactory' class
    Class FlyweightFactory
        Private flyweights As New Hashtable()
        ' Constructor
        Public Sub New()
            flyweights.Add("X", New ConcreteFlyweight())
            flyweights.Add("Y", New ConcreteFlyweight())
            flyweights.Add("Z", New ConcreteFlyweight())
        End Sub
        Public Function GetFlyweight(key As String) As Flyweight
            Return DirectCast(flyweights(key), Flyweight)
        End Function
    End Class

    ' The 'Flyweight' abstract class
    MustInherit Class Flyweight
        Public MustOverride Sub Operation(extrinsicstate As Integer)
    End Class

    ' The 'ConcreteFlyweight' class
    Class ConcreteFlyweight
        Inherits Flyweight
        Public Overrides Sub Operation(extrinsicstate As Integer)
            Console.WriteLine("ConcreteFlyweight: " & extrinsicstate.ToString)
        End Sub
    End Class

    ' The 'UnsharedConcreteFlyweight' class
    Class UnsharedConcreteFlyweight
        Inherits Flyweight
        Public Overrides Sub Operation(extrinsicstate As Integer)
            Console.WriteLine("UnsharedConcreteFlyweight: " & extrinsicstate.ToString)
        End Sub
    End Class
End Module

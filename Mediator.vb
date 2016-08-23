Module Mediator
    ' MainApp startup class for Structural 
    ' See description in http://www.vb-net.ru/ProgramTheory/Mediator.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            Dim m As New ConcreteMediator()
            Dim c1 As New ConcreteColleague1(m)
            Dim c2 As New ConcreteColleague2(m)
            m.Colleague1 = c1
            m.Colleague2 = c2
            c1.Send("How are you?")
            c2.Send("Fine, thanks")
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'Mediator' abstract class
    MustInherit Class Mediator
        Public MustOverride Sub Send(message As String, colleague As Colleague)
    End Class

    ' The 'ConcreteMediator' class
    Class ConcreteMediator
        Inherits Mediator
        Private _colleague1 As ConcreteColleague1
        Private _colleague2 As ConcreteColleague2
        Public WriteOnly Property Colleague1() As ConcreteColleague1
            Set(value As ConcreteColleague1)
                _colleague1 = value
            End Set
        End Property
        Public WriteOnly Property Colleague2() As ConcreteColleague2
            Set(value As ConcreteColleague2)
                _colleague2 = value
            End Set
        End Property
        Public Overrides Sub Send(message As String, colleague As Colleague)
            If colleague Is _colleague1 Then
                _colleague2.Notify(message)
            Else
                _colleague1.Notify(message)
            End If
        End Sub
    End Class

    ' The 'Colleague' abstract class
    MustInherit Class Colleague
        Protected mediator As Mediator
        ' Constructor
        Public Sub New(mediator As Mediator)
            Me.mediator = mediator
        End Sub
    End Class

    ' A 'ConcreteColleague' class
    Class ConcreteColleague1
        Inherits Colleague
        ' Constructor
        Public Sub New(mediator As Mediator)
            MyBase.New(mediator)
        End Sub
        Public Sub Send(message As String)
            mediator.Send(message, Me)
        End Sub
        Public Sub Notify(message As String)
            Console.WriteLine(Convert.ToString("Colleague1 gets message: ") & message)
        End Sub
    End Class

    ' A 'ConcreteColleague' class
    Class ConcreteColleague2
        Inherits Colleague
        ' Constructor
        Public Sub New(mediator As Mediator)
            MyBase.New(mediator)
        End Sub
        Public Sub Send(message As String)
            mediator.Send(message, Me)
        End Sub
        Public Sub Notify(message As String)
            Console.WriteLine(Convert.ToString("Colleague2 gets message: ") & message)
        End Sub
    End Class
End Module

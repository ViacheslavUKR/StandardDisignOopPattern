Module State
    ' State Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/State.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            ' Setup context in a state
            Dim c As New Context(New ConcreteStateA())
            ' Issue requests, which toggles state
            c.Request()
            c.Request()
            c.Request()
            c.Request()
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'State' abstract class
    MustInherit Class State
        Public MustOverride Sub Handle(context As Context)
    End Class

    ' A 'ConcreteState' class
    Class ConcreteStateA
        Inherits State
        Public Overrides Sub Handle(context As Context)
            context.State = New ConcreteStateB()
        End Sub
    End Class

    ' A 'ConcreteState' class
    Class ConcreteStateB
        Inherits State
        Public Overrides Sub Handle(context As Context)
            context.State = New ConcreteStateA()
        End Sub
    End Class

    ' The 'Context' class
    Class Context
        Private _state As State
        ' Constructor
        Public Sub New(state As State)
            Me.State = state
        End Sub
        ' Gets or sets the state
        Public Property State() As State
            Get
                Return _state
            End Get
            Set(value As State)
                _state = value
                Console.WriteLine("State: " + _state.[GetType]().Name)
            End Set
        End Property
        Public Sub Request()
            _state.Handle(Me)
        End Sub
    End Class
End Module

Module Memento
    ' Memento Design Pattern. 
    ' See description in http://www.vb-net.ru/ProgramTheory/Memento.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            Dim o As New Originator()
            o.State = "On"
            ' Store internal state
            Dim c As New Caretaker()
            c.Memento = o.CreateMemento()
            ' Continue changing originator
            o.State = "Off"
            ' Restore saved state
            o.SetMemento(c.Memento)
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'Originator' class
    Class Originator
        Private _state As String
        ' Property
        Public Property State() As String
            Get
                Return _state
            End Get
            Set(value As String)
                _state = value
                Console.WriteLine(Convert.ToString("State = ") & _state)
            End Set
        End Property
        ' Creates memento 
        Public Function CreateMemento() As Memento
            Return (New Memento(_state))
        End Function
        ' Restores original state
        Public Sub SetMemento(memento As Memento)
            Console.WriteLine("Restoring state...")
            State = memento.State
        End Sub
    End Class

    ' The 'Memento' class
    Class Memento
        Private _state As String
        ' Constructor
        Public Sub New(state As String)
            Me._state = state
        End Sub
        ' Gets or sets state
        Public ReadOnly Property State() As String
            Get
                Return _state
            End Get
        End Property
    End Class

    ' The 'Caretaker' class
    Class Caretaker
        Private _memento As Memento
        ' Gets or sets memento
        Public Property Memento() As Memento
            Get
                Return _memento
            End Get
            Set(value As Memento)
                _memento = value
            End Set
        End Property
    End Class
End Module

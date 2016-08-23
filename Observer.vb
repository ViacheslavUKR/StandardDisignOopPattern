Module Observer
    ' Observer Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/Observer.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            ' Configure Observer pattern
            Dim s As New ConcreteSubject()
            s.Attach(New ConcreteObserver(s, "X"))
            s.Attach(New ConcreteObserver(s, "Y"))
            s.Attach(New ConcreteObserver(s, "Z"))
            ' Change subject and notify observers
            s.SubjectState = "ABC"
            s.Notify()
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'Subject' abstract class
    MustInherit Class Subject
        Private _observers As New List(Of Observer)()
        Public Sub Attach(observer As Observer)
            _observers.Add(observer)
        End Sub
        Public Sub Detach(observer As Observer)
            _observers.Remove(observer)
        End Sub
        Public Sub Notify()
            For Each o As Observer In _observers
                o.Update()
            Next
        End Sub
    End Class

    ' The 'ConcreteSubject' class
    Class ConcreteSubject
        Inherits Subject
        Private _subjectState As String
        ' Gets or sets subject state
        Public Property SubjectState() As String
            Get
                Return _subjectState
            End Get
            Set(value As String)
                _subjectState = value
            End Set
        End Property
    End Class

    ' The 'Observer' abstract class
    MustInherit Class Observer
        Public MustOverride Sub Update()
    End Class

    ' The 'ConcreteObserver' class
    Class ConcreteObserver
        Inherits Observer
        Private _name As String
        Private _observerState As String
        Private _subject As ConcreteSubject
        ' Constructor
        Public Sub New(subject As ConcreteSubject, name As String)
            Me._subject = subject
            Me._name = name
        End Sub
        Public Overrides Sub Update()
            _observerState = _subject.SubjectState
            Console.WriteLine("Observer {0}'s new state is {1}", _name, _observerState)
        End Sub
        ' Gets or sets subject
        Public Property Subject() As ConcreteSubject
            Get
                Return _subject
            End Get
            Set(value As ConcreteSubject)
                _subject = value
            End Set
        End Property
    End Class
End Module

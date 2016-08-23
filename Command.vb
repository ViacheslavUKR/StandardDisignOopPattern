Module Command
    ' Command Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/Command.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            ' Create receiver, command, and invoker
            Dim receiver As New Receiver()
            Dim command As Command = New ConcreteCommand(receiver)
            Dim invoker As New Invoker()
            ' Set and execute command
            invoker.SetCommand(command)
            invoker.ExecuteCommand()
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'Command' abstract class
    MustInherit Class Command
        Protected receiver As Receiver
        ' Constructor
        Public Sub New(receiver As Receiver)
            Me.receiver = receiver
        End Sub
        Public MustOverride Sub Execute()
    End Class

    ' The 'ConcreteCommand' class
    Class ConcreteCommand
        Inherits Command
        ' Constructor
        Public Sub New(receiver As Receiver)
            MyBase.New(receiver)
        End Sub
        Public Overrides Sub Execute()
            receiver.Action()
        End Sub
    End Class

    ' The 'Receiver' class
    Class Receiver
        Public Sub Action()
            Console.WriteLine("Called Receiver.Action()")
        End Sub
    End Class

    ' The 'Invoker' class
    Class Invoker
        Private _command As Command
        Public Sub SetCommand(command As Command)
            Me._command = command
        End Sub
        Public Sub ExecuteCommand()
            _command.Execute()
        End Sub
    End Class
End Module

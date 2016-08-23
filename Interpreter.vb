Module Interpreter
    ' Interpreter Design Pattern. 
    ' See description in http://www.vb-net.ru/ProgramTheory/Interpreter.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            Dim context As New Context()
            ' Usually a tree 
            Dim list As New ArrayList()
            ' Populate 'abstract syntax tree' 
            list.Add(New TerminalExpression())
            list.Add(New NonterminalExpression())
            list.Add(New TerminalExpression())
            list.Add(New TerminalExpression())
            ' Interpret
            For Each exp As AbstractExpression In list
                exp.Interpret(context)
            Next
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'Context' class
    Class Context
    End Class

    ' The 'AbstractExpression' abstract class
    MustInherit Class AbstractExpression
        Public MustOverride Sub Interpret(context As Context)
    End Class

    ' The 'TerminalExpression' class
    Class TerminalExpression
        Inherits AbstractExpression
        Public Overrides Sub Interpret(context As Context)
            Console.WriteLine("Called Terminal.Interpret()")
        End Sub
    End Class

    ' The 'NonterminalExpression' class
    Class NonterminalExpression
        Inherits AbstractExpression
        Public Overrides Sub Interpret(context As Context)
            Console.WriteLine("Called Nonterminal.Interpret()")
        End Sub
    End Class
End Module

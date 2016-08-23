Module ChainOfResp
    ' Chain of Responsibility Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/ChainOfResp.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            ' Setup Chain of Responsibility
            Dim h1 As Handler = New ConcreteHandler1()
            Dim h2 As Handler = New ConcreteHandler2()
            Dim h3 As Handler = New ConcreteHandler3()
            h1.SetSuccessor(h2)
            h2.SetSuccessor(h3)
            ' Generate and process request
            Dim requests As Integer() = {2, 5, 14, 22, 18, 3, 27, 20}
            For Each request As Integer In requests
                h1.HandleRequest(request)
            Next
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'Handler' abstract class
    MustInherit Class Handler
        Protected successor As Handler
        Public Sub SetSuccessor(successor As Handler)
            Me.successor = successor
        End Sub
        Public MustOverride Sub HandleRequest(request As Integer)
    End Class

    ' The 'ConcreteHandler1' class
    Class ConcreteHandler1
        Inherits Handler
        Public Overrides Sub HandleRequest(request As Integer)
            If request >= 0 AndAlso request < 10 Then
                Console.WriteLine("{0} handled request {1}", Me.GetType.Name, request)
            ElseIf successor IsNot Nothing Then
                successor.HandleRequest(request)
            End If
        End Sub
    End Class

    ' The 'ConcreteHandler2' class
    Class ConcreteHandler2
        Inherits Handler
        Public Overrides Sub HandleRequest(request As Integer)
            If request >= 10 AndAlso request < 20 Then
                Console.WriteLine("{0} handled request {1}", Me.GetType.Name, request)
            ElseIf successor IsNot Nothing Then
                successor.HandleRequest(request)
            End If
        End Sub
    End Class

    ' The 'ConcreteHandler3' class
    Class ConcreteHandler3
        Inherits Handler
        Public Overrides Sub HandleRequest(request As Integer)
            If request >= 20 AndAlso request < 30 Then
                Console.WriteLine("{0} handled request {1}", Me.GetType.Name, request)
            ElseIf successor IsNot Nothing Then
                successor.HandleRequest(request)
            End If
        End Sub
    End Class
End Module

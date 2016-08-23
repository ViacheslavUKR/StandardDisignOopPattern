Module Strategy
    ' Strategy Design Pattern.
    ' See description in http://www.vb-net.ru/ProgramTheory/Strategy.htm
    Class MainApp
        ' Entry point into console application.
        Public Shared Sub Main()
            Dim context As Context
            ' Three contexts following different strategies
            context = New Context(New ConcreteStrategyA())
            context.ContextInterface()
            context = New Context(New ConcreteStrategyB())
            context.ContextInterface()
            context = New Context(New ConcreteStrategyC())
            context.ContextInterface()
            ' Wait for user
            Console.ReadKey()
        End Sub
    End Class

    ' The 'Strategy' abstract class
    MustInherit Class Strategy
        Public MustOverride Sub AlgorithmInterface()
    End Class

    ' A 'ConcreteStrategy' class
    Class ConcreteStrategyA
        Inherits Strategy
        Public Overrides Sub AlgorithmInterface()
            Console.WriteLine("Called ConcreteStrategyA.AlgorithmInterface()")
        End Sub
    End Class

    ' A 'ConcreteStrategy' class
    Class ConcreteStrategyB
        Inherits Strategy
        Public Overrides Sub AlgorithmInterface()
            Console.WriteLine("Called ConcreteStrategyB.AlgorithmInterface()")
        End Sub
    End Class

    ' A 'ConcreteStrategy' class
    Class ConcreteStrategyC
        Inherits Strategy
        Public Overrides Sub AlgorithmInterface()
            Console.WriteLine("Called ConcreteStrategyC.AlgorithmInterface()")
        End Sub
    End Class

    ' The 'Context' class
    Class Context
        Private _strategy As Strategy
        ' Constructor
        Public Sub New(strategy As Strategy)
            Me._strategy = strategy
        End Sub
        Public Sub ContextInterface()
            _strategy.AlgorithmInterface()
        End Sub
    End Class
End Module

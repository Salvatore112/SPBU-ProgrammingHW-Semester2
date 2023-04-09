namespace CalculatorSpace;

internal static class FiniteStateMachine
{
    enum States : int
    {
        startState = 0,
        witingForAnOperandStand = 5,
        Automotive = 6,
        Arts = 10,
        BeautyCare = 11,
        Fashion = 15
    }

    private static States currentState = States.startState;
    static int firstOperand;
    static int secondOperand;
    static char Operator;

    public static char Input { get; set; } = '0';
    public static string Output { get; private set; }

    static void IterateFSM()
    {
        switch (currentState)
        {
            case (States.startState):

                break;
        }
    }
}

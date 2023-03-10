namespace StackCalculatorTask;

using System;
using System.Text;

// Class that contains functions to calculate reverse polish notation using stack.
internal class StackCalculator
{
    // Function to calculate reverse polish notation using stack.
    public double Calculate(string expression)
    {
        var Stack = new ListStack();

        foreach (var i in expression.Split(' '))
        {
            switch (i)
            {
                case "+":
                    Stack.Push(Stack.Pop() + Stack.Pop());
                    break;
                case "-":
                    Stack.Push(-Stack.Pop() + Stack.Pop());
                    break;
                case "*":
                    Stack.Push(Stack.Pop() * Stack.Pop());
                    break;
                case "/":
                    double bottomElement = Stack.Pop();
                    double topElement = Stack.Pop();
                    if (Math.Abs(bottomElement) < 0.000001)
                    {
                        throw new DivideByZeroException();
                    }
                    else
                    {
                        Stack.Push(topElement / bottomElement);
                    }
                    break;
                default:
                    Stack.Push(Int32.Parse(i));
                    break;
            }
        }

        return Stack.Peek();
    }

    // Function that tests if calculator works correctly
    public static bool Tests()
    {
        string testExpression1 = "1 2 3 + *";
        double expectedResult1 = 5;
        var calculator1 = new StackCalculator();
        if (expectedResult1 - calculator1.Calculate(testExpression1) >= 0.000001)
        {
            Console.WriteLine("Tests failed on an example expression.");
            return false;
        }

        string testExpression2 = "24 5 -";
        double expectedResult2 = 19;
        var calculator2 = new StackCalculator();
        if (expectedResult2 - calculator2.Calculate(testExpression2) >= 0.000001)
        {
            Console.WriteLine("Tests failed on subtraction.");
            return false;
        }

        string testExpression3 = "12 5 -";
        double expectedResult3 = 2.4;
        var calculator3 = new StackCalculator();
        if (expectedResult3 - calculator3.Calculate(testExpression3) >= 0.000001)
        {
            Console.WriteLine("Tests failed on division.");
            return false;
        }

        string testExpression4 = "1 0 /";
        var calculator4 = new StackCalculator();
        bool DivideByZeroExceptionCaught = false;
        try
        {
            calculator4.Calculate(testExpression4);
        }
        catch (DivideByZeroException) 
        {
            DivideByZeroExceptionCaught = true;
        }
        if (!DivideByZeroExceptionCaught)
        {
            Console.WriteLine("Tests failed to catch DivideByZeroException.");
            return false;
        }

        return true;
    }
}


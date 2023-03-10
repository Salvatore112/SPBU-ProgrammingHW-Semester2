namespace StackCalculatorTask;

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

// Class that contains functions to calculate reverse polish notation using stack.
internal class StackCalculator
{
    // Function to calculate reverse polish notation using stack.
    public double Calculate(string expression, IStack stack)
    {
        foreach (var i in expression.Split(' '))
        {
            switch (i)
            {
                case "+":
                    stack.Push(stack.Pop() + stack.Pop());
                    break;
                case "-":
                    stack.Push(-stack.Pop() + stack.Pop());
                    break;
                case "*":
                    stack.Push(stack.Pop() * stack.Pop());
                    break;
                case "/":
                    double bottomElement = stack.Pop();
                    double topElement = stack.Pop();
                    if (Math.Abs(bottomElement) < 0.000001)
                    {
                        throw new DivideByZeroException();
                    }
                    else
                    {
                        stack.Push(topElement / bottomElement);
                    }
                    break;
                default:
                    stack.Push(Int32.Parse(i));
                    break;
            }
        }

        return stack.Peek();
    }

    // Function that tests if calculator works correctly
    public static bool Tests()
    {
        var testStack1 = new ArrayStack(10);
        string testExpression1 = "1 2 3 + *";
        double expectedResult1 = 5;
        var calculator1 = new StackCalculator();
        if (expectedResult1 - calculator1.Calculate(testExpression1, testStack1) >= 0.000001)
        {
            Console.WriteLine("Tests failed on an example expression.");
            return false;
        }

        var testStack2 = new ArrayStack(10);
        string testExpression2 = "24 5 -";
        double expectedResult2 = 19;
        var calculator2 = new StackCalculator();
        if (expectedResult2 - calculator2.Calculate(testExpression2, testStack2) >= 0.000001)
        {
            Console.WriteLine("Tests failed on subtraction.");
            return false;
        }

        var testStack3 = new ArrayStack(10);
        string testExpression3 = "12 5 -";
        double expectedResult3 = 2.4;
        var calculator3 = new StackCalculator();
        if (expectedResult3 - calculator3.Calculate(testExpression3, testStack3) >= 0.000001)
        {
            Console.WriteLine("Tests failed on division.");
            return false;
        }

        var testStack4 = new ListStack();
        string testExpression4 = "1 0 /";
        var calculator4 = new StackCalculator();
        bool DivideByZeroExceptionCaught = false;
        try
        {
            calculator4.Calculate(testExpression4, testStack4);
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


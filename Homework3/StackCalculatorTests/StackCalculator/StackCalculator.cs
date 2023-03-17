using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("StackCalculatorTask.Tests")]

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
}


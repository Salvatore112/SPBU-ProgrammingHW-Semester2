namespace StackCalculator;

using System;

class Program
{
    static void Main(string[] args)
    {
        if (!ListStack.Tests() || !ArrayStack.Tests() || !StackCalculator.Tests())
        {
            Console.WriteLine("Tests weren't passed");
            
        }
        else
        {
            string expression = "1 2 3 * +";
            var calculator = new StackCalculator();
            double result = calculator.Calculate(expression);
            Console.WriteLine($"Given expression: {expression}");
            Console.WriteLine($"Result: {result}");
        }
    }
    
    // Interface that ListStack and ArrayStack classes implement.
    interface IStack
    {
        void Push(double value);
        double Pop();
        double Peek();
        bool IsEmpty();
        void DisplayStack();
    }
}


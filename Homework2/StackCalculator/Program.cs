using StackCalculatorTask;

if (!ListStack.Tests() || !ArrayStack.Tests() || !StackCalculator.Tests())
{
    Console.WriteLine("Tests weren't passed");
            
}
else
{
    string expression = "1 2 3 * +";
    var stack = new ListStack();
    var calculator = new StackCalculator();
    double result = calculator.Calculate(expression, stack);
    Console.WriteLine($"Given expression: {expression}");
    Console.WriteLine($"Result: {result}");
}
    




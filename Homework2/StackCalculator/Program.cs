using StackCalculatorTask;

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
    




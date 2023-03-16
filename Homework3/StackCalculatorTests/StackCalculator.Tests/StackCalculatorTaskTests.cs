namespace StackCalculatorTask.Tests;

public class StackCalculatorTaskTests
{
    StackCalculator calculator = new StackCalculator();
    
    private static IEnumerable<IStack> stacks
    {
        get
        {
            yield return new ListStack();
            yield return new ArrayStack(20);
        }
    }

    [Test, TestCaseSource(nameof(stacks))]
    public void DevisionByZeroShouldThrowDivideByZeroException(IStack stack)
    {
        string testExpression = "1 0 /";

        Assert.Throws<DivideByZeroException>(() => calculator.Calculate(testExpression, stack));
    }

    [Test, TestCaseSource(nameof(stacks))]
    public void CalculatorShouldCorrectlyWorkWithNegativeValues(IStack stack)
    {
        string testExpression = "-10 -5 -";

        double result = calculator.Calculate(testExpression, stack);

        Assert.That(result + 5 < 0.00001);
    }

    [Test, TestCaseSource(nameof(stacks))]
    public void CalculatorShouldCorrectlyWorkWithPositiveValues(IStack stack)
    {
        string testExpression = "110 5 *";

        double result = calculator.Calculate(testExpression, stack);

        Assert.That(result - 550 < 0.00001);
    }

    [Test, TestCaseSource(nameof(stacks))]
    public void CalculatorShouldThrowFormatExceptionIfNonIntValuesArePassed(IStack stack)
    {
        string testExpression = "2.71 2.5 /";

        Assert.Throws<FormatException>(() => calculator.Calculate(testExpression, stack));
    }

    [Test, TestCaseSource(nameof(stacks))]
    public void CalculatorShouldProduceTheSameResultWithDifferentStacks(IStack stack)
    {
        var testArrayStack = new ArrayStack(10);
        var testListStack = new ListStack();
        string testExpression = "72 34 24 * +";

        Assert.That(calculator.Calculate(testExpression, stack) -
                    calculator.Calculate(testExpression, stack) < 0.00001);
    }

    [Test, TestCaseSource(nameof(stacks))]
    public void MultiplicationByZeroShouldProduceZero(IStack stack)
    {
        var testStack = new ListStack();
        string testExpression = "0 5 *";

        double result = calculator.Calculate(testExpression, stack);

        Assert.That(result < 0.000001);
    }

    [Test, TestCaseSource(nameof(stacks))]
    public void AddingZeroShouldMakeNoDifference(IStack stack)
    {
        var testStack = new ArrayStack(5);
        string testExpression = "0 5 +";

        double result = calculator.Calculate(testExpression, stack);

        Assert.That(result - 5 < 0.000001);
    }
}

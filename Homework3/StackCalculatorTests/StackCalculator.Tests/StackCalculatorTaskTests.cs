namespace StackCalculatorTask.Tests;

public class StackCalculatorTaskTests
{
    StackCalculator calculator = new StackCalculator();

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void DevisionByZeroShouldThrowDivideByZeroException()
    {
        var testStack = new ArrayStack(3);
        string testExpression = "1 0 /";

        Assert.Throws<DivideByZeroException>(() => calculator.Calculate(testExpression, testStack));
    }

    [Test]
    public void CalculatorShouldCorrectlyWorkWithNegativeValues()
    {
        var testStack = new ListStack();
        string testExpression = "-10 -5 -";

        double result = calculator.Calculate(testExpression, testStack);

        Assert.That(result + 5 < 0.00001);
    }

    [Test]
    public void CalculatorShouldCorrectlyWorkWithPositiveValues()
    {
        var testStack = new ArrayStack(3);
        string testExpression = "110 5 *";

        double result = calculator.Calculate(testExpression, testStack);

        Assert.That(result - 550 < 0.00001);
    }

    [Test]
    public void CalculatorShouldThrowFormatExceptionIfNonIntValuesArePassed()
    {
        var testStack = new ListStack();
        string testExpression = "2.71 2.5 /";

        Assert.Throws<FormatException>(() => calculator.Calculate(testExpression, testStack));
    }

    [Test]
    public void CalculatorShouldProduceTheSameResultWithDifferentStacks()
    {
        var testArrayStack = new ArrayStack(10);
        var testListStack = new ListStack();
        string testExpression = "72 34 24 * +";

        Assert.That(calculator.Calculate(testExpression, testListStack) -
                    calculator.Calculate(testExpression, testArrayStack) < 0.00001);
    }

    [Test]
    public void MultiplicationByZeroShouldProduceZero()
    {
        var testStack = new ListStack();
        string testExpression = "5 0 *";

        double result = calculator.Calculate(testExpression, testStack);

        Assert.That(result < 0.000001);
    }

    [Test]
    public void AddingZeroShouldMakeNoDifference()
    {
        var testStack = new ArrayStack(5);
        string testExpression = "0 5 +";

        double result = calculator.Calculate(testExpression, testStack);

        Assert.That(result - 5 < 0.000001);
    }
}

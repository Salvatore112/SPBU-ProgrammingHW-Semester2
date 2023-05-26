using CalculatorSpace;

public class Tests
{
    FiniteStateMachine calculator;

    [SetUp]
    public void Init()
    {
        calculator = new FiniteStateMachine();
    }

    [Test]
    public void AdditionShouldWork()
    {
        calculator.Input = '2';
        calculator.IterateFSM();
        calculator.Input = '+';
        calculator.IterateFSM();
        calculator.Input = '2';
        calculator.IterateFSM();
        calculator.Input = '=';
        calculator.IterateFSM();
        Assert.That(calculator.Output, Is.EqualTo("4"));
    }
    
    [Test]
    public void SubtractionShouldWork()
    {
        calculator.Input = '7';
        calculator.IterateFSM();
        calculator.Input = '-';
        calculator.IterateFSM();
        calculator.Input = '2';
        calculator.IterateFSM();
        calculator.Input = '=';
        calculator.IterateFSM();
        Assert.That(calculator.Output, Is.EqualTo("5"));
    }

    [Test]
    public void MultiplicationShouldWork()
    {
        calculator.Input = '5';
        calculator.IterateFSM();
        calculator.Input = '*';
        calculator.IterateFSM();
        calculator.Input = '5';
        calculator.IterateFSM();
        calculator.Input = '=';
        calculator.IterateFSM();
        Assert.That(calculator.Output, Is.EqualTo("25"));
    }

    [Test]
    public void DivisionShouldWork()
    {
        var calculator = new FiniteStateMachine();
        calculator.Input = '9';
        calculator.IterateFSM();
        calculator.Input = '/';
        calculator.IterateFSM();
        calculator.Input = '3';
        calculator.IterateFSM();
        calculator.Input = '=';
        calculator.IterateFSM();
        Assert.That(calculator.Output, Is.EqualTo("3"));
    }

    [Test]
    public void DivisionByZeroShouldThrowAnError()
    {
        calculator.Input = '1';
        calculator.IterateFSM();
        calculator.Input = '/';
        calculator.IterateFSM();
        calculator.Input = '0';
        calculator.IterateFSM();
        calculator.Input = '=';
        calculator.IterateFSM();
        Assert.That(calculator.Output, Is.EqualTo("Invalid input."));
    }
}
using CalculatorSpace;

public class Tests
{

    [Test]
    public void AdditionShouldWork()
    {
        var calculator = new FiniteStateMachine();
        calculator.Input = '2';
        calculator.IterateFSM();
        calculator.Input = '+';
        calculator.IterateFSM();
        calculator.Input = '2';
        calculator.IterateFSM();
        calculator.Input = '=';
        calculator.IterateFSM();
        Assert.That(calculator.Output == "4");
    }
    
    [Test]
    public void SubtractionShouldWork()
    {
        var calculator = new FiniteStateMachine();
        calculator.Input = '7';
        calculator.IterateFSM();
        calculator.Input = '-';
        calculator.IterateFSM();
        calculator.Input = '2';
        calculator.IterateFSM();
        calculator.Input = '=';
        calculator.IterateFSM();
        Assert.That(calculator.Output == "5");
    }

    [Test]
    public void MultiplicationShouldWork()
    {
        var calculator = new FiniteStateMachine();
        calculator.Input = '5';
        calculator.IterateFSM();
        calculator.Input = '*';
        calculator.IterateFSM();
        calculator.Input = '5';
        calculator.IterateFSM();
        calculator.Input = '=';
        calculator.IterateFSM();
        Assert.That(calculator.Output == "25");
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
        Assert.That(calculator.Output == "3");
    }

    [Test]
    public void DivisionByZeroShouldThrowAnError()
    {
        var calculator = new FiniteStateMachine();
        calculator.Input = '1';
        calculator.IterateFSM();
        calculator.Input = '/';
        calculator.IterateFSM();
        calculator.Input = '0';
        calculator.IterateFSM();
        calculator.Input = '=';
        calculator.IterateFSM();
        Assert.That(calculator.Output == "Invalid input.");
    }
}
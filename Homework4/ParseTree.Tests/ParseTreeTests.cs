namespace ParseTreeSpace.Tests;

public class Tests
{
    ParseTree testTree;

    [SetUp]
    public void Init()
    {
        testTree = new ParseTree();
    }

    [Test]
    public void TreeShouldBeAbleToCalculateExampleExpression()
    {
        string expression = "(* (+ 1 1) 2)";

        Assert.That(testTree.CalculateExpression(expression), Is.EqualTo(4));
        Assert.That(testTree.PrintTree(expression), Is.EqualTo("( * ( + 1 1 ) 2 )"));
    }

    [Test]
    public void MultiplicationByZeroShouldProduceZero()
    {
        string expression = "* 9 0";
        
        Assert.That(testTree.CalculateExpression(expression), Is.EqualTo(0));
        Assert.That(testTree.PrintTree(expression), Is.EqualTo("( * 9 0 )"));
    }

    [Test]
    public void ExpressionWhereBothOperandsAreTreesShouldBeCalculated()
    {
        string expression = "* (+ 3 1) (/ 14 2)";
        Assert.That(testTree.CalculateExpression(expression), Is.EqualTo(28).Within(0.00001));
    }

    [Test]
    public void InvalidCharactersInTheExpressionShouldCauseAnException()
    {
        string expression = "+ a b";
        Assert.Throws<InvalidExpressionException>(() => testTree.CalculateExpression(expression));
    }

    [Test]
    public void ExpressionStartingWithAnOperandShouldBeConsideredInvalid()
    {
        string expression = "5 + 5";
        Assert.Throws<InvalidExpressionException>(() => testTree.CalculateExpression(expression));
    }

    [Test]
    public void ExpressionsWithMissingOperandsShouldCauseAnException()
    {
        string expression = "* 3";
        Assert.Throws<InvalidExpressionException>(() => testTree.CalculateExpression(expression));
    }
}
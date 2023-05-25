namespace ParseTreeSpace.Tests;

public class Tests
{
    ParseTree testTree;

    [SetUp]
    public void Init()
    {
        //testTree = new ParseTree();
    }

    [Test]
    public void TreeShouldBeAbleToCalculateExampleExpression()
    {
        string expression = "(* (+ 1 1) 2)";
        testTree = new ParseTree(expression);

        Assert.That(testTree.CalculateExpression(), Is.EqualTo(4));
        Assert.That(testTree.PrintTree(), Is.EqualTo("( * ( + 1 1 ) 2 )"));
    }

    [Test]
    public void MultiplicationByZeroShouldProduceZero()
    {
        string expression = "* 9 0";
        testTree = new ParseTree(expression);
                
        Assert.That(testTree.CalculateExpression(), Is.EqualTo(0));
        Assert.That(testTree.PrintTree(), Is.EqualTo("( * 9 0 )"));
    }

    [Test]
    public void ExpressionWhereBothOperandsAreTreesShouldBeCalculated()
    {
        string expression = "* (+ 3 1) (/ 14 2)";
        testTree = new ParseTree(expression);
        Assert.That(testTree.CalculateExpression(), Is.EqualTo(28).Within(0.00001));
    }

    [Test]
    public void InvalidCharactersInTheExpressionShouldCauseAnException()
    {
        string expression = "+ a b";
        testTree = new ParseTree(expression);
        Assert.Throws<InvalidExpressionException>(() => testTree.CalculateExpression());
    }

    [Test]
    public void ExpressionStartingWithAnOperandShouldBeConsideredInvalid()
    {
        string expression = "5 + 5";
        testTree = new ParseTree(expression);
        Assert.Throws<InvalidExpressionException>(() => testTree.CalculateExpression());
    }

    [Test]
    public void ExpressionsWithMissingOperandsShouldCauseAnException()
    {
        string expression = "* 3";
        testTree = new ParseTree(expression);
        Assert.Throws<InvalidExpressionException>(() => testTree.CalculateExpression());
    }
}
namespace ParseTreeSpace.Tests;

public class Tests
{
    private static IEnumerable<TestCaseData> Trees
       => new TestCaseData[]
       {
            new TestCaseData(new ParseTree())
       };

    [TestCaseSource(nameof(Trees))]
    public void TreeShouldBeAbleToCalculateExampleExpression(IParseTree tree)
    {
        string expression = "(* (+ 1 1) 2)";
        Assert.That(tree.CalculateExpression(expression) == 4 &&
                    tree.PrintTree(expression) == "( * ( + 1 1 ) 2 )");
    }
    
    [TestCaseSource(nameof(Trees))]
    public void MultiplicationByZeroShouldProduceZero(IParseTree tree)
    {
        string expression = "* 9 0";
        Assert.That(tree.CalculateExpression(expression) < 0.00001 &&
                    tree.PrintTree(expression) == "( * 9 0 )");
    }

    [TestCaseSource(nameof(Trees))]
    public void ExpressionWhereBothOperandsAreTreesShouldBeCalculated(IParseTree tree)
    {
        string expression = "* (+ 3 1) (/ 14 2)";
        Assert.That(tree.CalculateExpression(expression), Is.EqualTo(28).Within(0.00001));
    }

    [TestCaseSource(nameof(Trees))]
    public void InvalidCharactersInTheExpressionShouldCauseAnException(IParseTree tree)
    {
        string expression = "+ a b";
        Assert.Throws<InvalidExpressionException>(() => tree.CalculateExpression(expression));
    }

    [TestCaseSource(nameof(Trees))]
    public void ExpressionStartingWithAnOperandShouldBeConsideredInvalid(IParseTree tree)
    {
        string expression = "5 + 5";
        Assert.Throws<InvalidExpressionException>(() => tree.CalculateExpression(expression));
    }

    [TestCaseSource(nameof(Trees))]
    public void ExpressionsWithMissingOperandsShouldCauseAnException(IParseTree tree)
    {
        string expression = "* 3";
        Assert.Throws<InvalidExpressionException>(() => tree.CalculateExpression(expression));
    }
}
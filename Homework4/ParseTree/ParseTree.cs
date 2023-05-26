using System.Text;

namespace ParseTreeSpace;

/// <inheritdoc cref="IParseTree"/>
internal class ParseTree : IParseTree
{
    private INode? root;
    private string expression;

    internal ParseTree(string exression)
    {
        this.expression = exression;
        int position = 0;
        string[] simplifiedExpression = SimplifyExpression(exression);

        if (!IsOperand(simplifiedExpression[0]))
        {
            throw new InvalidExpressionException("Expression may not start with an operand.");
        }

        if (simplifiedExpression.Length < 3)
        {
            throw new InvalidExpressionException("Expression shoud be at leas 3 characters long.");
        }

        root = BuildParseTreeRecursion(simplifiedExpression, ref position);

        INode BuildParseTreeRecursion(string[] expression, ref int position)
        {
            if (expression[position] is "+" or "-" or "*" or "/")
            {
                position++;
                Operator operatorNode = expression[position - 1] switch
                {
                    "*" => new TimesOperator(BuildParseTreeRecursion(expression, ref position), BuildParseTreeRecursion(expression, ref position)),
                    "+" => new PlusOperator(BuildParseTreeRecursion(expression, ref position), BuildParseTreeRecursion(expression, ref position)),
                    "-" => new MinusOperator(BuildParseTreeRecursion(expression, ref position), BuildParseTreeRecursion(expression, ref position)),
                    "/" => new DivideOperator(BuildParseTreeRecursion(expression, ref position), BuildParseTreeRecursion(expression, ref position)),
                    _ => throw new InvalidExpressionException("")
                };
                return operatorNode;
            }
            else 
            {
                bool isValid = Int32.TryParse(expression[position], out int value);
                if (!isValid)
                {
                    throw new InvalidExpressionException("Only integers may appear");
                }
                position++;
                return new Operand(value);
            }
             
        }
    }

    /// <inheritdoc cref="IParseTree.CalculateExpression"/>
    public double CalculateExpression()
    {
        if (root == null)
        {
            throw new InvalidExpressionException("Expression didn't contain operands or operators.");
        }

        return root.Calculate();
    }

    /// <inheritdoc cref="IParseTree.PrintTree"/>
    public string PrintTree()
    {
        if (root == null)
        {
            throw new InvalidExpressionException("Expression didn't contain operands or operators.");
        }

        return root.Print();
    }

    private string[] SimplifyExpression(string expression)
    {
        var newExpression = new StringBuilder();
        
        foreach (char character in expression)
        {
            if (character != ')' && character != '(') 
            {
                newExpression.Append(character);
            }
        }

        return newExpression.ToString().Split();
    }

    private bool IsOperand(string character)
        => character == "+" || character == "-" || character == "/" || character == "*";
}


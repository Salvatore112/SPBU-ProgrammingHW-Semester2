using System.Text;

namespace ParseTreeSpace;

/// <inheritdoc cref="IParseTree"/>
internal class ParseTree : IParseTree
{
    private INode? root;
    private bool isTreeBuilt = false;

    /// <inheritdoc cref="IParseTree.CalculateExpression"/>
    public double CalculateExpression(string expression)
    {
        if (!isTreeBuilt)
        {
            BuildParseTree(expression);
            isTreeBuilt = true;
        }
        
        if (root == null)
        {
            throw new InvalidExpressionException("Expression didn't contain operands or operators.");
        }

        return root.Calculate();
    }

    /// <inheritdoc cref="IParseTree.PrintTree"/>
    public string PrintTree(string expression)
    {
        if (!isTreeBuilt)
        {
            BuildParseTree(expression);
            isTreeBuilt = true;
        }

        if (root == null)
        {
            throw new InvalidExpressionException("Expression didn't contain operands or operators.");
        }

        return root.Print();
    }

    /// <inheritdoc cref="IParseTree.BuildParseTree"/>
    public void BuildParseTree(string expression)
    {
        int position = 0;
        string[] simplifiedExpression = SimplifyExpression(expression);

        if (!IsOperand(simplifiedExpression[0])) 
        {
            throw new InvalidExpressionException("Expression may not start with an operand.");
        }
        
        if (simplifiedExpression.Length < 3)
        {
            throw new InvalidExpressionException("Expression shoud be at leas 3 characters long.");
        }

        root = BuildParseTreeRecursion(simplifiedExpression, ref position);
    }
    
    private INode BuildParseTreeRecursion(string[] expression, ref int position)
    {
        INode tempNode;
        
        switch (expression[position]) 
        {
            case "*":
                var timesNode = new TimesOperator(BuildParseTreeRecursion(expression, ref position),
                                                  BuildParseTreeRecursion(expression, ref position));
                position++;
                tempNode = timesNode;
                break;
            case "+":
                var plusNode = new PlusOperator(BuildParseTreeRecursion(expression, ref position),
                                                BuildParseTreeRecursion(expression, ref position));
                position++;
                tempNode = plusNode;
                break;
            case "-":
                var minusNode = new PlusOperator(BuildParseTreeRecursion(expression, ref position),
                                                 BuildParseTreeRecursion(expression, ref position));
                position++;
                tempNode = minusNode;
                break;
            case "/":
                var divideNode = new PlusOperator(BuildParseTreeRecursion(expression, ref position),
                                                 BuildParseTreeRecursion(expression, ref position));
                position++;
                tempNode = divideNode;
                break;
            default:
                try
                {
                    double checkValue = Double.Parse(expression[position]);
                }
                catch (FormatException)
                {
                    throw new InvalidExpressionException("Expression may only contain integers, +, -, *, /.");
                }
                position++;
                tempNode = new Operand(Convert.ToInt32(expression[position - 1]));
                break;
        }
        return tempNode;
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

        return newExpression.ToString().Split(null);
    }

    private bool IsOperand(string character)
        => character == "+" || character == "-" || character == "/" || character == "*";
}


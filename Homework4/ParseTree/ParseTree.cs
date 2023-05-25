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
            INode tempNode = null;

            switch (expression[position])
            {
                case "*":
                    var timesNode = new TimesOperator();
                    position++;
                    timesNode.LeftChild = BuildParseTreeRecursion(expression, ref position);
                    timesNode.RightChild = BuildParseTreeRecursion(expression, ref position);
                    tempNode = timesNode;
                    break;
                case "+":
                    var plusNode = new PlusOperator();
                    position++;
                    plusNode.LeftChild = BuildParseTreeRecursion(expression, ref position);
                    plusNode.RightChild = BuildParseTreeRecursion(expression, ref position);
                    tempNode = plusNode;
                    break;
                case "-":
                    var minusNode = new PlusOperator();
                    position++;
                    minusNode.LeftChild = BuildParseTreeRecursion(expression, ref position);
                    minusNode.RightChild = BuildParseTreeRecursion(expression, ref position);
                    tempNode = minusNode;
                    break;
                case "/":
                    var divideNode = new DivideOperator();
                    position++;
                    divideNode.LeftChild = BuildParseTreeRecursion(expression, ref position);
                    divideNode.RightChild = BuildParseTreeRecursion(expression, ref position);
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

        return newExpression.ToString().Split(null);
    }

    private bool IsOperand(string character)
        => character == "+" || character == "-" || character == "/" || character == "*";
}


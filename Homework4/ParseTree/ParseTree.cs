using System.ComponentModel.Design.Serialization;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ParseTreeSpace;

internal class ParseTree
{
    private INode? Root { get; set; }
    private bool IsTreeBuilt { get; set; } = false;

    public double CalculateExpression(string expression)
    {
        if (!IsTreeBuilt)
        {
            BuildParseTree(expression);
            IsTreeBuilt = true;
        }
        
        if (Root == null)
        {
            throw new InvalidExpressionException("Expression didn't contain operands or operators.");
        }

        return Root.Calculate();
    }

    public string PrintTree(string expression)
    {
        if (!IsTreeBuilt)
        {
            BuildParseTree(expression);
            IsTreeBuilt = true;
        }

        if (Root == null)
        {
            throw new InvalidExpressionException("Expression didn't contain operands or operators.");
        }

        return Root.Print();
    }

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

        Root = BuildParseTreeRecursion(simplifiedExpression, ref position);
    }
    
    private INode BuildParseTreeRecursion(string[] expression, ref int position)
    {
        INode tempNode = null;
        
        switch (expression[position]) 
        {
            case "*":
                tempNode = new TimesOperator();
                position++;
                tempNode.LeftChild = BuildParseTreeRecursion(expression, ref position);
                tempNode.RightChild = BuildParseTreeRecursion(expression, ref position);
                break;
            case "+":
                tempNode = new PlusOperator();
                position++;
                tempNode.LeftChild = BuildParseTreeRecursion(expression, ref position);
                tempNode.RightChild = BuildParseTreeRecursion(expression, ref position);
                break;
            case "-":
                tempNode = new MinusOperator();
                position++;
                tempNode.LeftChild = BuildParseTreeRecursion(expression, ref position);
                tempNode.RightChild = BuildParseTreeRecursion(expression, ref position);
                break;
            case "/":
                tempNode = new ObelusOperator();
                position++;
                tempNode.LeftChild = BuildParseTreeRecursion(expression, ref position);
                tempNode.RightChild = BuildParseTreeRecursion(expression, ref position);
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
        var simplifiedExpression = new List<string>();
        foreach (char character in expression)
        {
            if (character == '(' || character == ')' || character == ' ')
            {
                continue;
            }
            else
            {
                simplifiedExpression.Add(character.ToString());
            }
        }
        return simplifiedExpression.ToArray();
    }

    private bool IsOperand(string character)
        => character == "+" || character == "-" || character == "/" || character == "*";
}


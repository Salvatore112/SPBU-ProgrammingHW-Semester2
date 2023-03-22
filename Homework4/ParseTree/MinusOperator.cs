using System.Text;

namespace ParseTreeSpace;

internal class MinusOperator : Operator
{
    public override INode LeftChild { get; set; }
    public override INode RightChild { get; set; }

    public override string Print()
        => $"( - {LeftChild.Print()} {RightChild.Print()} )";

    public override double Calculate()
        => LeftChild.Calculate() - RightChild.Calculate();

    internal MinusOperator(int leftValue, int rightValue)
    {
        this.LeftChild = new Operand(leftValue);
        this.RightChild = new Operand(rightValue);
    }

    internal MinusOperator(INode leftNode, int rightValue)
    {
        this.LeftChild = leftNode;
        this.RightChild = new Operand(rightValue);
    }

    internal MinusOperator(int leftValue, INode rightNode)
    {
        this.LeftChild = new Operand(leftValue);
        this.RightChild = rightNode;
    }

    internal MinusOperator(INode leftNode, INode rightNode)
    {
        this.LeftChild = leftNode;
        this.RightChild = rightNode;
    }

    internal MinusOperator()
    {

    }
}

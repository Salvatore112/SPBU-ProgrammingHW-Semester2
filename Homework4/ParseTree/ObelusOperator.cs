namespace ParseTreeSpace;

internal class ObelusOperator : Operator
{
    public override INode LeftChild { get; set; }
    public override INode RightChild { get; set; }

    public override string Print()
        => $"( / {LeftChild.Print()} {RightChild.Print()} )";

    public override double Calculate()
        => LeftChild.Calculate() / RightChild.Calculate();

    internal ObelusOperator(int leftValue, int rightValue)
    {
        this.LeftChild = new Operand(leftValue);
        this.RightChild = new Operand(rightValue);
    }

    internal ObelusOperator(INode leftNode, int rightValue)
    {
        this.LeftChild = leftNode;
        this.RightChild = new Operand(rightValue);
    }

    internal ObelusOperator(int leftValue, INode rightNode)
    {
        this.LeftChild = new Operand(leftValue);
        this.RightChild = rightNode;
    }

    internal ObelusOperator(INode leftNode, INode rightNode)
    {
        this.LeftChild = leftNode;
        this.RightChild = rightNode;
    }

    internal ObelusOperator()
    {

    }
}

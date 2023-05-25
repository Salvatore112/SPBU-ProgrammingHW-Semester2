using System.Text;

namespace ParseTreeSpace;

/// <inheritdoc cref="INode"/>
internal class MinusOperator : Operator
{
    /// <inheritdoc cref="INode.LeftChild"/>
    public override INode LeftChild { get; }
    
    /// <inheritdoc cref="INode.RightChild"/>
    public override INode RightChild { get; }

    /// <inheritdoc cref="INode.Print"/>
    public override string Print()
        => $"( - {LeftChild.Print()} {RightChild.Print()} )";

    /// <inheritdoc cref="INode.Calculate"/>
    public override double Calculate()
        => LeftChild.Calculate() - RightChild.Calculate();

    internal MinusOperator(INode leftChild, INode rightChild)
    {
        LeftChild = leftChild;
        RightChild = rightChild;
    }
}

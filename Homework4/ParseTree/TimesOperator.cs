namespace ParseTreeSpace;

/// <inheritdoc cref="INode"/>
internal class TimesOperator : Operator
{
    /// <inheritdoc cref="INode.LeftChild"/>
    public INode LeftChild { get; }

    /// <inheritdoc cref="INode.RightChild"/>
    public INode RightChild { get; }

    internal TimesOperator(INode leftChild, INode rightChild)
    {
        LeftChild = leftChild;
        RightChild = rightChild;
    }

    /// <inheritdoc cref="INode.Print"/>
    public override string Print()
        => $"( * {LeftChild.Print()} {RightChild.Print()} )";

    /// <inheritdoc cref="INode.Calculate"/>
    public override double Calculate()
        => LeftChild.Calculate() * RightChild.Calculate();
}

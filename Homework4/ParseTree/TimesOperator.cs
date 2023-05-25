namespace ParseTreeSpace;

/// <inheritdoc cref="INode"/>
internal class TimesOperator : Operator
{
    /// <inheritdoc cref="INode.LeftChild"/>
    public override INode LeftChild { get; }

    /// <inheritdoc cref="INode.RightChild"/>
    public override INode RightChild { get; }

    /// <inheritdoc cref="INode.Print"/>
    public override string Print()
        => $"( * {LeftChild.Print()} {RightChild.Print()} )";

    /// <inheritdoc cref="INode.Calculate"/>
    public override double Calculate()
        => LeftChild.Calculate() * RightChild.Calculate();

    internal TimesOperator(INode leftChild, INode rightChild)
    {
        LeftChild = leftChild;
        RightChild = rightChild;
    }
}

namespace ParseTreeSpace;

/// <inheritdoc cref="INode"/>
internal class TimesOperator : Operator
{
    /// <inheritdoc cref="INode.LeftChild"/>
    public override INode LeftChild { get; set; }

    /// <inheritdoc cref="INode.RightChild"/>
    public override INode RightChild { get; set; }

    /// <inheritdoc cref="INode.Print"/>
    public override string Print()
        => $"( * {LeftChild.Print()} {RightChild.Print()} )";

    /// <inheritdoc cref="INode.Calculate"/>
    public override double Calculate()
        => LeftChild.Calculate() * RightChild.Calculate();
}

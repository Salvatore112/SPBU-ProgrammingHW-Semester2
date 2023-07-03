namespace ParseTreeSpace;

/// <inheritdoc cref="INode"/>
internal abstract class Operator : INode
{
    /// <inheritdoc cref="INode.Print"/>
    public abstract string Print();

    /// <inheritdoc cref="INode.Calculate"/>
    public abstract double Calculate();
}

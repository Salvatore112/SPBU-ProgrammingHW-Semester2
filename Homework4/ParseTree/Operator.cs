namespace ParseTreeSpace;

/// <inheritdoc cref="INode"/>
internal abstract class Operator : INode
{
    /// <inheritdoc cref="INode.LeftChild"/>
    public abstract INode LeftChild { get; }
    
    /// <inheritdoc cref="INode.RightChild"/>
    public abstract INode RightChild { get; }

    /// <inheritdoc cref="INode.Print"/>
    public abstract string Print();

    /// <inheritdoc cref="INode.Calculate"/>
    public abstract double Calculate();
}

namespace ParseTreeSpace;

/// <inheritdoc cref="INode"/>
internal abstract class Operator : INode
{
    /// <inheritdoc cref="INode.LeftChild"/>
    public abstract INode LeftChild { get; set; }
    
    /// <inheritdoc cref="INode.RightChild"/>
    public abstract INode RightChild { get; set; }

    /// <inheritdoc cref="INode.Print"/>
    public abstract string Print();

    /// <inheritdoc cref="INode.Calculate"/>
    public abstract double Calculate();
}

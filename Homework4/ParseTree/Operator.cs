namespace ParseTreeSpace;

internal abstract class Operator : INode
{
    public abstract INode LeftChild { get; set; }
    public abstract INode RightChild { get; set; }

    public abstract string Print();

    public abstract double Calculate();
}

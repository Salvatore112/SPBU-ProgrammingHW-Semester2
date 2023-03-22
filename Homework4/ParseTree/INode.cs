namespace ParseTreeSpace;

internal interface INode
{
    public INode LeftChild { get; set; }
    public INode RightChild { get; set; }

    public string Print();

    public double Calculate();
}

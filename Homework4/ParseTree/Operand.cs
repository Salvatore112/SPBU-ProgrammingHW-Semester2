namespace ParseTreeSpace;

internal class Operand : INode
{
    public INode LeftChild { get; set; }
    public INode RightChild { get; set; }

    public double Value { get; set; }

    public string Print()
        => this.Value.ToString();

    public double Calculate()
        => this.Value;

    internal Operand(int number)
        => this.Value = number;
}

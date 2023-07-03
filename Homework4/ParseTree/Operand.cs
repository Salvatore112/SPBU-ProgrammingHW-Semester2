namespace ParseTreeSpace;

/// <inheritdoc cref="INode"/>
internal class Operand : INode
{
    /// <summary>
    /// Value that an operand holds.
    /// </summary>
    public double Value { get; set; }

    /// <inheritdoc cref="INode.Print"/>
    public string Print()
        => this.Value.ToString();

    /// <inheritdoc cref="INode.Calculate"/>
    public double Calculate()
        => this.Value;

    internal Operand(int number)
        => this.Value = number;
}

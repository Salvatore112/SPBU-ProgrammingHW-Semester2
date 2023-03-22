namespace ParseTreeSpace;

/// <summary>
/// Node used to create parse trees, contains links to left and right children
/// Functions that calculates the current node and print it.
/// </summary>
internal interface INode
{
    /// <summary>
    /// Left child child of a node that may be either an operation or an operand.
    /// </summary>
    public INode LeftChild { get; set; }

    /// <summary>
    /// Right child of a node that may be either an operation or an operand.
    /// </summary>
    public INode RightChild { get; set; }

    /// <summary>
    /// Function that returns a string with a node in the following form :
    /// ( operator operand1 operand2 ).
    /// </summary>
    /// <returns></returns>
    public string Print();

    /// <summary>
    /// Function that calculates this node if it's an operation or returns its
    /// value if it's an operand.
    /// </summary>
    /// <returns></returns>
    public double Calculate();
}

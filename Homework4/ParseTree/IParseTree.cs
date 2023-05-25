namespace ParseTreeSpace;

/// <summary>
/// an ordered, rooted tree that represents the syntactic
/// structure of a string according to some context-free grammar.
/// </summary>
public interface IParseTree
{
    /// <summary>
    /// Function that builds a parse tree  (if it's not already built) and calculates it 
    /// based on a given expression
    /// </summary>
    /// <param name="expression">Only contains integers, -, +, *, /. Must
    /// have the following form: operation operand1 operand2,
    /// where operands may be trees or integers.</param>
    public double CalculateExpression();

    /// <summary>
    /// Function that builds a parse tree  (if it's not already built) and prints it 
    /// based on a given expression
    /// </summary>
    /// <param name="expression">Only contains integers, -, +, *, /. Must
    /// have the following form: operation operand1 operand2,
    /// where operands may be trees or integers.</param>
    public string PrintTree();

    /*/// <summary>
    /// Function that builds a parse tree based on a given expression
    /// </summary>
    /// <param name="expression">Only contains integers, -, +, *, /. Must
    /// have the following form: operation operand1 operand2,
    /// where operands may be trees or integers.</param>
    public void BuildParseTree(string expression);*/
}

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
    /// <returns></returns>
    public double CalculateExpression(string expression);

    /// <summary>
    /// Function that builds a parse tree  (if it's not already built) and prints it 
    /// based on a given expression
    /// </summary>
    /// <param name="expression">Only contains integers, -, +, *, /. Must
    /// have the following form: operation operand1 operand2,
    /// where operands may be trees or integers.</param>
    /// <returns></returns>
    public string PrintTree(string expression);

    /// <summary>
    /// Function that builds a parse tree based on a given expression
    /// </summary>
    /// <param name="expression">Only contains integers, -, +, *, /. Must
    /// have the following form: operation operand1 operand2,
    /// where operands may be trees or integers.</param>
    /// <returns></returns>
    public void BuildParseTree(string expression);
}

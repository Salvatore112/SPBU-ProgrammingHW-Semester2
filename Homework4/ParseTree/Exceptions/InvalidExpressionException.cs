namespace ParseTreeSpace;

/// <summary>
/// Exception that is thrown when you try and enter invalid characters.
/// </summary>
internal class InvalidExpressionException : Exception
{
    internal InvalidExpressionException(string message) : base(message)
    {

    }
}

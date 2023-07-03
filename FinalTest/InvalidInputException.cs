namespace ButtonGame;

/// <summary>
/// Exception that is thrown when user tries to enter an odd number.
/// </summary>
internal class InvalidInputException : Exception
{
    internal InvalidInputException(string message) : base(message)
    {

    }

}
namespace GameSpace;

/// <summary>
/// Exception that is thrown when the map doesn't meet all the requirements.
/// </summary>
internal class InvalidMapException : Exception
{
    internal InvalidMapException(string message) : base(message)
    {

    }
}
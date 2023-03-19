namespace UniqueListSpace.UniqueListExceptions;

/// <summary>
/// An exception that is thrown when a user making a unique list have the same elements through changing its values.
/// </summary>
internal class ListHasTheSameElementException : Exception
{
    internal ListHasTheSameElementException()
    {

    }

    internal ListHasTheSameElementException(string message) 
        : base(message)
    {

    }
}

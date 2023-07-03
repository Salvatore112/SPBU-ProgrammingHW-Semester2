namespace UniqueListSpace.UniqueListExceptions;

/// <summary>
/// An exception that is thrown when a user making a unique list have the same elements through changing its values.
/// </summary>
public class ListHasTheSameElementException : Exception
{
    public ListHasTheSameElementException()
    {

    }

    public ListHasTheSameElementException(string message) 
        : base(message)
    {

    }
}

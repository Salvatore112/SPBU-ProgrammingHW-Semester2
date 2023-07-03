namespace UniqueListSpace;

using UniqueListSpace.UniqueListExceptions;

/// <inheritdoc cref="IMyList"/>
/// <remarks>It may not contain the same elements.</remarks>
internal class UniqueList : MyList
{
    /// <inheritdoc cref="IMyList.AddValue"/>
    /// <exception cref="AddingExistingElementException">Throws an exception if 
    /// there was an attemp to 
    /// add an existent element.</exception>
    public override void AddValue(int value, int position)
    {
        if (ThereIsSuchElement(value))
        {
            throw new AddingExistingElementException();
        }
        base.AddValue(value, position);
    }

    /// <inheritdoc cref="IMyList.ChangeValue"/>
    /// <exception cref="ListHasTheSameElementException">Throws an exception if 
    /// there was an attemp to 
    /// make a unique list have the same elements.</exception>
    public override void ChangeValue(int newValue, int position)
    {
        DeleteValue(position);
        
        if (ThereIsSuchElement(newValue))
        {
            throw new ListHasTheSameElementException("you caused it to have the same elements through changing a value in the list ");
        }

        base.AddValue(newValue, position);
    }
}

namespace MapFilterFold;

/// <summary>
/// Class that contains map, filter, fold functions.
/// </summary>
internal class Functions
{
    /// <summary>
    /// A function that applies a given function to each element of a list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">List to which the given function is applied.</param>
    /// <param name="transformFunction">Function that is aplied to the elements of the list.</param>
    /// <returns>List which elements were changed by the given function</returns>
    public List<U> Map<T, U>(List<T> list, Func<T, U> transformFunction)
    {
        var outputList = new List<U>();
        
        for (int i = 0; i < list.Count; i++)
        {
            outputList.Add(transformFunction(list[i]));
        }

        return outputList;
    }

    /// <summary>
    /// Returns a list of elements for which the given predicate returned true.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list from which you want to take specific elements.</param>
    /// <param name="checkFunction">The predicate according to which you want to take certain elements.</param>
    /// <returns>A list of elements for which the given predicate returned true.</returns>
    public List<T> Filter<T>(List<T> list, Func<T, bool> checkFunction)
    {
        var result = new List<T>();
        
        foreach (T element in list) 
        {
            if (checkFunction(element))
            {
                result.Add(element);
            }
        }
        
        return result;
    }

    /// <summary>
    /// A function that goes through a list accumulating a return value.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the list.</typeparam>
    /// <param name="list">The list through which the function goes.</param>
    /// <param name="acc">The return value that the function accumulates.</param>
    /// <param name="foldFunction">The function that specifies how the Fold function should go through the given list</param>
    /// <returns></returns>
    public U Fold<T, U>(List<T> list, U acc, Func<T, U, U> foldFunction) 
    {
        foreach (T element in list)
        {
            acc = foldFunction(element, acc);
        }
        
        return acc;
    }
}

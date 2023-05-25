using System.Drawing;

namespace UniqueListSpace;

/// <summary>
/// data structure that represents a finite number of ordered values, where
/// the same value may occur more than once.
/// </summary>
public interface IMyList
{
    /// <summary>
    /// Property that contains information on how many elements there are in the list.
    /// </summary>
    public int Size { get; }

    /// <summary>
    /// Function that adds a new element in the list in a certain position.
    /// </summary>
    /// <param name="value">A value you'd like to add</param>
    /// <param name="position">A position where a new element shoud be added</param>
    public void AddValue(int value, int position);
    
    /// <summary>
    /// Function that deletes an element from the list.
    /// </summary>
    /// <param name="position">A position you'd like to delete a value of.</param>
    public void DeleteValue(int position);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="newValue">A new value you'd like to add.</param>
    /// <param name="position">A position in which you want to change a value.</param>
    public void ChangeValue(int newValue, int position);

    /// <summary>
    /// A function that return a value of an element of a given position.
    /// </summary>
    /// <param name="position">A position of an element you want to get a value of.</param>
    /// <returns></returns>
    public int GetValue(int position);
}

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SparseVector.Tests")]

namespace SparseVectorSpace;

/// <summary>
/// A sparse vector is a vector having a relatively small number of nonzero elements.
/// </summary>
internal class SparseVector
{
    public int Size { get; private set; }
    public Dictionary<int, int> Vector { get; set; } = new();

    internal SparseVector(int size)
    {
        this.Size = size;
    }

    /// <summary>
    /// Sets a value at the given index.
    /// </summary>
    /// <param name="index">index at which you want to insert a value</param>
    /// <param name="value">value you want to insert</param>
    public void SetValueAt(int index, int value)
    {
        if (value == 0)
        {
            Vector.Remove(index);
        }
        else
        {
            Vector[index] = value;
        }
    }

    /// <summary>
    /// returns
    /// </summary>
    /// <param name="index">index at which you want to get a value</param>
    public int GetValueAt(int index)
        => Vector[index];

    private SparseVector GetReverseVector(SparseVector vector)
    {
        SparseVector outputVector = new(vector.Size);

        foreach (var Element in vector.Vector)
        {
            outputVector.Vector[Element.Key] = -Element.Value;
        }

        return outputVector;
    }

    /// <summary>
    /// Adds two vectors and returns the result.
    /// </summary>
    /// <param name="vector1"></param>
    /// <param name="vector2"></param>
    /// <returns></returns>
    /// <exception cref="VectorsOfDifferentSizeExcetpion"></exception>
    public SparseVector VectorAddition(SparseVector vector1, SparseVector vector2)
    {
        if (vector1.Size != vector2.Size)
        {
            throw new VectorsOfDifferentSizeExcetpion("You can't add or subtract vectors of different size.");
        }

        SparseVector outputVector = new(vector1.Size);

        foreach (var Element in vector1.Vector)
        {
            if (!vector2.Vector.ContainsKey(Element.Key))
            {
                outputVector.Vector.Add(Element.Key, Element.Value);
            }
            else
            {
                if (Element.Value + vector2.Vector[Element.Key] == 0)
                {
                    continue;
                }
                else
                {
                    outputVector.Vector.Add(Element.Key, Element.Value + vector2.Vector[Element.Key]);
                }
            }
        }

        foreach (var Element in vector2.Vector)
        {
            if (!vector1.Vector.ContainsKey(Element.Key))
            {
                outputVector.Vector.Add(Element.Key, Element.Value);
            }
        }

        return outputVector;
    }

    /// <summary>
    /// Subtracts two vectors and returns the result.
    /// </summary>
    /// <param name="vector1"></param>
    /// <param name="vector2"></param>
    /// <returns></returns>
    public SparseVector VectorSubtraction(SparseVector vector1, SparseVector vector2)
        => VectorAddition(vector1, GetReverseVector(vector2));

    /// <summary>
    /// Checks if the vector is null.
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    public bool IsNullVector(SparseVector vector)
        => vector.Vector.Count == 0;

    /// <summary>
    /// Returns a scolar product of the two given vectors.
    /// </summary>
    /// <param name="vector1"></param>
    /// <param name="vector2"></param>
    /// <returns></returns>
    /// <exception cref="VectorsOfDifferentSizeExcetpion"></exception>
    public int ScalarProduct(SparseVector vector1, SparseVector vector2)
    {
        if (vector1.Size != vector2.Size)
        {
            throw new VectorsOfDifferentSizeExcetpion("You get a scolar product from vectors of different size.");
        }

        int scalarProduct = 0;

        foreach (var Element in vector1.Vector)
        {
            if (!vector1.Vector.ContainsKey(Element.Key))
            {
                continue;
            }
            else
            {
                scalarProduct += Element.Value * vector2.Vector[Element.Key];
            }
        }

        return scalarProduct;
    }
}

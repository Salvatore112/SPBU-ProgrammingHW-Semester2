namespace SparseVectorSpace;

/// <summary>
/// Exception that is trown when trying to perfom an operations on vectors of different size.
/// </summary>
internal class VectorsOfDifferentSizeExcetpion : Exception
{
    internal VectorsOfDifferentSizeExcetpion(string message)
        : base(message)
    {

    }
}

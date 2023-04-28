namespace SparseVectorSpace.Tests;

public class Tests
{
    SparseVector vector1;
    SparseVector vector2;
    SparseVector vector3;
    
    [SetUp]
    public void Setup()
    {
        vector1 = new(5);
        vector1.SetValueAt(0, 1);
        vector1.SetValueAt(1, 2);
        vector1.SetValueAt(2, 3);
        vector1.SetValueAt(3, 4);
        vector1.SetValueAt(4, 5);
        vector2 = new(5);
        vector2.SetValueAt(0, 1);
        vector2.SetValueAt(1, 2);
        vector2.SetValueAt(2, 3);
        vector2.SetValueAt(3, 4);
        vector2.SetValueAt(4, 5);
        vector3 = new(6);
    }

    [Test]
    public void AdditionShouldWork()
    {
        SparseVector outputVector = vector1.VectorAddition(vector1, vector2);
        SparseVector excpectedResult = new(5);
        excpectedResult.SetValueAt(0, 2);
        excpectedResult.SetValueAt(1, 4);
        excpectedResult.SetValueAt(2, 6);
        excpectedResult.SetValueAt(3, 8);
        excpectedResult.SetValueAt(4, 10);

        foreach (var element in outputVector.Vector)
        {
            Assert.That(element.Value == excpectedResult.Vector[element.Key]);
        }
    }

    [Test]
    public void SubtractionShouldWork()
    {
        SparseVector outputVector = vector1.VectorSubtraction(vector1, vector2);

        Assert.That(outputVector.IsNullVector(outputVector));
    }

    [Test]
    public void AddingVectorsOfDifferentSizesShouldThrowAnException()
    {
        Assert.Throws<VectorsOfDifferentSizeExcetpion>(() => vector3.VectorAddition(vector3, vector1));
    }

    [Test]
    public void SubtractingVectorsOfDifferentSizesShouldThrowAnException()
    {
        Assert.Throws<VectorsOfDifferentSizeExcetpion>(() => vector3.VectorSubtraction(vector3, vector1));
    }

    [Test]
    public void GettingScalaraProductFromVectorsOfDifferentSizesShouldThrowAnException()
    {
        Assert.Throws<VectorsOfDifferentSizeExcetpion>(() => vector3.ScalarProduct(vector3, vector1));
    }

    [Test]
    public void ScalarProductShouldWork()
    {
        Assert.That(vector1.ScalarProduct(vector1, vector2), Is.EqualTo(55));
    }
}
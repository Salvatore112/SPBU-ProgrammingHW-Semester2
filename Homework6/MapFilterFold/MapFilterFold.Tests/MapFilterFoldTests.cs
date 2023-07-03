namespace MapFilterFold.Tests;

public class Tests
{
    Functions functions = new();

    [Test]
    public void MapFunctionShouldWorkCorrectlyOnTheExampleInput()
    {
        var exampleList1 = new List<int>() { 1, 2, 3 };
        var exampleList2 = new List<double>() { 1.1, 2.2, 3.3 };

        var expectedResult1 = new List<int>() { 2, 4, 6 };
        var expectedResult2 = new List<double>() { 2.2, 4.4, 6.6 };

        Assert.That(functions.Map(exampleList1, x => x * 2).SequenceEqual(expectedResult1));
        Assert.That(functions.Map(exampleList2, x => x * 2).SequenceEqual(expectedResult2));
    }

    [Test]
    public void FilterFunctionShouldWorkCorrectly()
    {
        var testList1 = new List<int>() { 1, 10, 3, 5, 21 };
        var testList2 = new List<double>() { 52.22, 10.3, 3.42, 5.53, 21.02 };

        var expectedResult1 = new List<int>() { 10, 21 };
        var expectedResult2 = new List<double>() { 52.22, 10.3, 21.02 };

        Assert.That(functions.Filter(testList1, x => x >= 10).SequenceEqual(expectedResult1));
        Assert.That(functions.Filter(testList2, x => x >= 10).SequenceEqual(expectedResult2));
    }

    [Test]
    public void FoldFunctionShouldWorkCorrectlyOnTheExampleInput()
    {
        var exampleList1 = new List<int>() { 1, 2, 3 };
        var exampleList2 = new List<double>() { 1.0, 2.0, 3.0 };
        
        var expectedResult1 = 6;
        var expectedResult2 = 6.0;

        Assert.That(functions.Fold(new List<double> { 1.0, 2.0, 3.0 }, 1.0, (acc, elem) => acc * elem), Is.EqualTo(6.0));
        Assert.That(functions.Fold(new List<int> { 1, 2, 3 }, 1, (acc, elem) => acc * elem), Is.EqualTo(6));
    }
}
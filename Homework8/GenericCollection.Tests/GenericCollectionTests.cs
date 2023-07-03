namespace GenericCollectionSpace.Tests;

public class Tests
{
    SkipList<int> skiplist = new();

    [SetUp]
    public void Setup()
    {
        skiplist.Clear();
    }

    [Test]
    public void WalkingThroughAListShouldBePossibleViaForeach()
    {
        skiplist.Add(1);
        skiplist.Add(2);
        skiplist.Add(3);
        skiplist.Add(4);
        skiplist.Add(5);
        int[] expectedResult = { 1, 2, 3, 4, 5 };
        int i = 0; 
        foreach (int element in skiplist)
        {
            Assert.That(element, Is.EqualTo(expectedResult[i]));
            i++;
        }
    }

    [Test]
    public void RemoveAndContainShouldWork()
    {
        skiplist.Add(222);
        skiplist.Add(333);
        skiplist.Add(444);
        skiplist.Remove(333);
        Assert.That(!skiplist.Contains(333));
    }

    [Test]
    public void RemoveAtAndContainShouldWork()
    {
        skiplist.Add(15);
        skiplist.Add(20);
        skiplist.Add(25);
        skiplist.RemoveAt(2);
        Assert.That(!skiplist.Contains(25));
    }

    [Test]
    public void ClearShouldWork()
    {
        skiplist.Add(0);
        skiplist.Add(1);
        skiplist.Add(2);
        skiplist.Add(3);
        skiplist.Add(4);
        skiplist.Add(5);
        skiplist.Clear();
        for (int i = 0; i <= 5; i++)
        {
            Assert.That(!skiplist.Contains((int)i));
        }
    }

    [Test]
    public void InedxOfShouldWork()
    {
        skiplist.Add(1);
        skiplist.Add(2);
        skiplist.Add(3);
        Assert.That(skiplist.IndexOf(3), Is.EqualTo(2));
    }
}
using UniqueListSpace.MyListExceptions;

namespace UniqueListSpace.Tests;

public class GeneralListTests
{
    private static IEnumerable<TestCaseData> Lists
        => new TestCaseData[]
        {
            new TestCaseData(new MyList()),
            new TestCaseData(new UniqueList()),
        };

    [TestCaseSource(nameof(Lists))]
    public void AddValueShouldWork(IMyList list)
    {
        list.AddValue(250, 0);

        Assert.That(list.Size != 0 && list.GetValue(0) == 250);
    }

    [TestCaseSource(nameof(Lists))]
    public void DeleteValueShouldWork(IMyList list)
    {
        list.AddValue(700, 0);
        list.AddValue(251, 1);
        list.AddValue(255, 2);

        list.DeleteValue(2);
        list.DeleteValue(1);

        Assert.That(list.Size == 1 && list.GetValue(0) == 700);
    }

    [TestCaseSource(nameof(Lists))]
    public void ChangeValueShouldWork(IMyList list)
    {
        list.AddValue(700, 0);
        list.AddValue(251, 1);
        list.AddValue(255, 2);

        list.ChangeValue(600, 2);

        Assert.That(list.GetValue(2) == 600);
    }

    [TestCaseSource(nameof(Lists))]
    public void DeletingNonExistentValueShouldThrowAnException(IMyList list)
    {
        list.AddValue(700, 0);
        list.AddValue(251, 1);
        list.AddValue(255, 2);

        Assert.Throws<DeletingNonExistentElementException>(() => list.DeleteValue(500));
    }
}
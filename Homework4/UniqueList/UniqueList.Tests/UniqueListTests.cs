using UniqueListSpace.MyListExceptions;
using UniqueListSpace.UniqueListExceptions;

namespace UniqueListSpace.Tests;

public class UniqueListTests
{
    private static IEnumerable<TestCaseData> Lists
        => new TestCaseData[]
        {
            new TestCaseData(new UniqueList()),
        };

    [TestCaseSource(nameof(Lists))]
    public void AddingAnExistentValueShouldThrowAnException(IMyList list)
    {
        list.AddValue(250, 0);
        
        Assert.Throws<AddingExistingElementException>(() => list.AddValue(250, 1));
    }

    [TestCaseSource(nameof(Lists))]
    public void CausingTheListHaveTheSameValuesThroughChangeValueMethodShouldThrowAnException(IMyList list)
    {
        list.AddValue(250, 0);
        list.AddValue(2520, 1);
        
        Assert.Throws<ListHasTheSameElementException>(() => list.ChangeValue(250, 1));
    }
}
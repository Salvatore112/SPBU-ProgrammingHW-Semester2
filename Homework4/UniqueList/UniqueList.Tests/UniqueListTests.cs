using UniqueListSpace.MyListExceptions;
using UniqueListSpace.UniqueListExceptions;

namespace UniqueListSpace.Tests;

public class UniqueListTests
{
    UniqueList list;

    [SetUp]
    public void Init()
    {
        list = new UniqueList();
    }


    [Test]
    public void AddingAnExistentValueShouldThrowAnException()
    {
        list.AddValue(250, 0);
        
        Assert.Throws<AddingExistingElementException>(() => list.AddValue(250, 1));
    }

    [Test]
    public void CausingTheListHaveTheSameValuesThroughChangeValueMethodShouldThrowAnException()
    {
        list.AddValue(250, 0);
        list.AddValue(2520, 1);
        
        Assert.Throws<ListHasTheSameElementException>(() => list.ChangeValue(250, 1));
    }
}
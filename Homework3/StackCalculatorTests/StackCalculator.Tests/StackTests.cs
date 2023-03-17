using System.IO.Pipes;

namespace StackCalculatorTask.Tests;

public class StackTests
{
    private static IEnumerable<IStack> stacks
    {
        get
        {
            yield return new ListStack();
            yield return new ArrayStack(20);
        }
    }

    [Test, TestCaseSource(nameof(stacks))]
    public void PushShouldWork(IStack stack)
    {
        stack.Push(5);

        Assert.IsFalse(stack.IsEmpty());
    }

    [Test, TestCaseSource(nameof(stacks))]
    public void ValuePushedShouldBeTheSameAsValuePeeked(IStack stack)
    {
        stack.Push(5);

        int pushedValue = 5;

        Assert.That(5, Is.EqualTo(stack.Peek()));
    }

    [Test, TestCaseSource(nameof(stacks))]
    public void PopFromEmptyStackShouldThrowAnException(IStack stack)
    {
        Assert.Throws<Exception>(() => stack.Pop());
    }

    [Test, TestCaseSource(nameof(stacks))]
    public void PushAndPopShouldLeaveTheStackEmpty(IStack stack)
    {
        stack.Push(5);
        stack.Pop();
        Assert.True(stack.IsEmpty());
    }

    [Test, TestCaseSource(nameof(stacks))]
    public void TwoPushesAndOnePopShouldLeaveStackNotEmpty(IStack stack)
    {
        stack.Push(5);
        stack.Push(5);
        stack.Pop();
        Assert.False(stack.IsEmpty());
    }
}

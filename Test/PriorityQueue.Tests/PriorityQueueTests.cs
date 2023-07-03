using MyPriorityQueueSpace.Exceptions;

namespace MyPriorityQueueSpace.Tests;

public class Tests
{
    [Test]
    public void EmptyShouldReturnTrueIfAQueueIsEmpty()
    {
        PriorityQueue queue = new PriorityQueue();
        Assert.That(queue.Empty());
    }

    [Test]
    public void EmptyShouldReturnFalseIfAQueueIsNotEmpty()
    {
        PriorityQueue queue = new PriorityQueue();
        queue.Enqueue(100, 1);
        Assert.That(!queue.Empty());
    }

    [Test]
    public void DequeueFromAnEmptyQueueShouldThrowAnException()
    {
        PriorityQueue queue = new PriorityQueue();

        Assert.Throws<DequeueFromEmptyPriorityQueueException>(() => queue.Dequeue());
    }

    [Test]
    public void DequeueShouldReturnAnElementWithTheHighestPriority()
    {
        PriorityQueue queue = new PriorityQueue();

        queue.Enqueue(100, 100);
        queue.Enqueue(200, 3);
        queue.Enqueue(300, 1);

        Assert.That(queue.Dequeue() == 100);
    }

    [Test]
    public void DequeueShouldReturnTheEarlistToAddElementIfThereAreMultipleElementsOfTheHighestPriority()
    {
        PriorityQueue queue = new PriorityQueue();

        queue.Enqueue(120, 100);
        queue.Enqueue(200, 3);
        queue.Enqueue(300, 1);
        queue.Enqueue(300, 100);

        Assert.That(queue.Dequeue() == 120);
    }
}
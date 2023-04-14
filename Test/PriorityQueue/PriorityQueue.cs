using MyPriorityQueueSpace.Exceptions;

namespace MyPriorityQueueSpace;

/// <summary>
/// First In — First Out data structure that behaves similarly
/// to the normal queue except that each element has some priority.
/// </summary>
internal class PriorityQueue
{
    private class Element
    {
        public int Value { get; private set; }
        public int Priority { get; private set; }
        
        internal Element(int value, int priority)
        {
            this.Value = value;
            this.Priority = priority;
        }
    }

    private List<Element> collection = new List<Element>();

    private int size = -1;

    /// <summary>
    /// Method used to add an element to the queue.
    /// </summary>
    /// <param name="value">Value of the element.</param>
    /// <param name="priority">Priority of the element.</param>
    public void Enqueue(int value, int priority)
    {
        collection.Add(new Element(value, priority));
        size++;
    }

    /// <summary>
    /// Method that checks if the queue is empty.
    /// </summary>
    /// <returns></returns>
    public bool Empty()
        => size == -1;
    
    private int FindHighestPriorityElement()
    {
        int highestPriority = collection[0].Priority;
        int foundIndex = 0;

        for (int i = 1; i < collection.Count; i++)
        {
            if (collection[i].Priority > highestPriority)
            {
                highestPriority = collection[i].Priority;
                foundIndex = i;
            }
        }
        return foundIndex;
    }

    /// <summary>
    /// Method that returns an element with the highest priority,
    /// if there are multiple elements of the highest priority, it
    /// returns the one that was added earlier than the others.
    /// </summary>
    /// <exception cref="DequeueFromEmptyPriorityQueueException">Thrown when trying to dequeue from an empty 
    /// queue.</exception>
    public int Dequeue()
    {
        if (Empty())
        {
            throw new DequeueFromEmptyPriorityQueueException();
        }
        int index = FindHighestPriorityElement();
        int element = collection[index].Value;
        collection.RemoveAt(FindHighestPriorityElement());
        size--;
        return element;
    }
} 
    

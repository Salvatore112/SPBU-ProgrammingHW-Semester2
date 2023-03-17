namespace StackCalculatorTask;

using System;

internal class ListStack : IStack
{
    private List<double> collection;
    private int stackPosition;

    // Function that takes a value and puts it on the top of the stack.
    public void Push(double value)
    {
        stackPosition++;
        collection.Add(value);
    }

    // Function that removes an element from the top of the stack.
    public double Pop()
    {
        if  (stackPosition == - 1)
        {
            throw new Exception("You tried to pop from an empty stack!");
        }
        
        double deletedValue = collection[stackPosition];
        collection.Remove(deletedValue);
        stackPosition--;
        
        return deletedValue;
    }

    // Function that returns an element that's on the top of the stack.
    public double Peek()
    {
        if (stackPosition == -1)
        {
            throw new Exception("You tried to peek an empty stack!");
        }
        
        return collection[stackPosition];
    }

    // Function that checks if the stack is empty.
    public bool IsEmpty()
        => stackPosition == -1;

    // Function that prints stack elements.
    public void DisplayStack()
    {
        for (int i = 0; i <= stackPosition; i++)
        {
            Console.WriteLine(collection[i]);
        }
    }

    public ListStack()
    {
        this.stackPosition = -1;
        this.collection = new List<double>();
    }
}
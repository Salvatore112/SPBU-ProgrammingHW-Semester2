namespace StackCalculatorTask;

using System;

internal class ArrayStack : IStack
{
    private double[] collection;
    private int stackPosition;
    public int Capacity { get ; private set; }

    // Function that takes a value and puts it on the top of the stack.
    public void Push(double value)
    {
        if (stackPosition + 1 == Capacity)
        {
            Capacity *= 2;
            Array.Resize(ref collection, Capacity);
        }
        
        stackPosition++;
        collection[stackPosition] = value;
    }

    // Function that removes an element from the top of the stack.
    public double Pop()
    {
        if (stackPosition == -1)
        {
            throw new Exception("You tried to pop from an empty stack!");
        }
        
        double deletedValue = collection[stackPosition];
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

    public ArrayStack (int capacity)
    {
        this.stackPosition = -1;
        this.collection = new double[capacity];
        this.Capacity = capacity;
    }
}


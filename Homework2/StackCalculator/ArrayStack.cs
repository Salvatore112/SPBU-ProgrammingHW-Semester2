namespace StackCalculatorTask;

using System;

internal class ArrayStack : IStack
{
    double[] collection;
    int capacity;
    int stackPosition;
    int Capacity { get { return capacity; } }

    // Function that takes a value and puts it on the top of the stack.
    public void Push(double value)
    {
        if (stackPosition + 1 == capacity)
        {
            capacity *= 2;
            Array.Resize(ref collection, capacity);
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
    {
        return (stackPosition == 0);
    }

    // Function that prints stack elements.
    public void DisplayStack()
    {
        for (int i = 0; i <= stackPosition; i++)
        {
            Console.WriteLine(collection[i]);
        }
    }

    // Function that tests if the stack functions work correctly.
    public static bool Tests()
    {
        var testStack1 = new ArrayStack(20);
        testStack1.Push(1);
        testStack1.Push(2); 
        testStack1.Push(6);
        if (testStack1.Peek() != 6)
        {
            Console.WriteLine("Stack tests failed on push function.");
            return false;
        }
        
        var testStack2 = new ArrayStack(20);
        testStack2.Push(1);
        testStack2.Push(8);
        testStack2.Push(6);
        testStack2.Pop();
        if (testStack2.Peek() != 8)
        {
            Console.WriteLine("Stack tests failed on pop function.");
            return false;
        }

        var testStack3 = new ArrayStack(20);
        bool ExceptionCaught3 = false;
        try
        {
            testStack3.Pop();
        }
        catch (Exception)
        {
            ExceptionCaught3 = true;
        }
        if (!ExceptionCaught3)
        {
            Console.WriteLine("Stack tests failed on catching PopFromEmptyStackExceprion.");
            return false;
        }

        var testStack4 = new ArrayStack(20);
        bool ExceptionCaught4 = false;
        try
        {
            testStack4.Peek();
        }
        catch (Exception)
        {
            ExceptionCaught4 = true;
        }
        if (!ExceptionCaught4)
        {
            Console.WriteLine("Stack tests failed on catching PeekEmptyStackExceprion.");
            return false;
        }

        return true;
    }

    public ArrayStack (int capacity)
    {
        this.stackPosition = -1;
        this.collection = new double[capacity];
        this.capacity = capacity;
    }
}


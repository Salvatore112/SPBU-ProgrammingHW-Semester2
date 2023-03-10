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
        => stackPosition == 0;

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
        var testStack1 = new ListStack();
        testStack1.Push(1);
        testStack1.Push(2);
        testStack1.Push(6);
        if (testStack1.Peek() != 6)
        {
            Console.WriteLine("Stack tests failed on push function.");
            return false;
        }

        var testStack2 = new ListStack();
        testStack2.Push(1);
        testStack2.Push(8);
        testStack2.Push(6);
        testStack2.Pop();
        if (testStack2.Peek() != 8)
        {
            Console.WriteLine("Stack tests failed on pop function.");
            return false;
        }

        var testStack3 = new ListStack();
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

        var testStack4 = new ListStack();
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

    public ListStack()
    {
        this.stackPosition = -1;
        this.collection = new List<double>();
    }
}
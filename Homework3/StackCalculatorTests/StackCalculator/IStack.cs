namespace StackCalculatorTask;

// Interface that ListStack and ArrayStack classes implement.
interface IStack
{
    // Function that takes a value and puts it on the top of the stack.
    void Push(double value);

    // Function that removes an element from the top of the stack.
    double Pop();

    // Function that returns an element that's on the top of the stack.
    double Peek();

    // Function that checks if the stack is empty.
    bool IsEmpty();

    // Function that prints stack elements.
    void DisplayStack();
}
namespace CalculatorSpace;

/// <summary>
/// Calculator functionality based off of finite state machine.
/// </summary>
internal class FiniteStateMachine
{
    enum States 
    {
        FirstOperandStartState = 0,
        FirstOperandState = 1,
        SignState = 2,
        PlusOperatorState = 3,
        SecondOperandStartState = 4,
        SecondOperandState = 5,
    }

    private States currentState = States.FirstOperandStartState;
    private string firstOperand = string.Empty;
    private string secondOperand = string.Empty;
    public static char Operator { get; set; }

    public char Input { get; set; } = '0';
    public string Output { get; private set; }

    public void IterateFSM()
    {
        if (Input == 'C')
        {
            currentState = States.FirstOperandStartState;
            Output = "0";
        }
        else 
        {
            switch (currentState)
            {
                case (States.FirstOperandStartState):
                    if (Input == '0' || IsOperator(Input))
                    {
                        currentState = States.FirstOperandStartState;
                        Output = "0";
                        break;
                    }
                    if (IsDigit(Input))
                    {
                        currentState = States.FirstOperandState;
                        Output = Input.ToString();
                        firstOperand = Input.ToString();
                    }
                    break;
                case (States.FirstOperandState):
                    
                    if (IsOperator(Input))
                    {
                        Operator = Input;
                        currentState = States.SecondOperandStartState;
                        break;
                    }
                    if (IsDigit(Input))
                    {
                        Output += Input;
                        firstOperand += Input.ToString();
                    }
                    break;
                case (States.SecondOperandStartState):
                    if (Input == '0' || IsOperator(Input))
                    {
                        currentState = States.SecondOperandStartState;
                        Output = "0";
                        break;
                    }
                    if (Input == '=')
                    {
                        currentState = States.FirstOperandStartState;
                        Output = "Invalid input.";
                        break;
                    }
                    if (IsDigit(Input))
                    {
                        currentState = States.SecondOperandState;
                        Output = Input.ToString();
                        secondOperand = Input.ToString();
                    }
                    break;
                case (States.SecondOperandState):
                    if (IsOperator(Input) || Input == '=')
                    {
                        switch (Operator)
                        {
                            case '+':
                                Output = (Convert.ToInt32(firstOperand) + Convert.ToInt32(secondOperand)).ToString();
                                break;
                            case '-':
                                Output = (Convert.ToInt32(firstOperand) - Convert.ToInt32(secondOperand)).ToString();
                                break;
                            case '/':
                                Output = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand)).ToString();
                                break;
                            case '*':
                                Output = (Convert.ToInt32(firstOperand) * Convert.ToInt32(secondOperand)).ToString();
                                break;
                        }
                        currentState = States.SecondOperandStartState;
                        firstOperand = Output;
                        break;
                    }
                    if (IsDigit(Input))
                    {
                        Output += Input;
                        firstOperand += Input.ToString();
                    }
                    break;
            }
        }
    }

    private bool IsDigit(char character)
        => Convert.ToInt32(character.ToString()) >= 0 && Convert.ToInt32(character.ToString()) <= 9;

    private bool IsSign(char character)
        => character == '+' || character == '-';

    private bool IsOperator(char character)
        => character == '+' || character == '-' || character == '*' ||
           character == '/';

}

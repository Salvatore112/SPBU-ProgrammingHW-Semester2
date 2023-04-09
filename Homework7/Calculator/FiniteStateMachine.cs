namespace CalculatorSpace;

internal class FiniteStateMachine
{
    enum States : int
    {
        firstOperandStartState = 0,
        firstOperandState = 1,
        signState = 2,
        plusOperatorState = 3,
        secondOperandStartState = 4,
        secondOperandState = 5,
    }

    private States currentState = States.firstOperandStartState;
    private string firstOperand = string.Empty;
    private string secondOperand = string.Empty;
    static char Operator;

    public char Input { get; set; } = '0';
    public string Output { get; private set; }

    public void IterateFSM()
    {
        if (Input == 'C')
        {
            currentState = States.firstOperandStartState;
            Output = "0";
        }
        else 
        {
            switch (currentState)
            {
                case (States.firstOperandStartState):
                    if (Input == '0' || IsOperator(Input))
                    {
                        currentState = States.firstOperandStartState;
                        Output = "0";
                        break;
                    }
                    if (IsDigit(Input))
                    {
                        currentState = States.firstOperandState;
                        Output = Input.ToString();
                        firstOperand = Input.ToString();
                    }
                    break;
                case (States.firstOperandState):
                    if (IsOperator(Input))
                    {
                        Operator = Input;
                        currentState = States.secondOperandStartState;
                        break;
                    }
                    if (IsDigit(Input))
                    {
                        Output += Input;
                        firstOperand += Input.ToString();
                    }
                    break;
                case (States.secondOperandStartState):
                    if (Input == '0' || IsOperator(Input))
                    {
                        currentState = States.secondOperandStartState;
                        Output = "0";
                        break;
                    }
                    if (IsDigit(Input))
                    {
                        currentState = States.secondOperandState;
                        Output = Input.ToString();
                        secondOperand = Input.ToString();
                    }
                    break;
                case (States.secondOperandState):
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
                        currentState = States.firstOperandStartState;
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

    bool IsDigit(char character)
        => Convert.ToInt32(character.ToString()) >= 0 && Convert.ToInt32(character.ToString()) <= 9;

    bool IsSign(char character)
        => character == '+' || character == '-';

    bool IsOperator(char character)
        => character == '+' || character == '-' || character == '*' ||
           character == '/';

}

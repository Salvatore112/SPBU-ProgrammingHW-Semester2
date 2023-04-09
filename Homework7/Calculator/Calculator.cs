namespace CalculatorSpace;

public partial class Calculator : Form
{
    public Calculator()
    {
        InitializeComponent();
        textBox.Text = "0";
    }

    FiniteStateMachine finiteStateMachine = new FiniteStateMachine();

    private void button1_Click(object sender, EventArgs e)
    {
        finiteStateMachine.Input = '1';
        finiteStateMachine.IterateFSM();
        textBox.Text = finiteStateMachine.Output;
    }

    private void button2_Click(object sender, EventArgs e)
    {
        finiteStateMachine.Input = '2';
        finiteStateMachine.IterateFSM();
        textBox.Text = finiteStateMachine.Output;
    }

    private void button3_Click(object sender, EventArgs e)
    {
        finiteStateMachine.Input = '3';
        finiteStateMachine.IterateFSM();
        textBox.Text = finiteStateMachine.Output;
    }

    private void button4_Click(object sender, EventArgs e)
    {
        finiteStateMachine.Input = '4';
        finiteStateMachine.IterateFSM();
        textBox.Text = finiteStateMachine.Output;
    }

    private void button5_Click(object sender, EventArgs e)
    {
        finiteStateMachine.Input = '5';
        finiteStateMachine.IterateFSM();
        textBox.Text = finiteStateMachine.Output;
    }

    private void button6_Click(object sender, EventArgs e)
    {
        finiteStateMachine.Input = '6';
        finiteStateMachine.IterateFSM();
        textBox.Text = finiteStateMachine.Output;
    }

    private void button7_Click(object sender, EventArgs e)
    {
        finiteStateMachine.Input = '7';
        finiteStateMachine.IterateFSM();
        textBox.Text = finiteStateMachine.Output;
    }

    private void button8_Click(object sender, EventArgs e)
    {
        finiteStateMachine.Input = '8';
        finiteStateMachine.IterateFSM();
        textBox.Text = finiteStateMachine.Output;
    }

    private void button9_Click(object sender, EventArgs e)
    {
        finiteStateMachine.Input = '9';
        finiteStateMachine.IterateFSM();
        textBox.Text = finiteStateMachine.Output;
    }

    private void button0_Click(object sender, EventArgs e)
    {
        finiteStateMachine.Input = '0';
        finiteStateMachine.IterateFSM();
        textBox.Text = finiteStateMachine.Output;
    }

    private void addButton_Click(object sender, EventArgs e)
    {
        finiteStateMachine.Input = '+';
        finiteStateMachine.IterateFSM();
        textBox.Text = finiteStateMachine.Output;
    }

    private void divideButton_Click(object sender, EventArgs e)
    {
        finiteStateMachine.Input = '/';
        finiteStateMachine.IterateFSM();
        textBox.Text = finiteStateMachine.Output;
    }

    private void multiplyButton_Click(object sender, EventArgs e)
    {
        finiteStateMachine.Input = '*';
        finiteStateMachine.IterateFSM();
        textBox.Text = finiteStateMachine.Output;
    }

    private void equalsButton_Click(object sender, EventArgs e)
    {
        finiteStateMachine.Input = '=';
        finiteStateMachine.IterateFSM();
        textBox.Text = finiteStateMachine.Output;
    }

    private void subtractButton_Click(object sender, EventArgs e)
    {
        finiteStateMachine.Input = '-';
        finiteStateMachine.IterateFSM();
        textBox.Text = finiteStateMachine.Output;
    }

    private void eraseButton_Click(object sender, EventArgs e)
    {
        finiteStateMachine.Input = 'C';
        finiteStateMachine.IterateFSM();
        textBox.Text = finiteStateMachine.Output;
    }
}

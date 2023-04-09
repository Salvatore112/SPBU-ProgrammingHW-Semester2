namespace CalculatorSpace;

public partial class Calculator : Form
{
    public Calculator()
    {
        InitializeComponent();
        textBox.Text = "0";
    }

    private void button1_Click(object sender, EventArgs e)
    {
        FiniteStateMachine.Input = '1';
        textBox.Text = FiniteStateMachine.Input.ToString();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        FiniteStateMachine.Input = '2';
    }

    private void button3_Click(object sender, EventArgs e)
    {
        FiniteStateMachine.Input = '3';
    }

    private void button4_Click(object sender, EventArgs e)
    {
        FiniteStateMachine.Input = '4';
    }

    private void button5_Click(object sender, EventArgs e)
    {
        FiniteStateMachine.Input = '5';
    }

    private void button6_Click(object sender, EventArgs e)
    {
        FiniteStateMachine.Input = '6';
    }

    private void button7_Click(object sender, EventArgs e)
    {
        FiniteStateMachine.Input = '7';
    }

    private void button8_Click(object sender, EventArgs e)
    {
        FiniteStateMachine.Input = '8';
    }

    private void button9_Click(object sender, EventArgs e)
    {
        FiniteStateMachine.Input = '9';
    }
}

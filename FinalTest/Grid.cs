namespace ButtonGame;

internal class Grid
{
    public List<Button> buttons = new();
    private List<int> values = new();
    private int tableSize;
    private int buttonCount;
    public bool IsWin { get; set; }

    Random rand = new();

    internal Grid (int size)
    {
        if (size % 2 != 0)
        {
            throw new InvalidInputException("The size of the grid can't be an odd number!");
        }

        tableSize = size;
        buttonCount = size * size;
        CreateButtons(buttons);
    }

    /// <summary>
    /// Function that creates button and assigns them values.
    /// </summary>
    /// <param name="buttonArray">List where the buttons are stored.</param>
    public void CreateButtons(List<Button> buttons)
    {
        for (int i = 0; i < (tableSize * tableSize) / 2; i ++)
        {
            int value = rand.Next(Convert.ToInt32((tableSize * tableSize) / 2 - 1));
            values.Add(value);
            values.Add(value);
        }
        
        for (int i = 0; i < tableSize; ++i)
        {
            for (int j = 0; j < tableSize; ++j)
            {
                var temp = new Button();
                temp.Location = new Point(i * 60, j * 50);
                temp.Size = new Size(60, 50);
                int valueIndex = rand.Next(values.Count);
                //temp.Text = values[valueIndex].ToString();
                temp.Tag = values[valueIndex].ToString();
                temp.Name = values[valueIndex].ToString();
                values.RemoveAt(valueIndex);
                buttons.Add(temp);
            }
        }
    }

    private bool firstButtonPressed = false;
    private Button frstButton;
    private Button secondButton;
 
    /// <summary>
    /// Function that accurs when the button is clicked. It disables buttons,
    /// shows their text depending on wheter the first button was pressed.
    /// </summary>
    /// <param name="button"></param>
    public void ClickFunction(Button button)
    {
        if (firstButtonPressed)
        {
            if (frstButton.Tag == button.Tag)
            {
                button.Text = button.Tag.ToString();
                button.Enabled = false;
                frstButton.Enabled = false;
                frstButton = null;
                firstButtonPressed = false;
                buttonCount -= 2;
            } 
            else
            {
                secondButton = button;
                button.Text = button.Tag.ToString();
                firstButtonPressed = false;
            }
        }
        else
        {
            if (secondButton != null)
            {
                secondButton.Text = "";
                secondButton = null;
            }
            if (frstButton != null)
            {
                frstButton.Text = "";
                frstButton = null;
            }

            button.Text = button.Tag.ToString();
            firstButtonPressed = true;
            frstButton = button;
        }
        if (buttonCount == 0)
        {
            IsWin = true;
        }
    }
}

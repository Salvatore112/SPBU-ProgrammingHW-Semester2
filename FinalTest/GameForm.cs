using System.Drawing;

namespace ButtonGame;

public partial class GameForm : Form
{
    private static int size;

    private Grid myGrid = new(size);

    public GameForm(int size)
    {
        size = Convert.ToInt32(size);
        CreateButtons();
        InitializeComponent();
    }

    public void CreateButtons()
    {
        foreach (var button in myGrid.buttons)
        {
            
            button.MouseClick += new MouseEventHandler(MouseClick);
            Controls.Add(button);
        }
    }

    private void MouseClick(object sender, MouseEventArgs e)
    {
        
        var button = (Button)sender;
        myGrid.ClickFunction(button);
        if (myGrid.IsWin)
        {
            MessageBox.Show("You win!");
        }
    }
}

using GameSpace;

namespace GameSpace;

/// <summary>
/// Class that contains function of dealing with map uploading and 
/// character movements.
/// </summary>
public class MapAndMovement
{
    private int originalRow = 0;
    private int originalCol = 0;

    /// <summary>
    /// Character's current X position.
    /// </summary>
    public int characterX { get; private set; }

    /// <summary>
    /// Character's current Y position.
    /// </summary>
    public int characterY { get; private set; }

    /// <summary>
    /// Matrix that contains map.
    /// </summary>
    public char[,] Map { get; private set; }

    private int mapRows;
    private int mapColumns;
    public bool withCharacter { get; private set; } = false;

    private void WriteAt(string s, int y, int x)
    {
        try
        {
            Console.SetCursorPosition(originalCol + x, originalRow + y);
            Console.Write(s);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
        }
    }

    /// <summary>
    /// Function that uploads a map from the file.
    /// </summary>
    /// <param name="FilePath"></param>
    public void LoadMap(string FilePath)
    {
        string[] lines = File.ReadAllLines(FilePath);

        mapRows = lines.Length;

        foreach (string line in lines)
        {
            mapColumns = Math.Max(mapColumns, line.Length);
        }

        Map = new char[mapRows, mapColumns];

        for (int i = 0; i < mapRows; i++)
        {
            for (int j = 0; j < mapColumns; j++)
            {
                if (j >= lines[i].Length)
                {
                    Map[i, j] = ' ';
                }
                else
                {
                    Map[i, j] = lines[i][j];
                    if (Map[i, j] == '@')
                    {
                        withCharacter = true;
                        characterX = j;
                        characterY = i;
                    }
                }
            }
        }
        if (!withCharacter)
        {
            throw new InvalidMapException("The map doesn't have a character");
        }
    }

    /// <summary>
    /// Function that draws a map.
    /// </summary>
    public void DrawMap()
    {
        originalRow = 0;
        originalCol = 0;

        for (int i = 0; i < mapRows; i++)
        {
            for (int j = 0; j < mapColumns; j++)
            {
                WriteAt(Map[i, j].ToString(), i, j);
            }
        }
    }

    /// <summary>
    /// Function performs a move and stores the result in the matrix.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void PerformMove (int x, int y)
    {
        if (Map[characterY + y, characterX + x] == ' ')
        {
            Map[characterY, characterX] = ' ';
            Map[characterY + y, characterX + x] = '@';

            characterX += x;
            characterY += y;
        }
        return;
    }

    /// <summary>
    /// Function that displays a move.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void DisplayMove(int x, int y)
    {
        WriteAt(" ", characterY - y, characterX - x);
        WriteAt("@", characterY, characterX);
        
        return;
    }

    /// <summary>
    /// Perform and display going left move.
    /// </summary>
    public void GoLeft()
    {
        PerformMove(-1, 0);
        DisplayMove(-1, 0);
        return;
    }

    /// <summary>
    /// Perform and display going right move.
    /// </summary>
    public void GoRight()
    {
        PerformMove(1, 0);
        DisplayMove(1, 0);
        return;
    }

    /// <summary>
    /// Perform and display going up move.
    /// </summary>
    public void GoUp()
    {
        PerformMove(0, -1);
        DisplayMove(0, -1);
        return;
    }

    /// <summary>
    /// Perform and display going down move.
    /// </summary>
    public void GoDown()
    {
        PerformMove(0, 1);
        DisplayMove(0, 1);
        return;
    }

}

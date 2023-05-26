using GameSpace;

/// <summary>
/// Class that contains a function to start the game.
/// </summary>
internal class Game
{
    private MapAndMovement mapAndMovement = new();
    
    private void EventLoop(Action Left, Action Right, Action Down, Action Up)
    {
        bool needExit = false;
        while (!needExit)
        {
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    Left();
                    break;
                case ConsoleKey.RightArrow:
                    Right();
                    break;
                case ConsoleKey.DownArrow:
                    Down();
                    break;
                case ConsoleKey.UpArrow:
                    Up();
                    break;
                case ConsoleKey.F:
                    needExit = true;
                    break;
            }
        }
    }

    /// <summary>
    /// Function that starts the game.
    /// </summary>
    public void StartGame(string Map)
    {
        mapAndMovement.LoadMap(Map);
        mapAndMovement.DrawMap();
        EventLoop(mapAndMovement.GoLeft, mapAndMovement.GoRight,
                  mapAndMovement.GoDown, mapAndMovement.GoUp);
    }
}

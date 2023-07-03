using GameSpace;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Game.Tests")]

var game = new Game();

game.StartGame("map.txt");

Console.ReadKey();


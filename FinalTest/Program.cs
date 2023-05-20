using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ButtonGame.Tests")]

namespace ButtonGame;

internal static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new GameForm(Convert.ToInt32(args[0])));
    }
}
using MapFilterFold;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MapFilterFold.Tests")]

var functions = new Functions();

var random = new Random();

var exampleList1 = new List<int>() { 1, 2, 3 };

functions.Map(exampleList1, x => x * 2);

Console.ReadKey();
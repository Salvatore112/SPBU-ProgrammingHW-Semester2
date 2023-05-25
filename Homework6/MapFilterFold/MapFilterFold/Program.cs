using MapFilterFold;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MapFilterFold.Tests")]

var functions = new Functions();

var random = new Random();

List<double> neww = new List<double>() { 2.2, 3.14, 2.55 };

neww = functions.Map(neww, (double x) => x * 2);

double acc = functions.Fold(new List<double> {1.1, 2.2, 3.2}, 1.0, (acc, elem) => acc * elem);

Console.ReadKey();


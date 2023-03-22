using ParseTreeSpace;
using System.IO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ParseTree.Tests")]

string filePath = @"D:\SPBU-ProgrammingHW-Semester2\Homework4\ParseTree\input.txt";

var file = new StreamReader(filePath);

string expression = file.ReadToEnd();

var tree = new ParseTree();

Console.WriteLine("Result: " + tree.CalculateExpression(expression));
Console.WriteLine("Printed tree: " + tree.PrintTree(expression));
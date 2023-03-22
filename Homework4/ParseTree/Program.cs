using ParseTreeSpace;
using System.Runtime.InteropServices;

string expression = "4 * 4";

var tree = new ParseTree();

Console.WriteLine(tree.CalculateExpression(expression));
Console.WriteLine(tree.PrintTree(expression));
using UniqueListSpace;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UniqueList.Tests")]

var list = new UniqueList();

list.AddValue(700, 0);
list.AddValue(251, 1);
list.AddValue(255, 2);

list.ChangeValue(600, 2);

list.AddValue(25511, 3);

list.DeleteValue(500);

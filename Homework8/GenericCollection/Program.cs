using GenericCollectionSpace;

var testList = new SkipList<int>();

testList.Add(1);
testList.Add(2);
testList.Add(3);

Console.WriteLine(testList.IndexOf(3));

testList.Clear();

Console.ReadKey();
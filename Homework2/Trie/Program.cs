using TrieDataStructure;

if (!Trie.Tests())
{
    Console.WriteLine("Tests failed.");
}
else
{
    var testTrie = new Trie();

    testTrie.Add("kernel");
    testTrie.Add("test");
    testTrie.Add("map");
    testTrie.Add("mapping");

    testTrie.Remove("mapping");

    Console.WriteLine(testTrie.Contains("mapping"));
}
    


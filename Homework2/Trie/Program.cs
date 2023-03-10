namespace Trie;

class Program
{
    static void Main(string[] args)
    {
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
    }

    // Interface that Trie class implements.
    interface ITrie
    {
        bool Add(string element);
        bool Contains(string element);
        bool Remove(string element);
        int HowManyStartsWithPrefix(String prefix);
    }
}

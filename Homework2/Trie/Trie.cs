namespace TrieDataStructure;

using System;

// Trie class that implements Trie data structure.
internal class Trie : ITrie
{
    private TrieNode root;

    public int Size { get; private set; }

    public Trie()
    {
        this.root = new TrieNode();
    }

    private class TrieNode
    {
        public Dictionary<char, TrieNode> SubNodes { get; }
        public bool IsWord { get; set; }
        public int WordCount { get; set; }
       
        public TrieNode()
        {
            this.SubNodes = new Dictionary<char, TrieNode>();
        }
    }

    // Functions that takes an element and adds it to the trie.
    public bool Add(string element)
    {
        if (Contains(element))
        {
            return false;
        }
        else
        {
            return AddRecursion(root, element);
        }
    }

    bool AddRecursion(TrieNode node, string remainingString)
    {
        // If statement that prevents the program crash from passing an empty string.
        if (remainingString.Length <= 0)
        {
            return true;
        }

        char prefix = remainingString[0];
        string subString = remainingString.Substring(1);

        if (!node.SubNodes.ContainsKey(prefix))
        {
            node.SubNodes.Add(prefix, new TrieNode());
        }
        node.SubNodes[prefix].WordCount++;

        if (subString.Length == 0)
        {
            node.SubNodes[prefix].IsWord = true;
            Size++;
            return true;
        }
        else
        {
            return AddRecursion(node.SubNodes[prefix], subString);
        }
    }

    // Function that checks if the given element in the trie.
    public bool Contains(string element)
    {
        TrieNode tempNode = root;
        foreach (char character in element)
        {
            if (!tempNode.SubNodes.ContainsKey(character))
            {
                return false;
            }
            else
            {
                tempNode = tempNode.SubNodes[character];
            }
        }

        return true;
    }

    // Function that removes an element from the trie.
    public bool Remove(string element)
    {
        bool isHere = Contains(element);

        return RemoveRecursion(root, element, isHere);
    }

    bool RemoveRecursion(TrieNode root, string remainingString, bool isHere)
    {
        if (remainingString.Length <= 0)
        {
            return isHere;
        }

        char prefix = remainingString[0];
        string subString = remainingString.Substring(1);

        RemoveRecursion(root.SubNodes[prefix], subString, isHere);

        TrieNode tempNode = root.SubNodes[prefix];

        if (root.SubNodes[prefix].WordCount > 1)
        {
            root.SubNodes[prefix].WordCount--;
        }
        else
        {
            root.SubNodes.Remove(prefix);
        }

        return isHere;
    }

    // Function that returns amount of words starting with the given prefix.
    public int HowManyStartsWithPrefix(string prefix)
    {
        TrieNode tempNode = root;
        foreach (char character in prefix)
        {
            if (!tempNode.SubNodes.ContainsKey(character))
            {
                return 0;
            }
            else
            {
                tempNode = tempNode.SubNodes[character];
            }
        }
        return tempNode.WordCount;
    }

    // Function that tests if all the trie functions work correctly.
    public static bool Tests()
    {
        var testTrie1 = new Trie();
        testTrie1.Add("red");
        testTrie1.Add("rear");
        testTrie1.Add("redacted");
        testTrie1.Add("kernel");

        if (testTrie1.Size != 4)
        {
            Console.WriteLine("Tests failed on returning size field.");
            return false;
        }

        if (testTrie1.HowManyStartsWithPrefix("re") != 3)
        {
            Console.WriteLine("Tests failed on HowManyStartsWithPrefix function.");
            return false;
        }

        if (!testTrie1.Contains("red") || !testTrie1.Contains("rear") || !testTrie1.Contains("redacted"))
        {
            Console.WriteLine("Tests failed on Contains/Add function.");
            return false;
        }

        testTrie1.Remove("rear");
        testTrie1.Remove("redacted");

        if (testTrie1.Contains("rear") || testTrie1.Contains("redacted"))
        {
            Console.WriteLine("Tests failed on Remove function.");
            return false;
        }

        return true;
    }
}



namespace LZWTask;

using System;

// Interface that Trie class implements.
interface ITrie
{
    // Functions that takes an element and adds it to the trie.
    bool Add(string element);

    // Function that checks if the given element in the trie.
    bool Contains(string element);

    // Function that removes an element from the trie.
    bool Remove(string element);

    // Function that returns amount of words starting with the given prefix.
    int HowManyStartsWithPrefix(String prefix);
}
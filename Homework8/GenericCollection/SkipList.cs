using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GenericCollection.Tests")]

namespace GenericCollectionSpace;

using System.Collections;

/// <inheritdoc/>
internal class SkipList<T> : IList<T> where T : IComparable<T>
{
    private Node<T> head = new Node<T>(default, 30, -1);
    private List<T> baseList = new();
    private Random random = new Random();
    int levels = 1;
    public int Count { get; private set; }
    public bool IsReadOnly { get; private set; }

    public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    /// <inheritdoc/>
    public bool Remove(T value)
    {
        if (!Contains(value))
        {
            return false;
        }
        else
        {
            RemoveAt(IndexOf(value));
            return true;
        }
    }

    /// <inheritdoc/>
    private class Node<U>
    {
        public U Value { get; set; }
        public Node<U>[] NextNodes { get; set; }
        public int Index { get; set; }

        public Node(U value, int levels, int index)
        {
            this.Value = value;
            this.NextNodes = new Node<U>[levels];
            this.Index = index;
        }
    }

    /// <inheritdoc/>
    public void Add(T value)
    {
        baseList.Add(value);

        int occupiedLevels = 0;
        for (int R = random.Next(); (R & 1) == 1; R >>= 1)
        {
            occupiedLevels++;
            if (occupiedLevels == levels)
            {
                levels++;
                break;
            }
        }

        Node<T> newNode = new Node<T>(value, levels, Count);
        Node<T> currentNode = head;

        for (int i = occupiedLevels; i >= 0; i--)
        {
            while (currentNode.NextNodes[i] != null)
            {
                if (currentNode.NextNodes[i].Value.CompareTo(value) > 0)
                {
                    break;
                }
                currentNode = currentNode.NextNodes[i];
            }
            newNode.NextNodes[i] = currentNode.NextNodes[i];
            currentNode.NextNodes[i] = newNode;
        }
        this.Count++;
    }

    /// <inheritdoc/>
    public bool Contains(T value)
    {
        Node<T> currentNode = head;
        for (int i = levels - 1; i >= 0; i--)
        {
            while (currentNode.NextNodes[i] != null)
            {
                if (currentNode.NextNodes[i].Value.CompareTo(value) == 0)
                {
                    return true;
                }
                if (currentNode.NextNodes[i].Value.CompareTo(value) > 0)
                {
                    break;
                }
                currentNode = currentNode.NextNodes[i];
            }
        }
        return false;
    }

    /// <inheritdoc/>
    public void RemoveAt(int index)
    {
        for (int i = levels - 1; i >= 0; i--)
        {
            Node<T> currentNode = head.NextNodes[i];
            while (currentNode.NextNodes[i] != null)
            {
                if (currentNode.NextNodes[i].Index >= index)
                {
                    break;
                }
                currentNode = currentNode.NextNodes[i];
            }

            if (currentNode.NextNodes[i] == null || currentNode.NextNodes[i].Index > index)
            {
                continue;
            }
            else
            {
                currentNode.NextNodes[i] = currentNode.NextNodes[i].NextNodes[i];
            }
        }
    }

    /// <inheritdoc/>
    public int IndexOf(T value)
    {
        int index = -1;
        for (int i = levels - 1; i >= 0; i--)
        {
            Node<T> currentNode = head.NextNodes[i];
            while (currentNode.NextNodes[i] != null)
            {
                if (currentNode.NextNodes[i].Value.CompareTo(value) >= 0)
                {
                    break;
                }
                currentNode = currentNode.NextNodes[i];
            }

            if (currentNode.NextNodes[i] == null || currentNode.NextNodes[i].Value.CompareTo(value) > 0)
            {
                continue;
            }
            else if (currentNode.NextNodes[i].Value.CompareTo(value) == 0)
            {
                index = currentNode.NextNodes[i].Index;
                break;
            }
        }
        return index;
    }

    /// <inheritdoc/>
    public void Clear()
    {
        head = new Node<T>(default, 30, -1);
        baseList = new();
        this.levels = 1;
        this.Count = 0;
    }

    /// <inheritdoc/>
    public void Insert(int index, T value)
        => throw new NotImplementedException();

    /// <inheritdoc/>
    public void CopyTo(T[] array, int arrayIndex)
    {
        for (int i = 0; i < this.Count; i++)
        {
            array[i + arrayIndex] = baseList[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return baseList.GetEnumerator();
    }

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator()
    {
        return baseList.GetEnumerator();
    }
}

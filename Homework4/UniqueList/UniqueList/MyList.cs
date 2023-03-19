namespace UniqueListSpace;

using UniqueListSpace.MyListExceptions;

/// <inheritdoc cref="IMyList"/>
internal class MyList : IMyList
{
    protected Node root = null;

    /// <inheritdoc cref="IMyList.Size"/>
    public int Size { get; set; }

    protected class Node
    {
        public int Value { get; set; }
        
        public Node NextNode { get; set; }

        public Node(int value, Node nextNode) 
        {
            this.Value = value;
            this.NextNode = nextNode;
        }
        
        public Node(int value)
        {
            this.Value = value;
        }
    }

    /// <inheritdoc cref="IMyList.AddValue"/>
    public virtual void AddValue(int value, int position)
    {
        position = position > this.Size ? this.Size : position;
        var newNode = new Node(value);
        if (this.Size == 0)
        {
            this.root = newNode;
        }
        else if (position == 0)
        {
            newNode.NextNode = this.root;
            this.root = newNode;
        }
        else
        {
            var tempNode = this.root;
            for (int i = 0; i < position - 1; i++)
            {
                tempNode = tempNode.NextNode;
            }

            newNode.NextNode = tempNode.NextNode;
            tempNode.NextNode = newNode;
        }
        this.Size++;
    }

    /// <inheritdoc cref="IMyList.ChangeValue"/>
    public virtual void ChangeValue(int newValue, int position)
    {
        var tempNode = this.root;
        for (int i = 0; i < position; i++)
        {
            tempNode = tempNode.NextNode;
        }
        tempNode.Value = newValue;
    }

    /// <inheritdoc cref="IMyList.DeleteValue"/>
    public virtual void DeleteValue(int position)
    {
        if (position > Size - 1)
        {
            throw new DeletingNonExistentElementException();
        }
        
        if (position == 0)
        {
            this.root = this.root.NextNode;
        }
        else
        {
            var tempNode = this.root;
            for (int i = 0; i < position - 1; i++)
            {
                tempNode = tempNode.NextNode;
            }

            if (tempNode.NextNode.NextNode == null)
            {
                tempNode.NextNode = null;
            }
            else
            {
                tempNode.NextNode = tempNode.NextNode.NextNode;
            }
        }
        this.Size--;
    }

    /// <inheritdoc cref="IMyList.GetValue"/>
    public int GetValue(int position)
    {
        if (this.Size == 0 || position >= this.Size)
        {
            throw new GettingNonExistentValueException();
        }
        
        var tempNode = this.root;
        
        for (int i = 0; i < position; i++)
        {
            tempNode = tempNode.NextNode;
        }

        return tempNode.Value;
    }
}

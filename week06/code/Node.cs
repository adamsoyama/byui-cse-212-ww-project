public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Problem 1: Insert Unique Values Only
    /// Update Insert to only allow unique values.
    /// </summary>
    public void Insert(int value)
    {
        // Prevent duplicates
        if (value == Data)
        {
            return; // Do nothing if value already exists
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else // value > Data
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    /// <summary>
    /// Problem 2: Contains
    /// Recursively search for a value in the tree.
    /// </summary>
    public bool Contains(int value)
    {
        if (value == Data) return true;

        if (value < Data)
        {
            return Left != null && Left.Contains(value);
        }
        else // value > Data
        {
            return Right != null && Right.Contains(value);
        }
    }

    /// <summary>
    /// Problem 4: Tree Height
    /// Height = 1 + max(height(left), height(right)).
    /// Base case: null child = 0.
    /// </summary>
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
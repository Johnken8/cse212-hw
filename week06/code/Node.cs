public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Don't insert if the value already exists
        if (value == Data)
            return;
            
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // If we found the value, return true
        if (value == Data)
            return true;
            
        // If value is less than current node, check left subtree
        if (value < Data)
            return Left != null && Left.Contains(value);
            
        // If value is greater than current node, check right subtree
        return Right != null && Right.Contains(value);
    }

    public int GetHeight()
    {
        // Get the height of left and right subtrees
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        
        // Return the maximum height plus 1 for current node
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
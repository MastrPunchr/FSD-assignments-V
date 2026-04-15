namespace LinkedList;

public class Node
{
    private int _data;
    private Node _next;

    public int Data
    {
        get => _data;
        set => _data = value;
    }

    public Node Next { get; set; }

    public Node(int value)
    {
        Data = value;
        Next = null;
    }

    public override string ToString()
    {
        if (Next == null)
        {
            return $"[{Data}] -> NULL";
        }
        return $"[{Data}] -> {Next}";
    }
}
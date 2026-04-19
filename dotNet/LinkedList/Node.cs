namespace LinkedList;

public class Node
{
    public int Data { get; set; }

    public Node Next { get; set; }

    public Node Prev { get; set; }

    public Node(int value)
    {
        Data = value;
        Next = null;
        Prev = null;
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
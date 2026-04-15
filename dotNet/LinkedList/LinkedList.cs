namespace LinkedList;

public class LinkedList
{
    private Node head;
    private int count;
    private Node tail;

    public Node Head
    {
        get => head;
        set => head = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Count
    {
        get => count;
        set => count = value;
    }

    public Node Tail
    {
        get => tail;
        set => tail = value ?? throw new ArgumentNullException(nameof(value));
    }

    public LinkedList()
    {
        Head = null;
        Tail = head;
        Count = 0;
    }

    public LinkedList(Node head)
    {
        Head = head;
        Tail = head;
        Count = 1;
    }

    public LinkedList(int value)
    {
        Head = new Node(value);
        Tail = head;
        Count = 1;
    }

    public Node Search(int value)
    {
        Node curr = Head;
        while (curr != null)
        {
            if (curr.Data == value)
            {
                return curr;
            }
            curr = curr.Next;
        }
        return null;
    }

    public void Add(Node node)
    {
        if (Head == null)
        {
            Head = node;
        }
        else
        {
            Tail.Next = node;
            Tail = Tail.Next;
            Count++;
        }
    }

    public override string ToString()
    {
        return $"HEAD -> {Head}";
    }
}
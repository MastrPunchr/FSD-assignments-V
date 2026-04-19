namespace LinkedList;

public class LinkedList
{
    public Node Head { get; set; }
    public int Count { get; set; }
    public Node Tail { get; set; }

    public LinkedList()
    {
        Head = null;
        Tail = Head;
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
        Tail = Head;
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
            Tail = node;
        }
        else
        {
            node.Prev = Tail;
            Tail.Next = node;
            Tail = node;
            Count++;
        }
    }

    public void Add(int value)
    {
        Node newNode = new Node(value);
        Add(newNode);
    }

    public void Remove(Node node) // O(1)
    {
        if (Count == 1)
        {
            Head = null;
            Tail = null;
        }
        if(node == Head)
        {
            Head = node.Next;
            node.Next.Prev = null;
        }
        else if (node == Tail)
        {
            Tail = node.Prev;
            node.Prev.Next = null;
        }
        else
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }
        node = null;
    }

    public void Remove(int value) // O(n)
    {
        Node toRemove = Search(value); // O(n)
        Remove(toRemove);// O(1)
    }

    public override string ToString()
    {
        return $"HEAD -> {Head}";
    }
}
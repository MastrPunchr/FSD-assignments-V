namespace LinkedList;

public class Program
{
    public static void Main()
    {
        Node n1 = new Node(1);
        Node n2 = new Node(2);

        Console.WriteLine(n1);
        Console.WriteLine(n2);

        LinkedList ll1 = new LinkedList(n1);
        ll1.Add(n2);
        Console.WriteLine(ll1);

        Console.WriteLine(ll1.Search(2));
    }
}


namespace LinkedList;

public class Program
{
    public static void Main()
    {
        LinkedList ll1 = new LinkedList();
        ll1.Add(1);
        ll1.Add(4);
        ll1.Add(7);

        LinkedList ll2 = new LinkedList();
        ll2.Add(2);
        ll2.Add(3);
        ll2.Add(5);

        LinkedList merged = MergeLinkedLists(ll1, ll2);
        Console.WriteLine(merged);
    }

    public static LinkedList MergeLinkedLists(LinkedList ll1, LinkedList ll2)
    {
        LinkedList ll3 = new LinkedList();
        //TODO
        Node curr1 = ll1.Head;
        Node curr2 = ll2.Head;
        while (curr1 != null && curr2 != null)
        {
            if (curr1.Data <= curr2.Data)
            {
                ll3.Add(curr1.Data);
                curr1 = curr1.Next;
            }
            else
            {
                ll3.Add(curr2.Data);
                curr2 = curr2.Next;
            }
        }

        while (curr1 != null)
        {
            ll3.Add(curr1.Data);
            curr1 = curr1.Next;
        }

        while (curr2 != null)
        {
            ll3.Add(curr2.Data);
            curr2 = curr2.Next;
        } 
        return ll3;
    }
}


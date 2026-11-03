namespace GenericsExample;

public class GenericBox<TypeA, TypeB>
{
    private TypeA first;
    private TypeB second;

    public void Box(TypeA a, TypeB b)
    {
        first = a;
        second = b;
    }

    public (TypeA, TypeB) Unbox()
    {
        return (first, second);
    }
}

class Program
{   
    //write a generic function PrintTwice<T>(T value) that prints value on two lines
    static void PrintTwice<T>(T value)
    {
        Console.WriteLine(value);
        Console.WriteLine(value);
    }
    //write a generic function GetFirst<T>(List<T> items) that returns the first item in the list
    static T GetFirst<T>(List<T> items)
    {
        return items[0];
    }
    //write a generic function MakeArray<T>(T first, T second) that returns an array holding the two values
    static T[] MakeArray<T>(T first, T second)
    {
        return [first, second];
    }
    //Write a generic function PrintAll<T>(List<T> items) that prints each item on its own line, numbered from 1.
    static void PrintAll<T>(List<T> items)
    {
        foreach (T item in items) Console.WriteLine(item);
    }
    //Write a generic function PrintPair<TFirst, TSecond>(TFirst first, TSecond second) that prints both values and the name of each value's type.
    static void PrintPair<TFirst, TSecond>(TFirst first, TSecond second)
    {
        Console.WriteLine(first.GetType() + ", " + first);
        Console.WriteLine(second.GetType() + ", " + second);
    }
    //Write a generic function Repeat<T>(T value, int count) that returns a new List<T> containing value repeated count times
    static List<T> Repeat<T>(T value, int count)
    {
        List<T> list = new List<T>();
        while (count > 0)
        {
            list.Add(value);
            count--;
        }
        return list;
    }
    //Write a generic function CountWhere<T>(List<T> items, Predicate<T> condition) that returns how many items make condition return true
    static int CountWhere<T>(List<T> items, Predicate<T> condition)
    {
        int count = 0;
        foreach (T item in items)
        {
            bool i = condition(item);
            if (i) count++;
        }

        return count;
    }
    //Write a generic function IsBetween<T>(T value, T min, T max) that returns true if value is greater than or equal to min and less than or equal to max. It must work for numbers, strings, and characters
    static bool IsBetween<T>(T value, T min, T max) where T : IComparable<T>
    {
        return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
    }
    
    static void Display<T>(T value)
     {
         Console.WriteLine("the values of the generic box are: " +  value);
     }

     static void PrintList<T>(List<T> items)
     {
         Console.WriteLine("[");
         foreach (T item in items) Console.WriteLine((item + ", "));
         Console.WriteLine("]");
     }
    
    public static void Main(string[] args)
    {
        GenericBox<int, int> b1 = new GenericBox<int, int>();
        b1.Box(1, 1);
        Display(b1.Unbox());

        GenericBox<int, string> b2 = new GenericBox<int, string>();
        b2.Box(1, "User1");
        Display(b2.Unbox());

        var results = GenericDelegates.Map([1, 2, 3, 4], GenericDelegates.IsEven);
        Console.WriteLine(results);
        PrintList(results);
        
        PrintTwice("hello");
        PrintList(new List<string> {"Trevor", "Nicholas", "Daniel"});
    }
}
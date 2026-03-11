using System.Globalization;
using System.Runtime.InteropServices.JavaScript;

namespace FirstProject;

public class FirstProblem
{
    public static void Main()
    {
        Fibonacci();
    }

    private static void Fahrenheit()
    {
        double temp;
        Console.WriteLine("Enter a temperature: ");
        temp = Convert.ToDouble(Console.ReadLine());
        double ftemp = (temp * 9 / 5) + 32;
        Console.WriteLine(ftemp);
    }

    private static void Calculator(Double A, Double B)
    {
        Console.WriteLine("Enter A: ");
        A = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter B: ");
        B = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("A + B =", A+B);
        Console.WriteLine("A - B =", A-B);
        Console.WriteLine("A * B =", A*B);
        Console.WriteLine("A / B =", A / B);
    }

    private static void Concatenate(String str1, String str2)
    {
        Console.WriteLine("String 1: ");
        str1 = Console.ReadLine();
        Console.WriteLine("String 2: ");
        str2 = Console.ReadLine();
        String str3 = String.Concat(str1, str2);
        str3 = str3.ToUpper();
        Console.WriteLine($"Length of {str3} is {str3.Length}");
    }

    private static void LbsToKg(Double InitialWeight)
    {
        const double LbsToKg = 0.45359237;
        const double MoonGrav = 0.165;
        const double MarsGrav = 0.377;

        double kgs = InitialWeight * LbsToKg;
        double grams = kgs * 1000;
        double tonnes = kgs / 1000;

        double MoonWeight = InitialWeight * MoonGrav;
        double MarsWeight = InitialWeight * MarsGrav;
    }

    private static void GradeAvg()
    {
        int[] Grades = new int[5];
        int sum = 0;
        for (int i = 0; i < Grades.Length; i++)
        {
            Console.WriteLine("Enter a grade: ");
            Grades[i] = Convert.ToInt16(Console.ReadLine());
            sum += Grades[i];
        }
        Console.WriteLine($"Average grade is {Convert.ToDouble(sum) / Grades.Length}");
    }

    private static void IsPalindrome()
    {
        Console.WriteLine("Enter a string: ");
        String str1 = Console.ReadLine();
        String str2 = "";
        for (int i = str1.Length; i > 0; i--)
        {
            str2 += str1[i];
        }

        if (str1 == str2)
        {
            Console.WriteLine($"{str1} is a palindrome");
        }
        else
        {
            Console.WriteLine($"{str1} is not a palindrome");
        }
    }

    private static void ShoppingList()
    {
        List<string> ShoppingList = new List<string>();
        bool done = false;
        int i = 0;
        do
        {
            Console.WriteLine("Item to add to list: ");
            String Input = Console.ReadLine();
            if (Input.ToLower() == "exit")
            {
                done = true;
            }
            else
            {
                if (Input != "")
                {
                    ShoppingList.Add(Input);
                }
                i++;
            }
        } while (!done);
        Console.WriteLine("Shopping List: ");
        for(int j = 0; j < ShoppingList.Count; j++)
        {
            Console.WriteLine(ShoppingList[j]);
        }
    }

    private static void SortNumbers()
    {
        int[] numbers = { 6, 4, 3, 1, 5, 2, 10 };
        for (int i = numbers.Length; i > 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
                }
            }
        }
        Console.WriteLine(numbers);
    }

    private static void ExpenseTracker()
    {
        var expenses = new List<(string, double)>();
        bool done = false;
        int i = 0;
        double total = 0;
        do
        {
            Console.WriteLine("Enter expense name");
            string expense = Convert.ToString(Console.ReadLine());
            if (expense.ToLower() == "end" || expense == "")
            {
                done = true;
            }
            Console.WriteLine("Enter expense cost");
            double cost = Convert.ToDouble(Console.ReadLine());
            expenses.Add((expense, cost));
        } while (!done);

        foreach ((string, double) exp in expenses)
        {
            total += exp.Item2;
        }
        Console.WriteLine($"Total cost: ${total}");
    }

    private static void Fibonacci()
    {
        int a = 0;
        int b = 1;
        int c = 1;
        Console.WriteLine("Enter how many places in the fibonacci sequence you want to print: ");
        int n = Convert.ToInt16(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(a);
            a = b;
            b = c;
            c = a + b;
        }
        
    }
}
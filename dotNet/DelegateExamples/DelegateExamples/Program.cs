namespace DelegateExamples;

internal static class Program
{
    public delegate int myIntToIntDelegate(int n);
    public delegate void PrintMessage(String msg);
    public delegate int MathOperation(int a, int b);

    public delegate double Returner(float a, float b);

    public delegate bool banana2(string a);

    public delegate int banana3(bool a);

    public delegate double banana4(int x, int y);

    public delegate int banana5(int a); //clone of myIntToIntDelegate
    
    public static void Main(string[] args)
    {
        myIntToIntDelegate func1 = Increment;
        myIntToIntDelegate func2 = Decrement;
        myIntToIntDelegate func3 = Halve;
        Action<string> func4 = SendEmail;
        func4 += SendFax;
        func4("Hey there this is an advertisement");

        //MathOperation math1 = Add; // Implicit instantiation
        MathOperation operation = new MathOperation(Add); //Explicit instantiation
        //They are identical in the intermediary language, it's just different ways to write it
        
        Console.WriteLine($"Operation(5, 3) = {operation(5, 3)}");

        MathOperation product = Multiply;
        Console.WriteLine($"product(5, 3) = {product(5,3)}");
        operation = Subtract;

        Console.WriteLine($"Operation(5, 3) = {operation(5, 3)}");
        Console.WriteLine($"operation.Method.Name = {operation.Method.Name}");
        Console.WriteLine($"operation.Target = {(operation.Target is null ? "null (static method)" : operation.Target)}");
        Console.WriteLine($"MathOperation base type = {typeof(MathOperation).BaseType}");

        var operations = new Dictionary<string, MathOperation>
        {
            ["+"] = Add,
            ["-"] = Subtract,
            ["*"] = Multiply,
        };

        foreach (string op in new[] { "+", "-", "*" })
        {
            MathOperation currentOperation = operations[op];
            Console.WriteLine($"7 {op} 2 = {currentOperation(7, 2)} (Calls {currentOperation.Method.Name})");
        }

        Calculator calc = new Calculator("A");
        MathOperation operation1 = calc.Subtract;
        Console.WriteLine($"operation1(10, 4) = {operation1(10, 4)}");

        Calculator calcA = new Calculator("A");
        Calculator calcB = new Calculator("B");

        MathOperation subtractOnA = calcA.Subtract;

        Returner r1 = (float a, float b) => a / b;
        Returner r2 = (float a, float b) => (a + b) / b;


        User u1 = new User()
        {
            Name = "John Doe",
            Email = "johndoe@gmail.com"
        };

        User u2 = new User()
        {
            Name = "Jane Doe",
            Email = "janedoe@gmail.com"
        };

        Publisher subscriptionService = new Publisher();
        subscriptionService.Subscribe(GenerateEmail(u1));
        subscriptionService.Subscribe(GenerateEmail(u2));
        
        subscriptionService.Publish("This is the first newsletter email");
    }

    static Subscription GenerateEmail(User u)
    {
        return (string str) => Console.WriteLine($"Hey {u.Name}, this is an automated email because you subscribed with email {u.Email}");
    }
    
    static int Add(int a, int b) {return a + b;}
    static int Subtract(int x, int y) {return x - y;}
    static int Multiply(int a, int b) {return a * b;}
    static double Divide(int x, int y){return (double)x/y;}
    static int Square(int a){return a * a;}

    static int Increment(int n) => n + 1;
    static int Decrement(int n) => n - 1;
    static int Halve(int n) => n / 2;
    static void SendEmail(string msg) => Console.WriteLine($"Email content: {msg}");
    static void SendFax(string msg) => Console.WriteLine($"Fax content: {msg}");
}
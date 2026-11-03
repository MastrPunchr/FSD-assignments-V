namespace GenericsExample;
public delegate void ActionDelegate<T>(T value);
public delegate bool PredicateDelegate<T>(T value);
public delegate TOut FunctionDelegate<TIn, TOut>(TIn value);

internal class GenericDelegates
{
    public static bool IsEven(int value) => value % 2 == 0;

    public static List<TOut> Map<TIn, TOut>(List<TIn> items, Func<TIn, TOut> transform)
    {
        var result = new List<TOut>();
        foreach (var item in items)
        {
            result.Add(transform(item));
        }

        return result;
    }
}
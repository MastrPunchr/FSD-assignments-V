namespace Kattis;

class Program
{
    public static void Main()
    {
        Parking();
        RadioCommercials();
        MagicalCows();
    }
    
    private static void Parking()
    {
        // Read first line: A B C (prices)
        var prices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int A = prices[0], B = prices[1] * 2, C = prices[2] * 3;
    
        // Read arrival and departure times for 3 trucks
        var trucks = new (int arrival, int departure)[3];
        for (int i = 0; i < 3; i++)
        {
            var times = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            trucks[i] = (times[0], times[1]);
        }
        
        //Gets the latest departure time to know when to end the logic
        int maxDeparture = trucks.Max(t => t.departure);
    
        int totalCost = 0;
        for (int minute = 1; minute <= maxDeparture; minute++)
        {
            int parkedCount = 0;
            for (int i = 0; i < 3; i++)
            {
                if (trucks[i].arrival <= minute && minute < trucks[i].departure)
                    parkedCount++;
            }
            int cost = parkedCount switch
            {
                1 => A,
                2 => B,
                3 => C,
                _ => 0
            };
            totalCost += cost;
            
            //debug line because the program was being finicky 
            //Console.WriteLine($"Minute {minute}: {parkedCount} trucks, minute cost {cost}, total so far: {totalCost}");
        }
    
        Console.WriteLine(totalCost);
    }

    private static void RadioCommercials()
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int p = int.Parse(input[1]);
        
        int[] students = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        
        int maxProfit = 0;
        int currentSum = 0;
        
        for (int i = 0; i < n; i++)
        {
            // Net profit for this break (revenue - cost)
            int netProfit = students[i] - p;
            
            // Either extend current sequence or start fresh
            currentSum = Math.Max(0, currentSum + netProfit);
            
            // Track the best profit found so far
            maxProfit = Math.Max(maxProfit, currentSum);
        }
        
        Console.WriteLine(maxProfit);
    }

    private static void MagicalCows()
    {
        string[] firstLine = Console.ReadLine().Split();
        int C = int.Parse(firstLine[0]);
        int N = int.Parse(firstLine[1]);
        int M = int.Parse(firstLine[2]);
        
        //the key is how many cows are on the farm and the value is how many farms have that value
        Dictionary<int, long> freq = new Dictionary<int, long>();
        
        for (int i = 0; i < N; i++)
        {
            //ci is cow index. instead of having a bunch of different farms we instead just have an array that collects how many farms contain ci cows. for example freq[1] = 5 would mean there are 5 farms that have only 1 cow
            int ci = int.Parse(Console.ReadLine());
            if (freq.ContainsKey(ci))
                freq[ci]++;
            else
                freq[ci] = 1;
        }
        
        int[] arr = new int[M]; //an array storing each day the inspector shows up
        for (int i = 0; i < M; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        
        //res[d] = number of farms on day d
        long[] res = new long[51];
        
        //simulates all days up to the highest number in M (the last day that there is an inspection)
        for (int i = 0; i <= arr.Max(); i++)
        {
            long t = 0;
            foreach (var kvp in freq)
            {
                t += kvp.Value; //adds how many farms exist
            }
            res[i] = t; //stores farm count for day i
            
            Dictionary<int, long> nextFreq = new Dictionary<int, long>();
            
            //Okay so I think I might understand what I meant when I wrote this but I'm not sure. I *think* it is comparing if each number doubled is greater than C (the max amount of cows per farm).
            foreach (var kvp in freq)
            {
                long doubled = (long)kvp.Key * 2;
                
                if (doubled > C)
                {
                    long stay = (doubled + 1) / 2;   // ceiling (what cows stay on farm A)
                    long leave = doubled / 2;        // floor (what cows go to farm B)
                    
                    if (nextFreq.ContainsKey((int)stay))
                        nextFreq[(int)stay] += kvp.Value;
                    else
                        nextFreq[(int)stay] = kvp.Value;
                    
                    if (nextFreq.ContainsKey((int)leave))
                        nextFreq[(int)leave] += kvp.Value;
                    else
                        nextFreq[(int)leave] = kvp.Value;
                }
                else
                {
                    if (nextFreq.ContainsKey((int)doubled))
                        nextFreq[(int)doubled] += kvp.Value;
                    else
                        nextFreq[(int)doubled] = kvp.Value;
                }
            }
            
            freq = nextFreq;
        }
        
        foreach (int dj in arr)
        {
            Console.WriteLine(res[dj]);
        }
    }
}
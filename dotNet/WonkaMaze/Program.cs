namespace WonkaMaze;

class Program
{
    public static void Main()
    {
        Maze maze1 = new Maze("../../../Maze1.txt");
        maze1.Path = maze1.SolveMaze();
        maze1.PrintPath();
    }

    public static void Wonka()
    {
        Queue<Customer> entranceLine = GenerateEntranceLine();
        Queue<Customer> oompaLine = new Queue<Customer>();
        Queue<Customer> loompaLine = new Queue<Customer>();
        int servedCustomers = 0;
        int remainingTime = 0;

        for (int i = 1; i <= 600; i++)
        {
            //Entrance loop
            if (entranceLine.Count > 0 && entranceLine.Peek().ArrivalTime == i)
            {
                oompaLine.Enqueue(entranceLine.Dequeue());
            }

            //Oompa loop
            if (oompaLine.Count > 0 && oompaLine.Peek().OompaWaitTime == 0)
            {
                loompaLine.Enqueue(oompaLine.Dequeue());
            }
            else if(oompaLine.Count > 0)
            {
                oompaLine.Peek().OompaWaitTime--;
            }

            //Loompa loop
            if (loompaLine.Count > 0 && loompaLine.Peek().LoompaWaitTime == 0)
            {
                loompaLine.Dequeue();
                servedCustomers++;
            }
            else if(loompaLine.Count > 0)
            {
                loompaLine.Peek().LoompaWaitTime--;
            }

            string frontLineCustomer = entranceLine.Count == 0 ? "None" : "Customer #" + entranceLine.Peek().CustomerNo;
            string oompaLineFront = oompaLine.Count == 0 ? "None" : "Customer #" + oompaLine.Peek().CustomerNo;
            string loompaLineFront = loompaLine.Count == 0 ? "None" : "Customer #" + loompaLine.Peek().CustomerNo;
            
            Console.WriteLine($"Time: {i}, Entrance Line Front: {frontLineCustomer}, Oompa's line currently has {oompaLine.Count} customer(s) with {oompaLineFront} in front which they need to wait for {(oompaLine.Count > 0 ? oompaLine.Peek().OompaWaitTime : 0)} minute(s). Loompa's line currently has {loompaLine.Count} customer(s) with Customer #{loompaLineFront} in front with a remaining time of {(loompaLine.Count > 0? loompaLine.Peek().LoompaWaitTime : 0)} minute(s).");
        }

        foreach (Customer cs in oompaLine.Concat(loompaLine))
        {
            remainingTime += cs.OompaWaitTime + cs.LoompaWaitTime;
        }
        
        //Exit statement
        Console.WriteLine($"\nThe Store is closed to new customers, There are {oompaLine.Count} customer(s) in Oompa's line and {loompaLine.Count} customer(s) in the checkout line.\nSo far we have had {servedCustomers} customers!\nWe need to stay open for {remainingTime} minutes to finish processing our customers orders...");
    }
    private static Queue<Customer> GenerateEntranceLine()
     {
         Queue<Customer> customers = new Queue<Customer>();
         int nextArrivalTime = 1;
         Random rnd = new Random();
 
         while (nextArrivalTime <= 600)
         {
             int arrivalTime = rnd.Next(5, 11);
             customers.Enqueue(new Customer(nextArrivalTime, rnd.Next(7, 15), rnd.Next(5, 9)));
             nextArrivalTime += arrivalTime;
         }
         
         return customers;
     }
}